using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Silt.Base.Common.PopupWindow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ResultOne r = new ResultOne();
            r.TextChanged += new TextChangedHandler1 (this.EventResultChanged);
            ChildForm fc = new ChildForm(r);
            fc.ShowDialog();

        }

        private void EventResultChanged(string s)
        {
            this.textBox1.Text = s;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}