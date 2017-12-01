using Common;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.CommonHelper;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var item = new ST_SysAdmin();
            item.UserName = CookieService.GetCookie("uname") == null ? "" : CookieService.GetCookie("uname");
            item.UserPwd = CookieService.GetCookie("upwd") == null ? "" : CookieService.GetCookie("upwd");
            item.IsRemember = CookieService.GetCookie("isRemember") == null || CookieService.GetCookie("isRemember") .Equals("0")? false :true;
            return View(item);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult GetValidateCode()
        {
            string checkCode = RandService.Number(4);
            CookieService.SetCookie("Code", checkCode);
            var bt = new ValidateCodeService().CreateImages(checkCode);
            return File(bt, "image/JPEG");
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="validateCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Userlogin(string userName, string passWord, string validateCode,bool isRemember)
        {
            var result = new JsonResult();
            var cookie = CookieService.GetCookie("Code");
            //if (!validateCode.Equals(cookie))
            //{
            //    result.Data = "验证码验证错误";
            //    return result;
            //}
            Session["sysAdmin"] = null;
            if (isRemember)
            {
                CookieService.SetCookie("uname", userName,7);
                CookieService.SetCookie("upwd", passWord,7);
                CookieService.SetCookie("isRemember", isRemember?"1":"0",7);
            }
            else
            {
                CookieService.ClearCookie("uname");
                CookieService.ClearCookie("upwd");
                CookieService.ClearCookie("isRemember");
            }

            ST_SysAdmin user = new ST_SysAdmin() { UserName = userName, UserPwd = PassWordService.MD5(passWord) };
            var loginUser = St_LogicHelper.UserLogin(user);
            if (loginUser != null)
            {
                Session["sysAdmin"] = loginUser;
                result.Data = "success";
            }
            else
            {
                result.Data = "用户名或密码错误";
            }
            return result;
        }

    }
}