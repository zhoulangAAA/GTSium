using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using DataAccessLayer.DataAccess;
using System.Collections;
using System.Threading;

namespace Sium
{
    public partial class Webinsert : Form
    {
        SQLServer Ms = new SQLServer();
        public Webinsert()
        {
            InitializeComponent();
        }

        private void Webinsert_Load(object sender, EventArgs e)
        {
            ShowInfo(Ms.ConnectionString);
            
        }
        /// <summary>
        /// 进货单打印
        /// </summary>
        /// <param name="ssql"></param>
        /// <returns></returns>
        public bool JHinto(int category_id, string title, string zhaiyao, string content, string add_time, string zhuzai,string imgRue)
        {

            string gsql = "insert into dt_article(channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,groupids_view,vote_id,is_top,is_red,is_hot,is_slide,is_sys,is_msg,user_name,add_time,update_time)values(1," + category_id + ",'','" + title + "','','"+ imgRue + "','" + title + "','','','" + zhaiyao + "','" + content + "',99,0,0,'',0,0,0,0,0,1,1,'admin','" + add_time + "',NULL)";
            int PU = Ms.IntExeSQLNonQuery(gsql);
            string Sql = "insert into dt_article_attribute_value([article_id],[source],[author])values(" + PU + ",'" + zhuzai + "','" + zhuzai + "')";
            return Ms.ExeSQLNonQuery(Sql);
           // Ms.c
        }
        private string GetPageData(string url)
        {

            //ge.DownloadString
            System.Net.HttpWebRequest _request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.WebResponse _response = _request.GetResponse(); ;
            System.IO.StreamReader oStreamRd = new System.IO.StreamReader(_response.GetResponseStream(),
            System.Text.Encoding.GetEncoding("gbk"));//不同站点根据不同编码读取[utf-8,GB2312,gbk]
            return oStreamRd.ReadToEnd();
        }
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
        private void button1_Click(object sender, EventArgs e)
        {
            string soudoc = "";
            string URL = textBox1.Text;
            int BegP = int.Parse(this.textBox2.Text);
            int EndP = int.Parse(this.textBox3.Text);
            string strUrl = "";
            for (int j = EndP; j > BegP; j--)
            {
                strUrl = URL + j.ToString() + textBox4.Text;
                soudoc = GetPageData(strUrl);//获取页面html     
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(soudoc);
                HtmlNode getNode = doc.DocumentNode;
                HtmlNode[] aNode = getNode.SelectNodes("//dl/dt/h3/a").ToArray();
                string head_temp = "";
                for (int i = 0; i < aNode.Length; i++)
                {

                    //  textBox5.Text += aNode[i].Attributes["href"].Value.ToString() + "\r\n";
                    string Listsoudoc = "";
                    Listsoudoc = GetPageData(aNode[i].Attributes["href"].Value.ToString());//获取页面html     
                    HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
                    listdoc.LoadHtml(Listsoudoc);
                    HtmlNode listgetNode = listdoc.DocumentNode;
                    //标题
                    HtmlNode getNodees = listgetNode.SelectSingleNode("//div[2]/h1");
                    //  HtmlNode[] T_zhugetNodees = listgetNode.CssSelect("div.title_zuo").ToArray();
                    //作者
                    HtmlNode getNodees2 = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/a");
                    //日期
                    HtmlNode getNodeestime = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/span");
                    //分类
                    //  HtmlNode getNodees3 = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/keyword");

                    //正文
                    HtmlNode getNodeescount = listgetNode.SelectSingleNode("//div[2]/div[4]");


                    string stcou = getNodeescount.InnerHtml.Replace("'", "");


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
                                //    this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                                string imgName = imgu.ToString().Substring(imgu.ToString().LastIndexOf("/") + 1);


                                getimg.Attributes["src"].Value = "/images/" + imgName;
                                SaveImageFromWeb(imgu, "D:\\DTcms\\DTcms.Web\\images\\");
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


                    //  this.textBox5.Text = Pek;
                    string T_Tit = getNodees.InnerText;
                    if (getNodees2 != null)
                    {
                        //JHinto(int.Parse(this.comboBox1.SelectedValue.ToString()), T_Tit, T_Tit, Pek, getNodeestime.InnerText, getNodees2.InnerText);
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Listsoudoc = "";
            Listsoudoc = GetPageData("http://www.siilu.com/20170611/234712.shtml");//获取页面html     
            HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
            listdoc.LoadHtml(Listsoudoc);
          
            HtmlNode listgetNode = listdoc.DocumentNode;
            //标题
            HtmlNode getNodees = listgetNode.SelectSingleNode("//h1[@class='titleh1']");
            //  HtmlNode[] T_zhugetNodees = listgetNode.CssSelect("div.title_zuo").ToArray();
            //作者
            HtmlNode getNodees2 = listgetNode.SelectSingleNode("//div[@class='title_zuo']/a");
            //日期
            HtmlNode getNodeestime = listgetNode.SelectSingleNode("//div[@class='title_zuo']/span");
            //分类
            //  HtmlNode getNodees3 = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/keyword");

            //正文
            HtmlNode getNodeescount = listgetNode.SelectSingleNode("//div[@class='scrap_div']");
            // HtmlNode[] getNodeescountsss = listgetNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[4]/a").ToArray();
            string cdoc = getNodeescount.InnerHtml;
            HtmlAgilityPack.HtmlDocument listdoc2 = new HtmlAgilityPack.HtmlDocument();
            listdoc2.LoadHtml(cdoc);
            HtmlNode cgetdco = listdoc2.DocumentNode;
            string Pek = cgetdco.InnerHtml;
            HtmlNode[] getNodeescounse = cgetdco.SelectNodes("//strong").ToArray();
            HtmlNode[] getNodeescounlink = cgetdco.SelectNodes("//img").ToArray();
            HtmlNode[] getNodeescounlinka = cgetdco.SelectNodes("//a").ToArray();
            for (int i = 0; i < getNodeescounse.Length; i++)
            {
                Pek = Pek.Replace(getNodeescounse[i].OuterHtml, "");
            }
            for (int i = 0; i < getNodeescounlink.Length; i++)
            {
                string pkk = getNodeescounlink[i].ParentNode.OuterHtml;
                HtmlNode getimg = getNodeescounlink[i];

                string imgu = getimg.Attributes["src"].Value.ToString();
                //    this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                string imgName = imgu.ToString().Substring(imgu.ToString().LastIndexOf("/") + 1);


                getimg.Attributes["src"].Value = "/images/" + imgName;
                SaveImageFromWeb(imgu, "D:\\images\\");
                Pek = Pek.Replace(pkk, getimg.OuterHtml);
                // this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                // getNodeescounlink[i].Attributes["src"].Value = "/images/" + imgName;
            }

            for (int i = 0; i < getNodeescounlinka.Length; i++)
            {
                Pek = Pek.Replace(getNodeescounlinka[i].OuterHtml, "");
                //    this.textBox5.Text += getNodeescounlink[i].ParentNode.OuterHtml;
                //  SaveImageFromWeb(getNodeescounlink[i].Attributes["src"].Value.ToString(), "C:\\test\\");
            }

            //连接
            //HtmlNode[] getNodeeslink = listgetNode.SelectNodes("//div[2]/div[4]/p").ToArray();

            //  string ggg = "";
            //  for (int i = 0; i < getNodeeslink.Length; i++)
            // {
            //     if(getNodeeslink.is
            //  }

            //string stcou = getNodeescount.InnerHtml.Replace(getNodeeslink.InnerHtml, "");
            Pek = Pek.Replace("思路网", "TP电商");
            Pek = Pek.Replace("tougao@siilu.com", "85841017@qq.com");
            ShowInfo(getNodees.InnerText);

            ShowInfo(getNodees2.InnerText);
            ShowInfo(Pek);

            ShowInfo(getNodeestime.InnerText);
        }
        public void ShowInfo(string Info)
        {
            textBox5.AppendText(Info);
            textBox5.AppendText(Environment.NewLine);
            textBox5.ScrollToCaret();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable tblDatas = new DataTable("Datas");
            tblDatas.Columns.Add("pUrl", Type.GetType("System.String"));
            tblDatas.Columns.Add("pImg", Type.GetType("System.String"));
            tblDatas.Columns.Add("Description", Type.GetType("System.String"));

          
            for (int i =int.Parse(textBox2.Text); i < int.Parse(textBox3.Text); i++)
            {
                
                string Listsoudoc = "";
                string SUrl = this.textBox1.Text + i.ToString() + this.textBox4.Text;
                ShowInfo(SUrl);Thread.Sleep(2000);
                Listsoudoc = GetPageData(SUrl);//获取页面html     
                HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
                listdoc.LoadHtml(Listsoudoc);
                HtmlNode listgetNode = listdoc.DocumentNode;
                HtmlNode[] getNodeescounse = listgetNode.SelectNodes("//dl[@class = 'cons_zhaiyao']/dd/h3/a").ToArray();
                HtmlNode[] getNodimg= listgetNode.SelectNodes("//dl[@class = 'cons_zhaiyao']/dt/a/img").ToArray();
                HtmlNode[] getNodDesc = listgetNode.SelectNodes("//dl[@class='cons_zhaiyao']/dd/p").ToArray();
                for (int j = 0; j < getNodeescounse.Length; j++)
                {
                    HtmlNode getimg = getNodeescounse[j];
                    string imUrl = getimg.Attributes["href"].Value.ToString();
                    string imImg = getNodimg[j].Attributes["src"].Value.ToString();
                    string imDes = getNodDesc[j].InnerText;
                    DataRow newRow;
                    newRow = tblDatas.NewRow();
                    newRow["pUrl"] = imUrl;
                    newRow["pImg"] = imImg;
                    newRow["Description"] = imDes;
                    tblDatas.Rows.Add(newRow);
                }
                Thread.Sleep(3000);
            }
           
            //foreach (DictionaryEntry de in ht)
            //{
            //    ShowInfo(de.Key+"---"+ de.Value);
            //}
            InsertWeb(tblDatas);
        }
        public void InsertWeb(DataTable tblDatas)
        {
            for (int i = 0; i < tblDatas.Rows.Count; i++)
              {
                string Listsoudoc = "";
                Listsoudoc = GetPageData(tblDatas.Rows[i]["pUrl"].ToString());//获取页面html     
                HtmlAgilityPack.HtmlDocument listdoc = new HtmlAgilityPack.HtmlDocument();
                listdoc.LoadHtml(Listsoudoc);
                HtmlNode listgetNode = listdoc.DocumentNode;
                //标题
                HtmlNode getNodees = listgetNode.SelectSingleNode("//h1[@class='titleh1']");
                //  HtmlNode[] T_zhugetNodees = listgetNode.CssSelect("div.title_zuo").ToArray();
                //作者
                HtmlNode getNodees2 = listgetNode.SelectSingleNode("//div[@class='title_zuo']/a");
                //日期
                HtmlNode getNodeestime = listgetNode.SelectSingleNode("//div[@class='title_zuo']/span");
                //分类
                //  HtmlNode getNodees3 = listgetNode.SelectSingleNode("//div[3]/div[2]/div[2]/div[1]/keyword");

                //正文
                HtmlNode getNodeescount = listgetNode.SelectSingleNode("//div[@class='scrap_div']");


                string stcou = getNodeescount.InnerHtml.Replace("'", "");


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
                Pek = Pek.Replace("思路网", "TP电商");
                Pek = Pek.Replace("tougao@siilu.com", "759007913@qq.com");

                //  this.textBox5.Text = Pek;
                string T_Tit = getNodees.InnerText;
                if (getNodees2 != null)
                {
                    ShowInfo(T_Tit);
                   
                    ShowInfo(getNodees2.InnerText);
                    ShowInfo(Pek);

                    ShowInfo(getNodeestime.InnerText);

                    //, T_Tit, Pek, getNodeestime.InnerText, getNodees2.InnerText);;
                  JHinto(6, T_Tit, tblDatas.Rows[i]["Description"].ToString(), Pek, getNodeestime.InnerText, getNodees2.InnerText, tblDatas.Rows[i]["pImg"].ToString());
                    Thread.Sleep(3000);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Sql = "SELECT  [id],[title]  FROM [dbo].[dt_article_category] where parent_id=6";
            this.comboBox1.DataSource = Ms.runSQLDataSet(Sql, "seef").Tables[0];
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.ValueMember = "id";
        }
    }
}
