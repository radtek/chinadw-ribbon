namespace ARM_User.DisplayLayer.Guides
{
  partial class SimpleGuideOneParamForm : SimpleGuideGridBaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleGuideOneParamForm));
      this.edName = new DevExpress.XtraEditors.TextEdit();
      this.label1 = new System.Windows.Forms.Label();
      this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // gridMain
      // 
      this.gridMain.DataSource = this.MainBS;
      resources.ApplyResources(this.gridMain, "gridMain");
      // 
      // gridMainView
      // 
      this.gridMainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName});
      this.gridMainView.OptionsBehavior.AllowIncrementalSearch = true;
      this.gridMainView.OptionsBehavior.Editable = false;
      this.gridMainView.OptionsDetail.EnableMasterViewMode = false;
      this.gridMainView.OptionsView.ColumnAutoWidth = false;
      this.gridMainView.OptionsView.ShowFooter = true;
      this.gridMainView.OptionsView.ShowGroupPanel = false;
      // 
      // splitterControl1
      // 
      resources.ApplyResources(this.splitterControl1, "splitterControl1");
      // 
      // panelControl1
      // 
      this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
      this.panelControl1.Appearance.Options.UseBackColor = true;
      this.panelControl1.Controls.Add(this.label1);
      this.panelControl1.Controls.Add(this.edName);
      resources.ApplyResources(this.panelControl1, "panelControl1");
      // 
      // barMenu
      // 
      this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInsert, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBeginEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancelEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true)});
      // 
      // barDockControlTop
      // 
      resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
      // 
      // barDockControlLeft
      // 
      resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
      // 
      // barDockControlRight
      // 
      resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
      // 
      // edName
      // 
      resources.ApplyResources(this.edName, "edName");
      this.edName.Name = "edName";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // gridColumnName
      // 
      resources.ApplyResources(this.gridColumnName, "gridColumnName");
      this.gridColumnName.FieldName = "Name";
      this.gridColumnName.Name = "gridColumnName";
      this.gridColumnName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridColumnName.Summary"))))});
      // 
      // SimpleGuideOneParamForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "SimpleGuideOneParamForm";
      this.Load += new System.EventHandler(this.SimpleGuideOneParamForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.Label label1;
    protected DevExpress.XtraEditors.TextEdit edName;
    protected DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
  }
}