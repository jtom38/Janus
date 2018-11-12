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
    public class DetailsModel : PageModel
    {
        private DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

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
    }
}
