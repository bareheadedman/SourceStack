using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Entities
{
    public class User : Entity
    {
        [Required(ErrorMessage = "* 用户名不能为空")] 
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* 密码不能为空")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* 密码的长度不能小于4，大于20")]
        public string PassWord { get; set; }

        public User InviterBy { get; set; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 邀请码的长度只能是4位数字")]
        public string InviterCode { get; set; }

        public int BMony { get; set; }
        public bool IsMale { get; set; }

        public List<Message> messages { get; set; }
        public List<Article> Articles { get; set; }
        public List<Category> Categorys { get; set; }

        public void Register()
        {
            InviterBy.BMony += 10;
        }

    }
}
