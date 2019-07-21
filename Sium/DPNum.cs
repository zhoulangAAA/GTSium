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
  
    public partial class DPNum : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string CDateTime;
        public DPNum(StringBuilder FPPcok)
        {
            InitializeComponent();
            FPPcokk = FPPcok;
            CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void Getshopindex()
        {
            DateTime BegDate = this.txtbegdate.Value;
            DateTime EndDate = this.txtenddate.Value;
            double ts2 = EndDate.Subtract(BegDate).TotalDays;
            string cItemid = txtItemID.Text;
            string ccateId = txtcateId.Text;
            
            for (int i = 0; i < ts2; i++)
            {
                Thread.Sleep(5000);
               
                string KeUrl = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId="+ ccateId+ "&selfItemId="+ cItemid + "&dateType=day&dateRange="+ BegDate.AddDays(i).ToString("yyyy-MM-dd") + "%7C"+ BegDate.AddDays(i).ToString("yyyy-MM-dd") + "&indexCode=payByrCntIndex&orderBy=payByrCntIndex&order=desc&_=1537104746274&token=";
                PostServer.Getcookie = FPPcokk.ToString();
                PostServer.GetHTTPTaobao(KeUrl);
               
                string txpayRateIndex = PostServer.GetHtml;
                JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string zone = json["data"].ToString();
                JArray results = JArray.Parse(zone);
                for (int j = 0; j < results.Count; j++)
                {
                    decimal aa = decimal.Parse(results[j]["selfItemPayByrCntIndex"]["value"].ToString());
                    // ShowInfo("值:" + aa.ToString());
                    decimal bb= Math.Round(aa, 0);
                    //;
                    decimal cc= decimal.Parse(results[j]["selfItemPayByrCnt"]["value"].ToString());

                    string Sql = "INSERT INTO [DP_Num]([inNum],[outNum],[typeid])VALUES("+ bb + ","+cc+",1)";
                    Ms.ExeSQLNonQuery(Sql);
                }

            }
            string Sqll = "Delete from DP_Num where outNum=0";
            Ms.ExeSQLNonQuery(Sqll);

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);

            double d = 1.5201;
            double result = System.Math.Pow(a, d);
            double result1 = result * 0.409 / 100;
            //  MessageBox.Show(c.ToString());
            // MessageBox.Show(result.ToString());
            //  MessageBox.Show(result1.ToString());
            this.textBox2.Text = Math.Round(result1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Getshopindex();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SqqS = "select distinct   *from DP_num";
            ultraGridcnt.DataSource = Ms.runSQLDataSet(SqqS, "ss").Tables[0];
            // ultraGridcnt.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.AliceBlue;
            ultraGridcnt.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.SkyBlue;
            
        }

        private void DPNum_Load(object sender, EventArgs e)
        {
            string SqqS = "select  inNum，outNum from DP_num";
            ultraGridcnt.DataSource = Ms.runSQLDataSet(SqqS, "ss").Tables[0];
        }
    }
}
