using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Silt.Base.Common.Report
{

    public class PrinterSetFile
    {
        public PrinterSetFile()
        {

        }
        /// <summary>
        /// ¥Ú”°≥ı º…Ë÷√
        /// </summary>
        public void PrinterSettings()
        {
            try
            {
                string strFileName = "ReportSettings.xml";
                FileInfo rs = new FileInfo(strFileName);
                if (rs.Exists)
                { }
                else
                {
                    StreamWriter sw = new StreamWriter(strFileName, true);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<ReportSettings>");
                    sw.WriteLine("<Test>");
                    sw.WriteLine("<ReportName>Test</ReportName>");
                    sw.WriteLine("<PrinterName>Microsoft Office Document Image Writer</PrinterName>");
                    sw.WriteLine("<PaperName>A4</PaperName>");
                    sw.WriteLine("<PageWidth>21.01</PageWidth>");
                    sw.WriteLine("<PageHeight>29.69</PageHeight>");
                    sw.WriteLine("<MarginTop>1</MarginTop>");
                    sw.WriteLine("<MarginBottom>1</MarginBottom>");
                    sw.WriteLine("<MarginLeft>1</MarginLeft>");
                    sw.WriteLine("<MarginRight>1</MarginRight>");
                    sw.WriteLine("<Orientation>H</Orientation>");
                    sw.WriteLine("</Test>");
                    sw.WriteLine("</ReportSettings>");
                    sw.WriteLine(" ");
                    sw.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}