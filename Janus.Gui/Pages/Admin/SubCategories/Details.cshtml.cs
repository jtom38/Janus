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
    public class DetailsModel : PageModel
    {
        private DatabaseContext _context;

        public DetailsModel()
        {
            _context = new DatabaseContext();
        }

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
                .FirstOrDefaultAsync();

            if (SubCategories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
