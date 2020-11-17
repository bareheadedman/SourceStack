using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //求助版块，定义一个类Problem，包含字段：标题（Title）、正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）和作者（Author），和方法Publish()


    //一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写。


    //每一个Problem对象一定有Body赋值



    //    考虑求助（Problem）的以下方法/属性，哪些适合实例，哪些适合静态，然后添加到类中：
    //Publish()：发布一篇求助，并将其保存到数据库
    //Load(int Id)：根据Id从数据库获取一条求助
    //Delete(int Id)：根据Id删除某个求助
    //repoistory：可用于在底层实现上述方法和数据库的连接操作等


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


        [HelpMoneyChanged(Amount =(-1)/*Reward*/,Message ="发布悬赏")]
        override public void Publish()
        {
            PublishTime = DateTime.Now;
            Author.HelpMoney -= Reward;
            Console.WriteLine("消耗悬赏的帮帮币");
        }




    }
}
