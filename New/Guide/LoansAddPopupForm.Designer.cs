namespace ARM_User.New.Guide
{
    partial class LoansAddPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoansAddPopupForm));
            this.dsMain = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.colabs_constant_dimension_id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colname = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colcode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colabs_constant_dimension_id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(402, 6);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(502, 6);
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(0, 251);
            this.panelControl2.Size = new System.Drawing.Size(598, 40);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Size = new System.Drawing.Size(598, 291);
            this.panelControl1.Controls.SetChildIndex(this.panelControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.treeMain, 0);
            this.panelControl1.Controls.SetChildIndex(this.gridControl1, 0);
            // 
            // treeMain
            // 
            this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colabs_constant_dimension_id,
            this.colname,
            this.colcode});
            this.treeMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeMain.OptionsBehavior.Editable = false;
            this.treeMain.OptionsFind.AlwaysVisible = true;
            this.treeMain.OptionsFind.FindDelay = 100;
            this.treeMain.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            this.treeMain.OptionsFind.ShowFindButton = false;
            this.treeMain.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.False;
            this.treeMain.Size = new System.Drawing.Size(598, 251);
            this.treeMain.TreeViewColumn = this.colabs_constant_dimension_id;
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.dataTable1.TableName = "tablePopupList";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "abs_constant_dimension_id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "name";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "code";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "report_date";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "note";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "t_order";
            // 
            // colabs_constant_dimension_id
            // 
            this.colabs_constant_dimension_id.Caption = "ID";
            this.colabs_constant_dimension_id.FieldName = "abs_constant_dimension_id";
            this.colabs_constant_dimension_id.Name = "colabs_constant_dimension_id";
            this.colabs_constant_dimension_id.Visible = true;
            this.colabs_constant_dimension_id.VisibleIndex = 0;
            this.colabs_constant_dimension_id.Width = 142;
            // 
            // colname
            // 
            this.colname.Caption = "Найменование";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 264;
            // 
            // colcode
            // 
            this.colcode.Caption = "Код";
            this.colcode.FieldName = "code";
            this.colcode.Name = "colcode";
            this.colcode.Visible = true;
            this.colcode.VisibleIndex = 2;
            this.colcode.Width = 39;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "tablePopupList";
            this.gridControl1.DataSource = this.dsMain;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(598, 251);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colabs_constant_dimension_id1,
            this.colname1,
            this.colcode1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colabs_constant_dimension_id1
            // 
            this.colabs_constant_dimension_id1.Caption = "ID";
            this.colabs_constant_dimension_id1.FieldName = "abs_constant_dimension_id";
            this.colabs_constant_dimension_id1.Name = "colabs_constant_dimension_id1";
            this.colabs_constant_dimension_id1.Visible = true;
            this.colabs_constant_dimension_id1.VisibleIndex = 0;
            this.colabs_constant_dimension_id1.Width = 40;
            // 
            // colname1
            // 
            this.colname1.Caption = "Найменование";
            this.colname1.FieldName = "name";
            this.colname1.Name = "colname1";
            this.colname1.Visible = true;
            this.colname1.VisibleIndex = 1;
            this.colname1.Width = 257;
            // 
            // colcode1
            // 
            this.colcode1.Caption = "Код";
            this.colcode1.FieldName = "code";
            this.colcode1.Name = "colcode1";
            this.colcode1.Visible = true;
            this.colcode1.VisibleIndex = 2;
            this.colcode1.Width = 254;
            // 
            // LoansAddPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(598, 291);
            this.Name = "LoansAddPopupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoansAddPopupForm_FormClosing);
            this.Load += new System.EventHandler(this.LoansAddPopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dsMain;
        private System.Data.DataTable dataTable1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colabs_constant_dimension_id;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colname;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colcode;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colabs_constant_dimension_id1;
        private DevExpress.XtraGrid.Columns.GridColumn colname1;
        private DevExpress.XtraGrid.Columns.GridColumn colcode1;
    }
}
