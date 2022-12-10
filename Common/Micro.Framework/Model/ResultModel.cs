namespace Micro.Framework
{
    /// <summary>
    /// 结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultModel<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ResultModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        public ResultModel(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="issuccess"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        public ResultModel(bool issuccess, string code, string message, T result)
        {
            this.IsSuccess = issuccess;
            this.Code = code;
            this.Message = message;
            this.Result = result;
        }

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
        /// 结果
        /// </summary>
        public T Result { get; set; } = default!;
    }
}