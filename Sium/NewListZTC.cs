using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.DataAccess;
namespace Sium
{
    public partial class NewListZTC : Form
    {
        string ItemIDID = "";
        SQLServer Ms = new SQLServer();
        public NewListZTC(string ItemID)
        {
            InitializeComponent();
            ItemIDID = ItemID;
        }

        private void NewListZTC_Load(object sender, EventArgs e)
        {
            string Sql = "SELECT distinct [indexdate] as 日期,[uvIndex] as 成交,[shopname] as 店铺 ,[picUrl] as 换图  FROM [Dp_shopindex] where ItemID='" + ItemIDID + "'order by indexdate desc";
            DataTable GetME = Ms.runSQLDataSet(Sql, "GetName").Tables[0];
            ultraGridall.DataSource = GetME;
        }
    }
}
