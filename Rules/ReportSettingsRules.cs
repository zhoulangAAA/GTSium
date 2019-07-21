using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
namespace Silt.Client.Rules
{
    public class ReportSettingsRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_reportSettings_ADD";//存过_新增 
        string strStoredProcDelete = "sys_reportSettings_Delete";//存过_删除 
        string strStoredProcUpdate = "sys_reportSettings_Update";//存过_修改         
        string strStrKey = "FID";//主键名      
        string strStrTableName = "sys_reportSettings";//表名        
        
        public ReportSettingsRules()
        {            
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 取得报表设置数据集 可读写
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSet()
        {
            DataSet ds = new DataSet();
            ds = this.DataSetLoadBySql("SELECT * FROM sys_reportSettings Order By FSort_ID", "sys_reportSettings");
            return ds;
        }
        /// <summary>
        /// 取得报表设置数据集 只读
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSetOnlyRead()
        {
            DataSet ds = null;
            ds = this.DataSetExecuteBySql("SELECT * FROM sys_reportSettings Where FStatus='1'");
            return ds;
        }
        
        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        /// <summary>
        /// 报表文件设置 如返回值为 1文件已存在；为2文件新生成成功;为0表示异常
        /// </summary>
        /// <returns></returns>
        public int ZAReportSettings(string strFileName)
        {
            int intReport = 0;
            try
            {
               // string strFileName = System.Configuration.ConfigurationSettings.AppSettings["ReportSettingsFileName"];

                FileInfo rs = new FileInfo(strFileName);
                if (rs.Exists)
                {
                    intReport = 1;
                }
                else
                {
                    StreamWriter sw = new StreamWriter(strFileName, true);
                    sw.WriteLine("<?xml version='1.0' standalone='yes'?>");
                    sw.WriteLine("<ReportSettings>");
                    DataSet ds = null;
                    ds = ZAGetDataSetOnlyRead();
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = null;
                            dr = dt.Rows[i];
                            sw.WriteLine("<" + dr["ReportName"].ToString() + ">");
                            sw.WriteLine("<ReportName>" + dr["ReportName"].ToString() + "</ReportName>");
                            sw.WriteLine("<PrinterName>" + dr["PrinterName"].ToString() + "</PrinterName>");
                            sw.WriteLine("<PaperName>" + dr["PaperName"].ToString() + "</PaperName>");
                            sw.WriteLine("<PageWidth>" + dr["PageWidth"].ToString() + "</PageWidth>");
                            sw.WriteLine("<PageHeight>" + dr["PageHeight"].ToString() + "</PageHeight>");
                            sw.WriteLine("<MarginTop>" + dr["MarginTop"].ToString() + "</MarginTop>");
                            sw.WriteLine("<MarginBottom>" + dr["MarginBottom"].ToString() + "</MarginBottom>");
                            sw.WriteLine("<MarginLeft>" + dr["MarginLeft"].ToString() + "</MarginLeft>");
                            sw.WriteLine("<MarginRight>" + dr["MarginRight"].ToString() + "</MarginRight>");
                            sw.WriteLine("<Orientation>" + dr["Orientation"].ToString() + "</Orientation>");
                            sw.WriteLine("</" + dr["ReportName"].ToString() + ">");

                        }
                    }
                    else
                    {
                        sw.WriteLine("<Template>");
                        sw.WriteLine("<ReportName>Template</ReportName>");
                        sw.WriteLine("<PrinterName>Microsoft Office Document Image Writer</PrinterName>");
                        sw.WriteLine("<PaperName>A4</PaperName>");
                        sw.WriteLine("<PageWidth>21.01</PageWidth>");
                        sw.WriteLine("<PageHeight>29.69</PageHeight>");
                        sw.WriteLine("<MarginTop>1</MarginTop>");
                        sw.WriteLine("<MarginBottom>1</MarginBottom>");
                        sw.WriteLine("<MarginLeft>1</MarginLeft>");
                        sw.WriteLine("<MarginRight>1</MarginRight>");
                        sw.WriteLine("<Orientation>H</Orientation>");
                        sw.WriteLine("</Template>");
                    }
                    sw.WriteLine("</ReportSettings>");
                    sw.WriteLine(" ");
                    sw.Close();

                    intReport = 2;
                }
            }
            catch
            {
                intReport = 0;
            }
            return intReport;
        }
    }
}
