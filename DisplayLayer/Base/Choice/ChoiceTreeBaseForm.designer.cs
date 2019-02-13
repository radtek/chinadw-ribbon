namespace ARM_User.DisplayLayer.Base
{
  partial class ChoiceTreeBaseForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceTreeBaseForm));
        this.MainBS = new System.Windows.Forms.BindingSource();
        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
        this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
        this.btnOk = new DevExpress.XtraEditors.SimpleButton();
        this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
        this.treeMain = new DevExpress.XtraTreeList.TreeList();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
        this.panelControl2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControl1
        // 
        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        this.panelControl1.Controls.Add(this.panelControl2);
        resources.ApplyResources(this.panelControl1, "panelControl1");
        this.panelControl1.Name = "panelControl1";
        // 
        // panelControl2
        // 
        this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        this.panelControl2.Controls.Add(this.btnOk);
        this.panelControl2.Controls.Add(this.btnCancel);
        resources.ApplyResources(this.panelControl2, "panelControl2");
        this.panelControl2.Name = "panelControl2";
        // 
        // btnOk
        // 
        resources.ApplyResources(this.btnOk, "btnOk");
        this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.btnOk.Name = "btnOk";
        // 
        // btnCancel
        // 
        resources.ApplyResources(this.btnCancel, "btnCancel");
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Name = "btnCancel";
        // 
        // treeMain
        // 
        resources.ApplyResources(this.treeMain, "treeMain");
        this.treeMain.KeyFieldName = "Id";
        this.treeMain.Name = "treeMain";
        this.treeMain.OptionsBehavior.Editable = false;
        this.treeMain.OptionsFind.AllowFindPanel = true;
        this.treeMain.ParentFieldName = "TreeParentId";
        this.treeMain.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
        // 
        // ChoiceTreeBaseForm
        // 
        this.AcceptButton = this.btnOk;
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.Controls.Add(this.treeMain);
        this.Controls.Add(this.panelControl1);
        this.Name = "ChoiceTreeBaseForm";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChoiceTreeBaseForm_FormClosed);
        this.Load += new System.EventHandler(this.ChoiceTreeBaseForm_Load);
        this.Shown += new System.EventHandler(this.ChoiceBaseForm_Shown);
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
        this.panelControl2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.BindingSource MainBS;
    protected DevExpress.XtraEditors.SimpleButton btnOk;
    protected DevExpress.XtraEditors.SimpleButton btnCancel;
    protected DevExpress.XtraEditors.PanelControl panelControl2;
    protected DevExpress.XtraEditors.PanelControl panelControl1;
    protected DevExpress.XtraTreeList.TreeList treeMain;

  }
}