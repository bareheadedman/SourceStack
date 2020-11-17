using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Appraise
    {
        //每个文章和评论都有一个评价


        public User vote { get; set; }
        public UpOrdown Direction { get; private set; }



        public void Disagree()
        {
            Direction = UpOrdown.Down;
        }

        public void Agree()
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
