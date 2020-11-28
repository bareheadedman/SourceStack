using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Pages.Entities
{
    public class Comment:Entity
    {
        public string Content { get; set; }
        public Article Refer;
        public List<Appraise> Appraises;
        public IList<Comment> Comments;
    }
}
