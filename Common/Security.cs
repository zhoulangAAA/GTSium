using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;
namespace Silt.Base.Common
{
    public class Security
    {
        public Security()
        {
            ///
            /// TODO: 在此处添加构造函数逻辑
            ///

        }
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="format">加密格式 SHA1,MD5，当前系统采用MD5</param>
        /// <param name="str">明文字符</param>       
        /// <returns>加密码后字符</returns>
        public static string StrToEncrypt(string format, string str)
        {
            //SHA1,MD5           
            string password = str;
            byte[] dataOfPwd = (new UnicodeEncoding()).GetBytes(password);
            byte[] hashValueOfPwd = ((HashAlgorithm)CryptoConfig.CreateFromName(format)).ComputeHash(dataOfPwd);
            password = BitConverter.ToString(hashValueOfPwd);
            return password;
        }
    }
}
