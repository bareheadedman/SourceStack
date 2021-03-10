using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BLL.Entities
{
    /// <summary>
    /// 内容的抽象类
    /// </summary>
    public abstract class Content : BaseEntity
    {
        /// <summary>
        /// 作者
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }




    }
}
