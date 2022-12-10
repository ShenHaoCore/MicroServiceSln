using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Micro.Framework
{
    /// <summary>
    /// 全局异常
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IWebHostEnvironment environment;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        public GlobalExceptionFilter(IWebHostEnvironment environment)
        {
            this.environment = environment;
            this.logger = LogManager.GetLogger(typeof(GlobalExceptionFilter));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            // 如果异常没有处理
            if (!context.ExceptionHandled)
            {
                BaseResponse baseResponse = new BaseResponse();
                baseResponse.IsSuccess = false;
                baseResponse.Message = context.Exception.Message ?? "";
                baseResponse.Exception = new BaseResponseException() { StackTrace = context.Exception.StackTrace ?? "", Source = context.Exception.Source ?? "", Message = context.Exception.Message ?? "" };

                if (environment.IsDevelopment()) { }

                logger.Error("出现错误，请联系管理员", context.Exception);

                context.Result = new JsonResult(baseResponse);
                // 异常已处理
                context.ExceptionHandled = true;
            }
        }
    }
}