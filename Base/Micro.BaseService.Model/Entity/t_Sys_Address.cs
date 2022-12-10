using SqlSugar;

namespace Micro.BaseService.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Sys_Address
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Sys_Address()
        {
        }

        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public System.String Code { get; set; } = string.Empty;

        /// <summary>
        /// 中文名
        /// </summary>
        public System.String NameCn { get; set; } = string.Empty;

        /// <summary>
        /// 英文名
        /// </summary>
        public System.String NameEn { get; set; } = string.Empty;

        /// <summary>
        /// 父级ID
        /// </summary>
        public System.Guid ParentID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public System.String Type { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    }
}