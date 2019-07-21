using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    /// <summary>
    /// 地区管理 规则
    /// </summary>
    public class AreaRules : ZASuite.Lis.Rules.ZASuiteDAORulesLis
    {
        public AreaRules()
        {
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 取得血库库房所有列表，可读写
        /// </summary>    
        /// <returns></returns>
        public DataSet GetListWrite()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area ORDER BY FNumber";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// 根据条件 取得血库库房所有列表，可读写
        /// </summary>      
        ///  <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetListWrite(string strWhere)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area " + strWhere;
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// 根据类别名称 取得 地区 所有列表，可读写
        /// </summary>      
        ///  <param name="strClassName">分类名称</param>
        /// <returns></returns>
        public DataSet GetListByClassName(string strClassName)
        {
            string sql;
            DataSet ds = new DataSet();
            if (strClassName == "" || strClassName == null)
                sql = "SELECT * FROM sys_area ORDER BY FNumber";
            else
                sql = "SELECT * FROM sys_area WHERE (FClassName = '" + strClassName.Trim() + "') ORDER BY FNumber";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// 根据条件 取得血库库房所有列表，可读写
        /// </summary>      
        ///  <param name="strFClassName">类型</param>
        /// <returns></returns>
        public DataSet GetListWriteByType(string strFClassName)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area Where FClassName = '" + strFClassName + "'";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// 取得可读写列表，根据上级ID
        /// </summary>
        /// <param name="strFParentID"></param>
        /// <returns></returns>
        public DataSet GetListWriteByFParentID(string strFParentID)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_area Where FID<>'0' and FParentID = '" + strFParentID + "'";
            ds = this.DataSetLoadBySql(sql, "sys_area");
            return ds;
        }
        /// <summary>
        /// 取得血库库房所有列表 启用，只读
        /// </summary>       
        /// <returns></returns>
        public DataSet GetList()
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_area Where FStatus = '1' ORDER BY FNumber";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// 取得血库库房所有列表，只读
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_area " + strWhere;
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// 取得名称，根据ID
        /// </summary>
        /// <param name="strID">主键</param>       
        /// <returns></returns>
        public string ZAFName(string strID)
        {
            string sql = "SELECT FName FROM sys_area Where FID='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// 取得代码，根据ID
        /// </summary>
        /// <param name="strID">主键</param>       
        /// <returns></returns>
        public string ZAFCode(string strID)
        {
            string sql = "SELECT FCode FROM sys_area Where FID='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZAUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_area_ADD";//存过_新增 
            string strStoredProcDelete = "sys_area_Delete";//存过_删除 
            string strStoredProcUpdate = "sys_area_Update";//存过_修改         
            string strStrKey = "FID";//主键名      
            string strStrTableName = "sys_area";//表名 
            //string strStrSortId = "FNumber";//排序字段          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        
    }
}
