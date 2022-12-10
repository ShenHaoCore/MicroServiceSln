using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Micro.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentPath"></param>
        public AppSetting(string contentPath)
        {
            string path = "appsettings.json";
            Configuration = new ConfigurationBuilder().SetBasePath(contentPath).Add(new JsonConfigurationSource { Path = path, Optional = false, ReloadOnChange = true }).Build();
            // 如果你把配置文件 是 根据环境变量来分开了，可以这样写 Path = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
            // 这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public AppSetting(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string Get(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }
            return "";
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="sectionPath"></param>
        /// <returns></returns>
        public static string GetValue(string sectionPath)
        {
            try
            {
                return Configuration[sectionPath];
            }
            catch (Exception) { }
            return "";
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static T GetObject<T>(params string[] sections)
        {
            return Configuration.GetSection(string.Join(":", sections)).Get<T>();
        }

        /// <summary>
        /// 获取列表
        /// 引用 Microsoft.Extensions.Configuration.Binder 包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }
    }
}