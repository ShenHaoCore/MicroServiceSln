using SqlSugar;

namespace Micro.BaseService.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressQueryParameter
    {
        /// <summary>
        /// 中文名
        /// </summary>
        public string NameCn { get; set; } = string.Empty;

        /// <summary>
        /// 英文名
        /// </summary>
        public string NameEn { get; set; } = string.Empty;
    }

    public class AddressInsertParameter
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 中文名
        /// </summary>
        public string NameCn { get; set; } = string.Empty;

        /// <summary>
        /// 英文名
        /// </summary>
        public string NameEn { get; set; } = string.Empty;

        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid ParentID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    [SugarTable("t_Sys_Address")]
    public class AddressModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public Guid ID { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 中文名
        /// </summary>
        public string NameCn { get; set; } = string.Empty;

        /// <summary>
        /// 英文名
        /// </summary>
        public string NameEn { get; set; } = string.Empty;

        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid ParentID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<AddressModel> Child { get; set; } = new List<AddressModel>();
    }
}