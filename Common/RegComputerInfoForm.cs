using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for frmRegComputerInfo.
  /// </summary>
  public class TfrmRegComputerInfo : XtraForm
  {
    private SimpleButton btnOk;
    private GroupBox groupBox1;
    private Label labComputerName;
    private Label labCPUAmount;
    private Label labCPUType;
    private Label labDiskCSerNum;
    private Label label1;
    private Label label12;
    private Label label15;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label labFixedDrives;
    private Label labOSBuildNumber;
    private Label labOSMajorVer;
    private Label labOSMinorVer;
    private Label labOSPlatformID;
    private PictureBox pictureBox1;

    /// <summary>
    ///   Required designer variable.
    /// </summary>
    private readonly Container components = null;

    public TfrmRegComputerInfo()
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
      var resources = new System.Resources.ResourceManager(typeof (TfrmRegComputerInfo));
      this.btnOk = new DevExpress.XtraEditors.SimpleButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labDiskCSerNum = new System.Windows.Forms.Label();
      this.labFixedDrives = new System.Windows.Forms.Label();
      this.labCPUAmount = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.labCPUType = new System.Windows.Forms.Label();
      this.labOSBuildNumber = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.labOSMinorVer = new System.Windows.Forms.Label();
      this.labOSMajorVer = new System.Windows.Forms.Label();
      this.labOSPlatformID = new System.Windows.Forms.Label();
      this.labComputerName = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Image = ((System.Drawing.Image) (resources.GetObject("btnOk.Image")));
      this.btnOk.ImageIndex = 12;
      this.btnOk.Location = new System.Drawing.Point(461, 258);
      this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(85, 23);
      //this.btnOk.Style = new DevExpress.Utils.ViewStyle("ControlStyle", null, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText);
      this.btnOk.TabIndex = 8;
      this.btnOk.Text = "Ок";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.labDiskCSerNum);
      this.groupBox1.Controls.Add(this.labFixedDrives);
      this.groupBox1.Controls.Add(this.labCPUAmount);
      this.groupBox1.Controls.Add(this.label15);
      this.groupBox1.Controls.Add(this.labCPUType);
      this.groupBox1.Controls.Add(this.labOSBuildNumber);
      this.groupBox1.Controls.Add(this.label12);
      this.groupBox1.Controls.Add(this.labOSMinorVer);
      this.groupBox1.Controls.Add(this.labOSMajorVer);
      this.groupBox1.Controls.Add(this.labOSPlatformID);
      this.groupBox1.Controls.Add(this.labComputerName);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.pictureBox1);
      this.groupBox1.Location = new System.Drawing.Point(7, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(538, 249);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      // 
      // labDiskCSerNum
      // 
      this.labDiskCSerNum.BackColor = System.Drawing.Color.LightGray;
      this.labDiskCSerNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labDiskCSerNum.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labDiskCSerNum.Location = new System.Drawing.Point(201, 207);
      this.labDiskCSerNum.Name = "labDiskCSerNum";
      this.labDiskCSerNum.Size = new System.Drawing.Size(78, 25);
      this.labDiskCSerNum.TabIndex = 18;
      this.labDiskCSerNum.Text = "123456789";
      this.labDiskCSerNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labFixedDrives
      // 
      this.labFixedDrives.BackColor = System.Drawing.Color.LightGray;
      this.labFixedDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labFixedDrives.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labFixedDrives.Location = new System.Drawing.Point(201, 182);
      this.labFixedDrives.Name = "labFixedDrives";
      this.labFixedDrives.Size = new System.Drawing.Size(323, 25);
      this.labFixedDrives.TabIndex = 17;
      this.labFixedDrives.Text = "C:\\; D:\\";
      this.labFixedDrives.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labCPUAmount
      // 
      this.labCPUAmount.BackColor = System.Drawing.Color.LightGray;
      this.labCPUAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labCPUAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labCPUAmount.Location = new System.Drawing.Point(446, 157);
      this.labCPUAmount.Name = "labCPUAmount";
      this.labCPUAmount.Size = new System.Drawing.Size(78, 25);
      this.labCPUAmount.TabIndex = 16;
      this.labCPUAmount.Text = "123";
      this.labCPUAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label15.Location = new System.Drawing.Point(279, 157);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(167, 25);
      this.label15.TabIndex = 15;
      this.label15.Text = "Количество процессоров:";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labCPUType
      // 
      this.labCPUType.BackColor = System.Drawing.Color.LightGray;
      this.labCPUType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labCPUType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labCPUType.Location = new System.Drawing.Point(201, 157);
      this.labCPUType.Name = "labCPUType";
      this.labCPUType.Size = new System.Drawing.Size(78, 25);
      this.labCPUType.TabIndex = 14;
      this.labCPUType.Text = "123";
      this.labCPUType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labOSBuildNumber
      // 
      this.labOSBuildNumber.BackColor = System.Drawing.Color.LightGray;
      this.labOSBuildNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labOSBuildNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labOSBuildNumber.Location = new System.Drawing.Point(446, 132);
      this.labOSBuildNumber.Name = "labOSBuildNumber";
      this.labOSBuildNumber.Size = new System.Drawing.Size(78, 25);
      this.labOSBuildNumber.TabIndex = 13;
      this.labOSBuildNumber.Text = "123";
      this.labOSBuildNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label12.Location = new System.Drawing.Point(357, 132);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(89, 26);
      this.label12.TabIndex = 12;
      this.label12.Text = "Build:";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labOSMinorVer
      // 
      this.labOSMinorVer.BackColor = System.Drawing.Color.LightGray;
      this.labOSMinorVer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labOSMinorVer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labOSMinorVer.Location = new System.Drawing.Point(279, 132);
      this.labOSMinorVer.Name = "labOSMinorVer";
      this.labOSMinorVer.Size = new System.Drawing.Size(78, 25);
      this.labOSMinorVer.TabIndex = 11;
      this.labOSMinorVer.Text = "123";
      this.labOSMinorVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labOSMajorVer
      // 
      this.labOSMajorVer.BackColor = System.Drawing.Color.LightGray;
      this.labOSMajorVer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labOSMajorVer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labOSMajorVer.Location = new System.Drawing.Point(201, 132);
      this.labOSMajorVer.Name = "labOSMajorVer";
      this.labOSMajorVer.Size = new System.Drawing.Size(78, 25);
      this.labOSMajorVer.TabIndex = 10;
      this.labOSMajorVer.Text = "123";
      this.labOSMajorVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labOSPlatformID
      // 
      this.labOSPlatformID.BackColor = System.Drawing.Color.LightGray;
      this.labOSPlatformID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labOSPlatformID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labOSPlatformID.Location = new System.Drawing.Point(201, 107);
      this.labOSPlatformID.Name = "labOSPlatformID";
      this.labOSPlatformID.Size = new System.Drawing.Size(323, 25);
      this.labOSPlatformID.TabIndex = 9;
      this.labOSPlatformID.Text = "Windows 2003";
      this.labOSPlatformID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labComputerName
      // 
      this.labComputerName.BackColor = System.Drawing.Color.LightGray;
      this.labComputerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labComputerName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.labComputerName.Location = new System.Drawing.Point(201, 82);
      this.labComputerName.Name = "labComputerName";
      this.labComputerName.Size = new System.Drawing.Size(323, 25);
      this.labComputerName.TabIndex = 8;
      this.labComputerName.Text = "Quaker";
      this.labComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label7.Location = new System.Drawing.Point(16, 207);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(185, 25);
      this.label7.TabIndex = 7;
      this.label7.Text = "Серийный номер диска C:";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label6.Location = new System.Drawing.Point(16, 182);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(185, 25);
      this.label6.TabIndex = 6;
      this.label6.Text = "Жесткие диски:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label5.Location = new System.Drawing.Point(16, 157);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(185, 25);
      this.label5.TabIndex = 5;
      this.label5.Text = "Тип процессора:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label4.Location = new System.Drawing.Point(16, 132);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(185, 25);
      this.label4.TabIndex = 4;
      this.label4.Text = "Версия ОС:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label3.Location = new System.Drawing.Point(16, 107);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(185, 25);
      this.label3.TabIndex = 3;
      this.label3.Text = "Операционная система:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label2.Location = new System.Drawing.Point(16, 82);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(185, 25);
      this.label2.TabIndex = 2;
      this.label2.Text = "Имя компьютера:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular,
        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
      this.label1.Location = new System.Drawing.Point(184, 35);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(165, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Параметры компьютера";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(15, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(58, 53);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // TfrmRegComputerInfo
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.btnOk;
      this.ClientSize = new System.Drawing.Size(552, 289);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnOk);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TfrmRegComputerInfo";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Компьютер зарегистрирован в базе данных";
      this.Load += new System.EventHandler(this.TfrmRegComputerInfo_Load);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    #endregion

    private void TfrmRegComputerInfo_Load(object sender, EventArgs e)
    {
      string ComputerName;
      int OSMajorVer;
      int OSMinorVer;
      int OSBuildNumber;
      int CPUAmount;
      int CPUType;
      UInt32 DiskCSerNum;
      Int32 OSPlatformId;
      UInt32 FixedDrives;

      Utilities.GetPCData(out ComputerName, out OSPlatformId, out OSMajorVer, out OSMinorVer, out OSBuildNumber,
        out CPUAmount, out CPUType, out FixedDrives, out DiskCSerNum);

      string OSPlatformIdStr, CPUTypeStr, FixedDrivesStr, DiskCSerNumStr;
      Utilities.GetPCDataStr(OSPlatformId, CPUType, FixedDrives, DiskCSerNum,
        out OSPlatformIdStr, out CPUTypeStr, out FixedDrivesStr, out DiskCSerNumStr);

      labComputerName.Text = ComputerName;
      labOSPlatformID.Text = OSPlatformIdStr;
      labOSMajorVer.Text = OSMajorVer.ToString();
      labOSMinorVer.Text = OSMinorVer.ToString();
      labOSBuildNumber.Text = OSBuildNumber.ToString();
      labCPUType.Text = CPUTypeStr;
      labCPUAmount.Text = CPUAmount.ToString();
      labFixedDrives.Text = FixedDrivesStr;
      labDiskCSerNum.Text = DiskCSerNumStr;

      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
    }
  }
}