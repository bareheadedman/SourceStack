using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using assignment.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E = assignment.Pages.Entities;

namespace assignment.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {

        private UserRepository UserRepository;

        public RegisterModel()
        {
            UserRepository = new UserRepository();
        }
        public E.User User { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }
        public string InputImageCode { get; set; }


        public void OnGet()
        {

        }
        public void OnPost()
        {
            E.User InviteBy = UserRepository.GetByName(User.InviterBy.Name);

            if (InviteBy == null)
            {

            }
            if (InviteBy.InviterCode != User.InviterBy.InviterCode)
            {

            }

            User.InviterBy = InviteBy;
            User.Register();
            UserRepository.Save(User);
        }
    }
}
