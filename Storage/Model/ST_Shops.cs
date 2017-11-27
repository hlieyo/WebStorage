using Foundation.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ST_Shops : BaseEntityObject
    {

        public ST_Shops() { }
        public ST_Shops(DataRow row)
        {
            if (row.Table.Columns.Contains("ID"))
                if (row["ID"] != DBNull.Value) this.ID = Convert.ToInt32(row["ID"]);

            if (row.Table.Columns.Contains("S_Brand"))
                if (row["S_Brand"] != DBNull.Value) this.S_BRAND = row["S_Brand"].ToString();

            if (row.Table.Columns.Contains("S_Code"))
                if (row["S_Code"] != DBNull.Value) this.S_CODE = row["S_Code"].ToString();

            if (row.Table.Columns.Contains("S_DelFlg"))
                if (row["S_DelFlg"] != DBNull.Value) this.S_DELFLG = Convert.ToBoolean(row["S_DelFlg"]);

            if (row.Table.Columns.Contains("S_InDate"))
                if (row["S_InDate"] != DBNull.Value) this.S_INDATE = Convert.ToDateTime(row["S_InDate"]);

            if (row.Table.Columns.Contains("S_InPrice"))
                if (row["S_InPrice"] != DBNull.Value) this.S_INPRICE = Convert.ToDecimal(row["S_InPrice"]);

            if (row.Table.Columns.Contains("S_Name"))
                if (row["S_Name"] != DBNull.Value) this.S_NAME = row["S_Name"].ToString();

            if (row.Table.Columns.Contains("S_OutDate"))
                if (row["S_OutDate"] != DBNull.Value) this.S_OUTDATE = Convert.ToDateTime(row["S_OutDate"]);

            if (row.Table.Columns.Contains("S_OutPrice"))
                if (row["S_OutPrice"] != DBNull.Value) this.S_OUTPRICE = Convert.ToDecimal(row["S_OutPrice"]);

            if (row.Table.Columns.Contains("S_SumNum"))
                if (row["S_SumNum"] != DBNull.Value) this.S_SUMNUM = Convert.ToDecimal(row["S_SumNum"]);

            if (row.Table.Columns.Contains("S_SumPrice"))
                if (row["S_SumPrice"] != DBNull.Value) this.S_SUMPRICE = Convert.ToDecimal(row["S_SumPrice"]);

            if (row.Table.Columns.Contains("S_Type"))
                if (row["S_Type"] != DBNull.Value) this.S_TYPE = row["S_Type"].ToString();

            if (row.Table.Columns.Contains("S_Unit"))
                if (row["S_Unit"] != DBNull.Value) this.S_UNIT = row["S_Unit"].ToString();

        }

        /// <summary>
        ///
        /// </summary>
        public Int32 ID { get; set; }

        /// <summary>
        ///品牌
        /// </summary>
        public string S_BRAND { get; set; }

        /// <summary>
        ///商品代码
        /// </summary>
        public string S_CODE { get; set; }

        /// <summary>
        ///是否已删除
        /// </summary>
        public bool S_DELFLG { get; set; }

        /// <summary>
        ///最后进货日期
        /// </summary>
        public DateTime? S_INDATE { get; set; }

        /// <summary>
        ///进货单价
        /// </summary>
        public decimal S_INPRICE { get; set; }

        /// <summary>
        ///商品名称
        /// </summary>
        public string S_NAME { get; set; }

        /// <summary>
        ///最后出货日期
        /// </summary>
        public DateTime? S_OUTDATE { get; set; }

        /// <summary>
        ///出货单价
        /// </summary>
        public decimal S_OUTPRICE { get; set; }

        /// <summary>
        ///总数量
        /// </summary>
        public decimal S_SUMNUM { get; set; }

        /// <summary>
        ///总价值
        /// </summary>
        public decimal S_SUMPRICE { get; set; }

        /// <summary>
        ///商品分类
        /// </summary>
        public string S_TYPE { get; set; }

        /// <summary>
        ///单位
        /// </summary>
        public string S_UNIT { get; set; }
    }
}
