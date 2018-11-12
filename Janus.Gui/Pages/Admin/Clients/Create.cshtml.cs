using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Janus.Gui.Pages.Admin.NewFolder
{
    public class CreateModel : PageModel
    {
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
        public Model.Data.Collections.Clients Clients { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Clients.InsertAsync(Clients);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}