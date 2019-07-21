namespace Sium
{
    partial class NewListZTC
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
            this.ultraGridall = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).BeginInit();
            this.SuspendLayout();
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
            this.ultraGridall.Size = new System.Drawing.Size(393, 702);
            this.ultraGridall.TabIndex = 26;
            // 
            // NewListZTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 702);
            this.Controls.Add(this.ultraGridall);
            this.Name = "NewListZTC";
            this.Text = "历史成交记录表";
            this.Load += new System.EventHandler(this.NewListZTC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridall;
    }
}