using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Entities
{
    public class Appraise : Entity
    {
        public User vote { get; set; }
        public UpOrdown Direction { get; set; }
        public DateTime PublishTime { get; set; }


        public void Disagree() //待实现
        {
            Direction = UpOrdown.Down;
        }

        public void Agree()  //待实现
        {

            Direction = UpOrdown.Up;
        }
    }
    public enum UpOrdown
    {
        Up,
        Down
    }

}
