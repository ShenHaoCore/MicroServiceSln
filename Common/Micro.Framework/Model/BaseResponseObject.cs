namespace Micro.Framework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseObject<T> : BaseResponse
    {
        /// <summary>
        /// 返回对象数据
        /// </summary>
        public T Result { get; set; } = default!;
    }
}