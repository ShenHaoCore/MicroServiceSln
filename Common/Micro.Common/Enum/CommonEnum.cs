using System.ComponentModel;

namespace Micro.Common
{
    /// <summary>
    /// 公共枚举
    /// </summary>
    public class CommonEnum
    {
        /// <summary>
        /// 版本
        /// </summary>
        public enum ApiVersion
        {
            /// <summary>
            /// V1版本
            /// </summary>
            [Description("V1版本")]
            V1 = 1,

            /// <summary>
            /// V2版本
            /// </summary>
            [Description("V2版本")]
            V2 = 2,
        }
    }
}