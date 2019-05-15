using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace BSB.Common.DB
{
    /// <summary>
    ///   Summary description for frmLogonDialog.
    /// </summary>
    public class TfrmLogonDialog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SimpleButton btnCancel;
    private SimpleButton btnOk;
    private bool IsFirstActivate;
    public string LogonDatabase;
    public string LogonPassword;
    public string LogonUsername;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraTab.XtraTabControl xtabControlLogin;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private SimpleButton simpleButton2;
        private GroupControl groupControl1;
        private ComboBoxEdit edbDatabase;
        private SimpleButton simpleButton1;
        private Label labelEdbDatabase;
        private TextEdit edPassword;
        private TextEdit edLogin;
        private Label label3;
        private Label label2;

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
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.xtabControlLogin = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelEdbDatabase = new System.Windows.Forms.Label();
            this.edPassword = new DevExpress.XtraEditors.TextEdit();
            this.edLogin = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabControlLogin)).BeginInit();
            this.xtabControlLogin.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edbDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageIndex = 12;
            this.btnOk.Location = new System.Drawing.Point(33, 197);
            this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(114, 29);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ок";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 13;
            this.btnCancel.Location = new System.Drawing.Point(183, 197);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(318, 36);
            // 
            // xtabControlLogin
            // 
            this.xtabControlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabControlLogin.Location = new System.Drawing.Point(0, 36);
            this.xtabControlLogin.Name = "xtabControlLogin";
            this.xtabControlLogin.SelectedTabPage = this.xtraTabPage1;
            this.xtabControlLogin.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtabControlLogin.Size = new System.Drawing.Size(318, 278);
            this.xtabControlLogin.TabIndex = 4;
            this.xtabControlLogin.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Controls.Add(this.btnCancel);
            this.xtraTabPage1.Controls.Add(this.btnOk);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(314, 274);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.edbDatabase);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.labelEdbDatabase);
            this.groupControl1.Controls.Add(this.edPassword);
            this.groupControl1.Controls.Add(this.edLogin);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
            this.groupControl1.Size = new System.Drawing.Size(314, 193);
            this.groupControl1.TabIndex = 3;
            // 
            // edbDatabase
            // 
            this.edbDatabase.EditValue = "";
            this.edbDatabase.Location = new System.Drawing.Point(11, 47);
            this.edbDatabase.Name = "edbDatabase";
            this.edbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edbDatabase.Properties.Appearance.Options.UseFont = true;
            this.edbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edbDatabase.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edbDatabase.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edbDatabase.Size = new System.Drawing.Size(246, 26);
            this.edbDatabase.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(268, 45);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(33, 28);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelEdbDatabase
            // 
            this.labelEdbDatabase.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdbDatabase.Location = new System.Drawing.Point(11, 25);
            this.labelEdbDatabase.Name = "labelEdbDatabase";
            this.labelEdbDatabase.Size = new System.Drawing.Size(170, 23);
            this.labelEdbDatabase.TabIndex = 11;
            this.labelEdbDatabase.Text = "База данных:";
            // 
            // edPassword
            // 
            this.edPassword.EditValue = "";
            this.edPassword.Location = new System.Drawing.Point(11, 156);
            this.edPassword.Name = "edPassword";
            this.edPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edPassword.Properties.Appearance.Options.UseFont = true;
            this.edPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edPassword.Properties.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(285, 26);
            this.edPassword.TabIndex = 8;
            // 
            // edLogin
            // 
            this.edLogin.EditValue = "";
            this.edLogin.Location = new System.Drawing.Point(11, 100);
            this.edLogin.Name = "edLogin";
            this.edLogin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edLogin.Properties.Appearance.Options.UseFont = true;
            this.edLogin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edLogin.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.edLogin.Size = new System.Drawing.Size(285, 26);
            this.edLogin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Имя пользователя:";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.simpleButton2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(314, 233);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Location = new System.Drawing.Point(211, 197);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(94, 29);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "Next";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // TfrmLogonDialog
            // 
            this.AcceptButton = this.btnOk;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 20);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(318, 314);
            this.Controls.Add(this.xtabControlLogin);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfrmLogonDialog";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Аутентификация пользователя";
            this.Activated += new System.EventHandler(this.TfrmLogonDialog_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TfrmLogonDialog_Closing);
            this.Load += new System.EventHandler(this.frmLogonDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabControlLogin)).EndInit();
            this.xtabControlLogin.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edbDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLogin.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private void frmLogonDialog_Load(object sender, EventArgs e)
    {
      IsFirstActivate = true;

      LoadTNSNames();
      LoadLastValues();
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

    private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void groupControl1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
            xtabControlLogin.SelectedTabPage = xtraTabPage2;
    }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            xtabControlLogin.SelectedTabPage = xtraTabPage1;
        }
    }
}