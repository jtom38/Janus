using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Janus.Gui.Pages.Admin.NewFolder
{
    public class EditModel : PageModel
    {
        private DatabaseContext _context;

        public EditModel()
        {
            _context = new DatabaseContext();
        }

        [BindProperty]
        public Model.Data.Collections.Clients Clients { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Clients = await _context.Clients.SingleOrDefaultAsync(m => m.Pk == id);
            Clients = await _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (Clients == null)
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

            //_context.Attach(Clients).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!ClientsExists(Clients.GUID))
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

        private bool ClientsExists(string id)
        {
            //return _context.Clients.Any(e => e.Pk == id);
            return _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>().Any(x => x.GUID == id);
        }
    }
}
