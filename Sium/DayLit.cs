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
    public partial class DayLit : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string CDateTime;
        string CcateId, propIdStr, propValueIdStr, propValueIdStr1, propValueIdStr2,TTid;
        public DayLit(StringBuilder FPPcok,string TID)
        {
            InitializeComponent();
            FPPcokk = FPPcok;
            CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            CcateId = "50008553";
            propIdStr = "168952055";
            propValueIdStr = "60077";
            propValueIdStr1 = "9695512";
            propValueIdStr2 = "6672878";
            TTid = TID;
        }

        /// <summary>
        /// 大盘行情指数
        /// </summary>
        public void getallList()
        {
            int HourNumber = DateTime.Now.Hour;
            DataTable shoptable = new DataTable();
            string Sqlshop = "SELECT distinct top 70 [ItemID] ,[shopname],[uvIndex] ,[indexdate]  FROM [Dp_shopindex] where indexdate='" + CDateTime + "' order by uvIndex desc";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];

            string Sqldels = "delete from DPrivalItem where getdate='" + CDateTime + "'";
            Ms.ExeSQLNonQuery(Sqldels);

            string SqlPE = "delete from DayDPAllListNumber where  DItemdate='" + CDateTime + "' and daytypeid=" + 0 + "";
            Ms.ExeSQLNonQuery(SqlPE);
            foreach (DataRow keydr in shoptable.Rows)
            {
                

               
                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["shopname"].ToString();
                CcateId = "50012100";
                try
                {
                    string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreIndexes.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                    PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid, "https://sycm.taobao.com/mc/ci/item/analysis?");
                   // PostServer.GetHTTPTaobao(strpayRateIndex);

                   

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
                  

                string SqlB = "INSERT INTO [DayDPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate],[daytypeid])VALUES('" + CItemid+ shopName + "'," + payItemCnt + ",'今日','" + itemid + "','" + CDateTime + "'," + 0+ ")";
                Ms.ExeSQLNonQuery(SqlB);

                string SqlC = "INSERT INTO [DayDPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate],[daytypeid])VALUES('" + CItemid+shopName + "'," + uvIndex + ",'流量指数','" + itemid + "','" + CDateTime + "'," + 0 + ")";
                Ms.ExeSQLNonQuery(SqlC);

                string SqlD = "INSERT INTO [DayDPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate],[daytypeid])VALUES('" + CItemid+shopName + "'," + cartHits + ",'加购人气','" + itemid + "','" + CDateTime + "'," + 0 + ")";
                Ms.ExeSQLNonQuery(SqlD);
                }
                catch (Exception)
                {

                    label2.Text = CItemid + "-";
                    //MessageBox.Show(CItemid);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            getallList();
            DayList(0);
            Gridcoure();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            string KCDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            string SqlDel = "delete from [Dp_shopindex] where  indexdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            Ms.ExeSQLNonQuery(SqlDel);

            string SqlDelList = "delete from [DayDPAllListNumber] where  DItemdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            Ms.ExeSQLNonQuery(SqlDelList);

            #region 统一读取
            SQLServer LinkServer = new SQLServer("SqlDSN");
            string SqlLink = "SELECT[rulName],[shopNametype],[regName] FROM [Dp_LinkList] where shopNametype = '" + System.Configuration.ConfigurationManager.AppSettings["ESysName"] + "'";
            DataTable GetlinkTable = LinkServer.runSQLDataSet(SqlLink, "s").Tables[0];

            string LinkList = "";
            string Reflinklist = "";
            for (int x = 0; x < GetlinkTable.Rows.Count; x++)
            {
                LinkList = GetlinkTable.Rows[x]["rulName"].ToString() + "dateRange=" + KCDateTime + "|" + KCDateTime;
                Reflinklist = GetlinkTable.Rows[x]["regName"].ToString() + "dateRange=" + KCDateTime + "|" + KCDateTime;
                GetshopCar(LinkList, Reflinklist);
                Thread.Sleep(10000);
            }
            #endregion
            string SqlDel2 = "delete from [DayDPAllListNumber] where [ItemID] not in(SELECT TOP 70 [ItemID] FROM [DayDPAllListNumber] where DItemdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'and typeid='昨日' order by HouNumber desc  ) and DItemdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            Ms.ExeSQLNonQuery(SqlDel2);
           
        }


        public void GetshopCar(string URLA,string regURLA)
        {
            string KCDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            PostServer.Getcookie = FPPcokk.ToString();
            PostServer.GetHTTPTaobaoTID(URLA, TTid, regURLA);
            string txpayRateIndex = PostServer.GetHtml;

            JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string strJson = EJson["data"].ToString();
            Etrace EtrJson = new Etrace();
            string ToJson = EtrJson.stringJson(strJson);

            JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);
            string zone = json["data"].ToString();
            JArray results = JArray.Parse(zone);
            for (int i = 0; i < results.Count; i++)
            {
                string citemid, ctitle, cuvIndex, cpicUrl;
                citemid = results[i]["itemId"].ToString();
                ctitle = results[i]["shopName"].ToString();
                cuvIndex = results[i]["payItmCnt"].ToString();
                cpicUrl = "https:" + results[i]["picUrl"].ToString();

                string Sql = "INSERT INTO [Dp_shopindex]([ItemID],[shopname],[uvIndex],[indexdate],[picUrl])VALUES('" + citemid + "','" + ctitle + "'," + Math.Ceiling(decimal.Parse(cuvIndex)) + ",'" + CDateTime + "','" + cpicUrl + "')";
                Ms.ExeSQLNonQuery(Sql);

                string SqlB = "INSERT INTO [DayDPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate],[daytypeid])VALUES('" + citemid + ctitle + "'," + Math.Ceiling(decimal.Parse(cuvIndex)) + ",'昨日','" + citemid + "','" + CDateTime + "'," + 1 + ")";
                Ms.ExeSQLNonQuery(SqlB);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                getallList();
                DayList(0);
                Gridcoure();
            
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            e.Layout.Override.RowSelectorWidth = 30;

            EmbeddableImageRenderer imgEditor = new EmbeddableImageRenderer();

            // Give the images a slim grayish border and align them to be in the middle of the cell.
            imgEditor.BorderShadowColor = Color.FromArgb(255, 128, 128);
            imgEditor.BorderShadowDepth = 2;

            //e.Layout.Bands[0].Columns["图像"].Editor = imgEditor;
            e.Layout.Bands[0].Columns["图像"].CellAppearance.ImageHAlign = HAlign.Center;
            e.Layout.Bands[0].Columns["图像"].CellAppearance.ImageVAlign = VAlign.Middle;
        }

       
     
        #region 色
        public void Gridcoure()
        {
            DataTable shoptable = new DataTable();
            string Sqlshop = "select itemid,shopname,IDshopName from dp_shop";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];

            for (int i = 0; i < this.ultraGridall.Rows.Count; i++)
            {
                foreach (DataRow keydr in shoptable.Rows)
                { 
                       
                    if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains(keydr["itemid"].ToString()))//景宏
                    {
                        this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                    }
                }
            }
               
        }
       
        #endregion

      
        private void button1_Click(object sender, EventArgs e)
        {
            DPindex getDp = new Sium.DPindex(FPPcokk, "50012100", "查询结果", comboBox1.Text, TTid);
            getDp.Show();
           
        }
        public void DayList(int daytype)
        {
            int HourNumber = DateTime.Now.Hour;
            DataTable shoptable = new DataTable();
            string Sqlshop = "SELECT distinct top 70 [ItemID] ,[shopname],[uvIndex] ,[indexdate]  FROM [Dp_shopindex] where indexdate='" + CDateTime + "' order by uvIndex desc";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];

            foreach (DataRow keydr in shoptable.Rows)
            {
                try
                {

                    PostServer.Getcookie = FPPcokk.ToString();
                    string CcateId, CItemid, CshopName;
                    CItemid = keydr["itemid"].ToString();
                   string SSHopNameat= keydr["shopname"].ToString();
                   CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                    CcateId = "50012100";
                string strpayRateIndex = "";
                if (daytype==0)
                {
                    strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc&token=";
                }
                else
                {
                    string Gday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=day&dateRange=" + Gday + "%7C" + Gday + "&indexCode=uv&orderBy=uv&order=desc&token=;";
                }
                PostServer.GetHTTPTaobaoTID(strpayRateIndex, TTid, "https://sycm.taobao.com/mc/ci/item/analysis?");
                string txpayRateIndex = PostServer.GetHtml;

                JObject EJson = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
                string strJson = EJson["data"].ToString();
                Etrace EtrJson = new Etrace();
                string ToJson = EtrJson.stringJson(strJson);

                JObject json = (JObject)JsonConvert.DeserializeObject(ToJson);

                    //支付转化指数
                    string typeIDstr = "";
                    string jsonpayRateIndex = "";
                if (daytype==0)
                {
                    jsonpayRateIndex = json["data"].ToString();
                }
                else
                {
                    jsonpayRateIndex = json["data"].ToString();
                }
                   
                    int NumberPayRate = 0;

                    JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                if (payRateIndexJArray.Count>0)
                {

              
                    for (int i = 0; i <8; i++)
                    {
                        if (payRateIndexJArray.Count > i)
                        {


                            typeIDstr = payRateIndexJArray[i]["pageName"]["value"].ToString();
                            NumberPayRate = int.Parse(payRateIndexJArray[i]["uv"]["value"].ToString());
                            string SqlB = "INSERT INTO [DayDPAllListNumber]([shopName],[HouNumber],[typeID],[ItemID],[DItemdate],[daytypeid])VALUES('" + CshopName + "'," + NumberPayRate + ",'" + typeIDstr + "','" + CItemid + "','" + CDateTime + "'," + daytype + ")";
                            Ms.ExeSQLNonQuery(SqlB);
                        }
                    }
                }
                else
                {
                    //this.textBox1.Text = this.textBox1.Text + CshopName;
                }

            }
                catch (Exception)
            {

                // throw;
            }
        }
            if (daytype == 0)
            {
                this.ultraGridall.DataSource = Ms.runSQLDataSet(txtSqlALLList(CDateTime, daytype).ToString(), "ss").Tables[0];
                ultraGridall.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
                ultraGridall.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
                ultraGridall.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.AliceBlue;
            }
            else
            {
              
            }
         


        }
        public StringBuilder txtSqlALLList(string cdatetime,int dayteypidd)
        {
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT distinct [shopName],[typeid],[HouNumber] into #dayKeyTableallList FROM [dbo].[DayDPAllListNumber] where DItemdate='" + cdatetime + "' ");
            Sqll.Append("SELECT * FROM #dayKeyTableallList");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.typeid/*需要行转列的列*/ IN ([昨日],[今日],[手淘搜索],[直通车],[手淘首页],[我的淘宝],[购物车],[淘内免费其他],[手淘问大家],[猫客搜索],[淘宝客],[流量指数],[加购人气]/*列的值*/)");
            Sqll.Append(") AS T");
            Sqll.Append(" drop table #dayKeyTableallList");
            return Sqll;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HttpPost PostServer = new HttpPost();
            PostServer.Getcookie = FPPcokk.ToString();
            PostServer.GetHTTPTaobaoTID("https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateType=day&pageSize=100&page=1&order=desc&orderBy=payItmCnt&cateId=50017589&deviceType=0&sellerType=-1&propIdStr=5754966&propValueIdStr=126003&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1553498512338&dateRange=2019-05-23|2019-05-23", TTid, "https://sycm.taobao.com/mc/mq/property_insight?activeKey=analyse&cateFlag=2&cateId=50017589&dateType=day&device=0&parentCateId=50012100&sellerType=-1&propertyIds=5754966&propertyValueIds=126003&");
            string txpayRateIndex = PostServer.GetHtml;
            this.textBox1.Text = txpayRateIndex;
        }

        private void DayLit_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = FPPcokk.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text ="sss-----"+ FPPcokk.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DPList getDp = new Sium.DPList(FPPcokk, "查询结果", comboBox1.Text, TTid);
            getDp.Show();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DayList(0);
            //Gridcoure();
           // DayList(1);
        }

        private void ultraGridall_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            e.Layout.Override.RowSelectorWidth = 30;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DayList(1);
        }

        private void ultraGridall_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int i = this.ultraGridall.ActiveRow.Index;
            int b = this.ultraGridall.ActiveCell.Column.Index;
            string IDshopName, ID, Imrul;
            IDshopName = this.ultraGridall.Rows[i].Cells[0].Value.ToString().Trim();
            string sID = System.Text.RegularExpressions.Regex.Replace(IDshopName, @"[^0-9]+", "");
          

           
            if (b == 0)
            {

                DPImages getDpA = new Sium.DPImages(sID, IDshopName);
                getDpA.Show();
            }
            if (b == 1)
            {
                NewListZTC getDp = new Sium.NewListZTC(sID);
                getDp.Show();
            }

            if (b == 2)
            {

                DPindex getDp = new Sium.DPindex(FPPcokk, "50012100", IDshopName, sID,TTid);
                getDp.Show();
            }
            //NewListZTC
            if (b ==3)
            {
                DPList getDp = new Sium.DPList(FPPcokk,IDshopName, sID, TTid);
                getDp.Show();

            }
            if (b == 4)
            {

                NewListZTC getDp = new Sium.NewListZTC(sID);
                getDp.Show();
            }

            //else
            //{

            //    DPindex getDp = new Sium.DPindex(FPPcokk, "50012100", IDshopName, sID);
            //    getDp.Show();
            //}
        }

      
    }
}
