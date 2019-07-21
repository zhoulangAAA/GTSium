using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Sium
{
    public partial class Formtest : Form
    {
        public Formtest()
        {
            InitializeComponent();
        }
        public string ConvertHexToString(string HexValue, string separator = null)
        {
            HexValue = string.IsNullOrEmpty(separator) ? HexValue : HexValue.Replace(string.Empty, separator);
            StringBuilder sbStrValue = new StringBuilder();
            while (HexValue.Length > 0)
            {
                sbStrValue.Append(Convert.ToChar(Convert.ToInt64(HexValue.Substring(0, 2), 16)).ToString());
                HexValue = HexValue.Substring(2);
            }
            return sbStrValue.ToString();
        }
       

        public string ConvertStringToHex(string strASCII, string separator = null)
        {
            StringBuilder sbHex = new StringBuilder();
            foreach (char chr in strASCII)
            {
                sbHex.Append(String.Format("{:X2}", Convert.ToInt64(chr)));
                sbHex.Append(separator ?? string.Empty);
            }
            return sbHex.ToString();
        }
        public string stringJson(string Jjson)
        {
            string plainText = "";
            try
            {

                byte[] c = strToToHexByte(Jjson);

                string cipherText = Convert.ToBase64String(c); ;
                RijndaelManaged rijndael = new RijndaelManaged();
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.Mode = CipherMode.CBC;
                ICryptoTransform transform = rijndael.CreateDecryptor(Encoding.UTF8.GetBytes("w28Cz694s63kBYk4"), Encoding.UTF8.GetBytes("4kYBk36s496zC82w"));
                byte[] bCipherText = Convert.FromBase64String((cipherText));//这里要用这个函数来正确转换Base64字符串成Byte数组
                MemoryStream ms = new MemoryStream(bCipherText);
                CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Read);
                byte[] bPlainText = new byte[bCipherText.Length];
                cs.Read(bPlainText, 0, bPlainText.Length);
                plainText = Encoding.UTF8.GetString(bPlainText);
                plainText = plainText.Trim('\0');
                return plainText;
            }
            catch (Exception)
            {

                return plainText;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = stringJson(this.textBox5.Text);
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strJson =this.textBox1.Text;
            Etrace EtrJson = new Etrace();
            string ToJson = EtrJson.stringJson(strJson);
            textBox1.Text = ToJson;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cipherText = "rDSLO3K0xHsRzztWlWcLRjC/+cibkj/oERaZUoS8zfK5/PpRhpOCp6tAeF803osreTYZ5DHG5LGx7niqeOB6709R0uFRvp7xL4LTVlDKxD62wxKRYQa3S9o03nKIjuBZRd9E3G7cKwYLzfuXXLhXlFW6j9ODh7clHwlktXX/Bq+UM1xo+TQkOMG2wB0OoDbc9mcwW+hlUPnLTI+UldoPn4O8XO78VgbPNFEzOxzOIurH5gk7d0NbwkOeqE/PNNbTGOnEDcfaWXf2+lbJv4ny2QrhLf6ufE1kkGEJr0rkv6hkPtvZ6th3Non3qW4+eSOEfyBI5x7V03SeP1wHQoPb6+xNYToKwJ2FGPd/L107/9nDpby4uYJQcEcw0tuY260dw7ejMGSHRbzHWLugksh3xCPAQBTYIgVmkbo1uObtVC+Lq6Hl2+fW/qjdOTVJUlo7WJeofWg4++61nY4iDapqjeoAMNyHfeg02hmmvV3YB3mjPdcAkjlAVEm7rzygBXDq9aRoCI7M/T5DQQZ/22+zBX/oO0sfzP9yCF1Skp6pvjNOtOa0ojlkDqeY0PQDdfr964z/Xw2LX5CPAYrw3qmfEh1nLZNzbh3B+GihEsCrBdwYqd6DMLtGY1UNP1SP+DpumyDz1sXmfSXy9Vy/U1+HwihonG9Kzql+evJ5suhTrFH1g+HrQA2thwrxsV9nBEpqxwTcKGP7fNZSDoqMSKrN8dT/bzxcsKZEdjcPWhpH6nLLAEiatrAalJmgOppG5DO8u+t1Y/yLCKB5GcDorCKr5Q==";
            byte[] bCipherText = Convert.FromBase64String((cipherText));
            textBox2.Text = ToHexString(bCipherText);
        }

      
        private string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            string[] chars = hs.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = HexStringToString(textBox2.Text, Encoding.UTF8); 
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private  byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            { 
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
              //  textBox2.Text = textBox2.Text + returnBytes[i].ToString()+"-";
                    }
            return returnBytes;
        }
        #region 64位转化
        /// <summary>
        /// 可用
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public  string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            textBox3.Text = "";
            StringBuilder strB = new StringBuilder();
            string hexString = string.Empty;
            if (bytes != null)
            {
               

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                   
                }
                hexString = strB.ToString();
            }

            return hexString;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] bCipherText = Convert.FromBase64String(this.textBox1.Text);
            textBox2.Text = ToHexString(bCipherText);
        }
        //64位
        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder stringGet = new StringBuilder();
            textBox5.Text = "";
            byte[] bCipherText = Convert.FromBase64String(this.textBox1.Text);

            for (int i = 0; i < bCipherText.Length; i++)
            {
                stringGet.Append(bCipherText[i].ToString() + "-");
            }
            textBox5.Text = stringGet.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //byte[] c = Convert.ToBase64String(textBox2.Text);
            //textBox5.Text= System.Text.Encoding.Default.GetString(c);
        }
        #endregion

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] c = strToToHexByte(textBox1.Text);
            textBox5.Text= Convert.ToBase64String(c);
        }

        private void button10_Click(object sender, EventArgs e)
        {
           // byte[] b = System.Text.Encoding.UTF8.GetBytes(jsons);
            byte[] c = strToToHexByte(textBox1.Text);
            textBox5.Text = Convert.ToBase64String(c);
        }
    }
}
