using Micro.BaseService.Bll;
using Micro.BaseService.Model;
using Micro.Common;
using Micro.Framework;
using Microsoft.AspNetCore.Mvc;

namespace Micro.BaseService.Behand.Controllers
{
    /// <summary>
    /// 地址 控制器
    /// </summary>
    public class AddressController : MicroController
    {
        #region 变量
        /// <summary>
        /// 地址
        /// </summary>
        [Autowired]
        public AddressBll AddrBll { get; set; } = new AddressBll();
        #endregion

        #region 接口
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<List<AddressModel>> QueryAll()
        {
            BaseResponseObject<List<AddressModel>> qryResponse = new BaseResponseObject<List<AddressModel>>();
            qryResponse.IsSuccess = true;
            qryResponse.Result = AddrBll.QueryAll();
            return qryResponse;
        }

        /// <summary>
        /// 查询上级
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<List<t_Sys_Address>> QueryParent([FromQuery] Guid id)
        {
            BaseResponseObject<List<t_Sys_Address>> qryResponse = new BaseResponseObject<List<t_Sys_Address>>();
            qryResponse.IsSuccess = true;
            qryResponse.Result = AddrBll.QueryParent(id);
            return qryResponse;
        }

        /// <summary>
        /// 查询下级
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<List<t_Sys_Address>> QueryChild([FromQuery] Guid id)
        {
            BaseResponseObject<List<t_Sys_Address>> qryResponse = new BaseResponseObject<List<t_Sys_Address>>();
            qryResponse.IsSuccess = true;
            qryResponse.Result = AddrBll.QueryChild(id);
            return qryResponse;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="qryRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Query([FromBody] AddressQueryRequest qryRequest)
        {
            BaseResponse qryResponse = new BaseResponse();
            return qryResponse;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Insert()
        {
            BaseResponse qryResponse = new BaseResponse();
            string routePrefix = AppSetting.Get("SystemSetting", "RoutePrefix");
            return qryResponse;
        }
        #endregion
    }
}