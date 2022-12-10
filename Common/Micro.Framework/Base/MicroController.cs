using Microsoft.AspNetCore.Mvc;

namespace Micro.Framework
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class MicroController : ControllerBase
    {
    }
}