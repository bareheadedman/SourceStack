using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _17BangMVC.Models
{
    public class RegisterModels
    {
        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string InvitedName { get; set; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 邀请码的长度只能是4位数字")]
        public string InvitedCode { get; set; }

        [Required(ErrorMessage = "* 用户名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码的长度不能小于4，大于20")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* 确认密码不能为空")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 验证码的长度只能等于4")]
        public string InputImageCode { get; set; }
    }
}