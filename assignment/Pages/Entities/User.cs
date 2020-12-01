using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Pages.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public List<Article> Articles { get; set; }
        public List<Category> Categorys { get; set; }

    }
}
