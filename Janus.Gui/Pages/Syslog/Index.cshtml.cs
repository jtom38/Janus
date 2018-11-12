using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Janus.Gui.Pages.Syslog
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string ViewAction { get; set; }

        [BindProperty(SupportsGet =true)]
        public string ViewMode { get; set; }

        public void OnGet()
        {

        }
    }
}