using System;
using System.ComponentModel;
using System.Windows.Forms;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using BSB.Common.DataGateway.Oracle;
using Oracle.ManagedDataAccess.Client;

namespace BSB.Common
{
    /// <summary>
    ///   Summary description for frmAppErrorDlg.
    /// </summary>
    public class TfrmAppErrorDlg : XtraForm
  {
    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmAppErrorDlg()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    ///   Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfrmAppErrorDlg));
            this.label1 = new System.Windows.Forms.Label();
            this.lbErrCode = new System.Windows.Forms.Label();
            this.mErrMsgRus = new DevExpress.XtraEditors.MemoEdit();
            this.mErrTrace = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.mErrMsgEng = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrMsgRus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrTrace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrMsgEng.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код ошибки:";
            // 
            // lbErrCode
            // 
            this.lbErrCode.AutoSize = true;
            this.lbErrCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbErrCode.ForeColor = System.Drawing.Color.Red;
            this.lbErrCode.Location = new System.Drawing.Point(122, 15);
            this.lbErrCode.Name = "lbErrCode";
            this.lbErrCode.Size = new System.Drawing.Size(95, 21);
            this.lbErrCode.TabIndex = 1;
            this.lbErrCode.Text = "ErrorCode";
            // 
            // mErrMsgRus
            // 
            this.mErrMsgRus.EditValue = "Сообщение об ошибке на русском языке:";
            this.mErrMsgRus.Location = new System.Drawing.Point(10, 51);
            this.mErrMsgRus.Name = "mErrMsgRus";
            this.mErrMsgRus.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.mErrMsgRus.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mErrMsgRus.Properties.Appearance.Options.UseBackColor = true;
            this.mErrMsgRus.Properties.Appearance.Options.UseFont = true;
            this.mErrMsgRus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.mErrMsgRus.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.mErrMsgRus.Properties.ReadOnly = true;
            this.mErrMsgRus.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mErrMsgRus.Size = new System.Drawing.Size(416, 129);
            this.mErrMsgRus.TabIndex = 2;
            this.mErrMsgRus.TabStop = false;
            this.mErrMsgRus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TfrmAppErrorDlg_KeyUp);
            // 
            // mErrTrace
            // 
            this.mErrTrace.EditValue = "Строка трассировки:";
            this.mErrTrace.Location = new System.Drawing.Point(10, 188);
            this.mErrTrace.Name = "mErrTrace";
            this.mErrTrace.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.mErrTrace.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mErrTrace.Properties.Appearance.Options.UseBackColor = true;
            this.mErrTrace.Properties.Appearance.Options.UseFont = true;
            this.mErrTrace.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.mErrTrace.Properties.ReadOnly = true;
            this.mErrTrace.Size = new System.Drawing.Size(416, 142);
            this.mErrTrace.TabIndex = 3;
            this.mErrTrace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TfrmAppErrorDlg_KeyUp);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageIndex = 12;
            this.btnOk.Location = new System.Drawing.Point(166, 343);
            this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 33);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ок";
            this.btnOk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TfrmAppErrorDlg_KeyUp);
            // 
            // mErrMsgEng
            // 
            this.mErrMsgEng.EditValue = "Сообщение об ошибке на английском языке:";
            this.mErrMsgEng.Location = new System.Drawing.Point(10, 390);
            this.mErrMsgEng.Name = "mErrMsgEng";
            this.mErrMsgEng.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.mErrMsgEng.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mErrMsgEng.Properties.Appearance.Options.UseBackColor = true;
            this.mErrMsgEng.Properties.Appearance.Options.UseFont = true;
            this.mErrMsgEng.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.mErrMsgEng.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.mErrMsgEng.Properties.ReadOnly = true;
            this.mErrMsgEng.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mErrMsgEng.Properties.WordWrap = false;
            this.mErrMsgEng.Size = new System.Drawing.Size(414, 159);
            this.mErrMsgEng.TabIndex = 5;
            this.mErrMsgEng.TabStop = false;
            this.mErrMsgEng.Visible = false;
            this.mErrMsgEng.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TfrmAppErrorDlg_KeyUp);
            // 
            // TfrmAppErrorDlg
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(430, 556);
            this.Controls.Add(this.mErrMsgEng);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mErrTrace);
            this.Controls.Add(this.mErrMsgRus);
            this.Controls.Add(this.lbErrCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfrmAppErrorDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ошибка";
            this.Load += new System.EventHandler(this.TfrmAppErrorDlg_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TfrmAppErrorDlg_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mErrMsgRus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrTrace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrMsgEng.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private void TfrmAppErrorDlg_Load(object sender, EventArgs e)
    {
      OldHeight = Height;
      Height = Height - mErrMsgEng.Size.Height - 10;

      lbErrCode.Text = ErrCode;
      mErrMsgEng.Text = ErrMsgEng;
      mErrMsgRus.Text = ErrMsgRus;
      mErrTrace.Text = ErrTrace;

      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
    }

    private void TfrmAppErrorDlg_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Alt && e.KeyCode == Keys.D)
      {
        mErrMsgEng.Visible = true;
        Height = OldHeight;
      }
    }

    #region Fields

    private SimpleButton btnOk;
    public string ErrCode;
    public string ErrMsgEng;
    public string ErrMsgRus;
    public string ErrTrace;
    private Label label1;
    private Label lbErrCode;
    private MemoEdit mErrMsgEng;
    private MemoEdit mErrMsgRus;
    private MemoEdit mErrTrace;
    private int OldHeight;

    #endregion
  }

  /// <summary>
  ///   Работа с ошибками в приложении
  /// </summary>
  internal class AppErrSupport
  {
    public static void ErrorHandler(string ErrorMsg)
    {
      var ErrDlg = new TfrmAppErrorDlg();
      try
      {
        ErrDlg.ErrCode = "0";
        ErrDlg.ErrMsgRus = ErrorMsg;
        ErrDlg.ErrMsgEng = String.Empty;
        ErrDlg.ErrTrace = String.Empty;

        ErrDlg.ShowDialog();
      }
      finally
      {
        ErrDlg.Dispose();
      }
    }

    public static void ErrorHandler(Exception Error)
    {
      if (Error is OracleException)
      {
        DBSupport.ErrorHandler(Error as OracleException);
      }
      else
      {
        var ErrDlg = new TfrmAppErrorDlg();
        try
        {
          ErrDlg.ErrCode = "0";
          ErrDlg.ErrMsgRus = Error.Message;
          ErrDlg.ErrMsgEng = Error.StackTrace;

          ErrDlg.ShowDialog();
        }
        finally
        {
          ErrDlg.Dispose();
        }
      }
    }
  }
}