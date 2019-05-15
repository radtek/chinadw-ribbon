namespace ARM_User.New.Guide
{
    partial class CreditsPledgesTypePopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsPledgesTypePopupForm));
            this.dsMain = new System.Data.DataSet();
            this.tsPledgesType = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.colname = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldim_name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coldim_part = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colcode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsPledgesType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(0, 10);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(134, 10);
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(0, 371);
            this.panelControl2.Size = new System.Drawing.Size(1072, 58);
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1072, 429);
            // 
            // treeMain
            // 
            this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colname,
            this.coldim_name,
            this.coldim_part,
            this.colcode,
            this.colLevel});
            this.treeMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeMain.DataMember = "tsPledgesType";
            this.treeMain.FixedLineWidth = 3;
            this.treeMain.MinWidth = 30;
            this.treeMain.OptionsBehavior.Editable = false;
            this.treeMain.OptionsFind.AlwaysVisible = true;
            this.treeMain.OptionsFind.FindDelay = 100;
            this.treeMain.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            this.treeMain.OptionsFind.ShowFindButton = false;
            this.treeMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeMain.Size = new System.Drawing.Size(1072, 371);
            this.treeMain.TreeLevelWidth = 27;
            this.treeMain.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeMain_AfterFocusNode);
            this.treeMain.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.treeMain_CustomDrawNodeImages);
            this.treeMain.DoubleClick += new System.EventHandler(this.treeMain_DoubleClick);
            this.treeMain.Resize += new System.EventHandler(this.treeMain_Resize);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.tsPledgesType});
            // 
            // tsPledgesType
            // 
            this.tsPledgesType.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11});
            this.tsPledgesType.TableName = "tsPledgesType";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "abs_dimension_id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "pokaz_id";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "parent_id";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Наименование";
            this.dataColumn4.ColumnName = "name";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "Код";
            this.dataColumn5.ColumnName = "code";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "report_date";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "Справочник";
            this.dataColumn7.ColumnName = "dim_name";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "Раздел справочника";
            this.dataColumn8.ColumnName = "dim_part";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "note";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "level_no";
            this.dataColumn10.DataType = typeof(int);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "rmn";
            // 
            // colname
            // 
            this.colname.Caption = "Наименование";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 289;
            // 
            // coldim_name
            // 
            this.coldim_name.Caption = "Раздел";
            this.coldim_name.FieldName = "dim_name";
            this.coldim_name.Name = "coldim_name";
            this.coldim_name.Visible = true;
            this.coldim_name.VisibleIndex = 1;
            this.coldim_name.Width = 233;
            // 
            // coldim_part
            // 
            this.coldim_part.Caption = "Справочник";
            this.coldim_part.FieldName = "dim_part";
            this.coldim_part.Name = "coldim_part";
            this.coldim_part.Visible = true;
            this.coldim_part.VisibleIndex = 2;
            this.coldim_part.Width = 272;
            // 
            // colcode
            // 
            this.colcode.FieldName = "code";
            this.colcode.Name = "colcode";
            this.colcode.Visible = true;
            this.colcode.VisibleIndex = 3;
            // 
            // colLevel
            // 
            this.colLevel.Caption = "treeListColumn1";
            this.colLevel.FieldName = "level_no";
            this.colLevel.Name = "colLevel";
            // 
            // PledgesTypePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.ClientSize = new System.Drawing.Size(1072, 429);
            this.Name = "PledgesTypePopupForm";
            this.Load += new System.EventHandler(this.PledgesTypePopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsPledgesType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dsMain;
        private System.Data.DataTable tsPledgesType;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colname;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldim_name;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coldim_part;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colcode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLevel;
    }
}
