namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseIsHaveTechForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseIsHaveTechForm));
        this.label1 = new System.Windows.Forms.Label();
        this.cbIsHaveTech = new DevExpress.XtraEditors.ComboBoxEdit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
        this.panelControlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
        this.panelControlButtonsRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.cbIsHaveTech.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControlButtons
        // 
        this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtons.Appearance.Options.UseBackColor = true;
        this.panelControlButtons.Location = new System.Drawing.Point(0, 82);
        this.panelControlButtons.Size = new System.Drawing.Size(251, 38);
        // 
        // panelControlButtonsRight
        // 
        this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
        this.panelControlButtonsRight.Location = new System.Drawing.Point(13, 2);
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
        this.panelControl1.Controls.Add(this.cbIsHaveTech);
        this.panelControl1.Controls.Add(this.label1);
        this.panelControl1.Size = new System.Drawing.Size(251, 120);
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.Location = new System.Drawing.Point(33, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(190, 17);
        this.label1.TabIndex = 21;
        this.label1.Text = "Признак наличия методики ";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cbIsHaveTech
        // 
        this.cbIsHaveTech.EditValue = "Все";
        this.cbIsHaveTech.Location = new System.Drawing.Point(47, 34);
        this.cbIsHaveTech.Name = "cbIsHaveTech";
        this.cbIsHaveTech.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
        this.cbIsHaveTech.Properties.Appearance.Options.UseFont = true;
        this.cbIsHaveTech.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbIsHaveTech.Properties.Items.AddRange(new object[] {
            "Все",
            "Да",
            "Нет"});
        this.cbIsHaveTech.Size = new System.Drawing.Size(192, 20);
        this.cbIsHaveTech.TabIndex = 415;
        this.cbIsHaveTech.EditValueChanged += new System.EventHandler(this.cbIsHaveTech_EditValueChanged);
        // 
        // ChooseIsHaveTechForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(251, 120);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ChooseIsHaveTechForm";
        this.Text = "Выберите";
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
        this.panelControlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
        this.panelControlButtonsRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.cbIsHaveTech.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.ComboBoxEdit cbIsHaveTech;

  }
}
