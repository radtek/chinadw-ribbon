namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepYearsQuarterMonthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepYearsQuarterMonthForm));
            this.edDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.edDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.luYears = new DevExpress.XtraEditors.LookUpEdit();
            this.luQuarter = new DevExpress.XtraEditors.LookUpEdit();
            this.rbYears = new System.Windows.Forms.RadioButton();
            this.rbQuarter = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.luMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.YearsBS = new System.Windows.Forms.BindingSource(this.components);
            this.rbPeriod = new System.Windows.Forms.RadioButton();
            this.QuartersBS = new System.Windows.Forms.BindingSource(this.components);
            this.MonthsBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
            this.panelControlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
            this.panelControlButtonsRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luYears.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luQuarter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuartersBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthsBS)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlButtons
            // 
            this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtons.Appearance.Options.UseBackColor = true;
            this.panelControlButtons.Location = new System.Drawing.Point(0, 93);
            this.panelControlButtons.Size = new System.Drawing.Size(315, 38);
            // 
            // panelControlButtonsRight
            // 
            this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
            this.panelControlButtonsRight.Location = new System.Drawing.Point(77, 2);
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
            this.panelControl1.Controls.Add(this.rbPeriod);
            this.panelControl1.Controls.Add(this.luMonth);
            this.panelControl1.Controls.Add(this.rbMonth);
            this.panelControl1.Controls.Add(this.rbQuarter);
            this.panelControl1.Controls.Add(this.rbYears);
            this.panelControl1.Controls.Add(this.luQuarter);
            this.panelControl1.Controls.Add(this.luYears);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.edDateEnd);
            this.panelControl1.Controls.Add(this.edDateBegin);
            this.panelControl1.Size = new System.Drawing.Size(315, 131);
            // 
            // edDateBegin
            // 
            this.edDateBegin.EditValue = null;
            this.edDateBegin.Location = new System.Drawing.Point(116, 137);
            this.edDateBegin.MaximumSize = new System.Drawing.Size(140, 0);
            this.edDateBegin.MinimumSize = new System.Drawing.Size(140, 0);
            this.edDateBegin.Name = "edDateBegin";
            this.edDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edDateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edDateBegin.Size = new System.Drawing.Size(140, 20);
            this.edDateBegin.TabIndex = 20;
            this.edDateBegin.Visible = false;
            this.edDateBegin.EditValueChanged += new System.EventHandler(this.edDateBegin_EditValueChanged);
            // 
            // edDateEnd
            // 
            this.edDateEnd.EditValue = null;
            this.edDateEnd.Location = new System.Drawing.Point(283, 137);
            this.edDateEnd.MaximumSize = new System.Drawing.Size(140, 0);
            this.edDateEnd.MinimumSize = new System.Drawing.Size(140, 0);
            this.edDateEnd.Name = "edDateEnd";
            this.edDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edDateEnd.Size = new System.Drawing.Size(140, 20);
            this.edDateEnd.TabIndex = 22;
            this.edDateEnd.Visible = false;
            this.edDateEnd.EditValueChanged += new System.EventHandler(this.edDateEnd_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "по";
            this.label2.Visible = false;
            // 
            // luYears
            // 
            this.luYears.Location = new System.Drawing.Point(116, 29);
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
            this.luQuarter.Location = new System.Drawing.Point(116, 61);
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
            this.rbYears.AutoSize = true;
            this.rbYears.Checked = true;
            this.rbYears.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbYears.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbYears.Location = new System.Drawing.Point(23, 30);
            this.rbYears.Name = "rbYears";
            this.rbYears.Size = new System.Drawing.Size(49, 18);
            this.rbYears.TabIndex = 418;
            this.rbYears.TabStop = true;
            this.rbYears.Text = "Год";
            this.rbYears.UseVisualStyleBackColor = true;
            this.rbYears.CheckedChanged += new System.EventHandler(this.rbYears_CheckedChanged);
            // 
            // rbQuarter
            // 
            this.rbQuarter.AutoSize = true;
            this.rbQuarter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbQuarter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbQuarter.Location = new System.Drawing.Point(23, 64);
            this.rbQuarter.Name = "rbQuarter";
            this.rbQuarter.Size = new System.Drawing.Size(77, 18);
            this.rbQuarter.TabIndex = 419;
            this.rbQuarter.Text = "Квартал";
            this.rbQuarter.UseVisualStyleBackColor = true;
            this.rbQuarter.Visible = false;
            this.rbQuarter.CheckedChanged += new System.EventHandler(this.rbQuarter_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(23, 99);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(56, 17);
            this.rbMonth.TabIndex = 420;
            this.rbMonth.Text = "Месяц";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.Visible = false;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // luMonth
            // 
            this.luMonth.Enabled = false;
            this.luMonth.Location = new System.Drawing.Point(116, 96);
            this.luMonth.Name = "luMonth";
            this.luMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "NameRu")});
            this.luMonth.Properties.DisplayMember = "NameRu";
            this.luMonth.Properties.NullText = "";
            this.luMonth.Properties.ShowHeader = false;
            this.luMonth.Properties.ValueMember = "Id";
            this.luMonth.Size = new System.Drawing.Size(140, 20);
            this.luMonth.TabIndex = 421;
            this.luMonth.Visible = false;
            this.luMonth.EditValueChanged += new System.EventHandler(this.luMonth_EditValueChanged);
            // 
            // rbPeriod
            // 
            this.rbPeriod.AutoSize = true;
            this.rbPeriod.Location = new System.Drawing.Point(23, 140);
            this.rbPeriod.Name = "rbPeriod";
            this.rbPeriod.Size = new System.Drawing.Size(85, 17);
            this.rbPeriod.TabIndex = 422;
            this.rbPeriod.Text = "За период с";
            this.rbPeriod.UseVisualStyleBackColor = true;
            this.rbPeriod.Visible = false;
            this.rbPeriod.CheckedChanged += new System.EventHandler(this.rbPeriod_CheckedChanged);
            // 
            // ChooseRepYearsQuarterMonthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(315, 131);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseRepYearsQuarterMonthForm";
            this.Text = "Выберите ";
            this.Load += new System.EventHandler(this.ChooseRepYearsQuarterMonthForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
            this.panelControlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
            this.panelControlButtonsRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luYears.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luQuarter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuartersBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthsBS)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.DateEdit edDateBegin;
    private System.Windows.Forms.Label label2;
    protected DevExpress.XtraEditors.DateEdit edDateEnd;
    private DevExpress.XtraEditors.LookUpEdit luYears;
    private DevExpress.XtraEditors.LookUpEdit luQuarter;
    private System.Windows.Forms.RadioButton rbMonth;
    private System.Windows.Forms.RadioButton rbQuarter;
    private System.Windows.Forms.RadioButton rbYears;
    private DevExpress.XtraEditors.LookUpEdit luMonth;
    protected System.Windows.Forms.BindingSource YearsBS;
    private System.Windows.Forms.RadioButton rbPeriod;
    protected System.Windows.Forms.BindingSource QuartersBS;
    protected System.Windows.Forms.BindingSource MonthsBS;
   
  }
}
