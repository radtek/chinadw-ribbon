using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace BSB.Common.DB
{
    /// <summary>
    ///   Summary description for frmChangePassword.
    /// </summary>
    public class TfrmChangePassword : XtraForm
  {
    private SimpleButton btnCancel;
    private SimpleButton btnOk;
    private TextEdit edNewPassword1;
    private TextEdit edNewPassword2;
    private TextEdit edOldPassword;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private OracleConnection ocChangePassword = new OracleConnection(); 
    private OracleCommand ocmdChangePassword;
    private Panel panel1;
    private PictureBox pictureBox1;    
    public decimal is_cancel = 0;
    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmChangePassword()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();      

      //
      // TODO: Add any constructor code after InitializeComponent call
      //

      /*if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);  commented Beles */
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfrmChangePassword));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edNewPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.edNewPassword1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.edOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edNewPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNewPassword1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edOldPassword.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.edNewPassword2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.edNewPassword1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edOldPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(19, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(358, 9);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // edNewPassword2
            // 
            this.edNewPassword2.EditValue = "";
            this.edNewPassword2.Location = new System.Drawing.Point(66, 199);
            this.edNewPassword2.Name = "edNewPassword2";
            this.edNewPassword2.Properties.Appearance.Options.UseFont = true;
            this.edNewPassword2.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edNewPassword2.Properties.PasswordChar = '*';
            this.edNewPassword2.Size = new System.Drawing.Size(264, 24);
            this.edNewPassword2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(67, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Подтверждение нового пароля:";
            // 
            // edNewPassword1
            // 
            this.edNewPassword1.EditValue = "";
            this.edNewPassword1.Location = new System.Drawing.Point(66, 133);
            this.edNewPassword1.Name = "edNewPassword1";
            this.edNewPassword1.Properties.Appearance.Options.UseFont = true;
            this.edNewPassword1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edNewPassword1.Properties.PasswordChar = '*';
            this.edNewPassword1.Size = new System.Drawing.Size(264, 24);
            this.edNewPassword1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Новый пароль:";
            // 
            // edOldPassword
            // 
            this.edOldPassword.EditValue = "";
            this.edOldPassword.Location = new System.Drawing.Point(66, 44);
            this.edOldPassword.Name = "edOldPassword";
            this.edOldPassword.Properties.Appearance.Options.UseFont = true;
            this.edOldPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edOldPassword.Properties.PasswordChar = '*';
            this.edOldPassword.Size = new System.Drawing.Size(264, 24);
            this.edOldPassword.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Старый пароль:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 13;
            this.btnCancel.Location = new System.Drawing.Point(299, 388);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageIndex = 12;
            this.btnOk.Location = new System.Drawing.Point(193, 388);
            this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 32);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ок";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 114);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(85, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 86);
            this.label4.TabIndex = 5;
            this.label4.Text = "После успешного изменения пароля будет выполнено отключение от базы данных с закр" +
    "ытием всех открытых окон. Для продолжения работы необходимо будет подключиться к" +
    " БД с новым паролем";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 69);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // TfrmChangePassword
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 434);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfrmChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение пароля пользователя";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TfrmChangePassword_Closing);
            this.Closed += new System.EventHandler(this.TfrmChangePassword_Closed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edNewPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edNewPassword1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edOldPassword.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private void TfrmChangePassword_Closing(object sender, CancelEventArgs e)
    {
      if (DialogResult != DialogResult.OK)
      {
          
              e.Cancel = false;
              return;
      }

      e.Cancel = true;

      // Проверяем заполнение полей
      if (edOldPassword.Text == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Старый пароль не введен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edOldPassword.Focus();
        return;
      }

      if (edNewPassword1.Text == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Новый пароль не введен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edNewPassword1.Focus();
        return;
      }

      if (edNewPassword2.Text == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Подтверждение нового пароля не введено"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edNewPassword2.Focus();
        return;
      }

      // Проверяем совпадение паролей
      if (!edNewPassword1.Text.Equals(edNewPassword2.Text))
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Пароли не совпадают"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edNewPassword1.Focus();
        return;
      }


            // Выполняем подключение к БД со старым паролем	
       ocChangePassword.ConnectionString = String.Format(
            dmControler.frmMain.DBConnectString,
            dmControler.frmMain.DBHost,
            dmControler.frmMain.DBPort,
            dmControler.frmMain.DBDatabase,
            dmControler.frmMain.DBLogin,
            dmControler.frmMain.DBPassword); ;
            
                
      try
      {
        ocChangePassword.Open();
      }
      catch (OracleException oe)
      {
        switch (oe.Number)
        {
          case 1004:
            XtraMessageBox.Show(LangTranslate.UiGetText("Не указано имя пользователя для подключения к базе данных"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 1005:
            XtraMessageBox.Show(LangTranslate.UiGetText("Не указан пароль для подключения к базе данных"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 1017:
            XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя пользователя или пароль"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 12154:
            XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя сервера"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 12500:
            XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя сервера"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 12560:
            XtraMessageBox.Show(LangTranslate.UiGetText("Не задано (неверно задано) имя сервера"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          case 28000:
            XtraMessageBox.Show(LangTranslate.UiGetText("Пользователь ORACLE заблокирован"),
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
          default:
            XtraMessageBox.Show(LangTranslate.UiGetText("Ошибка № ") + oe.Number + ": " + oe.Message,
              LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            break;
        }
      }

      if (ocChangePassword.State != ConnectionState.Open)
        return;

      // Изменяем пароль пользователя
      try
      {
        try
        {
          ocmdChangePassword = ocChangePassword.CreateCommand();
          ocmdChangePassword.Parameters.Clear();
          ocmdChangePassword.Parameters.Add("DATABASE_NAME_", OracleDbType.Varchar2, dmControler.frmMain.DBDatabase,
            ParameterDirection.Input);
          ocmdChangePassword.Parameters.Add("USER_NAME_", OracleDbType.Varchar2, dmControler.frmMain.DBLogin,
            ParameterDirection.Input);
          ocmdChangePassword.Parameters.Add("OLD_PASSWORD_", OracleDbType.Varchar2, edOldPassword.Text,
            ParameterDirection.Input);
          ocmdChangePassword.Parameters.Add("NEW_PASSWORD_", OracleDbType.Varchar2, edNewPassword1.Text,
            ParameterDirection.Input);
          ocmdChangePassword.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          ocmdChangePassword.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          ocmdChangePassword.Parameters["err_msg"].Size = 4000;
          ocmdChangePassword.CommandText = "adm.official_pack.Change_Current_User_Password";
          ocmdChangePassword.CommandType = CommandType.StoredProcedure;
          ocmdChangePassword.ExecuteNonQuery();

          var ErrCode = ((OracleDecimal) (ocmdChangePassword.Parameters["err_code"].Value)).ToInt32();
          if (ErrCode != 0)
          {
            var ErrMsg = ocmdChangePassword.Parameters["err_msg"].Value.ToString();
            DBSupport.DBErrorHandler(ErrCode, ErrMsg);
          }
          else
          {
            XtraMessageBox.Show(LangTranslate.UiGetText("Пароль успешно изменен"),
              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = false;
          }
        }
        finally
        {
          ocChangePassword.Close();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number,
          oe.Message + Environment.NewLine + "(occured in TfrmChangePassword.TfrmChangePassword_Closing).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(
          oe.Message + Environment.NewLine + "(occured in TfrmChangePassword.TfrmChangePassword_Closing).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TfrmChangePassword_Closed(object sender, EventArgs e)
    {
      if (ocChangePassword.State == ConnectionState.Open)
      {
        // Отключаемся от БД
        try
        {
          ocChangePassword.Close();
        }
        catch (Exception ex)
        {
          XtraMessageBox.Show(
            LangTranslate.UiGetText("Ошибка при отключении от базы данных:") + Environment.NewLine + ex.Message,
            LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ocChangePassword_StateChange(object sender, StateChangeEventArgs e)
    {
      if (e.CurrentState == ConnectionState.Open)
      {
        var ai = new TDBMS_Application_Info();
        ai.oc = ocChangePassword;

        // Задаем ID info
        ai.Set_Module(InitApplication.AppTitle, "Changing Password");
        ai.Set_Client_Info(InitApplication.BSB_APP_GUID);

        // Ожидаем идентификации приложения
        var oldCursor = Cursor;
        Cursor = Cursors.WaitCursor;
        try
        {
          var Audsid = DBExtended.get_SESSIONID(ocChangePassword);
          do
          {
            for (var i = 1; i < 50; i++)
            {
              Thread.Sleep(10);
              Application.DoEvents();
            }
          } while (!DBSupport.IsAppIdentified(Decimal.Parse(Audsid)));
        }
        finally
        {
          Cursor = oldCursor;
        }

        // Приложение идентифицировано. Убираем ID info
        ai.Set_Module(InitApplication.AppTitle, "");
        ai.Set_Client_Info("");
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        is_cancel = 1;
    }
  }
}