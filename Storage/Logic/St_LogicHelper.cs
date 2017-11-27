using Foundation.DataProvider;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class St_LogicHelper
    {
        public static List<ST_Shops> GetAllStShops()
        {
            return DBHelper.ExecuteDataTableSql(" SELECT * FROM  ST_Shops WHERE S_DelFlg=0").ToList<ST_Shops>();
        }

        /// <summary>
        /// 添加进货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool SaveInStorage(ST_InStorage model)
        {
            model.EntityState = EntityState.Added;
            var sqlStr = new StringBuilder();
            sqlStr.Append(" UPDATE [ST_Shops] SET S_InPrice=" + model.I_PRICE + ",S_SumNum+=" + model.I_NUM + ",S_SumPrice+=" + model.I_SUMPRICE + ",S_InDate=getdate()  where ID=" + model.I_SHOPSID);
            return DBHelper.Save(model, new List<string> { sqlStr.ToString() }).ResultStatus;
        }

        /// <summary>
        /// 添加出货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool SaveOutStorage(ST_OutStorage model)
        {
            model.EntityState = EntityState.Added;
            var sqlStr = new StringBuilder();
            sqlStr.Append(" UPDATE [ST_Shops] SET  S_SumNum-=" + model.O_NUM + ",S_SumPrice-=" + model.O_SUMPRICE + ",S_OutDate=getdate() where ID=" + model.O_SHOPSID);
            return DBHelper.Save(model, new List<string> { sqlStr.ToString() }).ResultStatus;
        }


        /// <summary>
        /// 保存商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool SaveStShops(ST_Shops model)
        {
            return DBHelper.Save(model).ResultStatus;
        }


        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static ST_Shops GetShopsById(string Id)
        {
            return DBHelper.ExecuteDataTableSql(" SELECT * FROM ST_Shops WHERE ID=@ID", new SqlParameter[] { new SqlParameter() { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = Int32.Parse(Id) } }).ToEntity<ST_Shops>();
        }

        /// <summary>
        /// 用户登陆  查询用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ST_SysAdmin UserLogin(ST_SysAdmin model)
        {
            return DBHelper.ExecuteDataTableSql(" select * from  ST_SysAdmin where UserName=@UserName and UserPwd=@UserPwd", new SqlParameter[] {
                new SqlParameter(){ParameterName="@UserName",SqlDbType=SqlDbType.VarChar,Value=model.UserName},
                new SqlParameter(){ParameterName="@UserPwd",SqlDbType=SqlDbType.VarChar,Value=model.UserPwd}
            }).ToEntity<ST_SysAdmin>();
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tableName">查询的表，多标用，隔开</param>
        /// <param name="field">查询的字段</param>
        /// <param name="orderfield">排序字段</param>
        /// <param name="orderType">排序类型,非 0 值则降序</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="where">查询条件</param>
        /// <param name="innerFields">关联字段</param>
        /// <param name="recordCount">返回的总记录数</param>
        /// <param name="innwhere">关联附加条件</param>
        /// <returns></returns>
        public DataTable SelectByPages(string tableName, string field, string orderfield, string orderType, int pageSize, int pageindex, string where, string innerFields, string innwhere, out int recordCount)
        {
            var type = orderType == "1";
            return PageHelper.SelectByPage(tableName, field, orderfield, type, pageSize, pageindex, where, innerFields, innwhere, out recordCount);
        }


        /// <summary>
        /// 分页查询商品数据
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">返回的总记录数</param>
        /// <returns></returns>
        public static List<ST_Shops> SelectByPagesShops(int pageSize, int pageindex, string where, out int recordCount)
        {
            return PageHelper.SelectByPage("ST_Shops", "*", "S_InDate", true, pageSize, pageindex, where, "", "", out recordCount).ToList<ST_Shops>();
        }


    }
}
