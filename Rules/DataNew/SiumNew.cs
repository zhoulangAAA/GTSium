using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataAccess;
using System.Data;
namespace Silt.Client.Rules.DataNew
{
    class SiumNew
    {
        SQLServer TDS = new SQLServer();
        public SiumNew()
        { }
        public DataTable GetCate(int parent_id)
        {
            string Sql = "SELECT  [id]  ,[title] FROM[dbo].[dt_article_category] where parent_id ="+parent_id;
            return TDS.runSQLDataSet(Sql, "get").Tables[0];
        }

      
    }
}
