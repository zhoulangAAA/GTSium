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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 childForm = new Form1();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void 生意参谋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chanmu childForm = new Chanmu();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void 生意参谋ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaoBaoCC CFrom = new TaoBaoCC();
            CFrom.MdiParent = this;
            CFrom.Text = "窗口 " + childFormNumber++;
            CFrom.Show();
        }

        private void 管理数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListTao CFrom = new ListTao();
            CFrom.MdiParent = this;
            CFrom.Text = "窗口 " + childFormNumber++;
            CFrom.Show();
        }

        private void ultraExplorerBar1_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            switch (e.Item.Key)
            {
                case "流量来源":
                    {

                        TaoBaoCC CFrom = new TaoBaoCC();
                        CFrom.MdiParent = this;
                        CFrom.Text = "窗口 " + childFormNumber++;
                        CFrom.Show();
                    }
                    break;
                case "数据管理":
                    {
                        ListTao CFrom = new ListTao();
                        CFrom.MdiParent = this;
                        CFrom.Text = "窗口 " + childFormNumber++;
                        CFrom.Show();
                    }
                    break;

                case "数据分析":
                    {
                        cmKeyfrom CFrom = new cmKeyfrom();
                        CFrom.MdiParent = this;
                        CFrom.Text = "窗口 " + childFormNumber++;
                        CFrom.Show();
                    }
                    break;
                case "思路网站采集":
                    {

                        Webinsert childForm = new Webinsert();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "淘大学网站采集":
                    {
                        Form1 childForm = new Form1();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "采集测试":
                    {
                        Chanmu childForm = new Chanmu();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;

                case "数据生成":
                    {
                        TaoTxt childForm = new TaoTxt();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "图片生成":
                    {
                        TxtImg childForm = new TxtImg();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "店铺数据":
                    {
                        shopList childForm = new shopList();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "30天曲线":
                    {
                        charList childForm = new charList();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "直通车监控":
                    {
                        ztc childForm = new ztc();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "流量解析":
                    {
                        Jxtxt childForm = new Jxtxt();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "快递查询":
                    {
                        EMS childForm = new EMS();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;

                case "加密解密":
                    {
                        pstest childForm = new pstest();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "控制面板":
                    {
                        MAXList childForm = new MAXList();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;
                case "竞品分析":
                    {
                        DppayList childForm = new DppayList();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;

                case "大盘行情":
                    {
                        MAXList childForm = new MAXList();
                        childForm.MdiParent = this;
                        childForm.Text = "窗口 " + childFormNumber++;
                        childForm.Show();
                    }
                    break;



            }
        }
    }
}
