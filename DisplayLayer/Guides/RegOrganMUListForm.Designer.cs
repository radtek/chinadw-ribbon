namespace ARM_User.DisplayLayer.Guides
{
    partial class RegOrganMUListForm
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
            this.treeListName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListTypeElement = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddChild = new DevExpress.XtraBars.BarButtonItem();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListName,
            this.treeListParentId,
            this.treeListId,
            this.treeListTypeElement,
            this.treeListColumn1});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.treeList1.Size = new System.Drawing.Size(923, 432);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.DoubleClick += new System.EventHandler(this.gridMain_DoubleClick);
            // 
            // edCountRecord
            // 
            this.edCountRecord.Caption = "0";
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 463);
            this.barDockControlBottom.Size = new System.Drawing.Size(923, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(923, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(923, 31);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnView,
            this.btnAdd,
            this.btnEdit,
            this.BtnDelete,
            this.btnAddChild});
            this.barManager.MaxItemId = 8;
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddChild),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnDelete)});
            // 
            // treeListName
            // 
            this.treeListName.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListName.Caption = "Наименование";
            this.treeListName.FieldName = "Name";
            this.treeListName.Name = "treeListName";
            this.treeListName.Visible = true;
            this.treeListName.VisibleIndex = 0;
            this.treeListName.Width = 786;
            // 
            // treeListParentId
            // 
            this.treeListParentId.AppearanceCell.Options.UseTextOptions = true;
            this.treeListParentId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListParentId.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListParentId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListParentId.Caption = "ID родительской записи";
            this.treeListParentId.FieldName = "ParentId";
            this.treeListParentId.Name = "treeListParentId";
            // 
            // treeListId
            // 
            this.treeListId.AppearanceCell.Options.UseTextOptions = true;
            this.treeListId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListId.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListId.Caption = "ID";
            this.treeListId.FieldName = "Id";
            this.treeListId.Name = "treeListId";
            // 
            // treeListTypeElement
            // 
            this.treeListTypeElement.AppearanceCell.Options.UseTextOptions = true;
            this.treeListTypeElement.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListTypeElement.Caption = "Тип элемента";
            this.treeListTypeElement.FieldName = "TypeElement";
            this.treeListTypeElement.Name = "treeListTypeElement";
            // 
            // btnView
            // 
            this.btnView.Caption = "Просмотреть";
            this.btnView.Glyph = global::ARM_User.Properties.Resources.view;
            this.btnView.Id = 3;
            this.btnView.Name = "btnView";
            this.btnView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnView_ItemClick);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addChildToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.addToolStripMenuItem.Text = "Добавить запись";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click_1);
            // 
            // addChildToolStripMenuItem
            // 
            this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
            this.addChildToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.addChildToolStripMenuItem.Text = "Добавить дочернюю запись";
            this.addChildToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Caption = "Добавить дочернюю";
            this.btnAddChild.Glyph = global::ARM_User.Properties.Resources.element_add;
            this.btnAddChild.Id = 7;
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddChild_ItemClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Признак \"Удален\"";
            this.treeListColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn1.FieldName = "IsDelete";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 1;
            this.treeListColumn1.Width = 119;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // RegOrganMUListForm
            // 
            this.ClientSize = new System.Drawing.Size(923, 463);
            this.Name = "RegOrganMUListForm";
            this.Text = "Справочник \"Регистрирующий орган МЮ\"";
            this.Load += new System.EventHandler(this.GetRegOrganMUForm_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.treeList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListTypeElement;
        private DevExpress.XtraBars.BarButtonItem btnView;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem BtnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnAddChild;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
