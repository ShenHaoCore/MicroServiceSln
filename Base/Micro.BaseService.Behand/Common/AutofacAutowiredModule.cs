using Autofac;
using Micro.BaseService.Bll;
using Micro.BaseService.Dal;
using Micro.Common;
using Micro.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Micro.BaseService.Behand
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
            builder.RegisterAssemblyTypes(typeof(BaseServiceBll).Assembly).Where(t => typeof(BaseServiceBll).IsAssignableFrom(t) && t != typeof(BaseServiceBll)).PropertiesAutowired(new AutowiredPropertySelector()); // 所有继承 BaseServiceBll 的都注册了
            builder.RegisterAssemblyTypes(typeof(BaseServiceDal).Assembly).Where(t => typeof(BaseServiceDal).IsAssignableFrom(t) && t != typeof(BaseServiceDal)).PropertiesAutowired(new AutowiredPropertySelector()); // 所有继承 BaseServiceDal 的都注册了
            RedisConfig redis = AppSetting.GetObject<RedisConfig>(RedisConfig.KEY);
            //builder.RegisterInstance<RedisHelper>(new RedisHelper("127.0.0.1", 55000, "redispw"));
            //builder.RegisterType<CallRepository>().As<ICallRepository>().SingleInstance();
            //builder.RegisterType<Counter>().As<ICounter>().InstancePerDependency().AsImplementedInterfaces();
        }
    }
}