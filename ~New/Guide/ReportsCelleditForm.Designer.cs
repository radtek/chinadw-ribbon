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
            DevExpress.Utils.Animation.PushTransition pushTransition2 = new DevExpress.Utils.Animation.PushTransition();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtabSQL = new DevExpress.XtraTab.XtraTabPage();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.xtabText = new DevExpress.XtraTab.XtraTabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.dsMain = new System.Data.DataSet();
            this.dtAutoComplete = new System.Data.DataTable();
            this.cbCheck = new DevExpress.XtraEditors.SimpleButton();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bResult = new DevExpress.XtraBars.BarStaticItem();
            this.bstext = new DevExpress.XtraBars.BarStaticItem();
            this.bstText = new DevExpress.XtraBars.BarStaticItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbOK = new DevExpress.XtraBars.BarButtonItem();
            this.bExecute = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFontStyle1 = new DevExpress.XtraRichEdit.Design.RepositoryItemFontStyle();
            this.autocompleteMenuSQLKeyWords = new AutocompleteMenuNS.AutocompleteMenu();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtAutoComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontStyle1)).BeginInit();
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
            this.btnSave.Location = new System.Drawing.Point(487, 5);
            this.btnSave.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageIndex = 12;
            this.btnCancel.Location = new System.Drawing.Point(378, 7);
            this.btnCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.None;
            this.panel1.Location = new System.Drawing.Point(205, 169);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(345, 38);
            this.panel1.Visible = false;
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
            this.panelControl1.Location = new System.Drawing.Point(0, 37);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.panelControl1.Size = new System.Drawing.Size(856, 327);
            this.panelControl1.Controls.SetChildIndex(this.panel1, 0);
            this.panelControl1.Controls.SetChildIndex(this.xtraTabControl1, 0);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbOK,
            this.bExecute,
            this.barStaticItem1,
            this.bResult,
            this.barEditItem2,
            this.barButtonItem1,
            this.barButtonItem3,
            this.bstext,
            this.bstText,
            this.barWorkspaceMenuItem1});
            this.barManager1.MaxItemId = 21;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1,
            this.repositoryItemFontStyle1});
            this.barManager1.StatusBar = this.bar1;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtabSQL;
            this.xtraTabControl1.Size = new System.Drawing.Size(852, 323);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabText,
            this.xtabSQL});
            // 
            // xtabSQL
            // 
            this.xtabSQL.Controls.Add(this.rtbSQL);
            this.xtabSQL.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtabSQL.ImageOptions.Image")));
            this.xtabSQL.Name = "xtabSQL";
            this.xtabSQL.Size = new System.Drawing.Size(845, 273);
            this.xtabSQL.Text = "SQL";
            // 
            // rtbSQL
            // 
            this.autocompleteMenuSQLKeyWords.SetAutocompleteMenu(this.rtbSQL, this.autocompleteMenuSQLKeyWords);
            this.rtbSQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQL.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rtbSQL.Location = new System.Drawing.Point(0, 0);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbSQL.Size = new System.Drawing.Size(845, 273);
            this.rtbSQL.TabIndex = 2;
            this.rtbSQL.Text = "";
            this.rtbSQL.TextChanged += new System.EventHandler(this.rtbSQL_TextChanged);
            this.rtbSQL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbSQL_MouseDown);
            // 
            // xtabText
            // 
            this.xtabText.Controls.Add(this.rtbText);
            this.xtabText.Name = "xtabText";
            this.xtabText.Size = new System.Drawing.Size(550, 461);
            this.xtabText.Text = "Text";
            // 
            // rtbText
            // 
            this.autocompleteMenuSQLKeyWords.SetAutocompleteMenu(this.rtbText, null);
            this.rtbText.BackColor = System.Drawing.SystemColors.Control;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(550, 461);
            this.rtbText.TabIndex = 1;
            this.rtbText.Text = "";
            this.rtbText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbText_KeyPress);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.dtAutoComplete});
            // 
            // dtAutoComplete
            // 
            this.dtAutoComplete.TableName = "tbAutoComplete";
            // 
            // cbCheck
            // 
            this.cbCheck.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cbCheck.ImageOptions.Image")));
            this.cbCheck.Location = new System.Drawing.Point(241, 9);
            this.cbCheck.Name = "cbCheck";
            this.cbCheck.Size = new System.Drawing.Size(96, 29);
            this.cbCheck.TabIndex = 4;
            this.cbCheck.Text = "Проверить";
            this.cbCheck.Click += new System.EventHandler(this.cbCheck_CheckedChanged);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barStaticItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bResult),
            new DevExpress.XtraBars.LinkPersistInfo(this.bstext, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "df";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Result:";
            this.barStaticItem1.Id = 12;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // bResult
            // 
            this.bResult.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.bResult.Id = 13;
            this.bResult.Name = "bResult";
            // 
            // bstext
            // 
            this.bstext.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bstext.Id = 18;
            this.bstext.Name = "bstext";
            // 
            // bstText
            // 
            this.bstText.Caption = "barStaticItem2";
            this.bstText.Id = 19;
            this.bstText.Name = "bstText";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbOK, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bExecute, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.Text = "Custom 3";
            // 
            // bbOK
            // 
            this.bbOK.Caption = "Сохранить";
            this.bbOK.Id = 10;
            this.bbOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbOK.ImageOptions.Image")));
            this.bbOK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbOK.ImageOptions.LargeImage")));
            this.bbOK.Name = "bbOK";
            this.bbOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbOK_ItemClick);
            // 
            // bExecute
            // 
            this.bExecute.Caption = "Выполнить";
            this.bExecute.Id = 11;
            this.bExecute.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bExecute.ImageOptions.Image")));
            this.bExecute.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bExecute.ImageOptions.LargeImage")));
            this.bExecute.Name = "bExecute";
            this.bExecute.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Проверка";
            this.barButtonItem1.Id = 16;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemFontStyle1;
            this.barEditItem2.Id = 15;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemFontStyle1
            // 
            this.repositoryItemFontStyle1.AutoHeight = false;
            this.repositoryItemFontStyle1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontStyle1.Name = "repositoryItemFontStyle1";
            // 
            // autocompleteMenuSQLKeyWords
            // 
            this.autocompleteMenuSQLKeyWords.CaptureFocus = true;
            this.autocompleteMenuSQLKeyWords.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenuSQLKeyWords.Colors")));
            this.autocompleteMenuSQLKeyWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenuSQLKeyWords.ImageList = null;
            this.autocompleteMenuSQLKeyWords.Items = new string[] {
        "SELECT",
        "FROM",
        "WHERE",
        "AND",
        "OR",
        "NVL",
        "XOR"};
            this.autocompleteMenuSQLKeyWords.TargetControlWrapper = null;
            this.autocompleteMenuSQLKeyWords.ToolTipDuration = 1000;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 5;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // barWorkspaceMenuItem1
            // 
            this.barWorkspaceMenuItem1.Caption = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.Id = 20;
            this.barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.WorkspaceManager = this.workspaceManager1;
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition2;
            // 
            // ReportsCelleditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(856, 399);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 11, 7, 11);
            this.Name = "ReportsCelleditForm";
            this.Text = "Редакирование ячейки";
            this.Load += new System.EventHandler(this.DialogHTMLCelleditForm_Load);
            this.Resize += new System.EventHandler(this.ReportsCelleditForm_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtAutoComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontStyle1)).EndInit();
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
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbOK;
        private DevExpress.XtraBars.BarButtonItem bExecute;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem bResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraRichEdit.Design.RepositoryItemFontStyle repositoryItemFontStyle1;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenuSQLKeyWords;
        private System.Data.DataTable dtAutoComplete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraBars.BarStaticItem bstext;
        private DevExpress.XtraBars.BarStaticItem bstText;
        private DevExpress.XtraBars.BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
    }
}
