using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    /// <summary>
    /// 帮帮币
    /// </summary>
    public class HelpMoney
    {
        public int Id { get; set; }
        /// <summary>
        /// 还剩多少可用
        /// </summary>
        public int Surplus { get; set; }
        /// <summary>
        /// 帮帮币收支的具体明细
        /// </summary>
        public IList<Account> Accounts { get; set; }
    }

}

