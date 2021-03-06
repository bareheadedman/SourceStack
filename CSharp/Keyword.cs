﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /// <summary>
    /// 关键字
    /// </summary>
    public class Keyword
    {
        public int Id { get; set; }

        /// <summary>
        /// 关键字的名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 被求助使用
        /// </summary>
        public IList<Problem> Problems { get; set; }

        /// <summary>
        /// 被文章使用
        /// </summary>
        public IList<Article> Articles { get; set; }

    }
}
