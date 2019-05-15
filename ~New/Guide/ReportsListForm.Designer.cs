namespace ARM_User.New.Guide
{
    partial class ReportsListForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsListForm));
            DevExpress.Utils.SimpleContextButton simpleContextButton1 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dsMain = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.tab1 = new DevExpress.XtraVerticalGrid.Tab();
            this.tab2 = new DevExpress.XtraVerticalGrid.Tab();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.bCount = new DevExpress.XtraBars.BarHeaderItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bPeriod = new DevExpress.XtraBars.BarEditItem();
            this.rPeriodComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.rbutton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rpLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colrep_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colperiod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrep_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_begin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate_end = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dcButton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colis_active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsql_arm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xpPageSelector1 = new DevExpress.Xpo.XPPageSelector(this.components);
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPeriodComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBeginEdit
            // 
            this.btnBeginEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBeginEdit.ImageOptions.Image")));
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelEdit.ImageOptions.Image")));
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            // 
            // btnInsert
            // 
            this.btnInsert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.ImageOptions.Image")));
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 470);
            this.barDockControlBottom.Size = new System.Drawing.Size(891, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(891, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(891, 28);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1,
            this.barListItem1,
            this.barEditItem2,
            this.bCount,
            this.bPeriod});
            this.barManager.MaxItemId = 15;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemComboBox1,
            this.repositoryLookUpEdit1,
            this.rPeriodComboBox});
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bCount),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.bPeriod, "", false, true, true, 158, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            // 
            // iEnableAutoSize
            // 
            this.iEnableAutoSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iEnableAutoSize.ImageOptions.Image")));
            this.iEnableAutoSize.ImageOptions.ImageIndex = 0;
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "tablePeriod";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ord";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "period";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.dataTable2.TableName = "tableReports";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "rep_num";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "name";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "code";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "period";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "rep_type";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "date_begin";
            this.dataColumn8.DataType = typeof(System.DateTime);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "date_end";
            this.dataColumn9.DataType = typeof(System.DateTime);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "sql_arm";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "is_active";
            this.dataColumn11.DataType = typeof(int);
            // 
            // tab1
            // 
            this.tab1.Caption = "Tab 1";
            this.tab1.Name = "tab1";
            // 
            // tab2
            // 
            this.tab2.Caption = "Tab 2";
            this.tab2.Name = "tab2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 8;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "barListItem1";
            this.barListItem1.Id = 9;
            this.barListItem1.Name = "barListItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemCheckedComboBoxEdit1;
            this.barEditItem2.Id = 10;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton1.Caption = "Yearly";
            simpleContextButton1.Id = new System.Guid("c5bb465a-24d3-4224-b96a-ceef43c20624");
            simpleContextButton1.Name = "simpleContextButton1";
            this.repositoryItemCheckedComboBoxEdit1.ContextButtons.Add(simpleContextButton1);
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // bCount
            // 
            this.bCount.Caption = "0";
            this.bCount.Id = 11;
            this.bCount.Name = "bCount";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryLookUpEdit1
            // 
            this.repositoryLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.repositoryLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tablePeriod.period", "table Period.period", 90, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryLookUpEdit1.DataSource = this.dsMain;
            this.repositoryLookUpEdit1.DisplayMember = "tableReports.period";
            this.repositoryLookUpEdit1.ImmediatePopup = true;
            this.repositoryLookUpEdit1.Name = "repositoryLookUpEdit1";
            this.repositoryLookUpEdit1.NullText = "выберите период";
            this.repositoryLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryLookUpEdit1.ValueMember = "tablePeriod.period";
            // 
            // bPeriod
            // 
            this.bPeriod.Caption = "Периодичность:";
            this.bPeriod.Edit = this.rPeriodComboBox;
            this.bPeriod.EditValue = "";
            this.bPeriod.Id = 14;
            this.bPeriod.Name = "bPeriod";
            this.bPeriod.EditValueChanged += new System.EventHandler(this.bPeriod_EditValueChanged);
            // 
            // rPeriodComboBox
            // 
            this.rPeriodComboBox.AutoHeight = false;
            this.rPeriodComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rPeriodComboBox.Name = "rPeriodComboBox";
            this.rPeriodComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.rPeriodComboBox.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.rPeriodComboBox_Closed);
            // 
            // rbutton
            // 
            editorButtonImageOptions1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            editorButtonImageOptions1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            serializableAppearanceObject1.Options.UseImage = true;
            this.rbutton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Настройки", -1, true, true, true, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F10)), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rbutton.Name = "rbutton";
            this.rbutton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbutton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbutton_ButtonPressed);
            // 
            // rpLookUpEdit2
            // 
            this.rpLookUpEdit2.AutoHeight = false;
            this.rpLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tablePeriod.period", "Имя4")});
            this.rpLookUpEdit2.DataSource = this.dsMain;
            this.rpLookUpEdit2.DisplayMember = "tablePeriod.period";
            this.rpLookUpEdit2.Name = "rpLookUpEdit2";
            // 
            // winExplorerView1
            // 
            this.winExplorerView1.GridControl = this.gridControl1;
            this.winExplorerView1.Name = "winExplorerView1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "tableReports";
            this.gridControl1.DataSource = this.dsMain;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rbutton,
            this.rpLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(891, 442);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.winExplorerView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colrep_num,
            this.colname,
            this.colcode,
            this.colperiod,
            this.colrep_type,
            this.coldate_begin,
            this.coldate_end,
            this.dcButton,
            this.colis_active,
            this.colsql_arm});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.RtfPageHeader = resources.GetString("gridView1.OptionsPrint.RtfPageHeader");
            this.gridView1.OptionsSelection.CheckBoxSelectorField = "period";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colrep_num
            // 
            this.colrep_num.Caption = "Номер";
            this.colrep_num.FieldName = "rep_num";
            this.colrep_num.Name = "colrep_num";
            this.colrep_num.OptionsColumn.AllowEdit = false;
            this.colrep_num.Visible = true;
            this.colrep_num.VisibleIndex = 0;
            this.colrep_num.Width = 46;
            // 
            // colname
            // 
            this.colname.Caption = "Найменование отчета";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.OptionsColumn.AllowEdit = false;
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 390;
            // 
            // colcode
            // 
            this.colcode.Caption = "Код";
            this.colcode.FieldName = "code";
            this.colcode.Name = "colcode";
            this.colcode.OptionsColumn.AllowEdit = false;
            this.colcode.Visible = true;
            this.colcode.VisibleIndex = 2;
            this.colcode.Width = 46;
            // 
            // colperiod
            // 
            this.colperiod.Caption = "Периодичность";
            this.colperiod.FieldName = "period";
            this.colperiod.Name = "colperiod";
            this.colperiod.OptionsColumn.AllowEdit = false;
            this.colperiod.Visible = true;
            this.colperiod.VisibleIndex = 3;
            this.colperiod.Width = 96;
            // 
            // colrep_type
            // 
            this.colrep_type.Caption = "Тип (тип настроек)";
            this.colrep_type.FieldName = "rep_type";
            this.colrep_type.Name = "colrep_type";
            this.colrep_type.OptionsColumn.AllowEdit = false;
            this.colrep_type.Width = 88;
            // 
            // coldate_begin
            // 
            this.coldate_begin.Caption = "Дата начала действия";
            this.coldate_begin.FieldName = "date_begin";
            this.coldate_begin.Name = "coldate_begin";
            this.coldate_begin.OptionsColumn.AllowEdit = false;
            this.coldate_begin.Visible = true;
            this.coldate_begin.VisibleIndex = 4;
            this.coldate_begin.Width = 87;
            // 
            // coldate_end
            // 
            this.coldate_end.Caption = "Дата оканчания действия";
            this.coldate_end.FieldName = "date_end";
            this.coldate_end.Name = "coldate_end";
            this.coldate_end.OptionsColumn.AllowEdit = false;
            this.coldate_end.Visible = true;
            this.coldate_end.VisibleIndex = 5;
            this.coldate_end.Width = 94;
            // 
            // dcButton
            // 
            this.dcButton.Caption = "Кнопка для перехода  в форму настройки";
            this.dcButton.ColumnEdit = this.rbutton;
            this.dcButton.Name = "dcButton";
            this.dcButton.OptionsColumn.FixedWidth = true;
            this.dcButton.Visible = true;
            this.dcButton.VisibleIndex = 6;
            this.dcButton.Width = 80;
            // 
            // colis_active
            // 
            this.colis_active.FieldName = "is_active";
            this.colis_active.MinWidth = 25;
            this.colis_active.Name = "colis_active";
            this.colis_active.Width = 94;
            // 
            // colsql_arm
            // 
            this.colsql_arm.FieldName = "sql_arm";
            this.colsql_arm.MinWidth = 25;
            this.colsql_arm.Name = "colsql_arm";
            this.colsql_arm.Width = 94;
            // 
            // xpPageSelector1
            // 
            this.xpPageSelector1.Collection = this.xpCollection1;
            // 
            // ReportsListForm
            // 
            this.ClientSize = new System.Drawing.Size(891, 470);
            this.Controls.Add(this.gridControl1);
            this.Name = "ReportsListForm";
            this.Text = "Список отчетов";
            this.Load += new System.EventHandler(this.ReportsListForm_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPeriodComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraVerticalGrid.Tab tab1;
        private DevExpress.XtraVerticalGrid.Tab tab2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraBars.BarHeaderItem bCount;        
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryLookUpEdit1;
        private System.Data.DataSet dsMain;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private DevExpress.XtraBars.BarEditItem bPeriod;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rPeriodComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbutton;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpLookUpEdit2;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.Xpo.XPPageSelector xpPageSelector1;
        private DevExpress.Xpo.XPCollection xpCollection1;
        private System.Data.DataColumn dataColumn10;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colrep_num;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colcode;
        private DevExpress.XtraGrid.Columns.GridColumn colperiod;
        private DevExpress.XtraGrid.Columns.GridColumn colrep_type;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_begin;
        private DevExpress.XtraGrid.Columns.GridColumn coldate_end;
        private DevExpress.XtraGrid.Columns.GridColumn dcButton;
        private System.Data.DataColumn dataColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colis_active;
        private DevExpress.XtraGrid.Columns.GridColumn colsql_arm;
    }
}
