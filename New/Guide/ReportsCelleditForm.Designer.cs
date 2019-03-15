namespace ARM_User.New.Guide
{
    partial class ReportsCelleditForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsCelleditForm));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtabSQL = new DevExpress.XtraTab.XtraTabPage();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.xtabText = new DevExpress.XtraTab.XtraTabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.dsMain = new System.Data.DataSet();
            this.cbCheck = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtabSQL.SuspendLayout();
            this.xtabText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageIndex = 12;
            this.btnSave.Location = new System.Drawing.Point(368, 5);
            this.btnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 12;
            this.btnCancel.Location = new System.Drawing.Point(459, 5);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCheck);
            this.panel1.Location = new System.Drawing.Point(2, 286);
            this.panel1.Size = new System.Drawing.Size(548, 31);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.Controls.SetChildIndex(this.cbCheck, 0);
            // 
            // barButtonItemBeginEdit
            // 
            this.barButtonItemBeginEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemBeginEdit.ImageOptions.Image")));
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
            // 
            // barButtonItemCancelEdit
            // 
            this.barButtonItemCancelEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemCancelEdit.ImageOptions.Image")));
            // 
            // barButtonItemRefresh
            // 
            this.barButtonItemRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemRefresh.ImageOptions.Image")));
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Size = new System.Drawing.Size(552, 319);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.xtraTabControl1, 0);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtabSQL;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(548, 284);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabText,
            this.xtabSQL});
            // 
            // xtabSQL
            // 
            this.xtabSQL.Controls.Add(this.rtbSQL);
            this.xtabSQL.Name = "xtabSQL";
            this.xtabSQL.Size = new System.Drawing.Size(546, 282);
            this.xtabSQL.Text = "SQL";
            // 
            // rtbSQL
            // 
            this.rtbSQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQL.Location = new System.Drawing.Point(0, 0);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbSQL.Size = new System.Drawing.Size(546, 282);
            this.rtbSQL.TabIndex = 2;
            this.rtbSQL.Text = "";
            // 
            // xtabText
            // 
            this.xtabText.Controls.Add(this.rtbText);
            this.xtabText.Name = "xtabText";
            this.xtabText.PageVisible = false;
            this.xtabText.Size = new System.Drawing.Size(471, 377);
            this.xtabText.Text = "Text";
            // 
            // rtbText
            // 
            this.rtbText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbText.Size = new System.Drawing.Size(471, 377);
            this.rtbText.TabIndex = 1;
            this.rtbText.Text = "";
            this.rtbText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbText_KeyPress);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            // 
            // cbCheck
            // 
            this.cbCheck.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cbCheck.ImageOptions.Image")));
            this.cbCheck.Location = new System.Drawing.Point(10, 5);
            this.cbCheck.Name = "cbCheck";
            this.cbCheck.Size = new System.Drawing.Size(83, 23);
            this.cbCheck.TabIndex = 4;
            this.cbCheck.Text = "Проверить";
            this.cbCheck.Click += new System.EventHandler(this.cbCheck_CheckedChanged);
            // 
            // ReportsCelleditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(552, 319);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsCelleditForm";
            this.Text = "Редакирование ячейки";
            this.Load += new System.EventHandler(this.DialogHTMLCelleditForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtabSQL.ResumeLayout(false);
            this.xtabText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtabText;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Data.DataSet dsMain;
        private DevExpress.XtraEditors.SimpleButton cbCheck;
        private DevExpress.XtraTab.XtraTabPage xtabSQL;
        private System.Windows.Forms.RichTextBox rtbSQL;
    }
}
