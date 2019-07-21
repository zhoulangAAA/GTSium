using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using DataAccessLayer.DataAccess;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;
namespace Sium
{
    public partial class DppayList : Form
    {
        SQLServer Ms = new SQLServer();
        public DppayList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IshopItemID = this.comboBox1.Text;
            string sqlU = "SELECT  [DItemdate],[shopName],[访客数],[买家数],[指数],[ItemID]FROM [DPListCUST] where ItemID='"+ IshopItemID + "' order by [DItemdate] desc";
            dPListCUSTBindingSource.DataSource = Ms.runSQLDataSet(sqlU, "ss").Tables[0];

            string sqla = "SELECT * from DPhqKeywordLIstCUST where ItemID='"+ IshopItemID + "'";
            dPhqKeywordLIstCUSTBindingSource.DataSource = Ms.runSQLDataSet(sqla, "ss").Tables[0];
            //ultraGrid3.DataSource = 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid3, fileName);
            Process.Start(fileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDialog1.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            string fileName = this.saveFileDialog1.FileName;
            this.ultraGridExcelExporter1.Export(this.ultraGrid1, fileName);
            Process.Start(fileName);
        }

        private void DppayList_Load(object sender, EventArgs e)
        {
            string Sql = "SELECT DISTINCT ItemID  FROM dbo.hqUVListCUS";

            comboBox1.DisplayMember = "ItemID";//控件显示的列名  
            comboBox1.ValueMember = "ItemID";//控件值的列名  
            comboBox1.DataSource = Ms.runSQLDataSet(Sql, "ss").Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string IshopItemID = this.comboBox1.Text;
            string delSql1 = "delete from hqUVList where ItemID='" + IshopItemID + "'";
            string delSql2 = "delete from hqUVListCUS where ItemID='" + IshopItemID + "'";
            string delSql3 = "delete from hqKeywordList where ItemID='" + IshopItemID + "'";
            string delSql4 = "delete from hqKeywordListCUS where ItemID='" + IshopItemID + "'";
            Ms.ExeSQLNonQuery(delSql1);
            Ms.ExeSQLNonQuery(delSql2);
            Ms.ExeSQLNonQuery(delSql3);
            Ms.ExeSQLNonQuery(delSql4);
            string Sql = "SELECT DISTINCT ItemID  FROM dbo.hqUVListCUS";

            comboBox1.DisplayMember = "ItemID";//控件显示的列名  
            comboBox1.ValueMember = "ItemID";//控件值的列名  
            comboBox1.DataSource = Ms.runSQLDataSet(Sql, "ss").Tables[0];

        }
    }
}
