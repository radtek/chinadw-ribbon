namespace ARM_User.DisplayLayer.Guides
{
  partial class SimpleGuideTreeBaseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleGuideTreeBaseForm));
      this.treeMain = new DevExpress.XtraTreeList.TreeList();
      this.btnInsertChild = new DevExpress.XtraBars.BarButtonItem();
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
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
      // barManager
      // 
      this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInsertChild});
      // 
      // treeMain
      // 
      resources.ApplyResources(this.treeMain, "treeMain");
      this.treeMain.KeyFieldName = "Id";
      this.treeMain.Name = "treeMain";
      this.treeMain.OptionsBehavior.Editable = false;
      this.treeMain.ParentFieldName = "";
      // 
      // btnInsertChild
      // 
      resources.ApplyResources(this.btnInsertChild, "btnInsertChild");
      this.btnInsertChild.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
      this.btnInsertChild.Glyph = global::ARM_User.Resources.AppResource.element_add;
      this.btnInsertChild.Id = 8;
      this.btnInsertChild.Name = "btnInsertChild";
      // 
      // SimpleGuideTreeBaseForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.treeMain);
      this.Name = "SimpleGuideTreeBaseForm";
      this.Load += new System.EventHandler(this.SimpleGuideTreeBaseForm_Load);
      this.Controls.SetChildIndex(this.barDockControlTop, 0);
      this.Controls.SetChildIndex(this.barDockControlBottom, 0);
      this.Controls.SetChildIndex(this.barDockControlRight, 0);
      this.Controls.SetChildIndex(this.barDockControlLeft, 0);
      this.Controls.SetChildIndex(this.panelControl1, 0);
      this.Controls.SetChildIndex(this.splitterControl1, 0);
      this.Controls.SetChildIndex(this.treeMain, 0);
      ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraTreeList.TreeList treeMain;
    private DevExpress.XtraBars.BarButtonItem btnInsertChild;



  }
}