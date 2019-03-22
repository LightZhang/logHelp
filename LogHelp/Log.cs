using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LogHelp
{
    public class Log
    {


        /// <summary>
        /// 错误日志 写内容
        /// </summary>
        /// <param name="errorMsg"></param>
        public static void WriteError(string errorMsg)
        {
            Log.WriteToFile("Error", errorMsg);
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logFileName">文件名</param>
        /// <param name="strings">内容</param>
        public static void Write(string logFileName, string strings)
        {
            try
            {
                if (!File.Exists(logFileName))
                {
                    FileStream fileStream = File.Create(logFileName);
                    fileStream.Close();
                }
                StreamWriter streamWriter = new StreamWriter(logFileName, true, Encoding.GetEncoding("gb2312"));
                streamWriter.WriteLine(strings);
                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 写日志，内容
        /// </summary>
        /// <param name="txt"></param>
        public static void Write(string txt)
        {
            Log.WriteToFile("", txt);
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="_fileName">文件名</param>
        /// <param name="_string">内容</param>
        /// <param name="_encoding">编码</param>
        /// <returns></returns>
        public static bool Write(string _fileName, string _string, string _encoding)
        {
            bool result = false;
            try
            {
                if (!File.Exists(_fileName))
                {
                    FileStream fileStream = File.Create(_fileName);
                    fileStream.Close();
                    fileStream.Dispose();
                }
                StreamWriter streamWriter = new StreamWriter(_fileName, true, Encoding.GetEncoding(_encoding));
                streamWriter.WriteLine(_string);
                streamWriter.Close();
                streamWriter.Dispose();
                result = true;
            }
            catch
            {
            }
            return result;
        }


        /// <summary>
        /// 写日志到指定文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="txt">内容</param>
        public static void WriteToFile(string fileName, string txt)
        {
            if (fileName == "")
            {
                fileName = "Log";
            }
            string text = BrowserTool.GetAppPath();
            if (HttpContext.Current != null)
            {
                string text2 = text;
                text = string.Concat(new string[] { text2, "/Log/", fileName, "_", DateTime.Now.ToString("yyyyMMdd"), ".log" });

                Log.Write(text, "/*******************************************************************************************************");
                Log.Write(text, string.Concat(new string[] {"* DateTime: ", DateTime.Now.ToString(), "\t\tIP: ", BrowserTool.GetIp(), "\t\tBrower: ", BrowserTool.GetOS(), "  ", BrowserTool.GetBrowser() }));
                Log.Write(text, "* Url : " + BrowserTool.GetUrl());
            }
            else
            {
                text += "/Log";
                try
                {
                    Directory.CreateDirectory(text);
                }
                catch
                {
                }
                string text2 = text;
                text = string.Concat(new string[]
                {  text2, "/",  fileName, "_", DateTime.Now.ToString("yyyyMMdd"), ".log" });

                text = text.Replace("\\", "/");
                Log.Write(text, "/*******************************************************************************************************");
                Log.Write(text, "DateTime: " + DateTime.Now.ToString());
            }
            Log.Write(text, txt);
            Log.Write(text, "*******************************************************************************************************/");
            Log.Write(text, "");
        }





    }
}
