using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Janus.Gui.Pages.Admin.Techs
{
    public class CreateModel : PageModel
    {
        private JanusDbContext _context;
        //private readonly JanusGUI.Models.DatabaseContext _context;

        public CreateModel(JanusDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Techs Techs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Techs.DateLogged = DateTime.Now;
            Techs.ID = Guid.NewGuid();

            await _context.Techs.AddAsync(Techs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}