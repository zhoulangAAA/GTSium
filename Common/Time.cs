using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Silt.Base.Common
{
	
	public class Time
	{

        public Time()
		{
			///
			/// TODO: 在此处添加构造函数逻辑
			///            
           
		}
        ///取得当前日期时间
        public String GetDataTime()
        {
            return GetData() + " " + GetTime();
        }
        ///取得当前日期
        public String GetData()
        {
            string DateTemp = string.Empty;
            System.DateTime date = System.DateTime.Now;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day);
            return DateTemp;

        }
        ///取得当前时间
        public String GetTime()
        {
            string DateTemp = string.Empty;
            System.DateTime date = System.DateTime.Now;
            DateTemp = Convert.ToString(date.Hour) + ":"
               + Convert.ToString(date.Minute) + ":"
               + Convert.ToString(date.Second);
            return DateTemp;
        }
        /// <summary>
        /// 取得当前开始日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ZAGetStartData(DateTime dt)
        {
            string DateTemp = string.Empty;
            System.DateTime date = dt;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day) + " 00:00:00";
            string strdata = Convert.ToDateTime(DateTemp).ToString();
            return strdata;

        }

        /// <summary>
        /// 取得当前结束日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ZAGetEndData(DateTime dt)
        {
            string DateTemp = string.Empty;
            System.DateTime date = dt;
            DateTemp = Convert.ToString(date.Year) + "-"
                + Convert.ToString(date.Month) + "-"
                + Convert.ToString(date.Day) + " 23:59:59";
            string strdata = Convert.ToDateTime(DateTemp).ToString();
            return strdata;
        }
	}
}
