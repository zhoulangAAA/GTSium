using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using DataAccessLayer.DataAccess;
namespace Sium
{
    public partial class Form1 : Form
    {
        IWebDriver driver = new FirefoxDriver();
        SQLServer Ms = new SQLServer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            DataTable tblDatas = new DataTable("Datas");
            tblDatas.Columns.Add("pUrl", Type.GetType("System.String"));
            tblDatas.Columns.Add("pImg", Type.GetType("System.String"));
            tblDatas.Columns.Add("Description", Type.GetType("System.String"));


            driver.Navigate().GoToUrl(this.textBox1.Text);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            for (int i = 0; i <2; i++)
            {
                Thread.Sleep(3000);
               
              
                var aa = driver.FindElements(By.XPath("//div[@class='item-right']/h3/a"));
                var bb = driver.FindElements(By.XPath("//div[@class='item-left']/a/img"));
                var cc = driver.FindElements(By.XPath("//div[@class='item-desc']/a"));
                for (int k = 0; k < aa.Count; k++)
                {
                   // HtmlNode getimg = getNodeescounse[j];
                    string imUrl = aa[k].GetAttribute("href");
                    string imImg = bb[k].GetAttribute("src");
                    string imDes = cc[k].Text;
                    DataRow newRow;
                    newRow = tblDatas.NewRow();
                    newRow["pUrl"] = imUrl;
                    newRow["pImg"] = imImg;
                    newRow["Description"] = imDes;
                    tblDatas.Rows.Add(newRow);
                }
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//a[@class = 'item J_Item next']")).Click();
            }
            InsertWeb(tblDatas);
            //for (int j = 0; j <5; j++)
            //{
            //    driver.Navigate().GoToUrl(a2[j].ToString());
            //    IJavaScriptExecutor JS2 = (IJavaScriptExecutor)driver;
            //    JS2.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            //    Thread.Sleep(3000);
            //    HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
            //    listdoc.LoadHtml(driver.PageSource);
            //    HtmlNode listgetNode = listdoc.DocumentNode;
            //    HtmlNode getNodees = listgetNode.SelectSingleNode("//div[@class='article-body']");
            //    string Pek = getNodees.InnerHtml;
            //    if (getNodees.SelectNodes(".//img") != null)
            //    {
            //        HtmlNode[] getNodeescounlink = getNodees.SelectNodes(".//img").ToArray();

            //        for (int k = 0; k < getNodeescounlink.Length; k++)
            //        {
            //            string pkk = getNodeescounlink[k].ParentNode.OuterHtml;
            //            HtmlNode getimg = getNodeescounlink[k];

            //            if (getimg.Attributes["src"] != null)
            //            {
            //                string imgu = getimg.Attributes["src"].Value.ToString();
            //                //    this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
            //                string imgName = imgu.ToString().Substring(imgu.ToString().LastIndexOf("/") + 1);


            //                getimg.Attributes["src"].Value = "/images/" + imgName;
            //                SaveImageFromWeb("https:"+imgu, "D:\\images\\");
            //                Pek = Pek.Replace(pkk, getimg.OuterHtml);
            //            }
            //            // this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
            //            // getNodeescounlink[i].Attributes["src"].Value = "/images/" + imgName;
            //        }

            //    }
            //    ShowInfo(Pek);
            //    Thread.Sleep(5000);
            //}
        }
        public void InsertWeb(DataTable tblDatas)
        {
            for (int i = 0; i < tblDatas.Rows.Count; i++)
            {
                string Listsoudoc = "";
                driver.Navigate().GoToUrl(tblDatas.Rows[i]["pUrl"].ToString());
                IJavaScriptExecutor JS2 = (IJavaScriptExecutor)driver;
                JS2.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                Thread.Sleep(3000);
                HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
                listdoc.LoadHtml(driver.PageSource);
                HtmlNode listgetNode = listdoc.DocumentNode;
                //标题
                HtmlNode getNodees = listgetNode.SelectSingleNode("//div[@class='article-header']/h3");
                //  HtmlNode[] T_zhugetNodees = listgetNode.CssSelect("div.title_zuo").ToArray();
                //作者
                HtmlNode getNodees2 = listgetNode.SelectSingleNode("//div[@class='article-author']/a");
                //日期
                HtmlNode getNodeestime = listgetNode.SelectSingleNode("//span[@class='date']");
                //分类
                //  HtmlNode getNodees3 = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/keyword");

                //正文
                HtmlNode getNodeescount = listgetNode.SelectSingleNode("//div[@class='article-body']");


              string stcou = getNodeescount.InnerHtml;


                HtmlAgilityPack.HtmlDocument listdoc2 = new HtmlAgilityPack.HtmlDocument();
                listdoc2.LoadHtml(stcou);
                HtmlNode cgetdco = listdoc2.DocumentNode;
                string Pek = cgetdco.InnerHtml;
               
                if (cgetdco.SelectNodes("//strong") != null)
                {
                    HtmlNode[] getNodeescounse = cgetdco.SelectNodes("//strong").ToArray();
                    for (int p = 0; p < getNodeescounse.Length; p++)
                    {
                        Pek = Pek.Replace(getNodeescounse[p].OuterHtml, "");
                    }
                }
                if (cgetdco.SelectNodes("//img") != null)
                {
                    HtmlNode[] getNodeescounlink = cgetdco.SelectNodes("//img").ToArray();

                    for (int k = 0; k < getNodeescounlink.Length; k++)
                    {
                        string pkk = getNodeescounlink[k].ParentNode.OuterHtml;
                        HtmlNode getimg = getNodeescounlink[k];

                        if (getimg.Attributes["src"] != null)
                        {
                            string imgu = getimg.Attributes["src"].Value.ToString();
                            imgu = imgu.Replace("//img.alicdn.com", "https://img.alicdn.com");
                            //    this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                            string imgName = imgu.ToString().Substring(imgu.ToString().LastIndexOf("/") + 1);


                            getimg.Attributes["src"].Value = "/kimages/" + imgName;
                            SaveImageFromWeb(imgu, "G:\\DTcms\\DTcms\\DTcms.Web\\kimages\\");
                            Pek = Pek.Replace(pkk, getimg.OuterHtml);
                        }
                        // this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                        // getNodeescounlink[i].Attributes["src"].Value = "/images/" + imgName;
                    }

                }

                if (cgetdco.SelectNodes("//a") != null)
                {
                    HtmlNode[] getNodeescounlinka = cgetdco.SelectNodes("//a").ToArray();

                    for (int a = 0; a < getNodeescounlinka.Length; a++)
                    {
                        Pek = Pek.Replace(getNodeescounlinka[a].ParentNode.OuterHtml, "");

                    }
                }
                
               //Pek = Pek.Replace("//img.alicdn.com", "https://img.alicdn.com");
          //      Pek = Pek.Replace("tougao@siilu.com", "759007913@qq.com");

                //  this.textBox5.Text = Pek;
                string T_Tit = getNodees.InnerText;
             
                    ShowInfo(T_Tit);
                ShowInfo(getNodeestime.InnerText);
                // ShowInfo(getNodees2.InnerText);
                ShowInfo(Pek);

                   

                    //, T_Tit, Pek, getNodeestime.InnerText, getNodees2.InnerText);;
                  JHinto(6, T_Tit, tblDatas.Rows[i]["Description"].ToString(), Pek, getNodeestime.InnerText, "", tblDatas.Rows[i]["pImg"].ToString());
                

            }
        }
        public bool JHinto(int category_id, string title, string zhaiyao, string content, string add_time, string zhuzai, string imgRue)
        {

            string gsql = "insert into dt_article(channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,groupids_view,vote_id,is_top,is_red,is_hot,is_slide,is_sys,is_msg,user_name,add_time,update_time)values(1," + category_id + ",'','" + title + "','','" + imgRue + "','" + title + "','','','" + zhaiyao + "','" + content + "',99,0,0,'',0,0,0,0,0,1,1,'admin','" + add_time + "',NULL)";
            int PU = Ms.IntExeSQLNonQuery(gsql);
            string Sql = "insert into dt_article_attribute_value([article_id],[source],[author])values(" + PU + ",'" + zhuzai + "','" + zhuzai + "')";
            return Ms.ExeSQLNonQuery(Sql);
        }
        public  void ShowInfo(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }
          //保存远程图片函数
        public int SaveImageFromWeb(string imgUrl, string path)
        {
            string imgName = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("/") + 1);
            path = path + "\\" + imgName;
            string defaultType = ".jpg";
            string[] imgTypes = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string imgType = imgUrl.ToString().Substring(imgUrl.ToString().LastIndexOf("."));
            foreach (string it in imgTypes)
            {
                if (imgType.ToLower().Equals(it))
                    break;
                if (it.Equals(".bmp"))
                    imgType = defaultType;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imgUrl);
                request.UserAgent = "Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; Natas.Robot)";
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                if (response.ContentType.ToLower().StartsWith("image/"))
                {
                    byte[] arrayByte = new byte[1024];
                    int imgLong = (int)response.ContentLength;
                    int l = 0;
                    // CreateDirectory(path);
                    FileStream fso = new FileStream(path, FileMode.Create);
                    while (l < imgLong)
                    {
                        int i = stream.Read(arrayByte, 0, 1024);
                        fso.Write(arrayByte, 0, i);
                        l += i;
                    }
                    fso.Close();
                    stream.Close();
                    response.Close();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (WebException)
            {
                return 0;
            }
            catch (UriFormatException)
            {
                return 0;
            }
        }
    }
}
