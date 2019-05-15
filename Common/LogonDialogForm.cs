using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.LookAndFeel;

namespace BSB.Common.DB
{
  /// <summary>
  ///   Summary description for frmLogonDialog.
  /// </summary>
  public class TfrmLogonDialog : XtraForm
  {
    private SimpleButton btnCancel;
    private SimpleButton btnOk;
    private ComboBoxEdit edbDatabase;
    private TextEdit edLogin;
    private TextEdit edPassword;
    private GroupBox groupBox1;
    private bool IsFirstActivate;
    private Label label1;
    private Label label2;
    private Label label3;
    public string LogonDatabase;
    public string LogonPassword;
    public string LogonUsername;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmLogonDialog()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfrmLogonDialog));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edPassword = new DevExpress.XtraEditors.TextEdit();
            this.edLogin = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edbDatabase.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageIndex = 12;
            this.btnOk.Location = new System.Drawing.Point(49, 232);
            this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(114, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ок";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 13;
            this.btnCancel.Location = new System.Drawing.Point(172, 232);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edPassword);
            this.groupBox1.Controls.Add(this.edLogin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edbDatabase);
            this.groupBox1.Location = new System.Drawing.Point(5, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // edPassword
            // 
            this.edPassword.EditValue = "";
            this.edPassword.Location = new System.Drawing.Point(15, 166);
            this.edPassword.Name = "edPassword";
            this.edPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.edPassword.Properties.Appearance.Options.UseFont = true;
            this.edPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edPassword.Properties.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(293, 26);
            this.edPassword.TabIndex = 2;
            // 
            // edLogin
            // 
            this.edLogin.EditValue = "";
            this.edLogin.Location = new System.Drawing.Point(15, 105);
            this.edLogin.Name = "edLogin";
            this.edLogin.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.edLogin.Properties.Appearance.Options.UseFont = true;
            this.edLogin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edLogin.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edLogin.Size = new System.Drawing.Size(293, 26);
            this.edLogin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя пользователя:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "База данных:";
            // 
            // edbDatabase
            // 
            this.edbDatabase.EditValue = "";
            this.edbDatabase.Location = new System.Drawing.Point(15, 43);
            this.edbDatabase.Name = "edbDatabase";
            this.edbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.edbDatabase.Properties.Appearance.Options.UseFont = true;
            this.edbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edbDatabase.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edbDatabase.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edbDatabase.Size = new System.Drawing.Size(293, 26);
            this.edbDatabase.TabIndex = 0;
            // 
            // TfrmLogonDialog
            // 
            this.AcceptButton = this.btnOk;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 22);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(329, 276);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Seven Classic";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfrmLogonDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Аутентификация пользователя";
            this.Activated += new System.EventHandler(this.TfrmLogonDialog_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TfrmLogonDialog_Closing);
            this.Load += new System.EventHandler(this.frmLogonDialog_Load);
            this.Shown += new System.EventHandler(this.TfrmLogonDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edbDatabase.Properties)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private void frmLogonDialog_Load(object sender, EventArgs e)
    {   
        IsFirstActivate = true;
            InitSkin();    

            LoadTNSNames();
        LoadLastValues();
    }

    private void InitSkin()
    {
        DevExpress.Skins.SkinManager.EnableFormSkins();
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged(); 
    }

    private void LoadTNSNames()
    {
      edbDatabase.Properties.Items.AddRange(DBTNSNames.GetAliasList());
    }
    private void TfrmLogonDialog_Activated(object sender, EventArgs e)
    {
      if (IsFirstActivate)
      {
        if (edbDatabase.Text != "")
        {
          if (edLogin.Text != "")
            edPassword.Focus();
          else
            edLogin.Focus();
        }
        else
          edbDatabase.Focus();

        IsFirstActivate = false;
      }
    }

    private void TfrmLogonDialog_Closing(object sender, CancelEventArgs e)
    {
      if (DialogResult != DialogResult.OK)
      {
        e.Cancel = false;
        return;
      }

      e.Cancel = true;

      LogonDatabase = edbDatabase.Text;
      if (LogonDatabase == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("База данных не указана"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edbDatabase.Focus();
        return;
      }

      LogonUsername = edLogin.Text;
      if (LogonUsername == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Имя пользователя не введено"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edLogin.Focus();
        return;
      }

      LogonPassword = edPassword.Text;
      if (LogonPassword == "")
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Пароль не введен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        edPassword.Focus();
        return;
      }

      SaveLastValues();

      e.Cancel = false;     
      
    }    

    /// <summary>
    ///   Загружаем значения БД и Login из реестра пользователя Windows
    /// </summary>
    private void LoadLastValues()
    {
      var reg = InitApplication.RegSetupRoot.OpenSubKey(InitApplication.RegAppKey, true);
      if (reg == null)
        reg = InitApplication.RegSetupRoot.CreateSubKey(InitApplication.RegAppKey);

      if (reg != null)
      {
        if (reg.GetValue("ProductName") == null)
          reg.SetValue("ProductName", InitApplication.ProductName);

        if (reg.GetValue("AppName") == null)
          reg.SetValue("AppName", InitApplication.AppName);

        if (reg.GetValue("LogonDatabase") != null)
          LogonDatabase = reg.GetValue("LogonDatabase").ToString();

        if (reg.GetValue("LogonUsername") != null)
          LogonUsername = reg.GetValue("LogonUsername").ToString();

        edbDatabase.Text = LogonDatabase;
        edLogin.Text = LogonUsername;
        if (edLogin.Text == "SUPERUSER")
            edPassword.Text = "Qwerty_12345";
      }
    }

    /// <summary>
    ///   Сохраняем значения БД и Login в реестре пользователя Windows
    /// </summary>
    private void SaveLastValues()
    {
      var reg = InitApplication.RegSetupRoot.OpenSubKey(InitApplication.RegAppKey, true);
      if (reg == null)
        reg = InitApplication.RegSetupRoot.CreateSubKey(InitApplication.RegAppKey);

      if (reg != null)
      {
        reg.SetValue("LogonDatabase", LogonDatabase);
        reg.SetValue("LogonUsername", LogonUsername);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
    }

        private void TfrmLogonDialog_Shown(object sender, EventArgs e)
        {
            LookAndFeel.UseDefaultLookAndFeel = true;
            LookAndFeel.SetSkinStyle( InitApplication.skinName );
            LookAndFeel.Style = InitApplication.style;
            
        }
    }
}