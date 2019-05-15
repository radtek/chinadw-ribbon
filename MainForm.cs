using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.DisplayLayer.Guides;
using BSB.Actions;
using BSB.Common;
using BSB.Common.DB;
using BSB.Common.DB.Admin;
using BSB.Win32API;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Oracle.ManagedDataAccess.Client;
using Timer = System.Timers.Timer;
using ARM_User.DisplayLayer.Service;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BSB.Common.DataGateway.Oracle;
using Oracle.ManagedDataAccess.Types;
using ARM_User.New.Guide;
using ARM_User.Properties;
using DevExpress.XtraBars.Ribbon;

namespace ARM_User
{
    /// <summary>
    ///   Summary description for Form1.
    /// </summary>
    public class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Windows Form Designer generated code
        public Boolean create = false;
        public decimal count;
        public Boolean iconnectlang = false;
        public Timer tmCheckGovSec;
        public Boolean kazlang = false;
        private MyAction aExtraPokaz;
        private MyAction aClients;
        private MyAction aCredits;
        private MyAction aRepList;
        private MyAction aCalendarsOperationDays;
        private MyAction aExportRep;
        private BackgroundWorker backgroundWorker1;
        private MyAction aPledges;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDataBase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpWindow;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpCustomize;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private AutoHideContainer hideContainerLeft;
        private BarButtonItem iConnect;
        private BarButtonItem iLockApplication;
        private BarButtonItem iDisconnect;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpView;
        private BarButtonItem iRefresh;
        private BarButtonItem iChangePassword;
        private BarButtonItem iExit;
        private BarButtonItem barButtonItemMenuPanel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private BarButtonItem barButtonItemMsgPanel;
        private BarButtonItem iPaintStyle;
        private BarButtonItem iTileVertical;
        private BarButtonItem iCloseAllWindows;
        private BarButtonItem barButtonItem17;
        private StyleController styleController1;
        private PopupMenu popupMenu1;
        private SkinDropDownButtonItem skinDropDownButtonItem1;
        private SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private SkinRibbonGalleryBarItem skinRibbonGalleryBarItem2;
        private SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private BarDockingMenuItem barDockingMenuItem1;
        private BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private WorkspaceManager workspaceManager1;
        private BarButtonItem barButtonItem4;
        private BarSubItem barSubItem6;
        private BarCheckItem barCheckRu;
        private BarCheckItem barCheckKz;
        private BarButtonItem barButtonItem6;
        private BarButtonItem barButtonItem5;
        private BarButtonItem iAbout;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar2;
        private BarButtonItem barButtonItem8;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private RibbonStatusBar ribbonStatusBar1;
        public DevExpress.XtraNavBar.NavBarControl navBarControl2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private TreeView tvMenu;
        private StyleController styleController2;
        private BarHeaderItem barHeaderItem1;
        private DevExpress.XtraScheduler.UI.RepositoryItemAppointmentStatus repositoryItemAppointmentStatus1;
        private RepositoryItemRatingControl repositoryItemRatingControl1;
        private RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        public decimal iscancelpassword = 0;

        /// <summary>
        ///   Required method for Designer support - do not modify
        ///   the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.imMain = new System.Windows.Forms.ImageList(this.components);
            this.MainDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.viewMessages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imMessages = new DevExpress.Utils.ImageCollection(this.components);
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.rcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.iConnect = new DevExpress.XtraBars.BarButtonItem();
            this.iLockApplication = new DevExpress.XtraBars.BarButtonItem();
            this.iDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.iRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.iChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.iExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMenuPanel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMsgPanel = new DevExpress.XtraBars.BarButtonItem();
            this.iPaintStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iTileVertical = new DevExpress.XtraBars.BarButtonItem();
            this.iCloseAllWindows = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinRibbonGalleryBarItem2 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barCheckRu = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckKz = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.rpDataBase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpWindow = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpCustomize = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.repositoryItemAppointmentStatus1 = new DevExpress.XtraScheduler.UI.RepositoryItemAppointmentStatus();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.ribbonMiniToolbar2 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.tmIdle = new System.Timers.Timer();
            this.tmCheckInterval = new System.Timers.Timer();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.MainActionList = new BSB.Actions.MyActionList(this.components);
            this.aConnect = new BSB.Actions.MyAction(this.components);
            this.aDisconnect = new BSB.Actions.MyAction(this.components);
            this.aRefreshOfficRights = new BSB.Actions.MyAction(this.components);
            this.aChangePassword = new BSB.Actions.MyAction(this.components);
            this.aLockApplication = new BSB.Actions.MyAction(this.components);
            this.aSetCurrentLanguage = new BSB.Actions.MyAction(this.components);
            this.aKazLang = new BSB.Actions.MyAction(this.components);
            this.aRuLang = new BSB.Actions.MyAction(this.components);
            this.aExtraPokaz = new BSB.Actions.MyAction(this.components);
            this.aClients = new BSB.Actions.MyAction(this.components);
            this.aCredits = new BSB.Actions.MyAction(this.components);
            this.aRepList = new BSB.Actions.MyAction(this.components);
            this.aCalendarsOperationDays = new BSB.Actions.MyAction(this.components);
            this.aExportRep = new BSB.Actions.MyAction(this.components);
            this.aPledges = new BSB.Actions.MyAction(this.components);
            this.tmCheckGovSec = new System.Timers.Timer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.styleController1 = new DevExpress.XtraEditors.StyleController(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarControl2 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.styleController2 = new DevExpress.XtraEditors.StyleController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainDockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAppointmentStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIdle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckGovSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).BeginInit();
            this.navBarControl2.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.styleController2)).BeginInit();
            this.SuspendLayout();
            // 
            // imMain
            // 
            this.imMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imMain.ImageStream")));
            this.imMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imMain.Images.SetKeyName(0, "");
            this.imMain.Images.SetKeyName(1, "");
            this.imMain.Images.SetKeyName(2, "");
            this.imMain.Images.SetKeyName(3, "");
            this.imMain.Images.SetKeyName(4, "");
            this.imMain.Images.SetKeyName(5, "");
            this.imMain.Images.SetKeyName(6, "");
            this.imMain.Images.SetKeyName(7, "");
            this.imMain.Images.SetKeyName(8, "");
            this.imMain.Images.SetKeyName(9, "");
            this.imMain.Images.SetKeyName(10, "");
            this.imMain.Images.SetKeyName(11, "");
            this.imMain.Images.SetKeyName(12, "");
            this.imMain.Images.SetKeyName(13, "");
            this.imMain.Images.SetKeyName(14, "");
            this.imMain.Images.SetKeyName(15, "");
            this.imMain.Images.SetKeyName(16, "");
            this.imMain.Images.SetKeyName(17, "");
            this.imMain.Images.SetKeyName(18, "");
            this.imMain.Images.SetKeyName(19, "");
            this.imMain.Images.SetKeyName(20, "");
            this.imMain.Images.SetKeyName(21, "");
            this.imMain.Images.SetKeyName(22, "");
            this.imMain.Images.SetKeyName(23, "");
            this.imMain.Images.SetKeyName(24, "");
            this.imMain.Images.SetKeyName(25, "");
            this.imMain.Images.SetKeyName(26, "");
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(4, 28);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1325, 18);
            this.controlContainer1.TabIndex = 0;
            // 
            // viewMessages
            // 
            this.viewMessages.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewMessages.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.viewMessages.Appearance.EvenRow.ForeColor = System.Drawing.Color.White;
            this.viewMessages.Appearance.EvenRow.Options.UseBackColor = true;
            this.viewMessages.Appearance.EvenRow.Options.UseForeColor = true;
            this.viewMessages.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewMessages.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.viewMessages.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.viewMessages.Appearance.FocusedCell.Options.UseBackColor = true;
            this.viewMessages.Appearance.FocusedCell.Options.UseForeColor = true;
            this.viewMessages.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewMessages.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.viewMessages.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.viewMessages.Appearance.FocusedRow.Options.UseBackColor = true;
            this.viewMessages.Appearance.FocusedRow.Options.UseForeColor = true;
            this.viewMessages.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewMessages.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.viewMessages.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.viewMessages.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewMessages.Appearance.Row.ForeColor = System.Drawing.Color.Red;
            this.viewMessages.Appearance.Row.Options.UseFont = true;
            this.viewMessages.Appearance.Row.Options.UseForeColor = true;
            this.viewMessages.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.viewMessages.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.viewMessages.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.viewMessages.Appearance.SelectedRow.Options.UseBackColor = true;
            this.viewMessages.Appearance.SelectedRow.Options.UseForeColor = true;
            this.viewMessages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colType,
            this.colText});
            this.viewMessages.Name = "viewMessages";
            this.viewMessages.OptionsView.AllowCellMerge = true;
            this.viewMessages.OptionsView.RowAutoHeight = true;
            this.viewMessages.OptionsView.ShowColumnHeaders = false;
            this.viewMessages.OptionsView.ShowDetailButtons = false;
            this.viewMessages.OptionsView.ShowGroupPanel = false;
            this.viewMessages.OptionsView.ShowIndicator = false;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "col_STATUS";
            this.colStatus.ImageOptions.ImageIndex = 0;
            this.colStatus.MinWidth = 10;
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            this.colStatus.Width = 20;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 4)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imMessages;
            // 
            // imMessages
            // 
            this.imMessages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imMessages.ImageStream")));
            // 
            // colType
            // 
            this.colType.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colType.AppearanceCell.Options.UseFont = true;
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colType.Caption = "Тип сообщения";
            this.colType.FieldName = "col_TYPE";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowEdit = false;
            this.colType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colType.OptionsColumn.FixedWidth = true;
            this.colType.OptionsColumn.ReadOnly = true;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            this.colType.Width = 130;
            // 
            // colText
            // 
            this.colText.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colText.AppearanceCell.Options.UseFont = true;
            this.colText.AppearanceCell.Options.UseTextOptions = true;
            this.colText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colText.Caption = "Текст";
            this.colText.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colText.FieldName = "col_TEXT";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.AllowEdit = false;
            this.colText.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colText.OptionsColumn.ReadOnly = true;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 403;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            // 
            // popupMenu
            // 
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.rcMain;
            // 
            // rcMain
            // 
            this.rcMain.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.rcMain.AutoHideEmptyItems = true;
            this.rcMain.AutoSizeItems = true;
            this.rcMain.ExpandCollapseItem.Id = 0;
            this.rcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMain.ExpandCollapseItem,
            this.barButtonItem3,
            this.iConnect,
            this.iLockApplication,
            this.iDisconnect,
            this.iRefresh,
            this.iChangePassword,
            this.iExit,
            this.barButtonItemMenuPanel,
            this.barButtonItemMsgPanel,
            this.iPaintStyle,
            this.iTileVertical,
            this.iCloseAllWindows,
            this.barButtonItem17,
            this.skinDropDownButtonItem1,
            this.skinRibbonGalleryBarItem1,
            this.skinRibbonGalleryBarItem2,
            this.skinPaletteRibbonGalleryBarItem1,
            this.barDockingMenuItem1,
            this.barWorkspaceMenuItem1,
            this.barButtonItem4,
            this.barSubItem6,
            this.barButtonItem5,
            this.barCheckRu,
            this.barCheckKz,
            this.barButtonItem6,
            this.iAbout,
            this.barButtonItem8,
            this.barHeaderItem1,
            this.barButtonItem1,
            this.barButtonItem2});
            this.rcMain.Location = new System.Drawing.Point(0, 0);
            this.rcMain.MaxItemId = 18;
            this.rcMain.Name = "rcMain";
            this.rcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpDataBase,
            this.rpView,
            this.rpWindow,
            this.rpCustomize,
            this.rpHelp});
            this.rcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl1,
            this.repositoryItemZoomTrackBar1,
            this.repositoryItemAppointmentStatus1,
            this.repositoryItemMarqueeProgressBar1});
            this.rcMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.rcMain.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            this.rcMain.Size = new System.Drawing.Size(1007, 179);
            this.rcMain.StatusBar = this.ribbonStatusBar1;
            this.rcMain.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.True;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.rcMain;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 1;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // iConnect
            // 
            this.iConnect.Caption = "Подключиться к базе данных";
            this.iConnect.Hint = "Подключиться к базе данных";
            this.iConnect.Id = 227;
            this.iConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iConnect.ImageOptions.Image")));
            this.iConnect.ImageOptions.ImageIndex = 7;
            this.iConnect.Name = "iConnect";
            this.iConnect.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemConnect_ItemClick);
            // 
            // iLockApplication
            // 
            this.iLockApplication.Caption = "Заблокировать приложение";
            this.iLockApplication.Id = 228;
            this.iLockApplication.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iLockApplication.ImageOptions.Image")));
            this.iLockApplication.Name = "iLockApplication";
            this.iLockApplication.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iLockApplication.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iLockApplication_ItemClick);
            // 
            // iDisconnect
            // 
            this.iDisconnect.Caption = "Отключиться от базы данных";
            this.iDisconnect.Hint = "Отключиться от базы данных";
            this.iDisconnect.Id = 229;
            this.iDisconnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iDisconnect.ImageOptions.Image")));
            this.iDisconnect.Name = "iDisconnect";
            this.iDisconnect.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iDisconnect_ItemClick);
            // 
            // iRefresh
            // 
            this.iRefresh.Caption = "Перечитать права пользователя";
            this.iRefresh.Id = 230;
            this.iRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iRefresh.ImageOptions.Image")));
            this.iRefresh.Name = "iRefresh";
            this.iRefresh.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iRefresh_ItemClick);
            // 
            // iChangePassword
            // 
            this.iChangePassword.Caption = "Изменить пароль пользователя";
            this.iChangePassword.Id = 231;
            this.iChangePassword.Name = "iChangePassword";
            this.iChangePassword.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iChangePassword_ItemClick);
            // 
            // iExit
            // 
            this.iExit.Caption = "Выход";
            this.iExit.Id = 232;
            this.iExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iExit.ImageOptions.Image")));
            this.iExit.Name = "iExit";
            this.iExit.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iExit_ItemClick);
            // 
            // barButtonItemMenuPanel
            // 
            this.barButtonItemMenuPanel.Id = 14;
            this.barButtonItemMenuPanel.Name = "barButtonItemMenuPanel";
            // 
            // barButtonItemMsgPanel
            // 
            this.barButtonItemMsgPanel.Id = 16;
            this.barButtonItemMsgPanel.Name = "barButtonItemMsgPanel";
            // 
            // iPaintStyle
            // 
            this.iPaintStyle.Id = 17;
            this.iPaintStyle.Name = "iPaintStyle";
            // 
            // iTileVertical
            // 
            this.iTileVertical.Id = 15;
            this.iTileVertical.Name = "iTileVertical";
            // 
            // iCloseAllWindows
            // 
            this.iCloseAllWindows.Caption = "Закрыть все";
            this.iCloseAllWindows.Id = 239;
            this.iCloseAllWindows.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iCloseAllWindows.ImageOptions.Image")));
            this.iCloseAllWindows.Name = "iCloseAllWindows";
            this.iCloseAllWindows.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.iCloseAllWindows.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCloseAllWindows_ItemClick);
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "Окна";
            this.barButtonItem17.Id = 240;
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.AccessibleName = "";
            this.skinDropDownButtonItem1.Id = 242;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            this.skinDropDownButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 243;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // skinRibbonGalleryBarItem2
            // 
            this.skinRibbonGalleryBarItem2.Caption = "skinRibbonGalleryBarItem2";
            this.skinRibbonGalleryBarItem2.Id = 244;
            this.skinRibbonGalleryBarItem2.Name = "skinRibbonGalleryBarItem2";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            this.skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            this.skinPaletteRibbonGalleryBarItem1.Id = 245;
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "barDockingMenuItem1";
            this.barDockingMenuItem1.Id = 246;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barWorkspaceMenuItem1
            // 
            this.barWorkspaceMenuItem1.Caption = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.Id = 247;
            this.barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.WorkspaceManager = this.workspaceManager1;
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 248;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "&Язык интерфейса";
            this.barSubItem6.Id = 249;
            this.barSubItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem6.ImageOptions.Image")));
            this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckRu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckKz),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.barSubItem6.Name = "barSubItem6";
            this.barSubItem6.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barCheckRu
            // 
            this.barCheckRu.Caption = "RU Русский";
            this.barCheckRu.Id = 251;
            this.barCheckRu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCheckRu.ImageOptions.Image")));
            this.barCheckRu.Name = "barCheckRu";
            this.barCheckRu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckRu_ItemClick);
            // 
            // barCheckKz
            // 
            this.barCheckKz.Caption = "KZ Казахский";
            this.barCheckKz.Id = 252;
            this.barCheckKz.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCheckKz.ImageOptions.Image")));
            this.barCheckKz.Name = "barCheckKz";
            this.barCheckKz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckKz_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 253;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 250;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "О программе...";
            this.iAbout.Id = 254;
            this.iAbout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iAbout.ImageOptions.Image")));
            this.iAbout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("iAbout.ImageOptions.LargeImage")));
            this.iAbout.Name = "iAbout";
            this.iAbout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.iAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAbout_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 257;
            this.barButtonItem8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.ImageOptions.Image")));
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Description = "Версия";
            this.barHeaderItem1.Id = 1;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 13;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // rpDataBase
            // 
            this.rpDataBase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9,
            this.ribbonPageGroup10});
            this.rpDataBase.Name = "rpDataBase";
            this.rpDataBase.Text = "База данных";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.iConnect);
            this.ribbonPageGroup1.ItemLinks.Add(this.iDisconnect);
            this.ribbonPageGroup1.ItemLinks.Add(this.iLockApplication);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "База данных";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.iRefresh);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Права";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.iChangePassword);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Пользователь";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.iExit);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Выход";
            // 
            // rpView
            // 
            this.rpView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rpView.Name = "rpView";
            this.rpView.Text = "Вид";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.skinDropDownButtonItem1);
            this.ribbonPageGroup4.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem1);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Стиль";
            // 
            // rpWindow
            // 
            this.rpWindow.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rpWindow.Name = "rpWindow";
            this.rpWindow.Text = "Окна";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.iCloseAllWindows);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Расположение";
            // 
            // rpCustomize
            // 
            this.rpCustomize.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.rpCustomize.Name = "rpCustomize";
            this.rpCustomize.Text = "Настройка";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barSubItem6);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Язык";
            // 
            // rpHelp
            // 
            this.rpHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.rpHelp.Name = "rpHelp";
            this.rpHelp.Text = "Справка";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.iAbout);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Информация";
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            // 
            // repositoryItemZoomTrackBar1
            // 
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            // 
            // repositoryItemAppointmentStatus1
            // 
            this.repositoryItemAppointmentStatus1.AutoHeight = false;
            this.repositoryItemAppointmentStatus1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemAppointmentStatus1.Name = "repositoryItemAppointmentStatus1";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            this.repositoryItemMarqueeProgressBar1.ShowTitle = true;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barHeaderItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 554);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.rcMain;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1007, 38);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.rcMain;
            // 
            // tmIdle
            // 
            this.tmIdle.Interval = 100000D;
            this.tmIdle.SynchronizingObject = this;
            this.tmIdle.Elapsed += new System.Timers.ElapsedEventHandler(this.tmIdle_Elapsed);
            // 
            // tmCheckInterval
            // 
            this.tmCheckInterval.Interval = 1000D;
            this.tmCheckInterval.SynchronizingObject = this;
            this.tmCheckInterval.Elapsed += new System.Timers.ElapsedEventHandler(this.tmCheckInterval_Elapsed);
            // 
            // MainActionList
            // 
            this.MainActionList.MyActions.AddRange(new BSB.Actions.MyAction[] {
            this.aConnect,
            this.aDisconnect,
            this.aRefreshOfficRights,
            this.aChangePassword,
            this.aLockApplication,
            this.aSetCurrentLanguage,
            this.aKazLang,
            this.aRuLang,
            this.aExtraPokaz,
            this.aClients,
            this.aCredits,
            this.aRepList,
            this.aCalendarsOperationDays,
            this.aExportRep,
            this.aPledges});
            // 
            // aConnect
            // 
            this.aConnect.Caption = null;
            this.aConnect.Category = "База данных";
            this.aConnect.Code = "aConnect";
            this.aConnect.Enabled = true;
            this.aConnect.MakeDisabledOnExec = true;
            this.aConnect.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aConnectExecute);
            // 
            // aDisconnect
            // 
            this.aDisconnect.Caption = null;
            this.aDisconnect.Category = "База данных";
            this.aDisconnect.Code = "aDisconnect";
            this.aDisconnect.Enabled = true;
            this.aDisconnect.MakeDisabledOnExec = true;
            this.aDisconnect.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aDisconnectExecute);
            // 
            // aRefreshOfficRights
            // 
            this.aRefreshOfficRights.Caption = null;
            this.aRefreshOfficRights.Category = "База данных";
            this.aRefreshOfficRights.Code = "aRefreshOfficRights";
            this.aRefreshOfficRights.Enabled = true;
            this.aRefreshOfficRights.MakeDisabledOnExec = true;
            this.aRefreshOfficRights.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aRefreshOfficRightsExecute);
            // 
            // aChangePassword
            // 
            this.aChangePassword.Caption = null;
            this.aChangePassword.Category = "База данных";
            this.aChangePassword.Code = "aChangePassword";
            this.aChangePassword.Enabled = true;
            this.aChangePassword.MakeDisabledOnExec = true;
            this.aChangePassword.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aChangePasswordExecute);
            // 
            // aLockApplication
            // 
            this.aLockApplication.Caption = null;
            this.aLockApplication.Category = "База данных";
            this.aLockApplication.Code = "aLockApplication";
            this.aLockApplication.Enabled = true;
            this.aLockApplication.MakeDisabledOnExec = true;
            this.aLockApplication.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aLockApplicationExecute);
            // 
            // aSetCurrentLanguage
            // 
            this.aSetCurrentLanguage.Caption = null;
            this.aSetCurrentLanguage.Category = null;
            this.aSetCurrentLanguage.Code = "aSetCurrentLanguage";
            this.aSetCurrentLanguage.Enabled = true;
            this.aSetCurrentLanguage.MakeDisabledOnExec = true;
            this.aSetCurrentLanguage.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aSetCurrentLanguage_Execute);
            // 
            // aKazLang
            // 
            this.aKazLang.Caption = null;
            this.aKazLang.Category = null;
            this.aKazLang.Code = "aKazLang";
            this.aKazLang.Enabled = true;
            this.aKazLang.MakeDisabledOnExec = true;
            this.aKazLang.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aKazLang_Execute);
            // 
            // aRuLang
            // 
            this.aRuLang.Caption = null;
            this.aRuLang.Category = null;
            this.aRuLang.Code = "aRuLang";
            this.aRuLang.Enabled = true;
            this.aRuLang.MakeDisabledOnExec = true;
            this.aRuLang.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aRuLang_Execute);
            // 
            // aExtraPokaz
            // 
            this.aExtraPokaz.Caption = "Дополнительные признаки";
            this.aExtraPokaz.Category = null;
            this.aExtraPokaz.Code = "aExtraPokaz";
            this.aExtraPokaz.Enabled = true;
            this.aExtraPokaz.MakeDisabledOnExec = true;
            this.aExtraPokaz.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aExtraPokaz_Execute);
            // 
            // aClients
            // 
            this.aClients.Caption = "Дополнительные признаки";
            this.aClients.Category = null;
            this.aClients.Code = "aClients";
            this.aClients.Enabled = true;
            this.aClients.MakeDisabledOnExec = true;
            this.aClients.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aClients_Execute);
            // 
            // aCredits
            // 
            this.aCredits.Caption = "";
            this.aCredits.Category = null;
            this.aCredits.Code = "aCredits";
            this.aCredits.Enabled = true;
            this.aCredits.MakeDisabledOnExec = true;
            this.aCredits.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aCredits_Execute);
            // 
            // aRepList
            // 
            this.aRepList.Caption = "Настройка отчетов";
            this.aRepList.Category = null;
            this.aRepList.Code = "aRepList";
            this.aRepList.Enabled = true;
            this.aRepList.MakeDisabledOnExec = true;
            this.aRepList.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aRepList_Execute);
            // 
            // aCalendarsOperationDays
            // 
            this.aCalendarsOperationDays.Caption = "Календар операционных дней";
            this.aCalendarsOperationDays.Category = null;
            this.aCalendarsOperationDays.Code = "aCalendarsOperationDays";
            this.aCalendarsOperationDays.Enabled = true;
            this.aCalendarsOperationDays.MakeDisabledOnExec = true;
            this.aCalendarsOperationDays.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aCalendarsOperationDays_Execute);
            // 
            // aExportRep
            // 
            this.aExportRep.Caption = "Экспорт отчетов в АИП Статистика";
            this.aExportRep.Category = null;
            this.aExportRep.Code = "aExportRep";
            this.aExportRep.Enabled = true;
            this.aExportRep.MakeDisabledOnExec = true;
            this.aExportRep.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aExportRep_Execute);
            // 
            // aPledges
            // 
            this.aPledges.Caption = "Залоговое обеспечение";
            this.aPledges.Category = null;
            this.aPledges.Code = "aPledges";
            this.aPledges.Enabled = true;
            this.aPledges.MakeDisabledOnExec = true;
            this.aPledges.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aPledges_Execute);
            // 
            // tmCheckGovSec
            // 
            this.tmCheckGovSec.Enabled = true;
            this.tmCheckGovSec.Interval = 5000D;
            this.tmCheckGovSec.SynchronizingObject = this;
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 66);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(22, 383);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Вид";
            // 
            // styleController1
            // 
            this.styleController1.PropertiesChanged += new System.EventHandler(this.styleController1_PropertiesChanged);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // navBarControl2
            // 
            this.navBarControl2.ActiveGroup = this.navBarGroup2;
            this.navBarControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.navBarControl2.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl2.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup2});
            this.navBarControl2.HotTrackedGroupCursor = System.Windows.Forms.Cursors.Hand;
            this.navBarControl2.Location = new System.Drawing.Point(0, 179);
            this.navBarControl2.MenuManager = this.rcMain;
            this.navBarControl2.Name = "navBarControl2";
            this.navBarControl2.OptionsNavPane.ExpandedWidth = 326;
            this.navBarControl2.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
            this.navBarControl2.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl2.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl2.Size = new System.Drawing.Size(38, 375);
            this.navBarControl2.TabIndex = 48;
            this.navBarControl2.Text = "Главное меню";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Главное меню";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 451;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.tvMenu);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(324, 334);
            this.navBarGroupControlContainer2.TabIndex = 0;
            // 
            // tvMenu
            // 
            this.tvMenu.BackColor = System.Drawing.SystemColors.Control;
            this.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("Tahoma", 8.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Margin = new System.Windows.Forms.Padding(10);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(324, 334);
            this.tvMenu.TabIndex = 2;
            this.tvMenu.DoubleClick += new System.EventHandler(this.tvMenu_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
            this.ClientSize = new System.Drawing.Size(1007, 592);
            this.Controls.Add(this.navBarControl2);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.rcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(800, 593);
            this.Name = "MainForm";
            this.Ribbon = this.rcMain;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "MainForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.MainDockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAppointmentStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIdle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckGovSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl2)).EndInit();
            this.navBarControl2.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.styleController2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region [О программе]

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ad = new TfrmAbout();
            try
            {
                ad.ShowDialog(this);
            }
            finally
            {
                ad.Dispose();
            }
        }

        #endregion

        #region [Процедура для обработки всех сообщений для окна]

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case (int)WinMessage.WM_ACTIVATEAPP:
                    OnWMActivateApp(ref m);
                    break;
                case (int)WinMessage.WM_QUERYOPEN:
                    OnWMQOpen(ref m);
                    return;
                case WM_AFTERSHOW:
                    AfterShow(ref m);
                    return;
            }
            base.WndProc(ref m);
        }

        #endregion

        private void InfoGuide_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmGuideInfo ad = new frmGuideInfo();
            //ad.MdiParent = this;
            //ad.Show();
        }

        #region Fields

        private const int WM_AFTERSHOW = (Int32)WinMessage.WM_USER + 1;
        private const bool V = false;
        private MyAction aChangePassword;
        private MyAction aConnect;
        public MyAction aDisconnect;
        private MyAction aLockApplication;
        private MyAction aRefreshOfficRights;
        private MyAction aSetCurrentLanguage;
        private GridColumn colStatus;
        private GridColumn colText;
        private GridColumn colType;
        private IContainer components;
        private ControlContainer controlContainer1;
        //private DockPanel dpMessages;
        //private GridControl gridMessages;
        public ImageList imMain;
        private ImageCollection imMessages;
        private MyActionList MainActionList;
        private DockManager MainDockManager;
        private PopupMenu popupMenu;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemMemoEdit repositoryItemMemoEdit1;
        public Timer tmCheckInterval;
        public Timer tmIdle;
        private ToolTipController toolTipController;
        private GridView viewMessages;
        private MyAction aKazLang;
        private MyAction aRuLang;
        //private readonly string xmlPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Xml\";

        #endregion


        public TreeView GetTvMenu()
        {
            return this.tvMenu;
        }

        #region Guides

        private void aCurrencyECB_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new CurrencyECBListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aRegOrganMU_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new RegOrganMUListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }

        private void aExecutor_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new ExecutorListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aSharer_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new SharerListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }

        private void aRepForm_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new MakeReportsForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aExtraPokaz_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new ExtraPokazListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aClients_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new ExtraPokazListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aCredits_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new LoansListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aRepList_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new ReportsListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aCalendarsOperationDays_Execute(object sender, TActionEventArgs ae)
        {
            var frm = new CalendarOperationsForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aExportRep_Execute(object sender, TActionEventArgs ae)
        {

            var frm = new ExportRepListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        private void aPledges_Execute(object sender, TActionEventArgs ae)
        {
            //MessageBox.Show("Pledges!");
            var frm = new CreditsListForm();
            frm.pAction = (MyAction)sender;
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region [Create and Dispose Form]

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region [Загрузка и инициализация]

        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            /* Инициализация приложения */
            InitApplication.InitializeApp();
            //MessageBox.Show(InitApplication.skinName);
            

            var frm = new MainForm();
            
            Application.AddMessageFilter(new TMessageFilter(frm));
            Application.Run(frm);
            InitApplication.UnInitializeApp();
        }

        /// <summary>
        ///   Загрузка и инициализация главного окна
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            dmControler.Init(this);
            //MainBarManager.Images = dmControler.frmMain.imMain;
            //tcMDIChildren.ImageList = dmControler.frmMain.imMain;
            tvMenu.ImageList = dmControler.frmMain.imMain;
            Text = InitApplication.AppTitle;

            //Skin
            rcMain.Toolbar.ItemLinks.Add(skinRibbonGalleryBarItem1); //skinDropDownButtonItem1
            rcMain.Toolbar.ItemLinks.Add(skinPaletteRibbonGalleryBarItem1);//

            barHeaderItem1.Caption = string.Format(LangTranslate.UiGetText("Версия: {0}"), Application.ProductVersion);
            /* ribbonStatusBar1.Tex
       InitBars();
       InitDockPanels();
             //styleController1.BeginUpdate();*/
            // Устанавливаем стиль приложения
            /*defaultLookAndFeel.LookAndFeel.SetStyle(InitApplication.style, InitApplication.useWindowsXPTheme,
         InitApplication.useDefaultLookAndFeel, InitApplication.skinName);
            styleController1_PropertiesChanged(sender, e);

            if (!SkinManager.AllowFormSkins)
                SkinManager.DisableFormSkins();
            else
                SkinManager.EnableFormSkins();
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();*/

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = InitApplication.style;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = InitApplication.skinName;

            // Сообщение о начале работы приложения
            Win32.PostMessage(Handle, WM_AFTERSHOW, IntPtr.Zero, IntPtr.Zero);
            //hideContainerBottom.Visible = false;
            //  GovSecuritiesLoadXml.WatcherMINFIN();           
        }

        /// <summary>
        ///   Начало работы
        /// </summary>
        private void AfterShow(ref Message m)
        {
            //MainBarManager.BeginUpdate();
            //MainBarManager.EndUpdate();

            aDisconnect.OnExecute();
            aConnect.OnExecute();
        }

        #endregion

        #region [Подключение и отсоединение к\от базы данных]

        /// <summary>
        ///   Событие: Подключение к БД
        /// </summary>
        private void BarButtonItemConnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            iconnectlang = true;
            aConnect.OnExecute();
            //aRuLang.OnExecute();
        }

        /// <summary>
        ///   Событие: Отключение от БД
        /// </summary>
        private void iDisconnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            aDisconnect.OnExecute();
        }

        /// <summary>
        ///   Отключение от БД
        /// </summary>
        /// 

        public void aDisconnectExecute(object sender, TActionEventArgs e)
        {
            // Проверка на подключение к БД
            if (dmControler.frmMain.oracleConnection.State == ConnectionState.Closed)
                return;

            // Проверяем можем ли мы закрыть все активные окна
            foreach (var Children in MdiChildren)
                if (Children is MDIChildForm)
                    if (!((MDIChildForm)Children).CanClose())
                        return;

            // Закрываем все активные окна
            foreach (var Children in MdiChildren)
                Children.Close();

            // Отключаемся от БД}
            //if (dmControler.frmMain.oracleConnection.State != ConnectionState.Closed)
            // {   


            // }

            SetConnectActions(false);

            // Уничтожаем меню
            DestroyMenu();

            // Уничтожаем панель сообщений
            //DestroyMsgPanel();
            Text = InitApplication.AppTitle;

            if (!DBSupport.DisconnectFromOracle(dmControler.frmMain.oracleConnection))
                return;
        }

        /// <summary>
        ///   Подключение к БД
        /// </summary>
        private void aConnectExecute(object sender, TActionEventArgs e)
        {
            DBSupport.main = this;
            // Проверка на подключение к БД
            if (dmControler.frmMain.oracleConnection.State == ConnectionState.Open)
                return;

            // Подключаемся к БД
            if (!DBSupport.ConnectToOracle(dmControler.frmMain.oracleConnection))
                return;

            SetConnectActions(true);

            // Подключение к БД выполнено, проверяем, прописан ли пользователь в Official
            if (!DBSupport.IsUserOfficial())
            {
                XtraMessageBox.Show(LangTranslate.UiGetText("Данный пользователь не имеет прав на работу с базой данных"),
                  LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                aDisconnect.OnExecute();
                return;
            }
            // Пользователь прописан в Official,
            // проверяем, не заблокировано ли должностное лицо администратором
            if (DBSupport.IsOfficialBlocked())
            {
                XtraMessageBox.Show(LangTranslate.UiGetText("Данное должностное лицо заблокировано администратором"),
                  LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                aDisconnect.OnExecute();
                return;
            }

            // Пользователь не заблокирован. Не истек ли срок действия пароля пользователя
            if (dmControler.frmMain.DBLogin != "ADMIN")
            {
                var PassChangeDate = DBSupport.GetUserPasswordChangeDate(dmControler.frmMain.DBLogin).Date;
                var CurrServerTime = DBSupport.GetServerTime().Date;
                var IdUsrPasswordChangeDate = DBSupport.GetIdUserChangePassword();
                var param = new TPkgParams();
                param.oc = dmControler.frmMain.oracleConnection;
                var MaxPassAge = Convert.ToInt32(param.GetSystemSetupParam("MAX_PASSWORD_AGE"));
                var PassExpireAlarmDays = Convert.ToInt32(param.GetSystemSetupParam("PASSWORD_EXPIRE_ALARM_DAYS"));

                var CurrPassAge = (CurrServerTime - PassChangeDate).Days;
                if ((CurrPassAge < MaxPassAge) && (CurrPassAge >= MaxPassAge - PassExpireAlarmDays))
                {
                    // Приближается конец срока действия пароля. Предупреждаем пользователя
                    /* XtraMessageBox.Show(
                    String.Format(LangTranslate.UiGetText("Срок действия пароля истечет через {0} дн."),
                      (PassChangeDate.AddDays(MaxPassAge) - CurrServerTime).Days),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    if (XtraMessageBox.Show(
                 String.Format(LangTranslate.UiGetText("Срок действия пароля истечет через {0} дн."),
                      (PassChangeDate.AddDays(MaxPassAge) - CurrServerTime).Days) + Environment.NewLine +
                 LangTranslate.UiGetText("Изменить пароль сейчас?"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        aChangePassword.OnExecute();
                    }
                }
                else if (CurrPassAge >= MaxPassAge)
                {
                    // Устанавливаем флаг блокировки пользователя/* Истек срок действия пароля */ 
                    /*DBSupport.SetCurrOfficialBlocked(2);
                      XtraMessageBox.Show(
                      LangTranslate.UiGetText("Срок действия пароля истек") + Environment.NewLine +
                      LangTranslate.UiGetText("Обратитесь к администратору базы данных"),
                      LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aDisconnect.OnExecute();
                    return;*/
                    XtraMessageBox.Show(
                    LangTranslate.UiGetText("Срок действия пароля истек.") + Environment.NewLine +
                    LangTranslate.UiGetText("Измените пароль "),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aChangePassword.OnExecute();
                }
                if (dmControler.frmMain.DBLogin != "SUPERUSER")
                {
                    if (((IdUsrPasswordChangeDate != null) || (IdUsrPasswordChangeDate != 0)) && (IdUsrPasswordChangeDate == 12))
                    {
                        XtraMessageBox.Show(
                        LangTranslate.UiGetText("Ваш пароль успешно изменён администратором.") + Environment.NewLine +
                        LangTranslate.UiGetText("Введите новый пароль."),
                        LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        aChangePassword.OnExecute();
                        if (iscancelpassword == 1)
                        {
                            if (DBSupport.ConnectToOracle(dmControler.frmMain.oracleConnection))
                            {
                                aDisconnect.OnExecute();
                                return;
                            }
                            else
                                return;
                        }

                    }
                }
            }

            Int32 Computer;
            string ComputerName;
            // С должностным лицом все в порядке, проверяем, зарегистрирован ли компьютер в БД
            if (!DBSupport.IsCompRegistered(out Computer, out ComputerName))
            {
                if (XtraMessageBox.Show(
                  LangTranslate.UiGetText("Данный компьютер не зарегистрирован в базе данных.") + Environment.NewLine +
                  LangTranslate.UiGetText("Зарегистрировать его?"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    aDisconnect.OnExecute();
                    return;
                }

                // Пытаемся зарегистрировать компьютер в БД
                if (!DBSupport.RegisterComputer(out Computer, out ComputerName))
                {
                    aDisconnect.OnExecute();
                    return;
                }
            }

            // Компьютер зарегистрирован в БД, проверяем, не заблокирован ли он
            if (DBSupport.IsCompBlocked(Computer))
            {
                XtraMessageBox.Show(
                  LangTranslate.UiGetText("Данный компьютер заблокирован администратором") + Environment.NewLine +
                  LangTranslate.UiGetText("В доступе отказано"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                aDisconnect.OnExecute();
                return;
            }

            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Заполняем таблицы прав и меню текущего должн. лица
                if (!DBSupport.FillCurrOfficTables(dmControler.frmMain.oracleConnection))
                {
                    XtraMessageBox.Show(
                      LangTranslate.UiGetText("Ошибка заполнения таблиц прав и меню пользователя") + Environment.NewLine +
                      LangTranslate.UiGetText("В доступе отказано"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    aDisconnect.OnExecute();
                    return;
                }

                // Корректируем объектные привилегии текущего должн. лица
                DBSupport.CorrectCurrOfficGrants(dmControler.frmMain.oracleConnection);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }

            #region [Выбираем язык интерфейса]

            barCheckRu.Checked = true;
            InitApplication.CurrentLangId = LangTranslate.SelectLang(false); //LanguageIds.Russian; 
            aSetCurrentLanguage.OnExecute();
            SetupNewVerArm();
            #endregion

            // Создаем меню
            CreateMenu();

            // Показываем Меню
            //dpMenu.Visibility = DockVisibility.Visible;

            // Создаем панель сообщений
            //CreateMsgPanel();

            Text = String.Format(LangTranslate.UiGetText("{0} [ пользователь - {1}@{2} ]"),
            LangTranslate.UiGetText(InitApplication.AppTitle), DBSupport.GetOfficialName(), dmControler.frmMain.DBDatabase);

            DBSupport.SetParams();

            // Читаем интервал неактивности до блокировки приложения
            var par = new TPkgParams();
            par.oc = dmControler.frmMain.oracleConnection;
            tmIdle.Interval = Int32.Parse(par.GetSystemSetupParam("APPLICATION_LOCK_INTERVAL")) * 1000;
            tmCheckInterval.Interval = 1 * 1000;

            if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                new LangTranslate().UISetupTexts(this);
            /*if (!RightsItemChecking.GetRightsItem(100434))
                barBtnSetTimesLoad.Visibility = BarItemVisibility.Never;*/

        }

        #endregion

        #region [Создание, уничтожение и работа с панелью сообщений]

        /*private void CreateMsgPanel()
        {
          DataTable dt = null;
          if (tvMenu.Nodes.Count > 0)
          {
            try
            {
              if (gridMessages.DataSource == null)
              {
                dt = new DataTable();
                dt.Columns.Add("col_STATUS", typeof (Int32));
                dt.Columns.Add("col_TYPE", typeof (string));
                dt.Columns.Add("col_TEXT", typeof (string));
              }
              else dt = (DataTable) gridMessages.DataSource;
              gridMessages.DataSource = dt;
            }
            finally
            {
              dt.Dispose();
            }
          }
        }*/

        private void AddMessageToMsgPanel(ref DataTable dt_, Int32 status, string type, string text)
        {
            dt_.BeginLoadData();
            dt_.LoadDataRow(new object[] { status, type, text }, false);
            dt_.EndLoadData();
        }

        /* private void DestroyMsgPanel()
         {
           if (gridMessages.DataSource != null)
             ((DataTable) gridMessages.DataSource).Clear();
         }*/

        #endregion

        #region [Создание, уничтожение и работа с меню]

        /// <summary>
        ///   Создаем меню
        /// </summary>
        private bool CreateMenu()
        {
            var bResult = false;
            //if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
            //throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

            DataTable dt;
            Int32 ErrCode;
            string ErrMsg;

            var ofr = new TPkgOfficialRight();
            try
            {
                ofr.oc = dmControler.frmMain.oracleConnection;
                ofr.ReadCurrOfficMenusAList(InitApplication.AppId, out dt, out ErrCode, out ErrMsg);
                try
                {
                    if (ErrCode != 0)
                    {
                        DBSupport.DBErrorHandler(ErrCode, ErrMsg);
                        return bResult;
                    }

                    TreeNode NewNode, ParentNode = null;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["CAPTION"].ToString() == "-") // Игнорируем разделители
                            continue;

                        // Вставляем подменю / элемент меню
                        if (row["PARENT_ID"] == DBNull.Value)
                        {
                            // Вставляем подменю верхнего уровня
                            NewNode = new TreeNode();
                            tvMenu.Nodes.Add(NewNode);
                        }
                        else
                        {
                            // Ищем родительское подменю по Parent_ID = App_Menu_Item предка
                            ParentNode = FindParentNode(tvMenu, null, Convert.ToInt32(row["PARENT_ID"]));
                            if (ParentNode != null)
                            {
                                // Добавляем дочернее подменю / элемент меню
                                NewNode = new TreeNode();
                                ParentNode.Nodes.Add(NewNode);
                            }
                            else
                                NewNode = null;
                        }

                        if (NewNode != null)
                        {
                            var md = new TMenuData();
                            if (Convert.ToInt32(row["ITEM_KIND"]) == 3)
                            {
                                if (row["ACTION"].ToString() != String.Empty)
                                {
                                    foreach (var action in MainActionList.MyActions)
                                    {
                                        if (action.Code == row["ACTION"].ToString())
                                        {
                                            action.Enabled = true;
                                            action.MakeDisabledOnExec = Convert.ToInt32(row["MAKE_DISABLED_ON_EXEC"]) == 1;
                                            md.pAction = action;
                                            break;
                                        }
                                    }
                                }
                            }

                            md.pCaption = LangTranslate.UiGetText(row["CAPTION"].ToString());
                            md.pHint = LangTranslate.UiGetText(row["HINT"].ToString());
                            md.pImageIndex = Convert.ToInt32(row["IMAGE_INDEX"]);
                            md.pAppMenuItem = Convert.ToInt32(row["APP_MENU_ITEM"]);

                            if (md.pImageIndex == -1)
                            {
                                if (Convert.ToInt32(row["ITEM_KIND"]) == 3)
                                {
                                    NewNode.SelectedImageIndex = 22;
                                    NewNode.ImageIndex = 22;
                                }
                                else
                                {
                                    NewNode.SelectedImageIndex = 24;
                                    NewNode.ImageIndex = 24;
                                }
                            }
                            else
                            {
                                NewNode.SelectedImageIndex = md.pImageIndex;
                                NewNode.ImageIndex = md.pImageIndex;
                            }

                            NewNode.Text = md.pCaption;
                            NewNode.Tag = md;
                        }
                    }
                    navBarControl2.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
                }
                finally
                {
                    dt.Clear();
                    dt.Dispose();
                }
            }
            catch (OracleException oe)
            {
                DBSupport.DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in frmMain.CreateMenu).");
            }
            catch (Exception oe)
            {
                XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in frmMain.CreateMenu).",
                  LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bResult;
        }

        /// <summary>
        ///   Уничтожает меню
        /// </summary>
        private void DestroyMenu()
        {
            tvMenu.Nodes.Clear();
        }

        /*private void iMenuExpand_ItemClick(object sender, ItemClickEventArgs e)
        {
          tvMenu.ExpandAll();
        }*/

        /*private void iMenuCollapse_ItemClick(object sender, ItemClickEventArgs e)
        {
          tvMenu.CollapseAll();
        }*/

        /*private void iMenuExpandNode_ItemClick(object sender, ItemClickEventArgs e)
        {
          if (tvMenu.SelectedNode != null)
            tvMenu.SelectedNode.Expand();
        }*/

        /*private void iMenuCollapseNode_ItemClick(object sender, ItemClickEventArgs e)
        {
          if (tvMenu.SelectedNode != null)
            tvMenu.SelectedNode.Collapse();
        }*/

        /*private void tvMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
          var md = e.Node.Tag as TMenuData;
          if (md != null)
          {
            if (md.pImageIndex == -1)
            {
              e.Node.ImageIndex = 24;
              e.Node.SelectedImageIndex = 24;
            }
          }
        }*/

        /*private void tvMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
          var md = e.Node.Tag as TMenuData;
          if (md != null)
          {
            if (md.pImageIndex == -1)
            {
              e.Node.ImageIndex = 23;
              e.Node.SelectedImageIndex = 23;
            }
          }
        }*/

        private TreeNode FindParentNode(TreeView tr, TreeNode node, Int32 ParentID)
        {
            TreeNode oResult = null;

            if (node == null)
            {
                foreach (TreeNode CurNode in tr.Nodes)
                {
                    var mdata = (TMenuData)CurNode.Tag;
                    if (mdata.pAppMenuItem == ParentID)
                        return CurNode;
                    if (CurNode.Nodes.Count > 0)
                        oResult = FindParentNode(tvMenu, CurNode, ParentID);
                    if (oResult != null)
                        return oResult;
                }
            }
            else
            {
                foreach (TreeNode CurNode in node.Nodes)
                {
                    var mdata = (TMenuData)CurNode.Tag;
                    if (mdata.pAppMenuItem == ParentID)
                        return CurNode;
                    if (CurNode.Nodes.Count > 0)
                        oResult = FindParentNode(tvMenu, CurNode, ParentID);

                    if (oResult != null)
                        return oResult;
                }
            }

            return oResult;
        }

        private void tvMenu_DoubleClick(object sender, EventArgs e)
        {
            var node = tvMenu.SelectedNode;
            var IsExecute = true;
            if (node != null)
            {
                var md = (TMenuData)node.Tag;
                if (md.pAction != null)
                {
                    if (md.pAction.Enabled)
                    {
                        if (md.pAction.MakeDisabledOnExec)
                        {
                            node.ForeColor = Color.FromArgb(100, 100, 100);
                            md.pAction.Enabled = false;
                        }

                        /*foreach (TabPage tp in tcMDIChildren.TabPages)
                        {
                            if (tp.Tag == md.pForm)
                            {
                                UserSelTab = false;
                                tcMDIChildren.SelectedTab = tp;
                                tcMDIChildren_SelectedIndexChanged(sender,e);
                                IsExecute = false; ;
                                return;
                            }
                        }*/
                        if (IsExecute)
                        {
                            var oldCursor = Cursor.Current;
                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                md.pAction.OnExecute();

                            }
                            finally
                            {
                                Cursor.Current = oldCursor;
                            }
                        }
                    }
                }
            }
        }

        private void _RepaintMenu(TreeNodeCollection nodes)
        {
            foreach (TreeNode _node in nodes)
            {
                var md = _node.Tag as TMenuData;
                if (md != null && md.pAction != null)
                {
                    if (!md.pAction.Enabled)
                        _node.ForeColor = Color.FromArgb(100, 100, 100);
                    else
                        _node.ForeColor = Color.Black;
                }

                if (_node.Nodes != null)
                    _RepaintMenu(_node.Nodes);
            }
        }

        public void RepaintMenu()
        {
            tvMenu.BeginUpdate();
            _RepaintMenu(tvMenu.Nodes);
            tvMenu.EndUpdate();
        }

        #endregion

        #region [Блокировка приложения]

        private bool FApplicationLocked;
        private IntPtr FForegroundWindowHandle;
        public TfrmUnlockApplication FUnlockApplicationForm;

        private void iLockApplication_ItemClick(object sender, ItemClickEventArgs e)
        {
            aLockApplication.OnExecute();
        }

        private void aLockApplicationExecute(object sender, TActionEventArgs e)
        {
            FApplicationLocked = true;
            FForegroundWindowHandle = Win32.GetForegroundWindow();
            Win32.ShowWindow(Handle, CmdShow.SW_MINIMIZE);
        }

        /// <summary>
        ///   Обрабатывает сообщение от Windows - WM_ACTIVATEAPP
        /// </summary>
        private void OnWMActivateApp(ref Message m)
        {
            var appActive = (((int)m.WParam != 0));

            if (FApplicationLocked && appActive)
            {
                if (FUnlockApplicationForm == null)
                {
                    FUnlockApplicationForm = new TfrmUnlockApplication();
                    try
                    {
                        if (FUnlockApplicationForm.ShowDialog() == DialogResult.OK)
                        {
                            FApplicationLocked = false;
                            if (Win32.IsIconic(Handle))
                                Win32.ShowWindow(Handle, CmdShow.SW_RESTORE);
                            Win32.SetForegroundWindow(FForegroundWindowHandle);
                        }
                        else
                            Win32.ShowWindow(Handle, CmdShow.SW_MINIMIZE);
                    }
                    finally
                    {
                        FUnlockApplicationForm.Dispose();
                        FUnlockApplicationForm = null;
                    }
                }
                else
                    FUnlockApplicationForm.BringToFront();
            }
        }

        private void OnWMQOpen(ref Message m)
        {
            if (FApplicationLocked)
                m.Result = new IntPtr(0);
            else
                m.Result = new IntPtr(1);
        }

        private void tmIdle_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Actions["aLockApplication"].Execute();
        }

        private void tmCheckInterval_Elapsed(object sender, ElapsedEventArgs e)
        {
            tmCheckInterval.Enabled = false;
            tmIdle.Enabled = true;
        }

        #endregion

        #region [Панель дочерних окон]

        /// <summary>
        ///   Признак того, что выбор закладки сделал пользователь а не программа
        /// </summary>
        private bool UserSelTab = true;

        /// <summary>
        ///   Признак того, что выбор окна сделал пользователь а не программа
        /// </summary>
        private bool UserWinActivate = true;

        /// <summary>
        ///   Создать взаимодействие между окном и панелью окон
        /// </summary>
        public void AttachPanelToWindow(Form frm)
        {
            frm.Closed += win_Closed;
            frm.Activated += win_Activated;

            var tp = new TabPage(frm.Text);
            tp.ImageIndex = 21;
            tp.Tag = frm;
            //tcMDIChildren.TabPages.Add(tp);
            tp.Text = LangTranslate.UiGetText(tp.Text);
        }

        private void win_Closed(object sender, EventArgs e)
        {
            /*foreach (TabPage tp in tcMDIChildren.TabPages)
            {
              if (tp.Tag == sender)
              {
                UserSelTab = false;
                tcMDIChildren.TabPages.Remove(tp);
              }
            }*/
        }

        private void win_Activated(object sender, EventArgs e)
        {
            if (!UserWinActivate)
            {
                UserWinActivate = true;
                return;
            }

           
        }

        

        #endregion

        #region [Обновление прав пользователя]

        private void iRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            aRefreshOfficRights.OnExecute();
        }

        /// <summary>
        ///   Обновление прав пользователя и перестройка меню
        /// </summary>
        private void aRefreshOfficRightsExecute(object sender, TActionEventArgs e)
        {
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Заполняем таблицы прав и меню текущего должн. лица
                if (!DBSupport.FillCurrOfficTables(dmControler.frmMain.oracleConnection))
                {
                    XtraMessageBox.Show(
                      LangTranslate.UiGetText("Ошибка заполнения таблиц прав и меню пользователя") + Environment.NewLine +
                      LangTranslate.UiGetText("В доступе отказано"), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    aDisconnect.OnExecute();
                    return;
                }

                // Корректируем объектные привилегии текущего должн. лица
                DBSupport.CorrectCurrOfficGrants(dmControler.frmMain.oracleConnection);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }

            // Вызываем процедуру инициализации переменных в БД
            DBSupport.SetParams();

            if (MdiChildren.Length > 0)
            {
                if (XtraMessageBox.Show(
                  LangTranslate.UiGetText("Для пересоздания меню необходимо закрыть все открытые окна") + Environment.NewLine +
                  LangTranslate.UiGetText("Пересоздать меню?"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Закрываем все активные окна
                    foreach (var f in MdiChildren)
                        f.Close();

                    // Уничтожаем меню
                    DestroyMenu();
                    // Уничтожаем панель сообщений
                    //DestroyMsgPanel();
                    // Создаем меню
                    CreateMenu();
                    // Создаем панель сообщений
                    //CreateMsgPanel();

                }
            }
            else
            {
                // Уничтожаем меню
                DestroyMenu();
                // Уничтожаем панель сообщений
                //DestroyMsgPanel();
                // Создаем меню
                CreateMenu();
                // Создаем панель сообщений
                //CreateMsgPanel();        
            }

            UnitOfWork.Instance.Clear();
        }

        #endregion

        #region [Изменение пароля пользователя]

        private void iChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            aChangePassword.OnExecute();
        }

        /// <summary>
        ///   Изменяет текущий пароль пользователя
        /// </summary>
        private void aChangePasswordExecute(object sender, TActionEventArgs e)
        {
            var cp = new TfrmChangePassword();
            try
            {
                if (cp.ShowDialog(this) == DialogResult.OK)
                {
                    aDisconnect.OnExecute();
                    aConnect.OnExecute();
                }
                else
                    iscancelpassword = cp.is_cancel;
            }
            finally
            {
                cp.Dispose();
            }
        }

        #endregion

        #region [Работа со стилями приложения]

        
        #endregion

        #region [Закрытие приложения]

        private void frmMain_Closing(object sender, CancelEventArgs e)
        {
            // Отключаемся от БД (с закрытием всех активных окон)
            aDisconnect.OnExecute();

            if (dmControler.frmMain.oracleConnection.State != ConnectionState.Closed)
            {
                XtraMessageBox.Show(LangTranslate.UiGetText("Не выполнено отключение от базы данных") + Environment.NewLine +
                                    LangTranslate.UiGetText("Работа программы не завершена"),
                  LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            e.Cancel = false;
            
        }

        private void frmMain_Closed(object sender, EventArgs e)
        {
            dmControler.UnInit();
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region [Разное]

        public void SetConnectActions(bool Connected)
        {
            iConnect.Enabled = !Connected;
            iDisconnect.Enabled = Connected;
            iRefresh.Enabled = Connected;
            iChangePassword.Enabled = Connected;
            iLockApplication.Enabled = Connected;
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            InitBars();
        }

        private void InitBars()
        {
            var ActiveMdiForm = ActiveMdiChild != null;
            iCloseAllWindows.Enabled = ActiveMdiForm;
        }

        private void iCloseAllWindows_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var fr in MdiChildren)
                fr.Close();
        }

        #endregion

        #region [События по пунктам меню]

        private void aSetCurrentLanguage_Execute(object sender, TActionEventArgs ae)
        {
            var conn = dmControler.frmMain.oracleConnection;
            var trans = conn.BeginTransaction();
            try
            {
                var cmd = conn.CreateCommand();
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "begin prepared.pkg_lang.current_lang_id := " + (decimal)InitApplication.CurrentLangId +
                                      "; end;";
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            finally
            {
                trans.Dispose();
            }
        }

        
        #endregion

        #region [Actions]

        private void hideContainerLeft_Click(object sender, EventArgs e)
        {

        }

        private void aShareReestr_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aShareJournalDenial_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aKazDepRecReestr_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aKndSanction_Execute(object sender, TActionEventArgs ae)
        {

        }
        private void aKazDepRecJournalDenial_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aIslamSecReestr_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aIslamSecJournalDenial_Execute(object sender, TActionEventArgs ae)
        {

        }

        private void aGovSecResstr_Execute(object sender, TActionEventArgs ae)
        {

        }
        #endregion

        private void barCheckRu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (
                      XtraMessageBox.Show(
                        LangTranslate.UiGetText("Перед сменой языка интерфейса будут закрыты все открытые окна. Продолжить?"),
                        LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (var fr in MdiChildren)
                    fr.Close();
                aRuLang.OnExecute();
            }
            else
            {
                barCheckRu.Checked = true;
                barCheckKz.Checked = false;
            }
        }

        private void barCheckKz_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (
                      XtraMessageBox.Show(
                        LangTranslate.UiGetText("Перед сменой языка интерфейса будут закрыты все открытые окна. Продолжить?"),
                        LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (var fr in MdiChildren)
                    fr.Close();
                aKazLang.OnExecute();
            }
            else
            {
                barCheckKz.Checked = true;
                barCheckRu.Checked = false;
            }
        }

        private void aKazLang_Execute(object sender, TActionEventArgs ae)
        {
            barCheckKz.Checked = true;
            barCheckRu.Checked = false;
            InitApplication.CurrentLangId = LangTranslate.SelectLang(true);
            new LangTranslate().UISetupTexts(this);
            DestroyMenu();
            //DestroyMsgPanel();
            CreateMenu();
            //CreateMsgPanel();
            kazlang = true;
        }

        private void aRuLang_Execute(object sender, TActionEventArgs ae)
        {
            barCheckRu.Checked = true;
            barCheckKz.Checked = false;
            InitApplication.CurrentLangId = LangTranslate.SelectLang(false);
            if (iconnectlang)
            {
                if (kazlang)
                {
                    InitApplication.CurrentLangId = LanguageIds.Kazakh;
                    barCheckKz.Checked = true;
                    barCheckRu.Checked = false;
                }
                new LangTranslate().UISetupTextCon(this);
            }
            else
                new LangTranslate().UISetupTexts(this);
            DestroyMenu();
            //DestroyMsgPanel();
            CreateMenu();
            //CreateMsgPanel();
            iconnectlang = false;
            kazlang = false;
        }
        #region Методы

        public void SetupNewVerArm()
        {
            var ErrCode = 0;
            var ErrMsg = String.Empty;

            try
            {
                var dbSetup = new DBSetup();
                dbSetup.oc = dmControler.frmMain.oracleConnection;
                var list = dbSetup.ReadSetupList(ErrCode, ErrMsg);

                if (list.Count > 0)
                {
                    if (XtraMessageBox.Show(LangTranslate.UiGetText("Обнаружена новая версия АРМа ") + list[list.Count - 1].Version + Environment.NewLine +
                                            LangTranslate.UiGetText("Обновить АРМ?"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        var tempPath = Path.GetTempPath();
                        // Копируем утилиту UppateApp во временный каталог
                        File.Copy(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + "UpdateApp.exe",
                          tempPath + @"\" + "UpdateApp.exe", true);

                        var args = "\"" + Application.ExecutablePath + "\" ";
                        // Сохраняем установочные файлы во временный каталог
                        foreach (var setup in list)
                        {
                            var setupFileName = tempPath + @"\" + "monitor_reports_update_" + setup.Version + ".exe";
                            using (var fs = File.Create(setupFileName))
                            {
                                fs.Write(setup.FileBody, 0, setup.FileBody.Length);
                                fs.Close();
                                args = args + "\"" + setupFileName + "\" ";
                            }
                        }

                        // Запускаем UppateApp
                        Process.Start(tempPath + @"\" + "UpdateApp.exe", args);

                        // Закрываем приложение
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
            }
        }
        #endregion

        
        public void KillClose()
        {
            foreach (var Children in MdiChildren)
                if (Children is MDIChildForm)
                    if (!((MDIChildForm)Children).CanClose())
                        return;
            // Закрываем все активные окна
            foreach (var Children in MdiChildren)  Children.Close();

            // Отключаемся от БД}

            if (!DBSupport.DisconnectFromOracle(dmControler.frmMain.oracleConnection))
                return;
            SetConnectActions(false);
            // Уничтожаем меню
            DestroyMenu();
            
            Text = InitApplication.AppTitle;
        }
        public void CloseSystem()
        {

            foreach (var f in MdiChildren)
                f.Close();
            // Уничтожаем меню
            // Создаем меню
            tvMenu.Nodes.Clear();
        }


        private void styleController1_PropertiesChanged(object sender, EventArgs e)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            InitApplication.skinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            InitApplication.style = DevExpress.LookAndFeel.UserLookAndFeel.Default.Style;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraNavBar.NavPaneState state = navBarControl2.OptionsNavPane.NavPaneState;
            switch (state)
            {
                case DevExpress.XtraNavBar.NavPaneState.Collapsed:
                    navBarControl2.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
                    break;
                case DevExpress.XtraNavBar.NavPaneState.Expanded:
                    navBarControl2.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                    break;

            }
        }
    }

    #region [Фильтр сообщений]

    /// <summary>
    ///   Фильтр сообщений всего приложения
    /// </summary>
    public class TMessageFilter : IMessageFilter
    {
        private readonly MainForm frm;

        public TMessageFilter(MainForm frm)
        {
            this.frm = frm;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == (int)WinMessage.WM_MOUSEMOVE || m.Msg == (int)WinMessage.WM_NCMOUSEMOVE ||
                m.Msg == (int)WinMessage.WM_KEYDOWN || m.Msg == (int)WinMessage.WM_SYSKEYDOWN)
            {
                if (dmControler.frmMain.oracleConnection.State == ConnectionState.Open)
                {
                    if (!frm.tmCheckInterval.Enabled && frm.FUnlockApplicationForm == null)
                    {
                        frm.tmIdle.Enabled = false;
                        frm.tmCheckInterval.Enabled = true;
                    }
                }
            }

            return false;
        }
    }
}
  #endregion  