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

        private UserRepository userRepository;

        public RegisterModel()
        {
            userRepository = new UserRepository();
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

            E.User inviterBy = userRepository.GetByName(User.InviterBy.Name);
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
            if (User.Name == userRepository.GetByName(User.Name).Name)
            {
                ModelState.AddModelError("User.Name", "用户名字已存在");
                return;
            }


            User.PassWord = PassWord;
            User.InviterBy = inviterBy;
            User.Register();
            userRepository.Save(User);
        }
    }
}
