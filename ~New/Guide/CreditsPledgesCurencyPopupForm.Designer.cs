namespace ARM_User.New.Guide
{
    partial class CreditsPledgesCurencyPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsPledgesCurencyPopupForm));
            this.dsMain = new System.Data.DataSet();
            this.tsCurrency = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.colcurrency_code = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colcurrency_name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcurrency_code1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcurrency_name1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(26, 10);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(161, 10);
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(0, 346);
            this.panelControl2.Size = new System.Drawing.Size(562, 58);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Size = new System.Drawing.Size(562, 404);
            this.panelControl1.Controls.SetChildIndex(this.panelControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.treeMain, 0);
            this.panelControl1.Controls.SetChildIndex(this.gridControl1, 0);
            // 
            // treeMain
            // 
            this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colcurrency_code,
            this.colcurrency_name});
            this.treeMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeMain.DataMember = "tsCurrency";
            this.treeMain.Dock = System.Windows.Forms.DockStyle.None;
            this.treeMain.FixedLineWidth = 3;
            this.treeMain.Location = new System.Drawing.Point(382, 138);
            this.treeMain.MinWidth = 30;
            this.treeMain.OptionsBehavior.Editable = false;
            this.treeMain.OptionsFind.AlwaysVisible = true;
            this.treeMain.OptionsFind.FindDelay = 100;
            this.treeMain.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            this.treeMain.OptionsFind.ShowFindButton = false;
            this.treeMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeMain.Size = new System.Drawing.Size(167, 183);
            this.treeMain.TreeLevelWidth = 27;
            this.treeMain.Visible = false;
            this.treeMain.Resize += new System.EventHandler(this.treeMain_Resize);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.tsCurrency});
            // 
            // tsCurrency
            // 
            this.tsCurrency.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.tsCurrency.TableName = "tsCurrency";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "p_currency_id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "currency_code";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "currency_name";
            // 
            // colcurrency_code
            // 
            this.colcurrency_code.Caption = "Код";
            this.colcurrency_code.FieldName = "currency_code";
            this.colcurrency_code.Name = "colcurrency_code";
            this.colcurrency_code.Visible = true;
            this.colcurrency_code.VisibleIndex = 0;
            this.colcurrency_code.Width = 47;
            // 
            // colcurrency_name
            // 
            this.colcurrency_name.Caption = "Наименование";
            this.colcurrency_name.FieldName = "currency_name";
            this.colcurrency_name.Name = "colcurrency_name";
            this.colcurrency_name.Visible = true;
            this.colcurrency_name.VisibleIndex = 1;
            this.colcurrency_name.Width = 629;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "tsCurrency";
            this.gridControl1.DataSource = this.dsMain;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(562, 346);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcurrency_code1,
            this.colcurrency_name1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colcurrency_code1
            // 
            this.colcurrency_code1.Caption = "Код";
            this.colcurrency_code1.FieldName = "currency_code";
            this.colcurrency_code1.MinWidth = 25;
            this.colcurrency_code1.Name = "colcurrency_code1";
            this.colcurrency_code1.OptionsColumn.AllowEdit = false;
            this.colcurrency_code1.OptionsColumn.AllowFocus = false;
            this.colcurrency_code1.OptionsColumn.FixedWidth = true;
            this.colcurrency_code1.Visible = true;
            this.colcurrency_code1.VisibleIndex = 0;
            this.colcurrency_code1.Width = 40;
            // 
            // colcurrency_name1
            // 
            this.colcurrency_name1.Caption = "Наименование";
            this.colcurrency_name1.FieldName = "currency_name";
            this.colcurrency_name1.MinWidth = 25;
            this.colcurrency_name1.Name = "colcurrency_name1";
            this.colcurrency_name1.OptionsColumn.AllowEdit = false;
            this.colcurrency_name1.OptionsColumn.AllowFocus = false;
            this.colcurrency_name1.Visible = true;
            this.colcurrency_name1.VisibleIndex = 1;
            this.colcurrency_name1.Width = 505;
            // 
            // PledgesCurencyPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.ClientSize = new System.Drawing.Size(562, 404);
            this.Name = "PledgesCurencyPopupForm";
            this.Load += new System.EventHandler(this.PledgesCurencyPopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dsMain;
        private System.Data.DataTable tsCurrency;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colcurrency_code;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colcurrency_name;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrency_code1;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrency_name1;
    }
}
