using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Silt.Client.Rules
{
    /// <summary>
    /// 系统基础列表设置 
    /// </summary>
    public class BaseListRules : ZASuiteDAORulesSys
    {
        /// <summary>
        /// 门诊开申请收费否
        /// </summary>
        public static int LisClinicChargeOk = 0;
        /// <summary>
        /// 门诊开申请打印否
        /// </summary>
        public static int LisClinicApplyPrintOk = 0;
        /// <summary>
        /// 门诊申请作废否
        /// </summary>
        public static int LisClinicChargeCancel = 0;
        /// <summary>
        /// 门诊取患者HIS接口否
        /// </summary>
        public static int LisClinicPatientOk = 0;
        /// <summary>
        /// 门诊取患者HIS接口否 接口文件url
        /// </summary>
        public static string LisClinicPatientOkValue = "d:\\lis.txt";
        /// <summary>
        /// 住院开申请打印否
        /// </summary>
        public static int LisInHospitalApplyPrintOk = 0;
        /// <summary>
        /// 住院收费作废否
        /// </summary>
        public static int LisInHospitalChargeCancel = 0;
        /// <summary>
        /// 住院收费否
        /// </summary>
        public static int LisInHospitalChargeOk = 0;
        
        public BaseListRules()
        {           
            // 
            // TODO: 在此处添加构造函数逻辑
            //	
        }
        /// <summary>
        /// 设置参数值
        /// </summary>
        public void ZASetParamValue()
        {
            DataSet ds = ZAGetBaseListOnlyRead();
            DataTable dt = ds.Tables[0];
            DataRow dr = null;
            string strkey = "";
            int intUserId = 0;
            string strValue = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                strkey = dr["fkey"].ToString();
                intUserId = Convert.ToInt32(dr["fuse_id"].ToString());
                strValue =dr["fvalue"].ToString();
                switch (strkey)
                {
                    case "LisClinicChargeOk":
                        LisClinicChargeOk = intUserId;
                        break;
                    case "LisClinicApplyPrintOk":
                        LisClinicApplyPrintOk = intUserId;
                        break;
                    case "LisClinicChargeCancel":
                        LisClinicChargeCancel = intUserId;
                        break;                   
                    case "LisClinicPatientOk":
                        {
                            LisClinicPatientOk = intUserId;
                            LisClinicPatientOkValue = strValue;
                            break;
                        }
                    case "LisInHospitalApplyPrintOk":
                        LisInHospitalApplyPrintOk = intUserId;
                        break;
                    case "LisInHospitalChargeCancel":
                        LisInHospitalChargeCancel = intUserId;
                        break;
                    case "LisInHospitalChargeOk":
                        LisInHospitalChargeOk = intUserId;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 根据条件组织ID取得日志数据集
        /// </summary>
        /// <param name="strWhere">构造数据集条件</param>
        /// <returns></returns>
        public DataSet ZAGetDataSet()
        {
            string sql;
            DataSet ds = new DataSet();
            sql = "SELECT * FROM sys_base_list ORDER BY ftype, fsort_id";
            ds = this.DataSetLoadBySql(sql, "sys_base_list");
            return ds;
        }
        
        public DataSet ZAGetBaseListOnlyRead()
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_base_list";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
        /// <summary>
        /// 根据条件组织ID取得日志数据集
        /// </summary>
        /// <param name="strUse_id">启用否</param>
        /// <returns></returns>
        public DataSet ZAGetDataSetOnlyRead(string strUse_id)
        {
            string sql;
            DataSet ds = null;
            sql = "SELECT * FROM sys_base_list Where fuse_id = '" + strUse_id + "'";
            ds = this.DataSetExecuteBySql(sql);
            return ds;
        }
       /// <summary>
        /// 根据关键字取得值
       /// </summary>  
        /// <param name="strfkey">关键字</param>
       /// <returns></returns>
        public string ZAGetFvalueByFkey(string strFkey)
        {
            string sql = "SELECT fvalue FROM sys_base_list WHERE (fkey='" + strFkey + "')";
            return this.ExecuteScalarGetString(sql);
        }

        /// <summary>
        /// 通过存储过程批量增、删、改数据集
        /// </summary>
        /// <returns></returns>
        public int ZAUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "sys_base_list_ADD";//存过_新增 
            string strStoredProcDelete = "sys_base_list_Delete";//存过_删除 
            string strStoredProcUpdate = "sys_base_list_Update";//存过_修改         
            string strStrKey = "fkey";//主键名      
            string strStrTableName = "sys_base_list";//表名             
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
    }
}
