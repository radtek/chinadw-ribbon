namespace ARM_User.DisplayLayer.Service
{
  partial class MultiPageListRoBaseForm
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
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tp = new DevExpress.XtraTab.XtraTabPage();
            this.pcMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            this.pcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
            this.barDockControlBottom.Size = new System.Drawing.Size(782, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 435);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(782, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 435);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(782, 24);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh});
            this.barManager.MaxItemId = 2;
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Обновить";
            this.btnRefresh.Glyph = global::ARM_User.Properties.Resources.refresh;
            this.btnRefresh.Id = 1;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(2, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tp;
            this.tcMain.Size = new System.Drawing.Size(778, 431);
            this.tcMain.TabIndex = 4;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp});
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            // 
            // tp
            // 
            this.tp.Name = "tp";
            this.tp.Size = new System.Drawing.Size(776, 416);
            // 
            // pcMain
            // 
            this.pcMain.Controls.Add(this.tcMain);
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 24);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(782, 435);
            this.pcMain.TabIndex = 5;
            // 
            // MultiPageListRoBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(782, 459);
            this.Controls.Add(this.pcMain);
            this.Name = "MultiPageListRoBaseForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.pcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            this.pcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraTab.XtraTabControl tcMain;
        protected DevExpress.XtraTab.XtraTabPage tp;
        protected DevExpress.XtraEditors.PanelControl pcMain;

    }
}
