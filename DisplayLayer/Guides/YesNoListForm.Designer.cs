namespace ARM_User.DisplayLayer.Guides
{
    partial class YesNoListForm
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
            this.gridID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNameRu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNameKz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAdvRepayRu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAdvRepayKz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBuyBackBondRu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBuyBackBondKz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEditUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.gridCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            this.gridMain.Size = new System.Drawing.Size(1318, 366);
            this.gridMain.DoubleClick += new System.EventHandler(this.gridMain_DoubleClick);
            // 
            // gridMainView
            // 
            this.gridMainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridID,
            this.gridCode,
            this.gridNameRu,
            this.gridNameKz,
            this.gridAdvRepayRu,
            this.gridAdvRepayKz,
            this.gridBuyBackBondRu,
            this.gridBuyBackBondKz,
            this.gridEditTime,
            this.gridEditUser,
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
            // barDockControlBottom
            // 
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 31);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(1318, 31);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnView,
            this.btnAdd,
            this.btnEdit,
            this.BtnDelete});
            this.barManager.MaxItemId = 7;
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnDelete)});
            // 
            // gridID
            // 
            this.gridID.Caption = "ID";
            this.gridID.FieldName = "Id";
            this.gridID.Name = "gridID";
            // 
            // gridNameRu
            // 
            this.gridNameRu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNameRu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNameRu.Caption = "Наименование (рус)";
            this.gridNameRu.FieldName = "NameRu";
            this.gridNameRu.Name = "gridNameRu";
            this.gridNameRu.Visible = true;
            this.gridNameRu.VisibleIndex = 1;
            this.gridNameRu.Width = 150;
            // 
            // gridNameKz
            // 
            this.gridNameKz.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNameKz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNameKz.Caption = "Наименование (каз)";
            this.gridNameKz.FieldName = "NameKz";
            this.gridNameKz.Name = "gridNameKz";
            this.gridNameKz.Visible = true;
            this.gridNameKz.VisibleIndex = 2;
            this.gridNameKz.Width = 150;
            // 
            // gridAdvRepayRu
            // 
            this.gridAdvRepayRu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridAdvRepayRu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridAdvRepayRu.Caption = "Досрочное погашение (рус)";
            this.gridAdvRepayRu.FieldName = "AdvRepayRu";
            this.gridAdvRepayRu.Name = "gridAdvRepayRu";
            this.gridAdvRepayRu.Visible = true;
            this.gridAdvRepayRu.VisibleIndex = 3;
            this.gridAdvRepayRu.Width = 150;
            // 
            // gridAdvRepayKz
            // 
            this.gridAdvRepayKz.AppearanceHeader.Options.UseTextOptions = true;
            this.gridAdvRepayKz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridAdvRepayKz.Caption = "Досрочное погашение (каз)";
            this.gridAdvRepayKz.FieldName = "AdvRepayKz";
            this.gridAdvRepayKz.Name = "gridAdvRepayKz";
            this.gridAdvRepayKz.Visible = true;
            this.gridAdvRepayKz.VisibleIndex = 4;
            this.gridAdvRepayKz.Width = 150;
            // 
            // gridBuyBackBondRu
            // 
            this.gridBuyBackBondRu.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBuyBackBondRu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBuyBackBondRu.Caption = "Выкуп облигаций (рус)";
            this.gridBuyBackBondRu.FieldName = "BuyBackBondRu";
            this.gridBuyBackBondRu.Name = "gridBuyBackBondRu";
            this.gridBuyBackBondRu.Visible = true;
            this.gridBuyBackBondRu.VisibleIndex = 5;
            this.gridBuyBackBondRu.Width = 130;
            // 
            // gridBuyBackBondKz
            // 
            this.gridBuyBackBondKz.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBuyBackBondKz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBuyBackBondKz.Caption = "Выкуп облигаций (каз)";
            this.gridBuyBackBondKz.FieldName = "BuyBackBondKz";
            this.gridBuyBackBondKz.Name = "gridBuyBackBondKz";
            this.gridBuyBackBondKz.Visible = true;
            this.gridBuyBackBondKz.VisibleIndex = 6;
            this.gridBuyBackBondKz.Width = 130;
            // 
            // gridEditTime
            // 
            this.gridEditTime.AppearanceCell.Options.UseTextOptions = true;
            this.gridEditTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEditTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridEditTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEditTime.Caption = "Дата изменения";
            this.gridEditTime.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.gridEditTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridEditTime.FieldName = "EditTime";
            this.gridEditTime.Name = "gridEditTime";
            this.gridEditTime.Visible = true;
            this.gridEditTime.VisibleIndex = 7;
            this.gridEditTime.Width = 100;
            // 
            // gridEditUser
            // 
            this.gridEditUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gridEditUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEditUser.Caption = "Ответственное лицо";
            this.gridEditUser.FieldName = "EditUser";
            this.gridEditUser.Name = "gridEditUser";
            this.gridEditUser.Visible = true;
            this.gridEditUser.VisibleIndex = 8;
            this.gridEditUser.Width = 150;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Признак \"Удален\"";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "IsDelete";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // YesNoListForm
            // 
            this.ClientSize = new System.Drawing.Size(1318, 397);
            this.Name = "YesNoListForm";
            this.Text = "Справочник  \"ДаНет\"";
            this.Load += new System.EventHandler(this.YesNoListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridID;
        private DevExpress.XtraGrid.Columns.GridColumn gridNameRu;
        private DevExpress.XtraGrid.Columns.GridColumn gridNameKz;
        private DevExpress.XtraGrid.Columns.GridColumn gridAdvRepayRu;
        private DevExpress.XtraGrid.Columns.GridColumn gridAdvRepayKz;
        private DevExpress.XtraGrid.Columns.GridColumn gridBuyBackBondRu;
        private DevExpress.XtraGrid.Columns.GridColumn gridBuyBackBondKz;
        private DevExpress.XtraGrid.Columns.GridColumn gridEditTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridEditUser;
        private DevExpress.XtraBars.BarButtonItem BtnView;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem BtnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
