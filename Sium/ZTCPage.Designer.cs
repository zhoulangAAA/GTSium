namespace Sium
{
    partial class ZTCPage
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DPListCUST", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("shopName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DItemdate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("买家数");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("访客数");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("指数", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UnboundColumn1", 0);
            this.ultraGrid3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid3
            // 
            this.ultraGrid3.AllowDrop = true;
            this.ultraGrid3.CalcManager = this.ultraCalcManager1;
            this.ultraGrid3.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn8.Header.Caption = "流量来源";
            ultraGridColumn8.Header.Fixed = true;
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Header.Caption = "日期";
            ultraGridColumn9.Header.Fixed = true;
            ultraGridColumn9.Header.VisiblePosition = 1;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Format = "0.00";
            ultraGridColumn7.Formula = "[买家数] / [访客数]*100";
            ultraGridColumn7.Header.Caption = "转化率";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn4,
            ultraGridColumn3,
            ultraGridColumn5,
            ultraGridColumn10,
            ultraGridColumn7});
            ultraGridBand1.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.ultraGrid3.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid3.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.ultraGrid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            this.ultraGrid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid3.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid3.Name = "ultraGrid3";
            this.ultraGrid3.Size = new System.Drawing.Size(522, 657);
            this.ultraGrid3.TabIndex = 8;
            this.ultraGrid3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            // 
            // ZTCPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 657);
            this.Controls.Add(this.ultraGrid3);
            this.Name = "ZTCPage";
            this.Text = "流量来源";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid3;
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
    }
}