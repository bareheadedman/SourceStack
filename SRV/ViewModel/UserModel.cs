using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SRV.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "邀请人")]
        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string InvitedName { get; set; }

        [Display(Name = "邀请码")]
        [Required(ErrorMessage = "* 邀请码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 邀请码的长度只能是4位数字")]
        public string InvitedCode { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        [Remote("UserIsExist", "User", ErrorMessage = "* 用户名已存在")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码的长度不能小于4，大于20")]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "* 确认密码不能为空")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "* 确认密码和密码不一致")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "验证码")]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 验证码的长度只能等于4")]
        public string InputImageCode { get; set; }
    }
}
