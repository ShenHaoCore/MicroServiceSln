using Micro.BaseService.Bll;
using Micro.BaseService.Model;
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
            BaseResponseObject<List<AddressModel>> queResponse = new BaseResponseObject<List<AddressModel>>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryAll();
            return queResponse;
        }

        /// <summary>
        /// 查询上级
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<List<t_Sys_Address>> QueryParent([FromQuery] Guid id)
        {
            BaseResponseObject<List<t_Sys_Address>> queResponse = new BaseResponseObject<List<t_Sys_Address>>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryParent(id);
            return queResponse;
        }

        /// <summary>
        /// 查询下级
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<List<t_Sys_Address>> QueryChild([FromQuery] Guid id)
        {
            BaseResponseObject<List<t_Sys_Address>> queResponse = new BaseResponseObject<List<t_Sys_Address>>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryChild(id);
            return queResponse;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Sys_Address> QueryById([FromQuery] Guid id)
        {
            BaseResponseObject<t_Sys_Address> queResponse = new BaseResponseObject<t_Sys_Address>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryById(id);
            return queResponse;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="namecn">中文名</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Sys_Address> QueryByNameCn([FromQuery] string namecn)
        {
            BaseResponseObject<t_Sys_Address> queResponse = new BaseResponseObject<t_Sys_Address>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryByNameCn(namecn);
            return queResponse;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="nameen">英文名</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Sys_Address> QueryByNameEn([FromQuery] string nameen)
        {
            BaseResponseObject<t_Sys_Address> queResponse = new BaseResponseObject<t_Sys_Address>();
            queResponse.IsSuccess = true;
            queResponse.Result = AddrBll.QueryByNameEn(nameen);
            return queResponse;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="queRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponseObject<List<t_Sys_Address>> Query([FromBody] AddressQueryRequest queRequest)
        {
            BaseResponseObject<List<t_Sys_Address>> queResponse = new BaseResponseObject<List<t_Sys_Address>>();
            return queResponse;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="insRequrst"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Insert([FromBody] AddressInsertRequest insRequrst)
        {
            BaseResponse insResponse = new BaseResponse();
            return insResponse;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="updRequrst"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Update([FromBody] AddressUpdateRequest updRequrst)
        {
            BaseResponse updResponse = new BaseResponse();
            return updResponse;
        }
        #endregion
    }
}