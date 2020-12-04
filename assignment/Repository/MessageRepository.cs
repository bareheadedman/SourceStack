using assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Repository

{
    public class MessageRepository
    {
        private static List<Message> messages;
        private static UserRepository userRepository = new UserRepository();

        static MessageRepository()
        {
            messages = new List<Message>
            {
                new Message()
                {
                    Id=1,
                    CreateTime= new DateTime(2020,1,2),
                    Reason = "奖励",
                    Content="暴打马保国奖励10个帮帮点",
                    Belong= userRepository.Find(1)
                },
                new Message()
                {
                    Id=2,
                    CreateTime= new DateTime(2020,1,3),
                    Reason = "奖励",
                    Content="使用闪电五连鞭奖励15个帮帮点",
                    Belong= userRepository.Find(1)
                },
                new Message()
                {
                    Id=3,
                    CreateTime= new DateTime(2020,1,2),
                    Reason = "奖励",
                    Content="被暴打没有闪奖励5个帮帮点",
                    Belong= userRepository.Find(2)
                },
            };
        }

        public List<Message> GetByUserName(string name)
        {
            return messages.Where(m => m.Reason == name).ToList();
        }
    }
}
