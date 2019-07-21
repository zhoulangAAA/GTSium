using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sium
{
    public partial class test2 : Form
    {
        public test2()
        {
            InitializeComponent();
        }

        private void test2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("到这里了");
            JObject json = (JObject)JsonConvert.DeserializeObject("sdfweeeewerwerwereeeeeeeeeeeeeee");
            string zone = json["data"]["data"].ToString();
            JArray results = JArray.Parse(zone);

        }
        public void test()
        {
            JObject json = (JObject)JsonConvert.DeserializeObject("sdfweeeewerwerwereeeeeeeeeeeeeee");
            string zone = json["data"]["data"].ToString();
            JArray results = JArray.Parse(zone);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }
    }
}
