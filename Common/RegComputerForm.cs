using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BSB.Common.DB;
using BSB.Common.DB.Admin;
using BSB.Win32API;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for frmRegComputer.
  /// </summary>
  public class TfrmRegComputer : XtraForm
  {
    private const int WM_POSTSHOW = (int) WinMessage.WM_USER + 1;
    private SimpleButton btnCancel;
    private SimpleButton btnOk;
    private GroupBox groupBox1;
    private Label label1;
    public OracleConnection ocRegComp;
    public Int32 pComputerID;
    public string pComputerName = String.Empty;
    private TextEdit teDescription;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmRegComputer()
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof (TfrmRegComputer));
      this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
      this.btnOk = new DevExpress.XtraEditors.SimpleButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.teDescription = new DevExpress.XtraEditors.TextEdit();
      this.ocRegComp = new Oracle.DataAccess.Client.OracleConnection();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.teDescription.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Image = ((System.Drawing.Image) (resources.GetObject("btnCancel.Image")));
      this.btnCancel.ImageIndex = 13;
      this.btnCancel.Location = new System.Drawing.Point(407, 78);
      this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(85, 24);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Отмена";
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Image = ((System.Drawing.Image) (resources.GetObject("btnOk.Image")));
      this.btnOk.ImageIndex = 12;
      this.btnOk.Location = new System.Drawing.Point(319, 78);
      this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(85, 24);
      this.btnOk.TabIndex = 7;
      this.btnOk.Text = "Ок";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.teDescription);
      this.groupBox1.Location = new System.Drawing.Point(7, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(485, 66);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.label1.Location = new System.Drawing.Point(9, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 14);
      this.label1.TabIndex = 11;
      this.label1.Text = "Описание компьютера:";
      // 
      // teDescription
      // 
      this.teDescription.EditValue = "";
      this.teDescription.Location = new System.Drawing.Point(152, 26);
      this.teDescription.Name = "teDescription";
      this.teDescription.Size = new System.Drawing.Size(324, 20);
      this.teDescription.TabIndex = 0;
      // 
      // ocRegComp
      // 
      this.ocRegComp.StateChange += new System.Data.StateChangeEventHandler(this.ocRegComp_StateChange);
      // 
      // TfrmRegComputer
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(498, 102);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TfrmRegComputer";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Регистрация компьютера";
      this.Load += new System.EventHandler(this.TfrmRegComputer_Load);
      this.Closed += new System.EventHandler(this.TfrmRegComputer_Closed);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.TfrmRegComputer_Closing);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) (this.teDescription.Properties)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    private void TfrmRegComputer_Load(object sender, EventArgs e)
    {
      Win32.PostMessage(Handle, WM_POSTSHOW, IntPtr.Zero, IntPtr.Zero);
    }

    private void TfrmRegComputer_Closing(object sender, CancelEventArgs e)
    {
      if (DialogResult != DialogResult.OK)
      {
        e.Cancel = false;
        return;
      }

      if (teDescription.Text == String.Empty)
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Описание компьютера не введено"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        teDescription.Focus();
        e.Cancel = true;
        return;
      }

      e.Cancel = !RegisterComp();
      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
    }

    private void TfrmRegComputer_Closed(object sender, EventArgs e)
    {
      // Отключаемся от БД
      DBSupport.DisconnectFromOracle(ocRegComp);
    }

    private void ocRegComp_StateChange(object sender, StateChangeEventArgs e)
    {
      if (e.CurrentState == ConnectionState.Open)
      {
        var ai = new TDBMS_Application_Info();
        try
        {
          ai.oc = ocRegComp;

          // Задаем ID info
          ai.Set_Module(InitApplication.AppTitle, "Changing Password");
          ai.Set_Client_Info(InitApplication.BSB_APP_GUID);

          // Ожидаем идентификации приложения
          var oldCursor = Cursor;
          Cursor = Cursors.WaitCursor;
          try
          {
            var Audsid = DBExtended.get_SESSIONID(ocRegComp);
            do
            {
              for (var i = 1; i < 50; i++)
              {
                Thread.Sleep(10);
                Application.DoEvents();
              }
            } while (!DBSupport.IsAppIdentified(Int32.Parse(Audsid)));
          }
          finally
          {
            Cursor = oldCursor;
          }

          // Приложение идентифицировано. Убираем ID info
          ai.Set_Module(InitApplication.AppTitle, "");
          ai.Set_Client_Info("");
        }
        catch (OracleException oe)
        {
          DBSupport.DBErrorHandler(oe.Number,
            oe.Message + Environment.NewLine + "(occured in TfrmRegComputer.ocRegComp_StateChange).");
        }
        catch (Exception oe)
        {
          XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in TfrmRegComputer.ocRegComp_StateChange).",
            LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private bool RegisterComp()
    {
      var Result = false;
      Int32 OSPlatformId, OSMajorVer, OSMinorVer, OSBuildNumber;
      Int32 CPUAmount, CPUType;
      UInt32 DiskCSerNum, FixedDrives;

      Utilities.GetPCData(out pComputerName, out OSPlatformId, out OSMajorVer, out OSMinorVer, out OSBuildNumber,
        out CPUAmount, out CPUType, out FixedDrives, out DiskCSerNum);

      Int32 ErrCode;
      string ErrMsg;

      var pc = new TPkgComputer();
      try
      {
        pc.oc = ocRegComp;
        pc.InsertComputer(pComputerName, teDescription.Text, OSPlatformId, OSMajorVer, OSMinorVer,
          OSBuildNumber, CPUAmount, CPUType, FixedDrives, (Int32) DiskCSerNum, 0, out pComputerID, out ErrCode,
          out ErrMsg);

        if (ErrCode != 0)
        {
          DBSupport.DBErrorHandler(ErrCode, ErrMsg);
        }
        else
        {
          // Показывает информацию о компьютере
          var cinf = new TfrmRegComputerInfo();
          try
          {
            cinf.ShowDialog();
          }
          finally
          {
            cinf.Dispose();
          }

          Result = true;
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number,
          oe.Message + Environment.NewLine + "(occured in TfrmRegComputer.RegisterComp).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in TfrmRegComputer.RegisterComp).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return Result;
    }

    private void InitRegComp()
    {
      // Выполняем подключение к БД
      if (!DBSupport.ConnectToOracle(ocRegComp))
      {
        DialogResult = DialogResult.Cancel;
        Close();
        return;
      }

      var oldCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        // Заполняем таблицы прав и меню текущего должн. лица
        if (!DBSupport.FillCurrOfficTables(ocRegComp))
        {
          XtraMessageBox.Show(
            LangTranslate.UiGetText("Ошибка заполнения таблиц прав и меню пользователя") + Environment.NewLine +
            LangTranslate.UiGetText("В доступе отказано"),
            LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
          DialogResult = DialogResult.Cancel;
          Close();
          return;
        }

        // Корректируем объектные привилегии текущего должн. лица
        DBSupport.CorrectCurrOfficGrants(ocRegComp);
      }
      finally
      {
        Cursor.Current = oldCursor;
      }
    }

    protected override void WndProc(ref Message m)
    {
      // TODO:  Add Form1.WndProc implementation
      if (m.Msg == WM_POSTSHOW)
      {
        InitRegComp();
      }
      base.WndProc(ref m);
    }
  }
}