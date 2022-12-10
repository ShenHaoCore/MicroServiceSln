using Autofac;
using Micro.Framework;
using Micro.UserService.Bll;
using Micro.UserService.Dal;
using Microsoft.AspNetCore.Mvc;

namespace Micro.UserService.Behand
{
    /// <summary>
    /// 
    /// </summary>
    public class AutofacAutowiredModule : Autofac.Module
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t != typeof(ControllerBase)).PropertiesAutowired(new AutowiredPropertySelector()); // 所有继承 ControllerBase 的都注册了
            builder.RegisterAssemblyTypes(typeof(UserServiceBll).Assembly).Where(t => typeof(UserServiceBll).IsAssignableFrom(t) && t != typeof(UserServiceBll)).PropertiesAutowired(new AutowiredPropertySelector()); // 所有继承 UserServiceBll 的都注册了
            builder.RegisterAssemblyTypes(typeof(UserServiceDal).Assembly).Where(t => typeof(UserServiceDal).IsAssignableFrom(t) && t != typeof(UserServiceDal)).PropertiesAutowired(new AutowiredPropertySelector()); // 所有继承 UserServiceDal 的都注册了
            //builder.RegisterInstance<RedisHelper>(new RedisHelper("127.0.0.1", 55000, "redispw"));
        }
    }
}