namespace ARM_User
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtabSQL = new DevExpress.XtraTab.XtraTabPage();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.xtabText = new DevExpress.XtraTab.XtraTabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtabSQL.SuspendLayout();
            this.xtabText.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(152, 115);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtabSQL;
            this.xtraTabControl1.Size = new System.Drawing.Size(497, 220);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabText,
            this.xtabSQL});
            // 
            // xtabSQL
            // 
            this.xtabSQL.Controls.Add(this.rtbSQL);
            this.xtabSQL.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtabSQL.ImageOptions.Image")));
            this.xtabSQL.Name = "xtabSQL";
            this.xtabSQL.Size = new System.Drawing.Size(490, 170);
            this.xtabSQL.Text = "SQL";
            // 
            // rtbSQL
            // 
            this.rtbSQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQL.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rtbSQL.Location = new System.Drawing.Point(0, 0);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbSQL.Size = new System.Drawing.Size(490, 170);
            this.rtbSQL.TabIndex = 2;
            this.rtbSQL.Text = "";
            // 
            // xtabText
            // 
            this.xtabText.Controls.Add(this.rtbText);
            this.xtabText.Name = "xtabText";
            this.xtabText.Size = new System.Drawing.Size(490, 170);
            this.xtabText.Text = "Text";
            // 
            // rtbText
            // 
            this.rtbText.BackColor = System.Drawing.SystemColors.Control;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(490, 170);
            this.rtbText.TabIndex = 1;
            this.rtbText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtabSQL.ResumeLayout(false);
            this.xtabText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtabSQL;
        private System.Windows.Forms.RichTextBox rtbSQL;
        private DevExpress.XtraTab.XtraTabPage xtabText;
        private System.Windows.Forms.RichTextBox rtbText;
    }
}