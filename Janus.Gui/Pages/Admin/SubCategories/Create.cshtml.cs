using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class CreateModel : PageModel
    {
        //private DatabaseContext _context;
        private DatabaseContext _context;

        public CreateModel()
        {
            _context = new DatabaseContext();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.Data.Collections.Categories SubCategories { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SubCategories.SubCategory = true;
            SubCategories.TenantID = "debug";

            await _context.Categories.InsertAsync(SubCategories);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}