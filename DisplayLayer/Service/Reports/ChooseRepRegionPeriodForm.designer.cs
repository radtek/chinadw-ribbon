namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepRegionPeriodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepRegionPeriodForm));
            this.edDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.edDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTypeReport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.luRegion = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbTypeReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlButtons
            // 
            this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtons.Appearance.Options.UseBackColor = true;
            this.panelControlButtons.Location = new System.Drawing.Point(0, 106);
            this.panelControlButtons.Size = new System.Drawing.Size(555, 38);
            // 
            // panelControlButtonsRight
            // 
            this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
            this.panelControlButtonsRight.Location = new System.Drawing.Point(317, 2);
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
            this.panelControl1.Controls.Add(this.luRegion);
            this.panelControl1.Controls.Add(this.cbTypeReport);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.edDateEnd);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.edDateBegin);
            this.panelControl1.Size = new System.Drawing.Size(555, 144);
            // 
            // edDateBegin
            // 
            this.edDateBegin.EditValue = null;
            this.edDateBegin.Location = new System.Drawing.Point(127, 14);
            this.edDateBegin.MaximumSize = new System.Drawing.Size(140, 0);
            this.edDateBegin.MinimumSize = new System.Drawing.Size(140, 0);
            this.edDateBegin.Name = "edDateBegin";
            this.edDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edDateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edDateBegin.Size = new System.Drawing.Size(140, 20);
            this.edDateBegin.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Дата с";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edDateEnd
            // 
            this.edDateEnd.EditValue = null;
            this.edDateEnd.Location = new System.Drawing.Point(332, 14);
            this.edDateEnd.MaximumSize = new System.Drawing.Size(140, 0);
            this.edDateEnd.MinimumSize = new System.Drawing.Size(140, 0);
            this.edDateEnd.Name = "edDateEnd";
            this.edDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edDateEnd.Size = new System.Drawing.Size(140, 20);
            this.edDateEnd.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(270, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "по";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Область";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(11, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 225;
            this.label4.Text = "Выбор выпуска";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTypeReport
            // 
            this.cbTypeReport.EditValue = "Все";
            this.cbTypeReport.Location = new System.Drawing.Point(127, 66);
            this.cbTypeReport.Name = "cbTypeReport";
            this.cbTypeReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTypeReport.Properties.Items.AddRange(new object[] {
            "Все",
            "был отказ ",
            "не был отказа "});
            this.cbTypeReport.Size = new System.Drawing.Size(345, 20);
            this.cbTypeReport.TabIndex = 414;
            this.cbTypeReport.EditValueChanged += new System.EventHandler(this.cbTypeReport_EditValueChanged);
            // 
            // luRegion
            // 
            this.luRegion.Location = new System.Drawing.Point(127, 39);
            this.luRegion.Name = "luRegion";
            this.luRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nameru", "Name1")});
            this.luRegion.Properties.DisplayMember = "Nameru";
            this.luRegion.Properties.NullText = "Все";
            this.luRegion.Properties.ShowHeader = false;
            this.luRegion.Properties.ValueMember = "Id";
            this.luRegion.Size = new System.Drawing.Size(345, 20);
            this.luRegion.TabIndex = 415;
            this.luRegion.EditValueChanged += new System.EventHandler(this.luRegion_EditValueChanged);
            // 
            // ChooseRepRegionPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 144);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseRepRegionPeriodForm";
            this.Text = "Выберите ";
            this.Load += new System.EventHandler(this.ChooseRepRegionPeriodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
            this.panelControlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
            this.panelControlButtonsRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTypeReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.DateEdit edDateBegin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    protected DevExpress.XtraEditors.DateEdit edDateEnd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private DevExpress.XtraEditors.ComboBoxEdit cbTypeReport;
    private DevExpress.XtraEditors.LookUpEdit luRegion;
   
  }
}
