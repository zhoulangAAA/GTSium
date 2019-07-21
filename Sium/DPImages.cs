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
using System.Data.SqlClient;
namespace Sium
{
    public partial class DPImages : Form
    {
        SQLServer Ms = new SQLServer();
        string imageUrl ,cTit= "";
        public DPImages(string IRUl,string Tit)
        {
            imageUrl = IRUl;
            cTit = Tit;
            InitializeComponent();
        }

        private void ultraGridall_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int i = this.ultraGridall.ActiveRow.Index;
           // int b = this.ultraGridall.ActiveCell.Column.Index;
            string IDshopURL= this.ultraGridall.Rows[i].Cells[1].Value.ToString().Trim();
            this.pictureBox1.ImageLocation = IDshopURL;
        }

        private void DPImages_Load(object sender, EventArgs e)
        {
            string Sql = "Select top 1 [picUrl] From [Dp_shopindex] Where ItemID='" + imageUrl + "'  order by  [indexdate]desc ";
           SqlDataReader ImgRd= Ms.runSQLDataReader(Sql);
            string ImgDrRul = "";
            if (ImgRd.Read())
            {
                ImgDrRul = ImgRd["picUrl"].ToString();
            }
            ImgRd.Close();
            this.Text = cTit;
            this.pictureBox1.ImageLocation = ImgDrRul;

            string SqlA = "SELECT distinct indexdate as 日期,picUrl as 图片 FROM [Dp_shopindex] WHERE indexdate IN (SELECT max(indexdate) FROM [Dp_shopindex] where ItemID='" + imageUrl + "'group by [picUrl] )and ItemID='"+ imageUrl + "' and picurl is not null order by indexdate desc";
            DataTable GetME = Ms.runSQLDataSet(SqlA, "GetName").Tables[0];
            ultraGridall.DataSource = GetME;
        }
    }
}
