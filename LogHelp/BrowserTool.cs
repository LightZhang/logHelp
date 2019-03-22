using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace LogHelp
{
    public class BrowserTool
    {

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static string GetAppPath()
        {
            string result;
            if (HttpContext.Current != null)
            {
                result = HttpContext.Current.Server.MapPath("~");
            }
            else
            {
                result = AppDomain.CurrentDomain.BaseDirectory;
            }
            return result;
        }

        public static string GetIp()
        {
            string text = string.Empty;
            text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.UserHostAddress;
            }
            string result;
            if (text == null || text == string.Empty )
            {
                result = "0.0.0.0";
            }
            else
            {
                result = text;
            }
            return result;
        }

        public static string GetOS()
        {
            HttpBrowserCapabilities httpBrowserCapabilities = new HttpBrowserCapabilities();
            httpBrowserCapabilities = HttpContext.Current.Request.Browser;
            return httpBrowserCapabilities.Platform;
        }

        public static string GetBrowser()
        {
            HttpBrowserCapabilities httpBrowserCapabilities = new HttpBrowserCapabilities();
            httpBrowserCapabilities = HttpContext.Current.Request.Browser;
            return httpBrowserCapabilities.Type;
        }

        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

     

    }
}
