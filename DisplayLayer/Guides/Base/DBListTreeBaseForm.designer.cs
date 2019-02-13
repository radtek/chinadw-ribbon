namespace ARM_User.DisplayLayer.Guides.Base
{
  partial class DBListTreeBaseForm
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
        this.MainBS = new System.Windows.Forms.BindingSource(this.components);
        this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        this.treeList1 = new DevExpress.XtraTreeList.TreeList();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
        this.SuspendLayout();
        // 
        // barManager
        // 
        this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh});
        this.barManager.MaxItemId = 3;
        // 
        // barMenu
        // 
        this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
        // 
        // MainBS
        // 
        this.MainBS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.MainBS_ListChanged);
        // 
        // btnRefresh
        // 
        this.btnRefresh.Caption = "Обновить";
        this.btnRefresh.Glyph = global::ARM_User.Properties.Resources.refresh;
        this.btnRefresh.Id = 2;
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
        // 
        // saveFileDialog1
        // 
        this.saveFileDialog1.CreatePrompt = true;
        this.saveFileDialog1.DefaultExt = "xls";
        this.saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
        this.saveFileDialog1.RestoreDirectory = true;
        // 
        // treeList1
        // 
        this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.treeList1.Location = new System.Drawing.Point(0, 31);
        this.treeList1.Name = "treeList1";
        this.treeList1.OptionsBehavior.Editable = false;
        this.treeList1.Size = new System.Drawing.Size(505, 366);
        this.treeList1.TabIndex = 4;
        // 
        // DBListTreeBaseForm
        // 
        this.ClientSize = new System.Drawing.Size(505, 397);
        this.Controls.Add(this.treeList1);
        this.Name = "DBListTreeBaseForm";
        this.Text = "DBListTreeForm";
        this.Load += new System.EventHandler(this.DBListRoForm_Load);
        this.Controls.SetChildIndex(this.barDockControlTop, 0);
        this.Controls.SetChildIndex(this.barDockControlBottom, 0);
        this.Controls.SetChildIndex(this.barDockControlRight, 0);
        this.Controls.SetChildIndex(this.barDockControlLeft, 0);
        this.Controls.SetChildIndex(this.treeList1, 0);
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.BindingSource MainBS;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    protected DevExpress.XtraBars.BarButtonItem btnRefresh;
    protected DevExpress.XtraTreeList.TreeList treeList1;
  }
}
