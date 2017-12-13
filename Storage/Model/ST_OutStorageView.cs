using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ST_OutStorageView
    {
        public ST_OutStorageView() { }

        public ST_OutStorageView(DataRow row)
        {
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
        public decimal O_SUMPRICE { get; set; }

    }
}
