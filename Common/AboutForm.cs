using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for Form2.
  /// </summary>
  public class TfrmAbout : XtraForm
  {
    private SimpleButton btnOk;
    private GroupBox groupBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private LinkLabel linkLabel1;
    private LinkLabel linkLabel2;
    private Label lProduct;
    private Label lVersion;
    private PictureBox pictureBox1;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmAbout()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfrmAbout));
        this.btnOk = new DevExpress.XtraEditors.SimpleButton();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        this.linkLabel2 = new System.Windows.Forms.LinkLabel();
        this.label7 = new System.Windows.Forms.Label();
        this.lVersion = new System.Windows.Forms.Label();
        this.lProduct = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // btnOk
        // 
        this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnOk.Location = new System.Drawing.Point(310, 248);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(75, 25);
        this.btnOk.TabIndex = 0;
        this.btnOk.Text = "Закрыть";
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(123, 279);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.pictureBox1.TabIndex = 1;
        this.pictureBox1.TabStop = false;
        // 
        // groupBox1
        // 
        this.groupBox1.Location = new System.Drawing.Point(128, 239);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(256, 4);
        this.groupBox1.TabIndex = 2;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "groupBox1";
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.Location = new System.Drawing.Point(128, 12);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(88, 17);
        this.label1.TabIndex = 3;
        this.label1.Text = "Программа:";
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label2.Location = new System.Drawing.Point(128, 69);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(88, 17);
        this.label2.TabIndex = 4;
        this.label2.Text = "Версия:";
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label3.Location = new System.Drawing.Point(128, 113);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(96, 17);
        this.label3.TabIndex = 5;
        this.label3.Text = "Разработчик:";
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label4.Location = new System.Drawing.Point(128, 170);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(176, 17);
        this.label4.TabIndex = 6;
        this.label4.Text = "Контактная информация:";
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label5.Location = new System.Drawing.Point(144, 192);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(48, 17);
        this.label5.TabIndex = 7;
        this.label5.Text = "E-Mail:";
        // 
        // label6
        // 
        this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label6.Location = new System.Drawing.Point(154, 213);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(38, 17);
        this.label6.TabIndex = 8;
        this.label6.Text = "Web:";
        // 
        // linkLabel1
        // 
        this.linkLabel1.Location = new System.Drawing.Point(199, 192);
        this.linkLabel1.Name = "linkLabel1";
        this.linkLabel1.Size = new System.Drawing.Size(96, 17);
        this.linkLabel1.TabIndex = 9;
        this.linkLabel1.TabStop = true;
        this.linkLabel1.Text = "support.bsbnb.kz";
        // 
        // linkLabel2
        // 
        this.linkLabel2.Location = new System.Drawing.Point(199, 213);
        this.linkLabel2.Name = "linkLabel2";
        this.linkLabel2.Size = new System.Drawing.Size(113, 17);
        this.linkLabel2.TabIndex = 10;
        this.linkLabel2.TabStop = true;
        this.linkLabel2.Text = "http://www.bsbnb.kz";
        // 
        // label7
        // 
        this.label7.Location = new System.Drawing.Point(128, 135);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(248, 35);
        this.label7.TabIndex = 11;
        this.label7.Text = "АО «Банковское сервисное бюро Национального Банка Казахстана» ";
        // 
        // lVersion
        // 
        this.lVersion.Location = new System.Drawing.Point(128, 92);
        this.lVersion.Name = "lVersion";
        this.lVersion.Size = new System.Drawing.Size(167, 15);
        this.lVersion.TabIndex = 12;
        this.lVersion.Text = "[version]";
        // 
        // lProduct
        // 
        this.lProduct.Location = new System.Drawing.Point(128, 32);
        this.lProduct.Name = "lProduct";
        this.lProduct.Size = new System.Drawing.Size(248, 35);
        this.lProduct.TabIndex = 13;
        this.lProduct.Text = "[product]";
        // 
        // TfrmAbout
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
        this.CancelButton = this.btnOk;
        this.ClientSize = new System.Drawing.Size(392, 279);
        this.Controls.Add(this.lProduct);
        this.Controls.Add(this.lVersion);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.linkLabel2);
        this.Controls.Add(this.linkLabel1);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.btnOk);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "TfrmAbout";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "О программе";
        this.Load += new System.EventHandler(this.TfrmAbout_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private void btnOk_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void TfrmAbout_Load(object sender, EventArgs e)
    {
      var asm = Assembly.GetExecutingAssembly();
      var ac = (AssemblyCopyrightAttribute) (asm.GetCustomAttributes(typeof (AssemblyCopyrightAttribute), true)[0]);
      lVersion.Text = Application.ProductVersion;
      lProduct.Text = Application.ProductName;
      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
    }
  }
}