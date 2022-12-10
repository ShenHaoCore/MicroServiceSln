using Newtonsoft.Json;
using StackExchange.Redis;

namespace Micro.Common
{
    /// <summary>
    /// Redis 帮助类
    /// </summary>
    public class RedisHelper : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private ConnectionMultiplexer Connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private IDatabase Cache { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private RedisValue Token { get; set; } = Environment.MachineName;

        /// <summary>
        /// 超时
        /// </summary>
        private TimeSpan TimeOut { get; set; } = new TimeSpan(0, 20, 0);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (Connection != null) { Connection.Dispose(); }
        }

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        public RedisHelper(string config)
        {
            Connection = ConnectionMultiplexer.Connect(config);
            Cache = Connection.GetDatabase();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机</param>
        /// <param name="port">端口</param>
        /// <param name="password">密码</param>
        public RedisHelper(string host, int port, string password)
        {
            ConfigurationOptions config = new ConfigurationOptions();
            config.Password = password;
            config.EndPoints.Add(host, port);

            Connection = ConnectionMultiplexer.Connect(config);
            Cache = Connection.GetDatabase();
        }
        #endregion

        #region Other
        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return Cache.KeyExists(key);
        }
        #endregion

        #region Remove
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return Cache.KeyDelete(key);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public long RemoveAll(IEnumerable<string> keys)
        {
            RedisKey[] redisKeys = keys.Select(P => new RedisKey(P)).ToArray();
            return Cache.KeyDelete(redisKeys);
        }
        #endregion

        #region Get
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            RedisValue values = Cache.StringGet(key);
            return ConvertObject<T>(values);
        }
        #endregion

        #region Set
        /// <summary>
        /// Set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            return this.Set(key, value, TimeOut);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan TimeOut)
        {
            string json = ConvertJson(value);
            return Cache.StringSet(key, json, TimeOut);
        }
        #endregion

        #region Lock
        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool LockTake(string key, TimeSpan timeout)
        {
            return Cache.LockTake(key, Token, timeout);
        }

        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool LockTake(string key, string token, TimeSpan timeOut)
        {
            return Cache.LockTake(key, token, timeOut);
        }

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool LockRelease(string key)
        {
            return Cache.LockRelease(key, Token);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ConvertJson<T>(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (typeof(T).IsValueType || typeof(T) == typeof(string)) { return value.ToString() ?? string.Empty; }
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static T ConvertObject<T>(RedisValue value)
        {
            if (value.IsNull) { return default!; }
            if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                if (typeof(T) == typeof(bool)) { value = Convert.ToBoolean(value); }
                T obj = (T)Convert.ChangeType(value, typeof(T));
                return obj;
            }
            return JsonConvert.DeserializeObject<T>(value);
        }
        #endregion
    }
}