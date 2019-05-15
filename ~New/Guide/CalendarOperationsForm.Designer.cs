namespace ARM_User.New.Guide
{
    partial class CalendarOperationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarOperationsForm));
            DevExpress.Utils.SimpleContextButton simpleContextButton4 = new DevExpress.Utils.SimpleContextButton();
            this.gcCalendar = new DevExpress.XtraGrid.GridControl();
            this.mainDS = new System.Data.DataSet();
            this.CalendarOp = new System.Data.DataTable();
            this.report_date_id = new System.Data.DataColumn();
            this.date_value = new System.Data.DataColumn();
            this.month = new System.Data.DataColumn();
            this.day_of_week = new System.Data.DataColumn();
            this.status = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.gvCalendar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDATE_VALUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAY_OF_WEEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMONTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREPORT_DATE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCALENDAR_STATUS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOLIDAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.CountBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 482);
            this.barDockControlBottom.Size = new System.Drawing.Size(664, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 451);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(664, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 451);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(664, 31);
            // 
            // barManager
            // 
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem11,
            this.barButtonItem1,
            this.barButtonItem2,
            this.CountBar});
            this.barManager.MaxItemId = 10;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemComboBox2,
            this.repositoryItemTextEdit1});
            // 
            // barMenu
            // 
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.CountBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            // 
            // iEnableAutoSize
            // 
            this.iEnableAutoSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iEnableAutoSize.ImageOptions.Image")));
            this.iEnableAutoSize.ImageOptions.ImageIndex = 0;
            // 
            // gcCalendar
            // 
            this.gcCalendar.DataMember = "CalendarOp";
            this.gcCalendar.DataSource = this.mainDS;
            this.gcCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCalendar.Location = new System.Drawing.Point(0, 31);
            this.gcCalendar.MainView = this.gvCalendar;
            this.gcCalendar.MenuManager = this.barManager;
            this.gcCalendar.Name = "gcCalendar";
            this.gcCalendar.Size = new System.Drawing.Size(664, 451);
            this.gcCalendar.TabIndex = 4;
            this.gcCalendar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCalendar});
            this.gcCalendar.Click += new System.EventHandler(this.gcCalendar_Click);
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "NewDataSet";
            this.mainDS.Tables.AddRange(new System.Data.DataTable[] {
            this.CalendarOp});
            // 
            // CalendarOp
            // 
            this.CalendarOp.Columns.AddRange(new System.Data.DataColumn[] {
            this.report_date_id,
            this.date_value,
            this.month,
            this.day_of_week,
            this.status,
            this.dataColumn1,
            this.dataColumn2});
            this.CalendarOp.TableName = "CalendarOp";
            // 
            // report_date_id
            // 
            this.report_date_id.Caption = "report_date_id";
            this.report_date_id.ColumnName = "REPORT_DATE_ID";
            this.report_date_id.DataType = typeof(long);
            // 
            // date_value
            // 
            this.date_value.Caption = "date_value";
            this.date_value.ColumnName = "DATE_VALUE";
            this.date_value.DataType = typeof(System.DateTime);
            // 
            // month
            // 
            this.month.Caption = "month";
            this.month.ColumnName = "MONTH";
            // 
            // day_of_week
            // 
            this.day_of_week.Caption = "day_of_week";
            this.day_of_week.ColumnName = "DAY_OF_WEEK";
            // 
            // status
            // 
            this.status.Caption = "status";
            this.status.ColumnName = "STATUS";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "CALENDAR_STATUS_ID";
            this.dataColumn1.DataType = typeof(long);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "HOLIDAY";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // gvCalendar
            // 
            this.gvCalendar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDATE_VALUE,
            this.colDAY_OF_WEEK,
            this.colMONTH,
            this.colREPORT_DATE_ID,
            this.colSTATUS,
            this.colCALENDAR_STATUS_ID,
            this.colHOLIDAY});
            this.gvCalendar.GridControl = this.gcCalendar;
            this.gvCalendar.Name = "gvCalendar";
            this.gvCalendar.OptionsBehavior.Editable = false;
            this.gvCalendar.OptionsDetail.EnableMasterViewMode = false;
            this.gvCalendar.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gvCalendar.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvCalendar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvCalendar.OptionsFind.FindDelay = 100;
            this.gvCalendar.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCalendar.OptionsFind.SearchInPreview = true;
            this.gvCalendar.OptionsFind.ShowFindButton = false;
            this.gvCalendar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCalendar.OptionsView.ShowGroupPanel = false;
            this.gvCalendar.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvCalendar_RowCellStyle);
            this.gvCalendar.DoubleClick += new System.EventHandler(this.gvCalendar_DoubleClick);
            // 
            // colDATE_VALUE
            // 
            this.colDATE_VALUE.Caption = "Дата";
            this.colDATE_VALUE.FieldName = "DATE_VALUE";
            this.colDATE_VALUE.Name = "colDATE_VALUE";
            this.colDATE_VALUE.Visible = true;
            this.colDATE_VALUE.VisibleIndex = 0;
            this.colDATE_VALUE.Width = 114;
            // 
            // colDAY_OF_WEEK
            // 
            this.colDAY_OF_WEEK.Caption = "День недели";
            this.colDAY_OF_WEEK.FieldName = "DAY_OF_WEEK";
            this.colDAY_OF_WEEK.Name = "colDAY_OF_WEEK";
            this.colDAY_OF_WEEK.Visible = true;
            this.colDAY_OF_WEEK.VisibleIndex = 1;
            // 
            // colMONTH
            // 
            this.colMONTH.Caption = "Месяц";
            this.colMONTH.FieldName = "MONTH";
            this.colMONTH.Name = "colMONTH";
            this.colMONTH.Visible = true;
            this.colMONTH.VisibleIndex = 2;
            // 
            // colREPORT_DATE_ID
            // 
            this.colREPORT_DATE_ID.FieldName = "REPORT_DATE_ID";
            this.colREPORT_DATE_ID.Name = "colREPORT_DATE_ID";
            // 
            // colSTATUS
            // 
            this.colSTATUS.Caption = "Вид дня";
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            this.colSTATUS.Visible = true;
            this.colSTATUS.VisibleIndex = 3;
            // 
            // colCALENDAR_STATUS_ID
            // 
            this.colCALENDAR_STATUS_ID.FieldName = "CALENDAR_STATUS_ID";
            this.colCALENDAR_STATUS_ID.Name = "colCALENDAR_STATUS_ID";
            // 
            // colHOLIDAY
            // 
            this.colHOLIDAY.FieldName = "HOLIDAY";
            this.colHOLIDAY.Name = "colHOLIDAY";
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "Обновить";
            this.barButtonItem11.Description = "Обновить";
            this.barButtonItem11.Hint = "Обновить";
            this.barButtonItem11.Id = 1;
            this.barButtonItem11.ImageOptions.Image = global::ARM_User.Properties.Resources.refresh;
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Редактировать";
            this.barButtonItem1.Description = "Редактировать";
            this.barButtonItem1.Hint = "Редактировать";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.Image = global::ARM_User.Properties.Resources.edit;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Создать\\Обновить";
            this.barButtonItem2.Hint = "Создать\\Обновить";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.Image = global::ARM_User.Properties.Resources.history_add;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "refresh";
            this.barButtonItem3.Hint = "Обновить";
            this.barButtonItem3.Id = 1;
            this.barButtonItem3.ImageOptions.Image = global::ARM_User.Properties.Resources.refresh;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            simpleContextButton4.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            simpleContextButton4.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            simpleContextButton4.Caption = "2019";
            simpleContextButton4.Id = new System.Guid("5066401d-9230-4f3e-aae2-1144ffbb6fbb");
            simpleContextButton4.Name = "simpleContextButton1";
            this.repositoryItemComboBox1.ContextButtons.Add(simpleContextButton4);
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Mask.EditMask = "yyyy";
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // CountBar
            // 
            this.CountBar.Caption = "Количество записей";
            this.CountBar.Edit = this.repositoryItemTextEdit1;
            this.CountBar.EditWidth = 54;
            this.CountBar.Enabled = false;
            this.CountBar.Hint = "Количество записей";
            this.CountBar.Id = 9;
            this.CountBar.Name = "CountBar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // CalendarOperationsForm
            // 
            this.ClientSize = new System.Drawing.Size(664, 482);
            this.Controls.Add(this.gcCalendar);
            this.Name = "CalendarOperationsForm";
            this.Text = "Календар операционных дней";
            this.Load += new System.EventHandler(this.CalendarOperations_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.gcCalendar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCalendar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCalendar;
        private System.Data.DataSet mainDS;
        private System.Data.DataTable CalendarOp;
        private System.Data.DataColumn report_date_id;
        private System.Data.DataColumn date_value;
        private System.Data.DataColumn month;
        private System.Data.DataColumn day_of_week;
        private System.Data.DataColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn colDATE_VALUE;
        private DevExpress.XtraGrid.Columns.GridColumn colDAY_OF_WEEK;
        private DevExpress.XtraGrid.Columns.GridColumn colMONTH;
        private DevExpress.XtraGrid.Columns.GridColumn colREPORT_DATE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCALENDAR_STATUS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colHOLIDAY;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        protected internal DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarEditItem CountBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
