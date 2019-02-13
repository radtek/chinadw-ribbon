namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepYearQuarterForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepYearQuarterForm));
        this.luYears = new DevExpress.XtraEditors.LookUpEdit();
        this.luQuarter = new DevExpress.XtraEditors.LookUpEdit();
        this.rbYears = new System.Windows.Forms.RadioButton();
        this.rbQuarter = new System.Windows.Forms.RadioButton();
        this.YearsBS = new System.Windows.Forms.BindingSource(this.components);
        this.QuartersBS = new System.Windows.Forms.BindingSource(this.components);
        this.MonthsBS = new System.Windows.Forms.BindingSource(this.components);
        this.cbIsReported = new DevExpress.XtraEditors.ComboBoxEdit();
        this.label1 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
        this.panelControlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
        this.panelControlButtonsRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.luYears.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luQuarter.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.YearsBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.QuartersBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MonthsBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbIsReported.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControlButtons
        // 
        this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtons.Appearance.Options.UseBackColor = true;
        this.panelControlButtons.Location = new System.Drawing.Point(0, 141);
        this.panelControlButtons.Size = new System.Drawing.Size(422, 38);
        // 
        // panelControlButtonsRight
        // 
        this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
        this.panelControlButtonsRight.Location = new System.Drawing.Point(184, 2);
        this.panelControlButtonsRight.Size = new System.Drawing.Size(236, 34);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(129, 5);
        this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(23, 5);
        this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        this.btnOk.Text = "ОK";
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControl1.Appearance.Options.UseBackColor = true;
        this.panelControl1.Controls.Add(this.label1);
        this.panelControl1.Controls.Add(this.cbIsReported);
        this.panelControl1.Controls.Add(this.rbQuarter);
        this.panelControl1.Controls.Add(this.rbYears);
        this.panelControl1.Controls.Add(this.luQuarter);
        this.panelControl1.Controls.Add(this.luYears);
        this.panelControl1.Size = new System.Drawing.Size(422, 179);
        // 
        // luYears
        // 
        this.luYears.Location = new System.Drawing.Point(248, 29);
        this.luYears.Name = "luYears";
        this.luYears.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luYears.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "Name1")});
        this.luYears.Properties.DisplayMember = "NameRu";
        this.luYears.Properties.NullText = "";
        this.luYears.Properties.ShowHeader = false;
        this.luYears.Properties.ValueMember = "Id";
        this.luYears.Size = new System.Drawing.Size(140, 20);
        this.luYears.TabIndex = 415;
        this.luYears.EditValueChanged += new System.EventHandler(this.luYears_EditValueChanged);
        // 
        // luQuarter
        // 
        this.luQuarter.Enabled = false;
        this.luQuarter.Location = new System.Drawing.Point(248, 63);
        this.luQuarter.Name = "luQuarter";
        this.luQuarter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luQuarter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "NameRu")});
        this.luQuarter.Properties.DisplayMember = "NameRu";
        this.luQuarter.Properties.NullText = "";
        this.luQuarter.Properties.ShowHeader = false;
        this.luQuarter.Properties.ValueMember = "Id";
        this.luQuarter.Size = new System.Drawing.Size(140, 20);
        this.luQuarter.TabIndex = 417;
        this.luQuarter.Visible = false;
        this.luQuarter.EditValueChanged += new System.EventHandler(this.luQuarter_EditValueChanged);
        // 
        // rbYears
        // 
        this.rbYears.Checked = true;
        this.rbYears.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.rbYears.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.rbYears.Location = new System.Drawing.Point(148, 30);
        this.rbYears.Name = "rbYears";
        this.rbYears.Size = new System.Drawing.Size(68, 17);
        this.rbYears.TabIndex = 418;
        this.rbYears.TabStop = true;
        this.rbYears.Text = "Год";
        this.rbYears.UseVisualStyleBackColor = true;
        this.rbYears.CheckedChanged += new System.EventHandler(this.rbYears_CheckedChanged);
        // 
        // rbQuarter
        // 
        this.rbQuarter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.rbQuarter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.rbQuarter.Location = new System.Drawing.Point(23, 64);
        this.rbQuarter.Name = "rbQuarter";
        this.rbQuarter.Size = new System.Drawing.Size(68, 17);
        this.rbQuarter.TabIndex = 419;
        this.rbQuarter.Text = "Квартал";
        this.rbQuarter.UseVisualStyleBackColor = true;
        this.rbQuarter.Visible = false;
        this.rbQuarter.CheckedChanged += new System.EventHandler(this.rbQuarter_CheckedChanged);
        // 
        // cbIsReported
        // 
        this.cbIsReported.EditValue = "Все";
        this.cbIsReported.Location = new System.Drawing.Point(248, 96);
        this.cbIsReported.Name = "cbIsReported";
        this.cbIsReported.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
        this.cbIsReported.Properties.Appearance.Options.UseFont = true;
        this.cbIsReported.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbIsReported.Properties.Items.AddRange(new object[] {
            "Все",
            "отчитавшихся",
            "не отчитавшихся"});
        this.cbIsReported.Size = new System.Drawing.Size(140, 20);
        this.cbIsReported.TabIndex = 421;
        this.cbIsReported.EditValueChanged += new System.EventHandler(this.cbIsReported_EditValueChanged);
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label1.Location = new System.Drawing.Point(5, 99);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(211, 13);
        this.label1.TabIndex = 422;
        this.label1.Text = "Выбор информации (факт.)";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // ChooseRepYearQuarterForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(422, 179);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ChooseRepYearQuarterForm";
        this.Text = "Выберите ";
        this.Load += new System.EventHandler(this.ChooseRepYearQuarterForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
        this.panelControlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
        this.panelControlButtonsRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.luYears.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luQuarter.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.YearsBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.QuartersBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MonthsBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbIsReported.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.LookUpEdit luYears;
    private DevExpress.XtraEditors.LookUpEdit luQuarter;
    private System.Windows.Forms.RadioButton rbQuarter;
    private System.Windows.Forms.RadioButton rbYears;
    protected System.Windows.Forms.BindingSource YearsBS;
    protected System.Windows.Forms.BindingSource QuartersBS;
    protected System.Windows.Forms.BindingSource MonthsBS;
    private DevExpress.XtraEditors.ComboBoxEdit cbIsReported;
    private System.Windows.Forms.Label label1;
   
  }
}
