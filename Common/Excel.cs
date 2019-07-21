using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Silt.Base.Common
{
    public class Excel
    {
        public Excel()
		{
			///
			/// TODO: 在此处添加构造函数逻辑
			///
           
		}
        /// </summary>
        /// <param name="Path">文件名称</param>
        /// <returns>返回一个数据集</returns>
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "Lis_Com_Patient");            
            conn.Close();
            myCommand.Dispose();
            conn.Dispose();
            return ds;
        }
        /*
       /// <summary>
       /// 写入Excel文档
       /// </summary>
       /// <param name="Path">文件名称</param>
       public bool SaveFP2toExcel(string Path)
       {
           
           try
           {
               string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
               OleDbConnection conn = new OleDbConnection(strConn);
               conn.Open();
               System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
               cmd.Connection = conn;
               //cmd.CommandText ="UPDATE [sheet1$] SET 姓名='2005-01-01' WHERE 工号='日期'";
               //cmd.ExecuteNonQuery ();
               for (int i = 0; i < fp2.Sheets[0].RowCount - 1; i++)
               {
                   if (fp2.Sheets[0].Cells[i, 0].Text != "")
                   {
                       cmd.CommandText = "INSERT INTO [sheet1$] (工号,姓名,部门,职务,日期,时间) VALUES('" + fp2.Sheets[0].Cells[i, 0].Text + "','" +
                        fp2.Sheets[0].Cells[i, 1].Text + "','" + fp2.Sheets[0].Cells[i, 2].Text + "','" + fp2.Sheets[0].Cells[i, 3].Text +
                        "','" + fp2.Sheets[0].Cells[i, 4].Text + "','" + fp2.Sheets[0].Cells[i, 5].Text + "')";
                       cmd.ExecuteNonQuery();
                   }
               }
               conn.Close();
               return true;
           }
           catch (System.Data.OleDb.OleDbException ex)
           {
               System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
           }
           return false;
            
       }

        * */
    }
    
}
