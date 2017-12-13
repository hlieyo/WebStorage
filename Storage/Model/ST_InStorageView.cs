using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ST_InStorageView
    {

        public ST_InStorageView() { }

        public ST_InStorageView(DataRow row)
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

            if (row.Table.Columns.Contains("S_Brand"))
                if (row["S_Brand"] != DBNull.Value) this.S_BRAND = row["S_Brand"].ToString();

            if (row.Table.Columns.Contains("S_Code"))
                if (row["S_Code"] != DBNull.Value) this.S_CODE = row["S_Code"].ToString();

            if (row.Table.Columns.Contains("S_Name"))
                if (row["S_Name"] != DBNull.Value) this.S_NAME = row["S_Name"].ToString();

            if (row.Table.Columns.Contains("S_Type"))
                if (row["S_Type"] != DBNull.Value) this.S_TYPE = row["S_Type"].ToString();

            if (row.Table.Columns.Contains("S_Unit"))
                if (row["S_Unit"] != DBNull.Value) this.S_UNIT = row["S_Unit"].ToString();
        }

        /// <summary>
        ///品牌
        /// </summary>
        public string S_BRAND { get; set; }

        /// <summary>
        ///商品代码
        /// </summary>
        public string S_CODE { get; set; }

        /// <summary>
        ///商品名称
        /// </summary>
        public string S_NAME { get; set; }


        /// <summary>
        ///商品分类
        /// </summary>
        public string S_TYPE { get; set; }

        /// <summary>
        ///单位
        /// </summary>
        public string S_UNIT { get; set; }

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
    }

}
