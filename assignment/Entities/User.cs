using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public User InviterBy { get; set; }
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
