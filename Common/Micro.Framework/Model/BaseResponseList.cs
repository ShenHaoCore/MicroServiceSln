namespace Micro.Framework
{
    /// <summary>
    /// 返回类型，对象集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseList<T> : BaseResponse
    {
        /// <summary>
        /// 结果集合
        /// </summary>
        public List<T> Results { get; set; } = new List<T>();

        /// <summary>
        /// 总记录数
        /// </summary>
        public long Total { get; set; } = 0;
    }
}