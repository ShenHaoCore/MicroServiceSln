using Micro.BaseService.Dal;
using Micro.BaseService.Model;
using Micro.Framework;

namespace Micro.BaseService.Bll
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressBll : BaseServiceBll
    {
        #region 变量
        /// <summary>
        /// 地址
        /// </summary>
        [Autowired]
        public AddressDal AddrDal { get; set; } = new AddressDal();
        #endregion

        #region 方法
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<AddressModel> QueryAll()
        {
            return AddrDal.QueryAll();
        }

        /// <summary>
        /// 查询上级（包含自己）
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public List<t_Sys_Address> QueryParent(Guid id)
        {
            return AddrDal.QueryParent(id);
        }

        /// <summary>
        /// 查询下级（包含自己）
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public List<t_Sys_Address> QueryChild(Guid id)
        {
            return AddrDal.QueryChild(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ResultModel<bool> Insert(AddressInsertParameter insParam)
        {
            ResultModel<bool> itResult = new ResultModel<bool>();

            t_Sys_Address address = new t_Sys_Address()
            {
                Code = insParam.Code,
                NameCn = insParam.NameCn,
                NameEn = insParam.NameEn,
                ParentID = insParam.ParentID,
                Type = insParam.Type,
                CreateTime = DateTime.Now
            };

            if (AddrDal.Insert(address))
            {
                itResult.IsSuccess = true;
                itResult.Message = "保存成功";
            }
            else
            {
                itResult.IsSuccess = false;
                itResult.Message = "保存失败";
            }

            return itResult;
        }
        #endregion
    }
}