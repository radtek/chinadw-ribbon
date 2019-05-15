namespace ARM_User.New.Guide
{
    partial class ExportRepHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportRepHistory));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dsMain = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.load_date = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colload_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colload_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerror_text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colload_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colus_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageIndex = 12;
            this.btnSave.Location = new System.Drawing.Point(697, 5);
            this.btnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 12;
            this.btnCancel.Location = new System.Drawing.Point(805, 5);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 308);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Size = new System.Drawing.Size(914, 38);
            // 
            // barButtonItemBeginEdit
            // 
            this.barButtonItemBeginEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemBeginEdit.ImageOptions.Image")));
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
            // 
            // barButtonItemCancelEdit
            // 
            this.barButtonItemCancelEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemCancelEdit.ImageOptions.Image")));
            // 
            // barButtonItemRefresh
            // 
            this.barButtonItemRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemRefresh.ImageOptions.Image")));
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panelControl1.Size = new System.Drawing.Size(918, 348);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.gridControl1, 0);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "tableHistory";
            this.gridControl1.DataSource = this.dsMain;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(914, 306);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.load_date,
            this.dataColumn6});
            this.dataTable1.TableName = "tableHistory";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "rep_name_id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "load_type";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "load_status";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "error_text";
            // 
            // load_date
            // 
            this.load_date.ColumnName = "load_date";
            this.load_date.DataType = typeof(System.DateTime);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "us_name";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colload_type,
            this.colload_status,
            this.colerror_text,
            this.colload_date,
            this.colus_name});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colload_date, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colload_type
            // 
            this.colload_type.Caption = "Тип операции";
            this.colload_type.FieldName = "load_type";
            this.colload_type.MinWidth = 23;
            this.colload_type.Name = "colload_type";
            this.colload_type.OptionsColumn.AllowEdit = false;
            this.colload_type.Visible = true;
            this.colload_type.VisibleIndex = 2;
            this.colload_type.Width = 113;
            // 
            // colload_status
            // 
            this.colload_status.Caption = "Статус загрузки";
            this.colload_status.FieldName = "load_status";
            this.colload_status.MinWidth = 23;
            this.colload_status.Name = "colload_status";
            this.colload_status.OptionsColumn.AllowEdit = false;
            this.colload_status.Visible = true;
            this.colload_status.VisibleIndex = 3;
            this.colload_status.Width = 113;
            // 
            // colerror_text
            // 
            this.colerror_text.Caption = "Текст ошибки";
            this.colerror_text.FieldName = "error_text";
            this.colerror_text.MinWidth = 23;
            this.colerror_text.Name = "colerror_text";
            this.colerror_text.OptionsColumn.AllowEdit = false;
            this.colerror_text.Visible = true;
            this.colerror_text.VisibleIndex = 4;
            this.colerror_text.Width = 113;
            // 
            // colload_date
            // 
            this.colload_date.Caption = "Дата и время операций";
            this.colload_date.DisplayFormat.FormatString = "f";
            this.colload_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colload_date.FieldName = "load_date";
            this.colload_date.MinWidth = 23;
            this.colload_date.Name = "colload_date";
            this.colload_date.OptionsColumn.AllowEdit = false;
            this.colload_date.Visible = true;
            this.colload_date.VisibleIndex = 0;
            this.colload_date.Width = 280;
            // 
            // colus_name
            // 
            this.colus_name.Caption = "Пользователь";
            this.colus_name.FieldName = "us_name";
            this.colus_name.MinWidth = 23;
            this.colus_name.Name = "colus_name";
            this.colus_name.OptionsColumn.AllowEdit = false;
            this.colus_name.Visible = true;
            this.colus_name.VisibleIndex = 1;
            this.colus_name.Width = 87;
            // 
            // ExportRepHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(918, 348);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "ExportRepHistory";
            this.Load += new System.EventHandler(this.ExportRepHistory_Load);
            this.ResizeBegin += new System.EventHandler(this.ExportRepHistory_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.ExportRepHistory_ResizeEnd);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Data.DataSet dsMain;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn load_date;
        private System.Data.DataColumn dataColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colload_type;
        private DevExpress.XtraGrid.Columns.GridColumn colload_status;
        private DevExpress.XtraGrid.Columns.GridColumn colerror_text;
        private DevExpress.XtraGrid.Columns.GridColumn colload_date;
        private DevExpress.XtraGrid.Columns.GridColumn colus_name;
    }
}
