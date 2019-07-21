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
    public partial class dayListpro : Form
    {
        StringBuilder FPPcokk;
        HttpPost PostServer = new HttpPost();
        SQLServer Ms = new SQLServer();
        string CDateTime;
        public dayListpro(StringBuilder FPPcok)
        {
           
            InitializeComponent();
            FPPcokk = FPPcok;
            CDateTime = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            getallList();
            colgrid();
        }
        public void colgrid()
        {
            for (int i = 0; i < this.ultraGrid1.Rows.Count; i++)
            {
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("576169856374"))//长虹跟斗云专卖店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("521366504774"))//景宏
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("539837217405"))//TCL
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("577085262058"))//俊丰电器专营店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("558801364585"))//haier海尔唯途专卖店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("566496670288"))//海尔础睦三祥专卖店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid1.Rows[i].Cells["itemid"].Value.ToString().Contains("578351917178"))//meiling美菱大脸猫专卖店
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
            }

        }
        public StringBuilder txtSqlALLList(string cdatetime, int dayteypidd)
        {
            StringBuilder Sqll = new StringBuilder();
            Sqll.Append("SELECT [shopName],[typeid],[HouNumber] into #dayKeyTableallList FROM [dbo].[DayDPAllListNumber] where DItemdate='" + cdatetime + "' and daytypeid=" + dayteypidd + "");
            Sqll.Append("SELECT * FROM #dayKeyTableallList");
            Sqll.Append(" AS P");
            Sqll.Append(" PIVOT");
            Sqll.Append("(");
            Sqll.Append("SUM(HouNumber/*行转列后 列的值*/) FOR ");
            Sqll.Append("p.typeid/*需要行转列的列*/ IN ([手淘搜索],[直通车],[手淘首页],[我的淘宝],[购物车],[淘内免费其他],[手淘问大家],[猫客搜索],[淘宝客]/*列的值*/)");
            Sqll.Append(") AS T");
            Sqll.Append(" drop table #dayKeyTableallList");
            return Sqll;
        }
        public void Gridcoure()
        {
            for (int i = 0; i < this.ultraGridall.Rows.Count; i++)
            {
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("576169856374"))//长虹跟斗云专卖店
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("521366504774"))//景宏
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("539837217405"))//TCL
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("577085262058"))//俊丰电器专营店
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("558801364585"))//haier海尔唯途专卖店
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("566496670288"))//海尔础睦三祥专卖店
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGridall.Rows[i].Cells["shopName"].Value.ToString().Contains("578351917178"))//meiling美菱大脸猫专卖店
                {
                    this.ultraGridall.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
            }
        }
        public void Gridcoure2()
        {
            for (int i = 0; i < this.ultraGrid2.Rows.Count; i++)
            {
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("576169856374"))//长虹跟斗云专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("521366504774"))//景宏
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("539837217405"))//TCL
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("577085262058"))//俊丰电器专营店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("558801364585"))//haier海尔唯途专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("566496670288"))//海尔础睦三祥专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
                if (this.ultraGrid2.Rows[i].Cells["shopName"].Value.ToString().Contains("578351917178"))//meiling美菱大脸猫专卖店
                {
                    this.ultraGrid2.Rows[i].Appearance.BackColor = Color.SkyBlue;
                }
            }
        }
        public void GetshopCar(string URLA)
        {
            string KCDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            PostServer.Getcookie = FPPcokk.ToString();
            //22m^2


            // string strpayRateIndex = "https://sycm.taobao.com/mc/mq/mkt/rank/item/hotpurpose.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=50&page=1&order=desc&orderBy=cartHits&cateId=350404&device=0&sellerType=-1&indexCode=cateRankId%2CcltHits%2CcartHits%2CtradeIndex&_=1536297303197&token=";
            PostServer.GetHTTPTaobao(URLA);
            string txpayRateIndex = PostServer.GetHtml;
            JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);
            string zone = json["data"]["data"].ToString();
            // ShowInfo(zone);
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
            }
        }
        /// <summary>
        /// 大盘行情指数
        /// </summary>
        public void getallList()
        {
            int HourNumber = DateTime.Now.Hour;
            DataTable shoptable = new DataTable();
            string Sqlshop = "SELECT top 70 [ItemID] ,[shopname],[uvIndex] ,[indexdate]  FROM [Dp_shopindex] where indexdate='" + CDateTime + "' order by uvIndex desc";
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
                try
                {
                    string strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveCoreIndexes.json?dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&_=1535966409385&token=";
                    PostServer.GetHTTPTaobao(strpayRateIndex);

                    string txpayRateIndex = PostServer.GetHtml;
                    JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);

                    decimal cartHits = 0;
                    decimal cltHits = 0;
                    decimal payItemCnt = 0;
                    decimal payRateIndex = 0;
                    decimal seIpvUvHits = 0;
                    decimal tradeIndex = 0;
                    decimal uvIndex = 0;
                    string itemid = "2342323423";
                    string shopName = "景宏";

                    cartHits = decimal.Parse(json["data"]["data"]["rivalItem1"]["cartHits"]["value"].ToString());
                    cltHits = decimal.Parse(json["data"]["data"]["rivalItem1"]["cltHits"]["value"].ToString());
                    payItemCnt = decimal.Parse(json["data"]["data"]["rivalItem1"]["payItemCnt"]["value"].ToString());
                    payRateIndex = decimal.Parse(json["data"]["data"]["rivalItem1"]["payRateIndex"]["value"].ToString());
                    seIpvUvHits = decimal.Parse(json["data"]["data"]["rivalItem1"]["seIpvUvHits"]["value"].ToString());
                    tradeIndex = decimal.Parse(json["data"]["data"]["rivalItem1"]["tradeIndex"]["value"].ToString());
                    uvIndex = decimal.Parse(json["data"]["data"]["rivalItem1"]["uvIndex"]["value"].ToString());
                    itemid = CItemid;
                    shopName = CshopName;

                    string Sqltxt = "INSERT INTO [DPrivalItem] ([cartHits] ,[cltHits] ,[payItemCnt],[payRateIndex] ,[seIpvUvHits] ,[tradeIndex] ,[uvIndex] ,[itemid] ,[shopName],[getdate])VALUES (" + cartHits + "," + cltHits + "," + payItemCnt + "," + payRateIndex + "," + seIpvUvHits + "," + tradeIndex + "," + uvIndex + ",'" + itemid + "','" + shopName + "','" + CDateTime + "')";
                    Ms.ExeSQLNonQuery(Sqltxt);
                }
                catch (Exception)
                {

                    //MessageBox.Show(CItemid);
                }
            }
            string sqlU = "SELECT [payItemCnt] as 今天,[ouvindex] as 昨天,[picUrl] as 图像,[shopName] as 店铺,[cartHits] as 加购人气,[payRateIndex] as 支付转化指数,[seIpvUvHits] as 搜索指数,[tradeIndex] as 交易指数,[uvIndex]as 流量指数, [clthits] as 收藏人气 ,[itemid]FROM [LangSL].[dbo].[DPListTOp50] where [getdate]='" + CDateTime + "' order by payitemcnt desc";
            ultraGrid1.DataSource = Ms.runSQLDataSet(sqlU, "ss");
            ultraGrid1.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.AliceBlue;

        }
        private void button7_Click(object sender, EventArgs e)
        {

            string KCDateTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            string SqlDel = "delete from [Dp_shopindex] where  indexdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            Ms.ExeSQLNonQuery(SqlDel);

            string A1 = "https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=20&page=1&order=desc&orderBy=payItmCnt&cateId=350404&deviceType=0&sellerType=-1&propIdStr=121594760&propValueIdStr=1311982402&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1537179878105&token=";
            string A2 = "https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=20&page=1&order=desc&orderBy=payItmCnt&cateId=350404&deviceType=0&sellerType=-1&propIdStr=121594760&propValueIdStr=497276179&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1537180102797&token=";
            string A3 = "https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateRange=" + KCDateTime + "%7C" + KCDateTime + "&dateType=day&pageSize=100&page=1&order=desc&orderBy=payItmCnt&cateId=350404&deviceType=0&sellerType=-1&propIdStr=121594760&propValueIdStr=497276180&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1537173212111&token=";

            GetshopCar(A1);
            Thread.Sleep(10000);
            GetshopCar(A2);
            Thread.Sleep(10000);
            GetshopCar(A3);
        }
        public void DayList(int daytype)
        {
            int HourNumber = DateTime.Now.Hour;
            DataTable shoptable = new DataTable();
            string Sqlshop = "SELECT top 70 [ItemID] ,[shopname],[uvIndex] ,[indexdate]  FROM [Dp_shopindex] where indexdate='" + CDateTime + "' order by uvIndex desc";
            shoptable = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];

            string SqlPE = "delete from DayDPAllListNumber where  DItemdate='" + CDateTime + "' and daytypeid=" + daytype + "";
            Ms.ExeSQLNonQuery(SqlPE);

            foreach (DataRow keydr in shoptable.Rows)
            {
                //try
                //{

                PostServer.Getcookie = FPPcokk.ToString();
                string CcateId, CItemid, CshopName;
                CItemid = keydr["itemid"].ToString();
                CshopName = keydr["itemid"].ToString() + keydr["shopname"].ToString();
                CcateId = "50012100";
                string strpayRateIndex = "";
                if (daytype == 0)
                {
                    strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getLiveFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=today&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=uv&orderBy=uv&order=desc&token=";
                }
                else
                {
                    string Gday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                    strpayRateIndex = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=day&dateRange=" + Gday + "%7C" + Gday + "&indexCode=uv&orderBy=uv&order=desc&token=;";
                }
                PostServer.GetHTTPTaobao(strpayRateIndex);
                string txpayRateIndex = PostServer.GetHtml;
                JObject json = (JObject)JsonConvert.DeserializeObject(txpayRateIndex);

                //支付转化指数
                string typeIDstr = "";
                string jsonpayRateIndex = "";
                if (daytype == 0)
                {
                    jsonpayRateIndex = json["data"]["data"].ToString();
                }
                else
                {
                    jsonpayRateIndex = json["data"].ToString();
                }

                int NumberPayRate = 0;

                JArray payRateIndexJArray = JArray.Parse(jsonpayRateIndex);
                if (payRateIndexJArray.Count > 0)
                {


                    for (int i = 0; i < 8; i++)
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
                    this.textBox1.Text = this.textBox1.Text + CshopName;
                }

                //}
                //catch (Exception)
                //{

                //    // throw;
                //}
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
                this.ultraGrid2.DataSource = Ms.runSQLDataSet(txtSqlALLList(CDateTime, daytype).ToString(), "ss").Tables[0];
                ultraGrid2.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
                ultraGrid2.DisplayLayout.Bands[0].Columns["shopname"].Header.Fixed = true;
                ultraGrid2.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.AliceBlue;
            }



        }
        private void button2_Click(object sender, EventArgs e)
        {
            DayList(0);
            Gridcoure();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DayList(1);
            Gridcoure2();
        }
    }
}
