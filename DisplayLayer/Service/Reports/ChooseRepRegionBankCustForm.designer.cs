namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepRegionBankCustForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepRegionBankCustForm));
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.luRegion = new DevExpress.XtraEditors.LookUpEdit();
        this.label1 = new System.Windows.Forms.Label();
        this.luBankCust = new DevExpress.XtraEditors.LookUpEdit();
        this.luUsr = new DevExpress.XtraEditors.LookUpEdit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
        this.panelControlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
        this.panelControlButtonsRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luBankCust.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsr.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControlButtons
        // 
        this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtons.Appearance.Options.UseBackColor = true;
        this.panelControlButtons.Location = new System.Drawing.Point(0, 132);
        this.panelControlButtons.Size = new System.Drawing.Size(550, 38);
        // 
        // panelControlButtonsRight
        // 
        this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
        this.panelControlButtonsRight.Location = new System.Drawing.Point(312, 2);
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
        this.panelControl1.Controls.Add(this.luUsr);
        this.panelControl1.Controls.Add(this.luBankCust);
        this.panelControl1.Controls.Add(this.label1);
        this.panelControl1.Controls.Add(this.luRegion);
        this.panelControl1.Controls.Add(this.label4);
        this.panelControl1.Controls.Add(this.label3);
        this.panelControl1.Size = new System.Drawing.Size(550, 170);
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label3.Location = new System.Drawing.Point(12, 20);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(140, 13);
        this.label3.TabIndex = 67;
        this.label3.Text = "Область";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label4.Location = new System.Drawing.Point(11, 45);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(140, 13);
        this.label4.TabIndex = 225;
        this.label4.Text = "Исполнитель";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // luRegion
        // 
        this.luRegion.Location = new System.Drawing.Point(153, 16);
        this.luRegion.Name = "luRegion";
        this.luRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nameru", "Name1")});
        this.luRegion.Properties.DisplayMember = "Nameru";
        this.luRegion.Properties.NullText = "Все";
        this.luRegion.Properties.ShowHeader = false;
        this.luRegion.Properties.ValueMember = "Id";
        this.luRegion.Size = new System.Drawing.Size(270, 20);
        this.luRegion.TabIndex = 415;
        this.luRegion.EditValueChanged += new System.EventHandler(this.luRegion_EditValueChanged);
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label1.Location = new System.Drawing.Point(9, 74);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(211, 13);
        this.label1.TabIndex = 416;
        this.label1.Text = "Представитель держателей облигаций ";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // luBankCust
        // 
        this.luBankCust.Location = new System.Drawing.Point(153, 92);
        this.luBankCust.Name = "luBankCust";
        this.luBankCust.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luBankCust.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "Name1")});
        this.luBankCust.Properties.DisplayMember = "NameRu";
        this.luBankCust.Properties.NullText = "Все";
        this.luBankCust.Properties.ShowHeader = false;
        this.luBankCust.Properties.ValueMember = "Id";
        this.luBankCust.Size = new System.Drawing.Size(270, 20);
        this.luBankCust.TabIndex = 417;
        this.luBankCust.EditValueChanged += new System.EventHandler(this.luBankCust_EditValueChanged);
        // 
        // luUsr
        // 
        this.luUsr.Location = new System.Drawing.Point(153, 42);
        this.luUsr.Name = "luUsr";
        this.luUsr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luUsr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SignatureFNF", "Name1")});
        this.luUsr.Properties.DisplayMember = "SignatureFNF";
        this.luUsr.Properties.NullText = "Все";
        this.luUsr.Properties.ShowHeader = false;
        this.luUsr.Properties.ValueMember = "Id";
        this.luUsr.Size = new System.Drawing.Size(270, 20);
        this.luUsr.TabIndex = 418;
        this.luUsr.EditValueChanged += new System.EventHandler(this.luUsr_EditValueChanged);
        // 
        // ChooseRepRegionBankCustForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(550, 170);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ChooseRepRegionBankCustForm";
        this.Text = "Выберите ";
        this.Load += new System.EventHandler(this.ChooseRepRegionBankCustForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
        this.panelControlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
        this.panelControlButtonsRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luBankCust.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsr.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private DevExpress.XtraEditors.LookUpEdit luRegion;
    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.LookUpEdit luUsr;
    private DevExpress.XtraEditors.LookUpEdit luBankCust;
   
  }
}
