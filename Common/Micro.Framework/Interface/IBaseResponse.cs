namespace Micro.Framework
{
    /// <summary>
    /// 返回结果基类接口
    /// </summary>
    public interface IBaseResponse : IBaseDTO
    {
        /// <summary>
        /// 处理成功失败标志
        /// </summary>
        bool IsSuccess { get; set; }
    }
}