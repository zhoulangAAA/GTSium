namespace Sium
{
    partial class GNumber
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("paySubOrderCnt", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("prePaySubOrderCnt", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("itemUrl", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("imgUrl", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("focus", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("rank", 6);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("self", 7);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("valid", 8);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("shopUrl", 9);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("itemid", 10);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("shopname", 11, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("dts1");
            this.ultraDataSource2 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 581);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ultraGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 405);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "大盘行情";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DataMember = "Band 0";
            this.ultraGrid1.DataSource = this.ultraDataSource2;
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.ForeColorDisabled = System.Drawing.Color.Red;
            ultraGridColumn5.Header.Appearance = appearance1;
            ultraGridColumn5.Header.Caption = "店铺";
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Caption = "今日";
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Width = 50;
            ultraGridColumn7.Header.Caption = "昨日";
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Width = 50;
            ultraGridColumn1.Header.VisiblePosition = 4;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 8;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 9;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 10;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 11;
            ultraGridColumn10.Header.VisiblePosition = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn1,
            ultraGridColumn4,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn10});
            ultraGridBand1.Expandable = false;
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid1.Location = new System.Drawing.Point(3, 17);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(234, 385);
            this.ultraGrid1.TabIndex = 16;
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 405);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(29, 128);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 35);
            this.button6.TabIndex = 18;
            this.button6.Text = "导出";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_2);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(126, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 36);
            this.button5.TabIndex = 17;
            this.button5.Text = "重执当前数据";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 36);
            this.button4.TabIndex = 16;
            this.button4.Text = "清零";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 36);
            this.button2.TabIndex = 15;
            this.button2.Text = "启动";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(127, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 36);
            this.button3.TabIndex = 14;
            this.button3.Text = "转到";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "直通车登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(240, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1266, 581);
            this.panel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ultraGrid2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1266, 581);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "小时行情";
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.ultraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGrid2.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly;
            this.ultraGrid2.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Location = new System.Drawing.Point(3, 17);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(1260, 561);
            this.ultraGrid2.TabIndex = 17;
            this.ultraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid2_InitializeLayout);
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1});
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Workbook (*.xls)|*.xls|All Files (*.*)|*.*";
            // 
            // GNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 581);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GNumber";
            this.Text = "行情走势";
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private System.Windows.Forms.Button button2;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
    }
}