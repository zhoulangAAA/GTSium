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
    public partial class hqkeyword : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();       
        SQLServer Ms = new SQLServer();
        string CcateId,CTit, CItemid,CDateTime;
        public hqkeyword(StringBuilder FPPcok,string cateId,string Tit,string ItemID)
        {
           
            InitializeComponent();

            FPPcokk = FPPcok;
            CcateId = cateId;
            CTit = Tit;
            CItemid = ItemID;
            CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            this.Text = CTit;

        }
        public void ShowInfo(string Info)
        {
            //textBox2.AppendText(Info);
            //textBox2.AppendText(Environment.NewLine);
            //textBox2.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Sqldel = "delete from hqKeyword  where  ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Sqldel = "delete from hqUV  where ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int HourNumber = DateTime.Now.Hour;
            int UHour = HourNumber - 1;
            string Sql = "update hqUV set DateHour = " + UHour + " where DateHour = " + HourNumber+ " and ItemID = '" + CItemid + "' and DItemdate = '" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int HourNumber = DateTime.Now.Hour;
            int UHour = HourNumber - 1;
            string Sql = "update hqKeyword set DateHour = " + UHour + " where DateHour = " + HourNumber + " and ItemID = '" + CItemid + "' and DItemdate = '" + CDateTime + "'"; 
            Ms.ExeSQLNonQuery(Sql);
        }

      
        /// <summary>
        /// 关键字
        /// </summary>
        public void getai()
        {
            int HourNumber = DateTime.Now.Hour;
            PostServer.Getcookie = FPPcokk.ToString();
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            string KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveKeywords.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&pageSize=20&page=1&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
           // ShowInfo(FPPcokk.ToString());
          //  ShowInfo(gHtml);

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["data"]["data"].ToString();

            string Sqldel = "delete from hqKeyword  where DateHour=" + HourNumber+ " and ItemID='"+ CItemid + "' and DItemdate='"+ CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldel);
         
            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string shopNameID = results[i]["keyword"]["value"].ToString();
                int Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                // ShowInfo(bb + "----" + aa);
                string Sql = "INSERT INTO [hqKeyword]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + "-(SELECT isnull(SUM(houNumber),0) FROM dbo.hqKeyword where shopname='" + shopNameID + "' and DateHour<" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'),'" + CItemid + "','"+ CDateTime + "')";

                //  ShowInfo(Sql);
                Ms.ExeSQLNonQuery(Sql);

             //   ShowInfo("关建字:" + results[i]["keyword"]["value"].ToString() + ":" + results[i]["uv"]["value"].ToString());

            }
            Ms.ClearParameters();
            Ms.AddParameter("@ItemID", CItemid, SQLServer.SQLDataType.SQLString, CItemid.Length, System.Data.ParameterDirection.Input);
            Ms.AddParameter("@paydate", CDateTime, SQLServer.SQLDataType.SQLDateTime, 4, System.Data.ParameterDirection.Input);
            //StringBuilder Sqll = new StringBuilder();
            //Sqll.Append("SELECT [shopName],[DateHour],[HouNumber] into #KeyTable FROM [dbo].[hqKeyword] where itemid='"+ CItemid + "' and DItemdate='"+ CDateTime + "'");
            //Sqll.Append("SELECT * FROM #KeyTable");
            //Sqll.Append(" AS P");
            //Sqll.Append(" PIVOT");
            //Sqll.Append("(");
            //Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            //Sqll.Append("p.DateHour/*需要行转列的列*/ IN ([0],[23],[22],[21],[20],[19],[18],[17],[16],[15],[14],[13],[12],[11],[10],[9],[8],[7],[6],[5],[4],[3],[2],[1]/*列的值*/)");
            //Sqll.Append(") AS T");
            //Sqll.Append("GO");
            //  string GSql = "select * from [hqKeyword_View]";Ms.runSPDataSet("Y_hqKeyword").Tables[0]; 
           // Sqll
            this.ultraGrid2.DataSource = Ms.runSPDataSet("Y_hqKeyword").Tables[0];
            ultraGrid2.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;

        }

        private void ultraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        public void getLU()
        {
            
            int HourNumber = DateTime.Now.Hour;
            PostServer.Getcookie = FPPcokk.ToString();
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            string KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc&_=1535785900902&token=";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
            // ShowInfo(FPPcokk.ToString());
            //  ShowInfo(gHtml);

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["data"]["data"].ToString();

            string Sqldel = "delete from hqUV  where DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldel);

            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string shopNameID = results[i]["pageName"]["value"].ToString();
                int Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                // ShowInfo(bb + "----" + aa);
                string Sql = "INSERT INTO [hqUV]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + "-(SELECT isnull(SUM(houNumber),0) FROM dbo.hqUV where shopname='" + shopNameID + "' and DateHour<" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'),'" + CItemid + "','" + CDateTime + "')";

                //  ShowInfo(Sql);
                Ms.ExeSQLNonQuery(Sql);

                //   ShowInfo("关建字:" + results[i]["keyword"]["value"].ToString() + ":" + results[i]["uv"]["value"].ToString());

            }
            //Ms.ClearParameters();
            //Ms.AddParameter("@ItemID", CItemid, SQLServer.SQLDataType.SQLString, CItemid.Length, System.Data.ParameterDirection.Input);
            //Ms.AddParameter("@paydate", CDateTime, SQLServer.SQLDataType.SQLDateTime, 4, System.Data.ParameterDirection.Input);
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT [shopName],[DateHour],[HouNumber] into #KeyTable FROM [dbo].[hqUV] where itemid='" + CItemid + "' and DItemdate='" + CDateTime + "'");
            Sqll.Append("SELECT * FROM #KeyTable");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.DateHour/*需要行转列的列*/ IN ([0],[23],[22],[21],[20],[19],[18],[17],[16],[15],[14],[13],[12],[11],[10],[9],[8],[7],[6],[5],[4],[3],[2],[1]/*列的值*/)");
            Sqll.Append(") AS T");
            //Sqll.Append("GO");
            //  string GSql = "select * from [hqKeyword_View]";Ms.runSPDataSet("Y_hqKeyword").Tables[0]; 
            // Sqll
            this.ultraGrid1.DataSource = Ms.runSQLDataSet(Sqll.ToString(), "ss").Tables[0];
            ultraGrid1.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < DateTime.Parse("2019-6-20"))
            {
                getai();
                getLU();
                this.timer1.Enabled = true;
            }
           

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            getai();
            getLU();
        }

    }
}
