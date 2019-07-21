using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    public class OrgFuncRules : ZASuiteDAORulesSys
    {
        //ZAWebServices.ZAWebServices zaws = new ZAWebServices.ZAWebServices();
        DataSet ds = new DataSet();
        string sql = "";       
        private DataSet m_dsObjectOrgFunc = null;
        /// <summary>
        /// 数据集对象
        /// </summary>
        public DataSet dsObjectOrgFunc
        {
            get
            {
                return this.m_dsObjectOrgFunc;
            }
            set
            {
                this.m_dsObjectOrgFunc = value;
            }
        }
         
        public OrgFuncRules()
        {
            
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }

        /// <summary>
        /// 取得只读 组织数据集列表
        /// </summary>    
        /// <returns></returns>
        public DataSet ZAGetOrgDataSetRead()
        {         
            
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1)");
           
        }
        /// <summary>
        /// 取得只读 组织数据集列表 根据上级ID
        /// </summary>
        /// <param name="fparent_id"></param>
        /// <returns></returns>
        public DataSet ZAGetOrgListByFparent_id(string fparent_id)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE fparent_id='" + fparent_id + "'");

        }
        public string ZAGetOrgChildOrgID(string fparent_id)
        {
            return this.ExecuteScalarGetString(" SELECT TOP 1 forg_id FROM sys_org WHERE (fparent_id = '" + fparent_id + "')");
        } 
       //
       /// <summary>
        /// 根据上级部门ID取得只读 组织数据集列表
       /// </summary>
       /// <param name="strDeptId"></param>
       /// <returns></returns>
        public DataSet ZAGetOrgDataSetRead(string strDeptId)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1) AND (ftype = 'Position') AND (fparent_id = '" + strDeptId + "')");
        } 
        /// <summary>
        /// 根据上级岗位ID取得只读 组织数据集列表
        /// </summary>
        /// <param name="strPositionId"></param>
        /// <returns></returns>
        public DataSet ZAGetOrgDataSetReadByPositionId(string strPositionId)
        {
            return this.DataSetExecuteBySql("SELECT * FROM sys_org WHERE (fstatus = 1) AND (ftype = 'Person') AND (fparent_id = '" + strPositionId + "')");
        }
        /// <summary>
        /// 根据组织主键取得类别
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgType(string strId)
        {
            return this.ExecuteScalarGetString("SELECT ftype FROM sys_org WHERE (forg_id = '" + strId + "')");
        }

        /// <summary>
        /// 根据组织主键取得岗位
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgfposition_id(string strId)
        {
            return this.ExecuteScalarGetString("SELECT fposition_id FROM sys_org WHERE (forg_id = '" + strId + "')");
        }  
        /// <summary>
        /// 根据组织主键取得部门
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public string ZAGetOrgfdept_id(string strId)
        {
            return this.ExecuteScalarGetString("SELECT fdept_id FROM sys_org WHERE (forg_id = '" + strId + "')");
        }

        /// <summary>
        /// 判断同部门下岗位是否存在
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool ZAOrgPositionOK(string strfparent_id, string strfposition_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + @strfparent_id + "') AND (ftype = 'Position') AND (fposition_id = '" + @strfposition_id + "')");
            if (strforid == "" || strforid == null)
            {              
            }
            else
            {
                ok = true;
            }
            return ok;
        }


        /// <summary>
        /// 判断同岗位下人员是否存在
        /// </summary>       
        /// <returns></returns>
        public bool ZAOrgPersonOK(string strfparent_id, string strperson_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + @strfparent_id + "') AND (ftype = 'Person') AND (fperson_id = '" + strperson_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// 判断岗位是否存在 下级人员
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public bool ZAOrgPositionPersonOK(string strfposition_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_id FROM sys_org WHERE (fparent_id = '" + strfposition_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }


        //SELECT forg_id FROM sys_org WHERE (fparent_id = '\ROOT\KMSETYY.OGN\JYK.dpt') AND (ftype = 'Position') AND (fposition_id = 'CYJS')


        /// <summary>
        /// 根据组织ID取得功能列表
        /// </summary>
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public int GetOrgFuncInfoCountByOrgId(string StrOrgId)
        {           
            int i = 0;           
            ds = null;
            sql = "";
            sql = "SELECT * FROM sys_org_func where forg_id='" + StrOrgId + "'";
            ds = this.DataSetExecuteBySql(sql);
            i = ds.Tables[0].Rows.Count;            
            if (i > 0)
            {
                this.m_dsObjectOrgFunc = ds;
            }
            return i;
        }
        /// <summary>
        /// 根据组织ID取得功能列表 启用的
        /// </summary>
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgID(string strforg_id,string strParent)
        {           
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            //sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);         
            return ds;
        }
        /// <summary>
        /// 根据组织ID取得功能列表 启用的
        /// </summary>
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgID(string strforg_id)
        {
            ds = null;
            //sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
           // this.Exists();
        }
        
        /// <summary>
        /// 是否存在下级功能
        /// </summary>
        /// <param name="strfparent_id"></param>
        /// <param name="strforg_id"></param>
        /// <returns></returns>
        public bool ChildFuncExists(string strfparent_id, string strforg_id)
        {
            ds = null;
            sql = "SELECT count(1) FROM v_sys_org_func where fparent_id='" + strfparent_id + "' and forg_id='" + strforg_id + "' and fstatus=1";
            return this.Exists(sql);
        }
        /// <summary>
        /// 取得子功能列表
        /// </summary>
        /// <param name="strfparent_id"></param>
        /// <param name="strforg_id"></param>
        /// <returns></returns>
        public DataSet GetChildFuncList(string strfparent_id, string strforg_id)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where fparent_id='" + strfparent_id + "' and forg_id='" + strforg_id + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// 根据组织ID取得功能列表 启用的  只读数据集
        /// </summary> 
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgIDRead(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 根据组织ID取得功能列表 启用的  只读数据集
        /// </summary> 
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public DataSet GetOrgFuncDSByforgIDReadDesc(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' and fstatus=1 order by fsort_id Desc";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        /// <summary>
        /// 根据组织ID取得功能列表 所有
        /// </summary>
        /// <param name="StrOrgId">组织ID</param>
        /// <returns></returns>
        public DataSet GetAllOrgFuncDSByforgID(string strforg_id, string strParent)
        {
            ds = null;
            sql = "SELECT * FROM v_sys_org_func where forg_id='" + strforg_id + "' and fparent_id='" + strParent + "' order by fsort_id";
            ds = this.DataSetLoadBySql(sql, "v_sys_org_func");
            return ds;
        }


        /// <summary>
        /// 判断此功能是否存在 下级功能
        /// </summary>
        /// <param name="strffunc_id">功能ID</param>
        /// <param name="strforg_id">组织ID</param>
        /// <returns></returns>
        public bool GetAllOrgChildFuncOK(string strffunc_id, string strforg_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT ffunc_id FROM v_sys_org_func WHERE (fparent_id = '" + strffunc_id + "')and (forg_id = '" + strforg_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
            
        }

        /// <summary>
        /// 判断此功能是否存在
        /// </summary>
        /// <param name="strffunc_id">功能ID</param>
        ///  <param name="strforg_id">组织ID</param>
        /// <returns></returns>
        public bool GetAllOrgFuncOK(string strffunc_id, string strforg_id)
        {
            bool ok = false;
            string strforid = this.ExecuteScalarGetString("SELECT forg_func_id FROM sys_org_func WHERE (ffunc_id = '" + strffunc_id + "') and (forg_id = '" + strforg_id + "')");
            if (strforid == "" || strforid == null)
            {
            }
            else
            {
                ok = true;
            }
            return ok;
        }
        /*
        /// <summary>
        /// 根据功能ＩＤ取得页面打开方式
        /// </summary>
        /// <param name="strffunc_id">功能主键ID</param>
        /// <returns></returns>
        public string ZAGetFwinformOpenTypeByID(string strffunc_id)
        {
            string sql = "SELECT fopen_page FROM sys_func WHERE (ffunc_id = '" + strffunc_id + "')";
            return this.ExecuteScalarGetString(sql);
        }
        */
        public DataSet ZAFuncListByFuncID(string strffunc_id)
        {
            ds = null;
            string sql = "SELECT * FROM sys_func WHERE (ffunc_id = '" + strffunc_id + "')";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }

        //---------------组织、功能、属性（数据范围）
        /// <summary>
        /// 根据功能ID、上级ID取得功能属性数据集,可读写
        /// </summary>        
        /// <param name="Forg_id">组织ID</param>
        /// <param name="FFunc_id">功能ID</param>
        /// <returns></returns>
        public DataSet OrgFuncPropertyLoadDS(string Forg_id, string FFunc_id)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM sys_org_func_property Where Forg_id='" + Forg_id + "' and FFunc_id='" + FFunc_id + "' Order by FIndex";
            ds = this.DataSetLoadBySql(sql, "sys_org_func_property");
            return ds;
        }

        /// <summary>
        /// 根据功能ID、上级ID取得功能属性数据集,可读
        /// </summary>        
        /// <param name="Forg_id">组织ID</param>
        /// <param name="FFunc_id">功能ID</param>
        /// <returns></returns>
        public DataSet OrgFuncPropertyExcuteDS(string Forg_id, string FFunc_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM sys_org_func_property Where Forg_id='" + Forg_id + "' and FFunc_id='" + FFunc_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
       

        /// <summary>
        /// 通过存储过程 批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int OrgFuncPropertyUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_org_func_property_ADD";//存过_新增 
            string strStoredProcDelete = "sys_org_func_property_Delete";//存过_删除 
            string strStoredProcUpdate = "sys_org_func_property_Update";//存过_修改         
            string strStrKey = "FProperty_ID";//主键名      
            string strStrTableName = "sys_org_func_property";//表名          
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
        /// <summary>
        /// 根据组织ID取得组织数据集，只读
        /// </summary>
        /// <param name="strForg_id">组织ID</param>
        /// <returns></returns>
        public DataSet GetOrgDSByOrgId(string strForg_id)
        {
            DataSet ds = null;
            string sql = "SELECT * FROM v_sys_org where forg_id='" + strForg_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        //---------------组织、功能、属性（数据范围）
    }
}
