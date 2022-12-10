using Micro.Common;
using Micro.Framework;
using Micro.UserService.Bll;
using Micro.UserService.Model;
using Microsoft.AspNetCore.Mvc;

namespace Micro.UserService.Behand.Controllers
{
    /// <summary>
    /// 客户 控制器
    /// </summary>
    public class CustomerController : MicroController
    {
        #region 变量
        /// <summary>
        /// 客户
        /// </summary>
        [Autowired]
        public CustomerBll CusBll { get; set; } = new CustomerBll();
        #endregion

        #region 接口
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="cusLogin">登录请求</param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(GroupName = nameof(CommonEnum.ApiVersion.V1))]
        public BaseResponseObject<bool> Login([FromBody] CusLoginRequest cusLogin)
        {
            BaseResponseObject<bool> loginResponse = new BaseResponseObject<bool>();

            CusLoginParameter loginParam = new CusLoginParameter() { LoginName = cusLogin.LoginName, Password = cusLogin.Password };

            ResultModel<CusLoginModel> loginResult = CusBll.Login(loginParam);

            if (loginResult.IsSuccess)
            {
                loginResponse.IsSuccess = true;
                loginResponse.Code = "";
                loginResponse.Message = "";
            }
            else
            {
                loginResponse.IsSuccess = false;
                loginResponse.Code = "";
                loginResponse.Message = "";
            }
            return loginResponse;
        }
        #endregion
    }
}
