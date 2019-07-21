using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class PersonRules : ZASuiteDAORulesSys
    {
        string strStoredProcAdd = "sys_person_ADD";//存过_新增 
        string strStoredProcDelete = "sys_person_Delete";//存过_删除 
        string strStoredProcUpdate = "sys_person_Update";//存过_修改         
        string strStrKey = "fperson_id";//主键名      
        string strStrTableName = "sys_person";//表名 
        string strStrSortId = "fsort_id";//排序字段 
       
        public PersonRules()
        {
           
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }
        /// <summary>
        /// 取得人员数据集 只读
        /// </summary>      
        /// <returns></returns>
        public DataSet ZAGetDataSetRead()
        {
            DataSet ds = null;
            ds = this.DataSetExecuteBySql("SELECT * FROM sys_person WHERE (fstatus = 1) Order By fname");
            return ds;
        }
        /*
        /// <summary>
        /// 根据条件 取得列表
        /// </summary>
        /// <param name="strflogin_name">登录名</param>
        /// <returns></returns>
        public IDataReader ZAGetIDataReaderPersonList(string strflogin_name)
        {
            string strSql = "SELECT * FROM sys_person WHERE (fstatus = '1') AND (flogin_name LIKE '" + strflogin_name + "%') Order By fname";
            return this.IDataReaderBySql(strSql);
        }*/
        /// <summary>
        /// 根据条件组织ID取得人员数据集
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
                sql = "SELECT * FROM " + strStrTableName + " WHERE " + strWhere + " ORDER BY " + strStrSortId;
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
        /// 登录名存在否
        /// </summary>
        /// <param name="strloginname"></param>
        /// <returns></returns>
        public bool ZALoginNameExists(string strloginname)
        {
           return this.Exists("SELECT COUNT(1) FROM sys_person WHERE (flogin_name = '" + strloginname + "')");
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="strId">人员ID</param>
        /// <returns></returns>
        public bool ZADelPerson(string strId)
        {
            bool result = false;
            string delPerson = "Delete sys_person WHERE (fperson_id = '" + strId + "')";
            string delOrg = "", delOrg_Func = "";
            string strforg_id = "";
            string sqlOrg = "SELECT forg_id FROM sys_org WHERE (fperson_id = '" + strId + "') and ftype='Person'";
            DataSet dsOrg = new DataSet();
            dsOrg = this.DataSetLoadBySql(sqlOrg, "sys_org");
            for (int i = 0; i < dsOrg.Tables[0].Rows.Count; i++)
            {
                strforg_id = dsOrg.Tables[0].Rows[i]["forg_id"].ToString();//人员 的组织 ID 
                delOrg = "Delete sys_org Where forg_id='" + strforg_id + "' and ftype='Person'";
                delOrg_Func = "Delete sys_org_func Where forg_id = '" + strforg_id + "'";
                this.ExecuteNonQuery(delOrg_Func);//删除人员功能记录  
                this.ExecuteNonQuery(delOrg);//删除人员组织记录
            }
            if (this.ExecuteNonQuery(delPerson) > 0)//删除人员
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 根据ＩＤ取得登录名称
        /// </summary>
        /// <param name="strID">主键ID</param>
        /// <returns></returns>
        public string ZAGetPersonByLloginName(string strID)
        {
            string sql = "SELECT fname FROM sys_person WHERE flogin_name='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
        /// <summary>
        /// 根据ＩＤ取得名称
        /// </summary>
        /// <param name="strID">主键ID</param>
        /// <returns></returns>
        public string ZAGetPersonNameByID(string strID)
        {
            string sql = "SELECT fname FROM sys_person WHERE fperson_id='" + strID + "'";
            return this.ExecuteScalarGetString(sql);

        }
    }
}
