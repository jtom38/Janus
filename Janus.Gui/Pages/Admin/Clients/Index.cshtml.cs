using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Janus.Persistence;
using Janus.Domain.AppSettings;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.Clients
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

        public IList<Domain.Entities.Clients> CliList { get; set; }
        
        [BindProperty]
        public Domain.Entities.Clients Cli { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewAction { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewMode { get; set; }

        [BindProperty(SupportsGet =true)]
        public Guid id { get; set; }

        string CookieViewMode = "Admin.Clients.Index.View";

        public async Task<IActionResult> OnGetAsync(string ViewMode)
        {
            if (string.IsNullOrEmpty(ViewAction)) { ViewAction = "index"; }

            ManageView(ViewMode);

            if (ViewAction == "index")
            {
                CliList = await _context.Clients
                    .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                    .ToListAsync();
            }
            else if(ViewAction == "create")
            {

            }
            else if(ViewAction == "delete" || ViewAction == "details" || ViewAction == "edit")
            {
                if (id == null)
                {
                    return RedirectToPage("./Index", new { });
                }

                //Clients = await _context.Clients.SingleOrDefaultAsync(m => m.Pk == id);
                Cli = await _context.Clients
                    .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

                if (Cli == null)
                {
                    return RedirectToPage("./Index", new { });
                }
                
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ViewAction.Equals("delete"))
            {
                Cli = await _context.Clients
                    .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                    .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

                if (Cli != null)
                {
                    _context.Clients.Remove(Cli);
                    await _context.SaveChangesAsync();
                }
            }
            else if (ViewAction.Equals("edit"))
            {
                //need the _id to update
                var rec = _context.Clients.Where(x => x.ID == id);
                //Cli.ID = rec.ID;
                
                try
                {
                    //await _context.Clients.UpdateAsync(rec.ID, Cli);
                    //await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }


            return RedirectToPage("./Index");
        }

        private void ManageView(string param)
        {
            try
            {
                //get cookie data
                string tView = GetViewCookie();

                //if no param and cookie was null set default value
                if (string.IsNullOrEmpty(param) &&
                    string.IsNullOrEmpty(tView))
                {
                    SetViewCookie(CookieViewMode, "card");
                    ViewMode = "card";
                }
                //Check to see if user defined to change view and if not use cookie
                else if (string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(tView))
                {
                    ViewMode = tView;
                }
                else if (param != tView)
                {
                    //update the value
                    if (!tView.Equals(param))
                    {
                        SetViewCookie(CookieViewMode, param);
                    }
                    ViewMode = param;
                }
            }
            catch
            {
                ViewMode = "card";
            }
        }

        public void SetViewCookie(string key, string value)
        {
            try
            {
                CookieOptions cookie = new CookieOptions()
                {
                    Secure = true
                };

                Response.Cookies.Append(key, value, cookie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private string GetViewCookie()
        {
            try
            {
                return Request.Cookies[CookieViewMode].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
