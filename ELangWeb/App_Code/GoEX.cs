using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// GoEX 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class GoEX : System.Web.Services.WebService
{

    public GoEX()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    /// <summary>
    /// 转16进制
    /// </summary>x
    /// <param name="hexString"></param>
    /// <returns></returns>
    private byte[] strToToHexByte(string hexString)
    {
        hexString = hexString.Replace(" ", "");
        if ((hexString.Length % 2) != 0)
            hexString += " ";
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
        {
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }
        return returnBytes;
    }
    [WebMethod]
    /// <summary>
    /// 解密PKCS7-CBC
    /// </summary>
    /// <param name="Jjson"></param>
    /// <returns></returns>
    public string stringJson(string Jjson)
    {
        string plainText = "";
        byte[] c = strToToHexByte(Jjson);

        string cipherText = Convert.ToBase64String(c); ;
        RijndaelManaged rijndael = new RijndaelManaged();
        rijndael.Padding = PaddingMode.PKCS7;
        rijndael.Mode = CipherMode.CBC;
        ICryptoTransform transform = rijndael.CreateDecryptor(Encoding.UTF8.GetBytes("sycmsycmsycmsycm"), Encoding.UTF8.GetBytes("mcysmcysmcysmcys"));
        byte[] bCipherText = Convert.FromBase64String((cipherText));//这里要用这个函数来正确转换Base64字符串成Byte数组
        MemoryStream ms = new MemoryStream(bCipherText);
        CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Read);
        byte[] bPlainText = new byte[bCipherText.Length];
        cs.Read(bPlainText, 0, bPlainText.Length);
        plainText = Encoding.UTF8.GetString(bPlainText);
        plainText = plainText.Trim('\0');
        return plainText;
    }

}
