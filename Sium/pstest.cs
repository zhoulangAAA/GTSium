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
    public partial class pstest : Form
    {
        public pstest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = SecurityService.SymmetricEncrypt(this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = SecurityService.SymmetricDecrypt(this.textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = System.Configuration.ConfigurationManager.AppSettings["GuaTang"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLServer Ms = new SQLServer();
            this.textBox1.Text = Ms.ConnectionString;
        }
    }
}
