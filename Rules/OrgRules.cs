using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class OrgRules : ZASuiteDAORulesSys
    {
        //ZAWebServices.ZAWebServices zaws = new ZAWebServices.ZAWebServices();
        //DataSet ds = new DataSet();
        
        public static string StrUserOrgId = "";//人员 的组织 ID
        public static string StrDeptId = "";//部门ID
        public static string StrPositionId = "";//岗位ID
        public static string StrUserName = "";//人员姓名
        public static string StrLoginName = "";//人员登录名

        public static string StrDeptName = "";//部门名称
        public static string StrPositionName = "";//岗位名称
        public static string StrLoginDateTime;//登录时间
        public static string StrPersonId = "";//人员ID

        
        private DataSet m_dsObjectOrg = null;
        /// <summary>
        /// 数据集对象
        /// </summary>
        public DataSet dsObjectOrg
        {
            get
            {
                return this.m_dsObjectOrg;
            }
            set
            {
                this.m_dsObjectOrg = value;
            }
        }
       
        public OrgRules()
        {
         
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }
       
        
       /// <summary>
       /// 登录是否成功
       /// </summary>
       /// <param name="strLoginName">登录名</param>
       /// <param name="SysLoginPassword">密码</param>
       /// <returns></returns>
        public bool LoginSuccess(string strLoginName, string SysLoginPassword)
        {
            bool b = false;
            DataSet ds = null;//            
            string sql =  "SELECT fperson_id FROM sys_person where FLOGIN_NAME='" + strLoginName + "' AND (fpassword='" + SysLoginPassword + "')";          
            ds = this.DataSetExecuteBySql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                StrPersonId = ds.Tables[0].Rows[0]["fperson_id"].ToString();
                StrLoginName = strLoginName;
                b = true;
            }
            return b;
        }
        /// <summary>
        /// 根据人员ID取得组织人员信息列表数，如果为1则取得组织信息，如果大于1则显示列表
        /// </summary>
        /// <param name="StrPersonId">人员ID</param>
        /// <returns></returns>
        public int GetOrgInfoCountByPersonId(string StrPersonId)
        {
            string strOrgId = "";
            int orgcount = 0;
            DataSet ds = null;           
            string sql = "SELECT * FROM v_sys_org where fperson_id='" + StrPersonId + "'";
            ds = this.DataSetExecuteBySql(sql);
            orgcount = ds.Tables[0].Rows.Count;
            if (orgcount==1)
            {               
                strOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//人员 的组织 ID 
                GetOrgInfoByOrgId(strOrgId);                
            }
            else if (orgcount > 1)
            {
                this.m_dsObjectOrg = ds;
            }
            return orgcount;
        }
        /// <summary>
        /// 根据组织ID取得组织信息
        /// </summary>
        /// <param name="strForg_id">组织ID</param>
        /// <returns></returns>
        public void GetOrgInfoByOrgId(string strForg_id)
        {           
            DataSet ds = null;           
            string sql = "SELECT * FROM v_sys_org where forg_id='" + strForg_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                StrUserOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//人员 的组织 ID 
                StrDeptId = ds.Tables[0].Rows[0]["fdept_id"].ToString();//部门ID
                StrPositionId = ds.Tables[0].Rows[0]["fposition_id"].ToString();//岗位ID
                StrUserName = ds.Tables[0].Rows[0]["personName"].ToString();//人员姓名
                StrDeptName = ds.Tables[0].Rows[0]["deptName"].ToString();//部门名称
                StrPositionName = ds.Tables[0].Rows[0]["positionName"].ToString();//岗位名称
                StrPersonId = ds.Tables[0].Rows[0]["fperson_id"].ToString();//人员ID
                //Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime =this.ZAGetCurrentServerDateTim();//登录时间
            }
            else
            {
                StrUserOrgId = "";//人员 的组织 ID 
                StrDeptId = "";//部门ID
                StrPositionId = "";//岗位ID
                StrUserName = "";//人员姓名
                StrDeptName = "";//部门名称
                StrPositionName = "";//岗位名称
                StrPersonId = "";//人员ID
                //Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime = this.ZAGetCurrentServerDateTim(); ;//登录时间
            }
        }
        
        /*
        /// <summary>
        /// 取得组织人员信息
        /// </summary>
        /// <param name="strPersonId">人员ID</param>
        /// <returns></returns>
        public bool GetOrgInfo()
        {
            bool b = false;
            ds = null;
            sql = "";
            sql = "SELECT * FROM sys_org where fperson_id='" + StrPersonId + "'";
            ds = this.DataSetLoadBySql(sql, "sys_org");
            if (ds.Tables[0].Rows.Count > 0)
            {
                b = true;
                StrUserOrgId = ds.Tables[0].Rows[0]["forg_id"].ToString();//人员 的组织 ID 
                StrDeptId = ds.Tables[0].Rows[0]["fdept_id"].ToString();//部门ID
                StrPositionId = ds.Tables[0].Rows[0]["fposition_id"].ToString();//岗位ID
                StrUserName = ds.Tables[0].Rows[0]["fname"].ToString();//人员姓名
                try
                {
                    StrDeptName = this.ExecuteScalarGetString("SELECT fname FROM sys_dept WHERE fdept_id='" + StrDeptId + "'");//部门名称
                }
                catch { }
                try
                {
                    StrPositionName = this.ExecuteScalarGetString("SELECT fname FROM sys_position WHERE fposition_id='" + StrPositionId + "'");///岗位名称
                }
                catch { }
                Silt.Base.Common.Time time = new Silt.Base.Common.Time();
                StrLoginDateTime = time.GetDataTime();//登录时间
            }
            return b;
        }*/
    }
}
