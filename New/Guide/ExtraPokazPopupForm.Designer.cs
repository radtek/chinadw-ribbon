namespace ARM_User.New.Guide
{
    partial class ExtraPokazPopupForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraPokazPopupForm));
            this.dsMain = new System.Data.DataSet();
            this.dataTablePopup = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.колNAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.колCODE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.колLEVEL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePopup)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(216, 6);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(306, 6);
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(0, 309);
            this.panelControl2.Size = new System.Drawing.Size(432, 40);
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(432, 349);
            // 
            // treeMain
            // 
            this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.колNAME,
            this.колCODE,
            this.колLEVEL});
            this.treeMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeMain.DataMember = "TablePopup";
            this.treeMain.KeyFieldName = "";
            this.treeMain.OptionsBehavior.Editable = false;
            this.treeMain.OptionsFind.AlwaysVisible = true;
            this.treeMain.OptionsFind.FindDelay = 100;
            this.treeMain.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;
            this.treeMain.OptionsFind.ShowFindButton = false;
            this.treeMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeMain.ParentFieldName = "";
            this.treeMain.Size = new System.Drawing.Size(432, 309);
            this.treeMain.TreeLevelWidth = 12;
            this.treeMain.GetNodeDisplayValue += new DevExpress.XtraTreeList.GetNodeDisplayValueEventHandler(this.treeMain_GetNodeDisplayValue);
            this.treeMain.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeMain_AfterFocusNode);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSetExtraPokazPopup";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTablePopup});
            // 
            // dataTablePopup
            // 
            this.dataTablePopup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTablePopup.TableName = "TablePopup";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "POKAZ_ID";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "NAME";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "CODE";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "LEVEL";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "PARENT_ID";
            this.dataColumn5.DataType = typeof(int);
            // 
            // колNAME
            // 
            this.колNAME.Caption = "Наименование";
            this.колNAME.FieldName = "NAME";
            this.колNAME.Name = "колNAME";
            this.колNAME.Visible = true;
            this.колNAME.VisibleIndex = 0;
            this.колNAME.Width = 274;
            // 
            // колCODE
            // 
            this.колCODE.Caption = "Код";
            this.колCODE.FieldName = "CODE";
            this.колCODE.Name = "колCODE";
            this.колCODE.Visible = true;
            this.колCODE.VisibleIndex = 1;
            this.колCODE.Width = 220;
            // 
            // колLEVEL
            // 
            this.колLEVEL.FieldName = "LEVEL_NO";
            this.колLEVEL.Name = "колLEVEL";
            this.колLEVEL.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.колLEVEL.Width = 111;
            // 
            // ExtraPokazPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(432, 349);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtraPokazPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Абстракный справочник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtraPokazPopupForm_FormClosing);
            this.Load += new System.EventHandler(this.ExtraPokazPopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablePopup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dsMain;
        private System.Data.DataTable dataTablePopup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn колNAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn колCODE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn колLEVEL;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
    }
}
