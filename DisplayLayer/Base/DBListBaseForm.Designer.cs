namespace ARM_User.DisplayLayer.Base
{
  partial class DBListBaseForm
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
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
        this.SuspendLayout();
        // 
        // gridMain
        // 
        this.gridMain.Location = new System.Drawing.Point(0, 24);
        this.gridMain.Size = new System.Drawing.Size(523, 385);
        // 
        // gridMainView
        // 
        this.gridMainView.OptionsBehavior.AllowIncrementalSearch = true;
        this.gridMainView.OptionsBehavior.Editable = false;
        this.gridMainView.OptionsDetail.EnableMasterViewMode = false;
        this.gridMainView.OptionsView.ColumnAutoWidth = false;
        this.gridMainView.OptionsView.ShowFooter = true;
        this.gridMainView.OptionsView.ShowGroupPanel = false;
        this.gridMainView.PaintStyleName = "WindowsXP";
        // 
        // edCountRecord
        // 
        this.edCountRecord.Caption = "2";
        // 
        // barDockControlBottom
        // 
        this.barDockControlBottom.Location = new System.Drawing.Point(0, 409);
        this.barDockControlBottom.Size = new System.Drawing.Size(523, 0);
        // 
        // barDockControlLeft
        // 
        this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
        this.barDockControlLeft.Size = new System.Drawing.Size(0, 385);
        // 
        // barDockControlRight
        // 
        this.barDockControlRight.Location = new System.Drawing.Point(523, 24);
        this.barDockControlRight.Size = new System.Drawing.Size(0, 385);
        // 
        // barDockControlTop
        // 
        this.barDockControlTop.Size = new System.Drawing.Size(523, 24);
        // 
        // DBListBaseForm
        // 
        this.ClientSize = new System.Drawing.Size(523, 409);
        this.Name = "DBListBaseForm";
        ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.gridMainView)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion
  }
}
