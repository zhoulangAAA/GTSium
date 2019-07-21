using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Silt.Client.Rules
{
    public class LogRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_log_ADD";//存过_新增 
        string strStoredProcDelete = "sys_log_Delete";//存过_删除 
        string strStoredProcUpdate = "sys_log_Update";//存过_修改         
        string strStrKey = "flog_id";//主键名      
        string strStrTableName = "sys_log";//表名 
        //string strStrSortId = "fsort_id";//排序字段 
       
        public LogRules()
        {
          
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 根据条件组织ID取得日志数据集
        /// </summary>
        /// <param name="strWhere">构造数据集条件</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet(string strWhere)
        {
            string sql;
            DataSet ds = new DataSet();
            sql = "SELECT * FROM " + strStrTableName + " WHERE " + strWhere;
           
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }
        /// <summary>
        /// 根据条件组织ID取得日志数据集
        /// </summary>
        /// <param name="strWhere">构造数据集条件</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetRead(string strWhere)
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM " + strStrTableName + " WHERE " + strWhere;

            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 根据条件组织ID取得日志数据集
        /// </summary>
        /// <param name="strWhere">构造数据集条件</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet_1(string strWhere)
        {
            string sql;
            DataSet ds = new DataSet();
           
                sql = "SELECT * FROM sys_log_1";

                ds = this.DataSetLoadBySql(sql, "sys_log_1");
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
        /// 删除日志
        /// </summary>
        /// <param name="strId">日志ID</param>
        /// <returns></returns>
        public bool ZADelPosition(string strId)
        {
            bool result = false;
            string delsql = "Delete sys_log WHERE (flog_id = '" + strId + "')";
            if (this.ExecuteNonQuery(delsql) > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="strTitle">标题</param>
        /// <param name="strFremark">备注</param>          
        public bool LogAdd(string strTitle,string strFremark)
        {
            bool result = false;
            string strSql = "INSERT INTO sys_log ([flog_id] ,[fstatus] ,[fperson_id] ,[ftitle] ,[fdate] ,[ftime] ,[fip] ,[fpc_name] ,[fremark] ,[fsort_id] ,[flogin_name] ,[fuser_name] ,[fdept_name] ,[fposition_name] ) VALUES ('" + ZAGetGuid() + "','1','" + OrgRules.StrPersonId + "','" + strTitle + "','','" + OrgRules.StrLoginDateTime + "','" + ZAGetHostIpAddress() + "','" + ZAGetHostName() + "','" + strFremark + "',0,'" + OrgRules.StrLoginName + "','" + OrgRules.StrUserName + "','" + OrgRules.StrDeptName + "','" + OrgRules.StrPositionName + "')";
            if (this.ExecuteNonQuery(strSql) > 0)
            {
                result = true;
            }
            return result;

            /*
             *  Database db = DatabaseFactory.CreateDatabase(ZAStrConn);          
            DbCommand dbCommandObject = db.GetStoredProcCommand(strStoredProcAdd);

            db.AddInParameter(dbCommandObject, "flog_id", DbType.String, ZAGetGuid());
            db.AddInParameter(dbCommandObject, "fstatus", DbType.String, "1");
            db.AddInParameter(dbCommandObject, "fperson_id", DbType.String, Sys.OrgRules.StrPersonId);

            db.AddInParameter(dbCommandObject, "ftitle", DbType.String, strTitle);
            db.AddInParameter(dbCommandObject, "fdate", DbType.String, "");
            db.AddInParameter(dbCommandObject, "ftime", DbType.String, Sys.OrgRules.StrLoginDateTime);
            db.AddInParameter(dbCommandObject, "fip", DbType.String, ZAGetHostIpAddress());
            db.AddInParameter(dbCommandObject, "fpc_name", DbType.String, ZAGetHostName());
            db.AddInParameter(dbCommandObject, "fremark", DbType.String, strFremark);
            db.AddInParameter(dbCommandObject, "fsort_id", DbType.Decimal, 0);
            db.AddInParameter(dbCommandObject, "flogin_name", DbType.String, Sys.OrgRules.StrLoginName);
            db.AddInParameter(dbCommandObject, "fuser_name", DbType.String, Sys.OrgRules.StrUserName);
            db.AddInParameter(dbCommandObject, "fdept_name", DbType.String, Sys.OrgRules.StrDeptName);
            db.AddInParameter(dbCommandObject, "fposition_name", DbType.String, Sys.OrgRules.StrPositionName);
             * 
             * 
             * 
             db.AddInParameter(dbCommandObject, "flog_id", DbType.String, logmodel.flog_id);
            db.AddInParameter(dbCommandObject, "fstatus", DbType.String, logmodel.fstatus);
            db.AddInParameter(dbCommandObject, "fperson_id", DbType.String, logmodel.fperson_id);
            db.AddInParameter(dbCommandObject, "ftitle", DbType.String, logmodel.ftitle);
            db.AddInParameter(dbCommandObject, "fdate", DbType.String, logmodel.fdate);
            db.AddInParameter(dbCommandObject, "ftime", DbType.String, logmodel.ftime);
            db.AddInParameter(dbCommandObject, "fip", DbType.String, logmodel.fip);
            db.AddInParameter(dbCommandObject, "fpc_name", DbType.String, logmodel.fpc_name);
            db.AddInParameter(dbCommandObject, "fremark", DbType.String, logmodel.fremark);
            db.AddInParameter(dbCommandObject, "fsort_id", DbType.Decimal, logmodel.fsort_id);
            db.AddInParameter(dbCommandObject, "flogin_name", DbType.String, logmodel.flogin_name);
            db.AddInParameter(dbCommandObject, "fuser_name", DbType.String, logmodel.fuser_name);
            db.AddInParameter(dbCommandObject, "fdept_name", DbType.String, logmodel.fdept_name);
            db.AddInParameter(dbCommandObject, "fposition_name", DbType.String, logmodel.fposition_name);
             */




            /*    
           
           
            

           

            if (db.ExecuteNonQuery(dbCommandObject) > 0)
            {
                result = true;
            } */     
            
        }
    }
}
