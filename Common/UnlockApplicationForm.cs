using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for frmUnlockApplication.
  /// </summary>
  public class TfrmUnlockApplication : XtraForm
  {
    private SimpleButton btnCancel;
    private SimpleButton btnOk;
    private TextEdit edPassword;
    private GroupBox groupBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private PictureBox pictureBox1;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmUnlockApplication()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      label2.Text = InitApplication.currentUser.Name;
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
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
      var resources = new System.ComponentModel.ComponentResourceManager(typeof (TfrmUnlockApplication));
      this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
      this.btnOk = new DevExpress.XtraEditors.SimpleButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.edPassword = new DevExpress.XtraEditors.TextEdit();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize) (this.edPassword.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Image = ((System.Drawing.Image) (resources.GetObject("btnCancel.Image")));
      this.btnCancel.ImageIndex = 13;
      this.btnCancel.Location = new System.Drawing.Point(285, 155);
      this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(85, 25);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Отмена";
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Image = ((System.Drawing.Image) (resources.GetObject("btnOk.Image")));
      this.btnOk.ImageIndex = 12;
      this.btnOk.Location = new System.Drawing.Point(193, 155);
      this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(85, 25);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Ок";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Controls.Add(this.edPassword);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Location = new System.Drawing.Point(6, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(364, 146);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.label2.ForeColor = System.Drawing.Color.Navy;
      this.label2.Location = new System.Drawing.Point(80, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "User Name";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.label1.Location = new System.Drawing.Point(80, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(227, 41);
      this.label1.TabIndex = 6;
      this.label1.Text = "Приложение заблокировано. Введите пароль для пользователя";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(11, 17);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(61, 57);
      this.pictureBox1.TabIndex = 5;
      this.pictureBox1.TabStop = false;
      // 
      // edPassword
      // 
      this.edPassword.EditValue = "";
      this.edPassword.Location = new System.Drawing.Point(16, 108);
      this.edPassword.Name = "edPassword";
      this.edPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F,
        System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.edPassword.Properties.Appearance.Options.UseFont = true;
      this.edPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.edPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.edPassword.Properties.PasswordChar = '*';
      this.edPassword.Size = new System.Drawing.Size(333, 20);
      this.edPassword.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((byte) (204)));
      this.label3.Location = new System.Drawing.Point(16, 88);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 18);
      this.label3.TabIndex = 4;
      this.label3.Text = "Пароль:";
      // 
      // TfrmUnlockApplication
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
      this.ClientSize = new System.Drawing.Size(376, 185);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TfrmUnlockApplication";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Система безопасности";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize) (this.edPassword.Properties)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion
  }
}