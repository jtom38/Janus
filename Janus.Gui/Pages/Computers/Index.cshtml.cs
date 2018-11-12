using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Janus.Gui.Pages.Computers
{
    public class IndexModel : PageModel
    {

        private JanusDbContext _context;

        public IndexModel(JanusDbContext context)
        {
            _context = context;
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
                .Where(x => x.TenantID == "debug")
                .ToListAsync();
        }
    }
}