using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Message: BaseEntity
    {
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool HasRead { get; set; }
        /// <summary>
        /// 消息的状态
        /// </summary>
        public MessageStatus MessageStatus { get; set; }


    }
}
