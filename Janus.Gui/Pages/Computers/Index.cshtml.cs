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

namespace Janus.Gui.Pages.Computers
{
    public class IndexModel : PageModel
    {

        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public IndexModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        [BindProperty]
        public List<Janus.Domain.Entities.ComputerID> ListComputer { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewMode { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewAcion { get; set; }

        /// <summary>
        /// Defines the location in the cookie to get filter info.
        /// </summary>
        readonly string CookieFilter = "Tickets.Index.Filter";

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(ViewMode)) { ViewMode = "table"; }

            ListComputer = await _context.ComputerIDs.AsQueryable<Domain.Entities.ComputerID>()
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .ToListAsync();
        }
    }
}