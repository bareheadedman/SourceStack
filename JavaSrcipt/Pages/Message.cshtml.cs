using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JavaSrcipt.Pages
{
    public class MessageModel : PageModel
    {
        public JsonResult OnGet()
        {
            Random nub = new Random();
            
            if (nub.Next(1,10)<6)
            {
                return new JsonResult(new { hasRead = true });

            }
            else
            {
                return new JsonResult(new { hasRead = false });

            }
        }
        public void OnPost()
        {

        }
    }
}
