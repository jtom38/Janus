using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Domain.Entities;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Computers
{
    public class DetailsModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public DetailsModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        [BindProperty(SupportsGet = true)]
        public Guid id { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewAction { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ViewMode { get; set; }

        [BindProperty]
        public ComputerID Item { get; set; }

        [BindProperty]
        public IList<HardDrives> ListDrives { get; set; }

        [BindProperty]
        public IList<Network> ListNetwork { get; set; }

        [BindProperty]
        public IList<WindowsUpdates> ListWindowsUpdates { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrEmpty(ViewMode)) { ViewMode = "table"; }
            if (string.IsNullOrEmpty(ViewAction)) { ViewAction = "bios"; }

            if (string.IsNullOrEmpty(id.ToString()))
            {
                return Redirect("./Computers/Index");
            }
            else
            {

                Item = await _context.ComputerIDs
                    .Where(x => x.ID == id)
                    .SingleOrDefaultAsync();
                
                ListDrives = await _context.HardDrives
                    .Where(x => x.ComputerID == Item)
                    .ToListAsync();
                /*
                ListNetwork = await _context.Network
                    .Where(x => x.ComputerID == Item)
                    .ToListAsync();
                    */
                ListWindowsUpdates = await _context.WindowsUpdates
                   .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                   .Where(x => x.ComputerID == Item)
                   .ToListAsync();

                //we have a value to parse
                if (Item.TenantID != _options.Value.Debug.TenantID)
                {
                    return Redirect("./Computers/Index");
                }

                //valid tenantID
                return Page();

                
            }
            //return Redirect("./Computers/Index");
        }


    }
}