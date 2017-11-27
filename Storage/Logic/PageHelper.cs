using Foundation.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class PageHelper
    {

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
        public static DataTable SelectByPage(string tableName, string field, string orderfield, bool orderType, int pageSize, int pageindex, string where, string innerFields, string innwhere, out int recordCount)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" exec pagination2  @tblName");
            strsql.Append(" ,@strGetFields");
            strsql.Append(" ,@fldName");
            strsql.Append(" ,@PageSize");
            strsql.Append(" ,@PageIndex");
            strsql.Append(" ,@doCount");
            strsql.Append(" ,@OrderType");
            strsql.Append(" ,@strWhere");
            strsql.Append(" ,@innerFields");
            strsql.Append(" ,@funStr");
            strsql.Append(" ,@innerwhere");

            SqlParameter[] pa = {
                                new SqlParameter{ParameterName="@tblName",SqlDbType=SqlDbType.VarChar,Value=tableName},
                                new SqlParameter{ParameterName="@strGetFields",SqlDbType=SqlDbType.VarChar,Value=field},
                                new SqlParameter{ParameterName="@fldName",SqlDbType=SqlDbType.VarChar,Value=orderfield},
                                new SqlParameter{ParameterName="@PageSize",SqlDbType=SqlDbType.Int,Value=pageSize},
                                new SqlParameter{ParameterName="@PageIndex",SqlDbType=SqlDbType.Int,Value=pageindex},
                                new SqlParameter{ParameterName="@doCount",SqlDbType=SqlDbType.Bit,Value=false},
                                new SqlParameter{ParameterName="@OrderType",SqlDbType=SqlDbType.Bit,Value=orderType},
                                new SqlParameter{ParameterName="@strWhere",SqlDbType=SqlDbType.VarChar,Value=where},
                                new SqlParameter{ParameterName="@innerFields",SqlDbType=SqlDbType.VarChar,Value=innerFields},
                                new SqlParameter{ParameterName="@funStr",SqlDbType=SqlDbType.VarChar,Value=""},
                                new SqlParameter{ParameterName="@innerwhere",SqlDbType=SqlDbType.VarChar,Value=innwhere}
                                };
            var resdt = DBHelper.ExecuteDataTableSp("pagination2", pa);
            SqlParameter[] pas = {
                                 new SqlParameter{ParameterName="@tblName",SqlDbType=SqlDbType.VarChar,Value=tableName},
                                new SqlParameter{ParameterName="@strGetFields",SqlDbType=SqlDbType.VarChar,Value=field},
                                new SqlParameter{ParameterName="@fldName",SqlDbType=SqlDbType.VarChar,Value=orderfield},
                                new SqlParameter{ParameterName="@PageSize",SqlDbType=SqlDbType.Int,Value=pageSize},
                                new SqlParameter{ParameterName="@PageIndex",SqlDbType=SqlDbType.Int,Value=pageindex},
                                new SqlParameter{ParameterName="@doCount",SqlDbType=SqlDbType.Bit,Value=true},
                                new SqlParameter{ParameterName="@OrderType",SqlDbType=SqlDbType.Bit,Value=orderType},
                                new SqlParameter{ParameterName="@strWhere",SqlDbType=SqlDbType.VarChar,Value=where},
                                new SqlParameter{ParameterName="@innerFields",SqlDbType=SqlDbType.VarChar,Value=innerFields},
                                new SqlParameter{ParameterName="@funStr",SqlDbType=SqlDbType.VarChar,Value=""},
                                new SqlParameter{ParameterName="@innerwhere",SqlDbType=SqlDbType.VarChar,Value=innwhere}
                                };
            var rowdt = DBHelper.ExecuteDataTableSp("pagination2", pas);
            recordCount = 0;
            if (rowdt != null && rowdt.Rows.Count > 0)
            {
                recordCount = Int32.Parse(rowdt.Rows[0][0].ToString());
            }
            return resdt;
        }
    }
}
