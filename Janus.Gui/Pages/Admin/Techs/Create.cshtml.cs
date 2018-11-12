using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Janus.Gui.Pages.Admin.Techs
{
    public class CreateModel : PageModel
    {
        private DatabaseContext _context;
        //private readonly JanusGUI.Models.DatabaseContext _context;

        public CreateModel(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.Data.Collections.Techs Techs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Techs.DateLogged = DateTime.Now.ToString();
            Techs.GUID = Guid.NewGuid().ToString();

            await _context.Techs.InsertAsync(Techs);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}