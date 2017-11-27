using Foundation.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ST_OutStorage:BaseEntityObject
    {

        public ST_OutStorage() { }

        public ST_OutStorage(DataRow row)
        {
            if (row.Table.Columns.Contains("ID"))
                if (row["ID"] != DBNull.Value) this.ID = Convert.ToInt32(row["ID"]);

            if (row.Table.Columns.Contains("O_AddTime"))
                if (row["O_AddTime"] != DBNull.Value) this.O_ADDTIME = Convert.ToDateTime(row["O_AddTime"]);

            if (row.Table.Columns.Contains("O_AddUser"))
                if (row["O_AddUser"] != DBNull.Value) this.O_ADDUSER = row["O_AddUser"].ToString();

            if (row.Table.Columns.Contains("O_Num"))
                if (row["O_Num"] != DBNull.Value) this.O_NUM = Convert.ToDecimal(row["O_Num"]);

            if (row.Table.Columns.Contains("O_Price"))
                if (row["O_Price"] != DBNull.Value) this.O_PRICE = Convert.ToDecimal(row["O_Price"]);

            if (row.Table.Columns.Contains("O_SumPrice"))
                if (row["O_SumPrice"] != DBNull.Value) this.O_SUMPRICE = Convert.ToDecimal(row["O_SumPrice"]);

            if (row.Table.Columns.Contains("O_ShopsId"))
                if (row["O_ShopsId"] != DBNull.Value) this.O_SHOPSID = Convert.ToInt32(row["O_ShopsId"]);

        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int O_SHOPSID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Int32 ID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime O_ADDTIME { get; set; }

        /// <summary>
        ///出货人
        /// </summary>
        public string O_ADDUSER { get; set; }

        /// <summary>
        ///出货数量
        /// </summary>
        public decimal O_NUM { get; set; }

        /// <summary>
        ///出货单价
        /// </summary>
        public decimal O_PRICE { get; set; }

        /// <summary>
        ///出货总价
        /// </summary>
        public decimal O_SUMPRICE { get;set;}
    }
}
