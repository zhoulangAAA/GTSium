namespace Sium
{
    partial class outzkey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impression");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bidwordstr", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("date", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impressionRate", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("click", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("price", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("competition", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cvr", 6);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("avgPrice", 7);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CTR", 8);
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("impression");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导出";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ultraGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 510);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.CalcManager = this.ultraCalcManager1;
            this.ultraGrid1.DataSource = this.ultraDataSource1;
            ultraGridColumn1.Header.Caption = "展现指数";
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn2.Header.Caption = "关建字";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn3.Header.Caption = "日期";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.Header.Caption = "点击指数";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Format = "0.00%";
            ultraGridColumn5.Header.Caption = "点击指数";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Caption = "价格指数";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn8.Header.Caption = "竞争度";
            ultraGridColumn8.Header.VisiblePosition = 9;
            ultraGridColumn9.Format = "";
            ultraGridColumn9.Header.Caption = "点击转化率";
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn10.Format = "";
            ultraGridColumn10.Header.Caption = "市场均价";
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn11.Header.Caption = "点击率";
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(3, 17);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(810, 490);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "导入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Workbook (*.xls)|*.xls|All Files (*.*)|*.*";
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1});
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            // 
            // outzkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 584);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "outzkey";
            this.Text = "outzkey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
    }
}