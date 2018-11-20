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
    public class DeleteModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public DeleteModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        [BindProperty]
        public Domain.Entities.SubCategories SubCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //SubCategories = await _context.SubCategories.SingleOrDefaultAsync(m => m.Pk == id);
            SubCategories = await _context.SubCategories
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();

            if (SubCategories == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //SubCategories = await _context.SubCategories.FindAsync(id);
            SubCategories = await _context.SubCategories
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .FirstOrDefaultAsync();

            if (SubCategories != null)
            {
                _context.SubCategories.Remove(SubCategories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
