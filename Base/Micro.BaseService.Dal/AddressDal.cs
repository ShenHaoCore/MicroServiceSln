using Micro.BaseService.Model;
using Micro.Common;
using SqlSugar;

namespace Micro.BaseService.Dal
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressDal : BaseServiceDal
    {
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<AddressModel> QueryAll()
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<AddressModel>().ToTree(it => it.Child, it => it.ParentID, Guid.Empty);
            }
        }

        /// <summary>
        /// 查询上级（包含自己）
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public List<t_Sys_Address> QueryParent(Guid id)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().ToParentList(it => it.ParentID, id);
            }
        }

        /// <summary>
        /// 查询下级（包含自己）
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public List<t_Sys_Address> QueryChild(Guid id)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().ToChildList(it => it.ParentID, id);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public t_Sys_Address QueryById(Guid id)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().Where(it => it.ID == id).First();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="code">主键ID</param>
        /// <returns></returns>
        public t_Sys_Address QueryByCode(string code)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().Where(it => it.Code == code).First();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="namecn">中文名</param>
        /// <returns></returns>
        public t_Sys_Address QueryByNameCn(string namecn)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().Where(it => it.NameCn == namecn).First();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="nameen">主键ID</param>
        /// <returns></returns>
        public t_Sys_Address QueryByNameEn(string nameen)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                return db.Queryable<t_Sys_Address>().Where(it => it.NameEn == nameen).First();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public bool Insert(t_Sys_Address address)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Insertable<t_Sys_Address>(address).ExecuteCommand();
                return true;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public bool Insert(List<t_Sys_Address> addresses)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Insertable<t_Sys_Address>(addresses).ExecuteCommand();
                return true;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public bool Update(t_Sys_Address address)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Updateable<t_Sys_Address>(address).ExecuteCommand();
                return true;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public bool Update(List<t_Sys_Address> addresses)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Updateable<t_Sys_Address>(addresses).ExecuteCommand();
                return true;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Deleteable<t_Sys_Address>().Where(P => P.ID == id).ExecuteCommand();
                return true;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">主键ID</param>
        /// <returns></returns>
        public bool Delete(List<Guid> ids)
        {
            using (SqlSugarClient db = SqlSugarHelper.GetInstance(BaseConst.ConnectionString))
            {
                db.Deleteable<t_Sys_Address>().Where(P => ids.Contains(P.ID)).ExecuteCommand();
                return true;
            }
        }
    }
}