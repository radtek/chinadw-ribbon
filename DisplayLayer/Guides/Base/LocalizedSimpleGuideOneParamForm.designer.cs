namespace ARM_User.DisplayLayer.Guides
{
  partial class LocalizedSimpleGuideOneParamForm : SimpleGuideGridBaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalizedSimpleGuideOneParamForm));
      this.edName = new DevExpress.XtraEditors.TextEdit();
      this.lbNameRu = new System.Windows.Forms.Label();
      this.gridColumnNameRu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.lbNameKz = new System.Windows.Forms.Label();
      this.edNameKz = new DevExpress.XtraEditors.TextEdit();
      this.gridColumnNameKz = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edNameKz.Properties)).BeginInit();
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
            this.gridColumnNameRu,
            this.gridColumnNameKz});
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
      this.panelControl1.Controls.Add(this.lbNameKz);
      this.panelControl1.Controls.Add(this.edNameKz);
      this.panelControl1.Controls.Add(this.lbNameRu);
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
      // edName
      // 
      resources.ApplyResources(this.edName, "edName");
      this.edName.Name = "edName";
      // 
      // lbNameRu
      // 
      resources.ApplyResources(this.lbNameRu, "lbNameRu");
      this.lbNameRu.Name = "lbNameRu";
      // 
      // gridColumnNameRu
      // 
      resources.ApplyResources(this.gridColumnNameRu, "gridColumnNameRu");
      this.gridColumnNameRu.FieldName = "NameRu";
      this.gridColumnNameRu.Name = "gridColumnNameRu";
      this.gridColumnNameRu.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gridColumnNameRu.Summary"))))});
      // 
      // lbNameKz
      // 
      resources.ApplyResources(this.lbNameKz, "lbNameKz");
      this.lbNameKz.Name = "lbNameKz";
      // 
      // edNameKz
      // 
      resources.ApplyResources(this.edNameKz, "edNameKz");
      this.edNameKz.Name = "edNameKz";
      // 
      // gridColumnNameKz
      // 
      resources.ApplyResources(this.gridColumnNameKz, "gridColumnNameKz");
      this.gridColumnNameKz.FieldName = "NameKz";
      this.gridColumnNameKz.Name = "gridColumnNameKz";
      // 
      // LocalizedSimpleGuideOneParamForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "LocalizedSimpleGuideOneParamForm";
      this.Load += new System.EventHandler(this.SimpleGuideOneParamForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edNameKz.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.Label lbNameRu;
    protected DevExpress.XtraEditors.TextEdit edName;
    protected DevExpress.XtraGrid.Columns.GridColumn gridColumnNameRu;
    protected System.Windows.Forms.Label lbNameKz;
    protected DevExpress.XtraEditors.TextEdit edNameKz;
    protected DevExpress.XtraGrid.Columns.GridColumn gridColumnNameKz;
  }
}