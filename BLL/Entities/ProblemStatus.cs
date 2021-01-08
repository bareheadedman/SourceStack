using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// 求助的状态
    /// </summary>
    public enum ProblemStatus
    {
        /// <summary>
        /// 已酬谢
        /// </summary>
        HasReward = 0,
        /// <summary>
        /// 已撤销
        /// </summary>
        HasBackout = 1,
        /// <summary>
        /// 协助中
        /// </summary>
        Helping = 2,

    }
}
