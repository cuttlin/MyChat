using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 此类用于记录好友的信息
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// 此用户的IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 此用户的头像
        /// </summary>
        public string Photo { get; set; }
        
        /// <summary>
        /// 此用户的名字
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 此用户的签名
        /// </summary>
        public string Signature { get; set; }

    }
}
