using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class PositionRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_position_ADD";//存过_新增 
        string strStoredProcDelete = "sys_position_Delete";//存过_删除 
        string strStoredProcUpdate = "sys_position_Update";//存过_修改         
        string strStrKey = "fposition_id";//主键名      
        string strStrTableName = "sys_position";//表名 
        string strStrSortId = "fsort_id";//排序字段 
        
        public PositionRules()
        {
            
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 取得岗位数据集 只读
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSetRead()
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_position WHERE (fstatus = 1)");
        }

        /// <summary>
        /// 根据条件组织ID取得岗位数据集
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
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZADataSetUpdate(DataSet dsObject)
        {
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="strId">岗位ID</param>
        /// <returns></returns>
        public bool ZADelPosition(string strId)
        {
            bool result = false;
            string delPosition = "Delete sys_position WHERE (fposition_id = '" + strId + "')";
            string delOrg = "Delete sys_org WHERE (fposition_id = '" + strId + "')";
            if (this.ExecuteTransaction2(delOrg, delPosition))
            {
                result = true;
            }
            return result;
        }
    }
}
