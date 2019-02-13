namespace ARM_User.DisplayLayer.Guides.Base
{
  partial class DBHdBaseForm
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
        this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        this.edCountRecord = new DevExpress.XtraBars.BarStaticItem();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
        this.SuspendLayout();
        // 
        // barDockControlBottom
        // 
        this.barDockControlBottom.Location = new System.Drawing.Point(0, 403);
        this.barDockControlBottom.Size = new System.Drawing.Size(517, 0);
        // 
        // barDockControlLeft
        // 
        this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
        this.barDockControlLeft.Size = new System.Drawing.Size(0, 379);
        // 
        // barDockControlRight
        // 
        this.barDockControlRight.Location = new System.Drawing.Point(517, 24);
        this.barDockControlRight.Size = new System.Drawing.Size(0, 379);
        // 
        // barDockControlTop
        // 
        this.barDockControlTop.Size = new System.Drawing.Size(517, 24);
        // 
        // MainBS
        // 
        this.MainBS.CurrentChanged += new System.EventHandler(this.MainBS_CurrentChanged);
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
        // repositoryItemTextEdit1
        // 
        this.repositoryItemTextEdit1.AutoHeight = false;
        this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
        // 
        // edCountRecord
        // 
        this.edCountRecord.Id = 4;
        this.edCountRecord.Name = "edCountRecord";
        this.edCountRecord.TextAlignment = System.Drawing.StringAlignment.Near;
        // 
        // DBHdBaseForm
        // 
        this.ClientSize = new System.Drawing.Size(517, 403);
        this.Name = "DBHdBaseForm";
        this.Text = "DBListROForm";
        this.Load += new System.EventHandler(this.DBListRoForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.BindingSource MainBS;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    protected DevExpress.XtraBars.BarButtonItem btnRefresh;
    private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    public DevExpress.XtraBars.BarStaticItem edCountRecord;
  }
}
