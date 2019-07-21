using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Silt.Client.Rules;

namespace Sium
{
    public partial class ListTao : Form
    {
        private string LstrGuid = "";
        private Silt.Client.Rules.ZASuiteDAORulesQQ rulesSys = new Silt.Client.Rules.ZASuiteDAORulesQQ();
        private Silt.Client.Rules.Tao.MASrcFlow baselistrules = new Silt.Client.Rules.Tao.MASrcFlow();
        private bool IsAddBool = new Boolean();
        private DataSet dsProdurcer = new DataSet();
        private DataSet OrderKeydsProdurcer = new DataSet();
        private DataSet ItemKeydsProdurcer = new DataSet();

        public ListTao()
        {
            InitializeComponent();
        }

        public void loadDataSet()
        {
            comboBox1.DisplayMember = "shopID";//控件显示的列名  
            comboBox1.ValueMember = "ItemID";//控件值的列名  
            comboBox1.DataSource = baselistrules.Getcombox();
            if (LstrGuid == "-1")
            {
                //dsProdurcer = baselistrules.ByidDSWrite(1);
                //this.srcFlowBindingSource.DataSource = dsProdurcer;
                //AddClass();
                this.IsAddBool = true;
            }
            else
            {
                dsProdurcer = baselistrules.ByidDSWrite(this.textBox1.Text);
                this.srcFlowBindingSource.DataSource = dsProdurcer;

                OrderKeydsProdurcer = baselistrules.OrderKeyByidDSWrite(this.textBox1.Text);
                view_KeyorderBindingSource.DataSource = OrderKeydsProdurcer;

                ItemKeydsProdurcer = baselistrules.ItemByidDSWrite(this.textBox1.Text);
                itemTrendBindingSource.DataSource = ItemKeydsProdurcer;
                this.IsAddBool = false;
            }
        }

        private void AddClass()
        {
            try
            {
                //Silt.Client.Rules.OrgRules.StrLoginName;
                string strGuid = this.rulesSys.ZAGetGuid();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt = dsProdurcer.Tables[0];
                dr = dt.NewRow();
                dr["ID"] = 0;
                //
                dr["ItemID"] = "5555555555555";
                //
                dr["pv"] = 468464886;
                //
                dr["pageName"] =" 直通车";
                //
                dr["uv"] = 16545;
                //
                dr["uvRate"] = 0.23;
                //
                dr["pvRate"] = 0.25;
                //
                dr["getdatedey"] ="2017-4-8";
                //
                dr["shopID"] = "5656";
                    dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageProcess.ZAMessageShowError(ex.Message.ToString());
            }
        }
        private void Addup()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataRow dr = this.dsProdurcer.Tables[0].Rows[0];
              

                this.Validate();
                this.srcFlowBindingSource.EndEdit();
                if (this.IsAddBool == true)
                {
                    if (this.baselistrules.ZAUpdate(this.dsProdurcer) > 0)
                    {

                        if (MessageProcess.ZAMessageDialogResult("Are you True Adding?"))
                        {
                            loadDataSet();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (this.baselistrules.ZAUpdate(this.dsProdurcer) > 0)
                    {
                        if (MessageProcess.ZAMessageDialogResult("Are you Treu update?"))
                        {
                            loadDataSet();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
               // this.zaSaveLog(ex.Message.ToString(), ex.ToString()); MessageProcess.ZAMessageShowError(ex.Message.ToString());
                MessageProcess.ZAMessageShowError(ex.Message.ToString());
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
        }

        private void srcFlowBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Addup();
            loadDataSet();
        }

        private void ListTao_Load(object sender, EventArgs e)
        {
            loadDataSet();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddClass();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid3, fileName);
            // Reset the first row index

            // Export the appropriate grid based on the selected tab
            //switch (this.ultraTabControl1.SelectedTab.Key)
            //{
            //    case "Formulas":
                   
            //        break;
            //    case "Images":
            //        this.ultraGridExcelExporter1.Export(this.ugImages, fileName);
            //        break;
            //    default:
            //        Debug.Fail("Unkown Selected Tab");
            //        return;
            //}

            // Launch the resulting xls file
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KKloadDataSet(this.comboBox1.SelectedValue.ToString());
        }

        public void KKloadDataSet(string ItemID)
        {
           
                dsProdurcer = baselistrules.ByidDSWrite(ItemID);
                this.srcFlowBindingSource.DataSource = dsProdurcer;

                OrderKeydsProdurcer = baselistrules.OrderKeyByidDSWrite(ItemID);
                view_KeyorderBindingSource.DataSource = OrderKeydsProdurcer;

                ItemKeydsProdurcer = baselistrules.ItemByidDSWrite(ItemID);
                itemTrendBindingSource.DataSource = ItemKeydsProdurcer;
                this.IsAddBool = false;
            //进行绑定  
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baselistrules.delFromItemID(this.comboBox1.SelectedValue.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
        }
    }
}
