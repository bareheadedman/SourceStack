using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel.Log
{
    public class LogModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码的长度不能小于4，大于20")]
        public string Password { get; set; }

        [Display(Name = "验证码")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 验证码的长度只能等于4")]
        public string InputImageCode { get; set; }

        public bool RememberMe { get; set; }
    }
}
