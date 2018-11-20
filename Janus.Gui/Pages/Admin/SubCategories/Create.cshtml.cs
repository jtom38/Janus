using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class CreateModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _config;

        public CreateModel(JanusDbContext context, IOptions<AppSettings> config)
        {
            _context = context;
            _config = config;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entities.SubCategories SubCategories { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            SubCategories.TenantID = _config.Value.Debug.TenantID;

            await _context.SubCategories.AddAsync(SubCategories);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}