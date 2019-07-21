namespace Sium
{
    partial class DayListPage
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGridall = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).BeginInit();
            this.ultraTabControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ultraGridall);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(1, 22);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(930, 715);
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
            this.ultraGridall.Size = new System.Drawing.Size(930, 715);
            this.ultraGridall.TabIndex = 24;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(930, 715);
            // 
            // ultraTabControl4
            // 
            this.ultraTabControl4.Controls.Add(this.ultraTabSharedControlsPage5);
            this.ultraTabControl4.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl4.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl4.Name = "ultraTabControl4";
            this.ultraTabControl4.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.ultraTabControl4.Size = new System.Drawing.Size(932, 738);
            this.ultraTabControl4.TabIndex = 5;
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "流量今日";
            this.ultraTabControl4.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3});
            this.ultraTabControl4.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // DayListPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 738);
            this.Controls.Add(this.ultraTabControl4);
            this.Name = "DayListPage";
            this.Text = "DayListPage";
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).EndInit();
            this.ultraTabControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridall;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl4;
    }
}