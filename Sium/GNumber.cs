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
    public partial class GNumber : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        StringBuilder FPPcok = new StringBuilder();
        SQLServer Ms = new SQLServer();
        public GNumber(StringBuilder FPPcok)
        {
            InitializeComponent();
            FPPcokk = FPPcok;

        }
        #region 登录凭证
        //public void GetCook()
        //{

        //    FPPcok.Clear();
        //    //var cok = driver.Manage().Cookies
        //    // ShowInfo(cok.AllCookies.ToString());
        //    //获取Cookie
        //    ICookieJar listCookie = driver.Manage().Cookies;
        //    // IList<Cookie> listCookie = selenuim.Manage( ).Cookies.AllCookies;//只是显示 可以用Ilist对象
        //    //显示初始Cookie的内容

        //    Console.WriteLine("--------------------");
        //    Console.WriteLine($"当前Cookie集合的数量：\t{listCookie.AllCookies.Count}");
        //    for (int i = 0; i < listCookie.AllCookies.Count; i++)
        //    {

        //        FPPcok.Append($"{listCookie.AllCookies[i].Name}=");
        //        FPPcok.Append($"{listCookie.AllCookies[i].Value};");

        //    }
        //}

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

            ////string Url = "https://login.taobao.com/member/login.jhtml?from=sycm&full_redirect=true&style=minisimple&minititle=&minipara=0,0,0&sub=true&redirect_url=https://subway.simba.taobao.com/#!/home";
            //string Url = "https://subway.simba.taobao.com/#!/home";
            //driver.Navigate().GoToUrl(Url);
            //Thread.Sleep(1000);
        }
        public void getai()
        {
           

          //  GetCook();
            int HourNumber = DateTime.Now.Hour;
            PostServer.Getcookie = FPPcokk.ToString();
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=350404&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
            // ShowInfo(gHtml);
            //  Thread.Sleep(10000);

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["data"]["data"]["topDatas"]["list"].ToString();
             string zone1 = json["data"]["data"]["watchDatas"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            DataTable dts1= JsonConvert.DeserializeObject<DataTable>(zone1);
            this.ultraGrid1.DataSource = dts;
            string Sqldel = "delete from hqNumber  where DateHour=" + HourNumber;
            Ms.ExeSQLNonQuery(Sqldel);
            // ultraGrid1.DisplayLayout.Bands[0].Columns["ADDate"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            // DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone);
            // loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            // dt = KeywordProdurcer.Tables[0];
            foreach (DataRow keydr in dts.Rows)
            {
                //    dr = dt.NewRow();
                //    dr["ID"] = 0;
                //    //
                //    dr["ItemID"] = ItemID.Text;
                //    //
                //    dr["keyword"] = keydr["keyword"].ToString();
                //    //
                //    dr["keypv"] = float.Parse(keydr["uv"].ToString());
                //    //
                //    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
                //    //
                //    dr["keytype"] = 0;
                //    dt.Rows.Add(dr);
                string bb = "店铺:" + keydr["shopName"].ToString();
                string aa = "件数:" + keydr["paySubOrderCnt"].ToString();
                string shopNameID = keydr["itemid"].ToString() + keydr["shopName"].ToString();
                // ShowInfo(bb + "----" + aa);
                string Sql = "INSERT INTO [hqNumber]([shopName],[DateHour],[HouNumber])VALUES('" + shopNameID + "'," + HourNumber + "," + int.Parse(keydr["paySubOrderCnt"].ToString()) + "-(SELECT isnull(SUM(houNumber),0) FROM dbo.hqNumber where shopname='" + shopNameID + "' and DateHour<" + HourNumber + "))";
               
               

               
                //  ShowInfo(Sql);
                Ms.ExeSQLNonQuery(Sql);
               
               
            }
             string GSql = "select * from [Pnumber_View]";
            this.ultraGrid2.DataSource = Ms.runSQLDataSet(GSql, "ss").Tables[0]; ;
          //  ultraGrid3.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //driver.Navigate().GoToUrl("https://subway.simba.taobao.com/#!/visitor/info");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (DateTime.Now < DateTime.Parse("2019-6-20"))
            {
                getai();
                colgrid();
                this.timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getai();
            colgrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string GSql = "delete from hqNumber";
           // string Sqldel = "delete from hqNumber  where DateHour=" + HourNumber;
            Ms.ExeSQLNonQuery(GSql);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int HourNumber = DateTime.Now.Hour;
            int UHour = HourNumber - 1;
            string Sql = "update hqNumber set DateHour = "+ UHour + " where DateHour = "+ HourNumber;
            Ms.ExeSQLNonQuery(Sql);

        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            e.Layout.Override.RowSelectorWidth = 30;
        }

        private void ultraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            e.Layout.Override.RowSelectorWidth = 30;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 大盘详细排名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click_1(object sender, EventArgs e)
        {
            string GSql = "select * from [Pnumber_View]";
            this.ultraGrid2.DataSource = Ms.runSQLDataSet(GSql, "ss").Tables[0]; ;
            for (int i = 0; i < this.ultraGrid2.Rows.Count; i++)
            {
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("景宏电器专营店"))//景宏
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("tcl小麦专卖店"))//TCL
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("美菱鑫宁专卖店"))//美菱鑫宁专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                //if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("539837217405"))//TCL
                //{
                //    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                //    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //}
                //if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString() == "548469188855奥克斯雨昕专卖店")
                //{
                //    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                //    // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //}
                //if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString() == "568857860149景宏电器专营店")
                //{
                //    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                //   //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //}
                //if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("572715793348"))
                //{
                //    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                //     // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //}

            }
        }
        public void colgrid()
        {
            for (int i = 0; i < this.ultraGrid2.Rows.Count; i++)
            {
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("景宏电器"))//景宏
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("tcl小麦"))//TCL
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("美菱鑫"))//美菱鑫宁专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                //if (this.ultraGrid2.Rows[i].Cells["shopname"].Value.ToString().Contains("574580557480奥克斯万博同辉专卖店"))
                //{
                //    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                //    // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //}

            }

            for (int i = 0; i < this.ultraGrid1.Rows.Count; i++)
            {
                //    if (this.ultraGrid1.Rows[i].Cells["shopname"].Value.ToString() == "奥克斯雨昕专卖店")
                //    {
                //        this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;
                //        // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //    }
                //    if (this.ultraGrid1.Rows[i].Cells["shopname"].Value.ToString() == "奥克斯万博同辉专卖店")
                //    {
                //        this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;
                //        //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                //    }
                if (this.ultraGrid1.Rows[i].Cells["shopname"].Value.ToString().Contains("景宏电器"))//景宏
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;
                    // this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid1.Rows[i].Cells["shopname"].Value.ToString().Contains("tcl小麦"))//TCL
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }
                if (this.ultraGrid1.Rows[i].Cells["shopname"].Value.ToString().Contains("美菱鑫宁"))//美菱鑫宁专卖店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;
                    //  this.ultraGrid2.Rows[i].Appearance.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0000ff");   // Color.Red;

                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click_2(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid2, fileName);
            Process.Start(fileName);
        }
    }
}
