using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class DeleteModel : PageModel
    {
        private DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Data.Collections.Categories SubCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //SubCategories = await _context.SubCategories.SingleOrDefaultAsync(m => m.Pk == id);
            SubCategories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.SubCategory == true)
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (SubCategories == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //SubCategories = await _context.SubCategories.FindAsync(id);
            SubCategories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.SubCategory == true)
                .FirstOrDefaultAsync();

            if (SubCategories != null)
            {
                await _context.Categories.DeleteAsync(SubCategories.GUID);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
