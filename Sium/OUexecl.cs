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
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;

namespace Sium
{
    public partial class OUexecl : Form
    {
        public OUexecl()
        {
            InitializeComponent();
        }

        private void OUexecl_Load(object sender, EventArgs e)
        {
            string DayName = "行情" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls";
          //  MessageBox.Show(DayName);
            SQLServer Ms = new SQLServer();
            string GSql = "select * from [Pnumber_View]";
           this.ultraGrid2.DataSource = Ms.runSQLDataSet(GSql, "ss").Tables[0];
            string fileName = "D:\\行情\\"+ DayName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid2, fileName);
            //Process.Start(fileName);
            this.Close();

        }
    }
}
