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
    public partial class onDP : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string CcateId, CTit, CItemid, CDateTime;
        DateTime getdatTime;
        public onDP(StringBuilder FPPcok, string cateId, string shopTit, string ItemID)
        {
            InitializeComponent();
            FPPcokk = FPPcok;
            CcateId = cateId;
            CTit = shopTit;
            CItemid = ItemID;
            CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            getdatTime = DateTime.Now;
            this.Text = CDateTime+CTit + CItemid;
        }
        public onDP()
        { InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {
            NowKeyWordsgetai();
            getUVList();
            PayList();
            string  BegDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string shopNameItemd = CTit + CItemid;

            DelUVTom(shopNameItemd);
            getUVList("uv", BegDate, CcateId, CItemid, shopNameItemd);
            getUVList("payByrCntIndex", BegDate, CcateId, CItemid, shopNameItemd);
            getKeywordList("uv", BegDate, CcateId, CItemid, shopNameItemd);
            getKeywordList("tradeIndex", BegDate, CcateId, CItemid, shopNameItemd);
            DataBinderTom(shopNameItemd);
        }

        private void onDP_Load(object sender, EventArgs e)
        {
           
          
        }
        #region 今天数据

       
        /// <summary>
        /// 临时表
        /// </summary>
        /// <returns></returns>
        public DataTable CLDataTable(string shopName,string Number)
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add(shopName, typeof(string));//时间
            dt.Columns.Add(Number, typeof(Int32));//点击率
            return dt;
        }
        /// <summary>
        /// 临时表2支付件
        /// </summary>
        /// <param name="shopName"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public DataTable CLPayDataTable(string shopName, string Number)
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add(shopName, typeof(Int32));//时间
            dt.Columns.Add(Number, typeof(Int32));//点击率
            return dt;
        }
        /// <summary>
        /// 支付件数
        /// </summary>
        public void PayList()
        {
            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreTrend.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
            PostServer.GetHTTPTaobao(strpayRateIndex);
            string txpayRateIndex = PostServer.GetHtml;
            JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string typeIDstr = "";
            string jsonpayRateIndex = "";
            jsonpayRateIndex = json["data"]["data"]["rivalItem1"]["payItemCnt"].ToString();
            typeIDstr = "payItemCnt";

            JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);

            DataTable kew = CLPayDataTable("时间","成交件数");
            DataRow dr = null;

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
                dr = kew.NewRow();
                dr["时间"] = i.ToString();
                dr["成交件数"] = NumberPayRate;
                kew.Rows.Add(dr);

            }
            ultraGrid4.DataSource = kew;
        }
        /// <summary>
        /// 流量结构
        /// </summary>
        public void getUVList()
        {
            int HourNumber = DateTime.Now.Hour;
            PostServer.Getcookie = FPPcokk.ToString();          
            string KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;          
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["data"]["data"].ToString();
            JArray results = JArray.Parse(zone);
            DataTable kew = CLDataTable("流量来源","访客");
            DataRow dr = null;
            for (int i = 0; i < results.Count; i++)
            {
                dr = kew.NewRow();
                string keyshopName = results[i]["pageName"]["value"].ToString();
                dr["流量来源"] = keyshopName;
                dr["访客"] = int.Parse(results[i]["uv"]["value"].ToString());
                kew.Rows.Add(dr);
            }
            ultraGrid2.DataSource = kew;
        }
        /// <summary>
        /// 当日关建字流量
        /// </summary>
        public void NowKeyWordsgetai()
        {
            int HourNumber = DateTime.Now.Hour;           
            PostServer.Getcookie = FPPcokk.ToString();
            string KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveKeywords.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=today&pageSize=20&page=1&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;         
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["data"]["data"].ToString();
            DataTable kew = CLDataTable("关键字","访客");
            JArray results = JArray.Parse(zone);
            DataRow dr = null;
            for (int i = 0; i < results.Count; i++)
            {
                dr = kew.NewRow();
                string keyshopName= results[i]["keyword"]["value"].ToString();
                dr["关键字"] = keyshopName;
                dr["访客"] = int.Parse(results[i]["uv"]["value"].ToString());
                kew.Rows.Add(dr);
            }
            ultraGridcnt.DataSource = kew;
        }
        #endregion
        #region 昨天数据
        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="IshopItemID"></param>
        public void DelUVTom(string IshopItemID)
        {
            string delSql1 = "delete from hqUVList where ItemID='" + IshopItemID + "'";
            string delSql2 = "delete from hqUVListCUS where ItemID='" + IshopItemID + "'";
            string delSql3 = "delete from hqKeywordList where ItemID='" + IshopItemID + "'";
            string delSql4 = "delete from hqKeywordListCUS where ItemID='" + IshopItemID + "'";
            Ms.ExeSQLNonQuery(delSql1);
            Ms.ExeSQLNonQuery(delSql2);
            Ms.ExeSQLNonQuery(delSql3);
            Ms.ExeSQLNonQuery(delSql4);
        }
       /// <summary>
       /// 加载数据
       /// </summary>
       /// <param name="IshopItemID"></param>
        public void DataBinderTom(string IshopItemID)
        {
            string sqlU = "SELECT  [DItemdate],[shopName],[访客数],[买家数],[指数],[ItemID]FROM [DPListCUST] where ItemID='" + IshopItemID + "' order by [DItemdate] desc";
            ultraGrid3.DataSource = Ms.runSQLDataSet(sqlU, "ss").Tables[0];

            string sqla = "SELECT * from DPhqKeywordLIstCUST where ItemID='" + IshopItemID + "'";
            DataTable getKeyword= Ms.runSQLDataSet(sqla, "ss").Tables[0];
            getKeyword.Columns.Remove("ItemID");
            getKeyword.Columns.Remove("指数");
            ultraGrid1.DataSource = getKeyword;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlU = "SELECT  [DItemdate],[shopName],[访客数],[买家数],[指数],[ItemID]FROM [DPListCUST] where ItemID='查询结果539423460162' order by [DItemdate] desc";
            ultraGrid3.DataSource = Ms.runSQLDataSet(sqlU, "ss").Tables[0];

            string sqla = "SELECT [日期],[关建字],[访客数] as A ,[买家数] as b,[指数],[ItemID] from DPhqKeywordLIstCUST where ItemID='查询结果539423460162'";
            DataTable getKeyword = Ms.runSQLDataSet(sqla, "ss").Tables[0];
          
            ultraGrid1.DataSource = getKeyword;
        }

        /// <summary>
        /// 昨天流量来源
        /// </summary>
        /// <param name="Key">访客</param>
        /// <param name="CDateTime">日期</param>
        /// <param name="CcateId">CID</param>
        /// <param name="CItemid">CItemid</param>
        /// <param name="CshopNameItemd">店铺和ID</param>
        public void getUVList(string Key, string CDateTime, string CcateId, string CItemid, string CshopNameItemd)
        {
           
            int HourNumber = 0;
            PostServer.Getcookie = FPPcokk.ToString();
            string KKurl = "";
            if (Key == "uv")
            {
                KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=day&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=" + Key + "&orderBy=" + Key + "&order=desc&_=1535785900902&token=";
            }
            if (Key == "payByrCntIndex")
            {
                KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=day&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=" + Key + "&orderBy=" + Key + "&order=desc&_=1535785900902&token=";
            }

            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
            if (gHtml.IndexOf("出错") > 0)
            {
              
            }
            else
            {
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = "";
                if (Key == "uv")
                {
                    zone = json["data"].ToString();
                }
                if (Key == "payByrCntIndex")
                {
                    zone = json["data"].ToString();
                }
                JArray results = JArray.Parse(zone);

                for (int i = 0; i < results.Count; i++)
                {
                    string shopNameID = "";
                    int Keynumber = 50;
                    string Sql = "";

                    if (Key == "uv")
                    {
                        shopNameID = results[i]["pageName"]["value"].ToString();
                        Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                        Sql = "INSERT INTO [hqUVList]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                       
                    }
                    if (Key == "payByrCntIndex")
                    {

                        shopNameID = results[i]["pageName"]["value"].ToString();
                        decimal aa = decimal.Parse(results[i]["rivalItem1PayByrCntIndex"]["value"].ToString());
                        decimal bb = Math.Round(aa, 0);
                        int CC = int.Parse(bb.ToString());
                        Keynumber = int.Parse(bb.ToString());
                        int Paycn = poweint(Keynumber);
                        Sql = "INSERT INTO [hqUVListCUS]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + CC + "," + Paycn + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    }
                 
                    Ms.ExeSQLNonQuery(Sql);

                }
            }

        }
        public void getKeywordList(string Key, string CDateTime, string CcateId, string CItemid, string CshopNameItemd)
        {
           
            int HourNumber = 0;
            PostServer.Getcookie = FPPcokk.ToString();
            string KKurl = "";
            if (Key == "uv")
            {
                KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getKeywords.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=day&pageSize=20&page=1&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=flow&indexCode=uv";
            }
            if (Key == "tradeIndex")
            {
                KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getKeywords.json?dateRange=" + CDateTime + "%7C" + CDateTime + "&dateType=day&pageSize=20&page=1&device=2&sellerType=0&cateId=" + CcateId + "&itemId=" + CItemid + "&topType=trade&indexCode=tradeIndex";
            }

            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
            if (gHtml.IndexOf("出错") > 0)
            {
               
            }
            else
            {
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = "";
                if (Key == "uv")
                {
                    zone = json["data"].ToString();
                }
                if (Key == "tradeIndex")
                {
                    zone = json["data"].ToString();
                }
                JArray results = JArray.Parse(zone);

                for (int i = 0; i < results.Count; i++)
                {
                    string shopNameID = "";
                    int Keynumber = 0;
                    string Sql = "";
                    if (Key == "uv")
                    {
                        shopNameID = results[i]["keyword"]["value"].ToString(); ;
                        Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                        Sql = "INSERT INTO [hqKeywordList]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    }
                    if (Key == "tradeIndex")
                    {

                        shopNameID = results[i]["keyword"]["value"].ToString();
                        decimal aa = decimal.Parse(results[i]["tradeIndex"]["value"].ToString());
                        decimal bb = Math.Round(aa, 0);
                        int CC = int.Parse(bb.ToString());
                        Keynumber = int.Parse(bb.ToString());
                        int Paycn = poweint(Keynumber);
                        Sql = "INSERT INTO [hqKeywordListCUS]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + CC + "," + Paycn + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    }
                    Ms.ExeSQLNonQuery(Sql);

                }
            }

        }
       /// <summary>
       /// 指数转化
       /// </summary>
       /// <param name="uvpay">指数</param>
       /// <returns></returns>
        public int poweint(int uvpay)
        {
            // x <= 630  y = (0.409x ^ 1.5201)/ 100
            //630 < x <= 1195 y = (0.2484x ^ 1.598)/ 100
            //1195 <= x <= 2050   y = (0.2005x ^ 1.6283)/ 100
            //2050 <= x <= 3130   y = (0.1653x ^ 1.6537)/ 100
            //3130 < x <= 4520    y = (0.1412x ^ 1.6732)/ 100
            //4520 < x <= 6030    y = (0.1253x ^ 1.6875)/ 100
            //6030 < x <= 8050    y = (0.1133x ^ 1.699)/ 100

            double x = 0.409;
            double y = 1.5201;
            if (uvpay <= 630)
            {
                x = 0.409;
                y = 1.5201;
            }
            if (630 < uvpay && uvpay <= 1195)
            {
                x = 0.2484;
                y = 1.598;
            }
            if (1195 < uvpay && uvpay <= 2050)
            {
                x = 0.2005;
                y = 1.6283;
            }
            if (2050 < uvpay && uvpay <= 3130)
            {
                x = 0.1653;
                y = 1.6537;
            }
            if (3130 < uvpay && uvpay <= 4520)
            {
                x = 0.1412;
                y = 1.6732;
            }
            if (4520 < uvpay && uvpay <= 6030)
            {
                x = 0.1253;
                y = 1.6875;
            }
            if (6030 < uvpay && uvpay <= 8050)
            {
                x = 0.1133;
                y = 1.699;
            }

            double result = System.Math.Pow(uvpay, y);
            double result1 = result * x / 100;

            string intPay = Math.Round(result1).ToString();
            return int.Parse(intPay);
        }
        #endregion
    }
}
