using Micro.Framework;
using Micro.UserService.Dal;
using Micro.UserService.Model;
using System.DirectoryServices.Protocols;

namespace Micro.UserService.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerBll : UserServiceBll
    {
        /// <summary>
        /// 客户
        /// </summary>
        [Autowired]
        public CustomerDal CusDal { get; set; } = new CustomerDal();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginParam"></param>
        public ResultModel<CusLoginModel> Login(CusLoginParameter loginParam)
        {
            ResultModel<CusLoginModel> loginResult = new ResultModel<CusLoginModel>();
            return loginResult;
        }
    }
}