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

namespace Janus.Gui.Pages.Admin.SubCategories
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

        public Domain.Entities.SubCategories SubCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //SubCategories = await _context.SubCategories.SingleOrDefaultAsync(m => m.Pk == id);
            SubCategories = await _context.SubCategories
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .FirstOrDefaultAsync();

            if (SubCategories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
