using System;
using System.Collections.Generic;
using System.Text;

namespace Entities

{
    /// <summary>
    /// 种类
    /// </summary>
    public class Category : BaseEntity
    {

        /// <summary>
        /// 作者
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// 种类的名字
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 有哪些文章
        /// </summary>
        public IList<Article> Articles { get; set; }


        /// <summary>
        /// 有哪些子系列
        /// </summary>
        public IList<Category> Categories { get; set; }

    }
}
