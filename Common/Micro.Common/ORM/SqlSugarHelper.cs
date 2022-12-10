using SqlSugar;

namespace Micro.Common
{
    /// <summary>
    /// SqlSugar 帮助类
    /// </summary>
    public class SqlSugarHelper
    {
        /// <summary>
        /// 创建 SqlSugarClient
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance(string connectionString)
        {
            return GetInstance(new ConnectionConfig() { ConnectionString = connectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true, InitKeyType = InitKeyType.Attribute });
        }

        /// <summary>
        /// 创建 SqlSugarClient
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance(ConnectionConfig config)
        {
            SqlSugarClient db = new SqlSugarClient(config);
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
#if DEBUG
                Console.WriteLine(sql);
                Console.WriteLine(string.Join(",", pars.Select(it => string.Format("{0}:{1}", it.ParameterName, it.Value))));
#endif
            };
            return db;
        }
    }
}
