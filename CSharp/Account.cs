using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /// <summary>
    /// 账单
    /// </summary>
    public class Account
    {
        public int Id { get; set; }

        /// <summary>
        /// 收入或指出的时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 还能使用的
        /// </summary>
        public int Usable { get; set; }
        /// <summary>
        /// 不可以用的
        /// </summary>
        public int Freeze { get; set; }
        /// <summary>
        /// 改变的变化,增加了,还是减少了
        /// </summary>
        public string Variation { get; set; }
        /// <summary>
        /// 变化的原因
        /// </summary>
        public string Remark { get; set; }


    }
}
