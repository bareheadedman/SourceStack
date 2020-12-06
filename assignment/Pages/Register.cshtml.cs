using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using E = assignment.Entities;

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
        [Required(ErrorMessage = "* 确认密码不能为空")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 验证码的长度只能等于4")]
        public string InputImageCode { get; set; }


        public void OnGet()
        {

        }
        public void OnPost()
        {

            if (User.PassWord != ConfirmPassWord)
            {
                ModelState.AddModelError(nameof(ConfirmPassWord), "确认密码和密码不一致");
            }

            E.User inviterBy = UserRepository.GetByName(User.InviterBy.Name);
            if (inviterBy == null)
            {
                ModelState.AddModelError("User.InviterBy.Name", "邀请人不存在");
            }
            else if (inviterBy.InviterCode != User.InviterBy.InviterCode)
            {
                ModelState.AddModelError("User.InviterBy.InviterCode", "邀请码错误");
            }


            if (!ModelState.IsValid)
            {
                return;
            }


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
