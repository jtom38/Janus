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
    public class DeleteModel : PageModel
    {
        private DatabaseContext _context;

        public DeleteModel()
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Clients = await _context.Clients.FindAsync(id);
            Clients = await _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.GUID == id)
                .FirstOrDefaultAsync();

            if (Clients != null)
            {
                await _context.Clients.DeleteAsync(Clients.GUID);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
