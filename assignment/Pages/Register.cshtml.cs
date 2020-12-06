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

        [Required(ErrorMessage = "* 邀请码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 邀请码的长度只能是4位数字")]
        public string InviterCode { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码的长度不能小于4，大于20")]
        public string PassWord { get; set; }

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

            if (!ModelState.IsValid)
            {
                return;
            }

            if (PassWord != ConfirmPassWord)
            {
                ModelState.AddModelError(nameof(ConfirmPassWord), "确认密码和密码不一致");
                return;
            }

            E.User inviterBy = UserRepository.GetByName(User.InviterBy.Name);
            if (inviterBy == null)
            {
                ModelState.AddModelError("InviterBy.Name", "邀请人不存在");
                return;
            }
            if (inviterBy.InviterCode != InviterCode)
            {
                ModelState.AddModelError(nameof(InviterCode), "邀请码错误");
                return;
            }




            User.PassWord = PassWord;
            User.InviterBy = inviterBy;
            User.Register();
            UserRepository.Save(User);
        }
    }
}
