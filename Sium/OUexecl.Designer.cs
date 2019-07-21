namespace Sium
{
    partial class OUexecl
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
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.ultraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGrid2.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly;
            this.ultraGrid2.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(1127, 676);
            this.ultraGrid2.TabIndex = 18;
            // 
            // OUexecl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 676);
            this.Controls.Add(this.ultraGrid2);
            this.Name = "OUexecl";
            this.Text = "OUexecl";
            this.Load += new System.EventHandler(this.OUexecl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
    }
}