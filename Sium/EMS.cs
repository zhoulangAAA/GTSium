using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Sium
{
    public partial class EMS : Form
    {
        HttpPost PostServer = new HttpPost();
        public EMS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lis = new List<string>();

            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                lis.Add(textBox1.Lines[i].ToString());
                try
                {
                    Thread.Sleep(1000);
                    PostServer.GetHTTPEMS("https://www.kuaidi100.com/query?type=zhongtong&postid=" + textBox1.Lines[i].ToString() + "&id=1&valicode=");
                    string gHtml = PostServer.GetHtml;
                    JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                    string zone = json["data"].ToString();
                    DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                    string sget = textBox1.Lines[i].ToString() + "-" + dts.Rows[0]["context"].ToString() + dts.Rows[0]["ftime"].ToString() + "\r\n";
                    FileStream fs = new FileStream("D:\\EMS.txt", FileMode.Append);
                    //获得字节数组
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(sget);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();
                    // textBox1.Lines[i] = "";
                }
                catch
                {
                    break;

                }
            }
            //for (int j = 0; j < lis.Count; j++)
            //{
            //    //try
            //    //{
            //    //    Thread.Sleep(1000);
            //    //    PostServer.GetHTTPEMS("https://www.kuaidi100.com/query?type=zhongtong&postid=" + lis[j].ToString() + "&id=1&valicode=");
            //    //    string gHtml = PostServer.GetHtml;
            //    //    JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            //    //    string zone = json["data"].ToString();
            //    //    DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            //    //    string sget = lis[j].ToString() + "-" + dts.Rows[0]["context"].ToString() + dts.Rows[0]["ftime"].ToString() + "\r\n";
            //    //    System.IO.File.AppendAllText(@"D:\\EMS.txt", sget);
            //    //}
            //    //catch
            //    //{
            //    //    break;

            //    //}
            //    //// MessageBox.Show(sget);
            //    //FileStream fs = new FileStream("D:\\EMS.txt", FileMode.Create);
            //    ////获得字节数组
            //    //byte[] data = System.Text.Encoding.UTF8.GetBytes(sget);
            //    ////开始写入
            //    //fs.Write(data, 0, data.Length);
            //    ////清空缓冲区、关闭流
            //    //fs.Flush();
            //    //fs.Close();
            //}
            MessageBox.Show("换IP");
          


        }
    }
}
