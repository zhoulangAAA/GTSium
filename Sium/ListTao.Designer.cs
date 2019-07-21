namespace Sium
{
    partial class ListTao
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("View_Keyorder", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("orkeyword");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("orvalue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("keypv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("keytype");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("keydate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UnboundColumn1", 0);
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("sumkeypv", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "sum( [keypv] )", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "keypv", 3, true);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("sumorvalue", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "sum( [orvalue] )", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "keypv", 3, true);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings3 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "[sumorvalue()] / [sumkeypv()]", null, -1, false, null, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "keypv", 3, true);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SrcFlow", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pageName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("uv");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("uvRate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pvRate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("getdatedey");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("shopID");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTao));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ItemTrend", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("payOrdCntList");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("payByrRateIndexList");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("payItemQtyList");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("paydate");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ultraGrid3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraCalcManager1 = new Infragistics.Win.UltraWinCalcManager.UltraCalcManager(this.components);
            this.taosysData = new Sium.TaosysData();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.srcFlowBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.srcFlowBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.view_KeyorderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.srcFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemTrendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taosysData)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcFlowBindingNavigator)).BeginInit();
            this.srcFlowBindingNavigator.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_KeyorderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcFlowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTrendBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 100);
            this.groupBox1.TabIndex = 0;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(736, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "导出来源";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "关建字导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 584);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ultraGrid3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1000, 558);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "专业版关建字成交";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ultraGrid3
            // 
            this.ultraGrid3.AllowDrop = true;
            this.ultraGrid3.CalcManager = this.ultraCalcManager1;
            this.ultraGrid3.DataSource = this.view_KeyorderBindingSource;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 131;
            ultraGridColumn2.Header.Caption = "关键字";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn3.Header.Caption = "订单量";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Caption = "访客量";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 134;
            ultraGridColumn5.Header.Caption = "PC/无线";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Caption = "日期";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Format = "0.00%";
            ultraGridColumn7.Formula = "[orvalue] / [keypv]";
            ultraGridColumn7.Header.Caption = "转化率";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn7.MaskInput = "0.00%";
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand1.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            summarySettings1.DisplayFormat = "总访客= {0}";
            summarySettings1.GroupBySummaryValueAppearance = appearance1;
            summarySettings2.DisplayFormat = "总成交量= {0:}";
            summarySettings2.GroupBySummaryValueAppearance = appearance2;
            summarySettings3.DisplayFormat = "平均转化率：{0:00.0%}";
            summarySettings3.GroupBySummaryValueAppearance = appearance3;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2,
            summarySettings3});
            this.ultraGrid3.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.ultraGrid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType;
            this.ultraGrid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid3.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid3.Name = "ultraGrid3";
            this.ultraGrid3.Size = new System.Drawing.Size(1000, 558);
            this.ultraGrid3.TabIndex = 4;
            this.ultraGrid3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraCalcManager1
            // 
            this.ultraCalcManager1.ContainingControl = this;
            // 
            // taosysData
            // 
            this.taosysData.DataSetName = "TaosysData";
            this.taosysData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 558);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "生意直通车";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ultraGrid1);
            this.tabPage1.Controls.Add(this.srcFlowBindingNavigator);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PC流量来源";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.AllowDrop = true;
            this.ultraGrid1.CalcManager = this.ultraCalcManager1;
            this.ultraGrid1.DataSource = this.srcFlowBindingSource;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 2;
            ultraGridColumn17.Width = 131;
            ultraGridColumn18.Header.Caption = "访客数";
            ultraGridColumn18.Header.VisiblePosition = 0;
            ultraGridColumn18.Width = 104;
            ultraGridColumn27.Header.Caption = "渠道";
            ultraGridColumn27.Header.VisiblePosition = 3;
            ultraGridColumn27.Width = 131;
            ultraGridColumn28.Header.Caption = "流量";
            ultraGridColumn28.Header.VisiblePosition = 4;
            ultraGridColumn28.Width = 102;
            ultraGridColumn29.Format = "0.00%";
            ultraGridColumn29.Header.Caption = "访客百分比";
            ultraGridColumn29.Header.VisiblePosition = 6;
            ultraGridColumn29.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn29.MaskInput = "n.nn%";
            ultraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn29.Width = 117;
            ultraGridColumn36.Format = "0.00%";
            ultraGridColumn36.Header.Caption = "流量百分比";
            ultraGridColumn36.Header.VisiblePosition = 5;
            ultraGridColumn36.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn36.MaskInput = "n.nn%";
            ultraGridColumn36.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            ultraGridColumn36.Width = 117;
            ultraGridColumn37.Header.Caption = "日期";
            ultraGridColumn37.Header.VisiblePosition = 7;
            ultraGridColumn37.Width = 131;
            ultraGridColumn38.Header.Caption = "店铺";
            ultraGridColumn38.Header.VisiblePosition = 8;
            ultraGridColumn38.Width = 131;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ultraGrid1.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            this.ultraGrid1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            this.ultraGrid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell;
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid1.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted;
            this.ultraGrid1.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top;
            this.ultraGrid1.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid1.Location = new System.Drawing.Point(3, 28);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(994, 527);
            this.ultraGrid1.TabIndex = 3;
            this.ultraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // srcFlowBindingNavigator
            // 
            this.srcFlowBindingNavigator.AddNewItem = null;
            this.srcFlowBindingNavigator.BindingSource = this.srcFlowBindingSource;
            this.srcFlowBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.srcFlowBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.srcFlowBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem,
            this.srcFlowBindingNavigatorSaveItem,
            this.toolStripButton1});
            this.srcFlowBindingNavigator.Location = new System.Drawing.Point(3, 3);
            this.srcFlowBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.srcFlowBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.srcFlowBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.srcFlowBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.srcFlowBindingNavigator.Name = "srcFlowBindingNavigator";
            this.srcFlowBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.srcFlowBindingNavigator.Size = new System.Drawing.Size(994, 25);
            this.srcFlowBindingNavigator.TabIndex = 2;
            this.srcFlowBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // srcFlowBindingNavigatorSaveItem
            // 
            this.srcFlowBindingNavigatorSaveItem.Image = global::Sium.Properties.Resources.ZANavigatorSave;
            this.srcFlowBindingNavigatorSaveItem.Name = "srcFlowBindingNavigatorSaveItem";
            this.srcFlowBindingNavigatorSaveItem.Size = new System.Drawing.Size(76, 22);
            this.srcFlowBindingNavigatorSaveItem.Text = "保存数据";
            this.srcFlowBindingNavigatorSaveItem.Click += new System.EventHandler(this.srcFlowBindingNavigatorSaveItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Sium.Properties.Resources.ZANavigatorAdd;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ultraGrid2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1000, 558);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "一个月图表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ultraGrid2
            // 
            this.ultraGrid2.AllowDrop = true;
            this.ultraGrid2.CalcManager = this.ultraCalcManager1;
            this.ultraGrid2.DataSource = this.itemTrendBindingSource;
            ultraGridColumn39.Header.VisiblePosition = 0;
            ultraGridColumn40.Header.VisiblePosition = 1;
            ultraGridColumn41.Header.VisiblePosition = 2;
            ultraGridColumn42.Header.VisiblePosition = 3;
            ultraGridColumn43.Header.VisiblePosition = 4;
            ultraGridColumn44.Header.VisiblePosition = 5;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44});
            this.ultraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ultraGrid2.DisplayLayout.EmptyRowSettings.ShowEmptyRows = true;
            this.ultraGrid2.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            this.ultraGrid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell;
            this.ultraGrid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ultraGrid2.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted;
            this.ultraGrid2.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top;
            this.ultraGrid2.DisplayLayout.UseFixedHeaders = true;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid2.Location = new System.Drawing.Point(3, 3);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(994, 552);
            this.ultraGrid2.TabIndex = 4;
            this.ultraGrid2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Workbook (*.xls)|*.xls|All Files (*.*)|*.*";
            // 
            // view_KeyorderBindingSource
            // 
            this.view_KeyorderBindingSource.DataMember = "View_Keyorder";
            this.view_KeyorderBindingSource.DataSource = this.taosysData;
            // 
            // srcFlowBindingSource
            // 
            this.srcFlowBindingSource.DataMember = "SrcFlow";
            this.srcFlowBindingSource.DataSource = this.taosysData;
            // 
            // itemTrendBindingSource
            // 
            this.itemTrendBindingSource.DataMember = "ItemTrend";
            this.itemTrendBindingSource.DataSource = this.taosysData;
            // 
            // ListTao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 684);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListTao";
            this.Text = "专业版数据分析";
            this.Load += new System.EventHandler(this.ListTao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCalcManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taosysData)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcFlowBindingNavigator)).EndInit();
            this.srcFlowBindingNavigator.ResumeLayout(false);
            this.srcFlowBindingNavigator.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_KeyorderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcFlowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTrendBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.BindingSource srcFlowBindingSource;
        private TaosysData taosysData;
        private System.Windows.Forms.BindingNavigator srcFlowBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton srcFlowBindingNavigatorSaveItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.BindingSource view_KeyorderBindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid3;
        private Infragistics.Win.UltraWinCalcManager.UltraCalcManager ultraCalcManager1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource itemTrendBindingSource;
        private System.Windows.Forms.TabPage tabPage4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}