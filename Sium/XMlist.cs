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
    public partial class XMlist : Form
    {
        IWebDriver driver = new FirefoxDriver();
        StringBuilder FPPcok = new StringBuilder();
        SQLServer Ms = new SQLServer();
        public string[] Y_headname;
        public int abc = 0;
        public int cint=0;
        public XMlist()
        {
            InitializeComponent();
        }
        public void GetURl(string Name, string Pass)
        {
            string Url = "http://m.ximalaya.com/login?fromUri=http%3A%2F%2Fpages.ximalaya.com%2Fcarnival123%2Fpromotion%3FpromotionId%3D932";
            driver.Navigate().GoToUrl(Url);

            // //a[@class = 'fl j-tab ']
            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//a[@class = 'fl j-tab ']")).Click();
            driver.FindElement(By.XPath("//input[@class = 'input-num pdlBig pwl-number']")).SendKeys(Name);
            driver.FindElement(By.XPath("//input[@class = 'input-text pd-reset pwl-pass']")).SendKeys(Pass);

            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//a[@class = 'btn login-register j-login on']")).Click();
            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//div[@class = 'bottom']")).Click();
            //是否弹框
            try
            {
                Thread.Sleep(cint);
                
                    // driver.Navigate().GoToUrl(Url);
                driver.FindElement(By.XPath("//img[@class = 'close']")).Click();
                Thread.Sleep(cint);
                driver.FindElement(By.XPath("//div[@class = 'bottom']")).Click();
            }
            catch (Exception)
            {

               
            }
           
            //if ( != null)
            //{
            //    
            //}

            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//div[@class = 'btn buy logined _oX']")).Click();

            Thread.Sleep(cint);
            string Uname= driver.FindElement(By.XPath("//p[@class = 'name elli']")).Text;

            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//a[@class = 'btn-purchase j-submit']")).Click();

            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//i[@class = 'ic ic-wxpay']")).Click();

            Thread.Sleep(cint);
            driver.FindElement(By.XPath("//a[@class = 'btn btn-primary j-pay']")).Click();

            string UNumber = driver.FindElement(By.XPath("//span[@class = 'order-number']")).Text;
            string Piw = Name + "-" + Pass + "-" + Uname + "-" + UNumber;
            ShowInfo(Piw);

            File.AppendAllText(textBox5.Text + ".txt", "\r\n" + Piw);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Url = "http://m.ximalaya.com/login?fromUri=http%3A%2F%2Fpages.ximalaya.com%2Fcarnival123%2Fpromotion%3FpromotionId%3D932";
            driver.Navigate().GoToUrl(Url);

            // //a[@class = 'fl j-tab ']
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@class = 'fl j-tab ']")).Click();
            driver.FindElement(By.XPath("//input[@class = 'input-num pdlBig pwl-number']")).SendKeys("15944627341");
            driver.FindElement(By.XPath("//input[@class = 'input-text pd-reset pwl-pass']")).SendKeys("Huang6666");

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@class = 'btn login-register j-login on']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class = 'bottom']")).Click();

            
                  Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class = 'btn buy logined _oX']")).Click();

            Thread.Sleep(1000);
            this.Text=driver.FindElement(By.XPath("//p[@class = 'name elli']")).Text;

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@class = 'btn-purchase j-submit']")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//i[@class = 'ic ic-wxpay']")).Click();

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@class = 'btn btn-primary j-pay']")).Click();

            this.button1.Text=driver.FindElement(By.XPath("//span[@class = 'order-number']")).Text;
         //   ShowInfo(data[0].ToString() + "--" + data[0].ToString() + "---" + i.ToString());

        }
        public DataTable NewPayDataTable(string shopName, string KaName, string UANumber, string Number, string PayNumber)
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add(shopName, typeof(DateTime));//时间
            dt.Columns.Add(KaName, typeof(string));//类别
            dt.Columns.Add(UANumber, typeof(decimal));//访客
            dt.Columns.Add(Number, typeof(decimal));//买家数
            dt.Columns.Add(PayNumber, typeof(decimal));//转化率
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog xjOpenFileDialog = new OpenFileDialog();
            xjOpenFileDialog.Filter = "文本文件|*.txt";
            if (xjOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xjFilePath = xjOpenFileDialog.FileName;
                this.textBox1.Text = xjFilePath;//显示文件路径

                StreamReader sr = new StreamReader(xjFilePath, Encoding.Default);
                string content = sr.ReadToEnd();
                Y_headname = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                for (int i = 0; i < Y_headname.Length-1; i++)
                {
                    string[] data = Y_headname[i].Split('-');
                    //string URLI = ;
                    ShowInfo2(data[0].ToString() + "--" + data[1].ToString() + "---" + i.ToString());
                   //
                }
                
            }
            textBox5.Text = "c:\\" + DateTime.Now.ToString("yyyyMMdd") + textBox4.Text;

        }
        public void ShowInfo(string Info)
        {
            textBox3.AppendText(Info);
            textBox3.AppendText(Environment.NewLine);
            textBox3.ScrollToCaret();
        }
        public void ShowInfo2(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            cint = int.Parse(this.textBox4.Text);
            int Ucou = Y_headname.Length;
            this.button1.Text = abc.ToString();
            if (Ucou>abc)
            {
                string[] data = Y_headname[abc].Split('-');
               // ShowInfo(data[0].ToString() + "--" + data[0].ToString() + "---" + abc.ToString());
                abc = abc + 1;
                GetURl(data[0].ToString(), data[1].ToString());
            }

              
               // GetURl(data[0].ToString(), data[1].ToString());



        }
    }
}
