using Foundation.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ST_InStorage : BaseEntityObject
    {
        public ST_InStorage() { }

        public ST_InStorage(DataRow row)
        {
            if (row.Table.Columns.Contains("I_AddTime"))
                if (row["I_AddTime"] != DBNull.Value) this.I_ADDTIME = Convert.ToDateTime(row["I_AddTime"]);

            if (row.Table.Columns.Contains("I_AddUser"))
                if (row["I_AddUser"] != DBNull.Value) this.I_ADDUSER = row["I_AddUser"].ToString();

            if (row.Table.Columns.Contains("I_Num"))
                if (row["I_Num"] != DBNull.Value) this.I_NUM = Convert.ToDecimal(row["I_Num"]);

            if (row.Table.Columns.Contains("I_Price"))
                if (row["I_Price"] != DBNull.Value) this.I_PRICE = Convert.ToDecimal(row["I_Price"]);

            if (row.Table.Columns.Contains("I_SumPrice"))
                if (row["I_SumPrice"] != DBNull.Value) this.I_SUMPRICE = Convert.ToDecimal(row["I_SumPrice"]);

            if (row.Table.Columns.Contains("ID"))
                if (row["ID"] != DBNull.Value) this.ID = Convert.ToInt32(row["ID"]);

            if (row.Table.Columns.Contains("I_SHOPSID"))
                if (row["I_SHOPSID"] != DBNull.Value) this.I_SHOPSID = Convert.ToInt32(row["I_SHOPSID"]);

        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public  int I_SHOPSID { get; set; }

        /// <summary>
        ///入库时间
        /// </summary>
        public DateTime I_ADDTIME { get; set; }

        /// <summary>
        ///入库人
        /// </summary>
        public string I_ADDUSER { get; set; }

        /// <summary>
        ///入库数量
        /// </summary>
        public decimal I_NUM { get; set; }

        /// <summary>
        ///入库单价
        /// </summary>
        public decimal I_PRICE { get; set; }

        /// <summary>
        ///入库总价
        /// </summary>
        public decimal I_SUMPRICE { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Int32 ID { get; set; }

    }
}
