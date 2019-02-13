namespace ARM_User.DisplayLayer.Base
{
    partial class SimpleDBEditGBTreeForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleDBEditGBTreeForm));
        this.btnSave = new DevExpress.XtraEditors.SimpleButton();
        this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
        this.panel1 = new System.Windows.Forms.Panel();
        this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
        this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
        this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
        this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
        this.panelControl1.Appearance.Options.UseBackColor = true;
        this.panelControl1.Controls.Add(this.panel1);
        this.panelControl1.Size = new System.Drawing.Size(481, 389);
        // 
        // bar1
        // 
        //this.bar1.Visible = false;
        // 
        // btnSave
        // 
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
        this.panel1.Location = new System.Drawing.Point(2, 356);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(477, 31);
        this.panel1.TabIndex = 4;
        // 
        // xtraTabControl2
        // 
        this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.xtraTabControl2.Location = new System.Drawing.Point(4, 4);
        this.xtraTabControl2.Name = "xtraTabControl2";
        this.xtraTabControl2.Size = new System.Drawing.Size(469, 342);
        this.xtraTabControl2.TabIndex = 0;
        // 
        // panelControl2
        // 
        this.panelControl2.Location = new System.Drawing.Point(8, 17);
        this.panelControl2.Name = "panelControl2";
        this.panelControl2.Size = new System.Drawing.Size(443, 228);
        this.panelControl2.TabIndex = 0;
        // 
        // panelControl3
        // 
        this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelControl3.Location = new System.Drawing.Point(4, 4);
        this.panelControl3.Name = "panelControl3";
        this.panelControl3.Size = new System.Drawing.Size(469, 335);
        this.panelControl3.TabIndex = 0;
        // 
        // panelControl4
        // 
        this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelControl4.Location = new System.Drawing.Point(4, 4);
        this.panelControl4.Name = "panelControl4";
        this.panelControl4.Size = new System.Drawing.Size(469, 342);
        this.panelControl4.TabIndex = 0;
        // 
        // SimpleDBEditGBTreeForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(481, 418);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "SimpleDBEditGBTreeForm";
        this.Text = "SimpleDBEditGBTreeForm";
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.SimpleButton btnSave;
    protected DevExpress.XtraEditors.SimpleButton btnCancel;
    private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
    protected System.Windows.Forms.Panel panel1;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.PanelControl panelControl3;
    private DevExpress.XtraEditors.PanelControl panelControl4;

  }
}
