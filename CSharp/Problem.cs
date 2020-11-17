using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{



    class Problem : Content
    {
        public string Title { get; set; }

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

        public IList<Comment<Problem>> Comments;
        public Problem(string body) : base("problem")
        {
            Body = body;
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
                _keyWord[index - 1] = value;
            }
        }



        public void Load(int id)
        {

        }

        public void Delete(int id)
        {

        }

        public void repoistory()
        {

        }





        [HelpMoneyChanged(Amount = (-1)/*Reward*/, Message = "发布悬赏")]
        override public void Publish()
        {
            PublishTime = DateTime.Now;
            Author.HelpMoney -= Reward;
            Console.WriteLine("消耗悬赏的帮帮币");
        }




    }
}
