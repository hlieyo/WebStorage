using Logic;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InView()
        {
            return View();
        }
        public ActionResult OutView()
        {
            return View();
        }
        public ActionResult ShopsView()
        {
            return View();
        }
        public ActionResult AddShops()
        {
            return View();
        }
        public ActionResult ShopsReport()
        {
            return View();
        }

        /// <summary>
        /// 分页获取商品数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetShopsByPage()
        {
            var result = new JsonResult();
            var start = Request.Form["start"]; //开始索引
            var length = Request.Form["length"]; //页大小
            var draw = Request.Form["draw"]; //原值返回
            var search = Request.Form["search"]; //自定义查询条件

            var shopsType = ""; //订单类型
            var queryStr = ""; //搜索关键字
            var querytime = ""; 
            var pageIndex = (int)Math.Ceiling(Convert.ToInt32(start) * 1.0 / 10);

            if (!string.IsNullOrWhiteSpace(search))
            {
                JObject obj = JObject.Parse(search);
                if (obj != null)
                {
                    queryStr = obj["KeyWhere"] == null ? "" : obj["KeyWhere"].ToString();
                    shopsType = obj["shopsType"] == null ? "" : obj["shopsType"].ToString();
                    querytime = obj["querytime"] == null ? "" : obj["querytime"].ToString();
                }
            }

            var SearchStr = new StringBuilder();
            SearchStr.Append(" 1=1");
            if (!string.IsNullOrWhiteSpace(querytime))
            {
                var time = querytime.Split(new char[] { '至' });
                if (time.Count() == 2)
                {
                    SearchStr.Append(" and S_InDate>='" + DateTime.Parse(time[0] + " 00:00:00") + "'");
                    SearchStr.Append(" and S_InDate<='" + DateTime.Parse(time[1] + " 23:59:59") + "'");
                }
            }
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                SearchStr.Append(" and (S_Code like '%" + queryStr + "%'  or  S_Name like '%" + queryStr + "%')");
            }

            if (!string.IsNullOrWhiteSpace(shopsType) && !shopsType.Equals("分类"))
            {
                SearchStr.Append(" and  S_Type='"+ shopsType + "'");
            }

            var pageCount = 0;
            var list = new List<ST_Shops>();
            list = St_LogicHelper.SelectByPagesShops(Convert.ToInt32(length), pageIndex + 1, SearchStr.ToString(), out pageCount);
            var resultObj = new
            {
                draw = Convert.ToInt32(draw),
                recordsTotal = pageCount,
                recordsFiltered = pageCount,
                data = list
            };
            result.Data = resultObj;
            return result;
        }


        /// <summary>
        /// 保存产品
        /// </summary>
        /// <param name="shops"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveShops(ST_Shops shops)
        {
            var result = new JsonResult();
            if (shops == null)
            {
                result.Data = "获取保存的商品信息失败";
            }
            else
            {
                if (shops.ID == 0)
                {
                    shops.S_INDATE = DateTime.Now;
                    shops.EntityState = System.Data.EntityState.Added;
                }
                else
                {
                    shops.EntityState = System.Data.EntityState.Modified;
                }

                if (St_LogicHelper.SaveStShops(shops))
                {
                    result.Data = "success";
                }
                else
                {
                    result.Data = "商品信息保存失败";
                }
            }
            return result;
        }


    }
}