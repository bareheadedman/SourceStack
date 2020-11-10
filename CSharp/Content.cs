﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    abstract class Content : Entity
    {

        //Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间

        public User Author { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        protected private string kind;
        public DateTime CreateTime { get; private set; }


        public DateTime PublishTime { get; protected set; }



        protected private Content(string kind)
        {
            CreateTime = DateTime.Now;
            this.kind = kind;
        }

        virtual public void Publish()
        {

        }









    }
}