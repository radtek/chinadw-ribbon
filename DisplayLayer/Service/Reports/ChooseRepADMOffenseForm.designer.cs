namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepADMOffenseForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepADMOffenseForm));
        this.edDt1 = new DevExpress.XtraEditors.DateEdit();
        this.label1 = new System.Windows.Forms.Label();
        this.edDt2 = new DevExpress.XtraEditors.DateEdit();
        this.label2 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.cbTypeSecurities = new DevExpress.XtraEditors.ComboBoxEdit();
        this.label5 = new System.Windows.Forms.Label();
        this.luUsers = new DevExpress.XtraEditors.LookUpEdit();
        this.executorDS = new ARM_User.DataLayer.DataSet.GuidesDataSet.ExecutorDS();
        this.label6 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.luKndSanc = new DevExpress.XtraEditors.LookUpEdit();
        this.luKoAP = new DevExpress.XtraEditors.LookUpEdit();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
        this.panelControlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
        this.panelControlButtonsRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.edDt1.Properties.VistaTimeProperties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt1.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt2.Properties.VistaTimeProperties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt2.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeSecurities.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsers.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.executorDS)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luKndSanc.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luKoAP.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControlButtons
        // 
        this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtons.Appearance.Options.UseBackColor = true;
        this.panelControlButtons.Location = new System.Drawing.Point(0, 157);
        this.panelControlButtons.Size = new System.Drawing.Size(425, 38);
        // 
        // panelControlButtonsRight
        // 
        this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
        this.panelControlButtonsRight.Location = new System.Drawing.Point(187, 2);
        this.panelControlButtonsRight.Size = new System.Drawing.Size(236, 34);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(129, 5);
        this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        // 
        // btnOk
        // 
        this.btnOk.Location = new System.Drawing.Point(23, 5);
        this.btnOk.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
        this.btnOk.Text = "ОK";
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        // 
        // panelControl1
        // 
        this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControl1.Appearance.Options.UseBackColor = true;
        this.panelControl1.Controls.Add(this.luKoAP);
        this.panelControl1.Controls.Add(this.luKndSanc);
        this.panelControl1.Controls.Add(this.label8);
        this.panelControl1.Controls.Add(this.label6);
        this.panelControl1.Controls.Add(this.luUsers);
        this.panelControl1.Controls.Add(this.label5);
        this.panelControl1.Controls.Add(this.cbTypeSecurities);
        this.panelControl1.Controls.Add(this.label4);
        this.panelControl1.Controls.Add(this.label2);
        this.panelControl1.Controls.Add(this.edDt2);
        this.panelControl1.Controls.Add(this.label1);
        this.panelControl1.Controls.Add(this.edDt1);
        this.panelControl1.Size = new System.Drawing.Size(425, 195);
        // 
        // edDt1
        // 
        this.edDt1.EditValue = null;
        this.edDt1.Location = new System.Drawing.Point(188, 12);
        this.edDt1.MaximumSize = new System.Drawing.Size(140, 0);
        this.edDt1.MinimumSize = new System.Drawing.Size(140, 0);
        this.edDt1.Name = "edDt1";
        this.edDt1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.edDt1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
        this.edDt1.Size = new System.Drawing.Size(140, 20);
        this.edDt1.TabIndex = 20;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.Location = new System.Drawing.Point(15, 14);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(170, 13);
        this.label1.TabIndex = 21;
        this.label1.Text = "Период применения с";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // edDt2
        // 
        this.edDt2.EditValue = null;
        this.edDt2.Location = new System.Drawing.Point(188, 33);
        this.edDt2.MaximumSize = new System.Drawing.Size(140, 0);
        this.edDt2.MinimumSize = new System.Drawing.Size(140, 0);
        this.edDt2.Name = "edDt2";
        this.edDt2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.edDt2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
        this.edDt2.Size = new System.Drawing.Size(140, 20);
        this.edDt2.TabIndex = 22;
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label2.Location = new System.Drawing.Point(54, 36);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(131, 13);
        this.label2.TabIndex = 23;
        this.label2.Text = "по";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label4.Location = new System.Drawing.Point(16, 119);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(170, 13);
        this.label4.TabIndex = 225;
        this.label4.Text = "Статус исполнения";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cbTypeSecurities
        // 
        this.cbTypeSecurities.EditValue = "Все";
        this.cbTypeSecurities.Location = new System.Drawing.Point(188, 117);
        this.cbTypeSecurities.Name = "cbTypeSecurities";
        this.cbTypeSecurities.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbTypeSecurities.Properties.Items.AddRange(new object[] {
            "Все",
            "исполнено",
            "не исполнено"});
        this.cbTypeSecurities.Size = new System.Drawing.Size(140, 20);
        this.cbTypeSecurities.TabIndex = 414;
        this.cbTypeSecurities.EditValueChanged += new System.EventHandler(this.cbTypeReport_EditValueChanged);
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label5.Location = new System.Drawing.Point(67, 99);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(120, 13);
        this.label5.TabIndex = 416;
        this.label5.Text = "Исполнитель";
        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // luUsers
        // 
        this.luUsers.Location = new System.Drawing.Point(188, 96);
        this.luUsers.Name = "luUsers";
        this.luUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luUsers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SignatureFNF", "Name1")});
        this.luUsers.Properties.DisplayMember = "SignatureFNF";
        this.luUsers.Properties.NullText = "Все";
        this.luUsers.Properties.ShowHeader = false;
        this.luUsers.Properties.ValueMember = "Id";
        this.luUsers.Size = new System.Drawing.Size(140, 20);
        this.luUsers.TabIndex = 417;
        this.luUsers.EditValueChanged += new System.EventHandler(this.luUsers_EditValueChanged);
        // 
        // executorDS
        // 
        this.executorDS.DataSetName = "ExecutorDS";
        this.executorDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // label6
        // 
        this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label6.Location = new System.Drawing.Point(67, 56);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(120, 13);
        this.label6.TabIndex = 418;
        this.label6.Text = "Вид санкций ";
        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label8
        // 
        this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label8.Location = new System.Drawing.Point(57, 78);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(130, 13);
        this.label8.TabIndex = 422;
        this.label8.Text = "Статья КоАП ";
        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // luKndSanc
        // 
        this.luKndSanc.Location = new System.Drawing.Point(188, 54);
        this.luKndSanc.Name = "luKndSanc";
        this.luKndSanc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luKndSanc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "Name1")});
        this.luKndSanc.Properties.DisplayMember = "NameRu";
        this.luKndSanc.Properties.NullText = "Все";
        this.luKndSanc.Properties.ShowHeader = false;
        this.luKndSanc.Properties.ValueMember = "Id";
        this.luKndSanc.Size = new System.Drawing.Size(140, 20);
        this.luKndSanc.TabIndex = 426;
        this.luKndSanc.EditValueChanged += new System.EventHandler(this.luKndSanc_EditValueChanged);
        // 
        // luKoAP
        // 
        this.luKoAP.Location = new System.Drawing.Point(188, 75);
        this.luKoAP.Name = "luKoAP";
        this.luKoAP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luKoAP.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameRu", "Name1")});
        this.luKoAP.Properties.DisplayMember = "NameRu";
        this.luKoAP.Properties.NullText = "Все";
        this.luKoAP.Properties.ShowHeader = false;
        this.luKoAP.Properties.ValueMember = "Id";
        this.luKoAP.Size = new System.Drawing.Size(140, 20);
        this.luKoAP.TabIndex = 427;
        this.luKoAP.EditValueChanged += new System.EventHandler(this.luKoAP_EditValueChanged);
        // 
        // ChooseRepADMOffenseForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(425, 195);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ChooseRepADMOffenseForm";
        this.Text = "Фильтр";
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
        this.panelControlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
        this.panelControlButtonsRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.edDt1.Properties.VistaTimeProperties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt1.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt2.Properties.VistaTimeProperties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDt2.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeSecurities.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsers.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.executorDS)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luKndSanc.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luKoAP.Properties)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.DateEdit edDt1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    protected DevExpress.XtraEditors.DateEdit edDt2;
    private System.Windows.Forms.Label label4;
    private DevExpress.XtraEditors.ComboBoxEdit cbTypeSecurities;
    private DevExpress.XtraEditors.LookUpEdit luUsers;
    private System.Windows.Forms.Label label5;
    private DataLayer.DataSet.GuidesDataSet.ExecutorDS executorDS;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label8;
    private DevExpress.XtraEditors.LookUpEdit luKndSanc;
    private DevExpress.XtraEditors.LookUpEdit luKoAP;
   
  }
}
