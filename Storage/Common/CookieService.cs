using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    /// <summary>
    /// Cookie 帮助类
    /// </summary>
    public class CookieService
    {
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="cookieValue">Cookie值</param>
        /// <param name="days">保存天数</param>
        public static void SetCookie(string cookieName, string cookieValue, int days)
        {
            if (cookieValue == null)
            {
                ClearCookie(cookieName);
                return;
            }

            //创建一个cookie对象实例 , 不设置cookie时间,表式为会话cookie
            HttpCookie cookie = new HttpCookie(cookieName);

            cookie.Expires = DateTime.Now.AddDays(days);

            //将数据加密            
            string strEncrypto = PassWordService.Encrypto(cookieValue);

            //将加密后的数据设置给cookie
            cookie.Value = strEncrypto;
            //将cookie发送发服务器
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="cookieValue">Cookie值</param>
        public static void SetCookie(string cookieName, string cookieValue)
        {
            if (cookieValue == null)
            {
                ClearCookie(cookieName);
                return;
            }
            //创建一个cookie对象实例 , 不设置cookie时间,表式为会话cookie
            HttpCookie cookie = new HttpCookie(cookieName);
            //将数据加密            
            string strEncrypto = PassWordService.Encrypto(cookieValue);
            //将加密后的数据设置给cookie
            cookie.Value = strEncrypto;
            //将cookie发送发服务器
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <returns>Cookie名称对应的值</returns>
        public static string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                return null;
            }
            else
            {
                string str = PassWordService.Decrypto(cookie.Value);
                return str;
            }
        }

        /// <summary>
        /// 清除Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookie.Value = null;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
