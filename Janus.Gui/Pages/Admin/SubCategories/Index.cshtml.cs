using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Janus.Persistence;
using Janus.Domain.Entities;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class IndexModel : PageModel
    {
        private JanusDbContext _context;

        public IndexModel(JanusDbContext context)
        {
            _context = context;
        }

        public IList<Domain.Entities.Categories> SubCatList { get;set; }

        [BindProperty]
        public Domain.Entities.Categories SubCat { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ViewAction { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewMode { get; set; }

        [BindProperty(SupportsGet =true)]
        public string id { get; set; }

        string CookieViewMode = "Admin.SubCategories.Index.View";

        public async Task<IActionResult> OnGetAsync()
        {
            /*
            SubCatList = await _context.SubCategories.ToListAsync();
            
            if (string.IsNullOrEmpty(ViewAction))
            {
                ViewAction = "index";
            }
            if(ViewAction == "index")
            {
                ManageView(ViewMode);
                SubCatList = await _context.Categories
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.SubCategory == true)
                    .ToListAsync();
            }
            else if(ViewAction == "create")
            {

            }
            else if(ViewAction == "delete" ||
                ViewAction == "edit" ||
                ViewAction == "details")
            {
                //SubCategories = await _context.SubCategories.SingleOrDefaultAsync(m => m.Pk == id);
                SubCat = await _context.Categories
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.SubCategory == true)
                    .Where(x => x.GUID == id)
                    .FirstOrDefaultAsync();

                if (SubCat == null)
                {
                    return RedirectToPage("./Index", new { });
                }
            }

            */
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ViewAction.Equals("create"))
            {

                SubCat.SubCategory = true;
                SubCat.TenantID = "debug";
                SubCat.AddedBy = "identity.user";
                SubCat.DateAdded = DateTime.Now;

                if(SubCat != null)
                {
                    await _context.Categories.AddAsync(SubCat);
                }
                
            }
            else if (ViewAction.Equals("edit"))
            {
                //need the _id to update
                var rec = await _context.Categories(SubCat.ID);
                SubCat.ID = rec.ID;
                SubCat.SubCategory = true;
                try
                {
                    await _context.Categories.Update(rec.ID, SubCat);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }
            else if (ViewAction.Equals("delete"))
            {
                SubCat = await _context.Categories
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.ID == SubCat.GUID)
                    .Where(x => x.SubCategory == true)
                    .FirstOrDefaultAsync();

                if (SubCat != null)
                {
                    await _context.Categories.Remove(SubCat.GUID);
                    await _context.SaveChangesAsync();
                }
            }
            */
            
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
