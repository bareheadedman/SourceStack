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

        [Required(ErrorMessage = "�û�������Ϊ��")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "���벻��Ϊ��")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "����ĳ��Ȳ���С��4,����20")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "��֤�벻��Ϊ��")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "��֤��ĳ���ֻ����4")]
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
                ModelState.AddModelError(nameof(Name), "�û���������");
                return;
            }
            if (user.PassWord != PassWord)
            {
                ModelState.AddModelError(nameof(PassWord), "�û��������벻��ȷ");
                return;
            }


        }
    }
}
