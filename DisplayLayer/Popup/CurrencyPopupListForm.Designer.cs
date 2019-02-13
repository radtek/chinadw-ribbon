namespace ARM_User.DisplayLayer.Guides.PopupList
{
    partial class CurrencyPopupListForm
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
            this.gridNameru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.Size = new System.Drawing.Size(466, 199);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridId,
            this.gridCode,
            this.gridNameru});
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(0, 199);
            // 
            // gridNameru
            // 
            this.gridNameru.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNameru.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNameru.Caption = "Наименование (рус)";
            this.gridNameru.FieldName = "Nameru";
            this.gridNameru.Name = "gridNameru";
            this.gridNameru.Visible = true;
            this.gridNameru.VisibleIndex = 1;
            this.gridNameru.Width = 365;
            // 
            // gridCode
            // 
            this.gridCode.AppearanceCell.Options.UseTextOptions = true;
            this.gridCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCode.Caption = "Код";
            this.gridCode.FieldName = "Code";
            this.gridCode.Name = "gridCode";
            this.gridCode.Visible = true;
            this.gridCode.VisibleIndex = 0;
            this.gridCode.Width = 83;
            // 
            // gridId
            // 
            this.gridId.Caption = "ID";
            this.gridId.FieldName = "Id";
            this.gridId.Name = "gridId";
            // 
            // CurrencyPopupListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(466, 240);
            this.Name = "CurrencyPopupListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Валюта";
            this.Load += new System.EventHandler(this.CurrencyPopupListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridNameru;
        private DevExpress.XtraGrid.Columns.GridColumn gridId;
    }
}
