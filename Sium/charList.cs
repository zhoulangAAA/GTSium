using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sium
{
    public partial class charList : Form
    {
        private Silt.Client.Rules.Tao.MASrcFlow baselistrules = new Silt.Client.Rules.Tao.MASrcFlow();
       
        StringBuilder SpTxt = new StringBuilder();
        StringBuilder SpJson = new StringBuilder();
        public charList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d4 = DateTime.Parse(this.EndDateL.Text).AddDays(-30);

            DateTime d1 = DateTime.Parse(this.EndDateL.Text);
            DateTime d2 = dateTimePicker1.Value;

            TimeSpan d3 = d1.Subtract(d2);
            TimeSpan D5 = d2.Subtract(d4);
            DataTable MayTable = baselistrules.GetPage(this.comboBox1.SelectedValue.ToString(), this.comboBox2.SelectedValue.ToString(), 1);
            textBox1.Text = d3.Days.ToString();
            SpJson.Append("{\"message\":\"操作成功\",\"data\":{\"list\":[");
            for (int K = 0; K < D5.Days; K++)
            {
                SpJson.Append("{\"hasNext\":false,\"uvRate\":0.0451837140019861,\"ptSourceLevel\":0,\"uv\":0,\"pv\":0,\"statDate\":\"" + d4.AddDays(K).ToString("yyyy-MM-dd") + "\",\"payItemQty\":27,\"orderBuyerCnt\":28,\"payBuyerCnt\":27,\"orderRate\":0.3077,\"favBuyerCnt\":2,\"addCartBuyerCnt\":7,\"payRate\":0.2967,\"jpUvIn\":34,\"jpUvOut\":90,\"nextIsUrl\":false,\"pvRate\":0.041337668369716675,\"sourceLevel\":0},");
            }

          
            for (int i = 0; i <=d3.Days+1; i++)
            {
                SpJson.Append("{\"hasNext\":false,\"uvRate\":0.0451837140019861,\"ptSourceLevel\":0,\"uv\":"+ MayTable.Rows[i]["uv"].ToString() + ",\"pv\":"+MayTable.Rows[i]["pv"].ToString()+",\"statDate\":\""+ d2.AddDays(i).ToString("yyyy-MM-dd")+ "\",\"payItemQty\":27,\"orderBuyerCnt\":28,\"payBuyerCnt\":27,\"orderRate\":0.3077,\"favBuyerCnt\":2,\"addCartBuyerCnt\":7,\"payRate\":0.2967,\"jpUvIn\":34,\"jpUvOut\":90,\"nextIsUrl\":false,\"pvRate\":0.041337668369716675,\"sourceLevel\":0}");
                if (i != d3.Days+1)
                {
                    SpJson.Append(",");
                }
            }
            SpJson.Append("]},\"code\":0,\"traceId\":\"0b83dd3614980602104342973e4aa0\"}");
            Write();
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        public void Write()
        {

            DateTime dt = DateTime.Now.AddDays(-1);
            //SpJson.Append("{\"message\":\"操作成功\",\"data\":{\"list\":[");
            //SpJson.Append("{\"hasNext\":false,\"uvRate\":0.0451837140019861,\"ptSourceLevel\":0,\"uv\":91,\"pv\":178,\"statDate\":\"2017-06-20\",\"payItemQty\":27,\"orderBuyerCnt\":28,\"payBuyerCnt\":27,\"orderRate\":0.3077,\"favBuyerCnt\":2,\"addCartBuyerCnt\":7,\"payRate\":0.2967,\"jpUvIn\":34,\"jpUvOut\":90,\"nextIsUrl\":false,\"pvRate\":0.041337668369716675,\"sourceLevel\":0}");
           
            //SpJson.Append("]},\"code\":0,\"traceId\":\"0b83dd3614980602104342973e4aa0\"}");

            //SpJson.Append("}}],\"lastDay\":\"" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "\"},\"message\":\"操作成功\"}");

            SpTxt.Append("HTTP/1.1 200 OK");
            SpTxt.Append("\r\nDate: " + string.Format("{0:R}", dt) + "");
            SpTxt.Append("\r\nContent-Type: application/json;charset=UTF-8");
            SpTxt.Append("\r\nVary: Accept-Encoding");
            SpTxt.Append("\r\nAccess-Control-Allow-Origin: https://sycm.taobao.com");
            SpTxt.Append("\r\nAccess-Control-Allow-Methods: GET, POST, OPTIONS");
            SpTxt.Append("\r\nAccess-Control-Allow-Headers: Origin, No-Cache, X-Requested-With, If-Modified-Since, Pragma, Last-Modified, Cache-Control, Expires, Content-Type, X-E4M-With");
            SpTxt.Append("\r\nAccess-Control-Allow-Credentials: true");
            SpTxt.Append("\r\nContent-Language: zh-CN");
            SpTxt.Append("\r\nServer: Tengine/Aserver");
            SpTxt.Append("\r\neagleeye-traceid: 0b83dd3614980602104342973e4aa0");
            SpTxt.Append("\r\nstrict-transport-security: max-age=31536000");
            SpTxt.Append("\r\nTiming-Allow-Origin: *");
            SpTxt.Append("\r\nX-Firefox-Spdy: h2");
            SpTxt.Append("\r\n");
            SpTxt.Append(SpJson.ToString());

            string PathUrl = "D:\\Diy30date.txt";
            //if (diydate.Checked)
            //{
            //    PathUrl = "D:\\diydate.txt";
            //}
            //else
            //{
            //    if (this.comboBox1.Text == "7天数据")
            //    { PathUrl = "D:\\7date.txt"; }

            //    if (this.comboBox1.Text == "30天数据")
            //    { PathUrl = "D:\\30date.txt"; }
            //}

            //string Txx = txtitemUv.Text + txtpayItemQty.Text + txtuvSe.Text;
            FileStream fs = new FileStream(PathUrl, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.UTF8.GetBytes(SpJson.ToString());
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            SpJson.Clear();
            SpTxt.Clear();
        }

        private void charList_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "shopID";//控件显示的列名  
            comboBox1.ValueMember = "ItemID";//控件值的列名  
            comboBox1.DataSource = baselistrules.Getcombox();

            comboBox2.DisplayMember = "PageName";//控件显示的列名  
            comboBox2.ValueMember = "PageName";//控件值的列名  
            comboBox2.DataSource = baselistrules.GetPageName();

            this.EndDateL.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

        }
    }
}
