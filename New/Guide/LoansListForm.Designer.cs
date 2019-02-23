namespace ARM_User.New.Guide
{
    partial class LoansListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoansListForm));
            this.bbRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.beData = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bbFilter = new DevExpress.XtraBars.BarButtonItem();
            this.bbSearch = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcList1 = new DevExpress.XtraGrid.GridControl();
            this.dsMain = new System.Data.DataSet();
            this.dtCredits = new System.Data.DataTable();
            this.P_LOANS_SID = new System.Data.DataColumn();
            this.LOAN_SID = new System.Data.DataColumn();
            this.CUSTOMER_NO = new System.Data.DataColumn();
            this.STATUS_CODE = new System.Data.DataColumn();
            this.STATUS_NAME = new System.Data.DataColumn();
            this.REF_NO = new System.Data.DataColumn();
            this.CONTRACT_NO = new System.Data.DataColumn();
            this.DRAWDOWN_DATE = new System.Data.DataColumn();
            this.MATURITY_DATE = new System.Data.DataColumn();
            this.YEAR_NO = new System.Data.DataColumn();
            this.CURRENCY_CODE = new System.Data.DataColumn();
            this.AMOUNT = new System.Data.DataColumn();
            this.RATE_INTEREST = new System.Data.DataColumn();
            this.CUSTOMER_NAME = new System.Data.DataColumn();
            this.dtExtraPokaz = new System.Data.DataTable();
            this.dcSat_loans_sid = new System.Data.DataColumn();
            this.dcLoan_sid = new System.Data.DataColumn();
            this.dcReport_date = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dcCreg_contract_no = new System.Data.DataColumn();
            this.dcCreg_contract_date = new System.Data.DataColumn();
            this.dcCrreg_line_contract_no = new System.Data.DataColumn();
            this.dcSrv_system_date = new System.Data.DataColumn();
            this.dtPokaz = new System.Data.DataTable();
            this.dc_LOAN_SID = new System.Data.DataColumn();
            this.dc_REPORT_DATE = new System.Data.DataColumn();
            this.dc_ABS_DIMENSION_ID = new System.Data.DataColumn();
            this.dc_POKAZ_ID = new System.Data.DataColumn();
            this.dc_NAME_POKAZ = new System.Data.DataColumn();
            this.dc_CODE_POKAZ = new System.Data.DataColumn();
            this.dc_dim_name = new System.Data.DataColumn();
            this.dc_dim_part = new System.Data.DataColumn();
            this.dc_T_SYSDATE = new System.Data.DataColumn();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbGredits = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvList1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gcList2 = new DevExpress.XtraGrid.GridControl();
            this.bgvExtraPokaz = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbExtraPokaz = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colreport_date = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colsrc_ddfcnt = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colcreg_contract_no = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colcreg_contract_date = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colcrreg_line_contract_no = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colsrv_system_date = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvCredits = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExtraPokazRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbExtraPokazView = new System.Windows.Forms.ToolStripButton();
            this.tsbExtraPokazAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbExtraPokazEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbExtraPokazDelete = new System.Windows.Forms.ToolStripButton();
            this.gcList3 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbPokaz = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.col_REPORT_DATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNAME_POKAZ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCODE_POKAZ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.col_dim_name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.col_dim_part = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.col_T_SYSDATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbPokazRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbPokazView = new System.Windows.Forms.ToolStripButton();
            this.tsbPokazAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbPokazEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbPokazDelete = new System.Windows.Forms.ToolStripButton();
            this.bCount = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExtraPokaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPokaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvExtraPokaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvCredits)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 575);
            this.barDockControlBottom.Size = new System.Drawing.Size(1062, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 551);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(1062, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 551);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(1062, 24);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbRefresh,
            this.beData,
            this.bbFilter,
            this.bbSearch,
            this.bCount,
            this.barButtonItem1});
            this.barManager.MaxItemId = 7;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1});
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bCount, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.beData, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            // 
            // iEnableAutoSize
            // 
            this.iEnableAutoSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iEnableAutoSize.ImageOptions.Image")));
            this.iEnableAutoSize.ImageOptions.ImageIndex = 0;
            // 
            // bbRefresh
            // 
            this.bbRefresh.Caption = "Обновить";
            this.bbRefresh.Description = "Обновить";
            this.bbRefresh.Hint = "Обновить";
            this.bbRefresh.Id = 1;
            this.bbRefresh.ImageOptions.Image = global::ARM_User.Properties.Resources.refresh;
            this.bbRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbRefresh.ImageOptions.LargeImage")));
            this.bbRefresh.Name = "bbRefresh";
            this.bbRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRefresh_ItemClick);
            // 
            // beData
            // 
            this.beData.Caption = "Дата";
            this.beData.Description = "Дата";
            this.beData.Edit = this.repositoryItemDateEdit1;
            this.beData.EditValue = new System.DateTime(2019, 1, 24, 0, 0, 0, 0);
            this.beData.EditWidth = 101;
            this.beData.Hint = "Дата";
            this.beData.Id = 2;
            this.beData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("beData.ImageOptions.Image")));
            this.beData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("beData.ImageOptions.LargeImage")));
            this.beData.Name = "beData";
            this.beData.EditValueChanged += new System.EventHandler(this.beData_EditValueChanged);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // bbFilter
            // 
            this.bbFilter.Caption = "Фильтр";
            this.bbFilter.Description = "Фильтр";
            this.bbFilter.Hint = "Фильтр";
            this.bbFilter.Id = 3;
            this.bbFilter.ImageOptions.Image = global::ARM_User.Properties.Resources.filter;
            this.bbFilter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbFilter.ImageOptions.LargeImage")));
            this.bbFilter.Name = "bbFilter";
            this.bbFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbFilter_ItemClick);
            // 
            // bbSearch
            // 
            this.bbSearch.Caption = "Поиск";
            this.bbSearch.Description = "Поиск";
            this.bbSearch.Hint = "Поиск";
            this.bbSearch.Id = 4;
            this.bbSearch.ImageOptions.Image = global::ARM_User.Properties.Resources.view;
            this.bbSearch.Name = "bbSearch";
            this.bbSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSearch_ItemClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 551);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 4;
            // 
            // gcList1
            // 
            this.gcList1.DataMember = "tsCredits";
            this.gcList1.DataSource = this.dsMain;
            this.gcList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList1.Location = new System.Drawing.Point(0, 0);
            this.gcList1.MainView = this.bandedGridView1;
            this.gcList1.MenuManager = this.barManager;
            this.gcList1.Name = "gcList1";
            this.gcList1.Size = new System.Drawing.Size(1062, 243);
            this.gcList1.TabIndex = 3;
            this.gcList1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1,
            this.gvList1});
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.dtCredits,
            this.dtExtraPokaz,
            this.dtPokaz});
            // 
            // dtCredits
            // 
            this.dtCredits.Columns.AddRange(new System.Data.DataColumn[] {
            this.P_LOANS_SID,
            this.LOAN_SID,
            this.CUSTOMER_NO,
            this.STATUS_CODE,
            this.STATUS_NAME,
            this.REF_NO,
            this.CONTRACT_NO,
            this.DRAWDOWN_DATE,
            this.MATURITY_DATE,
            this.YEAR_NO,
            this.CURRENCY_CODE,
            this.AMOUNT,
            this.RATE_INTEREST,
            this.CUSTOMER_NAME});
            this.dtCredits.TableName = "tsCredits";
            // 
            // P_LOANS_SID
            // 
            this.P_LOANS_SID.ColumnName = "P_LOANS_SID";
            this.P_LOANS_SID.DataType = typeof(int);
            // 
            // LOAN_SID
            // 
            this.LOAN_SID.ColumnName = "LOAN_SID";
            this.LOAN_SID.DataType = typeof(int);
            // 
            // CUSTOMER_NO
            // 
            this.CUSTOMER_NO.ColumnName = "CUSTOMER_NO";
            // 
            // STATUS_CODE
            // 
            this.STATUS_CODE.ColumnName = "STATUS_CODE";
            // 
            // STATUS_NAME
            // 
            this.STATUS_NAME.ColumnName = "STATUS_NAME";
            // 
            // REF_NO
            // 
            this.REF_NO.ColumnName = "REF_NO";
            // 
            // CONTRACT_NO
            // 
            this.CONTRACT_NO.ColumnName = "CONTRACT_NO";
            // 
            // DRAWDOWN_DATE
            // 
            this.DRAWDOWN_DATE.ColumnName = "DRAWDOWN_DATE";
            this.DRAWDOWN_DATE.DataType = typeof(System.DateTime);
            // 
            // MATURITY_DATE
            // 
            this.MATURITY_DATE.ColumnName = "MATURITY_DATE";
            this.MATURITY_DATE.DataType = typeof(System.DateTime);
            // 
            // YEAR_NO
            // 
            this.YEAR_NO.ColumnName = "YEAR_NO";
            this.YEAR_NO.DataType = typeof(int);
            // 
            // CURRENCY_CODE
            // 
            this.CURRENCY_CODE.ColumnName = "CURRENCY_CODE";
            // 
            // AMOUNT
            // 
            this.AMOUNT.ColumnName = "AMOUNT";
            this.AMOUNT.DataType = typeof(double);
            // 
            // RATE_INTEREST
            // 
            this.RATE_INTEREST.ColumnName = "RATE_INTEREST";
            this.RATE_INTEREST.DataType = typeof(double);
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.ColumnName = "CUSTOMER_NAME";
            // 
            // dtExtraPokaz
            // 
            this.dtExtraPokaz.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcSat_loans_sid,
            this.dcLoan_sid,
            this.dcReport_date,
            this.dataColumn1,
            this.dcCreg_contract_no,
            this.dcCreg_contract_date,
            this.dcCrreg_line_contract_no,
            this.dcSrv_system_date});
            this.dtExtraPokaz.TableName = "tsExtraPokaz";
            // 
            // dcSat_loans_sid
            // 
            this.dcSat_loans_sid.ColumnName = "sat_loans_sid";
            this.dcSat_loans_sid.DataType = typeof(int);
            // 
            // dcLoan_sid
            // 
            this.dcLoan_sid.ColumnName = "loan_sid";
            this.dcLoan_sid.DataType = typeof(int);
            // 
            // dcReport_date
            // 
            this.dcReport_date.ColumnName = "report_date";
            this.dcReport_date.DataType = typeof(System.DateTime);
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "src_ddfcnt";
            // 
            // dcCreg_contract_no
            // 
            this.dcCreg_contract_no.ColumnName = "creg_contract_no";
            // 
            // dcCreg_contract_date
            // 
            this.dcCreg_contract_date.ColumnName = "creg_contract_date";
            this.dcCreg_contract_date.DataType = typeof(System.DateTime);
            // 
            // dcCrreg_line_contract_no
            // 
            this.dcCrreg_line_contract_no.ColumnName = "crreg_line_contract_no";
            // 
            // dcSrv_system_date
            // 
            this.dcSrv_system_date.ColumnName = "srv_system_date";
            this.dcSrv_system_date.DataType = typeof(System.DateTime);
            // 
            // dtPokaz
            // 
            this.dtPokaz.Columns.AddRange(new System.Data.DataColumn[] {
            this.dc_LOAN_SID,
            this.dc_REPORT_DATE,
            this.dc_ABS_DIMENSION_ID,
            this.dc_POKAZ_ID,
            this.dc_NAME_POKAZ,
            this.dc_CODE_POKAZ,
            this.dc_dim_name,
            this.dc_dim_part,
            this.dc_T_SYSDATE});
            this.dtPokaz.TableName = "tsPokaz";
            // 
            // dc_LOAN_SID
            // 
            this.dc_LOAN_SID.ColumnName = "loan_sid";
            this.dc_LOAN_SID.DataType = typeof(int);
            // 
            // dc_REPORT_DATE
            // 
            this.dc_REPORT_DATE.ColumnName = "report_date";
            this.dc_REPORT_DATE.DataType = typeof(System.DateTime);
            // 
            // dc_ABS_DIMENSION_ID
            // 
            this.dc_ABS_DIMENSION_ID.ColumnName = "abs_dimension_id";
            this.dc_ABS_DIMENSION_ID.DataType = typeof(int);
            // 
            // dc_POKAZ_ID
            // 
            this.dc_POKAZ_ID.ColumnName = "pokaz_id";
            this.dc_POKAZ_ID.DataType = typeof(int);
            // 
            // dc_NAME_POKAZ
            // 
            this.dc_NAME_POKAZ.ColumnName = "name_pokaz";
            // 
            // dc_CODE_POKAZ
            // 
            this.dc_CODE_POKAZ.ColumnName = "code_pokaz";
            // 
            // dc_dim_name
            // 
            this.dc_dim_name.ColumnName = "dim_name";
            // 
            // dc_dim_part
            // 
            this.dc_dim_part.ColumnName = "dim_part";
            // 
            // dc_T_SYSDATE
            // 
            this.dc_T_SYSDATE.ColumnName = "t_sysdate";
            this.dc_T_SYSDATE.DataType = typeof(System.DateTime);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbGredits});
            this.bandedGridView1.ColumnPanelRowHeight = 10;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn3,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14});
            this.bandedGridView1.GridControl = this.gcList1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsBehavior.ReadOnly = true;
            this.bandedGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.bandedGridView1.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 1;
            this.bandedGridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.bandedGridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.bandedGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView1.OptionsFind.FindDelay = 100;
            this.bandedGridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.bandedGridView1.OptionsFind.SearchInPreview = true;
            this.bandedGridView1.OptionsFind.ShowFindButton = false;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridView1.OptionsView.BestFitMaxRowCount = 1;
            this.bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.bandedGridView1.OptionsView.RowAutoHeight = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.bandedGridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bandedGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList1_FocusedRowChanged);
            // 
            // gbGredits
            // 
            this.gbGredits.AppearanceHeader.Options.UseTextOptions = true;
            this.gbGredits.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbGredits.Caption = "Договора кредитов";
            this.gbGredits.Columns.Add(this.bandedGridColumn3);
            this.gbGredits.Columns.Add(this.bandedGridColumn5);
            this.gbGredits.Columns.Add(this.bandedGridColumn6);
            this.gbGredits.Columns.Add(this.bandedGridColumn7);
            this.gbGredits.Columns.Add(this.bandedGridColumn8);
            this.gbGredits.Columns.Add(this.bandedGridColumn9);
            this.gbGredits.Columns.Add(this.bandedGridColumn10);
            this.gbGredits.Columns.Add(this.bandedGridColumn11);
            this.gbGredits.Columns.Add(this.bandedGridColumn12);
            this.gbGredits.Columns.Add(this.bandedGridColumn13);
            this.gbGredits.Columns.Add(this.bandedGridColumn14);
            this.gbGredits.Name = "gbGredits";
            this.gbGredits.VisibleIndex = 0;
            this.gbGredits.Width = 742;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Код Заемщика";
            this.bandedGridColumn3.FieldName = "CUSTOMER_NO";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 37;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Статус договора(Наим.)";
            this.bandedGridColumn5.FieldName = "STATUS_NAME";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 37;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "№ референса";
            this.bandedGridColumn6.FieldName = "REF_NO";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 37;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Номер договора";
            this.bandedGridColumn7.FieldName = "CONTRACT_NO";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 37;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "Дата выдачи";
            this.bandedGridColumn8.FieldName = "DRAWDOWN_DATE";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 37;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "Дата погашения";
            this.bandedGridColumn9.FieldName = "MATURITY_DATE";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 37;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.Caption = "Год выдачи";
            this.bandedGridColumn10.FieldName = "YEAR_NO";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.Visible = true;
            this.bandedGridColumn10.Width = 37;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "Валюта договора";
            this.bandedGridColumn11.FieldName = "CURRENCY_CODE";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Visible = true;
            this.bandedGridColumn11.Width = 37;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn12.AutoFillDown = true;
            this.bandedGridColumn12.Caption = "Наименование заемщика";
            this.bandedGridColumn12.FieldName = "CUSTOMER_NAME";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Visible = true;
            this.bandedGridColumn12.Width = 376;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.AutoFillDown = true;
            this.bandedGridColumn13.Caption = "Сумма договора";
            this.bandedGridColumn13.FieldName = "AMOUNT";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.Visible = true;
            this.bandedGridColumn13.Width = 35;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.Caption = "Годовая %-ставка";
            this.bandedGridColumn14.FieldName = "RATE_INTEREST";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.Visible = true;
            this.bandedGridColumn14.Width = 35;
            // 
            // gvList1
            // 
            this.gvList1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvList1.GridControl = this.gcList1;
            this.gvList1.Name = "gvList1";
            this.gvList1.OptionsBehavior.Editable = false;
            this.gvList1.OptionsBehavior.ReadOnly = true;
            this.gvList1.OptionsDetail.EnableMasterViewMode = false;
            this.gvList1.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 1;
            this.gvList1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gvList1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvList1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvList1.OptionsFind.FindDelay = 100;
            this.gvList1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvList1.OptionsFind.SearchInPreview = true;
            this.gvList1.OptionsFind.ShowFindButton = false;
            this.gvList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvList1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gvList1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "P_LOANS_SID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 37;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "LOAN_SID";
            this.gridColumn2.FieldName = "LOAN_SID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 37;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Код Заемщика";
            this.gridColumn3.FieldName = "CUSTOMER_NO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 37;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Статус договора(Код)";
            this.gridColumn4.FieldName = "STATUS_CODE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 37;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Статус договора(Наим.)";
            this.gridColumn5.FieldName = "STATUS_NAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 37;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "№ референса";
            this.gridColumn6.FieldName = "REF_NO";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 37;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Номер договора";
            this.gridColumn7.FieldName = "CONTRACT_NO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 37;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Дата выдачи";
            this.gridColumn8.FieldName = "DRAWDOWN_DATE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 37;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Дата погашения";
            this.gridColumn9.FieldName = "MATURITY_DATE";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 37;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Год выдачи";
            this.gridColumn10.FieldName = "YEAR_NO";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 37;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Валюта договора";
            this.gridColumn11.FieldName = "CURRENCY_CODE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Width = 37;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "Наименование заемщика";
            this.gridColumn12.FieldName = "CUSTOMER_NAME";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 376;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Сумма договора";
            this.gridColumn13.FieldName = "AMOUNT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 35;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Годовая %-ставка";
            this.gridColumn14.FieldName = "RATE_INTEREST";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 35;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gcList2);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gcList3);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Size = new System.Drawing.Size(1062, 304);
            this.splitContainer2.SplitterDistance = 531;
            this.splitContainer2.TabIndex = 1;
            // 
            // gcList2
            // 
            this.gcList2.DataMember = "tsExtraPokaz";
            this.gcList2.DataSource = this.dsMain;
            this.gcList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList2.Location = new System.Drawing.Point(0, 25);
            this.gcList2.MainView = this.bgvExtraPokaz;
            this.gcList2.MenuManager = this.barManager;
            this.gcList2.Name = "gcList2";
            this.gcList2.Size = new System.Drawing.Size(531, 279);
            this.gcList2.TabIndex = 7;
            this.gcList2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvExtraPokaz,
            this.bgvCredits});
            // 
            // bgvExtraPokaz
            // 
            this.bgvExtraPokaz.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbExtraPokaz});
            this.bgvExtraPokaz.ColumnPanelRowHeight = 3;
            this.bgvExtraPokaz.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colreport_date,
            this.colsrc_ddfcnt,
            this.colcreg_contract_no,
            this.colcreg_contract_date,
            this.colcrreg_line_contract_no,
            this.colsrv_system_date});
            this.bgvExtraPokaz.GridControl = this.gcList2;
            this.bgvExtraPokaz.Name = "bgvExtraPokaz";
            this.bgvExtraPokaz.OptionsBehavior.Editable = false;
            this.bgvExtraPokaz.OptionsBehavior.ReadOnly = true;
            this.bgvExtraPokaz.OptionsNavigation.AutoFocusNewRow = true;
            this.bgvExtraPokaz.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bgvExtraPokaz.OptionsView.ShowGroupPanel = false;
            this.bgvExtraPokaz.RowHeight = 20;
            this.bgvExtraPokaz.ViewCaption = "Кредиты";
            // 
            // gbExtraPokaz
            // 
            this.gbExtraPokaz.AppearanceHeader.Options.UseTextOptions = true;
            this.gbExtraPokaz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbExtraPokaz.Caption = "Дополнительные показатели";
            this.gbExtraPokaz.Columns.Add(this.colreport_date);
            this.gbExtraPokaz.Columns.Add(this.colsrc_ddfcnt);
            this.gbExtraPokaz.Columns.Add(this.colcreg_contract_no);
            this.gbExtraPokaz.Columns.Add(this.colcreg_contract_date);
            this.gbExtraPokaz.Columns.Add(this.colcrreg_line_contract_no);
            this.gbExtraPokaz.Columns.Add(this.colsrv_system_date);
            this.gbExtraPokaz.Name = "gbExtraPokaz";
            this.gbExtraPokaz.VisibleIndex = 0;
            this.gbExtraPokaz.Width = 450;
            // 
            // colreport_date
            // 
            this.colreport_date.AppearanceHeader.Options.UseTextOptions = true;
            this.colreport_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colreport_date.AutoFillDown = true;
            this.colreport_date.Caption = "Дата действия показателя";
            this.colreport_date.FieldName = "report_date";
            this.colreport_date.Name = "colreport_date";
            this.colreport_date.Visible = true;
            // 
            // colsrc_ddfcnt
            // 
            this.colsrc_ddfcnt.AppearanceHeader.Options.UseTextOptions = true;
            this.colsrc_ddfcnt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsrc_ddfcnt.Caption = "№ договора (BOC)";
            this.colsrc_ddfcnt.FieldName = "src_ddfcnt";
            this.colsrc_ddfcnt.Name = "colsrc_ddfcnt";
            this.colsrc_ddfcnt.Visible = true;
            // 
            // colcreg_contract_no
            // 
            this.colcreg_contract_no.AppearanceHeader.Options.UseTextOptions = true;
            this.colcreg_contract_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcreg_contract_no.Caption = "№ договора (Кред. регистр)";
            this.colcreg_contract_no.FieldName = "creg_contract_no";
            this.colcreg_contract_no.Name = "colcreg_contract_no";
            this.colcreg_contract_no.Visible = true;
            // 
            // colcreg_contract_date
            // 
            this.colcreg_contract_date.AppearanceHeader.Options.UseTextOptions = true;
            this.colcreg_contract_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcreg_contract_date.Caption = "Дата договора (Кред. регистр)";
            this.colcreg_contract_date.FieldName = "creg_contract_date";
            this.colcreg_contract_date.Name = "colcreg_contract_date";
            this.colcreg_contract_date.Visible = true;
            // 
            // colcrreg_line_contract_no
            // 
            this.colcrreg_line_contract_no.AppearanceHeader.Options.UseTextOptions = true;
            this.colcrreg_line_contract_no.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcrreg_line_contract_no.Caption = "№ договора кред линии (Кред. регистр)";
            this.colcrreg_line_contract_no.FieldName = "crreg_line_contract_no";
            this.colcrreg_line_contract_no.Name = "colcrreg_line_contract_no";
            this.colcrreg_line_contract_no.Visible = true;
            // 
            // colsrv_system_date
            // 
            this.colsrv_system_date.AppearanceHeader.Options.UseTextOptions = true;
            this.colsrv_system_date.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsrv_system_date.Caption = "Текущая дата";
            this.colsrv_system_date.FieldName = "srv_system_date";
            this.colsrv_system_date.Name = "colsrv_system_date";
            this.colsrv_system_date.Visible = true;
            // 
            // bgvCredits
            // 
            this.bgvCredits.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.bgvCredits.GridControl = this.gcList2;
            this.bgvCredits.Name = "bgvCredits";
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExtraPokazRefresh,
            this.tsbExtraPokazView,
            this.tsbExtraPokazAdd,
            this.tsbExtraPokazEdit,
            this.tsbExtraPokazDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(531, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExtraPokazRefresh
            // 
            this.tsbExtraPokazRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExtraPokazRefresh.Image = global::ARM_User.Properties.Resources.refresh;
            this.tsbExtraPokazRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraPokazRefresh.Name = "tsbExtraPokazRefresh";
            this.tsbExtraPokazRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbExtraPokazRefresh.Text = "Обновить";
            // 
            // tsbExtraPokazView
            // 
            this.tsbExtraPokazView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExtraPokazView.Image = global::ARM_User.Properties.Resources.view;
            this.tsbExtraPokazView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraPokazView.Name = "tsbExtraPokazView";
            this.tsbExtraPokazView.Size = new System.Drawing.Size(23, 22);
            this.tsbExtraPokazView.Text = "Просмотр";
            this.tsbExtraPokazView.Click += new System.EventHandler(this.tsbExtraPokazView_Click);
            // 
            // tsbExtraPokazAdd
            // 
            this.tsbExtraPokazAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExtraPokazAdd.Image = global::ARM_User.Properties.Resources.add2;
            this.tsbExtraPokazAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraPokazAdd.Name = "tsbExtraPokazAdd";
            this.tsbExtraPokazAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbExtraPokazAdd.Text = "Добавить";
            this.tsbExtraPokazAdd.Click += new System.EventHandler(this.tsbExtraPokazAdd_Click);
            // 
            // tsbExtraPokazEdit
            // 
            this.tsbExtraPokazEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExtraPokazEdit.Image = global::ARM_User.Properties.Resources.edit;
            this.tsbExtraPokazEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraPokazEdit.Name = "tsbExtraPokazEdit";
            this.tsbExtraPokazEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbExtraPokazEdit.Text = "Редактировать";
            this.tsbExtraPokazEdit.Click += new System.EventHandler(this.tsbExtraPokazEdit_Click);
            // 
            // tsbExtraPokazDelete
            // 
            this.tsbExtraPokazDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExtraPokazDelete.Image = global::ARM_User.Properties.Resources.delete2;
            this.tsbExtraPokazDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExtraPokazDelete.Name = "tsbExtraPokazDelete";
            this.tsbExtraPokazDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbExtraPokazDelete.Text = "Удалить";
            this.tsbExtraPokazDelete.Click += new System.EventHandler(this.tsbExtraPokazDelete_Click);
            // 
            // gcList3
            // 
            this.gcList3.DataMember = "tsPokaz";
            this.gcList3.DataSource = this.dsMain;
            this.gcList3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList3.Location = new System.Drawing.Point(0, 25);
            this.gcList3.MainView = this.bandedGridView2;
            this.gcList3.MenuManager = this.barManager;
            this.gcList3.Name = "gcList3";
            this.gcList3.Size = new System.Drawing.Size(527, 279);
            this.gcList3.TabIndex = 6;
            this.gcList3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView2});
            // 
            // bandedGridView2
            // 
            this.bandedGridView2.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbPokaz});
            this.bandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.col_REPORT_DATE,
            this.colNAME_POKAZ,
            this.colCODE_POKAZ,
            this.col_dim_name,
            this.col_dim_part,
            this.col_T_SYSDATE});
            this.bandedGridView2.GridControl = this.gcList3;
            this.bandedGridView2.Name = "bandedGridView2";
            this.bandedGridView2.OptionsBehavior.Editable = false;
            this.bandedGridView2.OptionsBehavior.ReadOnly = true;
            this.bandedGridView2.OptionsDetail.EnableMasterViewMode = false;
            this.bandedGridView2.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 1;
            this.bandedGridView2.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.bandedGridView2.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.bandedGridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView2.OptionsFind.FindDelay = 100;
            this.bandedGridView2.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.bandedGridView2.OptionsFind.SearchInPreview = true;
            this.bandedGridView2.OptionsFind.ShowFindButton = false;
            this.bandedGridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gbPokaz
            // 
            this.gbPokaz.AppearanceHeader.Options.UseTextOptions = true;
            this.gbPokaz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbPokaz.Caption = "Показатели из абстрактного справочника";
            this.gbPokaz.Columns.Add(this.col_REPORT_DATE);
            this.gbPokaz.Columns.Add(this.colNAME_POKAZ);
            this.gbPokaz.Columns.Add(this.colCODE_POKAZ);
            this.gbPokaz.Columns.Add(this.col_dim_name);
            this.gbPokaz.Columns.Add(this.col_dim_part);
            this.gbPokaz.Columns.Add(this.col_T_SYSDATE);
            this.gbPokaz.Name = "gbPokaz";
            this.gbPokaz.VisibleIndex = 0;
            this.gbPokaz.Width = 462;
            // 
            // col_REPORT_DATE
            // 
            this.col_REPORT_DATE.Caption = "Дата действия показателя";
            this.col_REPORT_DATE.FieldName = "report_date";
            this.col_REPORT_DATE.Name = "col_REPORT_DATE";
            this.col_REPORT_DATE.Visible = true;
            this.col_REPORT_DATE.Width = 77;
            // 
            // colNAME_POKAZ
            // 
            this.colNAME_POKAZ.Caption = "Показатель (Наим.)";
            this.colNAME_POKAZ.FieldName = "name_pokaz";
            this.colNAME_POKAZ.Name = "colNAME_POKAZ";
            this.colNAME_POKAZ.Visible = true;
            this.colNAME_POKAZ.Width = 85;
            // 
            // colCODE_POKAZ
            // 
            this.colCODE_POKAZ.Caption = "Показатель (Код)";
            this.colCODE_POKAZ.FieldName = "code_pokaz";
            this.colCODE_POKAZ.Name = "colCODE_POKAZ";
            this.colCODE_POKAZ.Visible = true;
            // 
            // col_dim_name
            // 
            this.col_dim_name.Caption = "Справочник(Наим.)";
            this.col_dim_name.FieldName = "dim_name";
            this.col_dim_name.Name = "col_dim_name";
            this.col_dim_name.Visible = true;
            this.col_dim_name.Width = 73;
            // 
            // col_dim_part
            // 
            this.col_dim_part.Caption = "Справочник(подраздел)";
            this.col_dim_part.FieldName = "dim_part";
            this.col_dim_part.Name = "col_dim_part";
            this.col_dim_part.Visible = true;
            // 
            // col_T_SYSDATE
            // 
            this.col_T_SYSDATE.Caption = "Текущая дата";
            this.col_T_SYSDATE.FieldName = "t_sysdate";
            this.col_T_SYSDATE.Name = "col_T_SYSDATE";
            this.col_T_SYSDATE.Visible = true;
            this.col_T_SYSDATE.Width = 77;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPokazRefresh,
            this.tsbPokazView,
            this.tsbPokazAdd,
            this.tsbPokazEdit,
            this.tsbPokazDelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(527, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbPokazRefresh
            // 
            this.tsbPokazRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPokazRefresh.Image = global::ARM_User.Properties.Resources.refresh;
            this.tsbPokazRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPokazRefresh.Name = "tsbPokazRefresh";
            this.tsbPokazRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbPokazRefresh.Text = "Обновить";
            this.tsbPokazRefresh.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // tsbPokazView
            // 
            this.tsbPokazView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPokazView.Image = global::ARM_User.Properties.Resources.view;
            this.tsbPokazView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPokazView.Name = "tsbPokazView";
            this.tsbPokazView.Size = new System.Drawing.Size(23, 22);
            this.tsbPokazView.Text = "Просмотр";
            this.tsbPokazView.Click += new System.EventHandler(this.tsbPokazView_Click);
            // 
            // tsbPokazAdd
            // 
            this.tsbPokazAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPokazAdd.Image = global::ARM_User.Properties.Resources.add2;
            this.tsbPokazAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPokazAdd.Name = "tsbPokazAdd";
            this.tsbPokazAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbPokazAdd.Text = "Добавить";
            this.tsbPokazAdd.Click += new System.EventHandler(this.tsbPokazAdd_Click);
            // 
            // tsbPokazEdit
            // 
            this.tsbPokazEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPokazEdit.Image = global::ARM_User.Properties.Resources.edit;
            this.tsbPokazEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPokazEdit.Name = "tsbPokazEdit";
            this.tsbPokazEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbPokazEdit.Text = "Редактировать";
            this.tsbPokazEdit.Click += new System.EventHandler(this.tsbPokazEdit_Click);
            // 
            // tsbPokazDelete
            // 
            this.tsbPokazDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPokazDelete.Image = global::ARM_User.Properties.Resources.delete2;
            this.tsbPokazDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPokazDelete.Name = "tsbPokazDelete";
            this.tsbPokazDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbPokazDelete.Text = "Удалить";
            this.tsbPokazDelete.Click += new System.EventHandler(this.tsbPokazDelete_Click);
            // 
            // bCount
            // 
            this.bCount.Caption = "Количество записи";
            this.bCount.Edit = this.repositoryItemTextEdit1;
            this.bCount.EditWidth = 54;
            this.bCount.Enabled = false;
            this.bCount.Hint = "Количество записи";
            this.bCount.Id = 5;
            this.bCount.ItemAppearance.Disabled.BackColor = System.Drawing.Color.White;
            this.bCount.ItemAppearance.Disabled.Options.UseBackColor = true;
            this.bCount.ItemAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.bCount.ItemAppearance.Normal.Options.UseBackColor = true;
            this.bCount.ItemInMenuAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.bCount.ItemInMenuAppearance.Normal.Options.UseBackColor = true;
            this.bCount.Name = "bCount";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.repositoryItemTextEdit1.Appearance.Options.UseBackColor = true;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.DropDownControl = this.popupMenu1;
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // LoansListForm
            // 
            this.ClientSize = new System.Drawing.Size(1062, 575);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoansListForm";
            this.Text = "Кредиты";
            this.Load += new System.EventHandler(this.LoansListForm_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtExtraPokaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPokaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvExtraPokaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvCredits)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem bbRefresh;
        private DevExpress.XtraBars.BarEditItem beData;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem bbFilter;
        private DevExpress.XtraBars.BarButtonItem bbSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.BarEditItem bCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraGrid.GridControl gcList2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExtraPokazRefresh;
        private System.Windows.Forms.ToolStripButton tsbExtraPokazView;
        private System.Windows.Forms.ToolStripButton tsbExtraPokazAdd;
        private System.Windows.Forms.ToolStripButton tsbExtraPokazEdit;
        private System.Windows.Forms.ToolStripButton tsbExtraPokazDelete;
        private DevExpress.XtraGrid.GridControl gcList3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbPokazRefresh;
        private System.Windows.Forms.ToolStripButton tsbPokazView;
        private System.Windows.Forms.ToolStripButton tsbPokazAdd;
        private System.Data.DataSet dsMain;
        private System.Data.DataTable dtCredits;
        private System.Data.DataColumn P_LOANS_SID;
        private System.Data.DataColumn LOAN_SID;
        private System.Data.DataColumn CUSTOMER_NO;
        private System.Data.DataColumn STATUS_CODE;
        private System.Data.DataColumn STATUS_NAME;
        private System.Data.DataColumn REF_NO;
        private System.Data.DataColumn CONTRACT_NO;
        private System.Data.DataColumn DRAWDOWN_DATE;
        private System.Data.DataColumn MATURITY_DATE;
        private System.Data.DataColumn YEAR_NO;
        private System.Data.DataColumn CURRENCY_CODE;
        private System.Data.DataColumn AMOUNT;
        private System.Data.DataColumn RATE_INTEREST;
        private System.Data.DataTable dtExtraPokaz;
        private System.Data.DataTable dtPokaz;
        private System.Data.DataColumn CUSTOMER_NAME;
        private System.Data.DataColumn dcSat_loans_sid;
        private System.Data.DataColumn dcLoan_sid;
        private System.Data.DataColumn dcReport_date;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dcCreg_contract_no;
        private System.Data.DataColumn dcCreg_contract_date;
        private System.Data.DataColumn dcCrreg_line_contract_no;
        private System.Data.DataColumn dcSrv_system_date;
        private System.Data.DataColumn dc_LOAN_SID;
        private System.Data.DataColumn dc_REPORT_DATE;
        private System.Data.DataColumn dc_ABS_DIMENSION_ID;
        private System.Data.DataColumn dc_POKAZ_ID;
        private System.Data.DataColumn dc_NAME_POKAZ;
        private System.Data.DataColumn dc_CODE_POKAZ;
        private System.Data.DataColumn dc_dim_name;
        private System.Data.DataColumn dc_dim_part;
        private System.Data.DataColumn dc_T_SYSDATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvExtraPokaz;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbExtraPokaz;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colreport_date;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsrc_ddfcnt;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colcreg_contract_no;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colcreg_contract_date;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colcrreg_line_contract_no;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colsrv_system_date;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvCredits;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.GridControl gcList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbGredits;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbPokaz;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_REPORT_DATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNAME_POKAZ;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCODE_POKAZ;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_dim_name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_dim_part;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col_T_SYSDATE;
        private System.Windows.Forms.ToolStripButton tsbPokazDelete;
        private System.Windows.Forms.ToolStripButton tsbPokazEdit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}
