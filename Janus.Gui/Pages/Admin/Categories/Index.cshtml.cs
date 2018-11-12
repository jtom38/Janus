using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Janus.Model.Data;

namespace Janus.Gui.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        //private readonly JanusGUI.Models.DatabaseContext _context;
        private DatabaseContext _context;

        public IndexModel()
        {
            _context = new DatabaseContext();
        }

        public IList<Model.Data.Collections.Categories> Categories { get;set; }

        [BindProperty]
        public string ViewMode { get; set; }

        string CookieViewMode = "Admin.Categories.Index.View";

        public async Task OnGetAsync(string ViewMode)
        {
            ManageView(ViewMode);

            //Categories = await _context.Categories.ToListAsync();
            Categories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.SubCategory == false)
                .ToListAsync();

            var cat = Categories.Count();
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
                else
                {
                    //use what we got from the cookie
                    ViewMode = tView;
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
