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

            if (User.PassWord != ConfirmPassWord)
            {
                ModelState.AddModelError(nameof(ConfirmPassWord), "ȷ����������벻һ��");
            }

            E.User inviterBy = UserRepository.GetByName(User.InviterBy.Name);
            if (inviterBy == null)
            {
                ModelState.AddModelError("User.InviterBy.Name", "�����˲�����");
            }
            else if (inviterBy.InviterCode != User.InviterBy.InviterCode)
            {
                ModelState.AddModelError("User.InviterBy.InviterCode", "���������");
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
