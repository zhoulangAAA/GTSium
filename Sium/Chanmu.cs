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
using Gecko;
using Gecko.DOM;
namespace Sium
{
    public partial class Chanmu : Form
    {
        static private string xulrunnerPath = Application.StartupPath + "\\xulrunner";
        public Chanmu()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(xulrunnerPath);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
          //  create();
            IWebDriver driver = new FirefoxDriver();
            FirefoxProfile profile = new FirefoxProfile();
            //profile.SetPreference("extensions.firebug.net.enableSites", true);
            ////设置启用firebugcookies面板
            //profile.SetPreference("extensions.firebug.cookies.enableSites", true);
            driver.Navigate().GoToUrl(this.textBox1.Text);
          //  profile.
           // driver.
            //设置启用firebug网络面板

           // Thread.Sleep(10000);
            driver.FindElement(By.XPath("//input[@class='login-text J_UserName']")).Click();
            driver.FindElement(By.XPath("//input[@id='TPL_username_1']")).SendKeys("海尔启阳专卖店:楚狼");
            driver.FindElement(By.XPath("//input[@id='TPL_password_1']")).SendKeys("a123456");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@id = 'J_SubmitStatic']")).Click();
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

        private void button2_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("https://sycm.taobao.com/custom/login.htm");
           // geckoWebBrowser1.Document.
            //string["payByrRateIndexList"]


        }
        public void ShowInfo(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ShowInfo(geckoWebBrowser1.DomDocument.TextContent);
            //nsIHTMLEditor htmlEditor = (nsIHTMLEditor)geckoWebBrowser1.Editor;
            //ShowInfo(htmlEditor.ToString());
            foreach (Gecko.DOM.GeckoIFrameElement _E in geckoWebBrowser1.Document.GetElementsByTagName("iframe"))
            {
                //if (_E.GetAttribute("class") == "testClass")
                //{
                    var innerHTML = _E.ContentDocument;

                    foreach (GeckoHtmlElement _A in innerHTML.GetElementsByClassName("login-text J_UserName"))
                    {
                        _A.SetAttribute("value", "Test");
                    }
             
                foreach (GeckoHtmlElement F in innerHTML.GetElementsByName("TPL_password"))
                {
                    F.TextContent = "sfdsfsdfdsf";
                }
               // GeckoWebBrowser1.Document.GetElementById("pass").SetAttribute("value", "xxxxxx")
              //  innerHTML.GetElementById("TPL_password_1").SetAttribute("value", "Test");
                //}
            }

            //string content = null;
            //var iframe = geckoWebBrowser1.Document.GetElementsByTagName("iframe").FirstOrDefault() as Gecko.DOM.GeckoIFrameElement;
            //if (iframe != null)
            //{
            //    var html = iframe.ContentDocument.DocumentElement as GeckoHtmlElement;
            //    html.GetElementsByTagName("codeTerminal");

            //    //if (html != null)
            //    //    content = html.OuterHtml;
            //}

            //  ShowInfo(content);

        }
        public string GetElementAttributes(GeckoElement element)
        {
            var result = new StringBuilder();
            foreach (var a in element.Attributes)
            {
                result.Append(String.Format(" {0} = '{1}' ", a.NodeName, a.NodeValue));
            }

            return result.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var emailField = new Gecko.DOM.GeckoInputElement(geckoWebBrowser1.Document.GetHtmlElementById("TPL_password").DomObject);
            //emailField.c
            // java.EvaluateScript(@"window.alert('alert')", (nsISupports)geckoWebBrowser1.Window.DomWindow, out result);
            //geckoWebBrowser1.Navigate("view-source:" + "https://sycm.taobao.com/custom/login.htm");
            //geckoWebBrowser1.ViewSource();
            //GeckoInputElement txtbox = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByName("TPL_password_1").);
            //txtbox.Value = "Your string";
            //GetElementAttributes(geckoWebBrowser1.DomDocument);
        }
    }
  
}
