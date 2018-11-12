using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Janus.Gui.Pages.Admin.Techs
{
    public class EditModel : PageModel
    {
        private JanusDbContext _context;

        public EditModel(JanusDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Domain.Entities.Techs Techs { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Techs = await _context.Techs.SingleOrDefaultAsync(m => m.Pk == id);
            Techs = await _context.Techs
                .Where(x => x.TenantID == "debug")
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();

            if (Techs == null)
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

           // _context.Attach(Techs).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechsExists(Techs.ID))
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

        private bool TechsExists(Guid id)
        {
            //return _context.Techs.Any(e => e.Pk == id);
            return _context.Techs
                .Any(x => x.ID == id);
        }
    }
}
