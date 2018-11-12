using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class DetailsModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private JanusDbContext _context;

        public DetailsModel(JanusDbContext context)
        {
            _context = context;
        }

        public Domain.Entities.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m.Pk == id);
            Categories = await _context.Categories
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
