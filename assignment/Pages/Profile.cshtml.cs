using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E = assignment.Entities;

namespace assignment.Pages
{
    public class ProfileModel : PageModel
    {
        public E.User User { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {

        }
    }
}
