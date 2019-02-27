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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsCelleditForm));
            this.virtualServerModeSource1 = new DevExpress.Data.VirtualServerModeSource(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(191, 5);
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
            this.btnCancel.Location = new System.Drawing.Point(282, 5);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkButton1);
            this.panel1.Location = new System.Drawing.Point(2, 141);
            this.panel1.Size = new System.Drawing.Size(381, 31);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.Controls.SetChildIndex(this.checkButton1, 0);
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
            this.panelControl1.Size = new System.Drawing.Size(385, 174);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.xtraTabControl1, 0);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(381, 139);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.richTextBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(375, 111);
            this.xtraTabPage1.Text = "Text";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(375, 111);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // checkButton1
            // 
            this.checkButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("checkButton1.ImageOptions.Image")));
            this.checkButton1.Location = new System.Drawing.Point(22, 5);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(89, 23);
            this.checkButton1.TabIndex = 3;
            this.checkButton1.Text = "Проверить";
            // 
            // DialogHTMLCelleditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(385, 174);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogHTMLCelleditForm";
            this.Text = "Редакирование ячейки";
            this.Load += new System.EventHandler(this.DialogHTMLCelleditForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.virtualServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Data.VirtualServerModeSource virtualServerModeSource1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.CheckButton checkButton1;
    }
}
