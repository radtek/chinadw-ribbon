namespace ARM_User.DisplayLayer.Service
{
  partial class MakeReportsForm
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
        this.lcForm = new DevExpress.XtraLayout.LayoutControl();
        this.gcForms = new DevExpress.XtraGrid.GridControl();
        this.formsBS = new System.Windows.Forms.BindingSource(this.components);
        this.gvForms = new DevExpress.XtraGrid.Views.Grid.GridView();
        this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
        this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
        this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
        this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
        this.btnMake = new DevExpress.XtraBars.BarButtonItem();
        this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
        this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
        this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
        this.label1 = new System.Windows.Forms.Label();
        this.cbTypeReport = new DevExpress.XtraEditors.ComboBoxEdit();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lcForm)).BeginInit();
        this.lcForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gcForms)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.formsBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gvForms)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeReport.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // barDockControlBottom
        // 
        this.barDockControlBottom.Location = new System.Drawing.Point(0, 401);
        this.barDockControlBottom.Size = new System.Drawing.Size(1208, 0);
        // 
        // barDockControlLeft
        // 
        this.barDockControlLeft.Size = new System.Drawing.Size(0, 370);
        // 
        // barDockControlRight
        // 
        this.barDockControlRight.Location = new System.Drawing.Point(1208, 31);
        this.barDockControlRight.Size = new System.Drawing.Size(0, 370);
        // 
        // barDockControlTop
        // 
        this.barDockControlTop.Size = new System.Drawing.Size(1208, 31);
        // 
        // barManager
        // 
        this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh,
            this.btnMake});
        this.barManager.MaxItemId = 4;
        // 
        // barMenu
        // 
        this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnMake, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
        // 
        // lcForm
        // 
        this.lcForm.Controls.Add(this.gcForms);
        this.lcForm.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lcForm.Location = new System.Drawing.Point(0, 31);
        this.lcForm.Margin = new System.Windows.Forms.Padding(1);
        this.lcForm.Name = "lcForm";
        this.lcForm.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1008, 344, 250, 350);
        this.lcForm.Root = this.layoutControlGroup1;
        this.lcForm.Size = new System.Drawing.Size(1208, 370);
        this.lcForm.TabIndex = 6;
        this.lcForm.Text = "layoutControl1";
        // 
        // gcForms
        // 
        this.gcForms.DataSource = this.formsBS;
        this.gcForms.Location = new System.Drawing.Point(3, 3);
        this.gcForms.MainView = this.gvForms;
        this.gcForms.Name = "gcForms";
        this.gcForms.Size = new System.Drawing.Size(1202, 364);
        this.gcForms.TabIndex = 4;
        this.gcForms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvForms});
        this.gcForms.DoubleClick += new System.EventHandler(this.gcForms_DoubleClick);
        // 
        // gvForms
        // 
        this.gvForms.Appearance.Empty.BackColor = System.Drawing.Color.WhiteSmoke;
        this.gvForms.Appearance.Empty.Options.UseBackColor = true;
        this.gvForms.Appearance.FocusedRow.BackColor2 = System.Drawing.SystemColors.Highlight;
        this.gvForms.Appearance.HeaderPanel.Options.UseTextOptions = true;
        this.gvForms.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.gvForms.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.gvForms.Appearance.OddRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.gvForms.Appearance.OddRow.Options.UseBackColor = true;
        this.gvForms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumn2});
        this.gvForms.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        this.gvForms.GridControl = this.gcForms;
        this.gvForms.GroupPanelText = "Перенесите сюда колонку по которой нужно сгруппировать";
        this.gvForms.Name = "gvForms";
        this.gvForms.OptionsBehavior.Editable = false;
        this.gvForms.OptionsCustomization.AllowGroup = false;
        this.gvForms.OptionsDetail.EnableMasterViewMode = false;
        this.gvForms.OptionsMenu.EnableColumnMenu = false;
        this.gvForms.OptionsSelection.MultiSelect = true;
        this.gvForms.OptionsView.ShowGroupPanel = false;
        // 
        // gridColumnName
        // 
        this.gridColumnName.Caption = "Наименование";
        this.gridColumnName.FieldName = "Name";
        this.gridColumnName.Name = "gridColumnName";
        this.gridColumnName.Visible = true;
        this.gridColumnName.VisibleIndex = 1;
        this.gridColumnName.Width = 568;
        // 
        // gridColumn2
        // 
        this.gridColumn2.Caption = "ID";
        this.gridColumn2.FieldName = "Id";
        this.gridColumn2.Name = "gridColumn2";
        this.gridColumn2.Visible = true;
        this.gridColumn2.VisibleIndex = 0;
        // 
        // layoutControlGroup1
        // 
        this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
        this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
        this.layoutControlGroup1.GroupBordersVisible = false;
        this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
        this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
        this.layoutControlGroup1.Name = "layoutControlGroup1";
        this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
        this.layoutControlGroup1.Size = new System.Drawing.Size(1208, 370);
        this.layoutControlGroup1.Text = "layoutControlGroup1";
        this.layoutControlGroup1.TextVisible = false;
        // 
        // layoutControlItem1
        // 
        this.layoutControlItem1.Control = this.gcForms;
        this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
        this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
        this.layoutControlItem1.Name = "layoutControlItem1";
        this.layoutControlItem1.Size = new System.Drawing.Size(1206, 368);
        this.layoutControlItem1.Text = "layoutControlItem1";
        this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
        this.layoutControlItem1.TextToControlDistance = 0;
        this.layoutControlItem1.TextVisible = false;
        // 
        // btnRefresh
        // 
        this.btnRefresh.Caption = "Обновить";
        this.btnRefresh.Glyph = global::ARM_User.Properties.Resources.refresh;
        this.btnRefresh.Id = 1;
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
        // 
        // btnMake
        // 
        this.btnMake.Caption = "Сформировать";
        this.btnMake.Glyph = global::ARM_User.Properties.Resources.table_row_delete_icon1;
        this.btnMake.Id = 2;
        this.btnMake.Name = "btnMake";
        this.btnMake.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMake_ItemClick);
        // 
        // gridColumn1
        // 
        this.gridColumn1.Caption = "Номер";
        this.gridColumn1.FieldName = "Num";
        this.gridColumn1.Name = "gridColumn1";
        this.gridColumn1.Visible = true;
        this.gridColumn1.VisibleIndex = 0;
        // 
        // colCODE
        // 
        this.colCODE.Caption = "Код";
        this.colCODE.FieldName = "Code";
        this.colCODE.Name = "colCODE";
        this.colCODE.Visible = true;
        this.colCODE.VisibleIndex = 1;
        this.colCODE.Width = 90;
        // 
        // colNAME
        // 
        this.colNAME.Caption = "Наименование";
        this.colNAME.FieldName = "Name";
        this.colNAME.Name = "colNAME";
        this.colNAME.Visible = true;
        this.colNAME.VisibleIndex = 2;
        this.colNAME.Width = 662;
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label1.Location = new System.Drawing.Point(269, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(300, 14);
        this.label1.TabIndex = 411;
        this.label1.Text = "Выберите вид отчета по группам";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cbTypeReport
        // 
        this.cbTypeReport.EditValue = "Все";
        this.cbTypeReport.Location = new System.Drawing.Point(570, 7);
        this.cbTypeReport.Name = "cbTypeReport";
        this.cbTypeReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbTypeReport.Properties.Items.AddRange(new object[] {
            "Все",
            "Акции",
            "Облигации",
            "КДР",
            "ИЦБ",
            "ГЦБ",
            "ПАИ",
            "Мониторинг"});
        this.cbTypeReport.Size = new System.Drawing.Size(128, 20);
        this.cbTypeReport.TabIndex = 413;
        this.cbTypeReport.SelectedIndexChanged += new System.EventHandler(this.cbTypeReport_SelectedIndexChanged);
        this.cbTypeReport.EditValueChanged += new System.EventHandler(this.luTypeReport_EditValueChanged);
        // 
        // MakeReportsForm
        // 
        this.ClientSize = new System.Drawing.Size(1208, 401);
        this.Controls.Add(this.cbTypeReport);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.lcForm);
        this.Name = "MakeReportsForm";
        this.Text = "Выходные формы";
        this.Load += new System.EventHandler(this.MakeReportsBaseForm_Load);
        this.Controls.SetChildIndex(this.barDockControlTop, 0);
        this.Controls.SetChildIndex(this.barDockControlBottom, 0);
        this.Controls.SetChildIndex(this.barDockControlRight, 0);
        this.Controls.SetChildIndex(this.barDockControlLeft, 0);
        this.Controls.SetChildIndex(this.lcForm, 0);
        this.Controls.SetChildIndex(this.label1, 0);
        this.Controls.SetChildIndex(this.cbTypeReport, 0);
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lcForm)).EndInit();
        this.lcForm.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gcForms)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.formsBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gvForms)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeReport.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraLayout.LayoutControl lcForm;
    protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    private DevExpress.XtraBars.BarButtonItem btnRefresh;
    protected System.Windows.Forms.BindingSource formsBS;
    protected DevExpress.XtraBars.BarButtonItem btnMake;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    private DevExpress.XtraGrid.Columns.GridColumn colCODE;
    private DevExpress.XtraGrid.Columns.GridColumn colNAME;
    protected DevExpress.XtraGrid.GridControl gcForms;
    protected DevExpress.XtraGrid.Views.Grid.GridView gvForms;
    protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.ComboBoxEdit cbTypeReport;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
  }
}
