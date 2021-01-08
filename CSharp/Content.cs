using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    /// <summary>
    /// 内容的抽象类
    /// </summary>
    public abstract class Content : Entity
    {
        /// <summary>
        /// 作者
        /// </summary>
        public User Author { get; set; }
        /// <summary>
        /// 内容的主体
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 内容的种类
        /// </summary>
        protected private string Kind { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }



        public Content(string kind)
        {
            Kind = kind;
            CreateTime = DateTime.Now;
        }


    }
}
