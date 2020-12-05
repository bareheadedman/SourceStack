using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Entities;
using assignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment.Pages
{
    public class MessageModel : PageModel
    {
        [BindProperty]
        public List<Message> messages { get; set; }

        private static MessageRepository messageRepository;
        static MessageModel()
        {
            messageRepository = new MessageRepository();
        }

        public void OnGet()
        {
            messages = messageRepository.GetByUserId(1);
        }
        public void OnPost()
        {
            foreach (var item in messages)
            {
                if (item.Selected)
                {
                    messageRepository.Find(item.Id).Read();
                }
            }
        }
    }
}
