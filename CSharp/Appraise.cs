using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /// <summary>
    /// 评价
    /// </summary>
    public class Appraise : IAppraise
    {
        public int Id { get; set; }
        /// <summary>
        /// 投票人
        /// </summary>
        public User vote { get; set; }
        /// <summary>
        /// 投的什么票
        /// </summary>
        public UpOrdown Direction { get; private set; }

        /// <summary>
        /// 投票赞
        /// </summary>
        /// <param name="vote"> 投票人</param>
        public void AgreeBy(User vote)
        {
            Direction = UpOrdown.Up;

        }
        /// <summary>
        /// 投票踩
        /// </summary>
        /// <param name="vote">投票人</param>
        public void DisAgreeBy(User vote)
        {
            Direction = UpOrdown.Down;

        }
    }

    /// <summary>
    /// 储存投的什么票
    /// </summary>
    public enum UpOrdown
    {
        Up,
        Down
    }


}
