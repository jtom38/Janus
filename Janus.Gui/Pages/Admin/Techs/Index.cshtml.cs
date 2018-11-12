using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.Techs
{
    public class IndexModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public IndexModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        public IList<Domain.Entities.Techs> Techs { get;set; }

        public async Task OnGetAsync()
        {
            //Techs = await _context.Techs.ToListAsync();
            Techs = await _context.Techs
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .ToListAsync();
        }
    }
}
