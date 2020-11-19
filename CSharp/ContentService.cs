using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class ContentService
    {

        //        添加一个新类ContentService，其中有一个发布（Publish()）方法：

        //如果发布Article，需要消耗一个帮帮币
        //如果发布Problem，需要消耗其设置悬赏数量的帮帮币
        //如果发布Suggest，不需要消耗帮帮币



        public void Publish(Content content)
        {
            try
            {
                content.Publish();
                Console.WriteLine("保存到数据库");
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("内容的作者不能为空");
                throw new Exception("内容的作者不能为空", a);
            }
            catch (ArgumentOutOfRangeException b)
            {
                Console.WriteLine("求助的Reward为负数" + b.Message + b.Source);
            }
            finally 
            {
                Console.WriteLine($"{DateTime.Now}请求发布内容Id:{content.id}" );
            }
        }



    }
}
