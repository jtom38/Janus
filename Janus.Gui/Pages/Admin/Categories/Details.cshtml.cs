using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Janus.Model.Data;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class DetailsModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private DatabaseContext _context;

        public DetailsModel()
        {
            _context = new DatabaseContext();
        }

        public Model.Data.Collections.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m.Pk == id);
            Categories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
