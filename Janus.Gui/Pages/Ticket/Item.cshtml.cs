using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Janus.Domain.Entities;
using Janus.Persistence;
using Microsoft.EntityFrameworkCore;
using Janus.Domain.AppSettings;
using Microsoft.Extensions.Options;
using System;

namespace Janus.Gui.Pages.Ticket
{
    public class TicketModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public TicketModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        //[TempData]
        [BindProperty]
        public Domain.Entities.Ticket TicketInformation { get; set; }

        //[TempData]
        [BindProperty]
        public IList<TicketComments> TicketComments { get; set; }

        [BindProperty]
        public IList<TicketStatus> TicketStatus { get; set; }

        //[TempData]
        [BindProperty]
        public ComputerID ComputerInfo { get; set; }

        //[TempData]
        [BindProperty]
        public List<HardDrives> HdInfo { get; set; }

        //[TempData]
        [BindProperty]
        public List<Network> NetInfo { get; set; }

        //[TempData]
        [BindProperty]
        public List<WindowsUpdates> WinUpdates { get; set; }

        [BindProperty]
        public TicketComments NewComment { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ViewAction { get; set; }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(ViewAction)) { ViewAction = "ticket"; }

            if (ViewAction.Equals("ticket"))
            {
                TicketInformation = await _context.Tickets
                    .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
                /*
                TicketComments = await _context.TicketComments
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .Where(x => x.ID == id)
                .ToListAsync();
                */
            }
            else if (ViewAction.Equals("computer"))
            {

            }

            /*
            //TicketStatus = await _context.TicketStatus.ToListAsync();
            if (!string.IsNullOrEmpty(TicketInformation.Computer))
            {
                //ComputerInfo = await _context.Computer.SingleOrDefaultAsync(x => x.Pk == TicketInformation.ComputerPk);
                ComputerInfo = await _context.ComputerIDCollection.AsQueryable<ComputerID>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.GUID == TicketInformation.ComputerID)
                    .FirstOrDefaultAsync();
                //HdInfo = await _context.HardDrive.Where(x => x.ComputerPk == TicketInformation.ComputerPk).ToListAsync();
                HdInfo = await _context.HardDrivesCollection.AsQueryable<HardDrives>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.GUID == TicketInformation.ComputerID)
                    .ToListAsync();

                //NetInfo = await _context.Network.Where(x => x.ComputerPk == TicketInformation.ComputerPk).ToListAsync();
                NetInfo = await _context.NetworkCollection.AsQueryable<Network>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.ComputerID == TicketInformation.ComputerID)
                    .ToListAsync();

                //WinUpdates = await _context.WindowsUpdates.Where(x => x.ComputerPk == TicketInformation.ComputerPk).ToListAsync();
                WinUpdates = await _context.WindowsUpdateCollection.AsQueryable<WindowsUpdates>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.GUID == TicketInformation.ComputerID)
                    .ToListAsync();
            }
            */
            

            if (TicketInformation == null)
            {
                return NotFound();
            }
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }

        private async Task GetTicketInfoAsync(int? id)
        {
            //using (ApiTickets apiTickets = new ApiTickets())
            //{
            //    TicketInformation = await apiTickets.GetSingleItemAsync(id);
            //};
        }

        private async Task GetTicketCommentsAsync(int? id)
        {
            //using (ApiTicketComments api = new ApiTicketComments())
            //{
            //    TicketComments = await api.GetByTicketIdAsync(id);
            //};  
        }

        private async Task GetComputerInfoAsync()
        {
            //using(ApiComputer api = new ApiComputer())
            //{
            //    ComputerInfo = await api.ByPk("02bdf711-c2b8-400a-b7e8-eafeb1ac2049");
            //}
        }

        private async Task GetHardDriveInfoAsync()
        {
            //using(ApiHardDrive api = new ApiHardDrive())
            //{
            //    HdInfo = await api.GetAllByComputerPkAsync("02bdf711-c2b8-400a-b7e8-eafeb1ac2049");
            //}
        }

        private async Task GetNetworkInfoAsync()
        {
            //using(ApiNetwork api = new ApiNetwork())
            //{
            //    NetInfo = await api.GetAllByComputerPkAsync("02bdf711-c2b8-400a-b7e8-eafeb1ac2049");
            //}
        }

        private async Task GetWindowsUpdatesAsync()
        {
            //using(ApiWindowsUpdates api = new ApiWindowsUpdates())
            //{
            //    WinUpdates = await api.GetAllByComputerPkAsync("02bdf711-c2b8-400a-b7e8-eafeb1ac2049");
            //}
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync()
        {


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            ////_context.Attach(TicketInformation).State = EntityState.Modified;
            //var z = await _context.Tickets
            //    .SingleOrDefaultAsync(x => x.Pk == TicketInformation.GUID);

            //if(z != null)
            //{
            //    if (TicketInformation.Status == "Resolved")
            //    {
            //        z.TicketFinished = DateTime.Now.ToString();
            //    }

            //    z.Status = TicketInformation.Status;
            //    _context.Update(z);
            //}

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TicketsInformationExists(TicketInformation.Pk))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            ////return Page();
            return Redirect($"./Ticket?id={TicketInformation.ID}");
        }

        private void TicketsInformationExists(long id)
        {
            //returns bool
            //return _context.Tickets.Any(e => e.Pk == id);
        }
    }
}