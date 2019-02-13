namespace ARM_User.DisplayLayer.Popup
{
    partial class PopupRegOrganMuListForm
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
            this.treeListNAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(268, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(0, 367);
            this.panelControl1.Size = new System.Drawing.Size(468, 41);
            // 
            // treeMain
            // 
            this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListNAME});
            this.treeMain.KeyFieldName = "ID";
            this.treeMain.OptionsBehavior.Editable = false;
            this.treeMain.OptionsFind.AllowFindPanel = true;
            this.treeMain.ParentFieldName = "S_G_CLASSIFIER_OKED_PARENT";
            this.treeMain.Size = new System.Drawing.Size(468, 367);
            // 
            // treeListNAME
            // 
            this.treeListNAME.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListNAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListNAME.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.treeListNAME.Caption = "Наименование";
            this.treeListNAME.FieldName = "NAME";
            this.treeListNAME.Name = "treeListNAME";
            this.treeListNAME.Visible = true;
            this.treeListNAME.VisibleIndex = 0;
            // 
            // PopupRegOrganMuListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(468, 408);
            this.Name = "PopupRegOrganMuListForm";
            this.Text = "Вид деятельности по ОКЭД";
            this.Load += new System.EventHandler(this.PopupRegOrganMuListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListNAME;
    }
}
