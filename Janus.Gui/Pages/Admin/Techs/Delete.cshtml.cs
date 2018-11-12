using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Janus.Gui.Pages.Admin.Techs
{
    public class DeleteModel : PageModel
    {
        private DatabaseContext _context;

        public DeleteModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Data.Collections.Techs Techs { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Techs = await _context.Techs.SingleOrDefaultAsync(m => m.Pk == id);
            Techs = await _context.TechsCollection.AsQueryable<Model.Data.Collections.Techs>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (Techs == null)
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

            //Techs = await _context.Techs.FindAsync(id);
            Techs = await _context.TechsCollection.AsQueryable<Model.Data.Collections.Techs>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (Techs != null)
            {
                await _context.Techs.DeleteAsync(Techs.GUID);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
