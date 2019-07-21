using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows;
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using System.Net;

namespace Sium
{
    class HttpPost
    {
        public string Getcookie { get; set; }
        public string GetHtml { get; set; }
        public string Depcookie { get; set; }
        public string Allcookie { get; set; }
        public CookieCollection llcookie;

        public string GetHTTPTaobao(string sURL)
        {
          
            HttpHelper http = new HttpHelper();
         //   Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            HttpItem item = new HttpItem()
            {

                URL = sURL,//URL     必需项    
                Accept = " */",
                Host = "sycm.taobao.com",
                Method = "get",//URL     可选项 默认为Get
                Cookie = Getcookie,
               // CsharpHttpHelper.Item.Cookie = ",",
           //     CookieCollection = llcookie,//字符串Cookie     可选项   
                Referer = "https://sycm.taobao.com/mq/industry/rank/industry.htm",//来源URL     可选项   
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
               // ResultCookieType = ResultCookieType.CookieCollection,
                ContentType = "text/html",
                ResultType = ResultType.String

            };
            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;

            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }
        public string GetHTTPTaobaoTID(string sURL, string tid)
        {

            HttpHelper http = new HttpHelper();
            //   Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            HttpItem item = new HttpItem()
            {

                URL = sURL,//URL     必需项    
                Accept = " */",
                Host = "sycm.taobao.com",
                Method = "get",//URL     可选项 默认为Get
                Cookie = Getcookie,
                // CsharpHttpHelper.Item.Cookie = ",",
                //     CookieCollection = llcookie,//字符串Cookie     可选项   
              

                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  

                ContentType = "text/html",
                ResultType = ResultType.String

            };
            item.Header.Add("transit-id", tid);
            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;

            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }
        public string GetHTTPTaobaoTID(string sURL,string tid,string regUrl)
        {

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {

                URL = sURL,//URL     必需项   
                Host = "sycm.taobao.com",
                Accept = " */",
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                Method = "get",//URL     可选项 默认为Get
                Referer = regUrl,
                ContentType = "text/html",
                Cookie = Getcookie,
                ResultType = ResultType.String

            };
            item.Header.Add("transit-id", tid);
            item.Header.Add("Pragma", "no-cache");
            item.Header.Add("Cache-Control", "no-cache");
            item.Header.Add("TE", "Trailers");
            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;

            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }
        public void GetHTTP(string sURL)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = sURL,//URL     必需项    
                Method = "get",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                //Cookie = "",//字符串Cookie     可选项   
                //Referer = "",//来源URL     可选项   
                //Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "text/html",//返回类型    可选项有默认值   
                Allowautoredirect = false,//是否根据301跳转     可选项   
                //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
                //  ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                //ProxyPwd = "123456",//代理服务器密码     可选项    
                //ProxyUserName = "administrator",//代理服务器账户名     可选项   
                ResultCookieType = ResultCookieType.CookieCollection,
                ResultType = ResultType.String

            };

            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;
            Allcookie = HttpHelper.CookieCollectionToStrCookie(llcookie);
            Getcookie = HttpHelper.GetSmallCookie(Allcookie).Replace(";;", ";");
        }
        public void GetHTTPEMS(string sURL)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = sURL,//URL     必需项    
                Method = "get",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                //Cookie = "",//字符串Cookie     可选项   
                //Referer = "",//来源URL     可选项   
                //Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "text/html",//返回类型    可选项有默认值   
                Allowautoredirect = false,//是否根据301跳转     可选项   
                //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
                //  ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                //ProxyPwd = "123456",//代理服务器密码     可选项    
                //ProxyUserName = "administrator",//代理服务器账户名     可选项   
                ResultCookieType = ResultCookieType.CookieCollection,
                ResultType = ResultType.String

            };

            HttpResult result = http.GetHtml(item);
            GetHtml = result.Html;
        }

        public void GetHTTPTaobaocom(string sURL)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = sURL,//URL     必需项    
                Accept = " */",
                Host = "suggest.taobao.com",
                Method = "get",//URL     可选项 默认为Get
              
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                //Cookie = "",//字符串Cookie     可选项   
               Referer = "https://www.taobao.com/",//来源URL     可选项   
                //Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:66.0) Gecko/20100101 Firefox/66.0",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "text/html",//返回类型    可选项有默认值   
                Allowautoredirect = false,//是否根据301跳转     可选项   
                //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
                //  ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                //ProxyPwd = "123456",//代理服务器密码     可选项    
                //ProxyUserName = "administrator",//代理服务器账户名     可选项   
                ResultCookieType = ResultCookieType.CookieCollection,
                ResultType = ResultType.String

            };

            HttpResult result = http.GetHtml(item);
            GetHtml = result.Html;
        }
        public string Depcooke(string cook)
        {
            string PEK = "ssssssssss";
            if (Getcookie != null)
            {
                string[] Gcook = Getcookie.Split(';');
                for (int i = 0; i < Gcook.Length; i++)
                {
                    string[] arr = Gcook[i].Split('=');
                    if (arr[0] == cook)
                        PEK = arr[1].ToString();
                }
            }
            return PEK;
        }
        public string GetHTTPRef(string sURL, string Ref)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = sURL,//URL     必需项    
                Host = "localhost.ptlogin2.qq.com:4300",
                Method = "get",//URL     可选项 默认为Get   
                CookieCollection = llcookie,//字符串Cookie     可选项   
                Referer = Ref,//来源URL     可选项   
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                ResultCookieType = ResultCookieType.CookieCollection,
                ContentType = "text/html",
                ResultType = ResultType.String

            };
            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;

            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }
        public string GetHTTPRefs(string sURL, string Ref)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = sURL,//URL     必需项    
                // Accept:="*/*",
                Host = "localhost.ptlogin2.qq.com:4301",
                Method = "get",//URL     可选项 默认为Get   
                CookieCollection = llcookie,//字符串Cookie     可选项   
                Referer = Ref,//来源URL     可选项  
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ResultCookieType = ResultCookieType.CookieCollection,
                ResultType = ResultType.String

            };
            HttpResult result = http.GetHtml(item);
            GetHtml = result.Html;
            llcookie = result.CookieCollection;
            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }

        public string PostHttpZCT(string URLpost ,string Datepost)
        {
            //创建Httphelper对象
            HttpHelper http = new HttpHelper();
            //创建Httphelper参数对象
            HttpItem item = new HttpItem()
            {
                Host = "subway.simba.taobao.com",
                Accept = "application/json, text/javascript, */*; q=0.01",
                UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0",//用户的浏览器类型，版本，操作系统     可选项有默认值  
                Referer = "https://subway.simba.taobao.com",
                Method = "post",//URL     可选项 默认为Get
                URL = URLpost,//URL     必需项  
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8",//返回类型    可选项有默认值
                Cookie = Getcookie,
                Postdata = Datepost,//Post要发送的数据

            };
            HttpResult result = http.GetHtml(item);
            llcookie = result.CookieCollection;
            GetHtml = result.Html;

            Getcookie = HttpHelper.GetSmallCookie(result.Cookie).Replace(";;", ";");
            return GetHtml;
        }
           
    }
}
