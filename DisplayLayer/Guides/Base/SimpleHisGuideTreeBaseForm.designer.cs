namespace ARM_User.DisplayLayer.Guides
{
  partial class SimpleHisGuideTreeBaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleHisGuideTreeBaseForm));
      this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.MainBS = new System.Windows.Forms.BindingSource(this.components);
      this.btnHistoryAdd = new DevExpress.XtraBars.BarButtonItem();
      this.btnHistoryDelete = new DevExpress.XtraBars.BarButtonItem();
      this.HistoryBS = new System.Windows.Forms.BindingSource(this.components);
      this.xtraTabControlBottom = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPageMain = new DevExpress.XtraTab.XtraTabPage();
      this.treeMain = new DevExpress.XtraTreeList.TreeList();
      this.xtraTabPageHistory = new DevExpress.XtraTab.XtraTabPage();
      this.gridHistory = new DevExpress.XtraGrid.GridControl();
      this.gridHistoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.barButtonItemExcel = new DevExpress.XtraBars.BarButtonItem();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.HistoryBS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlBottom)).BeginInit();
      this.xtraTabControlBottom.SuspendLayout();
      this.xtraTabPageMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
      this.xtraTabPageHistory.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridHistoryView)).BeginInit();
      this.SuspendLayout();
      // 
      // btnBeginEdit
      // 
      this.btnBeginEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBeginEdit_ItemClick);
      // 
      // btnCancelEdit
      // 
      this.btnCancelEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelEdit_ItemClick);
      // 
      // btnDelete
      // 
      this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
      // 
      // btnInsert
      // 
      this.btnInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
      // 
      // btnRefresh
      // 
      this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
      // 
      // btnSave
      // 
      this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
      // 
      // barManager
      // 
      this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnHistoryAdd,
            this.btnHistoryDelete,
            this.barButtonItemExcel});
      this.barManager.MaxItemId = 11;
      // 
      // barMenu
      // 
      this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInsert, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBeginEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHistoryAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHistoryDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancelEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true)});
      // 
      // splitterControl1
      // 
      resources.ApplyResources(this.splitterControl1, "splitterControl1");
      this.splitterControl1.Name = "splitterControl1";
      this.splitterControl1.TabStop = false;
      // 
      // panelControl1
      // 
      this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
      this.panelControl1.Appearance.Options.UseBackColor = true;
      resources.ApplyResources(this.panelControl1, "panelControl1");
      this.panelControl1.Name = "panelControl1";
      // 
      // MainBS
      // 
      this.MainBS.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.MainBS_BindingComplete);
      this.MainBS.CurrentChanged += new System.EventHandler(this.MainBS_CurrentChanged);
      this.MainBS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.MainBS_ListChanged);
      // 
      // btnHistoryAdd
      // 
      resources.ApplyResources(this.btnHistoryAdd, "btnHistoryAdd");
      this.btnHistoryAdd.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
      this.btnHistoryAdd.Glyph = global::ARM_User.Resources.AppResource.history_add;
      this.btnHistoryAdd.Id = 8;
      this.btnHistoryAdd.Name = "btnHistoryAdd";
      this.btnHistoryAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryAdd_ItemClick);
      // 
      // btnHistoryDelete
      // 
      resources.ApplyResources(this.btnHistoryDelete, "btnHistoryDelete");
      this.btnHistoryDelete.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
      this.btnHistoryDelete.Glyph = global::ARM_User.Resources.AppResource.history_delete;
      this.btnHistoryDelete.Id = 9;
      this.btnHistoryDelete.Name = "btnHistoryDelete";
      this.btnHistoryDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryDelete_ItemClick);
      // 
      // xtraTabControlBottom
      // 
      resources.ApplyResources(this.xtraTabControlBottom, "xtraTabControlBottom");
      this.xtraTabControlBottom.Name = "xtraTabControlBottom";
      this.xtraTabControlBottom.SelectedTabPage = this.xtraTabPageMain;
      this.xtraTabControlBottom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageMain,
            this.xtraTabPageHistory});
      // 
      // xtraTabPageMain
      // 
      this.xtraTabPageMain.Controls.Add(this.treeMain);
      this.xtraTabPageMain.Name = "xtraTabPageMain";
      resources.ApplyResources(this.xtraTabPageMain, "xtraTabPageMain");
      // 
      // treeMain
      // 
      resources.ApplyResources(this.treeMain, "treeMain");
      this.treeMain.KeyFieldName = "Id";
      this.treeMain.Name = "treeMain";
      this.treeMain.OptionsBehavior.Editable = false;
      this.treeMain.ParentFieldName = "";
      // 
      // xtraTabPageHistory
      // 
      this.xtraTabPageHistory.Controls.Add(this.gridHistory);
      this.xtraTabPageHistory.Name = "xtraTabPageHistory";
      resources.ApplyResources(this.xtraTabPageHistory, "xtraTabPageHistory");
      // 
      // gridHistory
      // 
      resources.ApplyResources(this.gridHistory, "gridHistory");
      this.gridHistory.MainView = this.gridHistoryView;
      this.gridHistory.Name = "gridHistory";
      this.gridHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridHistoryView});
      // 
      // gridHistoryView
      // 
      this.gridHistoryView.GridControl = this.gridHistory;
      this.gridHistoryView.Name = "gridHistoryView";
      this.gridHistoryView.OptionsBehavior.AllowIncrementalSearch = true;
      this.gridHistoryView.OptionsBehavior.Editable = false;
      this.gridHistoryView.OptionsDetail.EnableMasterViewMode = false;
      this.gridHistoryView.OptionsView.ColumnAutoWidth = false;
      this.gridHistoryView.OptionsView.ShowGroupPanel = false;
      // 
      // barButtonItemExcel
      // 
      resources.ApplyResources(this.barButtonItemExcel, "barButtonItemExcel");
      this.barButtonItemExcel.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
      this.barButtonItemExcel.Glyph = global::ARM_User.Resources.AppResource.excel;
      this.barButtonItemExcel.Id = 10;
      this.barButtonItemExcel.Name = "barButtonItemExcel";
      this.barButtonItemExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExcel_ItemClick);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.CreatePrompt = true;
      this.saveFileDialog1.DefaultExt = "xls";
      resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
      this.saveFileDialog1.RestoreDirectory = true;
      // 
      // SimpleHisGuideTreeBaseForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.xtraTabControlBottom);
      this.Controls.Add(this.splitterControl1);
      this.Controls.Add(this.panelControl1);
      this.Name = "SimpleHisGuideTreeBaseForm";
      this.Load += new System.EventHandler(this.SimpleHisGuideBaseForm_Load);
      this.Shown += new System.EventHandler(this.SimpleHisGuideBaseForm_Shown);
      this.Controls.SetChildIndex(this.barDockControlTop, 0);
      this.Controls.SetChildIndex(this.barDockControlBottom, 0);
      this.Controls.SetChildIndex(this.barDockControlRight, 0);
      this.Controls.SetChildIndex(this.barDockControlLeft, 0);
      this.Controls.SetChildIndex(this.panelControl1, 0);
      this.Controls.SetChildIndex(this.splitterControl1, 0);
      this.Controls.SetChildIndex(this.xtraTabControlBottom, 0);
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.HistoryBS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlBottom)).EndInit();
      this.xtraTabControlBottom.ResumeLayout(false);
      this.xtraTabPageMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
      this.xtraTabPageHistory.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridHistoryView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.SplitterControl splitterControl1;
    protected DevExpress.XtraEditors.PanelControl panelControl1;
    protected DevExpress.XtraBars.BarButtonItem btnHistoryAdd;
    protected DevExpress.XtraBars.BarButtonItem btnHistoryDelete;
    protected System.Windows.Forms.BindingSource MainBS;
    protected System.Windows.Forms.BindingSource HistoryBS;
    protected DevExpress.XtraTab.XtraTabPage xtraTabPageHistory;
    protected DevExpress.XtraTab.XtraTabControl xtraTabControlBottom;
    protected DevExpress.XtraTab.XtraTabPage xtraTabPageMain;
    protected DevExpress.XtraGrid.GridControl gridHistory;
    protected DevExpress.XtraGrid.Views.Grid.GridView gridHistoryView;
    protected DevExpress.XtraBars.BarButtonItem barButtonItemExcel;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    protected DevExpress.XtraTreeList.TreeList treeMain;

  }
}