using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver.Linq;
using Janus.Model.Data;

namespace Janus.Gui.Pages.Admin.Clients
{
    public class IndexModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private DatabaseContext _context;

        public IndexModel()
        {
            _context = new DatabaseContext();
        }

        public IList<Model.Data.Collections.Clients> CliList { get; set; }
        
        [BindProperty]
        public Model.Data.Collections.Clients Cli { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewAction { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewMode { get; set; }

        [BindProperty(SupportsGet =true)]
        public string id { get; set; }

        string CookieViewMode = "Admin.Clients.Index.View";

        public async Task<IActionResult> OnGetAsync(string ViewMode)
        {
            if (string.IsNullOrEmpty(ViewAction)) { ViewAction = "index"; }

            ManageView(ViewMode);

            if (ViewAction == "index")
            {
                CliList = await _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>()
                    .Where(x => x.TenantID == "debug")
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
                Cli = await _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.GUID == id)
                    .FirstOrDefaultAsync();

                if (Cli == null)
                {
                    return RedirectToPage("./Index", new { });
                }
                
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ViewAction.Equals("delete"))
            {
                Cli = await _context.ClientsCollection.AsQueryable<Model.Data.Collections.Clients>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.GUID == id)
                    .FirstOrDefaultAsync();

                if (Cli != null)
                {
                    await _context.Clients.DeleteAsync(Cli.GUID);
                    //await _context.SaveChangesAsync();
                }
            }
            else if (ViewAction.Equals("edit"))
            {
                //need the _id to update
                var rec = await _context.Clients.GetFirstByGUIDAsync(Cli.GUID);
                Cli.ID = rec.ID;
                
                try
                {
                    await _context.Clients.UpdateAsync(rec.ID, Cli);
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
