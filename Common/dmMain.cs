using System;
using System.ComponentModel;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for dmMain.
  /// </summary>
  public class _dmMain : Form
  {
    private IContainer components;
    // Данные о соединении с БД
    public string DBConnectString = "User Id={0};Password={1};Data Source={2};Pooling=false;";
    public string DBDatabase;
    public string DBLogin;
    public string DBPassword;
    public ImageList imMain;
    public OracleConnection oracleConnection;

    public _dmMain()
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
      this.components = new System.ComponentModel.Container();
      var resources = new System.ComponentModel.ComponentResourceManager(typeof (_dmMain));
      this.imMain = new System.Windows.Forms.ImageList(this.components);
      
        this.oracleConnection = new Oracle.DataAccess.Client.OracleConnection();
      this.SuspendLayout();
      // 
      // imMain
      // 
      this.imMain.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imMain.ImageStream")));
      this.imMain.TransparentColor = System.Drawing.Color.Transparent;
      this.imMain.Images.SetKeyName(0, "");
      this.imMain.Images.SetKeyName(1, "");
      this.imMain.Images.SetKeyName(2, "");
      this.imMain.Images.SetKeyName(3, "");
      this.imMain.Images.SetKeyName(4, "");
      this.imMain.Images.SetKeyName(5, "");
      this.imMain.Images.SetKeyName(6, "");
      this.imMain.Images.SetKeyName(7, "");
      this.imMain.Images.SetKeyName(8, "");
      this.imMain.Images.SetKeyName(9, "");
      this.imMain.Images.SetKeyName(10, "");
      this.imMain.Images.SetKeyName(11, "");
      this.imMain.Images.SetKeyName(12, "");
      this.imMain.Images.SetKeyName(13, "");
      this.imMain.Images.SetKeyName(14, "");
      this.imMain.Images.SetKeyName(15, "");
      this.imMain.Images.SetKeyName(16, "");
      this.imMain.Images.SetKeyName(17, "");
      this.imMain.Images.SetKeyName(18, "");
      this.imMain.Images.SetKeyName(19, "");
      this.imMain.Images.SetKeyName(20, "");
      this.imMain.Images.SetKeyName(21, "");
      this.imMain.Images.SetKeyName(22, "");
      this.imMain.Images.SetKeyName(23, "");
      this.imMain.Images.SetKeyName(24, "");
      this.imMain.Images.SetKeyName(25, "");
      this.imMain.Images.SetKeyName(26, "window_information.png");
      // 
      // _dmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(264, 117);
      this.Name = "_dmMain";
      this.ShowInTaskbar = false;
      this.Text = "dmMain";
      this.ResumeLayout(false);
    }

    #endregion
  }

  public class dmControler
  {
    public static _dmMain frmMain;

    public static void Init(Form OwnerForm)
    {
      UnInit();

      frmMain = new _dmMain();
      try
      {
        frmMain.Visible = false;
        OwnerForm.AddOwnedForm(frmMain);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
        frmMain.Dispose();
      }
    }

    public static void UnInit()
    {
      if (frmMain != null)
      {
        frmMain.Dispose();
        frmMain = null;
      }
    }
  }
}