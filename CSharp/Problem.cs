using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //标题（Title）、正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）和作者（Author），和方法Publish()
    class Problem
    {
        private string _title;
        private string _body;

        private int _reward;

        public int Reward
        {
            get
            {
                return _reward;
            }
            set
            {
                if (value > 0)
                {
                    _reward = value;
                }
                else
                {
                    Console.WriteLine("Reward不能为负数");
                }
            }
        }


        private DateTime _publicDateTime;
        private string _author;

        private Problem()
        {

        }

        public Problem(string body)
        {
            _body = body;
        }

        private string[] _keyWord = new string[10];

        public string this[int index]
        {
            get
            {
                return _keyWord[index - 1];
            }
            set
            {
                _keyWord[index-1] = value;
            }
        }



        //public bool Publish(Problem problem, out string cause)
        //{

        //}

        public  void Load(int id)
        {

        }

        public   void  Delete(int id)
        {

        }



    }
}
