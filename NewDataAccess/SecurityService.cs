using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace DataAccessLayer.DataAccess
{
    /// <summary>
    /// SecurityService 的摘要说明。
    /// </summary>
    public class SecurityService
    {
        static protected Byte[] byteKey = { 117, 14, 45, 12, 234, 79, 77, 234, 37, 104, 13, 9, 118, 51, 87, 123 };
        static protected Byte[] byteIV = { 32, 123, 79, 32, 72, 123, 13, 123 };

        static public string SymmetricEncrypt(String sPlainText)
        {
            Byte[] bytePlaintext;
            MemoryStream EncryptedStream;
            ICryptoTransform Encryptor;
            CryptoStream TheCryptoStream;
            if (sPlainText == "") return "";
            bytePlaintext = Encoding.ASCII.GetBytes(sPlainText);
            EncryptedStream = new MemoryStream(sPlainText.Length);
            Encryptor = GetEncryptor();
            TheCryptoStream = new CryptoStream(EncryptedStream, Encryptor, CryptoStreamMode.Write);
            TheCryptoStream.Write(bytePlaintext, 0, bytePlaintext.Length);
            TheCryptoStream.FlushFinalBlock();
            TheCryptoStream.Close();

            return Convert.ToBase64String(EncryptedStream.ToArray());

        }//End Function

        static public string SymmetricDecrypt(String sEncryptedText)
        {
            Byte[] byteEncrypted;
            MemoryStream PlaintextStream;
            ICryptoTransform Decryptor;
            CryptoStream TheCryptoStream;

            if (sEncryptedText == "") return "";

            byteEncrypted = Convert.FromBase64String(sEncryptedText.Trim());
            PlaintextStream = new MemoryStream(sEncryptedText.Length);
            Decryptor = GetDecryptor();
            TheCryptoStream = new CryptoStream(PlaintextStream, Decryptor, CryptoStreamMode.Write);

            TheCryptoStream.Write(byteEncrypted, 0, byteEncrypted.Length);
            TheCryptoStream.FlushFinalBlock();
            TheCryptoStream.Close();

            return Encoding.ASCII.GetString(PlaintextStream.ToArray());

        }//End Function

        static private ICryptoTransform GetEncryptor()
        {
            RC2CryptoServiceProvider CryptoProvider = new RC2CryptoServiceProvider();
            CryptoProvider.Mode = CipherMode.CBC;
            return CryptoProvider.CreateEncryptor(byteKey, byteIV);

        }//End Function

        static private ICryptoTransform GetDecryptor()
        {
            RC2CryptoServiceProvider CryptoProvider = new RC2CryptoServiceProvider();
            CryptoProvider.Mode = CipherMode.CBC;
            return CryptoProvider.CreateDecryptor(byteKey, byteIV);

        }//End Function
    }
}
