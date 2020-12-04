using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E = assignment.Entities;

namespace assignment.Pages.Log
{
    public class OnModel : PageModel
    {

        public E.User User { get; set; }
        public string InvidInputImageCode { get; set; }
        public bool RememberMe { get; set; }
        public void OnGet()
        {
        }
    }
}
