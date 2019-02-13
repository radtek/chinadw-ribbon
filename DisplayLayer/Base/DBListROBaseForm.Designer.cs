namespace ARM_User.DisplayLayer.Guides.Base
{
  partial class DBListROBaseForm
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
        this.gridMain = new DevExpress.XtraGrid.GridControl();
        this.MainBS = new System.Windows.Forms.BindingSource(this.components);
        this.gridMainView = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        this.edCountRecord = new DevExpress.XtraBars.BarStaticItem();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
        this.SuspendLayout();
        // 
        // barDockControlBottom
        // 
        this.barDockControlBottom.Location = new System.Drawing.Point(0, 402);
        this.barDockControlBottom.Size = new System.Drawing.Size(515, 0);
        // 
        // barDockControlLeft
        // 
        this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
        this.barDockControlLeft.Size = new System.Drawing.Size(0, 378);
        // 
        // barDockControlRight
        // 
        this.barDockControlRight.Location = new System.Drawing.Point(515, 24);
        this.barDockControlRight.Size = new System.Drawing.Size(0, 378);
        // 
        // barDockControlTop
        // 
        this.barDockControlTop.Size = new System.Drawing.Size(515, 24);
        // 
        // barManager
        // 
        this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh,
            this.edCountRecord});
        this.barManager.MaxItemId = 5;
        this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
        // 
        // barMenu
        // 
        this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.edCountRecord),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
        // 
        // gridMain
        // 
        this.gridMain.DataSource = this.MainBS;
        this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.gridMain.Location = new System.Drawing.Point(0, 24);
        this.gridMain.MainView = this.gridMainView;
        this.gridMain.Name = "gridMain";
        this.gridMain.Size = new System.Drawing.Size(515, 378);
        this.gridMain.TabIndex = 5;
        this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMainView});
        this.gridMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridMain_MouseMove);
        // 
        // MainBS
        // 
        this.MainBS.CurrentChanged += new System.EventHandler(this.MainBS_CurrentChanged);
        this.MainBS.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.MainBS_ListChanged);
        // 
        // gridMainView
        // 
        this.gridMainView.ColumnPanelRowHeight = 30;
        this.gridMainView.FooterPanelHeight = 20;
        this.gridMainView.GridControl = this.gridMain;
        this.gridMainView.Name = "gridMainView";
        this.gridMainView.OptionsDetail.EnableMasterViewMode = false;
        this.gridMainView.OptionsView.ColumnAutoWidth = false;
        this.gridMainView.OptionsView.ShowFooter = true;
        this.gridMainView.OptionsView.ShowGroupPanel = false;
        this.gridMainView.PaintStyleName = "MixedXP";
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
        // DBListROBaseForm
        // 
        this.ClientSize = new System.Drawing.Size(515, 402);
        this.Controls.Add(this.gridMain);
        this.Name = "DBListROBaseForm";
        this.Text = "DBListROForm";
        this.Load += new System.EventHandler(this.DBListRoForm_Load);
        this.Controls.SetChildIndex(this.barDockControlTop, 0);
        this.Controls.SetChildIndex(this.barDockControlBottom, 0);
        this.Controls.SetChildIndex(this.barDockControlRight, 0);
        this.Controls.SetChildIndex(this.barDockControlLeft, 0);
        this.Controls.SetChildIndex(this.gridMain, 0);
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraGrid.GridControl gridMain;
    protected DevExpress.XtraGrid.Views.Grid.GridView gridMainView;
    protected System.Windows.Forms.BindingSource MainBS;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    protected DevExpress.XtraBars.BarButtonItem btnRefresh;
    private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    public DevExpress.XtraBars.BarStaticItem edCountRecord;
  }
}
