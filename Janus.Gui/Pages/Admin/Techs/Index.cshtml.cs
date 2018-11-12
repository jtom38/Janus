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
    public class IndexModel : PageModel
    {
        private DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<Model.Data.Collections.Techs> Techs { get;set; }

        public async Task OnGetAsync()
        {
            //Techs = await _context.Techs.ToListAsync();
            Techs = await _context.TechsCollection.AsQueryable<Model.Data.Collections.Techs>()
                .Where(x => x.TenantID == "debug")
                .ToListAsync();
        }
    }
}
