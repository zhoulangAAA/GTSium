using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Silt.Base.Common
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log
    {
        public Log()
        {
            ///
            /// TODO: 在此处添加构造函数逻辑
            ///
        }
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="strErrorTitle">错误标题</param>
        /// <param name="strException">异常主体</param>
        public void ZASaveLog(string strErrorTitle, string strException)
        {
            if (strErrorTitle == "" || strErrorTitle == "")
            {
                strErrorTitle = "一般异常";
            }
            StreamWriter sw;            
            //sw = File.AppendText(Server.MapPath(null) + "\\ZASuite~Log.log");//Web
            sw = File.AppendText(System.Configuration.ConfigurationSettings.AppSettings["SysLogFileName"]);//Winform
            sw.WriteLine("--------开始-------");
            sw.WriteLine("时间：" + System.DateTime.Now.ToString());
            sw.WriteLine("系统：" + System.Configuration.ConfigurationSettings.AppSettings["SysName"]);
            sw.WriteLine("标题：" + strErrorTitle);
            sw.WriteLine(strException);
            sw.WriteLine("--------结束-------");
            sw.WriteLine("");
            sw.Flush();
            sw.Close();
        }
    }
}
