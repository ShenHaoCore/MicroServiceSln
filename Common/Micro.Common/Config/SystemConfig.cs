namespace Micro.Common
{
    /// <summary>
    /// 系统设置配置
    /// </summary>
    public class SystemConfig
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Redis";

        /// <summary>
        /// 路由前缀
        /// </summary>
        public string RoutePrefix { get; set; } = string.Empty;
    }
}