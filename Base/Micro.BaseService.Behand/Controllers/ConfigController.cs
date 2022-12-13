using Micro.Common;
using Micro.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Micro.BaseService.Behand.Controllers
{
    /// <summary>
    /// 配置 控制器
    /// </summary>
    public class ConfigController : MicroController
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get([FromQuery] string path)
        {
            return Content(AppSetting.GetValue(path));
        }
    }
}