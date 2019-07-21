using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataAccessLayer.DataAccess;

namespace Sium
{
    public partial class DPoneLook : Form
    {
        static private string xulrunnerPath = Application.StartupPath + "\\xulrunner";
        string  CTit, CItemid;
        public DPoneLook(string shopTit, string ItemID)
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(xulrunnerPath);
            CTit = shopTit;
             CItemid = ItemID;
            this.Text = "https://detail.tmall.com/item.htm?id="+CItemid;
          
        }

        private void DPoneLook_Load(object sender, EventArgs e)
        {
            test();
        }
        public void test()
        {
            geckoWebBrowser1.Navigate("https://detail.tmall.com/item.htm?id=" + CItemid);
          
        }
    }
}
