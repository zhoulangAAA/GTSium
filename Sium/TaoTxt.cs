using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Sium
{
    public partial class TaoTxt : Form
    {
        StringBuilder SpTxt = new StringBuilder();
        StringBuilder SpJson = new StringBuilder();
        string EndDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        public TaoTxt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtitemUv.Text = this.txtitemUv.Text.Replace("	", ",");
            this.txtpayItemQty.Text = this.txtpayItemQty.Text.Replace("	", ",");
            this.txtuvSe.Text = this.txtuvSe.Text.Replace("	", ",");
        }

        private void TaoTxt_Load(object sender, EventArgs e)
        {
            lbEnddate.Text = EndDate;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Write();
        }
        public void ShowInfo(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        public void Write()
        {
          
            DateTime dt = DateTime.Now.AddDays(-1);
            SpJson.Append("{\"traceId\":\"0bfb815614967628514014492e9777\",\"code\":0,\"data\":{\"list\":[{\"2\":{");
            SpJson.Append("\"payItemQty\":[" + GetListKey(txtpayItemQty.Text) + "],");
            SpJson.Append("\"uvSe\":[" + GetListKey(txtuvSe.Text) + "],");
            SpJson.Append("\"itemUv\":[" + GetListKey(txtitemUv.Text) + "]");

            SpJson.Append("}}],\"lastDay\":\"" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "\"},\"message\":\"操作成功\"}");

            SpTxt.Append("HTTP/1.1 200 OK");
            SpTxt.Append("\r\nDate: "+ string.Format("{0:R}", dt) + "");
            SpTxt.Append("\r\nContent-Type: application/json;charset=UTF-8");
            SpTxt.Append("\r\nConnection: keep-alive");
            SpTxt.Append("\r\nVary: Accept-Encoding");
            SpTxt.Append("\r\nAccess-Control-Allow-Origin: https://sycm.taobao.com");
            SpTxt.Append("\r\nAccess-Control-Allow-Methods: GET, POST, OPTIONS");
            SpTxt.Append("\r\nAccess-Control-Allow-Headers: Origin, No-Cache, X-Requested-With, If-Modified-Since, Pragma, Last-Modified, Cache-Control, Expires, Content-Type, X-E4M-With");
            SpTxt.Append("\r\nAccess-Control-Allow-Credentials: true");
            SpTxt.Append("\r\nContent-Language: zh-CN");
            SpTxt.Append("\r\nServer: Tengine/Aserver");
            SpTxt.Append("\r\nEagleEye-TraceId: 0bfb815614967628514014492e9777");
            SpTxt.Append("\r\nStrict-Transport-Security: max-age=31536000");
            SpTxt.Append("\r\nTiming-Allow-Origin: *");
            
            byte[] datas = System.Text.Encoding.UTF8.GetBytes(SpJson.ToString());
            MessageBox.Show(datas.Length.ToString());
            SpTxt.Append("\r\nContent-Length: " + datas.Length.ToString() + "");
            SpTxt.Append("\r\n");
            SpTxt.Append("\r\n");
            SpTxt.Append(SpJson.ToString());

            string PathUrl = "";
            if (diydate.Checked)
            {
                PathUrl = "D:\\diydate.txt";
            }
            else
            {
                if (this.comboBox1.Text == "7天数据")
                { PathUrl = "D:\\7date.txt"; }

                if (this.comboBox1.Text == "30天数据")
                { PathUrl = "D:\\30date.txt"; }
            }

            //string Txx = txtitemUv.Text + txtpayItemQty.Text + txtuvSe.Text;
            FileStream fs = new FileStream(PathUrl, FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.UTF8.GetBytes(SpTxt.ToString());
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            SpJson.Clear();
            SpTxt.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (diydate.Checked)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                DateTime d1 = DateTime.Parse(this.EndDate);
                DateTime d2 = dateTimePicker1.Value;
                TimeSpan d3 = d1.Subtract(d2);
                GetStringKey(this.txtitemUv.Text, d3.Days+2);
            }
            else
            {
                if (this.comboBox1.Text == "7天数据")
                { GetStringKey(this.txtitemUv.Text, 7); }

                if (this.comboBox1.Text == "30天数据")
                { GetStringKey(this.txtitemUv.Text, 30); }
            }
        }
        public string GetListKey(string instr)
        {
            string Getkey = "";
            if (diydate.Checked)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                DateTime d1 = dateTimePicker2.Value;
                DateTime d2 = dateTimePicker1.Value;
                TimeSpan d3 = d1.Subtract(d2);
                Getkey=GetStringKey(instr, d3.Days + 2);
            }
            else
            {
                if (this.comboBox1.Text == "7天数据")
                { Getkey= GetStringKey(instr, 7); }

                if (this.comboBox1.Text == "30天数据")
                { Getkey=GetStringKey(instr, 30); }
            }
            return Getkey;

        }
        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="instr">写入多少天</param>
        /// <param name="getday">传入字符串</param>
        /// <returns></returns>
        public string GetStringKey(string instr, int getday)
        {
            StringBuilder newSpTxt = new StringBuilder();
            int instrlength = instr.Split(',').Length;
            if (instrlength < getday)
            {
                for (int i = 0; i < getday-instrlength; i++)
                {
                    newSpTxt.Append("0,");
                }
                newSpTxt.Append(instr);
            }
            ShowInfo(newSpTxt.ToString());
           // string newstringKey = "";
            return newSpTxt.ToString();
        }
    }
}
