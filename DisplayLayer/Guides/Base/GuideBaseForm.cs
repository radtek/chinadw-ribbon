using System.ComponentModel;
using BSB.Common;
using DevExpress.XtraBars;

namespace ARM_User.DisplayLayer.Guides
{
  /// <summary>
  ///   Базовая форма для справочников
  /// </summary>
  public class GuideBaseForm : MDIChildForm
  {
    protected BarButtonItem btnBeginEdit;
    protected BarButtonItem btnCancelEdit;
    protected BarButtonItem btnDelete;
    protected BarButtonItem btnInsert;
    protected BarButtonItem btnRefresh;
    protected BarButtonItem btnSave;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public GuideBaseForm()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideBaseForm));
        this.btnInsert = new DevExpress.XtraBars.BarButtonItem();
        this.btnBeginEdit = new DevExpress.XtraBars.BarButtonItem();
        this.btnSave = new DevExpress.XtraBars.BarButtonItem();
        this.btnCancelEdit = new DevExpress.XtraBars.BarButtonItem();
        this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
        this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        this.SuspendLayout();
        // 
        // barDockControlBottom
        // 
        resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
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
        // barManager
        // 
        this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            ((DevExpress.XtraBars.BarManagerCategory)(resources.GetObject("barManager.Categories")))});
        this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInsert,
            this.btnDelete,
            this.btnBeginEdit,
            this.btnSave,
            this.btnCancelEdit,
            this.btnRefresh});
        this.barManager.MaxItemId = 8;
        // 
        // btnInsert
        // 
        resources.ApplyResources(this.btnInsert, "btnInsert");
        this.btnInsert.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnInsert.Glyph = global::ARM_User.Resources.AppResource.add2;
        this.btnInsert.Id = 2;
        this.btnInsert.Name = "btnInsert";
        // 
        // btnBeginEdit
        // 
        resources.ApplyResources(this.btnBeginEdit, "btnBeginEdit");
        this.btnBeginEdit.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnBeginEdit.Glyph = global::ARM_User.Resources.AppResource.edit;
        this.btnBeginEdit.Id = 3;
        this.btnBeginEdit.Name = "btnBeginEdit";
        // 
        // btnSave
        // 
        resources.ApplyResources(this.btnSave, "btnSave");
        this.btnSave.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnSave.Glyph = global::ARM_User.Resources.AppResource.disk_blue;
        this.btnSave.Id = 4;
        this.btnSave.Name = "btnSave";
        // 
        // btnCancelEdit
        // 
        resources.ApplyResources(this.btnCancelEdit, "btnCancelEdit");
        this.btnCancelEdit.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnCancelEdit.Glyph = global::ARM_User.Resources.AppResource.undo;
        this.btnCancelEdit.Id = 5;
        this.btnCancelEdit.Name = "btnCancelEdit";
        // 
        // btnDelete
        // 
        resources.ApplyResources(this.btnDelete, "btnDelete");
        this.btnDelete.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnDelete.Glyph = global::ARM_User.Resources.AppResource.delete2;
        this.btnDelete.Id = 6;
        this.btnDelete.Name = "btnDelete";
        // 
        // btnRefresh
        // 
        resources.ApplyResources(this.btnRefresh, "btnRefresh");
        this.btnRefresh.CategoryGuid = new System.Guid("5bb41f35-774c-4c14-b1f3-312f02d763bd");
        this.btnRefresh.Glyph = global::ARM_User.Resources.AppResource.refresh;
        this.btnRefresh.Id = 7;
        this.btnRefresh.Name = "btnRefresh";
        // 
        // GuideBaseForm
        // 
        resources.ApplyResources(this, "$this");
        this.Name = "GuideBaseForm";
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected virtual void EndEdit()
    {
      ValidateChildren();
    }

    protected virtual void CancelEdit()
    {
    }
  }
}