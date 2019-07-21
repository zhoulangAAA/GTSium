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
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using System.Net;
namespace Sium
{
    public partial class TaoBaoCC : Form
    {
        HttpPost PostServer = new HttpPost();
        IWebDriver driver = new FirefoxDriver();
        StringBuilder FPPcok = new StringBuilder();
        SQLServer Ms = new SQLServer();
        private string LstrGuid = "";
        private Silt.Client.Rules.ZASuiteDAORulesQQ rulesSys = new Silt.Client.Rules.ZASuiteDAORulesQQ();
        private Silt.Client.Rules.Tao.MASrcFlow baselistrules = new Silt.Client.Rules.Tao.MASrcFlow();
        private bool IsAddBool = new Boolean();
        private DataSet dsProdurcer = new DataSet();
        private DataSet ItemTrendProdurcer = new DataSet();
        private DataSet KeywordProdurcer = new DataSet();
        private DataSet OrderwordProdurcer = new DataSet();
        private DataSet CMKeywordProdurcer = new DataSet();
        private DataSet ShopWordProdurces = new DataSet();
        public ReadOnlyCollection<OpenQA.Selenium.Cookie> CookiesUS { get; set; }
        // private DataSet dsProdurcer = new DataSet();
        public TaoBaoCC()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //string Url = "https://login.taobao.com/member/login.jhtml?from=sycm&full_redirect=true&style=minisimple&minititle=&minipara=0,0,0&sub=true&redirect_url=http://sycm.taobao.com/mq/industry/rank/industry.htm";
            string Url = "https://subway.simba.taobao.com/#!/home";
            driver.Navigate().GoToUrl(Url);
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//input[@id='TPL_username_1']")).Click();
            //driver.FindElement(By.XPath("//input[@id='TPL_username_1']")).SendKeys(UserName.Text);
            //driver.FindElement(By.XPath("//input[@id='TPL_password_1']")).SendKeys(UserPass.Text);
            //Thread.Sleep(1000);
            //  driver.FindElement(By.XPath("//button[@id = 'J_SubmitStatic']")).Click();
        }
        #region 初始化数据
        public void loadDataSet()
        {
            dsProdurcer = baselistrules.ByidDSWrite("0");
            ItemTrendProdurcer = baselistrules.ItemTrendByidDSWrite("0");
            KeywordProdurcer = baselistrules.KeyByidDSWrite("0");
            OrderwordProdurcer = baselistrules.OrderByidDSWrite("0");
            CMKeywordProdurcer = baselistrules.CMKeyByidDSWrite("0");
            


        }
        #endregion
        #region 登录凭证
        public void GetCook()
        {
            FPPcok.Clear();
            //var cok = driver.Manage().Cookies
            // ShowInfo(cok.AllCookies.ToString());
            //获取Cookie
            ICookieJar listCookie = driver.Manage().Cookies;
            // IList<Cookie> listCookie = selenuim.Manage( ).Cookies.AllCookies;//只是显示 可以用Ilist对象
            //显示初始Cookie的内容

            Console.WriteLine("--------------------");
            Console.WriteLine($"当前Cookie集合的数量：\t{listCookie.AllCookies.Count}");
            for (int i = 0; i < listCookie.AllCookies.Count; i++)
            {

                FPPcok.Append($"{listCookie.AllCookies[i].Name}=");
                FPPcok.Append($"{listCookie.AllCookies[i].Value};");

            }
        }
      
        #endregion
        #region Top10PC无线来源
        public void PCpv(string ENDdata)
        {
          
            PostServer.Getcookie = FPPcok.ToString();
            string Kurl = "https://sycm.taobao.com/mq/rank/listItemSrcFlow.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateRangePre=" + EndDate.Text + "|" + EndDate.Text+  "&dateType=day&dateTypePre=recent1&device=1&devicePre=0&itemDetailType=1&itemId=" + this.ItemID.Text + "&rankTabIndex=0&rankType=1&seller=-1&token=50cd0ba09&view=detail";
            PostServer.GetHTTPTaobao(Kurl);
           // ShowInfo(Kurl);
            string gHtml = PostServer.GetHtml;
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["content"]["data"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = dsProdurcer.Tables[0];
            foreach (DataRow keyrow in dts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["pv"] = float.Parse(keyrow["pv"].ToString());
                //
                dr["pageName"] = keyrow["pageName"].ToString();
                //
                dr["uv"] = float.Parse(keyrow["uv"].ToString());
                //
                dr["uvRate"] = float.Parse(keyrow["uvRate"].ToString());
                //
                dr["pvRate"] = float.Parse(keyrow["pvRate"].ToString());
                //
                dr["getdatedey"] = ENDdata;
                //
                dr["shopID"] = this.shopName.Text;
                dr["typeID"] = 0;
                dt.Rows.Add(dr);
               
            }
            ShowInfo("正在采集--PC来源TOP10：" + ENDdata);
            //   string zone_en = json["beijing"]["zone_en"].ToString();
            //Dictionary<string, object> data = json["data"] as Dictionary<string, object>;
            //JArray array = (JArray)json["data"];
            //foreach (var jObject in array)
            //{ }

            //ShowInfo(zone);
            Addup();
        }
        public void WXpv(string ENDdata)
        {
           
            PostServer.Getcookie = FPPcok.ToString();
            string Kurl = "https://sycm.taobao.com/mq/rank/listItemSrcFlow.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateRangePre=" + EndDate.Text + "|" + EndDate.Text+  "&dateType=day&dateTypePre=recent1&device=2&devicePre=0&itemDetailType=1&itemId=" + this.ItemID.Text + "&rankTabIndex=0&rankType=1&seller=-1&token=50cd0ba09&view=detail";
            PostServer.GetHTTPTaobao(Kurl);
            ShowInfo(Kurl);
            string gHtml = PostServer.GetHtml;
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["content"]["data"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = dsProdurcer.Tables[0];
            foreach (DataRow keyrow in dts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["pv"] = float.Parse(keyrow["pv"].ToString());
                //
                dr["pageName"] = keyrow["pageName"].ToString();
                //
                dr["uv"] = float.Parse(keyrow["uv"].ToString());
                //
                dr["uvRate"] = float.Parse(keyrow["uvRate"].ToString());
                //
                dr["pvRate"] = float.Parse(keyrow["pvRate"].ToString());
                //
                dr["getdatedey"] = ENDdata;
                //
                dr["shopID"] = this.shopName.Text;
                dr["typeID"] = 1;
                dt.Rows.Add(dr);
                
            }
            ShowInfo("正在采集--无线来源TOP10：" + ENDdata);
            //   string zone_en = json["beijing"]["zone_en"].ToString();
            //Dictionary<string, object> data = json["data"] as Dictionary<string, object>;
            //JArray array = (JArray)json["data"];
            //foreach (var jObject in array)
            //{ }

            //ShowInfo(zone);
            Addup();
        }
        #endregion
        #region TOP10流量关建字
        public void Keyvoid(string ENDdata)
        {
            PostServer.Getcookie = FPPcok.ToString();
            //家电
            string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateRangePre=" + this.EndDate.Text + "|" + this.EndDate.Text + "&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=" + this.ItemID.Text + "&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail&_=";
           //女装
            string KeUrl2 = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateRangePre=" + this.EndDate.Text + "|" + this.EndDate.Text + "&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=" + this.ItemID.Text + "&latitude=undefined&rankTabIndex=0&rankType=1&seller=-1";

            PostServer.GetHTTPTaobao(KeUrl2);
            string gHtml = PostServer.GetHtml;
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["content"]["data"]["pcSeList"].ToString();
            string zone1 = json["content"]["data"]["wlSeList"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone1);
            loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = KeywordProdurcer.Tables[0];
            foreach (DataRow keydr in dts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["keyword"] = keydr["keyword"].ToString();
                //
                dr["keypv"] = float.Parse(keydr["uv"].ToString());
                //
                dr["keydate"] = ENDdata ;
                //
                dr["keytype"] = 0;
                dt.Rows.Add(dr);
                

            }
            ShowInfo("正在采集--PC流量关建词TOP10：" + ENDdata);
            foreach (DataRow keydrtype in WXdts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["keyword"] = keydrtype["keyword"].ToString();
                //
                dr["keypv"] = float.Parse(keydrtype["uv"].ToString());
                //
                dr["keydate"] = ENDdata;
                //
                dr["keytype"] = 1;
                dt.Rows.Add(dr);
               
            }
            ShowInfo("正在采集--无线流量关建词TOP10：" + ENDdata);
            KeywordAddup();
        }
        #endregion
        #region Top10成交关建字
        public void Ordervoid(string ENDdata)
        {
            PostServer.Getcookie = FPPcok.ToString();
            //string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre =2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=14344454654&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail";
            string KKurl = "https://sycm.taobao.com/mq/rank/listKeywordOrder.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateRangePre=" + this.EndDate.Text + "|" + this.EndDate.Text + "&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=1&itemId=" + this.ItemID.Text + "&latitude=undefined&rankTabIndex=0&rankType=1&seller=-1&token=6396ac0e7&view=detail&_=1495604216501";
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
          //  ShowInfo(gHtml);
            Thread.Sleep(10000);

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["content"]["data"]["pcList"].ToString();
            string zone1 = json["content"]["data"]["wlList"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone1);
            loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = OrderwordProdurcer.Tables[0];
            foreach (DataRow keydr in dts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["orkeyword"] = keydr["keyword"].ToString();
                //
                dr["orvalue"] = float.Parse(keydr["value"].ToString());
                //
                dr["ordate"] = ENDdata;
                //
                dr["ortype"] = 0;
                dt.Rows.Add(dr);
              
            }
            ShowInfo("正在采集--PC成交关建词TOP10：" + ENDdata);
            foreach (DataRow keydrtype in WXdts.Rows)
            {
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = ItemID.Text;
                //
                dr["orkeyword"] = keydrtype["keyword"].ToString();
                //
                dr["orvalue"] = float.Parse(keydrtype["value"].ToString());
                //
                dr["ordate"] = ENDdata;
                //
                dr["ortype"] = 1;
                dt.Rows.Add(dr);
              
                // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
            }
            ShowInfo("正在采集--无线成交关建词TOP10：" + ENDdata);

            OrderwordAddup();
        }
        #endregion
        #region 商家数据关键字
        public void ShopKey(int  TopNumber, string  ENDdata)
        {
            PostServer.Getcookie = FPPcok.ToString();
            //https://sycm.taobao.com/bda/items/itemanaly/itemformto/findItemKeywords.json?currentPage=1&dateRange=2017-06-13%7C2017-06-13&dateType=day&device=2&itemId=548142099488&order=uv&orderType=desc&search=&searchType=taobao&token=179b0f5b9&_=1497618232245";
            string KKurl = "https://sycm.taobao.com/bda/items/itemanaly/itemformto/findItemKeywords.json?currentPage=" + TopNumber.ToString() + "&dateRange=" + ENDdata + "|" + ENDdata + "&dateType=day&device=2&itemId="+this.ItemID.Text+"&order=uv&orderType=desc&search=&searchType=taobao";
           ShowInfo(KKurl);
            PostServer.GetHTTPTaobao(KKurl);

            string gHtml = PostServer.GetHtml;
            //ShowInfo(gHtml);
            Thread.Sleep(1000);
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string totalPage = json["data"]["totalPage"].ToString();
            string zone = json["data"]["list"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);

            ShopWordProdurces = baselistrules.shopkeyByidDSWrite("1");
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = ShopWordProdurces.Tables[0];
            foreach (DataRow keydr in dts.Rows)
            {
                dr = dt.NewRow();
                dr["payAmt"] = float.Parse(keydr["payAmt"].ToString());
                dr["payBuyerCnt"] = float.Parse(keydr["payBuyerCnt"].ToString());
                dr["payRate"] = float.Parse(keydr["payRate"].ToString());
                dr["pv"] = float.Parse(keydr["pv"].ToString());
                dr["avgPv"] = float.Parse(keydr["avgPv"].ToString());
                dr["bounceRate"] = float.Parse(keydr["bounceRate"].ToString());
                dr["payItemQty"] = float.Parse(keydr["payItemQty"].ToString());
                dr["keyword"] = keydr["keyword"].ToString();
                dr["uv"] = float.Parse(keydr["uv"].ToString());
                dr["ItemID"] = ItemID.Text; ;
                dr["keydate"] = ENDdata;
                dt.Rows.Add(dr);
            }
            ShoprwordAddup();
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            GetCook();
            for (int i = -1; i > -31; i--)
            {

                PostServer.Getcookie = FPPcok.ToString();
                string KKurl = "https://sycm.taobao.com/mq/rank/listItemSrcFlow.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre=2017-05-29|2017-05-29&dateType=day&dateTypePre=recent1&device=1&devicePre=0&itemDetailType=1&itemId=14344454654&rankTabIndex=0&rankType=1&seller=-1&token=50cd0ba09&view=detail";
                PostServer.GetHTTPTaobao(KKurl);
                string gHtml = PostServer.GetHtml;
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["content"]["data"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                loadDataSet();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = dsProdurcer.Tables[0];
                foreach (DataRow keyrow in dts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["pv"] = float.Parse(keyrow["pvRate"].ToString());
                    //
                    dr["pageName"] = keyrow["pageName"].ToString();
                    //
                    dr["uv"] = float.Parse(keyrow["uv"].ToString());
                    //
                    dr["uvRate"] = float.Parse(keyrow["uvRate"].ToString());
                    //
                    dr["pvRate"] = float.Parse(keyrow["pvRate"].ToString());
                    //
                    dr["getdatedey"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                    //
                    dr["shopID"] = this.shopName.Text;
                    dr["typeID"] = 0;
                    dt.Rows.Add(dr);
                }
                Addup();
                //foreach (var jObject in array)
                //{ }
                ShowInfo(gHtml);
                ShowInfo("----------------------------------------------------------------");
                ShowInfo(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
                ShowInfo("----------------------------------------------------------------");
            }
            //JArray JArray = (JArray)JsonConvert.DeserializeObject(gHtml);
            //JArray["aaa"] = "";
        }
        public void ShowInfo(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // var cok = driver.Manage().Cookies.AllCookies.
         //   ShowInfo(cok.AllCookies);
            ////获取Cookie
            //ICookieJar listCookie = driver.Manage().Cookies;
            //// IList<Cookie> listCookie = selenuim.Manage( ).Cookies.AllCookies;//只是显示 可以用Ilist对象
            ////显示初始Cookie的内容

            //Console.WriteLine("--------------------");
            //Console.WriteLine($"当前Cookie集合的数量：\t{listCookie.AllCookies.Count}");
            //for (int i = 0; i < listCookie.AllCookies.Count; i++)
            //{

            //    FPPcok.Append($"{listCookie.AllCookies[i].Name}=");
            //    FPPcok.Append($"{listCookie.AllCookies[i].Value};");
            //    ShowInfo($"Cookie的名称:{listCookie.AllCookies[i].Name}");
            //    ShowInfo($"Cookie的值:{listCookie.AllCookies[i].Value}");
            //    ShowInfo($"Cookie的所在域:{listCookie.AllCookies[i].Domain}");
            //    ShowInfo($"Cookie的路径:{listCookie.AllCookies[i].Path}");
            //    ShowInfo($"Cookie的过期时间:{listCookie.AllCookies[i].Expiry}");
            //    ShowInfo("-----");
            //}
            //ShowInfo(FPPcok.ToString());

            //添加一个新的Cookie
            //OpenQA.Selenium.Cookie newCookie = new OpenQA.Selenium.Cookie("新Cookie", "新值", "", DateTime.Now.AddDays(1));
            // listCookie.AddCookie(newCookie);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetCook();
            PostServer.Getcookie = FPPcok.ToString();
            string KKurl = "https://sycm.taobao.com/ipoll/live/summary/getItemHourTrend.json?device=0&itemId=548469188855&token=921ecadaa&_=1532589712690";
            string gHtml = PostServer.GetHTTPTaobao(KKurl);
            ShowInfo(gHtml);
        }


        private void AddClass()
        {
            try
            {

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = dsProdurcer.Tables[0];
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = "5555555555555";
                //
                dr["pv"] = 468464886;
                //
                dr["pageName"] = " 直通车";
                //
                dr["uv"] = 16545;
                //
                dr["uvRate"] = 0.23;
                //
                dr["pvRate"] = 0.25;
                //
                dr["getdatedey"] = "2017-4-8";
                //
                dr["shopID"] = "5656";
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageProcess.ZAMessageShowError(ex.Message.ToString());
            }
        }
        private void Addup()
        {
            //try
            //{
                Cursor = Cursors.WaitCursor;
              //  DataRow dr = this.dsProdurcer.Tables[0].Rows[0];


                this.Validate();
                this.baselistrules.ZAUpdate(this.dsProdurcer);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void ItemTrendAddup()
        {
            //try
            //{
            Cursor = Cursors.WaitCursor;
            //  DataRow dr = this.ItemTrendProdurcer.Tables[0].Rows[0];


            this.Validate();
            this.baselistrules.ItemTrendZAUpdate(this.ItemTrendProdurcer);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void KeywordAddup()
        {
            //try
            //{
            Cursor = Cursors.WaitCursor;
            //  DataRow dr = this.ItemTrendProdurcer.Tables[0].Rows[0];


            this.Validate();
            this.baselistrules.KeyZAUpdate(this.KeywordProdurcer);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void OrderwordAddup()
        {
            //try
            //{
            Cursor = Cursors.WaitCursor;
            //  DataRow dr = this.ItemTrendProdurcer.Tables[0].Rows[0];


            this.Validate();
            this.baselistrules.OrderZAUpdate(this.OrderwordProdurcer);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void CMKeywordAddup()
        {
            //try
            //{
            Cursor = Cursors.WaitCursor;
            //  DataRow dr = this.ItemTrendProdurcer.Tables[0].Rows[0];


            this.Validate();
           this.baselistrules.SYSTUpdate(this.CMKeywordProdurcer);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void ShoprwordAddup()
        {
            //try
            //{
            Cursor = Cursors.WaitCursor;
            //  DataRow dr = this.ItemTrendProdurcer.Tables[0].Rows[0];


            this.Validate();
            this.baselistrules.ShopkeywordZAUpdate(this.ShopWordProdurces);


            //}
            //catch (Exception ex)
            //{
            //    // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //    MessageProcess.ZAMessageShowError(ex.Message.ToString());
            //}
            //finally
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }
        private void button5_Click(object sender, EventArgs e)
        {
            GetCook();
            string cookiesget = this.textBox3.Text;
            PostServer.Getcookie = FPPcok.ToString();


            string Urls = "https://sycm.taobao.com/mq/rank/listItemTrend.json?cateId=" + this.cateId.Text + "&categoryId=" + cateId.Text + "&dateRange=" + this.EndDate.Text + "|" + this.EndDate.Text + "&dateRangePre=" + this.EndDate.Text + "|" + this.EndDate.Text + "&dateType=recent1&dateTypePre=recent1&device=0&devicePre=0&indexes=payOrdCnt,payByrRateIndex,payItemQty&itemDetailType=1&itemId=" + this.ItemID.Text + "&latitude=undefined&rankTabIndex=0&rankType=1&seller=-1&token=b73cc47a6&view=detail&_=1497987942153";
            string Ursl = "https://sycm.taobao.com/mq/rank/listItemTrend.json?cateId=162201&categoryId=162201&dateRange=2017-06-19|2017-06-19&dateRangePre=2017-06-13|2017-06-19&dateType=recent1&dateTypePre=recent7&device=0&devicePre=0&indexes=payOrdCnt,payByrRateIndex,payItemQty&itemDetailType=1&itemId=551416049383&latitude=undefined&rankTabIndex=0&rankType=1&seller=-1&token=b73cc47a6&view=detail&_=1497990965952";
            PostServer.GetHTTPTaobao(Urls);
            string gHtml = PostServer.GetHtml;
            ShowInfo(gHtml);
            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            string zone = json["content"]["data"]["payOrdCntList"].ToString();
            string zone1 = json["content"]["data"]["payByrRateIndexList"].ToString();
            string zone2 = json["content"]["data"]["payItemQtyList"].ToString();
            ShowInfo(zone);
            JArray array = JsonConvert.DeserializeObject<JArray>(zone);
            JArray array1 = JsonConvert.DeserializeObject<JArray>(zone1);
            JArray array2 = JsonConvert.DeserializeObject<JArray>(zone2);
            loadDataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt = ItemTrendProdurcer.Tables[0];
            int nowdata = 31;
            Regex regex = new Regex("[^0-9]");
          
            for (int i = 0; i < array.Count; i++)
            {
                float result=0;
                nowdata--;
                dr = dt.NewRow();
                dr["ID"] = 0;
                dr["ItemID"] = this.ItemID.Text;
                //
                if (float.TryParse(array[i].ToString(), out result))
                {
                    dr["payOrdCntList"] = float.Parse(array[i].ToString());
                    dr["payByrRateIndexList"] = float.Parse(array1[i].ToString());
                    dr["payItemQtyList"] = float.Parse(array2[i].ToString());
                }
                else
                {
                    dr["payOrdCntList"] = 0;
                    dr["payByrRateIndexList"] = 0;
                    dr["payItemQtyList"] = 0;
                }
             
             
                //
                dr["paydate"] = DateTime.Now.AddDays(-nowdata).ToString("yyyy-MM-dd");
                dt.Rows.Add(dr);
                ShowInfo(DateTime.Now.AddDays(-nowdata).ToString("yyyy-MM-dd"));
                ShowInfo(array[i].ToString());
                ShowInfo(array1[i].ToString());
                ShowInfo(array2[i].ToString());
                ShowInfo("-------------------------");

            }
            ItemTrendAddup();
            //DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
        }

        private void TaoBaoCC_Load(object sender, EventArgs e)
        {
            this.EndDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            this.dateTimePicker1.Text = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            this.dateTimePicker2.Text = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string randomstr = (Convert.ToDouble(random.Next(1, 100)) / Math.PI / 100).ToString();
            GetCook();
            for (int i = -1; i > -31; i--)
            {
                PostServer.Getcookie = FPPcok.ToString();
                string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre =2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=14344454654&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail&_=" + randomstr;
                string KKurl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre=2017-05-29|2017-05-29&dateType=day&dateTypePre=recent1&device=1&devicePre=0&itemDetailType=1&itemId=14344454654&rankTabIndex=0&rankType=1&seller=-1&token=50cd0ba09&view=detail";
                PostServer.GetHTTPTaobao(KeUrl);
                string gHtml = PostServer.GetHtml;



                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["content"]["data"]["pcSeList"].ToString();
                string zone1 = json["content"]["data"]["wlSeList"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone);
                loadDataSet();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = KeywordProdurcer.Tables[0];
                foreach (DataRow keydr in dts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["keyword"] = keydr["keyword"].ToString();
                    //
                    dr["keypv"] = float.Parse(keydr["uv"].ToString());
                    //
                    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
                    //
                    dr["keytype"] = 0;
                    dt.Rows.Add(dr);
                    string aa = "PC:" + dr["keyword"].ToString();
                    ShowInfo(aa);
                    ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }
                foreach (DataRow keydrtype in WXdts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["keyword"] = keydrtype["keyword"].ToString();
                    //
                    dr["keypv"] = float.Parse(keydrtype["uv"].ToString());
                    //
                    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                    //
                    dr["keytype"] = 1;
                    dt.Rows.Add(dr);
                    string aa = "无线:" + dr["keyword"].ToString();

                    ShowInfo(aa);
                    ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }
                KeywordAddup();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string randomstr = (Convert.ToDouble(random.Next(1, 100)) / Math.PI / 100).ToString();
            GetCook();
            for (int i = -1; i > -31; i--)
            {
                PostServer.Getcookie = FPPcok.ToString();
                string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre =2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=14344454654&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail&_=" + randomstr;
                string KKurl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre=2017-05-29|2017-05-29&dateType=day&dateTypePre=recent1&device=1&devicePre=0&itemDetailType=1&itemId=14344454654&rankTabIndex=0&rankType=1&seller=-1&token=50cd0ba09&view=detail";
                PostServer.GetHTTPTaobao(KeUrl);
                string gHtml = PostServer.GetHtml;



                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["content"]["data"]["pcSeList"].ToString();
                string zone1 = json["content"]["data"]["wlSeList"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone);
                loadDataSet();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = KeywordProdurcer.Tables[0];
                foreach (DataRow keydr in dts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["keyword"] = keydr["keyword"].ToString();
                    //
                    dr["keypv"] = float.Parse(keydr["uv"].ToString());
                    //
                    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
                    //
                    dr["keytype"] = 0;
                    dt.Rows.Add(dr);
                    string aa = "PC:" + dr["keyword"].ToString();
                    ShowInfo(aa);
                    ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }
                foreach (DataRow keydrtype in WXdts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["keyword"] = keydrtype["keyword"].ToString();
                    //
                    dr["keypv"] = float.Parse(keydrtype["uv"].ToString());
                    //
                    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                    //
                    dr["keytype"] = 1;
                    dt.Rows.Add(dr);
                    string aa = "无线:" + dr["keyword"].ToString();

                    ShowInfo(aa);
                    ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }
                KeywordAddup(); Thread.Sleep(10000);
            }
        }
        /// <summary>
        /// 返回总数
        /// </summary>
        /// <param name="HourNumber">当前小时</param>
        /// <param name="AllNumber">总数</param>
        /// <returns></returns>
        public void getNowNumber(int HourNumber, int AllNumber, string shopName)
        {
           
           
        }
        private void button9_Click(object sender, EventArgs e)
        {
         
          
            GetCook();
            int HourNumber = DateTime.Now.Hour;
                PostServer.Getcookie = FPPcok.ToString();
                //string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre =2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=14344454654&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail";
                string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
                PostServer.GetHTTPTaobao(KKurl);
                string gHtml = PostServer.GetHtml;
                ShowInfo(gHtml);
              //  Thread.Sleep(10000);

                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["data"]["data"]["topDatas"]["list"].ToString();
              //  string zone1 = json["content"]["data"]["wlList"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
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
                ShowInfo(bb+"----"+aa);
                string Sql = "INSERT INTO [hqNumber]([shopName],[DateHour],[HouNumber])VALUES('" + shopNameID + "'," + HourNumber + "," + int.Parse(keydr["paySubOrderCnt"].ToString()) + "-(SELECT isnull(SUM(houNumber),0) FROM dbo.hqNumber where shopname='" + shopNameID + "' and DateHour<" + HourNumber + "))";
                string Sqldel = "delete from hqNumber  where DateHour=" + HourNumber;
                string GSql = "select * from [Pnumber_View]";

                Ms.ExeSQLNonQuery(Sqldel);
                //  ShowInfo(Sql);
                Ms.ExeSQLNonQuery(Sql);
                // ShowInfo("---------------------------------------");
                // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
            }
               

              
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetCook();

            for (int i = -1; i > -31; i--)
            {
                PostServer.Getcookie = FPPcok.ToString();
                //string KeUrl = "https://sycm.taobao.com/mq/rank/listItemSeKeyword.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre =2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=7&itemId=14344454654&latitude=property&propertyIds=31600&propertyValueIds=105377&rankTabIndex=0&rankType=1&seller=-1&token=e7162653f&view=detail";
                string KKurl = "https://sycm.taobao.com/mq/rank/listKeywordOrder.json?cateId=350712&categoryId=350712&dateRange=" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "|" + DateTime.Now.AddDays(i).ToString("yyyy-MM-dd") + "&dateRangePre=2017-06-01|2017-06-01&dateType=day&dateTypePre=recent1&device=0&devicePre=0&itemDetailType=1&itemId=14344454654&latitude=undefined&rankTabIndex=0&rankType=1&seller=-1&token=6396ac0e7&view=detail&_=1495604216501";
                PostServer.GetHTTPTaobao(KKurl);
                string gHtml = PostServer.GetHtml;
                ShowInfo(gHtml);
                Thread.Sleep(10000);

                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["content"]["data"]["pcList"].ToString();
                string zone1 = json["content"]["data"]["wlList"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                DataTable WXdts = JsonConvert.DeserializeObject<DataTable>(zone);
                loadDataSet();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = OrderwordProdurcer.Tables[0];
                foreach (DataRow keydr in dts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["orkeyword"] = keydr["keyword"].ToString();
                    //
                    dr["orvalue"] = float.Parse(keydr["value"].ToString());
                    //
                    dr["ordate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
                    //
                    dr["ortype"] = 0;
                    dt.Rows.Add(dr);
                    string aa = "PC:" + keydr["keyword"].ToString() + "value:" + keydr["value"].ToString();
                    ShowInfo(aa);
                    // ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }
                foreach (DataRow keydrtype in WXdts.Rows)
                {
                    dr = dt.NewRow();
                    dr["ID"] = 0;
                    //
                    dr["ItemID"] = ItemID.Text;
                    //
                    dr["orkeyword"] = keydrtype["keyword"].ToString();
                    //
                    dr["orvalue"] = float.Parse(keydrtype["value"].ToString());
                    //
                    dr["ordate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
                    //
                    dr["ortype"] = 1;
                    dt.Rows.Add(dr);
                    string aa = "无线:" + keydrtype["keyword"].ToString() + "value:" + keydrtype["value"].ToString();

                    ShowInfo(aa);
                    ShowInfo("---------------------------------------");
                    // ShowInfo($"{0}\t{1}\t{2}\t{3}\t,dr[0], dr[1], dr[2], dr[3]");
                }

                OrderwordAddup();
            }
        }
        public DataTable GeDataTable()
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("ADDate", typeof(Int32));//添加列
            dt.Columns.Add("addCartItemCnt", typeof(Int32));
          //  dt.Columns.Add("itemFavCnt", typeof(Int32));
          //  dt.Columns.Add("payItemQty", typeof(Int32));
            dt.Columns.Add("payBuyerCnt", typeof(Int32));
          //  dt.Columns.Add("uv", typeof(Int32));
            dt.Columns.Add("pv", typeof(Int32));
            dt.Columns.Add("payRate", typeof(decimal));
          //  dt.Columns.Add("payAmt", typeof(decimal));
            return dt;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //DataTable SubTable = GeDataTable();
            //SubTable.Clear();
            JObject json = (JObject)JsonConvert.DeserializeObject(textBox3.Text);
           // string zone = json["result"][1].ToString();
            string zone = json["rateDetail"]["rateList"].ToString();
            //DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            //ultraGrid1.DataSource = dts;
            // ShowInfo(zone);
            JArray results = JArray.Parse(zone);
            //// results.OrderByDescending(x => (string)x["uv"]["value"]);//按order进行降序排序
            for (int i = 0; i < results.Count; i++)
            {
                string shopNameID = results[i]["rateContent"].ToString();
              //  int Keynumber = int.Parse(results[i]["rivalItem1PayByrCntIndex"]["value"].ToString());
                ShowInfo(shopNameID );
                //nfo("值:" + results[i]["selfItemPayByrCnt"]["value"].ToString());

                //ShowInfo("ID:"+results[i]["item"]["itemId"].ToString());
                //ShowInfo("店铺:" + results[i]["shop"]["title"].ToString());
                //ShowInfo("流量指数:" + results[i]["uvIndex"]["value"].ToString());


            }


            //}
            //DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            //ultraGrid1.DataSource = dts;
            //   //   string itemFavCnt = json["data"]["data"]["itemFavCnt"].ToString();
            //   // string payItemQty = json["data"]["data"]["payItemQty"].ToString();
            //   string payBuyerCnt = json["data"]["data"]["payBuyerCnt"].ToString();

            ////   string uv = json["data"]["data"]["uv"].ToString();
            //   string pv = json["data"]["data"]["pv"].ToString();

            //   string payRate = json["data"]["data"]["payRate"].ToString();
            // //  string payAmt = json["data"]["data"]["payAmt"].ToString();


            //   JArray JAaddCartItemCnt = JArray.Parse(addCartItemCnt);
            //   //JArray JAitemFavCnt = JArray.Parse(itemFavCnt);
            //  // JArray JApayItemQty = JArray.Parse(payItemQty);
            //   JArray JApayBuyerCnt = JArray.Parse(payBuyerCnt);

            // //  JArray JAuv = JArray.Parse(uv);
            //   JArray JApv = JArray.Parse(pv);
            //   JArray JApayRate = JArray.Parse(payRate);
            // //  JArray JApayAmt = JArray.Parse(payAmt);
            //   DataRow dr = null;
            //   for (int i = JAaddCartItemCnt.Count-1; i >-1; i--)
            //   {
            //       dr = SubTable.NewRow();
            //       dr["ADDate"] = i;
            //       dr["addCartItemCnt"] = JAaddCartItemCnt[i].ToString();
            //      // dr["itemFavCnt"] = JAitemFavCnt[i].ToString();
            //     //  dr["payItemQty"] = JApayItemQty[i].ToString();
            //       dr["payBuyerCnt"] = JApayBuyerCnt[i].ToString();//买家数

            //      // dr["uv"] = JAuv[i].ToString();
            //       dr["pv"] = JApv[i].ToString();
            //       dr["payRate"] = decimal.Parse(JApayRate[i].ToString())*100;
            //     //  dr["payAmt"] = JApayAmt[i].ToString();
            //       SubTable.Rows.Add(dr);

            //   }
            //   this.ultraGrid1.DataSource = SubTable;
            //   ultraGrid1.DisplayLayout.Bands[0].Columns["ADDate"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            //   // DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            //   // DataTable dt = new DataTable();
            //   // dt = dts.Copy();
            //   // dt.Rows.Clear();
            //   // DataRow dr = null;
            //   // foreach (DataRow keydr in dts.Rows)
            //   // {
            //   //     dr = dt.NewRow();




            //   //         ShowInfo("关建字:" + keydr["payItemQty"].ToString());


            //   //     //



            //   // }
            //   //outzkey aa = new outzkey(dt);
            //   //aa.Show();


            #region 市场行情小时

            //DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);

            //foreach (DataRow keydr in dts.Rows)
            //{
            //    //    dr = dt.NewRow();
            //    //    dr["ID"] = 0;
            //    //    //
            //    //    dr["ItemID"] = ItemID.Text;
            //    //    //
            //    //    dr["keyword"] = keydr["keyword"].ToString();
            //    //    //
            //    //    dr["keypv"] = float.Parse(keydr["uv"].ToString());
            //    //    //
            //    //    dr["keydate"] = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"); ;
            //    //    //
            //    //    dr["keytype"] = 0;
            //    //    dt.Rows.Add(dr);

            //    //   ShowInfo(totalPage);
            //    ShowInfo("店铺:" + keydr["shopName"].ToString());
            //    ShowInfo("宝贝ID:" + keydr["itemId"].ToString());
            //    ShowInfo("今日成交:" + keydr["paySubOrderCnt"].ToString());
            //    ShowInfo("昨日成交:" + keydr["prePaySubOrderCnt"].ToString());

            //}
            #endregion
            #region 每小时点击
            //DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            //           DataTable dt = new DataTable(); //原来的资料
            //dt = GetGroupedBy(dts, "clickTimeStr", "clickTimeStr", "Sum");
            //foreach (DataRow keydr in dt.Rows)
            //{

            //    ShowInfo(keydr["clickTimeStr"].ToString() +"："+ dts.Compute("count(clickTimeStr)", "clickTimeStr='" + keydr["clickTimeStr"].ToString() + "'").ToString());


            //}
            #endregion


        }
        private DataTable GetGroupedBy(DataTable dt, string columnNamesInDt, string groupByColumnNames, string typeOfCalculation)
        {
            //Return its own if the column names are empty
            if (columnNamesInDt == string.Empty || groupByColumnNames == string.Empty)
            {
                return dt;
            }

            //Once the columns are added find the distinct rows and group it bu the numbet
            DataTable _dt = dt.DefaultView.ToTable(true, groupByColumnNames);

            //The column names in data table
            string[] _columnNamesInDt = columnNamesInDt.Split(',');

            for (int i = 0; i < _columnNamesInDt.Length; i = i + 1)
            {
                if (_columnNamesInDt[i] != groupByColumnNames)
                {
                    _dt.Columns.Add(_columnNamesInDt[i]);
                }
            }

            //Gets the collection and send it back
            for (int i = 0; i < _dt.Rows.Count; i = i + 1)
            {
                for (int j = 0; j < _columnNamesInDt.Length; j = j + 1)
                {
                    if (_columnNamesInDt[j] != groupByColumnNames)
                    {
                        _dt.Rows[i][j] = dt.Compute(typeOfCalculation + "(" + _columnNamesInDt[j] + ")", groupByColumnNames + " = '" + _dt.Rows[i][groupByColumnNames].ToString() + "'");
                    }
                }
            }

            return _dt;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            GetCook();
            for (int i = -1; i > -31; i--)
            {
                string ENDate = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                Thread.Sleep(10000);
                PCpv(ENDate);
                WXpv(ENDate);
                Keyvoid(ENDate);
                Ordervoid(ENDate);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GetCook();
            for (int i = -1; i > -31; i--)
            {
                string ENDate = DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                for (int j = 1; j <=6; j++)
                {
                    ShopKey(j, ENDate);
                }
                
              
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            WitGetCook();
            driver.Navigate().GoToUrl("https://sycm.taobao.com/mq/industry/rank/industry.htm");
        }
        public void WitGetCook()
        {
          //  CookiesUS.
            //string strCookHeader = this.textBox3.Text;
            ////string[] Cou = aa.Split(';');
            //string[] strCookTemp = strCookHeader.Split(';');
            //ArrayList al = new ArrayList();
            //int i = 0;
            //int n = strCookTemp.Length;
            //while (i < n)
            //{
            //    //if (strCookTemp[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
            //    //{
            //    //    al.Add(strCookTemp[i] + "," + strCookTemp[i + 1]);
            //    //    i = i + 1;
            //    //}
            //    //else
            //    //{
            //    //    al.Add(strCookTemp[i]);
            //    //}
            //    ShowInfo(strCookTemp[i]+"--------" + strCookTemp[i + 1]);
            //    i = i + 1;
            //}
            //ICookieJar listCookie;
            string aa = this.textBox3.Text;
            string[] Cou = aa.Split(';');
            foreach (string sCookie in Cou)
            {
                string[] PP = sCookie.Split('=');
                //for (int ji = 0; ji < PP.Length; ji++)
                //{
                    OpenQA.Selenium.Cookie pe = new OpenQA.Selenium.Cookie(PP[0], PP[1]);
                    driver.Manage().Cookies.AddCookie(pe);
                    ShowInfo(PP[0]+"----------"+PP[1]);
                //}
            
             
                //if (sCookie.IndexOf("expires") > 0)
                //    OpenQA.Selenium.Cookie pe = new OpenQA.Selenium.Cookie()

            }
            //ICookieJar listCookie;
            //listCookie.
            //driver.Manage().Cookies = ICookieJar listCookie;
            ////OpenQA.Selenium.Cookie ow = new OpenQA.Selenium.Cookie();
            //FPPcok.Clear();
            //driver.Manage().Cookies.AddCookie()
            //// ShowInfo(cok.AllCookies.ToString());
            ////获取Cookie
            ////driver.Manage().Cookies.
            //ICookieJar listCookie = driver.Manage().Cookies;
            //listCookie.DeleteAllCookies();
            //listCookie.AddCookie();
            //string 
            //// IList<Cookie> listCookie = selenuim.Manage( ).Cookies.AllCookies;//只是显示 可以用Ilist对象
            ////显示初始Cookie的内容

            //Console.WriteLine("--------------------");
            //Console.WriteLine($"当前Cookie集合的数量：\t{listCookie.AllCookies.Count}");
            //for (int i = 0; i < listCookie.AllCookies.Count; i++)
            //{

            //    FPPcok.Append($"{listCookie.AllCookies[i].Name}=");
            //    FPPcok.Append($"{listCookie.AllCookies[i].Value};");

            //}
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.EndDate.Text = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://sycm.taobao.com/custom/login.htm?_target=http://sycm.taobao.com/mq/industry/rank/industry.htm");
        
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            DateTime BegDate = this.dateTimePicker1.Value;
            DateTime EndDate = this.dateTimePicker2.Value;
            double ts2 = BegDate.Subtract(EndDate).TotalDays;
            GetCook();
            DataTable dt = new DataTable();
            dt = null;
            DataRow dr = null;
            for (int i = 0; i < ts2; i++)
            {
                Thread.Sleep(10000);
                PostServer.Getcookie = FPPcok.ToString();
                string KeUrl = "https://subway.simba.taobao.com/report/getNetworkPerspective.htm?bidwordstr="+ textBox5.Text+ "&startDate="+ EndDate.AddDays(i).ToString("yyyy-MM-dd") + "&endDate="+ EndDate.AddDays(i).ToString("yyyy-MM-dd") + "&perspectiveType=2";
                // ShowInfo(KeUrl);
                string KKdatePost = "sla=json&isAjaxRequest=true&token="+ txtKeyken.Text+ "&_referer=/tools/insight/queryresult?kws=" + textBox5.Text + "&tab=tabs-region";
                PostServer.PostHttpZCT(KeUrl, KKdatePost);
               
                string gHtml = PostServer.GetHtml;
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["result"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                if (dt==null)
                {
                    dt = dts.Copy();
                    dt.Rows.Clear();
                }
               
                
                foreach (DataRow keydr in dts.Rows)
                {
                    dr = dt.NewRow();

                    if (keydr["network"].ToString() == "4")
                    {
                        dr["bidwordstr"] = keydr["bidwordstr"];
                        dr["network"] = keydr["network"];
                        dr["impression"] = keydr["impression"];
                        dr["date"] = EndDate.AddDays(i).ToString("yyyy-MM-dd");
                        dr["impressionRate"] = keydr["impressionRate"];
                        dr["click"] = keydr["click"];
                        dr["price"] = keydr["price"];
                        dr["ctr"] = keydr["ctr"];
                        dr["competition"] = keydr["competition"];
                        dr["cvr"] = keydr["cvr"];
                        
                        dr["avgPrice"] = keydr["avgPrice"];
                        dt.Rows.Add(dr);


                        ShowInfo("关建字:" + keydr["bidwordstr"].ToString());
                        ShowInfo("展示量:" + keydr["impression"].ToString());

                    }
                    //



                }
                
                //ShowInfo(zone);
            }
            outzkey aa = new outzkey(dt);
            aa.Show();
            //  ShowInfo(FPPcok.ToString());

            // MessageBox.Show(ts2.ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DateTime BegDate = this.dateTimePicker1.Value;
            DateTime EndDate = this.dateTimePicker2.Value;
            double ts2 = BegDate.Subtract(EndDate).TotalDays;
            int getts2 = int.Parse(ts2.ToString());
            GetCook();
            for (int j = 0; j < ts2; j++)
            {
                for (int k = 1; k <=5; k++)
                {
                    Thread.Sleep(10000);
                    PostServer.Getcookie = FPPcok.ToString();
                    string KeUrl = "https://sycm.taobao.com/flow/new/item/source/detail.json?itemId=560900631295&dateType=day&dateRange=" + EndDate.AddDays(j).ToString("yyyy-MM-dd") + "%7C" + EndDate.AddDays(j).ToString("yyyy-MM-dd") + "&pageId=23.s1150&pPageId=23&pageLevel=2&childPageType=se_keyword&page="+k.ToString()+"&pageSize=50&order=desc&orderBy=payByrCnt&device=2";
                    ShowInfo(KeUrl);
                    PostServer.GetHTTPTaobao(KeUrl);
                    string gHtml = PostServer.GetHtml;
                    JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                    string zone = json["data"]["data"].ToString();
                    loadDataSet();
                    DataTable dt = new DataTable();
                    DataRow dr = null;
                    dt = CMKeywordProdurcer.Tables[0];

                    JArray results = JArray.Parse(zone);
                    for (int i = 0; i < results.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr["uv"] = float.Parse(results[i]["uv"]["value"].ToString());
                        dr["bounceUv"] = float.Parse(results[i]["bounceUv"]["value"].ToString());
                        dr["payByrCnt"] = float.Parse(results[i]["payByrCnt"]["value"].ToString());
                        dr["bounceSelfUv"] = float.Parse(results[i]["bounceSelfUv"]["value"].ToString());
                        dr["cartByrCnt"] = float.Parse(results[i]["cartByrCnt"]["value"].ToString());
                        dr["pv"] = float.Parse(results[i]["pv"]["value"].ToString());
                        dr["payRate"] = float.Parse(results[i]["payRate"]["value"].ToString());
                        dr["pageLevel"] = float.Parse(results[i]["pageLevel"]["value"].ToString());
                        dr["cltCnt"] = float.Parse(results[i]["cltCnt"]["value"].ToString());
                        dr["pageId"] = float.Parse("23");
                        dr["pageName"] = results[i]["pageName"]["value"].ToString();
                        dr["payItmCnt"] = float.Parse(results[i]["cltCnt"]["value"].ToString());
                        dr["crtByrCnt"] = float.Parse(results[i]["crtByrCnt"]["value"].ToString());
                        dr["pPageId"] = float.Parse(results[i]["pPageId"]["value"].ToString());
                        dr["crtRate"] = float.Parse(results[i]["crtRate"]["value"].ToString());
                        dr["indate"] = DateTime.Now.ToString("yyyy-MM-dd");
                        dr["getdate"] = EndDate.AddDays(j).ToString();
                        dr["crmName"] = shopName.Text;
                        dr["itemid"] = ItemID.Text;
                        dt.Rows.Add(dr);

                    }
                    CMKeywordAddup();
                   
                }
               
                
            }
                       //GetCook();
            //PostServer.Getcookie = FPPcok.ToString();
            //string KeUrl = "https://sycm.taobao.com/flow/new/item/source/detail.json?itemId=560900631295&dateType=day&dateRange=2018-03-18%7C2018-03-18&pageId=23.s1150&pPageId=23&pageLevel=2&childPageType=se_keyword&page=1&pageSize=50&order=desc&orderBy=payByrCnt&device=2";

            //PostServer.GetHTTPTaobao(KeUrl);
            //string gHtml = PostServer.GetHtml;
            //textBox3.Text = gHtml;

           


        }

        private void button20_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://subway.simba.taobao.com/#!/visitor/info");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void getUVList(string Key,string CDateTime, string CcateId,string CItemid,string CshopNameItemd)
        {
            Thread.Sleep(10000);
            int HourNumber = 0;
            PostServer.Getcookie = FPPcok.ToString();
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
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
            if (gHtml.IndexOf("出错")>0)
            {
                ShowInfo("出错:"+CDateTime);
            }
            else
            {
                // ShowInfo(FPPcokk.ToString());
                ShowInfo(KKurl);

                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);


                //string Sqldel = "delete from hqUV  where DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                //Ms.ExeSQLNonQuery(Sqldel);
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
                    int Keynumber = 0;
                    string Sql = "";

                    if (Key == "uv")
                    {
                        shopNameID = results[i]["pageName"]["value"].ToString();
                        Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                        Sql = "INSERT INTO [hqUVList]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                        // ShowInfo(shopNameID + "----" + Keynumber);
                    }
                    if (Key == "payByrCntIndex")
                    {

                        shopNameID = results[i]["pageName"]["value"].ToString();
                        decimal aa = decimal.Parse(results[i]["rivalItem1PayByrCntIndex"]["value"].ToString());
                        ShowInfo(aa.ToString());
                        decimal bb = Math.Round(aa, 0);
                        int CC = int.Parse(bb.ToString());
                        Keynumber = int.Parse(bb.ToString());
                        int Paycn = poweint(Keynumber);
                        Sql = "INSERT INTO [hqUVListCUS]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + CC + "," + Paycn + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    }
                    //  ShowInfo(Sql);
                    Ms.ExeSQLNonQuery(Sql);

                }
            }
           
        }
        public void getKeywordList(string Key, string CDateTime, string CcateId, string CItemid,string CshopNameItemd)
        {
            Thread.Sleep(10000);
            int HourNumber = 0;
            PostServer.Getcookie = FPPcok.ToString();
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
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
            if (gHtml.IndexOf("出错")>0)
            {
                 ShowInfo("出错:"+CDateTime);
            }
            else
            {
                // ShowInfo(FPPcokk.ToString());
                ShowInfo(KKurl);

                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);


                //string Sqldel = "delete from hqUV  where DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                //Ms.ExeSQLNonQuery(Sqldel);
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
                    // ShowInfo(bb + "----" + aa);
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
                    //  ShowInfo(Sql);
                    Ms.ExeSQLNonQuery(Sql);
                }
            }
          
        }
        public void getUVListNEW(string CDateTime, string CcateId, string CItemid, string CshopNameItemd)
        {
            Thread.Sleep(10000);
            int HourNumber = 0;
            PostServer.Getcookie = FPPcok.ToString();
            string Key = "uv";
            //空调扇 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50017589&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //蒸气刷 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50008553&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            //女童装 string KKurl = "https://sycm.taobao.com/ipoll/live/industry/showTopItems.json?cateId=50010518&cateLevel=2&device=0&limit=100&page=1&seller=-1&size=50&token=9592cec50&_=1532944703615";
            string KKurl = "";
                KKurl = "https://sycm.taobao.com/mc/rivalItem/analysis/getFlowSource.json?device=2&cateId=" + CcateId + "&rivalItem1Id=" + CItemid + "&dateType=day&dateRange=" + CDateTime + "%7C" + CDateTime + "&indexCode=" + Key + "&orderBy=" + Key + "&order=desc&_=1535785900902&token=";
            
            PostServer.GetHTTPTaobao(KKurl);
            string gHtml = PostServer.GetHtml;
            if (gHtml.IndexOf("出错") > 0)
            {
                ShowInfo("出错:" + CDateTime);
            }
            else
            {
                // ShowInfo(FPPcokk.ToString());
                ShowInfo(KKurl);

                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);


                //string Sqldel = "delete from hqUV  where DateHour=" + HourNumber + " and ItemID='" + CItemid + "' and DItemdate='" + CDateTime + "'";
                //Ms.ExeSQLNonQuery(Sqldel);
                string zone = "";
                //if (Key == "uv")
                //{
                    zone = json["data"].ToString();
                ShowInfo(zone);
                //}
                //if (Key == "payByrCntIndex")
                //{
                //    zone = json["data"].ToString();
                //}
                JArray results = JArray.Parse(zone);

                for (int i = 0; i < results.Count; i++)
                {
                    string shopNameID = "";
                    int Keynumber = 0;
                    int Keynumberb = 0;
                    string Sql = "";

                    //if (Key == "uv")
                    //{
                        shopNameID = results[i]["pageName"]["value"].ToString();
                        Keynumber = int.Parse(results[i]["uv"]["value"].ToString());
                        Sql = "INSERT INTO [hqUVList]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + HourNumber + "," + Keynumber + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    // ShowInfo(shopNameID + "----" + Keynumber);
                    //}
                    //if (Key == "payByrCntIndex")
                    //{

                    //   shopNameID = results[i]["pageName"]["value"].ToString();
                    string fff = results[i]["rivalItem1PayByrCntIndex"]["value"].ToString();
                    ShowInfo(fff);
                    decimal aa = decimal.Parse(fff);
                        ShowInfo(aa.ToString());
                        decimal bb = Math.Round(aa, 0);
                        int CC = int.Parse(bb.ToString());
                        Keynumberb = int.Parse(bb.ToString());
                        int Paycn = poweint(Keynumberb);
                        Sql = "INSERT INTO [hqUVListCUS]([shopName],[DateHour],[HouNumber],[ItemID],[DItemdate])VALUES('" + shopNameID + "'," + CC + "," + Paycn + ",'" + CshopNameItemd + "','" + CDateTime + "')";
                    //}
                    //  ShowInfo(Sql);
                    Ms.ExeSQLNonQuery(Sql);

                }
            }

        }
        public int poweint(int uvpay)
        {
            // x <= 630  y = (0.409x ^ 1.5201)/ 100
            //630 < x <= 1195 y = (0.2484x ^ 1.598)/ 100
            //1195 <= x <= 2050   y = (0.2005x ^ 1.6283)/ 100
            //2050 <= x <= 3130   y = (0.1653x ^ 1.6537)/ 100
            //3130 < x <= 4520    y = (0.1412x ^ 1.6732)/ 100
            //4520 < x <= 6030    y = (0.1253x ^ 1.6875)/ 100
            //6030 < x <= 8050    y = (0.1133x ^ 1.699)/ 100

            double x =0.409;
            double y = 1.5201;
            if (uvpay<=630)
            {
                x = 0.409;
                y = 1.5201;
            }
            if (630<uvpay && uvpay <= 1195)
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
        private void button21_Click(object sender, EventArgs e)
        {
            DateTime BegDate = this.dateTimePicker4.Value;
            DateTime EndDate = this.dateTimePicker3.Value;
            double ts2 = BegDate.Subtract(EndDate).TotalDays;
            string shopNameItemd = ItemID.Text + shopName.Text;
            GetCook();          
            for (int i = 0; i < ts2; i++)
            {
               // getUVListNEW(EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getUVList("uv", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getUVList("payByrCntIndex", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getKeywordList("uv", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getKeywordList("tradeIndex", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
            }
      }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

            DateTime BegDate = this.dateTimePicker4.Value;
            DateTime EndDate = this.dateTimePicker3.Value;
            double ts2 = BegDate.Subtract(EndDate).TotalDays;
            string shopNameItemd = ItemID.Text + shopName.Text;
            GetCook();
            for (int i = 0; i < ts2; i++)
            {
                // getUVListNEW(EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getUVList("uv", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                getUVList("payByrCntIndex", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                //getKeywordList("uv", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
                //getKeywordList("tradeIndex", EndDate.AddDays(i).ToString("yyyy-MM-dd"), cateId.Text, ItemID.Text, shopNameItemd);
            }
        }
    }
 }
