namespace ARM_User.DisplayLayer.Base
{
    partial class SimpleMEditForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleMEditForm));
        this.btnSave = new DevExpress.XtraEditors.SimpleButton();
        this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
        this.panel1 = new System.Windows.Forms.Panel();
        this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
        this.panelControl1.Appearance.Options.UseBackColor = true;
        this.panelControl1.Controls.Add(this.panelControl2);
        this.panelControl1.Controls.Add(this.panel1);
        this.panelControl1.Size = new System.Drawing.Size(481, 418);
        // 
        // btnSave
        // 
        this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.btnSave.Appearance.Options.UseFont = true;
        this.btnSave.Appearance.Options.UseForeColor = true;
        this.btnSave.Image = global::ARM_User.Properties.Resources.check2;
        this.btnSave.ImageIndex = 12;
        this.btnSave.Location = new System.Drawing.Point(298, 4);
        this.btnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(85, 23);
        this.btnSave.TabIndex = 1;
        this.btnSave.Text = "OK";
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.btnCancel.Appearance.Options.UseFont = true;
        this.btnCancel.Appearance.Options.UseForeColor = true;
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Image = global::ARM_User.Properties.Resources.delete2;
        this.btnCancel.ImageIndex = 12;
        this.btnCancel.Location = new System.Drawing.Point(389, 4);
        this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(85, 23);
        this.btnCancel.TabIndex = 2;
        this.btnCancel.Text = "Отмена";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.btnCancel);
        this.panel1.Controls.Add(this.btnSave);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel1.Location = new System.Drawing.Point(2, 385);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(477, 31);
        this.panel1.TabIndex = 4;
        // 
        // panelControl2
        // 
        this.panelControl2.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelControl2.Appearance.Options.UseBackColor = true;
        this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelControl2.Location = new System.Drawing.Point(2, 2);
        this.panelControl2.Name = "panelControl2";
        this.panelControl2.Size = new System.Drawing.Size(477, 383);
        this.panelControl2.TabIndex = 5;
        // 
        // SimpleMEditForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(481, 418);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "SimpleMEditForm";
        this.Load += new System.EventHandler(this.SimpleMEditForm_Load_1);
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.SimpleButton btnSave;
    protected DevExpress.XtraEditors.SimpleButton btnCancel;
    protected System.Windows.Forms.Panel panel1;
    protected DevExpress.XtraEditors.PanelControl panelControl2;

  }
}
