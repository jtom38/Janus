using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Janus.Domain.Entities;
using Janus.Persistence;

namespace Janus.Gui.Pages.Search
{
    public class IndexModel : PageModel
    {
        private JanusDbContext _context;

        public IndexModel(JanusDbContext context)
        {
            //_context = new DatabaseContext();
            //ListTickets = new List<Janus.Domain.Entities.Ticket>();
            _context = context;
        }

        [BindProperty]
        //Might be de not needed
        public string SearchValue { get; set; }

        [BindProperty]
        public Janus.Domain.Entities.Ticket Tickets { get; set; }

        [BindProperty]
        public IList<Janus.Domain.Entities.Ticket> ListTickets { get; set; }

        [BindProperty]
        public ComputerID Computers { get; set; }

        [BindProperty]
        public List<ComputerID> ListComputers { get; set; }

        [BindProperty]
        public Network Network { get; set; }

        [BindProperty]
        public List<Network> ListNetwork { get; set; }

        [BindProperty]
        public bool Reports { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewAction { get; set; }

        public void OnGet()
        {
            if(string.IsNullOrEmpty(ViewAction)) { ViewAction = "default"; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if(!string.IsNullOrEmpty(Tickets.Message) ||
                !string.IsNullOrEmpty(Tickets.Category) ||
                !string.IsNullOrEmpty(Tickets.SubmittedBy) ||
                !string.IsNullOrEmpty(Tickets.Computer))
            { await SearchTickets(); }
            
            if(!string.IsNullOrEmpty(Computers.ComputerName) ||
                !string.IsNullOrEmpty(Computers.Domain) ||
                !string.IsNullOrEmpty(Computers.Model) ||
                !string.IsNullOrEmpty(Computers.SkuNumber))
            { await SearchComputers(); }
            */
            return Page();
            
        }

        private async Task SearchTickets()
        {
            /*
            List<Janus.Domain.Entities.Ticket> temp = new List<Janus.Domain.Entities.Ticket>();
            if (!string.IsNullOrEmpty(Tickets.Message))
            {
                List<Janus.Domain.Entities.Ticket> t = new List<Janus.Domain.Entities.Ticket>();
                temp = await _context.TicketsCollection.AsQueryable<Janus.Domain.Entities.Ticket>()
                    .Where(x => x.ID == new Guid("f370fff6-7638-4cdd-8701-9e38ee54abdb")
                    .Where(x => x.Message.Contains(Tickets.Message))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Tickets.Category))
            {
                List<Domain.Entities.Ticket> t = new List<Janus.Domain.Entities.Ticket>();
                temp = await _context.TicketsCollection.AsQueryable<Janus.Domain.Entities.Ticket>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.CategoryID.Contains(Tickets.ID))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Tickets.SubCategory))
            {
                List<Janus.Model.Data.Collections.Tickets> t = new List<Janus.Model.Data.Collections.Tickets>();
                temp = await _context.TicketsCollection.AsQueryable<Janus.Model.Data.Collections.Tickets>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.SubCategoryID.Contains(Tickets.SubCategoryID))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Tickets.ComputerID))
            {
                List<Janus.Model.Data.Collections.Tickets> t = new List<Janus.Model.Data.Collections.Tickets>();
                temp = await _context.TicketsCollection.AsQueryable<Janus.Model.Data.Collections.Tickets>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.ComputerID.Contains(Tickets.ComputerID))
                    .ToListAsync();
                temp.AddRange(t);
            }
            if(temp.Count >= 1) { ListTickets.AddRange(temp); }
            */
        }

        private async Task SearchComputers()
        {
            /*
            List<ComputerID> temp = new List<ComputerID>();

            if (!string.IsNullOrEmpty(Computers.ComputerName))
            {
                List<ComputerID> t = new List<ComputerID>();
                temp = await _context.ComputerIDCollection.AsQueryable<ComputerID>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.ComputerName.Contains(Computers.ComputerName))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Computers.Domain))
            {
                List<ComputerID> t = new List<ComputerID>();
                temp = await _context.ComputerIDCollection.AsQueryable<ComputerID>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.Domain.Contains(Computers.Domain))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Computers.Model))
            {
                List<ComputerID> t = new List<ComputerID>();
                temp = await _context.ComputerIDCollection.AsQueryable<ComputerID>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.Model.Contains(Computers.Model))
                    .ToListAsync();
                temp.AddRange(t);
            }
            else if (!string.IsNullOrEmpty(Computers.SkuNumber))
            {
                List<ComputerID> t = new List<ComputerID>();
                temp = await _context.ComputerIDCollection.AsQueryable<ComputerID>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.SkuNumber.Contains(Computers.SkuNumber))
                    .ToListAsync();
                temp.AddRange(t);
            }
            
            if(temp.Count() >= 1) { ListComputers.AddRange(temp); }
            */
        }
    }
}