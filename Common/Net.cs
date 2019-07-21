using System;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;
namespace Silt.Base.Common
{
	//// <summary>
    //// SysUtil 的摘要说明。
	//// Purpose: 同系统功能相关公共资源
	//// Version:ZASuite1.0 @2006
	//// Author: 陶银洲
	//// Date: 2006
    //// </summary>
	public class Net
	{

        public Net()
		{
			///
			/// TODO: 在此处添加构造函数逻辑
			///            
           
		}
        /// <summary>
        /// 取得主机名
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            IPHostEntry ipHE = Dns.GetHostByName(Dns.GetHostName());
            return ipHE.HostName.ToString();
        }
        /// <summary>
        /// 取得主机IP
        /// </summary>
        /// <returns></returns>
        public string GetHostIpAddress()
        {
            IPHostEntry ipHE = Dns.GetHostByName(Dns.GetHostName());
            return ipHE.AddressList[0].ToString();
        }
       
	}
}
