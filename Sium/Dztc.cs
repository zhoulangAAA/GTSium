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
    public partial class Dztc : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string  CDateTime,TTid;
        public Dztc(StringBuilder FPPcok,string TID)
        {

            InitializeComponent();

            FPPcokk = FPPcok;
            TTid = TID;
              CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
          

        }
        public void ShowInfo(string Info)
        {
            //textBox2.AppendText(Info);
            //textBox2.AppendText(Environment.NewLine);
            //textBox2.ScrollToCaret();
        }

        /// <summary>
        /// 成交和指数
        /// </summary>
        public void getai()
        {
            int HourNumber = DateTime.Now.Hour;
           
            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                try
                {

               
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString()+keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                //  string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
                Thread.Sleep(5000);
                    PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                    string txpayRateIndex = PostServer.GetHtml;

                    JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                    string strJson = EJson["data"].ToString();
                    Etrace EtrJson = new Etrace();
                    string ToJson = EtrJson.stringJson(strJson);

                   // PostServer.GetHTTPTaobao(strpayRateIndex);
              //  string txpayRateIndex = PostServer.GetHtml;
                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
                for (int j = 0; j <=6; j++)
                {
                    //支付转化指数
                    string typeIDstr = "";
                    string jsonpayRateIndex = "";

                    if (j == 0)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["cartHits"].ToString();
                        typeIDstr = "cartHits";
                    }
                    if (j == 1)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["cltHits"].ToString();
                        typeIDstr = "cltHits";
                    }
                    if (j == 2)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["payItemCnt"].ToString();
                        typeIDstr = "payItemCnt";
                    }
                    if (j == 3)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["payRateIndex"].ToString();
                        typeIDstr = "payRateIndex";
                    }
                    if (j == 4)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["seIpvUvHits"].ToString();
                        typeIDstr = "seIpvUvHits";
                    }
                    if (j == 5)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["tradeIndex"].ToString();
                        typeIDstr = "tradeIndex";
                    }
                    if (j == 6)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["uvIndex"].ToString();
                        typeIDstr = "uvIndex";
                    }
                    //删除
                    string Sqldel = " delete from Dpnumber where ItemID='" + CItemid + "' and typeid='" + typeIDstr + "'";
                    Ms.ExeSQLNonQuery(Sqldel);
                    //ShowInfo(jsonpayRateIndex);
                    JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                    for (int i = 0; i < payRateIndexJArray.Count; i++)
                    {
                        decimal NumberPayRate = 0;
                        if (payRateIndexJArray[i].ToString() != "")
                        {
                            NumberPayRate = Math.Ceiling(decimal.Parse(payRateIndexJArray[i].ToString()));
                        }
                        else
                        {
                            NumberPayRate = 0;
                        }
                        string Sql = "INSERT INTO [DPNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + i + "," + NumberPayRate + ",'"+ typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                        Ms.ExeSQLNonQuery(Sql);
                    }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


            this.ultraGridcnt.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payItemCnt").ToString(), "ss").Tables[0];
            //this.ultraGrid2.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "uvIndex").ToString(), "ss").Tables[0];
            //this.ultraGrid5.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "cartHits").ToString(), "ss").Tables[0];
            this.ultraGrid3.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payRateIndex").ToString(), "ss").Tables[0];

            ultraGridcnt.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid2.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid5.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            ultraGrid3.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;


            ultraGridcnt.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            ultraGridcnt.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid2.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid2.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid5.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid5.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid3.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid3.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;


        }
        public StringBuilder txtSql(string cdatetime,string typeid)
        {
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT [shopName],[DateHour],[HouNumber] into #KeyTable FROM [dbo].[DPNumber] where DItemdate='" + cdatetime + "' and typeid='"+ typeid + "'");
            Sqll.Append("SELECT * FROM #KeyTable");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.DateHour/*需要行转列的列*/ IN ([0],[23],[22],[21],[20],[19],[18],[17],[16],[15],[14],[13],[12],[11],[10],[9],[8],[7],[6],[5],[4],[3],[2],[1]/*列的值*/)");
            Sqll.Append(") AS T");
            Sqll.Append(" drop table #KeyTable");
           
            return Sqll;
        }
        /// <summary>
        /// 成交和指数
        /// </summary>
        public void PayList()
        {
            int HourNumber = DateTime.Now.Hour;

            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                try
                {


                    PostServer.Getcookie = FPPcokk.ToString();
                    string CcateId, CItemid, CshopName;
                    CItemid = keydr["itemid"].ToString();
                    CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                    CcateId = "50012100";
                    string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                    //  string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
                    //Thread.Sleep(5000);
                    //PostServer.GetHTTPTaobao(strpayRateIndex);
                    //string txpayRateIndex = PostServer.GetHtml;
                    PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid, "https://sycm.taobao.com/mc/ci/shop/analysis?");
                   // PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                    string txpayRateIndex = PostServer.GetHtml;

                    JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                    string strJson = EJson["data"].ToString();
                    Etrace EtrJson = new Etrace();
                    string ToJson = EtrJson.stringJson(strJson);


                    JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
                    //for (int j = 0; j <= 6; j++)
                    //{
                        //支付转化指数
                        string typeIDstr = "";
                        string jsonpayRateIndex = "";

                        //if (j == 0)
                        //{
                        //    jsonpayRateIndex = json["data"]["rivalItem1"]["cartHits"].ToString();
                        //    typeIDstr = "cartHits";
                        //}
                        //if (j == 1)
                        //{
                        //    jsonpayRateIndex = json["rivalItem1"]["cltHits"].ToString();
                        //    typeIDstr = "cltHits";
                        //}
                        //if (j == 2)
                        //{
                            jsonpayRateIndex = json["data"]["rivalItem1"]["payItemCnt"].ToString();
                            typeIDstr = "payItemCnt";
                        //}
                        //if (j == 3)
                        //{
                        //    jsonpayRateIndex = json["data"]["rivalItem1"]["payRateIndex"].ToString();
                        //    typeIDstr = "payRateIndex";
                        //}
                        //if (j == 4)
                        //{
                        //    jsonpayRateIndex = json["data"]["rivalItem1"]["seIpvUvHits"].ToString();
                        //    typeIDstr = "seIpvUvHits";
                        //}
                        //if (j == 5)
                        //{
                        //    jsonpayRateIndex = json["data"]["rivalItem1"]["tradeIndex"].ToString();
                        //    typeIDstr = "tradeIndex";
                        //}
                        //if (j == 6)
                        //{
                        //    jsonpayRateIndex = json["data"]["rivalItem1"]["uvIndex"].ToString();
                        //    typeIDstr = "uvIndex";
                        //}
                        //删除
                        string Sqldel = " delete from Dpnumber where ItemID='" + CItemid + "' and typeid='" + typeIDstr + "'";
                        Ms.ExeSQLNonQuery(Sqldel);
                        //ShowInfo(jsonpayRateIndex);
                        JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                        for (int i = 0; i < payRateIndexJArray.Count; i++)
                        {
                            decimal NumberPayRate = 0;
                            if (payRateIndexJArray[i].ToString() != "")
                            {
                                NumberPayRate = Math.Ceiling(decimal.Parse(payRateIndexJArray[i].ToString()));
                            }
                            else
                            {
                                NumberPayRate = 0;
                            }
                            string Sql = "INSERT INTO [DPNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + i + "," + NumberPayRate + ",'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                            Ms.ExeSQLNonQuery(Sql);
                        } 
                    //}
                }
                catch (Exception)
                {

                  //  throw;
                }
            }


            this.ultraGridcnt.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payItemCnt").ToString(), "ss").Tables[0];
            //this.ultraGrid2.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "uvIndex").ToString(), "ss").Tables[0];
            //this.ultraGrid5.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "cartHits").ToString(), "ss").Tables[0];
            //this.ultraGrid3.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payRateIndex").ToString(), "ss").Tables[0];

            ultraGridcnt.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid2.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid5.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid3.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;


            ultraGridcnt.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            ultraGridcnt.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid2.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid2.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid5.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid5.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid3.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid3.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            getai();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string Sql = "  delete from DPListNumber where DItemdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sql);

        }
        /// <summary>
        /// 所有重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }
        public void ListYY()
        {
            int HourNumber = DateTime.Now.Hour;

            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc&_=1535785900902&token=";

                //  string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
                // Thread.Sleep(10000);
                //PostServer.GetHTTPTaobao(strpayRateIndex);
                //string txpayRateIndex = PostServer.GetHtml;
                PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid, "https://sycm.taobao.com/mc/ci/shop/analysis?");
                //PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                string txpayRateIndex = PostServer.GetHtml;

                JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string strJson = EJson["data"].ToString();
                Etrace EtrJson = new Etrace();
                string ToJson = EtrJson.stringJson(strJson);


                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);

                //支付转化指数
                string typeIDstr = "";
                string jsonpayRateIndex = "";
                jsonpayRateIndex = json["data"].ToString();
                int NumberPayRate = 0;
               
                JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                for (int i = 0; i < payRateIndexJArray.Count; i++)
                {

                    typeIDstr = payRateIndexJArray[i]["pageName"]["value"].ToString();
                    NumberPayRate = int.Parse(payRateIndexJArray[i]["uv"]["value"].ToString());
                    //  string Sql = "INSERT INTO [DPListNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + i + "," + NumberPayRate + ",'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                    string SqlA = "INSERT INTO [DPListNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + HourNumber + "," + NumberPayRate + "-(SELECT isnull(SUM(houNumber),0) FROM dbo.DPListNumber where shopname='" + CshopName + "' and DateHour<" + HourNumber + " and typeid='" + typeIDstr + "' and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'),'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                    Ms.ExeSQLNonQuery(SqlA);
                }

            }
        }
        /// <summary>
        /// 流量
        /// </summary>
        public void Listgetai()
        {
            int HourNumber = DateTime.Now.Hour;

            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                try
                {

                    PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc&token=";

                //  string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
                // Thread.Sleep(10000);
                //PostServer.GetHTTPTaobao(strpayRateIndex);
                //string txpayRateIndex = PostServer.GetHtml;

                PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid, "https://sycm.taobao.com/mc/ci/shop/analysis?");
               // PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                string txpayRateIndex = PostServer.GetHtml;

                JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string strJson = EJson["data"].ToString();
                Etrace EtrJson = new Etrace();
                string ToJson = EtrJson.stringJson(strJson);

                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
               
                    //支付转化指数
                    string typeIDstr = "";
                    string jsonpayRateIndex = "";

                   
                        jsonpayRateIndex = json["data"].ToString(); 
                      
                
                int NumberPayRate = 0;
                //ShowInfo(jsonpayRateIndex);
                string Sqldel = "delete from DPListNumber where shopname='" + CshopName + "' and DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                string SqlPE = "delete from DPAllListNumber where shopname='" + CshopName + "' and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                Ms.ExeSQLNonQuery(Sqldel);
                Ms.ExeSQLNonQuery(SqlPE);
                JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                int getPayRate = payRateIndexJArray.Count;
                int getPayrating = 0;
                if (getPayRate>10)
                {
                    getPayrating = 10;
                }
                else
                {
                    getPayrating = getPayRate;
                }
                    for (int i = 0; i < getPayrating; i++)
                    {
                 
                           typeIDstr = payRateIndexJArray[i]["pageName"]["value"].ToString();
                           NumberPayRate = int.Parse(payRateIndexJArray[i]["uv"]["value"].ToString());
                    StringBuilder SqlBA = new StringBuilder();
                    SqlBA.Append("declare @bookId int ");
                    SqlBA.Append("SELECT @bookId=isnull(SUM(houNumber),0) FROM dbo.DPListNumber where shopname='" + CshopName + "' and DateHour<" + HourNumber + " and typeid='" + typeIDstr + "' and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'");
                    SqlBA.Append(" INSERT INTO [DPListNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + HourNumber + "," + NumberPayRate + "-@bookId,'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')");

                    string SqlB = "INSERT INTO [DPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + NumberPayRate + ",'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                    Ms.ExeSQLNonQuery(SqlBA.ToString());
                    Ms.ExeSQLNonQuery(SqlB);
                }

            }
                catch (Exception)
            {

                // throw;
            }
        }

            this.ultraGrid4.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "直通车").ToString(), "ss").Tables[0];
            this.ultraGrid7.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "手淘搜索").ToString(), "ss").Tables[0];
            //this.ultraGridindex.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "手淘首页").ToString(), "ss").Tables[0];
        
            this.ultraGrid9.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "购物车").ToString(), "ss").Tables[0]; 
            //this.ultraGrid10.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "淘内免费其他").ToString(), "ss").Tables[0];
            //this.ultraGrid11.DataSource = Ms.runSQLDataSet(txtSqlList(CDateTime, "我的淘宝").ToString(), "ss").Tables[0];

            this.ultraGridall.DataSource = Ms.runSQLDataSet(txtSqlALLList(CDateTime).ToString(), "ss").Tables[0];
            
            ultraGrid4.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            ultraGrid7.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGridindex.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid9.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid10.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid11.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;

            //ultraGrid4.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid4.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid7.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid7.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGridindex.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGridindex.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid9.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid9.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid10.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid10.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;

            //ultraGrid11.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //ultraGrid11.DisplayLayout.Bands[0].Columns[HourNumber.ToString()].Header.Appearance.ForeColor = Color.Red;



        }
        public StringBuilder txtSqlList(string cdatetime, string typeid)
        {
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT [shopName],[DateHour],[HouNumber] into #KeyTableList FROM [dbo].[DPListNumber] where DItemdate='" + cdatetime + "' and typeid='" + typeid + "'");
            Sqll.Append("SELECT * FROM #KeyTableList");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.DateHour/*需要行转列的列*/ IN ([0],[23],[22],[21],[20],[19],[18],[17],[16],[15],[14],[13],[12],[11],[10],[9],[8],[7],[6],[5],[4],[3],[2],[1]/*列的值*/)");
            Sqll.Append(") AS T"); 
            Sqll.Append(" drop table #KeyTableList");
            return Sqll;
        }

        public StringBuilder txtSqlALLList(string cdatetime)
        {
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT [shopName],[typeid],[HouNumber] into #KeyTableallList FROM [dbo].[DPAllListNumber] where DItemdate='" + cdatetime + "'");
            Sqll.Append("SELECT * FROM #KeyTableallList");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.typeid/*需要行转列的列*/ IN ([手淘搜索],[直通车],[手淘首页],[我的淘宝],[购物车],[淘内免费其他],[手淘问大家],[猫客搜索],[淘宝客]/*列的值*/)");
            Sqll.Append(") AS T");
            Sqll.Append(" drop table #KeyTableallList");

            return Sqll;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                PayList(); Listgetai();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int HourNumber = DateTime.Now.Hour;
           int UHour = HourNumber - 1;
            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                CcateId = "50012100";
                
                string Sqldel = "update DPListNumber set DateHour ="+ UHour + " where shopname='" + CshopName + "' and DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                Ms.ExeSQLNonQuery(Sqldel);
            }
         
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                this.timer1.Enabled = true;
                //Listgetai();全部
                //getai();

                PayList(); Listgetai();
           
           
        }
       /// <summary>
       /// 流量汇总
       /// </summary>
        public void getallList()
        {
            int HourNumber = DateTime.Now.Hour;
            DataTable shoptable = new DataTable();
            string Sqlshop = "SELECT [ItemID] ,[shopname],[uvIndex] ,[indexdate]  FROM [Dp_shopindex] where indexdate='"+ CDateTime + "'";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];

            string Sqldels = "delete from DPrivalItem where getdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldels);

            foreach (DataRow keydr in shoptable.Rows)
            {
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreIndexes.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                //PostServer.GetHTTPTaobao(strpayRateIndex);

                //string txpayRateIndex = PostServer.GetHtml;

                PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                string txpayRateIndex = PostServer.GetHtml;

                JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string strJson = EJson["data"].ToString();
                Etrace EtrJson = new Etrace();
                string ToJson = EtrJson.stringJson(strJson);

                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);

                decimal cartHits = 0;
                decimal cltHits = 0;
                decimal payItemCnt = 0;
                decimal payRateIndex = 0;
                decimal seIpvUvHits = 0;
                decimal tradeIndex = 0;
                decimal uvIndex = 0;
                string itemid = "2342323423";
                string shopName = "景宏";

                cartHits = decimal.Parse(json["data"]["rivalItem1"]["cartHits"]["value"].ToString());
                cltHits = decimal.Parse(json["data"]["rivalItem1"]["cltHits"]["value"].ToString());
                payItemCnt = decimal.Parse(json["data"]["rivalItem1"]["payItemCnt"]["value"].ToString());
                payRateIndex = decimal.Parse(json["data"]["rivalItem1"]["payRateIndex"]["value"].ToString());
                seIpvUvHits = decimal.Parse(json["data"]["rivalItem1"]["seIpvUvHits"]["value"].ToString());
                tradeIndex = decimal.Parse(json["data"]["rivalItem1"]["tradeIndex"]["value"].ToString());
                uvIndex = decimal.Parse(json["data"]["rivalItem1"]["uvIndex"]["value"].ToString());
                itemid = CItemid;
                shopName = CshopName;

                string Sqltxt = "INSERT INTO [DPrivalItem] ([cartHits] ,[cltHits] ,[payItemCnt],[payRateIndex] ,[seIpvUvHits] ,[tradeIndex] ,[uvIndex] ,[itemid] ,[shopName],[getdate])VALUES (" + cartHits + "," + cltHits + "," + payItemCnt + "," + payRateIndex + "," + seIpvUvHits + "," + tradeIndex + "," + uvIndex + ",'" + itemid + "','" + shopName + "','" + CDateTime + "')";
                Ms.ExeSQLNonQuery(Sqltxt);
            }
            //string sqlU = "Select payItemCnt,itemid,shopName from DPrivalItem where getdate='" + CDateTime + "'";
            //ultraGrid1.DataSource = Ms.runSQLDataSet(sqlU, "ss");

           
        }
        /// <summary>
        /// 成交大盘指数
        /// </summary>
        public void Timegetai()
        {
            int HourNumber = DateTime.Now.Hour;

            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            foreach (DataRow keydr in shoptable.Rows)
            {
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                //  string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv&_=1535778429590&token=";
                // Thread.Sleep(10000);
                //PostServer.GetHTTPTaobao(strpayRateIndex);
                //string txpayRateIndex = PostServer.GetHtml;

                PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
                string txpayRateIndex = PostServer.GetHtml;

                JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string strJson = EJson["data"].ToString();
                Etrace EtrJson = new Etrace();
                string ToJson = EtrJson.stringJson(strJson);

                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
                for (int j = 0; j <= 6; j++)
                {
                    //支付转化指数
                    string typeIDstr = "";
                    string jsonpayRateIndex = "";

                    if (j == 0)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["cartHits"].ToString();
                        typeIDstr = "cartHits";
                    }
                    if (j == 1)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["cltHits"].ToString();
                        typeIDstr = "cltHits";
                    }
                    if (j == 2)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["payItemCnt"].ToString();
                        typeIDstr = "payItemCnt";
                    }
                    if (j == 3)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["payRateIndex"].ToString();
                        typeIDstr = "payRateIndex";
                    }
                    if (j == 4)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["seIpvUvHits"].ToString();
                        typeIDstr = "seIpvUvHits";
                    }
                    if (j == 5)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["tradeIndex"].ToString();
                        typeIDstr = "tradeIndex";
                    }
                    if (j == 6)
                    {
                        jsonpayRateIndex = json["data"]["rivalItem1"]["uvIndex"].ToString();
                        typeIDstr = "uvIndex";
                    }

                    //ShowInfo(jsonpayRateIndex);
                    JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                    for (int i = 0; i < payRateIndexJArray.Count; i++)
                    {
                        if (i== HourNumber)
                        {
                            //删除
                            string Sqldel = " delete from Dpnumber where ItemID='"+ CItemid + "' and dateHour="+ HourNumber + " and typeid='"+ typeIDstr + "'";
                            Ms.ExeSQLNonQuery(Sqldel);
                            decimal NumberPayRate = 0;
                            if (payRateIndexJArray[i].ToString() != "")
                            {
                                NumberPayRate = Math.Ceiling(decimal.Parse(payRateIndexJArray[i].ToString()));
                            }
                            else
                            {
                                NumberPayRate = 0;
                            }
                            string Sql = "INSERT INTO [DPNumber]([shopName],[DateHour],[HouNumber],[typeID],[ItemID],[DItemdate])VALUES('" + CshopName + "'," + i + "," + NumberPayRate + ",'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "')";
                            Ms.ExeSQLNonQuery(Sql);
                        }
                       
                    }
                }
            }


            this.ultraGridcnt.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payItemCnt").ToString(), "ss").Tables[0];
            //this.ultraGrid2.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "uvIndex").ToString(), "ss").Tables[0];
            //this.ultraGrid5.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "cartHits").ToString(), "ss").Tables[0];
            //this.ultraGrid3.DataSource = Ms.runSQLDataSet(txtSql(CDateTime, "payRateIndex").ToString(), "ss").Tables[0];
            ultraGridcnt.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid2.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid5.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
            //ultraGrid3.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;

        }

        /// <summary>
        /// 清除数据重新监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string Sqldel = "delete from DPListNumber where  DItemdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldel);

            //int HourNumber = DateTime.Now.Hour;

            //DataTable shoptable = new DataTable();
            //string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            //shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
            //foreach (DataRow keydr in shoptable.Rows)
            //{
            //    PostServer.Getcookie = FPPcokk.ToString();
            //    string CcateId, CItemid, CshopName;
            //    CItemid = keydr["itemid"].ToString();
            //    CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
            //    CcateId = "50012100";
            //    string Sqldel = "delete from DPListNumber where shopname='" + CshopName + "' and DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
            //    Ms.ExeSQLNonQuery(Sqldel);
            //}
        }
        /// <summary>
        /// 大盘启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //getallList();
        }
        public void Getshopindex()
        {
             string KCDateTime =  DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = "https://sycm.taobao.com/mc/mq/mkt/rank/item/hotsearch.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=100&page=1&order=desc&orderBy=uvIndex&cateId=350404&device=0&sellerType=-1&indexCode=cateRankId%2CuvIndex%2CseIpvUvHits%2CtradeIndex&_=1536239539735&token=";
            //PostServer.GetHTTPTaobao(strpayRateIndex);
            //string txpayRateIndex = PostServer.GetHtml;

            PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
            string txpayRateIndex = PostServer.GetHtml;

            JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string strJson = EJson["data"].ToString();
            Etrace EtrJson = new Etrace();
            string ToJson = EtrJson.stringJson(strJson);


            JObject json = (JObject)JsonConvert.DeserializeObject(strJson);
            string zone = json["data"].ToString();
            // ShowInfo(zone);
            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string citemid, ctitle, cuvIndex;
                citemid = results[i]["item"]["itemId"].ToString();
                ctitle = results[i]["shop"]["title"].ToString();
                cuvIndex = results[i]["uvIndex"]["value"].ToString();

                string Sql = "INSERT INTO [Dp_shopindex]([ItemID],[shopname],[uvIndex],[indexdate])VALUES('" + citemid + "','" + ctitle + "'," + Math.Ceiling(decimal.Parse(cuvIndex)) + ",'" + CDateTime + "')";
                Ms.ExeSQLNonQuery(Sql);
            }
        }

        public void GetshopindexB()
        {
            string KCDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = "https://sycm.taobao.com/mc/mq/mkt/rank/item/hotsale.json?dateRange="+ KCDateTime + "%7C"+ KCDateTime + "&dateType=day&pageSize=50&page=1&order=desc&orderBy=tradeIndex&cateId=350404&device=0&sellerType=-1&indexCode=cateRankId%2CtradeIndex%2CtradeGrowthRange%2CpayRateIndex&_=1536240356326&token=";
        ///"https://sycm.taobao.com/mc/mq/mkt/rank/item/hotsale.json?dateRange=2018-09-05%7C2018-09-05&dateType=day&pageSize=100&page=1&order=desc&orderBy=tradeIndex&cateId=350404&device=0&sellerType=-1&indexCode=cateRankId%2CtradeIndex%2CtradeGrowthRange%2CpayRateIndex&_=1536242393521&token="
            //PostServer.GetHTTPTaobao(strpayRateIndex);
            //string txpayRateIndex = PostServer.GetHtml;

            PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
            string txpayRateIndex = PostServer.GetHtml;

            JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string strJson = EJson["data"].ToString();
            Etrace EtrJson = new Etrace();
            string ToJson = EtrJson.stringJson(strJson);

            JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
            string zone = json["data"].ToString();
            // ShowInfo(zone);
            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string citemid,cpayRateIndex;
                cpayRateIndex = results[i]["payRateIndex"]["value"].ToString();
                citemid = results[i]["item"]["itemId"].ToString();
                string Sql = "INSERT INTO [Dp_shopindexB]([ItemID],[payRateIndex],[indexdate])VALUES('" + citemid + "'," + Math.Ceiling(decimal.Parse(cpayRateIndex)) + ",'" + CDateTime + "')";
                Ms.ExeSQLNonQuery(Sql);
            }
        }


        public void GetshopCar()
        {
            string KCDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = "https://sycm.taobao.com/mc/mq/mkt/rank/item/hotpurpose.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=50&page=1&order=desc&orderBy=cartHits&cateId=350404&device=0&sellerType=-1&indexCode=cateRankId%2CcltHits%2CcartHits%2CtradeIndex&_=1536297303197&token=";
            //PostServer.GetHTTPTaobao(strpayRateIndex);
            //string txpayRateIndex = PostServer.GetHtml;


            PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid);
            string txpayRateIndex = PostServer.GetHtml;

            JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string strJson = EJson["data"].ToString();
            Etrace EtrJson = new Etrace();
            string ToJson = EtrJson.stringJson(strJson);

            JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
            string zone = json["data"].ToString();
            // ShowInfo(zone);
            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string citemid, ctitle, cuvIndex;
                citemid = results[i]["item"]["itemId"].ToString();
                ctitle = results[i]["shop"]["title"].ToString();
                cuvIndex = results[i]["cltHits"]["value"].ToString();

                string Sql = "INSERT INTO [Dp_shopindex]([ItemID],[shopname],[uvIndex],[indexdate])VALUES('" + citemid + "','" + ctitle + "'," + Math.Ceiling(decimal.Parse(cuvIndex)) + ",'" + CDateTime + "')";
                Ms.ExeSQLNonQuery(Sql);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           /// GetshopCar();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string DayName = "监控成交" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls";
            string fileName = "D:\\行情\\" + DayName;
            this.ultraGridExcelExporter1.Export(this.ultraGridcnt, fileName);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string DayName = "直通车" + DateTime.Now.ToString("yyyy-MM-dd").Replace("/", "-") + ".xls";
            string fileName = "D:\\行情\\" + DayName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid4, fileName);
        }

        private void Dztc_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            PayList(); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Listgetai();
        }
    }
}
