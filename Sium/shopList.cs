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
    public partial class shopList : Form
    {
        private Silt.Client.Rules.Tao.MASrcFlow baselistrules = new Silt.Client.Rules.Tao.MASrcFlow();
     
        private DataSet dsProdurcer = new DataSet();
        private DataSet KeyshaProdurcer = new DataSet();
        public shopList()
        {
            InitializeComponent();
        }

        private void shopList_Load(object sender, EventArgs e)
        {
            DataTable comTable = new DataTable();
            comTable = baselistrules.Getcombox();
            comboBox1.DisplayMember = "shopID";//控件显示的列名  
            comboBox1.ValueMember = "ItemID";//控件值的列名  
            comboBox1.DataSource = comTable;

            comboBox2.DisplayMember = "shopID";//控件显示的列名  
            comboBox2.ValueMember = "ItemID";//控件值的列名  
            comboBox2.DataSource = comTable;

            comboBox3.DisplayMember = "shopID";//控件显示的列名  
            comboBox3.ValueMember = "ItemID";//控件值的列名  
            comboBox3.DataSource = comTable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid3, fileName);
            Process.Start(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
            Process.Start(fileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dsProdurcer = baselistrules.shopkeyByidDSWrite("548142099488");
            this.shopkeywordBindingSource.DataSource = dsProdurcer;

            KeyshaProdurcer = baselistrules.shopItembyID(this.dateTimePicker1.Text, this.comboBox2.SelectedValue.ToString(), "559173102917");
            this.view_shuaKeyBindingSource.DataSource = KeyshaProdurcer;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dsProdurcer = baselistrules.shopkeyByidDSWrite(this.comboBox3.SelectedValue.ToString());
            this.shopkeywordBindingSource.DataSource = dsProdurcer;
        }
    }
}
