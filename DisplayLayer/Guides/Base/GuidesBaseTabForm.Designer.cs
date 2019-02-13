namespace ARM_User.DisplayLayer.Guides.Base
{
    partial class GuidesBaseTabForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ts1 = new System.Windows.Forms.TabPage();
            this.ts2 = new System.Windows.Forms.TabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tabControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(522, 333);
            this.panelControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.ts1);
            this.tabControl1.Controls.Add(this.ts2);
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 18);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 327);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // ts1
            // 
            this.ts1.Location = new System.Drawing.Point(4, 4);
            this.ts1.Name = "ts1";
            this.ts1.Padding = new System.Windows.Forms.Padding(3);
            this.ts1.Size = new System.Drawing.Size(506, 301);
            this.ts1.TabIndex = 0;
            this.ts1.Text = "Реквизиты";
            this.ts1.UseVisualStyleBackColor = true;
            // 
            // ts2
            // 
            this.ts2.AutoScroll = true;
            this.ts2.Location = new System.Drawing.Point(4, 4);
            this.ts2.Name = "ts2";
            this.ts2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ts2.Size = new System.Drawing.Size(506, 301);
            this.ts2.TabIndex = 1;
            this.ts2.Text = "Последняя корректировка";
            this.ts2.UseVisualStyleBackColor = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::ARM_User.Properties.Resources.delete2;
            this.simpleButton1.Location = new System.Drawing.Point(459, 351);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Отмена";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::ARM_User.Properties.Resources.check2;
            this.simpleButton2.Location = new System.Drawing.Point(369, 350);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "OK";
            // 
            // GuidesBaseTabForm
            // 
            this.ClientSize = new System.Drawing.Size(539, 388);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.panelControl1);
            this.Name = "GuidesBaseTabForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ts2;
        protected System.Windows.Forms.TabControl tabControl1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton1;
        protected DevExpress.XtraEditors.SimpleButton simpleButton2;
        protected System.Windows.Forms.TabPage ts1;
        protected DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
