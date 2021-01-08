using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{

    /// <summary>
    /// 帮帮币
    /// </summary>
    public class HelpMoney: BaseEntity
    {
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

