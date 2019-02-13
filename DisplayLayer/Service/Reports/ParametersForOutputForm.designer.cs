namespace ARM_User.DisplayLayer.Service
{
  partial class ParametersForOutputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersForOutputForm));
            this.panelControlButtons = new DevExpress.XtraEditors.PanelControl();
            this.panelControlButtonsRight = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.resourceManagerSetter = new BSB.Localization.Resources.ResourceManagerSetter();
            this.regionBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
            this.panelControlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
            this.panelControlButtonsRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBS)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlButtons
            // 
            this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtons.Appearance.Options.UseBackColor = true;
            this.panelControlButtons.Controls.Add(this.panelControlButtonsRight);
            this.panelControlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlButtons.Location = new System.Drawing.Point(0, 226);
            this.panelControlButtons.Name = "panelControlButtons";
            this.panelControlButtons.Size = new System.Drawing.Size(292, 47);
            this.panelControlButtons.TabIndex = 3;
            // 
            // panelControlButtonsRight
            // 
            this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
            this.panelControlButtonsRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlButtonsRight.Controls.Add(this.btnCancel);
            this.panelControlButtonsRight.Controls.Add(this.btnOk);
            this.panelControlButtonsRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControlButtonsRight.Location = new System.Drawing.Point(54, 2);
            this.panelControlButtonsRight.Name = "panelControlButtonsRight";
            this.panelControlButtonsRight.Size = new System.Drawing.Size(236, 43);
            this.panelControlButtonsRight.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(124, 10);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(18, 10);
            this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ок";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(292, 273);
            this.panelControl1.TabIndex = 2;
            BSB.Localization.Resources.ResourceManagerProvider.GetResourceManager(typeof(ParametersForOutputForm), resources, out resources);
            // 
            // ParametersForOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.panelControlButtons);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParametersForOutputForm";
            this.Text = "ParametersForOutputForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
            this.panelControlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
            this.panelControlButtonsRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBS)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.PanelControl panelControlButtons;
    protected DevExpress.XtraEditors.PanelControl panelControlButtonsRight;
    public DevExpress.XtraEditors.SimpleButton btnCancel;
    public DevExpress.XtraEditors.SimpleButton btnOk;
    protected DevExpress.XtraEditors.PanelControl panelControl1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private BSB.Localization.Resources.ResourceManagerSetter resourceManagerSetter;
    private System.Windows.Forms.BindingSource regionBS;
  }
}
