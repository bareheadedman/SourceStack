using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    /// <summary>
    ///  评价功能接口
    /// </summary>
    public interface IAppraise
    {
        /// <summary>
        /// 被谁点赞
        /// </summary>
        /// <param name="vote"></param>
        void AgreeBy(User vote);
        /// <summary>
        /// 被谁踩
        /// </summary>
        /// <param name="vote"></param>
        void DisAgreeBy(User vote);


    }
}
