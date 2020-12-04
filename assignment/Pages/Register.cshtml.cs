using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E = assignment.Pages.Entities;

namespace assignment.Pages
{
    public class RegisterModel : PageModel
    {
        public E.User User { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }
        public string InputImageCode { get; set; }

        public void OnGet()
        {

        }
        public void OnPost()
        {

        }
    }
}
