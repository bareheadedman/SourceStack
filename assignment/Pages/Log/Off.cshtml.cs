using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment.Pages.Log
{
    public class OffModel : PageModel
    {
        public void OnGet()
        {
            Response.Cookies.Delete(Keys.userId);
        }
    }
}
 