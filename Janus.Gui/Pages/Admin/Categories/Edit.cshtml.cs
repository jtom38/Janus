using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public EditModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        [BindProperty]
        public Domain.Entities.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m.Pk == id);
            Categories = await _context.Categories
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .FirstOrDefaultAsync();

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Categories).State = EntityState.Modified;

            try
            {
               // await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (!CategoriesExists(Categories.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoriesExists(Guid id)
        {
            //return _context.Categories.Any(e => e.Pk == id);
            return _context.Categories
                .Any(x => x.ID == id);
        }
    }
}
