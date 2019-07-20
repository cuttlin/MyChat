using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Model
{
    /// <summary>
    /// 聊天内容
    /// </summary>
    public class ChatContent
    {
        /// <summary>
        /// 聊天类型 :  0.请求通信 1.发送内容 2.发送抖动
        /// </summary>
        public int ChatType { get; set; }
        
        /// <summary>
        /// 聊天内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发送者的IP
        /// </summary>
        public string SendIP { get; set; }

        /// <summary>
        /// 发送者字体的颜色
        /// </summary>
        public string FontColor { get; set; }
    }
}
