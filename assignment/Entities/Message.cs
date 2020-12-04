using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Entities
{
    public class Message : Entity
    {
        public DateTime CreateTime { get; set; }
        public string Reason { get; set; }
        public string Content { get; set; }
        public bool Selected { get; set; }
        public User Belong { get; set; }
        public void Read()
        {
            Selected = true;
        }
    }


}
