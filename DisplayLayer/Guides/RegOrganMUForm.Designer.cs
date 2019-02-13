namespace ARM_User.DisplayLayer.Guides
{
    partial class RegOrganMUForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegOrganMUForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.edName = new DevExpress.XtraEditors.TextEdit();
            this.edParentName = new DevExpress.XtraEditors.ButtonEdit();
            this.cBoxTypeElement = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbDel = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBoxTypeElement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(419, 4);
            this.btnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(510, 4);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 161);
            this.panel1.Size = new System.Drawing.Size(605, 31);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Size = new System.Drawing.Size(609, 194);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.layoutControl1, 0);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbDel);
            this.layoutControl1.Controls.Add(this.edName);
            this.layoutControl1.Controls.Add(this.edParentName);
            this.layoutControl1.Controls.Add(this.cBoxTypeElement);
            this.layoutControl1.Location = new System.Drawing.Point(8, 7);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(600, 120);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(159, 60);
            this.edName.MenuManager = this.barManager1;
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(429, 20);
            this.edName.StyleController = this.layoutControl1;
            this.edName.TabIndex = 6;
            // 
            // edParentName
            // 
            this.edParentName.Location = new System.Drawing.Point(159, 36);
            this.edParentName.MenuManager = this.barManager1;
            this.edParentName.Name = "edParentName";
            this.edParentName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edParentName.Size = new System.Drawing.Size(429, 20);
            this.edParentName.StyleController = this.layoutControl1;
            this.edParentName.TabIndex = 5;
            this.edParentName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // cBoxTypeElement
            // 
            this.cBoxTypeElement.Location = new System.Drawing.Point(159, 12);
            this.cBoxTypeElement.MenuManager = this.barManager1;
            this.cBoxTypeElement.Name = "cBoxTypeElement";
            this.cBoxTypeElement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBoxTypeElement.Properties.Items.AddRange(new object[] {
            "Запись",
            "Группа"});
            this.cBoxTypeElement.Size = new System.Drawing.Size(429, 20);
            this.cBoxTypeElement.StyleController = this.layoutControl1;
            this.cBoxTypeElement.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(600, 120);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cBoxTypeElement;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(580, 24);
            this.layoutControlItem1.Text = "Тип элемента";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(144, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.edParentName;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(580, 24);
            this.layoutControlItem2.Text = "Выбор родительской записи";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(144, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.edName;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(580, 24);
            this.layoutControlItem3.Text = "Наименование";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(144, 13);
            // 
            // cbDel
            // 
            this.cbDel.Location = new System.Drawing.Point(12, 84);
            this.cbDel.MenuManager = this.barManager1;
            this.cbDel.Name = "cbDel";
            this.cbDel.Properties.Caption = "Признак \"Удален\"";
            this.cbDel.Size = new System.Drawing.Size(576, 19);
            this.cbDel.StyleController = this.layoutControl1;
            this.cbDel.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbDel;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(580, 28);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // RegOrganMUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(609, 194);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegOrganMUForm";
            this.Text = "Просмотр реквизитов справочника \"Регистрирующий орган МЮ\"";
            this.Load += new System.EventHandler(this.RegOrganMUForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBoxTypeElement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit edName;
        private DevExpress.XtraEditors.ButtonEdit edParentName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit cBoxTypeElement;
        private DevExpress.XtraEditors.CheckEdit cbDel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
