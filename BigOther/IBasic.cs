using System;
using System.Collections.Generic;
using System.Text;

namespace BigOther
{
    namespace Basic
    {
        /// <summary>
        /// 基本数据类型通用接口
        /// </summary>
        public interface IBasic
        {
            /// <summary>
            /// 获取上一层级对象
            /// </summary>
             IBasic father { get; }
            /// <summary>
            /// 设置包含的所有特性使能
            /// </summary>
             bool enable { get; set; }
        }
    }
    
}
