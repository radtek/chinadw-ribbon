namespace ARM_User.DisplayLayer.Guides.Base
{
    partial class ChinaSimpleEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChinaSimpleEditForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btGuides = new DevExpress.XtraEditors.SimpleButton();
            this.repFormDS1 = new ARM_User.DataLayer.DataSet.GuidesDataSet.RepFormDS();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFormDS1)).BeginInit();
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
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(2, 391);
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
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.btGuides);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Size = new System.Drawing.Size(481, 424);
            this.panelControl1.Controls.SetChildIndex(this.groupControl1, 0);
            this.panelControl1.Controls.SetChildIndex(this.groupControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.btGuides, 0);
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(477, 141);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "group 1";
            // 
            // groupControl2
            // 
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 143);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(477, 213);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "group 2";
            // 
            // btGuides
            // 
            this.btGuides.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btGuides.ImageOptions.Image")));
            this.btGuides.Location = new System.Drawing.Point(370, 362);
            this.btGuides.Name = "btGuides";
            this.btGuides.Size = new System.Drawing.Size(106, 23);
            this.btGuides.TabIndex = 10;
            this.btGuides.Text = "Справочники";
            this.btGuides.Click += new System.EventHandler(this.btGuides_Click);
            // 
            // repFormDS1
            // 
            this.repFormDS1.DataSetName = "RepFormDS";
            this.repFormDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ChinaSimpleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(481, 424);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChinaSimpleEditForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repFormDS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.GroupControl groupControl2;
        public DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.SimpleButton btGuides;
        private DataLayer.DataSet.GuidesDataSet.RepFormDS repFormDS1;
    }
}
