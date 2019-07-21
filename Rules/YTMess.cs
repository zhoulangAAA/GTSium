using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace Silt.Client.Rules
{
    public class YTMess : ZASuiteDAORulesSys
    {
      
        public YTMess()
		{
		}
		/// <summary>
        /// 
        /// </summary>
        /// <param name="FProducer_ID"></param>
        /// <returns></returns>
        public DataSet ByidDSWrite(string byID)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM YT_ms Where MS_ID='" + byID + "'";
            ds = this.DataSetLoadBySql(sql, "YT_ms");
            return ds;
        }
		/// <summary>
        /// 
        /// </summary>
        /// <param name="dsObject"></param>
        /// <returns></returns>
		 public int ZAUpdate(DataSet dsObject)
        {
            string strStoredProcAdd = "Y_YT_m_Insert";
            string strStoredProcDelete = "Y_YT_m_Delete";
            string strStoredProcUpdate = "Y_YT_m_Update";       
            string strStrKey = "MS_ID";
            string strStrTableName = "YT_ms";                
            return this.DataSetUpdate(dsObject, strStrTableName, strStrKey, strStoredProcAdd, strStoredProcDelete, strStoredProcUpdate);
        }
    }
}
