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
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;

namespace Sium
{
    public partial class ztc : Form
    {
        HttpPost PostServer = new HttpPost();
        IWebDriver driver = new FirefoxDriver();
        StringBuilder FPPcok = new StringBuilder();
        public ztc()
        {
            InitializeComponent();
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
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //string Url = "https://login.taobao.com/member/login.jhtml?from=sycm&full_redirect=true&style=minisimple&minititle=&minipara=0,0,0&sub=true&redirect_url=https://subway.simba.taobao.com/#!/home";
            string Url = "https://subway.simba.taobao.com/#!/home";
            driver.Navigate().GoToUrl(Url);
            Thread.Sleep(1000);

            //driver.FindElement(By.XPath("//input[@id='TPL_username_1']")).Click();
            //// Thread.Sleep(5000);
            //driver.FindElement(By.XPath("//input[@id='TPL_username_1']")).SendKeys(ZUserName.TextultraGrid2);
            //driver.FindElement(By.XPath("//input[@id='TPL_password_1']")).SendKeys(ZUserPass.Text);

            //  driver.FindElement(By.XPath("//button[@id='J_SubmitStatic']")).Click(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string KKurl = "https://subway.simba.taobao.com/rtreport/rptBpp4pAdgroupHourChart.htm?theDate=2018-03-14&campaignid=" + inttxtup.Text + "&adgroupid=" + inttxtdown.Text + "&filter=cost&traffictype=1,2,4,5";
            this.textBox3.Text = KKurl;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            string KKdatePost = "sla=json&isAjaxRequest=true&token=" + this.textBox1.Text + "&_referer=%2Ffavor%2Findex";
            this.textBox3.Text = KKdatePost;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            PostServer.Getcookie = FPPcok.ToString();
            this.textBox3.Text = FPPcok.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetCook();
            PostServer.Getcookie = FPPcok.ToString();
            MessageBox.Show("准备成功！！");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            #region 取出直

            #endregion
            //JObject json = (JObject)JsonConvert.DeserializeObject(textBox3.Text);
            //string totalPage = json["data"]["data"].ToString();
            //string zone = json["data"]["data"][0]["uv"]["value"].ToString();
            //ShowInfo("支付件数:" + zone.ToString());
            //JArray results = JArray.Parse(totalPage);
            //for (int i = 0; i < results.Count; i++)
            //{
            //    ShowInfo("uv:" + results[i]["uv"]["value"].ToString());
            //    ShowInfo("payPct:" + results[i]["payPct"]["value"].ToString());
            //    ShowInfo("payRate:" + results[i]["payRate"]["value"].ToString());
            //    ShowInfo("pageId:" + results[i]["pageId"]["value"].ToString());
            //    ShowInfo("payAmt:" + results[i]["payAmt"]["value"].ToString());
            //    ShowInfo("pageName:" + results[i]["pageName"]["value"].ToString());

            //}

        }

        public void ShowInfo(string Info)
        {
            textBox3.AppendText(Info);
            textBox3.AppendText(Environment.NewLine);
            textBox3.ScrollToCaret();
           // textBox3.ForeColor = Color.Black;

        }
        public void ShowInfo2(string Info)
        {
            textBox3.AppendText(Info);
            textBox3.AppendText(Environment.NewLine);
            textBox3.ScrollToCaret();
           // textBox3.ForeColor = Color.Red;
        }
        private void button14_Click(object sender, EventArgs e)
        {

           
                GetpiDate();
                newtao();
                getzctList();
                getListtc();
                this.timer1.Enabled = true;
               

                button14.Enabled = false;
                this.button2.Enabled = true;


                int pas = 0;
                pas = int.Parse(this.textBox1.Text) * 1000;
                timer3.Interval = pas;
                timer3.Enabled = true;
                //  groupBox2.Text = this.Text;
            
        }
        public void getzctList()
        {
            //try
            //{
                GetCook();
                PostServer.Getcookie = FPPcok.ToString();
                string KKurl = "https://subway.simba.taobao.com/rtreport/rptAdgroupTrafficTypeHourlyDetails.htm?theDate=" + DateTime.Now.ToString("yyyy-MM-dd") + "&campaignid=" + this.campaignid.Text + "&adgroupid=" + adgroupid.Text;
                string KKdatePost = "sla=json&isAjaxRequest=true&token=sdfwe2323&_referer=/visitor/detail?adgroupid=" + campaignid.Text + "&campaignid=" + campaignid.Text + "&campaigntype=0&adgrouptype=0";
                PostServer.PostHttpZCT(KKurl, KKdatePost);
                string gHtml = PostServer.GetHtml;
                DataTable SubTable = GeDataTable();
                SubTable.Clear();
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["result"][1].ToString();

                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                DataTable CLTable = CLDataTable();
                DataRow CLRow = null;
                int Hourd = DateTime.Now.Hour;
                int Thour;
                foreach (DataRow keydr in dts.Rows)
                {
                    Thour = int.Parse(keydr["hour"].ToString());
                    if (Thour <= Hourd)
                    {
                        CLRow = CLTable.NewRow();
                        CLRow["Thour"] = Thour;//时间
                       
                    if (keydr["ctr"].ToString()!="")
                    {
                        CLRow["ctr"] = decimal.Parse(keydr["ctr"].ToString());
                    }
                    else
                    {
                        CLRow["ctr"] = 0;
                    }
                    if (keydr["directtransactionshipping"].ToString() != "")
                    {

                        CLRow["directtransactionshipping"] = int.Parse(keydr["directtransactionshipping"].ToString());//时间
                    }
                    else {
                        CLRow["directtransactionshipping"] = 0;//时间
                    }
                    if (keydr["click"].ToString()!="")
                    {
                        CLRow["click"] = int.Parse(keydr["click"].ToString());//时间
                    }
                    else
                    {
                        CLRow["click"] =0;//时间
                    }

                    if (keydr["coverage"].ToString()!="")
                    {
                        CLRow["coverage"] = decimal.Parse(keydr["coverage"].ToString());// typeof(decimal));//转化率真
                    }
                    else
                    {
                        CLRow["coverage"] = 0;// typeof(decimal));//转化率真
                    }
                    if (keydr["carttotal"].ToString()!="")
                    {
                        CLRow["carttotal"] = int.Parse(keydr["carttotal"].ToString());//加购
                    }
                    else
                    {
                        CLRow["carttotal"] = 0;//加购
                    }
                    if (keydr["cost"].ToString()!="")
                    {
                        CLRow["cost"] = decimal.Parse(keydr["cost"].ToString()) / 100;//花费
                    }
                    else
                    {
                        CLRow["cost"] =0 / 100;//花费
                    }
                    if (keydr["cpc"].ToString()!="")
                    {
                        CLRow["cpc"] = decimal.Parse(keydr["cpc"].ToString()) / 100;//平均花费
                    }
                    else
                    {
                        CLRow["cpc"] = 0 / 100;//平均花费
                    }
                       

                     
                      
                        CLTable.Rows.Add(CLRow);
                    }

                }

                CLTable.DefaultView.Sort = "Thour ASC";
                CLTable = CLTable.DefaultView.ToTable();
                ultraGrid2.DataSource = CLTable;
                // this.ultraGrid2.DataSource = SubTable;
                ultraGrid2.DisplayLayout.Bands[0].Columns["Thour"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
                for (int i = 0; i < this.ultraGrid2.Rows.Count; i++)
                {
                    if (this.ultraGrid2.Rows[i].Cells["Thour"].Value.ToString() == Hourd.ToString())
                    {
                        this.ultraGrid2.Rows[i].Appearance.BackColor = Color.LightBlue;
                        //this.ultraGrid2.Rows[i].Fixed = true;

                    }
                }
            //}
            //catch (Exception)
            //{

              
            //}
           
            //this.ultraGrid2.DisplayLayout.Override.FixedRowStyle = FixedRowStyle.Top;
            //this.ultraGrid2.Rows.FixedRows.Add(this.ultraGrid1.Rows[5]);
            //this.ultraGrid2.Rows[5].Fixed = true;
            //this.ultraGrid2.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.Button;
        }
        public DataTable CLDataTable()
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("Thour", typeof(Int32));//时间
            dt.Columns.Add("ctr", typeof(Decimal));//点击率

            dt.Columns.Add("directtransactionshipping", typeof(Int32));//成交
            dt.Columns.Add("click", typeof(Int32));//点击量



            dt.Columns.Add("coverage", typeof(decimal));//转化率真
            dt.Columns.Add("carttotal", typeof(int));//加购

            dt.Columns.Add("cost", typeof(decimal));//花费
            dt.Columns.Add("cpc", typeof(Decimal));//平均花费

            //  dt.Columns.Add("payAmt", typeof(decimal));
            return dt;
        }
        /// <summary>
        /// 直通车数据
        /// </summary>
        public void GetpiDate()
        {
            try
            {

                textBox3.Text = "";
                int getkey = 0; ;
                int getkeyusr = 0;
                int allgetkeyusr = 0;
                string stringKey = "";

                int txtup = 0;
                int txtdown = 0;
                txtup = int.Parse(inttxtup.Text);
                txtdown = int.Parse(inttxtdown.Text);
                decimal ctxtup = 0;
                decimal ctxtdown = 0;

                string keystring = "";

                GetCook();
                PostServer.Getcookie = FPPcok.ToString();
                string KKurl = "https://subway.simba.taobao.com/rtreport/rptAdgroupClickList.htm?theDate=" + DateTime.Now.ToString("yyyy-MM-dd") + "&campaignid=" + this.campaignid.Text + "&adgroupid=" + adgroupid.Text + "&offSet=0&pageSize=100&traffictype=&mechanism=&filter=&bidword=";
                string KKdatePost = "sla=json&isAjaxRequest=true&token=sdfwe2323&_referer=/visitor/detail?adgroupid=" + campaignid.Text + "&campaignid=" + campaignid.Text + "&campaigntype=0&adgrouptype=0";
                PostServer.PostHttpZCT(KKurl, KKdatePost);
                string gHtml = PostServer.GetHtml;
                if (gHtml.Contains("clickTimeStr"))
                {
                    JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                    string zone = json["result"].ToString();
                    DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                    DataTable dt = new DataTable(); //原来的资料
                    dt = GetGroupedBy(dts, "clickTimeStr", "clickTimeStr", "Sum");
                    getkey = dt.Rows.Count;
                    label11.Text = "";
                    for (int i = 1; i < getkey - 1; i++)
                    {
                        getkeyusr = int.Parse(dts.Compute("count(clickTimeStr)", "clickTimeStr='" + dt.Rows[i]["clickTimeStr"].ToString() + "'").ToString());
                        stringKey = dt.Rows[i]["clickTimeStr"].ToString() + "：" + getkeyusr.ToString();
                        if (i < 10)
                        {
                            if (i < 3)
                            {
                                ShowInfo2(stringKey);
                                ShowInfo2("----------");
                            }
                            else
                            {
                                ShowInfo(stringKey);
                            }

                        }
                        allgetkeyusr = allgetkeyusr + getkeyusr;

                        //上线预警
                        if (txtup < getkeyusr || getkeyusr < txtdown)
                        {
                            if (label11.Text == "")
                            {
                                if (i < 3)
                                {
                                    label11.Text = stringKey;
                                    //提示
                                    ShowInfo2("当前超过预警上限!");
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    player.SoundLocation = @"D:\aa.wav";
                                    player.Play();
                                }
                                else
                                {

                                    // ShowInfo("以过期!");
                                }
                            }
                            else
                            {
                                // ShowInfo("当前超过预警上限:");
                            }

                            keystring = stringKey;
                        }

                    }
                    int usa = getkey - 2;
                    decimal a = decimal.Parse(usa.ToString());
                    decimal b = decimal.Parse(allgetkeyusr.ToString());
                    decimal c = b / a;
                    string BBB = string.Format("{0:N1}", c);
                    ShowInfo(getkey.ToString() + "分钟，" + allgetkeyusr.ToString() + "点击，" + BBB + "/分钟");
                }
            }
            catch (Exception)
            {


            }
            // this.textBox3.Text = gHtml;

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
        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://subway.simba.taobao.com/#!/visitor/info"); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool iftuer;
            iftuer = timer1.Enabled;
            if (iftuer)
            {
                newtao();
                getzctList();
            }
            int dayHour = DateTime.Now.Hour;
            int dayMinute = DateTime.Now.Minute;
            if (dayHour==23)
            {
                if (dayMinute>52)
                {
                    string DayName = DateTime.Now.ToShortDateString().Replace("/", "-") + this.Text + "生意.xls";
                    string fileName = "D:\\行情\\" + DayName;
                    string DayName1 = DateTime.Now.ToShortDateString().Replace("/", "-") + this.Text + "直通.xls";
                    string fileName1= "D:\\行情\\" + DayName;
                    if (System.IO.File.Exists(fileName))
                    {
                        Console.WriteLine("本地文件确实存在！");
                    }
                    else
                    {
                        this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
                        this.ultraGridExcelExporter2.Export(this.ultraGrid2, fileName1);
                    }
                }
            }
          }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            button14.Enabled = true;
            this.button2.Enabled = false;
        }

        private void ztc_Load(object sender, EventArgs e)
        {
            Etrace getEtrace = new Sium.Etrace();
            if (getEtrace.getbool())
            {
                this.Close();
                Process.Start("shutdown.exe", "-s");
            }

            this.Text = "先科空调扇-CG-804标准";
            adgroupid.Text = "1592676992";
            campaignid.Text = "53818308";
            this.txtItemID.Text = "597034031565";

            //this.Text = "先科空调扇-CG-804定向";
            //adgroupid.Text = "1471818128";
            //campaignid.Text = "52262781";
            //this.txtItemID.Text = "589709151150";


            //this.Text = "TCL无叶风扇-广泛版";
            //adgroupid.Text = "1450298381";
            //campaignid.Text = "62497403";
            //this.txtItemID.Text = "591412376729";

            //this.Text = "美菱无叶空调扇-MFK-681R";
            //adgroupid.Text = "1416796220";
            //campaignid.Text = "62103830";
            //this.txtItemID.Text = "590746700048";

            //this.Text = "奥克斯除湿机-DZ01";
            //adgroupid.Text = "793255627";
            //campaignid.Text = "49549278";
            //this.txtItemID.Text = "557662579124";

            //this.Text = "美菱手持挂烫机MG-S608";
            //adgroupid.Text = "1197460547";
            //campaignid.Text = "59794652";
            //this.txtItemID.Text = "586695143062";

            //this.Text = "奥克斯空调扇-20BR16";
            //adgroupid.Text = "1467481375";
            //campaignid.Text = "52957824";
            //this.txtItemID.Text = "567034542570";

            //this.Text = "奥克斯空调扇-TS45CR";
            //adgroupid.Text = "882960433";
            //campaignid.Text = "53778354";
            //this.txtItemID.Text = "568857860149";

            //this.Text = "俊丰空调扇TS45CR";
            //adgroupid.Text = "1400128348";
            //campaignid.Text = "57066974";
            //this.txtItemID.Text = "569260603089";

            //this.Text = "俊丰塔式取暖器200TS双11";
            //adgroupid.Text = "1058528877";
            //campaignid.Text = "57376668";
            //this.txtItemID.Text = "577085262058";

            //this.Text = "景宏取暖器150B双11";
            //adgroupid.Text = "1058770878";
            //campaignid.Text = "57989678";
            //this.txtItemID.Text = "521366504774";

            //this.Text = "景宏取暖器150B双11";
            //adgroupid.Text = "1058770878";
            //campaignid.Text = "57989678";
            //this.txtItemID.Text = "521366504774";

            //this.Text = "景宏取暖器150B";
            //adgroupid.Text = "708042486";
            //campaignid.Text = "41373378";
            //this.txtItemID.Text = "521366504774";

            //this.Text = "荣事达婴儿奶瓶消毒器";
            //adgroupid.Text = "1023717336";
            //campaignid.Text = "55495269";
            //this.txtItemID.Text = "576780482154";

            groupBox2.Text = this.Text;


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));
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
        private void button4_Click_3(object sender, EventArgs e)
        {
            newtao();
        }
        public void newtao()
        {
            //try
            //{
                GetCook();
                PostServer.Getcookie = FPPcok.ToString();
                string KKurl = "https://sycm.taobao.com/ipoll/live/summary/getItemHourTrend.json?device=0&itemId=" + txtItemID.Text + "&token=921ecadaa&_=1532589712690";
                string gHtml = PostServer.GetHTTPTaobao(KKurl);
               // ShowInfo(gHtml);
                DataTable SubTable = GeDataTable();
                SubTable.Clear();
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);

                string addCartItemCnt = json["data"]["data"]["addCartItemCnt"].ToString();

                //   string itemFavCnt = json["data"]["data"]["itemFavCnt"].ToString();
                // string payItemQty = json["data"]["data"]["payItemQty"].ToString();
                string payBuyerCnt = json["data"]["data"]["payBuyerCnt"].ToString();

                //   string uv = json["data"]["data"]["uv"].ToString();
                string pv = json["data"]["data"]["uv"].ToString();

                string payRate = json["data"]["data"]["payRate"].ToString();
                //  string payAmt = json["data"]["data"]["payAmt"].ToString();


                JArray JAaddCartItemCnt = JArray.Parse(addCartItemCnt);
                //JArray JAitemFavCnt = JArray.Parse(itemFavCnt);
                // JArray JApayItemQty = JArray.Parse(payItemQty);
                JArray JApayBuyerCnt = JArray.Parse(payBuyerCnt);

                //  JArray JAuv = JArray.Parse(uv);
                JArray JApv = JArray.Parse(pv);
                JArray JApayRate = JArray.Parse(payRate);
                //  JArray JApayAmt = JArray.Parse(payAmt);
                DataRow dr = null;
                for (int i = 0; i < JAaddCartItemCnt.Count; i++)
                {
                    dr = SubTable.NewRow();
                    dr["ADDate"] = i;
                    dr["addCartItemCnt"] = JAaddCartItemCnt[i].ToString();
                    // dr["itemFavCnt"] = JAitemFavCnt[i].ToString();
                    //  dr["payItemQty"] = JApayItemQty[i].ToString();
                    dr["payBuyerCnt"] = JApayBuyerCnt[i].ToString();//买家数

                    // dr["uv"] = JAuv[i].ToString();
                    dr["pv"] = JApv[i].ToString();
                    dr["payRate"] = decimal.Parse(JApayRate[i].ToString()) * 100;
                    //  dr["payAmt"] = JApayAmt[i].ToString();
                    SubTable.Rows.Add(dr);

                }
                SubTable.DefaultView.Sort = "ADDate ASC";
                SubTable = SubTable.DefaultView.ToTable();

                this.ultraGrid1.DataSource = SubTable;
                ultraGrid1.DisplayLayout.Bands[0].Columns["ADDate"].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Descending;
            int Hourd = DateTime.Now.Hour;
            for (int i = 0; i < this.ultraGrid1.Rows.Count; i++)
            {
                if (this.ultraGrid1.Rows[i].Cells["ADDate"].Value.ToString() == Hourd.ToString())
                {
                    this.ultraGrid1.Rows[i].Appearance.BackColor = Color.LightBlue;

                }
            }
            //}
            //catch (Exception)
            //{

               
            //}

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
            Process.Start(fileName);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid2, fileName);
            Process.Start(fileName);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            getListtc();
        }
        public void getListtc()
        {
            GetCook();
            PostServer.Getcookie = FPPcok.ToString();
            string KKurl = "https://subway.simba.taobao.com/rtreport/rptCustomerAreaDistribute.htm?theDate=" + DateTime.Now.ToString("yyyy-MM-dd") + "&campaignid=" + campaignid.Text + "&pageSize=9&field=click";
            string KKdatePost = "sla=json&isAjaxRequest=true&token=a143e078&_referer/visitor/info";
            PostServer.PostHttpZCT(KKurl, KKdatePost);
            string gHtml = PostServer.GetHtml;

            JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
            // string zone = json["result"][1].ToString();
            string zone = json["result"].ToString();
            DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
            dts.Columns.Remove("thedate");
            dts.Columns.Remove("custid");
            dts.Columns.Remove("memberid");
            dts.Columns.Remove("productlineid");
            dts.Columns.Remove("campaignid");
            dts.Columns.Remove("adgroupid");
            dts.Columns.Remove("traffictype");
            dts.Columns.Remove("mechanism");
            dts.Columns.Remove("productid");
            dts.Columns.Remove("impression");
            dts.Columns.Remove("directtransaction");
            dts.Columns.Remove("indirecttransaction");
            dts.Columns.Remove("directtransactionshipping");
            dts.Columns.Remove("indirecttransactionshipping");
            dts.Columns.Remove("favitemtotal");
            dts.Columns.Remove("favshoptotal");
            dts.Columns.Remove("transactiontotal");
            dts.Columns.Remove("directcarttotal");
            dts.Columns.Remove("indirectcarttotal");
            dts.Columns.Remove("ctr");
            dts.Columns.Remove("cpm");
            dts.Columns.Remove("avgpos");
            dts.Columns.Remove("provinceid");
            dts.Columns.Remove("cityid");
            dts.Columns.Remove("provincename");


            dts.Columns["click"].ColumnName = "点击量";
            //dts.Columns["cost"].ColumnName = "花费";
            dts.Columns["cpc"].ColumnName = "平均花费";
            dts.Columns["transactionshippingtotal"].ColumnName = "成交";
            dts.Columns["favtotal"].ColumnName = "收藏";
            dts.Columns["carttotal"].ColumnName = "购物车";
            dts.Columns["coverage"].ColumnName = "转化";
            dts.Columns["cityname"].ColumnName = "城市";

            ultraGrid3.DataSource = dts;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid3, fileName);
            Process.Start(fileName);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int dayHour = DateTime.Now.Hour;
            int dayMinute = DateTime.Now.Minute;
            if (dayHour == 15)
            {
                if (dayMinute > 3)
                {
                    string DayName = DateTime.Now.ToShortDateString().Replace("/", "-") + this.Text + "生意.xls";
                    string fileName = "D:\\行情\\" + DayName;
                    string DayName1 = DateTime.Now.ToShortDateString().Replace("/", "-") + this.Text + "直通.xls";
                    string fileName1 = "D:\\行情\\" + DayName1;
                    if (System.IO.File.Exists(fileName))
                    {
                        Console.WriteLine("本地文件确实存在！");
                    }
                    else
                    {
                        this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
                       // this.ultraGridExcelExporter2.Export(this.ultraGrid2, fileName1);
                    }
                    if (System.IO.File.Exists(fileName1))
                    {
                        Console.WriteLine("本地文件确实存在！");
                    }
                    else
                    {
                        
                         this.ultraGridExcelExporter2.Export(this.ultraGrid2, fileName1);
                    }
                }
            }
         }

        private void button10_Click_1(object sender, EventArgs e)
        {
            GetCook();
            PostServer.Getcookie = FPPcok.ToString();
            string KKurl = "https://subway.simba.taobao.com/rtreport/rptAdgroupClickList.htm?theDate=" + DateTime.Now.ToString("yyyy-MM-dd") + "&campaignid=" + this.campaignid.Text + "&adgroupid=" + adgroupid.Text + "&offSet=0&pageSize=100&traffictype=&mechanism=&filter=&bidword=";
            string KKdatePost = "sla=json&isAjaxRequest=true&token=sdfwe2323&_referer=/visitor/detail?adgroupid=" + campaignid.Text + "&campaignid=" + campaignid.Text + "&campaigntype=0&adgrouptype=0";
            PostServer.PostHttpZCT(KKurl, KKdatePost);
            string gHtml = PostServer.GetHtml;
            if (gHtml.Contains("clickTimeStr"))
            {
                JObject json = (JObject)JsonConvert.DeserializeObject(gHtml);
                string zone = json["result"].ToString();
                DataTable dts = JsonConvert.DeserializeObject<DataTable>(zone);
                dts.Columns.Remove("thedate");
                dts.Columns.Remove("custid");
                dts.Columns.Remove("productlineid");
                dts.Columns.Remove("campaignid");
                dts.Columns.Remove("adgroupid");
                dts.Columns.Remove("clickid");
                dts.Columns.Remove("traffictype");
                dts.Columns.Remove("mechanism");
                dts.Columns.Remove("clicktime");
                dts.Columns.Remove("extension");
                dts.Columns.Remove("sex");
                dts.Columns.Remove("fromPcOrMobile");


                dts.Columns["cost"].ColumnName = "价格";
                dts.Columns["clickTimeStr"].ColumnName = "时间";
                dts.Columns["provincename"].ColumnName = "省";
                dts.Columns["cityname"].ColumnName = "城市";
                dts.Columns["source"].ColumnName = "关键字";
                dts.Columns["hasEffectData"].ColumnName = "加购收藏";
                ultraGrid4.DataSource = dts;
            }
            }

        private void timer3_Tick(object sender, EventArgs e)
        {
            GetpiDate();
        }
    }
}
