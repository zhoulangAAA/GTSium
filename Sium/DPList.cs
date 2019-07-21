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
    public partial class DPList : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        //直通车
        public string Url1 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=22.2&pPageId=22&cateId=50012100";
        //手淘搜索
        public string Url2 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=23.s1150&pPageId=23&cateId=50012100";
        //手淘首页
        public string Url3 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=23.s1140&pPageId=23&cateId=50012100";
        //购物车
        public string Url4 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=21.3&pPageId=21&cateId=50012100";
        //我的淘宝
        public string Url5 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=21.1&pPageId=21&cateId=50012100";
        //淘宝客
        public string Url6 = "https://sycm.taobao.com/mc/rivalItem/analysis/getSourceTrend.json?dateType=day&indexCode=uv&device=2&pageId=22.1&pPageId=22&cateId=50012100";
        public string CDateTime,GetUrl1, GetUrl2, GetUrl3, GetUrl4, GetUrl5, GetUrl6;
        public string GetItemid;
        public DPList(StringBuilder cok,string shopName,string Itemid, string cateId)
        {
            InitializeComponent();
            GetItemid = Itemid;
            CDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            FPPcokk = cok;
            GetUrl1 = "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            this.Text = shopName;
            //GetUrl1 = Url1 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            //GetUrl2 = Url2 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            //GetUrl3 = Url3 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            //GetUrl4 = Url4 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            //GetUrl5 = Url5 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;
            //GetUrl6 = Url6 + "&dateRange=" + CDateTime + "%7C" + CDateTime + "&rivalItem1Id=" + Itemid;

        }
        public void PageListData()
        {
            //DataTable GE1 = PayList("手淘搜索", Url2+ GetUrl1);
            //DataTable GE2 = PayList("直通车", Url1+ GetUrl1);
          

           
            //DataView dataView = PayList("手淘搜索", Url2 + GetUrl1).DefaultView;
            //dataView.Sort = "时间 desc";
            //ultraGridcnt.DataSource = dataView.Table;

            ultraGridcnt.DataSource = PayList("手淘搜索", Url2 + GetUrl1);
            ultraGridcnt.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


            ultraGrid2.DataSource = PayList("直通车", Url1 + GetUrl1);
            ultraGrid2.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;

            ultraGrid4.DataSource = PayList("手淘首页", Url3 + GetUrl1);
            ultraGrid4.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


            ultraGrid5.DataSource = PayList("我的淘宝", Url5 + GetUrl1);
            ultraGrid5.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


            ultraGrid3.DataSource = PayList("购物车", Url4 + GetUrl1);
            ultraGrid3.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;

            ultraGrid1.DataSource = PayList("淘宝客", Url6 + GetUrl1);
            ultraGrid1.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


        }
        public DataTable  PayList(string UName,string UrlName)
        {
            PostServer.Getcookie = FPPcokk.ToString();
            string strpayRateIndex = UrlName;
            PostServer.GetHTTPTaobao(strpayRateIndex);
            string txpayRateIndex = PostServer.GetHtml;

            //PostServer.GetHTTPTaobaoTID(strpayRateIndex, TID);

            //string gHtml = PostServer.GetHtml;
            //JObject EJson = (JObject)JsonConvert.DeserializeObject(gHtml);
            //string strJson = EJson["data"].ToString();
            //Etrace EtrJson = new Etrace();
            //string ToJson = EtrJson.stringJson(strJson);

            JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string typeIDstr = "";
            string jsonpayRateIndex = "";
            string jsonpayRateIndexUA = "";

            jsonpayRateIndex = json["data"]["rivalItem1PayByrCntIndex"].ToString();
            jsonpayRateIndexUA = json["data"]["rivalItem1Uv"].ToString();
            // DataTable dts = JsonConvert.DeserializeObject<DataTable>(jsonpayRateIndex);


            JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
            JArray payRateIndexJArrayUA = JArray.Parse(jsonpayRateIndexUA);

            DataTable kew = NewPayDataTable("时间", "类别","访客数", "成交","转化率");
            DataRow dr = null;

            for (int i = 0; i < payRateIndexJArray.Count; i++)
            {
                //访客数
                decimal NumberPayRateUV = 0;
                if (payRateIndexJArrayUA[i].ToString() != "")
                {
                    NumberPayRateUV = decimal.Parse(payRateIndexJArrayUA[i].ToString());
                }
                else
                {
                    NumberPayRateUV = 0;
                }

                //买件家
                decimal NumberPayRate = 0;
                if (payRateIndexJArray[i].ToString() != "")
                {
                    NumberPayRate = Math.Ceiling(decimal.Parse(payRateIndexJArray[i].ToString()));
                }
                else
                {
                    NumberPayRate = 0;
                }
                decimal bb = Math.Round(NumberPayRate, 0);
                int PP = int.Parse(bb.ToString());
                int Paycn = poweint(PP);
                string FaPayUa = "";
                if (Paycn>0)
                {
                    decimal PayUA = Paycn / NumberPayRateUV * 100;
                    FaPayUa = Math.Round(PayUA, 2).ToString();
                }
                else
                {
                    FaPayUa = "0";
                }
               

                dr = kew.NewRow();
                dr["时间"] = DateTime.Now.AddDays(-30+i).ToString("yyyy-MM-dd");
                dr["类别"] = UName;
                dr["访客数"] = NumberPayRateUV;
                dr["成交"] = Paycn;
                dr["转化率"] = FaPayUa;
                kew.Rows.Add(dr);

            }
            return kew;
        }
        /// <summary>
        /// 直通车
        /// </summary>
        /// <param name="shopName"></param>
        /// <param name="Number"></param>
        /// <param name="PayNumber"></param>
        /// <returns></returns>
        public DataTable NewPayDataTable(string shopName, string KaName,string UANumber,string Number,string  PayNumber)
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add(shopName, typeof(DateTime));//时间
            dt.Columns.Add(KaName, typeof(string));//类别
            dt.Columns.Add(UANumber, typeof(decimal));//访客
            dt.Columns.Add(Number, typeof(decimal));//买家数
            dt.Columns.Add(PayNumber, typeof(decimal));//转化率
            return dt;
        }

        private void DPList_Load(object sender, EventArgs e)
        {
            PageListData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string GetDateTime = "";
            GetDateTime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string GetUrlBut = "&dateRange=" + GetDateTime + "%7C" + GetDateTime + "&rivalItem1Id=" + GetItemid;

            DataView dataView = PayList("手淘搜索", Url2 + GetUrlBut).DefaultView;
            dataView.Sort = "时间 desc";
            ultraGridcnt.DataSource = dataView.Table;


            ultraGrid2.DataSource = PayList("直通车", Url1 + GetUrlBut);
            ultraGrid2.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;

            ultraGrid4.DataSource = PayList("手淘首页", Url3 + GetUrlBut);
            ultraGrid4.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


            ultraGrid5.DataSource = PayList("我的淘宝", Url5 + GetUrlBut);
            ultraGrid5.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;


            ultraGrid3.DataSource = PayList("购物车", Url4 + GetUrlBut);
            ultraGrid3.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;

            ultraGrid1.DataSource = PayList("淘宝客", Url6 + GetUrlBut);
            ultraGrid1.DisplayLayout.Bands[0].Columns["时间"].SortIndicator = SortIndicator.Descending;

        }

        public int poweint(int uvpay)
        {
            
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
    }
}
