using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Pages.Entities
{
    public class Category : Content
    {
        public User Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }

    }
}
