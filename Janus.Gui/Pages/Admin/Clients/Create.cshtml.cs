using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.NewFolder
{
    public class CreateModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public CreateModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.Clients Clients { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Clients.AddAsync(Clients);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}