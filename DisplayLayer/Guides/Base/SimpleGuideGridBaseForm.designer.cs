namespace ARM_User.DisplayLayer.Guides
{
  partial class SimpleGuideGridBaseForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleGuideGridBaseForm));
        this.gridMain = new DevExpress.XtraGrid.GridControl();
        this.gridMainView = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
        this.SuspendLayout();
        // 
        // splitterControl1
        // 
        resources.ApplyResources(this.splitterControl1, "splitterControl1");
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
        this.panelControl1.Appearance.Options.UseBackColor = true;
        resources.ApplyResources(this.panelControl1, "panelControl1");
        // 
        // barDockControlLeft
        // 
        resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
        // 
        // barDockControlRight
        // 
        resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
        // 
        // barDockControlTop
        // 
        resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
        // 
        // gridMain
        // 
        resources.ApplyResources(this.gridMain, "gridMain");
        this.gridMain.MainView = this.gridMainView;
        this.gridMain.Name = "gridMain";
        this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMainView});
        // 
        // gridMainView
        // 
        this.gridMainView.GridControl = this.gridMain;
        this.gridMainView.Name = "gridMainView";
        this.gridMainView.OptionsBehavior.AllowIncrementalSearch = true;
        this.gridMainView.OptionsBehavior.Editable = false;
        this.gridMainView.OptionsDetail.EnableMasterViewMode = false;
        this.gridMainView.OptionsView.ColumnAutoWidth = false;
        this.gridMainView.OptionsView.ShowFooter = true;
        this.gridMainView.OptionsView.ShowGroupPanel = false;
        // 
        // saveFileDialog1
        // 
        this.saveFileDialog1.CreatePrompt = true;
        this.saveFileDialog1.DefaultExt = "xls";
        resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
        this.saveFileDialog1.RestoreDirectory = true;
        // 
        // SimpleGuideGridBaseForm
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.gridMain);
        this.Name = "SimpleGuideGridBaseForm";
        this.Load += new System.EventHandler(this.SimpleGuideGridBaseForm_Load);
        this.Shown += new System.EventHandler(this.SimpleGuideGridBaseForm_Shown);
        this.Controls.SetChildIndex(this.barDockControlTop, 0);
        this.Controls.SetChildIndex(this.barDockControlBottom, 0);
        this.Controls.SetChildIndex(this.barDockControlRight, 0);
        this.Controls.SetChildIndex(this.barDockControlLeft, 0);
        this.Controls.SetChildIndex(this.panelControl1, 0);
        this.Controls.SetChildIndex(this.splitterControl1, 0);
        this.Controls.SetChildIndex(this.gridMain, 0);
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraGrid.GridControl gridMain;
    protected DevExpress.XtraGrid.Views.Grid.GridView gridMainView;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;

  }
}