using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sium
{
    public partial class cmKeyfrom : Form
    {
    
        private Silt.Client.Rules.ZASuiteDAORulesQQ rulesSys = new Silt.Client.Rules.ZASuiteDAORulesQQ();
        private Silt.Client.Rules.Tao.MASrcFlow baselistrules = new Silt.Client.Rules.Tao.MASrcFlow();

        private DataSet CMKeywordProdurcer = new DataSet();
        public cmKeyfrom()
        {
            InitializeComponent();
        }

        public void KKloadDataSet(string ItemID)
        {

            CMKeywordProdurcer = baselistrules.CMKeyByidDSWriteview("560900631295");
            this.cmkeywordbindingSource.DataSource = CMKeywordProdurcer;

           
            //进行绑定  

        }

        private void cmKeyfrom_Load(object sender, EventArgs e)
        {
            KKloadDataSet("3");
        }
    }
}
