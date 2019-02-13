namespace ARM_User.DisplayLayer.Service
{
  partial class ChooseRepRegionPeriodDenialForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRepRegionPeriodDenialForm));
        this.edDateBegin = new DevExpress.XtraEditors.DateEdit();
        this.label1 = new System.Windows.Forms.Label();
        this.edDateEnd = new DevExpress.XtraEditors.DateEdit();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.cbTypeSecurities = new DevExpress.XtraEditors.ComboBoxEdit();
        this.luRegion = new DevExpress.XtraEditors.LookUpEdit();
        this.label5 = new System.Windows.Forms.Label();
        this.luUsers = new DevExpress.XtraEditors.LookUpEdit();
        this.executorDS = new ARM_User.DataLayer.DataSet.GuidesDataSet.ExecutorDS();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
        this.panelControlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).BeginInit();
        this.panelControlButtonsRight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
        this.panelControl1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties.VistaTimeProperties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties.VistaTimeProperties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeSecurities.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsers.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.executorDS)).BeginInit();
        this.SuspendLayout();
        // 
        // panelControlButtons
        // 
        this.panelControlButtons.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtons.Appearance.Options.UseBackColor = true;
        this.panelControlButtons.Location = new System.Drawing.Point(0, 164);
        this.panelControlButtons.Size = new System.Drawing.Size(606, 38);
        // 
        // panelControlButtonsRight
        // 
        this.panelControlButtonsRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
        this.panelControlButtonsRight.Appearance.Options.UseBackColor = true;
        this.panelControlButtonsRight.Location = new System.Drawing.Point(368, 2);
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
        this.panelControl1.Controls.Add(this.luUsers);
        this.panelControl1.Controls.Add(this.label5);
        this.panelControl1.Controls.Add(this.luRegion);
        this.panelControl1.Controls.Add(this.cbTypeSecurities);
        this.panelControl1.Controls.Add(this.label4);
        this.panelControl1.Controls.Add(this.label3);
        this.panelControl1.Controls.Add(this.label2);
        this.panelControl1.Controls.Add(this.edDateEnd);
        this.panelControl1.Controls.Add(this.label1);
        this.panelControl1.Controls.Add(this.edDateBegin);
        this.panelControl1.Size = new System.Drawing.Size(606, 202);
        // 
        // edDateBegin
        // 
        this.edDateBegin.EditValue = null;
        this.edDateBegin.Location = new System.Drawing.Point(119, 7);
        this.edDateBegin.MaximumSize = new System.Drawing.Size(140, 0);
        this.edDateBegin.MinimumSize = new System.Drawing.Size(140, 0);
        this.edDateBegin.Name = "edDateBegin";
        this.edDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.edDateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
        this.edDateBegin.Size = new System.Drawing.Size(140, 20);
        this.edDateBegin.TabIndex = 20;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label1.Location = new System.Drawing.Point(5, 10);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(112, 13);
        this.label1.TabIndex = 21;
        this.label1.Text = "Дата с";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // edDateEnd
        // 
        this.edDateEnd.EditValue = null;
        this.edDateEnd.Location = new System.Drawing.Point(346, 7);
        this.edDateEnd.MaximumSize = new System.Drawing.Size(140, 0);
        this.edDateEnd.MinimumSize = new System.Drawing.Size(140, 0);
        this.edDateEnd.Name = "edDateEnd";
        this.edDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.edDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
        this.edDateEnd.Size = new System.Drawing.Size(140, 20);
        this.edDateEnd.TabIndex = 22;
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label2.Location = new System.Drawing.Point(264, 10);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(80, 13);
        this.label2.TabIndex = 23;
        this.label2.Text = "по";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label3
        // 
        this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label3.Location = new System.Drawing.Point(6, 45);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(112, 13);
        this.label3.TabIndex = 67;
        this.label3.Text = "Область";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label4
        // 
        this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label4.Location = new System.Drawing.Point(6, 115);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(112, 13);
        this.label4.TabIndex = 225;
        this.label4.Text = "Вид ЦБ";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cbTypeSecurities
        // 
        this.cbTypeSecurities.EditValue = "Все";
        this.cbTypeSecurities.Location = new System.Drawing.Point(119, 112);
        this.cbTypeSecurities.Name = "cbTypeSecurities";
        this.cbTypeSecurities.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbTypeSecurities.Properties.Items.AddRange(new object[] {
            "Все",
            "Акции",
            "Облигации",
            "Паи",
            "КДР",
            "ИЦБ"});
        this.cbTypeSecurities.Size = new System.Drawing.Size(270, 20);
        this.cbTypeSecurities.TabIndex = 414;
        this.cbTypeSecurities.EditValueChanged += new System.EventHandler(this.cbTypeReport_EditValueChanged);
        // 
        // luRegion
        // 
        this.luRegion.Location = new System.Drawing.Point(119, 42);
        this.luRegion.Name = "luRegion";
        this.luRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nameru", "Name1")});
        this.luRegion.Properties.DisplayMember = "Nameru";
        this.luRegion.Properties.NullText = "Все";
        this.luRegion.Properties.ShowHeader = false;
        this.luRegion.Properties.ValueMember = "Id";
        this.luRegion.Size = new System.Drawing.Size(270, 20);
        this.luRegion.TabIndex = 415;
        this.luRegion.EditValueChanged += new System.EventHandler(this.luRegion_EditValueChanged);
        // 
        // label5
        // 
        this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.label5.Location = new System.Drawing.Point(6, 79);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(112, 13);
        this.label5.TabIndex = 416;
        this.label5.Text = "Исполнитель";
        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // luUsers
        // 
        this.luUsers.Location = new System.Drawing.Point(119, 76);
        this.luUsers.Name = "luUsers";
        this.luUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.luUsers.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SignatureFNF", "Name1")});
        this.luUsers.Properties.DisplayMember = "SignatureFNF";
        this.luUsers.Properties.NullText = "Все";
        this.luUsers.Properties.ShowHeader = false;
        this.luUsers.Properties.ValueMember = "Id";
        this.luUsers.Size = new System.Drawing.Size(270, 20);
        this.luUsers.TabIndex = 417;
        this.luUsers.EditValueChanged += new System.EventHandler(this.luUsers_EditValueChanged);
        // 
        // executorDS
        // 
        this.executorDS.DataSetName = "ExecutorDS";
        this.executorDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // ChooseRepRegionPeriodDenialForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(606, 202);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "ChooseRepRegionPeriodDenialForm";
        this.Text = "Выберите ";
        this.Load += new System.EventHandler(this.ChooseRepRegionPeriodDenialForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
        this.panelControlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControlButtonsRight)).EndInit();
        this.panelControlButtonsRight.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
        this.panelControl1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties.VistaTimeProperties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateBegin.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties.VistaTimeProperties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edDateEnd.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.cbTypeSecurities.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luRegion.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.luUsers.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.executorDS)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.DateEdit edDateBegin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    protected DevExpress.XtraEditors.DateEdit edDateEnd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private DevExpress.XtraEditors.ComboBoxEdit cbTypeSecurities;
    private DevExpress.XtraEditors.LookUpEdit luRegion;
    private DevExpress.XtraEditors.LookUpEdit luUsers;
    private System.Windows.Forms.Label label5;
    private DataLayer.DataSet.GuidesDataSet.ExecutorDS executorDS;
   
  }
}
