namespace Sium
{
    partial class cmKeyfrom
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("View_CMKeyword", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Itemid");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("crmName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("uv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cltCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("crtByrCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("payByrCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("indate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pageName");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("sumuv", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "sum( [uv] )", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "payByrCnt", 6, true);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("sumorvalue", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "sum( [payByrCnt] )", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "payByrCnt", 6, true);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings3 = new Infragistics.Win.UltraWinGrid.SummarySettings("ff", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "[sumorvalue()] / [sumuv()]", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "payByrCnt", 6, true);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("View_CMKeyword", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Itemid");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("crmName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("uv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cltCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("crtByrCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("payByrCnt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("indate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pageName");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ultraGrid3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.cmkeywordbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taosysData = new Sium.TaosysData();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmkeywordbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taosysData)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "加载";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "关建字导出";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ultraGrid3
            // 
            this.ultraGrid3.CalcManager = this.ultraCalcManager1;
            this.ultraGrid3.DataSource = this.cmkeywordbindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 131;
            ultraGridColumn3.Header.Caption = "店铺";
            ultraGridColumn3.Header.VisiblePosition = 7;
            ultraGridColumn4.Header.Caption = "访客数";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.Caption = "收藏";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.Header.Caption = "加购";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn7.Header.Caption = "订单数";
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn8.Header.Caption = "日期";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.Caption = "关键字";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand2.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            summarySettings1.DisplayFormat = "总访客= {0}";
            summarySettings1.GroupBySummaryValueAppearance = appearance1;
            summarySettings2.DisplayFormat = "总成交量= {0:}";
            summarySettings2.GroupBySummaryValueAppearance = appearance2;
            summarySettings3.DisplayFormat = "平均转化率：{0:00.0%}";
            summarySettings3.GroupBySummaryValueAppearance = appearance3;
            ultraGridBand2.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2,
            summarySettings3});
            this.ultraGrid3.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ultraGrid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.ultraGrid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid3.Location = new System.Drawing.Point(3, 3);
            this.ultraGrid3.Name = "ultraGrid3";
            this.ultraGrid3.Size = new System.Drawing.Size(894, 520);
            this.ultraGrid3.TabIndex = 5;
            this.ultraGrid3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            // 
            // cmkeywordbindingSource
            // 
            this.cmkeywordbindingSource.DataMember = "View_CMKeyword";
            this.cmkeywordbindingSource.DataSource = this.taosysData;
            // 
            // taosysData
            // 
            this.taosysData.DataSetName = "TaosysData";
            this.taosysData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(908, 552);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ultraGrid3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(900, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生意参谋直通车";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ultraGrid1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(900, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生意参谋手淘";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(900, 526);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "直通车";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(900, 526);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "综合分析";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.CalcManager = this.ultraCalcManager1;
            this.ultraGrid1.DataSource = this.cmkeywordbindingSource;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn14.Header.VisiblePosition = 4;
            ultraGridColumn15.Header.VisiblePosition = 5;
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn18.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid1.Location = new System.Drawing.Point(3, 3);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(894, 520);
            this.ultraGrid1.TabIndex = 0;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // cmKeyfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 652);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "cmKeyfrom";
            this.Text = "生意参谋自有数据";
            this.Load += new System.EventHandler(this.cmKeyfrom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmkeywordbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taosysData)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid3;
        private System.Windows.Forms.BindingSource cmkeywordbindingSource;
        private TaosysData taosysData;
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
    }
}