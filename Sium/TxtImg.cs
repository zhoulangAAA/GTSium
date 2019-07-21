using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class TxtImg : Form
    {
        public TxtImg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "D:\\images\\a.png";
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);
            System.Drawing.Image imgWarter = System.Drawing.Image.FromFile("D:\\images\\c.png");
            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                g.DrawImage(imgWarter, new Rectangle(imgSrc.Width - imgWarter.Width,
                                                 imgSrc.Height - imgWarter.Height,
                                                 imgWarter.Width,
                                                 imgWarter.Height),
                        0, 0, imgWarter.Width, imgWarter.Height, GraphicsUnit.Pixel);
            }

            string newpath = "D:\\images\\x.jpg";
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //this.image_Water.ImageUrl = @"~/Image/WaterMark.bmp"
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "D:\\images\\a.png";
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                g.DrawImage(imgSrc, 0, 0, imgSrc.Width, imgSrc.Height);
                using (Font f = new Font("宋体", 20))
                {
                    using (Brush b = new SolidBrush(Color.Red))
                    {
                        string addText = "我的地盘我做主";
                        g.DrawString(addText, f, b, 100, 20);
                    }
                }
            }
            string fontpath = "D:\\images\\a.jpg";
            imgSrc.Save(fontpath, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            //使用ClearType字体功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"开始时间:2016-1-1" + "\r\n"
                                                              + "结束时间:2017-1-1" + "\r\n"
                                                             + "沙尘天气等级:2" + "\r\n"
                                                             + "PM10日均浓度最大值:2ug/m3" + "\r\n"
                                                              + "影响范围:济南，青岛";
            //得到Bitmap(传入Rectangle.Empty自动计算宽高)
            Bitmap bmp = TextToBitmap(str, new Font("Arial", 16), Rectangle.Empty, Color.Black, Color.Wheat);


            //保存到桌面save.jpg
            string directory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            bmp.Save(directory + "\\save.png", ImageFormat.Png);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //连接端口
                FirefoxProfileManager profileManager = new FirefoxProfileManager();
                FirefoxProfile profile = profileManager.GetProfile("lang");
                profile.SetPreference("auto-reader-view.sdk.load.reason", "startup");
                var driver = new FirefoxDriver(profile);

                driver.Navigate().GoToUrl("http://localhost:810/news/show-84.html");
                Thread.Sleep(8000);

                driver.Navigate().Refresh();
                //var keyWord = driver.FindElement(By.XPath("//div[@id='container']"));
                //Screenshot screenShotFile = ((ITakesScreenshot)driver).GetScreenshot();
                
                //screenShotFile.SaveAsFile("test.gif", ScreenshotImageFormat.Gif);
             
                //设置窗体最大化
                //driver.Manage().Window.Maximize();
                //找到对象
                var imgelement = driver.FindElement(By.XPath("//div[@class='main_box']"));
                var location = imgelement.Location;
                var size = imgelement.Size;

                var savepath =@"d:\codingpy_1.png";
                driver.GetScreenshot().SaveAsFile(savepath, ScreenshotImageFormat.Png);//屏幕截图   
                Image image = System.Drawing.Image.FromFile(savepath);
                int left = location.X;
                int top = location.Y;
                int right = left + size.Width;
                int bottom = top + size.Height;
                //截图
                Bitmap bitmap = new Bitmap(savepath);//原图
                Bitmap destBitmap = new Bitmap(size.Width, size.Height);//目标图
                Rectangle destRect = new Rectangle(0, 0, size.Width, size.Height);//矩形容器
                Rectangle srcRect = new Rectangle(left, top, size.Width, size.Height);
                Graphics graphics = Graphics.FromImage(destBitmap);
                graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                destBitmap.Save("d:\\aa.png", System.Drawing.Imaging.ImageFormat.Png);
                graphics.Dispose();

            }

            catch (System.Net.Sockets.SocketException ex)
            {
                MessageBox.Show(ex.ToString());

            }
           
           
        }
        public void ShowInfo(string Info)
        {
            textBox2.AppendText(Info);
            textBox2.AppendText(Environment.NewLine);
            textBox2.ScrollToCaret();
        }
        public void snapshot(ITakesScreenshot drivername, String filename)
        {

            Screenshot scrFile = drivername.GetScreenshot();

            try
            {

               

                scrFile.SaveAsFile("D:\\" + filename, ImageFormat.Png);
            }

            catch (IOException e)
            {
                Console.WriteLine("Can't save screenshot");

            }
            finally
            {
                Console.WriteLine("screen shot finished");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
