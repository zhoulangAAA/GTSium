using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class DeptRules : ZASuiteDAORulesSys
    {
        //string strStoredProcAdd = "sys_dept_ADD";//存过_新增 
        //string strStoredProcDelete = "sys_dept_Delete";//存过_删除 
        //string strStoredProcUpdate = "sys_dept_Update";//存过_修改         
        //string strStrKey = "fdept_id";//主键名      
        string strStrTableName = "sys_dept";//表名 
        string strStrSortId = "fsort_id";//排序字段 
       
        public DeptRules()
        {           
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }
        
        /// <summary>
        /// 根据条件组织ID取得部门数据集
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
            sql = "SELECT * FROM sys_dept WHERE fparent_id='" + strFparent_id + "' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }
        /// <summary>
        /// 取得部门列表  只读，根据状态
        /// </summary>
        /// <param name="strFStatus"></param>
        /// <returns></returns>
        public DataSet ZAGetDataSetByFStatus(string strFStatus)
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_dept WHERE fstatus='" + strFStatus + "' ORDER BY fsort_id,fname";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 根据ＩＤ取得名称
        /// </summary>
        /// <param name="strID">主键ID</param>
        /// <returns></returns>
        public string ZAGetDeptNameByID(string strID)
        {
            string sql = "SELECT fname FROM sys_dept WHERE fdept_id='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }

        /*
        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        */
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="strId">部门ID</param>
        /// <returns></returns>
        public bool ZADelDept(string strId)
        {
            bool result = false;
            string delPosition = "Delete sys_dept WHERE (fdept_id = '" + strId + "')";
            string delOrg = "Delete sys_org WHERE (fdept_id = '" + strId + "')";
            if (this.ExecuteTransaction2(delOrg, delPosition))
            {
                result = true;
            }
            return result;
        }


        /// <summary>
        ///部门 是否存在下级
        /// </summary>
        /// <param name="strId">部门ID</param>
        /// <returns></returns>
        public bool ZADeptHaveChild(string strId)
        {
            string strid = null;
            bool b = false;
            strid = this.ExecuteScalarGetString("SELECT fdept_id FROM sys_dept WHERE (fparent_id = '" + strId + "')");
            if (strid == "" || strid == null || strid.Length == 0)
            { 
            }
            else
            {
                b = true;
            }
            return b;
        }

      

        //-------------------------------------------------------------
        /// <summary>
        /// 根据上级ID 取得组织部门
        /// </summary>
        /// <param name="strFparent_id">上级ID</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetOrg(string strFparent_id)
        {
            string sql;
            // string strWhere = " fparent_id='" + strFparent_id + "' ";
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_org WHERE fparent_id='" + strFparent_id + "' and  ftype='Dept' ORDER BY fsort_id";
            ds = this.DataSetLoadBySql(sql, strStrTableName);
            return ds;
        }


        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdateOrg(DataSet dsObject)
        {
            string strStoredProcAdd1 = "sys_org_ADD";//存过_新增 
            string strStoredProcDelete1 = "sys_org_Delete";//存过_删除 
            string strStoredProcUpdate1 = "sys_org_Update";//存过_修改         
            string strStrKey1 = "forg_id";//主键名      
            string strStrTableName1 = "sys_org";//表名             
            return this.DataSetUpdate(dsObject, strStrTableName1, strStrKey1, strStoredProcAdd1, strStoredProcDelete1, strStoredProcUpdate1);
        }
    }
}
