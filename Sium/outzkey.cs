using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sium
{
    public partial class outzkey : Form
    {
        public outzkey(DataTable Ds)
        {
            InitializeComponent();
          
            this.ultraGrid1.DataSource = Ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
            Process.Start(fileName);
        }
    }
}
