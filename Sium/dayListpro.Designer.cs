namespace Sium
{
    partial class dayListpro
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Column 0", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("图像", 0);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraTabControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGridall = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).BeginInit();
            this.ultraTabControl4.SuspendLayout();
            this.ultraTabPageControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ultraTabControl4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1085, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ultraTabControl4
            // 
            this.ultraTabControl4.Controls.Add(this.ultraTabSharedControlsPage5);
            this.ultraTabControl4.Controls.Add(this.ultraTabPageControl11);
            this.ultraTabControl4.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl4.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl4.Location = new System.Drawing.Point(3, 3);
            this.ultraTabControl4.Name = "ultraTabControl4";
            this.ultraTabControl4.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.ultraTabControl4.Size = new System.Drawing.Size(1079, 750);
            this.ultraTabControl4.TabIndex = 4;
            ultraTab1.TabPage = this.ultraTabPageControl11;
            ultraTab1.Text = "大盘排行榜";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "流量今日";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "流量昨日";
            this.ultraTabControl4.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab3,
            ultraTab4});
            this.ultraTabControl4.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(1077, 727);
            // 
            // ultraTabPageControl11
            // 
            this.ultraTabPageControl11.Controls.Add(this.ultraGrid1);
            this.ultraTabPageControl11.Controls.Add(this.groupBox1);
            this.ultraTabPageControl11.Location = new System.Drawing.Point(1, 22);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new System.Drawing.Size(1077, 727);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Width = 1056;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            ultraGridColumn3.Width = 95;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(1077, 659);
            this.ultraGrid1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 659);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1077, 68);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(477, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 35);
            this.button3.TabIndex = 18;
            this.button3.Text = "加载昨天";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "加载今天";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(829, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(966, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(164, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 35);
            this.button7.TabIndex = 14;
            this.button7.Text = "大盘采集";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(20, 22);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 35);
            this.button6.TabIndex = 13;
            this.button6.Text = "大盘启动";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraGridall);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1165, 701);
            // 
            // ultraGridall
            // 
            this.ultraGridall.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGridall.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGridall.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.ultraGridall.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGridall.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly;
            this.ultraGridall.DisplayLayout.UseFixedHeaders = true;
            this.ultraGridall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridall.Location = new System.Drawing.Point(0, 0);
            this.ultraGridall.Name = "ultraGridall";
            this.ultraGridall.Size = new System.Drawing.Size(1165, 701);
            this.ultraGridall.TabIndex = 24;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGrid2);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(1165, 701);
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGrid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.ultraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGrid2.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly;
            this.ultraGrid2.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(1165, 701);
            this.ultraGrid2.TabIndex = 25;
            // 
            // timer1
            // 
            this.timer1.Interval = 900000;
            // 
            // dayListpro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 756);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "dayListpro";
            this.Text = "dayListpro";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).EndInit();
            this.ultraTabControl4.ResumeLayout(false);
            this.ultraTabPageControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl4;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl11;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridall;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private System.Windows.Forms.Timer timer1;
    }
}