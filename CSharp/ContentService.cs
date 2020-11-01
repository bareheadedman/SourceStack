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


    
        public  void Publish(Content content)
        {
            content.Publish();
            Console.WriteLine("保存到数据库");
        }



    }
}
