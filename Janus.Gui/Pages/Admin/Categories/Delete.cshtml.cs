using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private JanusDbContext _context;
        private IOptions<AppSettings> _config;

        public DeleteModel(JanusDbContext context, IOptions<AppSettings> config)
        {
            _context = context;
            _config = config;
        }

        [BindProperty]
        public Janus.Domain.Entities.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _context.Categories
                .Where(x => x.TenantID == ).FirstOrDefaultAsync();
            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m. == id);

            if (Categories == null)
            {
                return NotFound();
            }
            */
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categories = await _context.Categories
                .Where(x => x.TenantID == _config.Value.Debug.TenantID)
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
            //Categories = await _context.Categories.FindAsync(id);

            if (Categories != null)
            {
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
