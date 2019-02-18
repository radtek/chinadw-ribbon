﻿namespace ARM_User.DisplayLayer.Base
{
    partial class SimpleModulsEditGBForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleModulsEditGBForm));
        this.tcMain = new DevExpress.XtraTab.XtraTabControl();
        this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
        this.btnSave = new DevExpress.XtraEditors.SimpleButton();
        this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
        this.panel1 = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
        this.tcMain.SuspendLayout();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
        this.panelControl1.Appearance.Options.UseBackColor = true;
        this.panelControl1.Controls.Add(this.panel1);
        this.panelControl1.Controls.Add(this.tcMain);
        this.panelControl1.Size = new System.Drawing.Size(481, 389);
        // 
        // bar1
        // 
        //this.bar1.Visible = false;
        // 
        // tcMain
        // 
        this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
        this.tcMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
        this.tcMain.Location = new System.Drawing.Point(2, 2);
        this.tcMain.Name = "tcMain";
        this.tcMain.PaintStyleName = "WindowsXP";
        this.tcMain.SelectedTabPage = this.xtraTabPage1;
        this.tcMain.Size = new System.Drawing.Size(477, 350);
        this.tcMain.TabIndex = 0;
        this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
        // 
        // xtraTabPage1
        // 
        this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
        this.xtraTabPage1.Name = "xtraTabPage1";
        this.xtraTabPage1.Size = new System.Drawing.Size(469, 322);
        this.xtraTabPage1.Text = "Реквизиты";
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
        // SimpleModulsEditGBForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(481, 418);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "SimpleModulsEditGBForm";
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
        this.tcMain.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraTab.XtraTabControl tcMain;
    protected DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    protected DevExpress.XtraEditors.SimpleButton btnSave;
    protected DevExpress.XtraEditors.SimpleButton btnCancel;
    protected System.Windows.Forms.Panel panel1;

  }
}