using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Janus.Gui.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private JanusDbContext _context;

        public DeleteModel(JanusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Janus.Domain.Entities.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();
            //Categories = await _context.Categories.FindAsync(id);

            if (Categories != null)
            {
                _context.Categories.Remove(Categories.ID);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
