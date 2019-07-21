using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using DataAccessLayer.DataAccess;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
namespace Sium
{
    public partial class ONkeyword : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string  begCdatetime,CDateTime;
        public ONkeyword(StringBuilder FPPcok)
        {
            InitializeComponent();
            FPPcokk = FPPcok;
          
            CDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            begCdatetime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        }

        public void PayList(string Keyname)
        {
            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = "https://sycm.taobao.com/mc/searchword/relatedWord.json?dateRange="+ begCdatetime + "%7C"+ CDateTime + "&dateType=recent7&pageSize=100&page=1&order=desc&orderBy=seIpvUvHits&keyword="+ Keyname+ "&device=0&indexCode=seIpvUvHits%2CsePvIndex%2CclickRate%2CclickHits%2CclickHot&_=1538571848534&token=";
            PostServer.GetHTTPTaobao(strpayRateIndex);
        
            string gHtml = PostServer.GetHtml;

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            // string zone = json["result"][1].ToString();
            string zone = json["data"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            ultraGrid3.DataSource = dts;

            dts.Columns["seIpvUvHits"].ColumnName = "搜索人气";
            //dts.Columns["cost"].ColumnName = "花费";
            dts.Columns["sePvIndex"].ColumnName = "搜索热度";
            dts.Columns["clickRate"].ColumnName = "点击率";
            dts.Columns["clickHits"].ColumnName = "点击人气";
            dts.Columns["clickHot"].ColumnName = "点击热度";
            dts.Columns["tradeIndex"].ColumnName = "交易指数";
            dts.Columns["payConvRate"].ColumnName = "支付转化率";
            dts.Columns["onlineGoodsCnt"].ColumnName = "在线商品数";
            dts.Columns["tmClickRatio"].ColumnName = "商城点击占比";
            dts.Columns["p4pAmt"].ColumnName = "直通车参考价";
            // dts.Columns["tradeIndex"].
            // this.ultraGrid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            // this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance= Infragistics.Win.b
          //  ultraGrid3.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Aqua;

            //this.ultraGrid3.UseOsThemes = DefaultableBoolean.True;
            //ultraGrid3.DisplayLayout.Override.HotTrackCellAppearance.BackColor = Color.Blue;
            //this.ultraGrid3.DisplayLayout.Override.HotTrackRowCellAppearance.BackColor = Color.Yellow;
            //this.ultraGrid3.DisplayLayout.Override.HotTrackHeaderAppearance.BackColor = Color.Blue;
            //this.ultraGrid3.DisplayLayout.Override.HotTrackRowAppearance.ForeColor = Color.LightGreen;
            //this.ultraGrid3.DisplayLayout.Override.HotTrackRowSelectorAppearance.BackColor = Color.Green;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PayList(this.textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid3, fileName);
            Process.Start(fileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
