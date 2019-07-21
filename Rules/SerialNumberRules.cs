using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Silt.Client.Rules
{
    public class SerialNumberRules : ZASuiteDAORulesSys
    {

        public SerialNumberRules()
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
        public DataSet ZAGetDataSet(string strType)
        {
            string sql;
            DataSet ds = new DataSet();
            if (strType == "")
            {
                sql = "SELECT * FROM sys_serialNumber ORDER BY ftype";
            }
            else {
                sql = "SELECT * FROM sys_serialNumber where ftype ='" + strType + "' ORDER BY ftype";
            }
            ds = this.DataSetLoadBySql(sql, "sys_serialNumber");
            return ds;
        }
          
    }
}
