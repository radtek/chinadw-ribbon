namespace ARM_User.DisplayLayer.Guides
{
  partial class SimpleGuideBaseForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleGuideBaseForm));
        this.MainBS = new System.Windows.Forms.BindingSource(this.components);
        this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
        this.barButtonItemExcel = new DevExpress.XtraBars.BarButtonItem();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
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
            this.barButtonItemExcel});
        this.barManager.MaxItemId = 9;
        // 
        // MainBS
        // 
        this.MainBS.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.MainBS_BindingComplete);
        this.MainBS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.MainBS_ListChanged);
        // 
        // splitterControl1
        // 
        resources.ApplyResources(this.splitterControl1, "splitterControl1");
        this.splitterControl1.Name = "splitterControl1";
        this.splitterControl1.TabStop = false;
        // 
        // panelControl1
        // 
        resources.ApplyResources(this.panelControl1, "panelControl1");
        this.panelControl1.Name = "panelControl1";
        // 
        // barButtonItemExcel
        // 
        resources.ApplyResources(this.barButtonItemExcel, "barButtonItemExcel");
        this.barButtonItemExcel.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.barButtonItemExcel.Glyph = global::ARM_User.Resources.AppResource.excel;
        this.barButtonItemExcel.Id = 8;
        this.barButtonItemExcel.Name = "barButtonItemExcel";
        this.barButtonItemExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExcel_ItemClick);
        // 
        // SimpleGuideBaseForm
        // 
        resources.ApplyResources(this, "$this");
        this.Controls.Add(this.splitterControl1);
        this.Controls.Add(this.panelControl1);
        this.Name = "SimpleGuideBaseForm";
        this.Load += new System.EventHandler(this.SimpleGuideBaseForm_Load);
        this.Controls.SetChildIndex(this.barDockControlTop, 0);
        this.Controls.SetChildIndex(this.barDockControlBottom, 0);
        this.Controls.SetChildIndex(this.barDockControlRight, 0);
        this.Controls.SetChildIndex(this.barDockControlLeft, 0);
        this.Controls.SetChildIndex(this.panelControl1, 0);
        this.Controls.SetChildIndex(this.splitterControl1, 0);
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.BindingSource MainBS;
    protected DevExpress.XtraEditors.SplitterControl splitterControl1;
    protected DevExpress.XtraEditors.PanelControl panelControl1;
    protected DevExpress.XtraBars.BarButtonItem barButtonItemExcel;

  }
}
