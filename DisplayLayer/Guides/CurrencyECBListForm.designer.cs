namespace ARM_User.DisplayLayer.Guides
{
    partial class CurrencyECBListForm
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
            this.gridCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDesig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNameru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNamekz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDatlast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridIdUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridMain.Size = new System.Drawing.Size(1011, 406);
            this.gridMain.DoubleClick += new System.EventHandler(this.gridMain_DoubleClick);
            // 
            // gridMainView
            // 
            this.gridMainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCode,
            this.gridDesig,
            this.gridNameru,
            this.gridNamekz,
            this.gridDatlast,
            this.gridIdUser,
            this.gridColumn1});
            this.gridMainView.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridMainView.OptionsBehavior.Editable = false;
            this.gridMainView.OptionsDetail.EnableMasterViewMode = false;
            this.gridMainView.OptionsView.ColumnAutoWidth = false;
            this.gridMainView.OptionsView.ShowFooter = true;
            this.gridMainView.OptionsView.ShowGroupPanel = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // edCountRecord
            // 
            this.edCountRecord.Caption = "2";
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Size = new System.Drawing.Size(1011, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 406);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(1011, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 406);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(1011, 31);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnView,
            this.btnAdd,
            this.btnEdit,
            this.BtnDelete,
            this.barButtonItem1});
            this.barManager.MaxItemId = 8;
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            // 
            // gridCode
            // 
            this.gridCode.AppearanceCell.Options.UseTextOptions = true;
            this.gridCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCode.Caption = "Код";
            this.gridCode.FieldName = "Code";
            this.gridCode.Name = "gridCode";
            this.gridCode.Visible = true;
            this.gridCode.VisibleIndex = 0;
            // 
            // gridDesig
            // 
            this.gridDesig.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDesig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDesig.Caption = "Обозначение для НИН";
            this.gridDesig.FieldName = "Desig";
            this.gridDesig.Name = "gridDesig";
            this.gridDesig.Visible = true;
            this.gridDesig.VisibleIndex = 1;
            this.gridDesig.Width = 140;
            // 
            // gridNameru
            // 
            this.gridNameru.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNameru.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNameru.Caption = "Наименование (рус)";
            this.gridNameru.FieldName = "Nameru";
            this.gridNameru.Name = "gridNameru";
            this.gridNameru.Visible = true;
            this.gridNameru.VisibleIndex = 2;
            this.gridNameru.Width = 150;
            // 
            // gridNamekz
            // 
            this.gridNamekz.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNamekz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNamekz.Caption = "Наименование (каз)";
            this.gridNamekz.FieldName = "Namekz";
            this.gridNamekz.Name = "gridNamekz";
            this.gridNamekz.Visible = true;
            this.gridNamekz.VisibleIndex = 3;
            this.gridNamekz.Width = 150;
            // 
            // gridDatlast
            // 
            this.gridDatlast.AppearanceCell.Options.UseTextOptions = true;
            this.gridDatlast.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDatlast.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDatlast.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDatlast.Caption = "Дата изменения";
            this.gridDatlast.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.gridDatlast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridDatlast.FieldName = "EditTime";
            this.gridDatlast.Name = "gridDatlast";
            this.gridDatlast.Visible = true;
            this.gridDatlast.VisibleIndex = 4;
            this.gridDatlast.Width = 140;
            // 
            // gridIdUser
            // 
            this.gridIdUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gridIdUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridIdUser.Caption = "Ответственное лицо";
            this.gridIdUser.FieldName = "EditUser";
            this.gridIdUser.Name = "gridIdUser";
            this.gridIdUser.Visible = true;
            this.gridIdUser.VisibleIndex = 5;
            this.gridIdUser.Width = 150;
            // 
            // BtnView
            // 
            this.BtnView.Caption = "Просмотреть";
            this.BtnView.Glyph = global::ARM_User.Properties.Resources.view;
            this.BtnView.Id = 3;
            this.BtnView.Name = "BtnView";
            this.BtnView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnView_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Добавить";
            this.btnAdd.Glyph = global::ARM_User.Properties.Resources.add2;
            this.btnAdd.Id = 4;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Изменить";
            this.btnEdit.Glyph = global::ARM_User.Properties.Resources.edit;
            this.btnEdit.Id = 5;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Caption = "Удалить";
            this.BtnDelete.Glyph = global::ARM_User.Properties.Resources.delete2;
            this.BtnDelete.Id = 6;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelete_ItemClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Признак \"Удален\"";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "Isdelete";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 120;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Загрузить";
            this.barButtonItem1.Glyph = global::ARM_User.Properties.Resources.table_row_delete_icon1;
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // CurrencyECBListForm
            // 
            this.ClientSize = new System.Drawing.Size(1011, 437);
            this.Name = "CurrencyECBListForm";
            this.Text = "Справочник \"Коды для обозначения валют и фондов\"";
            this.Load += new System.EventHandler(this.CurrencyECBListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridDesig;
        private DevExpress.XtraGrid.Columns.GridColumn gridNameru;
        private DevExpress.XtraGrid.Columns.GridColumn gridNamekz;
        private DevExpress.XtraGrid.Columns.GridColumn gridDatlast;
        private DevExpress.XtraGrid.Columns.GridColumn gridIdUser;
        private DevExpress.XtraBars.BarButtonItem BtnView;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem BtnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
