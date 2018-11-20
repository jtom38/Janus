using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.Entities;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {        
        private JanusDbContext _context;

        public CreateModel(JanusDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Janus.Domain.Entities.Categories Categories { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Categories.ID = Guid.NewGuid();
            Categories.DateAdded = DateTime.Now;
            Categories.AddedBy = "User";

            await _context.Categories.AddAsync(Categories);
            //await _context.Categories.InsertAsync(Categories);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}