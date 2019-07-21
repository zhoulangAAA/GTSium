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
namespace Sium
{
    public partial class KeyWordTao : Form
    {
        public KeyWordTao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            HttpPost PostServer = new HttpPost();
            string KKurl = "https://suggest.taobao.com/sug?code=utf-8&q="+this.textBox1.Text+"&_ksTS=1554358322769_809&callback=jsonp810&k=1&area=c2c&bucketid=3";
            PostServer.GetHTTPTaobaocom(KKurl);
            string gHtml = PostServer.GetHtml;
           // "\r\{\"result\":[[\"挂烫机\",\"85735.7101952053\"],[\"挂烫机家用\",\"55755.755138021355\"],[\"挂烫机家用 蒸汽 小型\",\"26903.098636030758\"],[\"挂烫机 蒸汽 家用\",\"39576.9363256785\"],[\"挂烫机 手持\",\"38590.10342904935\"],[\"挂烫机商用服装店\",\"3144.651087228193\"],[\"挂烫机家用 小型\",\"18744.079323797137\"],[\"挂烫机 蒸汽 家用 立式\",\"26500.344969199177\"],[\"挂烫机配件\",\"18808.569732937685\"],[\"挂烫机家用新款全自动\",\"2434.595238095238\"]],\"magic\":[{\"index\":\"2\",\"type\":\"tag_group\",\"data\":[[{\"title\":\"挂式\",\"type\":\"hot\"},{\"title\":\"便携式\"},{\"title\":\"立式\"}],[{\"title\":\"服装店\"},{\"title\":\"熨斗\",\"type\":\"hot\"},{\"title\":\"小型\"},{\"title\":\"扬子\"},{\"title\":\"蒸汽\"},{\"title\":\"双杆\"},{\"title\":\"红心\"}]]},{\"index\":\"9\",\"type\":\"tag_group\",\"data\":[[{\"title\":\"水箱\"},{\"title\":\"通用\"},{\"title\":\"红心\"},{\"title\":\"衣架\"},{\"title\":\"全铝\"},{\"title\":\"上海\"},{\"title\":\"发热体\"},{\"title\":\"飞利浦\"},{\"title\":\"蒸汽\",\"type\":\"hot\"},{\"title\":\"喷头\"}]]}]})"
           string a= gHtml.Replace("jsonp810(", "").Replace(")", "");
         //    a = gHtml.Replace("\r\n", "").Replace("\\", "");
            // JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            JObject json = (JObject)JsonConvert.DeserializeObject(a);
            string zone = json["result"].ToString();
            JArray array = JsonConvert.DeserializeObject<JArray>(zone);
            for (int i = 0; i < array.Count; i++)
            {
                ShowInfo(array[i][0].ToString()+"-"+ array[i][1].ToString());
            }
         
        }
        public void ShowInfo(string Info)
        {
            textBox5.AppendText(Info);
            textBox5.AppendText(Environment.NewLine);
            textBox5.ScrollToCaret();
        }

    }
}
