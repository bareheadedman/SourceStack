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

        [Required(ErrorMessage = "* �����벻��Ϊ��")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* ������ĳ���ֻ����4λ����")]
        public string InviterCode { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* ���벻��Ϊ��")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "* ����ĳ��Ȳ���С��4������20")]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "* ȷ�����벻��Ϊ��")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "* ��֤�벻��Ϊ��")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* ��֤��ĳ���ֻ�ܵ���4")]
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
                ModelState.AddModelError(nameof(ConfirmPassWord), "ȷ����������벻һ��");
                return;
            }

            E.User inviterBy = userRepository.GetByName(User.InviterBy.Name);
            if (inviterBy == null)
            {
                ModelState.AddModelError("InviterBy.Name", "�����˲�����");
                return;
            }
            if (inviterBy.InviterCode != InviterCode)
            {
                ModelState.AddModelError(nameof(InviterCode), "���������");
                return;
            }
            if (User.Name == userRepository.GetByName(User.Name).Name)
            {
                ModelState.AddModelError("User.Name", "�û������Ѵ���");
                return;
            }


            User.PassWord = PassWord;
            User.InviterBy = inviterBy;
            User.Register();
            userRepository.Save(User);
        }
    }
}
