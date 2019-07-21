using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Silt.Client.Rules
{
    public class FuncRules : ZASuiteDAORulesSys
    {
       
        string strStrTableName = "sys_func";//表名 
        string strStrSortId = "fsort_id";//排序字段 
        
        public FuncRules()
        {

            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        
        /// <summary>
        /// 根据条件组织ID取得功能数据集
        /// </summary>
        /// <param name="strWhere">构造数据集条件</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet(string strWhere)
        {
            string sql;
            DataSet ds = new DataSet();
            if (strWhere == "" || strWhere == null)
            {
                sql = "SELECT * FROM " + strStrTableName + " ORDER BY " + strStrSortId;
            }
            else
            {
                sql = "SELECT * FROM " + strStrTableName + " WHERE '" + strWhere + "' ORDER BY " + strStrSortId;
            }
          
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }

        /// <summary>
        /// 根据上级ID
        /// </summary>
        /// <param name="strFparent_id">上级ID</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetByFparent_id(string strFparent_id)
        {
            string sql;
            // string strWhere = " fparent_id='" + strFparent_id + "' ";
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_func WHERE fparent_id='" + strFparent_id + "' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }

        

        /// <summary>
        /// 取得只读 功能数据集列表
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetFuncDataSetRead()
        {

            return this.DataSetExecuteBySql("SELECT * FROM sys_func WHERE (fstatus = 1) order by fsort_id");

        }

        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
       // public int ZADataSetUpdate(DataSet dsObject)
       // {
          //  return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        //}

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="strId">功能ID</param>
        /// <returns></returns>
        public bool ZADelDept(string strId)
        {
            bool result = false;
            string delSQL = "Delete sys_func WHERE (ffunc_id = '" + strId + "')";
            if (this.ExecuteNonQuery(delSQL) > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        ///功能 是否存在下级
        /// </summary>
        /// <param name="strId">功能ID</param>
        /// <returns></returns>
        public bool ZADeptHaveChild(string strId)
        {
            string strid = null;
            bool b = false;
            strid = this.ExecuteScalarGetString("SELECT ffunc_id FROM sys_func WHERE (fparent_id = '" + strId + "')");
            if (strid == "" || strid == null || strid.Length == 0)
            {
            }
            else
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 新增功能
        /// </summary>
        /// <param name="funcmodel">功能模型</param>
        /// <returns></returns>
        public bool FuncAdd(FuncModel modelobject)
        {
            bool result = false;

            /*
            Database db = DatabaseFactory.CreateDatabase(ZAStrConn);
            DbCommand dbCommandObject = db.GetStoredProcCommand("sys_func_ADD");

            db.AddInParameter(dbCommandObject, "ffunc_id", DbType.String, modelobject.ffunc_id);
            db.AddInParameter(dbCommandObject, "fname", DbType.String, modelobject.fname);
            db.AddInParameter(dbCommandObject, "fwinform", DbType.String, modelobject.fwinform);
            db.AddInParameter(dbCommandObject, "fparent_id", DbType.String, modelobject.fparent_id);
            db.AddInParameter(dbCommandObject, "fstatus", DbType.String, modelobject.fstatus);
            db.AddInParameter(dbCommandObject, "fsort_id", DbType.Decimal, modelobject.fsort_id);
            db.AddInParameter(dbCommandObject, "fremark", DbType.String, modelobject.fremark);       
           */

            string strSql = "INSERT INTO sys_func([ffunc_id],[fname],[fwinform],[fparent_id],[fstatus],[fsort_id],[fremark],[fopen_page],[fpluggableUnit],[fpluggableUnitName],[fpluggableUnitAssembly],[ficon])VALUES('" + modelobject.ffunc_id + "','" + modelobject.fname + "','" + modelobject.fwinform + "','" + modelobject.fparent_id + "','" + modelobject.fstatus + "'," + modelobject.fsort_id + ",'" + modelobject.fremark + "','" + modelobject.fopen_page + "','"+modelobject.fpluggableUnit+"','"+modelobject.fpluggableUnitName+"','"+modelobject.fpluggableUnitAssembly+"','"+modelobject.ficon+"')";
            if (this.ExecuteNonQuery(strSql) > 0)
            {
              result = true;
            }       
            return result;
        }

        //-------------------功能属性相关
        /// <summary>
        /// 根据功能ID、上级ID取得功能属性数据集,可读写
        /// </summary>
        /// <param name="FFunc_id">功能ID</param>
        /// <param name="FParent_ID">上级ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFFunc_id(string FFunc_id, string FParent_ID)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_func_property Where FFunc_id='" + FFunc_id + "' and FParent_ID='" + FParent_ID + "'";
            ds = this.DataSetLoadBySql(sql, "sys_func_property");
            return ds;
        }
        /// <summary>
        /// 根据功能ID取得功能属性数据集,只读
        /// </summary>
        /// <param name="FFunc_id">功能ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFFunc_idRead(string FFunc_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FFunc_id='" + FFunc_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 根据上级ID取得功能属性数据集,只读
        /// </summary>
        /// <param name="FParent_ID">上级ID</param>
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyByFParent_IDRead(string FParent_ID)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FParent_ID='" + FParent_ID + "' Order By FIndex";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 取得基本功能属性列表，只读
        /// </summary>       
        /// <returns></returns>
        public DataSet ZAGetFuncPropertyBaseList()
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_func_property Where FStatus=1 and FFunc_id='-1'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 通过存储过程 批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZAUpdateFuncProperty(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_func_property_ADD";//存过_新增 
            string strStoredProcDelete = "sys_func_property_Delete";//存过_删除 
            string strStoredProcUpdate = "sys_func_property_Update";//存过_修改         
            string strStrKey = "FProperty_ID";//主键名      
            string strStrTableName = "sys_func_property";//表名          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        //----------------------------------
    }
}
