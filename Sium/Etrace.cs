using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace Sium
{
    public class Etrace
    {
        public Etrace()
        { }
      
        /// <summary>
        /// 解密PKCS7-CBC
        /// </summary>
        /// <param name="Jjson"></param>
        /// <returns></returns>
        public string stringJson(string Jjson)
        {
            string plainText = "";
            ELangWebService.GoEXSoapClient s = new ELangWebService.GoEXSoapClient();
            plainText = s.stringJson(Jjson);
            s.Close();
            s.Abort();
            return plainText;
        }
        public bool getbool()
        {
            ELangWebService.GoEXSoapClient s = new ELangWebService.GoEXSoapClient();
            return s.HelloBool();
        }
      
       

    }
}
