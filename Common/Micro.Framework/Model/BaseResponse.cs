using Newtonsoft.Json;

namespace Micro.Framework
{
    /// <summary>
    /// 返回类型
    /// </summary>
    public class BaseResponse : IBaseResponse
    {
        /// <summary>
        /// 处理成功失败标志
        /// </summary>
        public bool IsSuccess { get; set; } = false;

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 异常
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BaseResponseException? Exception { get; set; }
    }
}