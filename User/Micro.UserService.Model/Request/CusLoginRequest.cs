namespace Micro.UserService.Model
{
    /// <summary>
    /// 登录请求
    /// </summary>
    public class CusLoginRequest
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; } = String.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = String.Empty;
    }
}