using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Silt.Base.Common.PopupWindow
{
    public partial class ChildForm : Form
    {
       
        public ChildForm()
        {
            InitializeComponent();
        }

        private ResultOne r;
        public ChildForm(ResultOne r)
            : this()
        {
            this.r = r;
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            r.ChangeText(this.textBox1.Text);
        }
    }
}