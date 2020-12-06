using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E = assignment.Entities;

namespace assignment.Pages.Log
{
    [BindProperties]
    public class OnModel : PageModel
    {
        private UserRepository userRepository;
        public OnModel()
        {
            userRepository = new UserRepository();
        }

        [Required(ErrorMessage = "用户名不能为空")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "密码的长度不能小于4,大于20")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "验证码的长度只能是4")]
        public string InvidInputImageCode { get; set; }

        public bool RememberMe { get; set; }

        public void OnGet()
        {


        }

        public void OnPost()
        {

            E.User user = userRepository.GetByName(Name);

            if (!ModelState.IsValid)
            {
                return;
            }
            if (user == null)
            {
                ModelState.AddModelError(nameof(Name), "用户名不存在");
                return;
            }
            if (user.PassWord != PassWord)
            {
                ModelState.AddModelError(nameof(PassWord), "用户名或密码不正确");
                return;
            }


        }
    }
}
