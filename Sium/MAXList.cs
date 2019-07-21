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
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using System.Net;
namespace Sium
{
    public partial class MAXList : Form
    {
        IWebDriver driver = new FirefoxDriver();
        StringBuilder FPPcok = new StringBuilder();
        SQLServer Ms = new SQLServer();
        public MAXList()
        {
            InitializeComponent();
            this.Text = System.Configuration.ConfigurationManager.AppSettings["CHCName"];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string Url = "https://login.taobao.com/member/login.jhtml?from=sycm&full_redirect=true&style=minisimple&minititle=&minipara=0,0,0&sub=true&redirect_url=https://subway.simba.taobao.com/#!/home";
            string Url = "https://subway.simba.taobao.com/#!/home";
            driver.Navigate().GoToUrl(Url);
            Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://sycm.taobao.com");
            GetCook();
        }
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
      
      

        private void button4_Click(object sender, EventArgs e)
        {
            DayLit getDc = new Sium.DayLit(FPPcok, System.Configuration.ConfigurationManager.AppSettings["TainID"]);
            getDc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dztc getDc = new Sium.Dztc(FPPcok, System.Configuration.ConfigurationManager.AppSettings["TainID"]);
            getDc.Show();
        }

        private void MAXList_Load(object sender, EventArgs e)
        {

            Etrace getEtrace = new Sium.Etrace();
            if (getEtrace.getbool())
            {
                this.Close();
                Process.Start("shutdown.exe", "-s");
            }
           
                //大盘排行
                groupBox1.Visible = true;
                //竞争监控
                groupBox4.Visible = true;
                //单品监控
                groupBox3.Visible = true;
                string Sqlshop = "select itemid as ID,IDshopName as 店铺 from dp_shop";
                this.ultraGridcnt.DataSource = Ms.runSQLDataSet(Sqlshop, "ss").Tables[0];
           
            
        }

       
        private void ultraGridcnt_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int i = this.ultraGridcnt.ActiveRow.Index;
            int b = this.ultraGridcnt.ActiveCell.Column.Index;
            string id = this.ultraGridcnt.Rows[i].Cells[0].Value.ToString().Trim();
            string IDshopName = this.ultraGridcnt.Rows[i].Cells[1].Value.ToString().Trim();
            // MessageBox.Show(id);
            if (b==0)
            {
                DPindex getDp = new Sium.DPindex(FPPcok, "50012100", IDshopName, id, System.Configuration.ConfigurationManager.AppSettings["TainID"]);
                getDp.Show();
            }
            if (b==1)
            {
                DPList getDp = new Sium.DPList(FPPcok, IDshopName, id, IDshopName);
                getDp.Show();
            }
           

            //hqkeyword getK = new hqkeyword(FPPcok, "50012100", IDshopName, id);
            //getK.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GNumber getK = new GNumber(FPPcok);
            getK.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ONkeyword getK = new ONkeyword(FPPcok);
            getK.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {

                URL = "https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateType=day&pageSize=100&page=1&order=desc&orderBy=payItmCnt&cateId=50017589&deviceType=0&sellerType=-1&propIdStr=5754966&propValueIdStr=126003&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1553498512338&dateRange=2019-05-23|2019-05-23",//URL     必需项   
                Host = "sycm.taobao.com",
                Accept = " */",
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                Method = "get",//URL     可选项 默认为Get
                Referer = "https://sycm.taobao.com/mc/mq/property_insight?activeKey=analyse&cateFlag=2&cateId=50017589&dateType=day&device=0&parentCateId=50012100&sellerType=-1&propertyIds=5754966&propertyValueIds=126003&",
                ContentType = "text/html",
                Cookie = FPPcok.ToString(),
                ResultType = ResultType.String

            };
            item.Header.Add("transit-id", this.textBox1.Text);
            item.Header.Add("Pragma", "no-cache");
            item.Header.Add("Cache-Control", "no-cache");
            item.Header.Add("TE", "Trailers");
            HttpResult result = http.GetHtml(item);
          
            this.textBox2.Text = result.Html;

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HttpPost PostServer = new HttpPost();
            PostServer.Getcookie = FPPcok.ToString();
            PostServer.GetHTTPTaobaoTID("https://sycm.taobao.com/mc/mq/prop/listPropItem.json?dateType=day&pageSize=100&page=1&order=desc&orderBy=payItmCnt&cateId=50017589&deviceType=0&sellerType=-1&propIdStr=5754966&propValueIdStr=126003&indexCode=tradeIndex%2CpayItmCnt%2CpayRateIndex&_=1553498512338&dateRange=2019-05-23|2019-05-23", this.textBox1.Text, "https://sycm.taobao.com/mc/mq/property_insight?activeKey=analyse&cateFlag=2&cateId=50017589&dateType=day&device=0&parentCateId=50012100&sellerType=-1&propertyIds=5754966&propertyValueIds=126003&");
            string txpayRateIndex = PostServer.GetHtml;
            this.textBox2.Text = txpayRateIndex;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = FPPcok.ToString(); 
        }
    }
}
