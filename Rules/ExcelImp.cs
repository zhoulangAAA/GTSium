using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Silt.Client.Rules
{

    /// <summary>
    /// Lis项目 规则
    /// </summary>
    public class ExcelImp : ZASuiteDAORulesSys
    {
        public ExcelImp()
        {
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 取得表lTabel所有字段列表
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetFieldAllLis(string lType)
        {
            string sql;
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_excel WHERE FType = '" + lType + "'" + "  ORDER BY FORDER_NUM";
            ds = this.DataSetLoadBySql(sql, "sys_excel");
            return ds;
        }

        /// <summary>
        /// 执行ExecuteNonQuery
        /// 该方法返回的是SQL语句执行影响的行数，我们可以利用该方法来执行一些没有返回值的操作(Insert,Update,Delete)
        /// </summary>
        /// <param name="strSql">一般的SQL语句</param>
        public int ExecuteNonQuery(string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbcomm = db.GetSqlStringCommand("insert into person values(1,'shy','女','123456')");
            DbCommand dbcomm = db.GetSqlStringCommand(strSql);
            return db.ExecuteNonQuery(dbcomm);
        }
        /// <summary>
        /// 取得32位GUID
        /// </summary>
        /// <returns></returns>
        public string  ZAGetGuid()
        {
            string strGuid = "";
            //string strGuid = System.Guid.NewGuid().ToString().ToUpper();
            strGuid = System.Guid.NewGuid().ToString();
            return strGuid.Replace("-", "");
        }

        
    }
}
