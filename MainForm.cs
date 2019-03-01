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
using Oracle.DataAccess.Client;
using Timer = System.Timers.Timer;
using ARM_User.DisplayLayer.Service;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BSB.Common.DataGateway.Oracle;
using Oracle.DataAccess.Types;
using ARM_User.New.Guide;

namespace ARM_User
{
  /// <summary>
  ///   Summary description for Form1.
  /// </summary>
  public class MainForm : XtraForm
  {
    #region Windows Form Designer generated code
      public Boolean create = false;
      public decimal count;      
      public Boolean iconnectlang = false;
      private MyAction aStatusLoadToSaid;
      private MyAction aGovSecJournalStatus;
      public Timer tmCheckGovSec;
      public Boolean kazlang = false;
      private MyAction aShareAffiliatesInfo;
      private MyAction aFounderList;
      private MyAction aAssignee;
      private MyAction aProvisionKnd;
      private MyAction aAssets;
      private MyAction aPeriodicity;
      private MyAction aProtocolIsin;
        private MyAction myAction1;
        private MyAction myAction2;
        private MyAction aExtraPokaz;
        private MyAction aClients;
        private MyAction aCredits;
        private MyAction aRepList;
        private MyAction aCalendarsOperationDays;
        public decimal iscancelpassword = 0;

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BarSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.iConnect = new DevExpress.XtraBars.BarButtonItem();
            this.iDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.iLockApplication = new DevExpress.XtraBars.BarButtonItem();
            this.iRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.iChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.iExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemView = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemMenuPanel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMsgPanel = new DevExpress.XtraBars.BarButtonItem();
            this.iPaintStyle = new DevExpress.XtraBars.BarSubItem();
            this.ipsWXP = new DevExpress.XtraBars.BarButtonItem();
            this.ipsOXP = new DevExpress.XtraBars.BarButtonItem();
            this.ipsO2K = new DevExpress.XtraBars.BarButtonItem();
            this.ipsO2003 = new DevExpress.XtraBars.BarButtonItem();
            this.iSkins = new DevExpress.XtraBars.BarSubItem();
            this.iSCaramel = new DevExpress.XtraBars.BarButtonItem();
            this.iSAsphaltWorld = new DevExpress.XtraBars.BarButtonItem();
            this.iSLiquidSky = new DevExpress.XtraBars.BarButtonItem();
            this.iSCoffee = new DevExpress.XtraBars.BarButtonItem();
            this.iSStardust = new DevExpress.XtraBars.BarButtonItem();
            this.iSGlassOceans = new DevExpress.XtraBars.BarButtonItem();
            this.iSMoneyTwins = new DevExpress.XtraBars.BarButtonItem();
            this.iSLondonLiquidSky = new DevExpress.XtraBars.BarButtonItem();
            this.mWindow = new DevExpress.XtraBars.BarSubItem();
            this.iCascade = new DevExpress.XtraBars.BarButtonItem();
            this.iTileHorizontal = new DevExpress.XtraBars.BarButtonItem();
            this.iTileVertical = new DevExpress.XtraBars.BarButtonItem();
            this.iCloseAllWindows = new DevExpress.XtraBars.BarButtonItem();
            this.BarMdiChildrenListItem = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barCheckRu = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckKz = new DevExpress.XtraBars.BarCheckItem();
            this.barBtnSetTimesLoad = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.InfoGuide = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barHint = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.MainDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dpMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.dpMessages = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridMessages = new DevExpress.XtraGrid.GridControl();
            this.viewMessages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imMessages = new DevExpress.Utils.ImageCollection(this.components);
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.imMain = new System.Windows.Forms.ImageList(this.components);
            this.iMenuExpand = new DevExpress.XtraBars.BarButtonItem();
            this.iMenuCollapse = new DevExpress.XtraBars.BarButtonItem();
            this.iMenuExpandNode = new DevExpress.XtraBars.BarButtonItem();
            this.iMenuCollapseNode = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tmIdle = new System.Timers.Timer();
            this.tmCheckInterval = new System.Timers.Timer();
            this.tcMDIChildren = new System.Windows.Forms.TabControl();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.MainActionList = new BSB.Actions.MyActionList(this.components);
            this.aConnect = new BSB.Actions.MyAction(this.components);
            this.aDisconnect = new BSB.Actions.MyAction(this.components);
            this.aRefreshOfficRights = new BSB.Actions.MyAction(this.components);
            this.aChangePassword = new BSB.Actions.MyAction(this.components);
            this.aLockApplication = new BSB.Actions.MyAction(this.components);
            this.aSetCurrentLanguage = new BSB.Actions.MyAction(this.components);
            this.aFundKnd = new BSB.Actions.MyAction(this.components);
            this.aIssueECB = new BSB.Actions.MyAction(this.components);
            this.aCurrencyECB = new BSB.Actions.MyAction(this.components);
            this.aIssuersGuidesList = new BSB.Actions.MyAction(this.components);
            this.aBankCust = new BSB.Actions.MyAction(this.components);
            this.aCategoryControls = new BSB.Actions.MyAction(this.components);
            this.aClassifierOKED = new BSB.Actions.MyAction(this.components);
            this.aSpecBus = new BSB.Actions.MyAction(this.components);
            this.aSignPartNores = new BSB.Actions.MyAction(this.components);
            this.aSpecIssuer = new BSB.Actions.MyAction(this.components);
            this.aAbilityConvert = new BSB.Actions.MyAction(this.components);
            this.aReg = new BSB.Actions.MyAction(this.components);
            this.aRegion = new BSB.Actions.MyAction(this.components);
            this.aAudit = new BSB.Actions.MyAction(this.components);
            this.aKindECB = new BSB.Actions.MyAction(this.components);
            this.aIssOrganCont = new BSB.Actions.MyAction(this.components);
            this.aDateTypeLocal = new BSB.Actions.MyAction(this.components);
            this.aDocKnd = new BSB.Actions.MyAction(this.components);
            this.aAddCategoryShare = new BSB.Actions.MyAction(this.components);
            this.aCategoryECB = new BSB.Actions.MyAction(this.components);
            this.aIndexRewards = new BSB.Actions.MyAction(this.components);
            this.aProcessknd = new BSB.Actions.MyAction(this.components);
            this.aOLF = new BSB.Actions.MyAction(this.components);
            this.aListing = new BSB.Actions.MyAction(this.components);
            this.aRating = new BSB.Actions.MyAction(this.components);
            this.aRegOrganMU = new BSB.Actions.MyAction(this.components);
            this.aStateShareUk = new BSB.Actions.MyAction(this.components);
            this.aAppointment = new BSB.Actions.MyAction(this.components);
            this.aRepKnd = new BSB.Actions.MyAction(this.components);
            this.aSignatory = new BSB.Actions.MyAction(this.components);
            this.aExecutor = new BSB.Actions.MyAction(this.components);
            this.aCatHolderEcb = new BSB.Actions.MyAction(this.components);
            this.aIssueStsECB = new BSB.Actions.MyAction(this.components);
            this.aIssuersGCB = new BSB.Actions.MyAction(this.components);
            this.aKindGCB = new BSB.Actions.MyAction(this.components);
            this.aDebtRepayment = new BSB.Actions.MyAction(this.components);
            this.aStsReport = new BSB.Actions.MyAction(this.components);
            this.aKindRegBonds = new BSB.Actions.MyAction(this.components);
            this.aArticlesKOAP = new BSB.Actions.MyAction(this.components);
            this.aCauseChangesRep = new BSB.Actions.MyAction(this.components);
            this.aSuspension = new BSB.Actions.MyAction(this.components);
            this.aCountry = new BSB.Actions.MyAction(this.components);
            this.aDecisionAdmOffences = new BSB.Actions.MyAction(this.components);
            this.aFormCollection = new BSB.Actions.MyAction(this.components);
            this.aJurPersSts = new BSB.Actions.MyAction(this.components);
            this.aReasonAnnulECB = new BSB.Actions.MyAction(this.components);
            this.aUnitDimPerECB = new BSB.Actions.MyAction(this.components);
            this.aJurPersCreateMethod = new BSB.Actions.MyAction(this.components);
            this.aMethodLocalECB = new BSB.Actions.MyAction(this.components);
            this.aPlaceAccommECB = new BSB.Actions.MyAction(this.components);
            this.aReasonChangeShareIssue = new BSB.Actions.MyAction(this.components);
            this.aStsStAccommECB = new BSB.Actions.MyAction(this.components);
            this.aDecVerifInf = new BSB.Actions.MyAction(this.components);
            this.aBasePrescription = new BSB.Actions.MyAction(this.components);
            this.aViolationKnd = new BSB.Actions.MyAction(this.components);
            this.aOrganRegIssueECB = new BSB.Actions.MyAction(this.components);
            this.aMRP = new BSB.Actions.MyAction(this.components);
            this.aResolutionDR = new BSB.Actions.MyAction(this.components);
            this.aStatusECB = new BSB.Actions.MyAction(this.components);
            this.aStatusLicense = new BSB.Actions.MyAction(this.components);
            this.aCondMonitorValid = new BSB.Actions.MyAction(this.components);
            this.aSharer = new BSB.Actions.MyAction(this.components);
            this.aReasonSuspensionECB = new BSB.Actions.MyAction(this.components);
            this.aDecTreadCard = new BSB.Actions.MyAction(this.components);
            this.aProcess = new BSB.Actions.MyAction(this.components);
            this.aBondRegistry = new BSB.Actions.MyAction(this.components);
            this.aBondReestr = new BSB.Actions.MyAction(this.components);
            this.aBondRefuseJournal = new BSB.Actions.MyAction(this.components);
            this.aShareJournalReestr = new BSB.Actions.MyAction(this.components);
            this.aShareJournalChanges = new BSB.Actions.MyAction(this.components);
            this.aShareReestr = new BSB.Actions.MyAction(this.components);
            this.aShareJournalDenial = new BSB.Actions.MyAction(this.components);
            this.aKazDepRecReestr = new BSB.Actions.MyAction(this.components);
            this.aKazDepRecJournalDenial = new BSB.Actions.MyAction(this.components);
            this.aIslamSecReestr = new BSB.Actions.MyAction(this.components);
            this.aPaiReestr = new BSB.Actions.MyAction(this.components);
            this.aPermJournal = new BSB.Actions.MyAction(this.components);
            this.aPermRegRefuse = new BSB.Actions.MyAction(this.components);
            this.aPaiRefuse = new BSB.Actions.MyAction(this.components);
            this.aKndSanctions = new BSB.Actions.MyAction(this.components);
            this.aIslamSecJournalDenial = new BSB.Actions.MyAction(this.components);
            this.aGovSecResstr = new BSB.Actions.MyAction(this.components);
            this.aIssuer = new BSB.Actions.MyAction(this.components);
            this.aBondCorrection = new BSB.Actions.MyAction(this.components);
            this.aRepForm = new BSB.Actions.MyAction(this.components);
            this.aPaiCorrection = new BSB.Actions.MyAction(this.components);
            this.aDepRepJournal = new BSB.Actions.MyAction(this.components);
            this.aCorrectionDepRep = new BSB.Actions.MyAction(this.components);
            this.aCorrectionPerm = new BSB.Actions.MyAction(this.components);
            this.aCorrectionShare = new BSB.Actions.MyAction(this.components);
            this.aCorrectionKdr = new BSB.Actions.MyAction(this.components);
            this.aCorrectionGovSec = new BSB.Actions.MyAction(this.components);
            this.aCorrectionIslam = new BSB.Actions.MyAction(this.components);
            this.aKazLang = new BSB.Actions.MyAction(this.components);
            this.aRuLang = new BSB.Actions.MyAction(this.components);
            this.aViolation = new BSB.Actions.MyAction(this.components);
            this.aViolCapSize = new BSB.Actions.MyAction(this.components);
            this.aViolIssueReport = new BSB.Actions.MyAction(this.components);
            this.aViolRpmReport = new BSB.Actions.MyAction(this.components);
            this.aViolEnforc = new BSB.Actions.MyAction(this.components);
            this.aViolSanctions = new BSB.Actions.MyAction(this.components);
            this.aViolRefuseDoc = new BSB.Actions.MyAction(this.components);
            this.aCorrectionViolation = new BSB.Actions.MyAction(this.components);
            this.aStatusLoadToSaid = new BSB.Actions.MyAction(this.components);
            this.aGovSecJournalStatus = new BSB.Actions.MyAction(this.components);
            this.aShareAffiliatesInfo = new BSB.Actions.MyAction(this.components);
            this.aDefaultList = new BSB.Actions.MyAction(this.components);
            this.aFounderList = new BSB.Actions.MyAction(this.components);
            this.aAssignee = new BSB.Actions.MyAction(this.components);
            this.aProvisionKnd = new BSB.Actions.MyAction(this.components);
            this.aAssets = new BSB.Actions.MyAction(this.components);
            this.aPeriodicity = new BSB.Actions.MyAction(this.components);
            this.aProtocolIsin = new BSB.Actions.MyAction(this.components);
            this.myAction1 = new BSB.Actions.MyAction(this.components);
            this.myAction2 = new BSB.Actions.MyAction(this.components);
            this.aExtraPokaz = new BSB.Actions.MyAction(this.components);
            this.aClients = new BSB.Actions.MyAction(this.components);
            this.aCredits = new BSB.Actions.MyAction(this.components);
            this.aRepList = new BSB.Actions.MyAction(this.components);
            this.tmCheckGovSec = new System.Timers.Timer();
            this.aCalendarsOperationDays = new BSB.Actions.MyAction(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDockManager)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dpMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dpMessages.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIdle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckGovSec)).BeginInit();
            this.SuspendLayout();
            // 
            // MainBarManager
            // 
            this.MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.MainBarManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Справка", new System.Guid("cac15f5a-1f8e-43ad-b9d6-5225fb64e467")),
            new DevExpress.XtraBars.BarManagerCategory("База данных", new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db")),
            new DevExpress.XtraBars.BarManagerCategory("Меню", new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d")),
            new DevExpress.XtraBars.BarManagerCategory("Вид", new System.Guid("72357ab3-5503-454a-be9f-14acecaa5e4b")),
            new DevExpress.XtraBars.BarManagerCategory("Окно", new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763")),
            new DevExpress.XtraBars.BarManagerCategory("Стиль", new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf")),
            new DevExpress.XtraBars.BarManagerCategory("Рабочее меню", new System.Guid("81d48205-e99e-4e12-aa2b-1551e99931bd")),
            new DevExpress.XtraBars.BarManagerCategory("Скины", new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445"))});
            this.MainBarManager.DockControls.Add(this.barDockControlTop);
            this.MainBarManager.DockControls.Add(this.barDockControlBottom);
            this.MainBarManager.DockControls.Add(this.barDockControlLeft);
            this.MainBarManager.DockControls.Add(this.barDockControlRight);
            this.MainBarManager.DockManager = this.MainDockManager;
            this.MainBarManager.Form = this;
            this.MainBarManager.Images = this.imMain;
            this.MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarSubItem1,
            this.barSubItemView,
            this.mWindow,
            this.BarSubItem2,
            this.iConnect,
            this.iDisconnect,
            this.iLockApplication,
            this.iRefresh,
            this.iChangePassword,
            this.iExit,
            this.iAbout,
            this.barHint,
            this.iCascade,
            this.iTileHorizontal,
            this.iTileVertical,
            this.iCloseAllWindows,
            this.BarMdiChildrenListItem,
            this.ipsWXP,
            this.ipsOXP,
            this.ipsO2K,
            this.ipsO2003,
            this.iMenuExpand,
            this.iMenuCollapse,
            this.iMenuExpandNode,
            this.iMenuCollapseNode,
            this.iSkins,
            this.iSCaramel,
            this.iSAsphaltWorld,
            this.iSLiquidSky,
            this.iSCoffee,
            this.iSStardust,
            this.iSGlassOceans,
            this.iSMoneyTwins,
            this.iSLondonLiquidSky,
            this.barButtonItemMenuPanel,
            this.barButtonItemMsgPanel,
            this.iPaintStyle,
            this.InfoGuide,
            this.barButtonItem1,
            this.barSubItem3,
            this.barSubItem4,
            this.barSubItem5,
            this.barCheckRu,
            this.barCheckKz,
            this.barBtnSetTimesLoad});
            this.MainBarManager.MainMenu = this.bar1;
            this.MainBarManager.MaxItemId = 62;
            this.MainBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.MainBarManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemView),
            new DevExpress.XtraBars.LinkPersistInfo(this.mWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubItem2)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Главное меню";
            // 
            // BarSubItem1
            // 
            this.BarSubItem1.Caption = "База данных";
            this.BarSubItem1.CategoryGuid = new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d");
            this.BarSubItem1.Id = 13;
            this.BarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iConnect),
            new DevExpress.XtraBars.LinkPersistInfo(this.iDisconnect),
            new DevExpress.XtraBars.LinkPersistInfo(this.iLockApplication, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iChangePassword, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iExit, true)});
            this.BarSubItem1.Name = "BarSubItem1";
            // 
            // iConnect
            // 
            this.iConnect.Caption = "Подключиться к базе данных";
            this.iConnect.CategoryGuid = new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db");
            this.iConnect.Hint = "Подключиться к базе данных";
            this.iConnect.Id = 15;
            this.iConnect.ImageOptions.ImageIndex = 7;
            this.iConnect.Name = "iConnect";
            this.iConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemConnect_ItemClick);
            // 
            // iDisconnect
            // 
            this.iDisconnect.Caption = "Отключиться от базы данных";
            this.iDisconnect.CategoryGuid = new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db");
            this.iDisconnect.Enabled = false;
            this.iDisconnect.Hint = "Отключиться от базы данных";
            this.iDisconnect.Id = 16;
            this.iDisconnect.ImageOptions.ImageIndex = 6;
            this.iDisconnect.Name = "iDisconnect";
            this.iDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iDisconnect_ItemClick);
            // 
            // iLockApplication
            // 
            this.iLockApplication.Caption = "Заблокировать приложение";
            this.iLockApplication.CategoryGuid = new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db");
            this.iLockApplication.Enabled = false;
            this.iLockApplication.Hint = "Заблокировать приложение";
            this.iLockApplication.Id = 35;
            this.iLockApplication.ImageOptions.ImageIndex = 20;
            this.iLockApplication.Name = "iLockApplication";
            this.iLockApplication.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iLockApplication_ItemClick);
            // 
            // iRefresh
            // 
            this.iRefresh.Caption = "Перечитать права пользователя";
            this.iRefresh.CategoryGuid = new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db");
            this.iRefresh.Enabled = false;
            this.iRefresh.Hint = "Перечитать права пользователя";
            this.iRefresh.Id = 17;
            this.iRefresh.ImageOptions.ImageIndex = 15;
            this.iRefresh.Name = "iRefresh";
            this.iRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iRefresh_ItemClick);
            // 
            // iChangePassword
            // 
            this.iChangePassword.Caption = "Изменить пароль пользователя";
            this.iChangePassword.CategoryGuid = new System.Guid("cab7762b-f378-41ff-ae31-89aa33dc34db");
            this.iChangePassword.Enabled = false;
            this.iChangePassword.Hint = "Изменить пароль пользователя";
            this.iChangePassword.Id = 18;
            this.iChangePassword.ImageOptions.ImageIndex = 10;
            this.iChangePassword.Name = "iChangePassword";
            this.iChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iChangePassword_ItemClick);
            // 
            // iExit
            // 
            this.iExit.Caption = "Выход";
            this.iExit.CategoryGuid = new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d");
            this.iExit.Id = 19;
            this.iExit.Name = "iExit";
            this.iExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iExit_ItemClick);
            // 
            // barSubItemView
            // 
            this.barSubItemView.Caption = "Вид";
            this.barSubItemView.CategoryGuid = new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d");
            this.barSubItemView.Id = 22;
            this.barSubItemView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemMenuPanel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemMsgPanel),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPaintStyle)});
            this.barSubItemView.Name = "barSubItemView";
            // 
            // barButtonItemMenuPanel
            // 
            this.barButtonItemMenuPanel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMenuPanel.Caption = "Панель меню";
            this.barButtonItemMenuPanel.CategoryGuid = new System.Guid("72357ab3-5503-454a-be9f-14acecaa5e4b");
            this.barButtonItemMenuPanel.Down = true;
            this.barButtonItemMenuPanel.Hint = "Скрыть\\Показать панель меню";
            this.barButtonItemMenuPanel.Id = 23;
            this.barButtonItemMenuPanel.ImageOptions.ImageIndex = 16;
            this.barButtonItemMenuPanel.Name = "barButtonItemMenuPanel";
            this.barButtonItemMenuPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMenuPanel_ItemClick);
            // 
            // barButtonItemMsgPanel
            // 
            this.barButtonItemMsgPanel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMsgPanel.Caption = "Панель сообщений";
            this.barButtonItemMsgPanel.CategoryGuid = new System.Guid("72357ab3-5503-454a-be9f-14acecaa5e4b");
            this.barButtonItemMsgPanel.Down = true;
            this.barButtonItemMsgPanel.Hint = "Скрыть\\Показать панель сообщений";
            this.barButtonItemMsgPanel.Id = 52;
            this.barButtonItemMsgPanel.ImageOptions.ImageIndex = 26;
            this.barButtonItemMsgPanel.Name = "barButtonItemMsgPanel";
            this.barButtonItemMsgPanel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemMsgPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMsgPanel_ItemClick);
            // 
            // iPaintStyle
            // 
            this.iPaintStyle.Caption = "Стиль раскраски";
            this.iPaintStyle.CategoryGuid = new System.Guid("72357ab3-5503-454a-be9f-14acecaa5e4b");
            this.iPaintStyle.Id = 34;
            this.iPaintStyle.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ipsWXP),
            new DevExpress.XtraBars.LinkPersistInfo(this.ipsOXP),
            new DevExpress.XtraBars.LinkPersistInfo(this.ipsO2K),
            new DevExpress.XtraBars.LinkPersistInfo(this.ipsO2003),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSkins)});
            this.iPaintStyle.Name = "iPaintStyle";
            this.iPaintStyle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ipsWXP
            // 
            this.ipsWXP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.ipsWXP.Caption = "Windows XP";
            this.ipsWXP.CategoryGuid = new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf");
            this.ipsWXP.Description = "WindowsXP";
            this.ipsWXP.GroupIndex = 1;
            this.ipsWXP.Id = 30;
            this.ipsWXP.Name = "ipsWXP";
            this.ipsWXP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ips_ItemClick);
            // 
            // ipsOXP
            // 
            this.ipsOXP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.ipsOXP.Caption = "Office XP";
            this.ipsOXP.CategoryGuid = new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf");
            this.ipsOXP.Description = "OfficeXP";
            this.ipsOXP.GroupIndex = 1;
            this.ipsOXP.Id = 31;
            this.ipsOXP.Name = "ipsOXP";
            this.ipsOXP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ips_ItemClick);
            // 
            // ipsO2K
            // 
            this.ipsO2K.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.ipsO2K.Caption = "Office 2000";
            this.ipsO2K.CategoryGuid = new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf");
            this.ipsO2K.Description = "Office2000";
            this.ipsO2K.GroupIndex = 1;
            this.ipsO2K.Id = 32;
            this.ipsO2K.Name = "ipsO2K";
            this.ipsO2K.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ips_ItemClick);
            // 
            // ipsO2003
            // 
            this.ipsO2003.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.ipsO2003.Caption = "Office 2003";
            this.ipsO2003.CategoryGuid = new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf");
            this.ipsO2003.Description = "Office2003";
            this.ipsO2003.GroupIndex = 1;
            this.ipsO2003.Id = 33;
            this.ipsO2003.Name = "ipsO2003";
            this.ipsO2003.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ips_ItemClick);
            // 
            // iSkins
            // 
            this.iSkins.Caption = "Скины";
            this.iSkins.CategoryGuid = new System.Guid("db168634-9068-4b8a-834b-70143f4d7bcf");
            this.iSkins.Id = 41;
            this.iSkins.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iSCaramel),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSAsphaltWorld),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSLiquidSky),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSCoffee),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSStardust),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSGlassOceans),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSMoneyTwins),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSLondonLiquidSky)});
            this.iSkins.Name = "iSkins";
            // 
            // iSCaramel
            // 
            this.iSCaramel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSCaramel.Caption = "Caramel";
            this.iSCaramel.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSCaramel.GroupIndex = 1;
            this.iSCaramel.Id = 42;
            this.iSCaramel.Name = "iSCaramel";
            this.iSCaramel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSAsphaltWorld
            // 
            this.iSAsphaltWorld.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSAsphaltWorld.Caption = "The Asphalt World";
            this.iSAsphaltWorld.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSAsphaltWorld.GroupIndex = 1;
            this.iSAsphaltWorld.Id = 43;
            this.iSAsphaltWorld.Name = "iSAsphaltWorld";
            this.iSAsphaltWorld.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSLiquidSky
            // 
            this.iSLiquidSky.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSLiquidSky.Caption = "Liquid Sky";
            this.iSLiquidSky.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSLiquidSky.GroupIndex = 1;
            this.iSLiquidSky.Id = 44;
            this.iSLiquidSky.Name = "iSLiquidSky";
            this.iSLiquidSky.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSCoffee
            // 
            this.iSCoffee.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSCoffee.Caption = "Coffee";
            this.iSCoffee.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSCoffee.GroupIndex = 1;
            this.iSCoffee.Id = 45;
            this.iSCoffee.Name = "iSCoffee";
            this.iSCoffee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSStardust
            // 
            this.iSStardust.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSStardust.Caption = "Stardust";
            this.iSStardust.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSStardust.GroupIndex = 1;
            this.iSStardust.Id = 46;
            this.iSStardust.Name = "iSStardust";
            this.iSStardust.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSGlassOceans
            // 
            this.iSGlassOceans.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSGlassOceans.Caption = "Glass Oceans";
            this.iSGlassOceans.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSGlassOceans.GroupIndex = 1;
            this.iSGlassOceans.Id = 47;
            this.iSGlassOceans.Name = "iSGlassOceans";
            this.iSGlassOceans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSMoneyTwins
            // 
            this.iSMoneyTwins.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSMoneyTwins.Caption = "Money Twins";
            this.iSMoneyTwins.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSMoneyTwins.GroupIndex = 1;
            this.iSMoneyTwins.Id = 48;
            this.iSMoneyTwins.Name = "iSMoneyTwins";
            this.iSMoneyTwins.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // iSLondonLiquidSky
            // 
            this.iSLondonLiquidSky.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iSLondonLiquidSky.Caption = "London Liquid Sky";
            this.iSLondonLiquidSky.CategoryGuid = new System.Guid("48098e1d-c466-4488-8b96-4056c7a53445");
            this.iSLondonLiquidSky.GroupIndex = 1;
            this.iSLondonLiquidSky.Id = 49;
            this.iSLondonLiquidSky.Name = "iSLondonLiquidSky";
            this.iSLondonLiquidSky.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSkins_ItemClick);
            // 
            // mWindow
            // 
            this.mWindow.Caption = "Окно";
            this.mWindow.CategoryGuid = new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d");
            this.mWindow.Id = 28;
            this.mWindow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iCascade),
            new DevExpress.XtraBars.LinkPersistInfo(this.iTileHorizontal),
            new DevExpress.XtraBars.LinkPersistInfo(this.iTileVertical),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCloseAllWindows),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarMdiChildrenListItem, true)});
            this.mWindow.Name = "mWindow";
            // 
            // iCascade
            // 
            this.iCascade.Caption = "Каскадом";
            this.iCascade.CategoryGuid = new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763");
            this.iCascade.Id = 24;
            this.iCascade.ImageOptions.ImageIndex = 17;
            this.iCascade.Name = "iCascade";
            this.iCascade.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCascade_ItemClick);
            // 
            // iTileHorizontal
            // 
            this.iTileHorizontal.Caption = "Расположить горизонтально";
            this.iTileHorizontal.CategoryGuid = new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763");
            this.iTileHorizontal.Id = 25;
            this.iTileHorizontal.ImageOptions.ImageIndex = 19;
            this.iTileHorizontal.Name = "iTileHorizontal";
            this.iTileHorizontal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iTileHorizontal_ItemClick);
            // 
            // iTileVertical
            // 
            this.iTileVertical.Caption = "Расположить вертикально";
            this.iTileVertical.CategoryGuid = new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763");
            this.iTileVertical.Id = 26;
            this.iTileVertical.ImageOptions.ImageIndex = 18;
            this.iTileVertical.Name = "iTileVertical";
            this.iTileVertical.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iTileVertical_ItemClick);
            // 
            // iCloseAllWindows
            // 
            this.iCloseAllWindows.Caption = "Закрыть все";
            this.iCloseAllWindows.CategoryGuid = new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763");
            this.iCloseAllWindows.Id = 36;
            this.iCloseAllWindows.Name = "iCloseAllWindows";
            this.iCloseAllWindows.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCloseAllWindows_ItemClick);
            // 
            // BarMdiChildrenListItem
            // 
            this.BarMdiChildrenListItem.Caption = "Окна";
            this.BarMdiChildrenListItem.CategoryGuid = new System.Guid("747d4ad8-974a-42d0-85a0-48a038d83763");
            this.BarMdiChildrenListItem.Id = 29;
            this.BarMdiChildrenListItem.Name = "BarMdiChildrenListItem";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Настройка";
            this.barSubItem4.Id = 56;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSetTimesLoad)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "&Язык интерфейса";
            this.barSubItem5.Id = 57;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckRu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckKz)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barCheckRu
            // 
            this.barCheckRu.Caption = "RU Русский";
            this.barCheckRu.Id = 58;
            this.barCheckRu.Name = "barCheckRu";
            this.barCheckRu.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckRu_CheckedChanged);
            this.barCheckRu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckRu_ItemClick);
            // 
            // barCheckKz
            // 
            this.barCheckKz.Caption = "KZ Казахский";
            this.barCheckKz.Id = 59;
            this.barCheckKz.Name = "barCheckKz";
            this.barCheckKz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckKz_ItemClick);
            // 
            // barBtnSetTimesLoad
            // 
            this.barBtnSetTimesLoad.Caption = "Выгрузка на сайт";
            this.barBtnSetTimesLoad.Id = 61;
            this.barBtnSetTimesLoad.Name = "barBtnSetTimesLoad";
            this.barBtnSetTimesLoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSetTimesLoad_ItemClick);
            // 
            // BarSubItem2
            // 
            this.BarSubItem2.Caption = "Справка";
            this.BarSubItem2.CategoryGuid = new System.Guid("4f31361d-1b22-40a3-92c8-db911363509d");
            this.BarSubItem2.Id = 14;
            this.BarSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iAbout),
            new DevExpress.XtraBars.LinkPersistInfo(this.InfoGuide)});
            this.BarSubItem2.Name = "BarSubItem2";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "О программе...";
            this.iAbout.CategoryGuid = new System.Guid("cac15f5a-1f8e-43ad-b9d6-5225fb64e467");
            this.iAbout.Id = 20;
            this.iAbout.ImageOptions.ImageIndex = 14;
            this.iAbout.Name = "iAbout";
            this.iAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAbout_ItemClick);
            // 
            // InfoGuide
            // 
            this.InfoGuide.Caption = "&Справочная информация";
            this.InfoGuide.Id = 54;
            this.InfoGuide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("InfoGuide.ImageOptions.Image")));
            this.InfoGuide.Name = "InfoGuide";
            this.InfoGuide.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.InfoGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.InfoGuide_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(175, 165);
            this.bar2.FloatSize = new System.Drawing.Size(85, 65);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iConnect),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iDisconnect, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.iLockApplication, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iChangePassword, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemMenuPanel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemMsgPanel)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Основной";
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barHint)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.DrawSizeGrip = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Нижний";
            // 
            // barHint
            // 
            this.barHint.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.barHint.Id = 21;
            this.barHint.Name = "barHint";
            this.barHint.Size = new System.Drawing.Size(32, 0);
            this.barHint.Width = 32;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.MainBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(599, 48);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 393);
            this.barDockControlBottom.Manager = this.MainBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(599, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 48);
            this.barDockControlLeft.Manager = this.MainBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 345);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(599, 48);
            this.barDockControlRight.Manager = this.MainBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 345);
            // 
            // MainDockManager
            // 
            this.MainDockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.MainDockManager.Form = this;
            this.MainDockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpMessages});
            this.MainDockManager.MenuManager = this.MainBarManager;
            this.MainDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerLeft.Controls.Add(this.dpMenu);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 48);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(20, 345);
            // 
            // dpMenu
            // 
            this.dpMenu.Controls.Add(this.dockPanel1_Container);
            this.dpMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMenu.ID = new System.Guid("6bbfbc01-ccf9-4a45-b503-7eaef7a61ec9");
            this.dpMenu.Location = new System.Drawing.Point(19, 48);
            this.dpMenu.Name = "dpMenu";
            this.dpMenu.OriginalSize = new System.Drawing.Size(219, 326);
            this.dpMenu.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMenu.SavedIndex = 0;
            this.dpMenu.Size = new System.Drawing.Size(219, 345);
            this.dpMenu.Text = " Меню";
            this.dpMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            this.dpMenu.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dpMenu_VisibilityChanged);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tvMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 27);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(213, 315);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            this.MainBarManager.SetPopupContextMenu(this.tvMenu, this.popupMenu);
            this.tvMenu.Size = new System.Drawing.Size(213, 315);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterCollapse);
            this.tvMenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterExpand);
            this.tvMenu.DoubleClick += new System.EventHandler(this.tvMenu_DoubleClick);
            // 
            // dpMessages
            // 
            this.dpMessages.Controls.Add(this.controlContainer1);
            this.dpMessages.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMessages.FloatSize = new System.Drawing.Size(419, 152);
            this.dpMessages.FloatVertical = true;
            this.dpMessages.ID = new System.Guid("7613deef-a254-4501-8ddf-ebf83bb0b1a6");
            this.dpMessages.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dpMessages.Location = new System.Drawing.Point(0, 0);
            this.dpMessages.Name = "dpMessages";
            this.dpMessages.OriginalSize = new System.Drawing.Size(577, 50);
            this.dpMessages.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpMessages.SavedIndex = 0;
            this.dpMessages.Size = new System.Drawing.Size(580, 50);
            this.dpMessages.Text = "Сообщения";
            this.dpMessages.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            this.dpMessages.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dpMessages_VisibilityChanged);
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gridMessages);
            this.controlContainer1.Location = new System.Drawing.Point(3, 27);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(574, 20);
            this.controlContainer1.TabIndex = 0;
            // 
            // gridMessages
            // 
            this.gridMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMessages.Location = new System.Drawing.Point(0, 0);
            this.gridMessages.MainView = this.viewMessages;
            this.gridMessages.Name = "gridMessages";
            this.gridMessages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemMemoEdit1});
            this.gridMessages.Size = new System.Drawing.Size(574, 20);
            this.gridMessages.TabIndex = 0;
            this.gridMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMessages});
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
            this.viewMessages.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.viewMessages.GridControl = this.gridMessages;
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
            this.colStatus.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            // iMenuExpand
            // 
            this.iMenuExpand.Caption = "Развернуть меню";
            this.iMenuExpand.CategoryGuid = new System.Guid("81d48205-e99e-4e12-aa2b-1551e99931bd");
            this.iMenuExpand.Hint = "Развернуть меню";
            this.iMenuExpand.Id = 37;
            this.iMenuExpand.ImageOptions.ImageIndex = 26;
            this.iMenuExpand.Name = "iMenuExpand";
            this.iMenuExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iMenuExpand_ItemClick);
            // 
            // iMenuCollapse
            // 
            this.iMenuCollapse.Caption = "Свернуть меню";
            this.iMenuCollapse.CategoryGuid = new System.Guid("81d48205-e99e-4e12-aa2b-1551e99931bd");
            this.iMenuCollapse.Hint = "Свернуть меню";
            this.iMenuCollapse.Id = 38;
            this.iMenuCollapse.ImageOptions.ImageIndex = 27;
            this.iMenuCollapse.Name = "iMenuCollapse";
            this.iMenuCollapse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iMenuCollapse_ItemClick);
            // 
            // iMenuExpandNode
            // 
            this.iMenuExpandNode.Caption = "Развернуть подменю";
            this.iMenuExpandNode.CategoryGuid = new System.Guid("81d48205-e99e-4e12-aa2b-1551e99931bd");
            this.iMenuExpandNode.Hint = "Развернуть подменю";
            this.iMenuExpandNode.Id = 39;
            this.iMenuExpandNode.Name = "iMenuExpandNode";
            this.iMenuExpandNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iMenuExpandNode_ItemClick);
            // 
            // iMenuCollapseNode
            // 
            this.iMenuCollapseNode.Caption = "Свернуть подменю";
            this.iMenuCollapseNode.CategoryGuid = new System.Guid("81d48205-e99e-4e12-aa2b-1551e99931bd");
            this.iMenuCollapseNode.Hint = "Свернуть подменю";
            this.iMenuCollapseNode.Id = 40;
            this.iMenuCollapseNode.Name = "iMenuCollapseNode";
            this.iMenuCollapseNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iMenuCollapseNode_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 60;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "barSubItem3";
            this.barSubItem3.Id = 55;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iMenuExpandNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.iMenuCollapseNode),
            new DevExpress.XtraBars.LinkPersistInfo(this.iMenuExpand, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iMenuCollapse)});
            this.popupMenu.Manager = this.MainBarManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Stardust";
            this.defaultLookAndFeel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
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
            // tcMDIChildren
            // 
            this.tcMDIChildren.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcMDIChildren.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcMDIChildren.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMDIChildren.HotTrack = true;
            this.tcMDIChildren.Location = new System.Drawing.Point(20, 369);
            this.tcMDIChildren.Name = "tcMDIChildren";
            this.tcMDIChildren.SelectedIndex = 0;
            this.tcMDIChildren.Size = new System.Drawing.Size(579, 24);
            this.tcMDIChildren.TabIndex = 10;
            this.tcMDIChildren.Visible = false;
            this.tcMDIChildren.SelectedIndexChanged += new System.EventHandler(this.tcMDIChildren_SelectedIndexChanged);
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
            this.aFundKnd,
            this.aIssueECB,
            this.aCurrencyECB,
            this.aIssuersGuidesList,
            this.aBankCust,
            this.aCategoryControls,
            this.aClassifierOKED,
            this.aSpecBus,
            this.aSignPartNores,
            this.aSpecIssuer,
            this.aAbilityConvert,
            this.aReg,
            this.aRegion,
            this.aAudit,
            this.aKindECB,
            this.aIssOrganCont,
            this.aDateTypeLocal,
            this.aDocKnd,
            this.aAddCategoryShare,
            this.aCategoryECB,
            this.aIndexRewards,
            this.aProcessknd,
            this.aOLF,
            this.aListing,
            this.aRating,
            this.aRegOrganMU,
            this.aStateShareUk,
            this.aAppointment,
            this.aRepKnd,
            this.aSignatory,
            this.aExecutor,
            this.aCatHolderEcb,
            this.aIssueStsECB,
            this.aIssuersGCB,
            this.aKindGCB,
            this.aDebtRepayment,
            this.aStsReport,
            this.aKindRegBonds,
            this.aArticlesKOAP,
            this.aCauseChangesRep,
            this.aSuspension,
            this.aCountry,
            this.aDecisionAdmOffences,
            this.aFormCollection,
            this.aJurPersSts,
            this.aReasonAnnulECB,
            this.aUnitDimPerECB,
            this.aJurPersCreateMethod,
            this.aMethodLocalECB,
            this.aPlaceAccommECB,
            this.aReasonChangeShareIssue,
            this.aStsStAccommECB,
            this.aDecVerifInf,
            this.aBasePrescription,
            this.aViolationKnd,
            this.aOrganRegIssueECB,
            this.aMRP,
            this.aResolutionDR,
            this.aStatusECB,
            this.aStatusLicense,
            this.aCondMonitorValid,
            this.aSharer,
            this.aReasonSuspensionECB,
            this.aProcessknd,
            this.aDecTreadCard,
            this.aProcess,
            this.aBondRegistry,
            this.aBondReestr,
            this.aBondRefuseJournal,
            this.aShareJournalReestr,
            this.aShareJournalChanges,
            this.aShareReestr,
            this.aShareJournalDenial,
            this.aKazDepRecReestr,
            this.aKazDepRecJournalDenial,
            this.aIslamSecReestr,
            this.aPaiReestr,
            this.aPermJournal,
            this.aPermRegRefuse,
            this.aPaiRefuse,
            this.aKndSanctions,
            this.aIslamSecJournalDenial,
            this.aGovSecResstr,
            this.aIssuer,
            this.aBondCorrection,
            this.aRepForm,
            this.aBondCorrection,
            this.aPaiCorrection,
            this.aDepRepJournal,
            this.aCorrectionDepRep,
            this.aCorrectionPerm,
            this.aCorrectionShare,
            this.aCorrectionKdr,
            this.aCorrectionGovSec,
            this.aCorrectionIslam,
            this.aKazLang,
            this.aRuLang,
            this.aViolation,
            this.aViolCapSize,
            this.aViolIssueReport,
            this.aViolRpmReport,
            this.aViolEnforc,
            this.aViolSanctions,
            this.aViolRefuseDoc,
            this.aCorrectionViolation,
            this.aStatusLoadToSaid,
            this.aGovSecJournalStatus,
            this.aShareAffiliatesInfo,
            this.aDefaultList,
            this.aFounderList,
            this.aAssignee,
            this.aProvisionKnd,
            this.aAssets,
            this.aPeriodicity,
            this.aProtocolIsin,
            this.myAction1,
            this.myAction2,
            this.aExtraPokaz,
            this.aClients,
            this.aCredits,
            this.aRepList,
            this.aCalendarsOperationDays});
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
            // aFundKnd
            // 
            this.aFundKnd.Caption = null;
            this.aFundKnd.Category = null;
            this.aFundKnd.Code = null;
            this.aFundKnd.Enabled = true;
            this.aFundKnd.MakeDisabledOnExec = true;
            // 
            // aIssueECB
            // 
            this.aIssueECB.Caption = null;
            this.aIssueECB.Category = null;
            this.aIssueECB.Code = null;
            this.aIssueECB.Enabled = true;
            this.aIssueECB.MakeDisabledOnExec = true;
            // 
            // aCurrencyECB
            // 
            this.aCurrencyECB.Caption = null;
            this.aCurrencyECB.Category = null;
            this.aCurrencyECB.Code = "aCurrencyECB";
            this.aCurrencyECB.Enabled = true;
            this.aCurrencyECB.MakeDisabledOnExec = true;
            this.aCurrencyECB.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aCurrencyECB_Execute);
            // 
            // aIssuersGuidesList
            // 
            this.aIssuersGuidesList.Caption = null;
            this.aIssuersGuidesList.Category = null;
            this.aIssuersGuidesList.Code = null;
            this.aIssuersGuidesList.Enabled = true;
            this.aIssuersGuidesList.MakeDisabledOnExec = true;
            // 
            // aBankCust
            // 
            this.aBankCust.Caption = null;
            this.aBankCust.Category = null;
            this.aBankCust.Code = null;
            this.aBankCust.Enabled = true;
            this.aBankCust.MakeDisabledOnExec = true;
            // 
            // aCategoryControls
            // 
            this.aCategoryControls.Caption = null;
            this.aCategoryControls.Category = null;
            this.aCategoryControls.Code = null;
            this.aCategoryControls.Enabled = true;
            this.aCategoryControls.MakeDisabledOnExec = true;
            // 
            // aClassifierOKED
            // 
            this.aClassifierOKED.Caption = null;
            this.aClassifierOKED.Category = null;
            this.aClassifierOKED.Code = null;
            this.aClassifierOKED.Enabled = true;
            this.aClassifierOKED.MakeDisabledOnExec = true;
            // 
            // aSpecBus
            // 
            this.aSpecBus.Caption = null;
            this.aSpecBus.Category = null;
            this.aSpecBus.Code = null;
            this.aSpecBus.Enabled = true;
            this.aSpecBus.MakeDisabledOnExec = true;
            // 
            // aSignPartNores
            // 
            this.aSignPartNores.Caption = null;
            this.aSignPartNores.Category = null;
            this.aSignPartNores.Code = null;
            this.aSignPartNores.Enabled = true;
            this.aSignPartNores.MakeDisabledOnExec = true;
            // 
            // aSpecIssuer
            // 
            this.aSpecIssuer.Caption = null;
            this.aSpecIssuer.Category = null;
            this.aSpecIssuer.Code = null;
            this.aSpecIssuer.Enabled = true;
            this.aSpecIssuer.MakeDisabledOnExec = true;
            // 
            // aAbilityConvert
            // 
            this.aAbilityConvert.Caption = null;
            this.aAbilityConvert.Category = null;
            this.aAbilityConvert.Code = null;
            this.aAbilityConvert.Enabled = true;
            this.aAbilityConvert.MakeDisabledOnExec = true;
            // 
            // aReg
            // 
            this.aReg.Caption = null;
            this.aReg.Category = null;
            this.aReg.Code = null;
            this.aReg.Enabled = true;
            this.aReg.MakeDisabledOnExec = true;
            // 
            // aRegion
            // 
            this.aRegion.Caption = null;
            this.aRegion.Category = null;
            this.aRegion.Code = null;
            this.aRegion.Enabled = true;
            this.aRegion.MakeDisabledOnExec = true;
            // 
            // aAudit
            // 
            this.aAudit.Caption = null;
            this.aAudit.Category = null;
            this.aAudit.Code = null;
            this.aAudit.Enabled = true;
            this.aAudit.MakeDisabledOnExec = true;
            // 
            // aKindECB
            // 
            this.aKindECB.Caption = null;
            this.aKindECB.Category = null;
            this.aKindECB.Code = null;
            this.aKindECB.Enabled = true;
            this.aKindECB.MakeDisabledOnExec = true;
            // 
            // aIssOrganCont
            // 
            this.aIssOrganCont.Caption = null;
            this.aIssOrganCont.Category = null;
            this.aIssOrganCont.Code = null;
            this.aIssOrganCont.Enabled = true;
            this.aIssOrganCont.MakeDisabledOnExec = true;
            // 
            // aDateTypeLocal
            // 
            this.aDateTypeLocal.Caption = null;
            this.aDateTypeLocal.Category = null;
            this.aDateTypeLocal.Code = null;
            this.aDateTypeLocal.Enabled = true;
            this.aDateTypeLocal.MakeDisabledOnExec = true;
            // 
            // aDocKnd
            // 
            this.aDocKnd.Caption = null;
            this.aDocKnd.Category = null;
            this.aDocKnd.Code = null;
            this.aDocKnd.Enabled = true;
            this.aDocKnd.MakeDisabledOnExec = true;
            // 
            // aAddCategoryShare
            // 
            this.aAddCategoryShare.Caption = null;
            this.aAddCategoryShare.Category = null;
            this.aAddCategoryShare.Code = null;
            this.aAddCategoryShare.Enabled = true;
            this.aAddCategoryShare.MakeDisabledOnExec = true;
            // 
            // aCategoryECB
            // 
            this.aCategoryECB.Caption = null;
            this.aCategoryECB.Category = null;
            this.aCategoryECB.Code = null;
            this.aCategoryECB.Enabled = true;
            this.aCategoryECB.MakeDisabledOnExec = true;
            // 
            // aIndexRewards
            // 
            this.aIndexRewards.Caption = null;
            this.aIndexRewards.Category = null;
            this.aIndexRewards.Code = null;
            this.aIndexRewards.Enabled = true;
            this.aIndexRewards.MakeDisabledOnExec = true;
            // 
            // aProcessknd
            // 
            this.aProcessknd.Caption = null;
            this.aProcessknd.Category = null;
            this.aProcessknd.Code = null;
            this.aProcessknd.Enabled = true;
            this.aProcessknd.MakeDisabledOnExec = true;
            // 
            // aOLF
            // 
            this.aOLF.Caption = null;
            this.aOLF.Category = null;
            this.aOLF.Code = null;
            this.aOLF.Enabled = true;
            this.aOLF.MakeDisabledOnExec = true;
            // 
            // aListing
            // 
            this.aListing.Caption = null;
            this.aListing.Category = null;
            this.aListing.Code = null;
            this.aListing.Enabled = true;
            this.aListing.MakeDisabledOnExec = true;
            // 
            // aRating
            // 
            this.aRating.Caption = null;
            this.aRating.Category = null;
            this.aRating.Code = null;
            this.aRating.Enabled = true;
            this.aRating.MakeDisabledOnExec = true;
            // 
            // aRegOrganMU
            // 
            this.aRegOrganMU.Caption = null;
            this.aRegOrganMU.Category = null;
            this.aRegOrganMU.Code = "aRegOrganMU";
            this.aRegOrganMU.Enabled = true;
            this.aRegOrganMU.MakeDisabledOnExec = true;
            this.aRegOrganMU.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aRegOrganMU_Execute);
            // 
            // aStateShareUk
            // 
            this.aStateShareUk.Caption = null;
            this.aStateShareUk.Category = null;
            this.aStateShareUk.Code = null;
            this.aStateShareUk.Enabled = true;
            this.aStateShareUk.MakeDisabledOnExec = true;
            // 
            // aAppointment
            // 
            this.aAppointment.Caption = null;
            this.aAppointment.Category = null;
            this.aAppointment.Code = null;
            this.aAppointment.Enabled = true;
            this.aAppointment.MakeDisabledOnExec = true;
            // 
            // aRepKnd
            // 
            this.aRepKnd.Caption = null;
            this.aRepKnd.Category = null;
            this.aRepKnd.Code = null;
            this.aRepKnd.Enabled = true;
            this.aRepKnd.MakeDisabledOnExec = true;
            // 
            // aSignatory
            // 
            this.aSignatory.Caption = null;
            this.aSignatory.Category = null;
            this.aSignatory.Code = null;
            this.aSignatory.Enabled = true;
            this.aSignatory.MakeDisabledOnExec = true;
            // 
            // aExecutor
            // 
            this.aExecutor.Caption = null;
            this.aExecutor.Category = null;
            this.aExecutor.Code = "aExecutor";
            this.aExecutor.Enabled = true;
            this.aExecutor.MakeDisabledOnExec = true;
            this.aExecutor.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aExecutor_Execute);
            // 
            // aCatHolderEcb
            // 
            this.aCatHolderEcb.Caption = null;
            this.aCatHolderEcb.Category = null;
            this.aCatHolderEcb.Code = null;
            this.aCatHolderEcb.Enabled = true;
            this.aCatHolderEcb.MakeDisabledOnExec = true;
            // 
            // aIssueStsECB
            // 
            this.aIssueStsECB.Caption = null;
            this.aIssueStsECB.Category = null;
            this.aIssueStsECB.Code = null;
            this.aIssueStsECB.Enabled = true;
            this.aIssueStsECB.MakeDisabledOnExec = true;
            // 
            // aIssuersGCB
            // 
            this.aIssuersGCB.Caption = null;
            this.aIssuersGCB.Category = null;
            this.aIssuersGCB.Code = null;
            this.aIssuersGCB.Enabled = true;
            this.aIssuersGCB.MakeDisabledOnExec = true;
            // 
            // aKindGCB
            // 
            this.aKindGCB.Caption = null;
            this.aKindGCB.Category = null;
            this.aKindGCB.Code = null;
            this.aKindGCB.Enabled = true;
            this.aKindGCB.MakeDisabledOnExec = true;
            // 
            // aDebtRepayment
            // 
            this.aDebtRepayment.Caption = null;
            this.aDebtRepayment.Category = null;
            this.aDebtRepayment.Code = null;
            this.aDebtRepayment.Enabled = true;
            this.aDebtRepayment.MakeDisabledOnExec = true;
            // 
            // aStsReport
            // 
            this.aStsReport.Caption = null;
            this.aStsReport.Category = null;
            this.aStsReport.Code = null;
            this.aStsReport.Enabled = true;
            this.aStsReport.MakeDisabledOnExec = true;
            // 
            // aKindRegBonds
            // 
            this.aKindRegBonds.Caption = null;
            this.aKindRegBonds.Category = null;
            this.aKindRegBonds.Code = null;
            this.aKindRegBonds.Enabled = true;
            this.aKindRegBonds.MakeDisabledOnExec = true;
            // 
            // aArticlesKOAP
            // 
            this.aArticlesKOAP.Caption = null;
            this.aArticlesKOAP.Category = null;
            this.aArticlesKOAP.Code = null;
            this.aArticlesKOAP.Enabled = true;
            this.aArticlesKOAP.MakeDisabledOnExec = true;
            // 
            // aCauseChangesRep
            // 
            this.aCauseChangesRep.Caption = null;
            this.aCauseChangesRep.Category = null;
            this.aCauseChangesRep.Code = null;
            this.aCauseChangesRep.Enabled = true;
            this.aCauseChangesRep.MakeDisabledOnExec = true;
            // 
            // aSuspension
            // 
            this.aSuspension.Caption = null;
            this.aSuspension.Category = null;
            this.aSuspension.Code = null;
            this.aSuspension.Enabled = true;
            this.aSuspension.MakeDisabledOnExec = true;
            // 
            // aCountry
            // 
            this.aCountry.Caption = null;
            this.aCountry.Category = null;
            this.aCountry.Code = null;
            this.aCountry.Enabled = true;
            this.aCountry.MakeDisabledOnExec = true;
            // 
            // aDecisionAdmOffences
            // 
            this.aDecisionAdmOffences.Caption = null;
            this.aDecisionAdmOffences.Category = null;
            this.aDecisionAdmOffences.Code = null;
            this.aDecisionAdmOffences.Enabled = true;
            this.aDecisionAdmOffences.MakeDisabledOnExec = true;
            // 
            // aFormCollection
            // 
            this.aFormCollection.Caption = null;
            this.aFormCollection.Category = null;
            this.aFormCollection.Code = null;
            this.aFormCollection.Enabled = true;
            this.aFormCollection.MakeDisabledOnExec = true;
            // 
            // aJurPersSts
            // 
            this.aJurPersSts.Caption = null;
            this.aJurPersSts.Category = null;
            this.aJurPersSts.Code = null;
            this.aJurPersSts.Enabled = true;
            this.aJurPersSts.MakeDisabledOnExec = true;
            // 
            // aReasonAnnulECB
            // 
            this.aReasonAnnulECB.Caption = null;
            this.aReasonAnnulECB.Category = null;
            this.aReasonAnnulECB.Code = null;
            this.aReasonAnnulECB.Enabled = true;
            this.aReasonAnnulECB.MakeDisabledOnExec = true;
            // 
            // aUnitDimPerECB
            // 
            this.aUnitDimPerECB.Caption = null;
            this.aUnitDimPerECB.Category = null;
            this.aUnitDimPerECB.Code = null;
            this.aUnitDimPerECB.Enabled = true;
            this.aUnitDimPerECB.MakeDisabledOnExec = true;
            // 
            // aJurPersCreateMethod
            // 
            this.aJurPersCreateMethod.Caption = null;
            this.aJurPersCreateMethod.Category = null;
            this.aJurPersCreateMethod.Code = null;
            this.aJurPersCreateMethod.Enabled = true;
            this.aJurPersCreateMethod.MakeDisabledOnExec = true;
            // 
            // aMethodLocalECB
            // 
            this.aMethodLocalECB.Caption = null;
            this.aMethodLocalECB.Category = null;
            this.aMethodLocalECB.Code = null;
            this.aMethodLocalECB.Enabled = true;
            this.aMethodLocalECB.MakeDisabledOnExec = true;
            // 
            // aPlaceAccommECB
            // 
            this.aPlaceAccommECB.Caption = null;
            this.aPlaceAccommECB.Category = null;
            this.aPlaceAccommECB.Code = null;
            this.aPlaceAccommECB.Enabled = true;
            this.aPlaceAccommECB.MakeDisabledOnExec = true;
            // 
            // aReasonChangeShareIssue
            // 
            this.aReasonChangeShareIssue.Caption = null;
            this.aReasonChangeShareIssue.Category = null;
            this.aReasonChangeShareIssue.Code = null;
            this.aReasonChangeShareIssue.Enabled = true;
            this.aReasonChangeShareIssue.MakeDisabledOnExec = true;
            // 
            // aStsStAccommECB
            // 
            this.aStsStAccommECB.Caption = null;
            this.aStsStAccommECB.Category = null;
            this.aStsStAccommECB.Code = null;
            this.aStsStAccommECB.Enabled = true;
            this.aStsStAccommECB.MakeDisabledOnExec = true;
            // 
            // aDecVerifInf
            // 
            this.aDecVerifInf.Caption = null;
            this.aDecVerifInf.Category = null;
            this.aDecVerifInf.Code = null;
            this.aDecVerifInf.Enabled = true;
            this.aDecVerifInf.MakeDisabledOnExec = true;
            // 
            // aBasePrescription
            // 
            this.aBasePrescription.Caption = null;
            this.aBasePrescription.Category = null;
            this.aBasePrescription.Code = null;
            this.aBasePrescription.Enabled = true;
            this.aBasePrescription.MakeDisabledOnExec = true;
            // 
            // aViolationKnd
            // 
            this.aViolationKnd.Caption = null;
            this.aViolationKnd.Category = null;
            this.aViolationKnd.Code = null;
            this.aViolationKnd.Enabled = true;
            this.aViolationKnd.MakeDisabledOnExec = true;
            // 
            // aOrganRegIssueECB
            // 
            this.aOrganRegIssueECB.Caption = null;
            this.aOrganRegIssueECB.Category = null;
            this.aOrganRegIssueECB.Code = null;
            this.aOrganRegIssueECB.Enabled = true;
            this.aOrganRegIssueECB.MakeDisabledOnExec = true;
            // 
            // aMRP
            // 
            this.aMRP.Caption = null;
            this.aMRP.Category = null;
            this.aMRP.Code = null;
            this.aMRP.Enabled = true;
            this.aMRP.MakeDisabledOnExec = true;
            // 
            // aResolutionDR
            // 
            this.aResolutionDR.Caption = null;
            this.aResolutionDR.Category = null;
            this.aResolutionDR.Code = null;
            this.aResolutionDR.Enabled = true;
            this.aResolutionDR.MakeDisabledOnExec = true;
            // 
            // aStatusECB
            // 
            this.aStatusECB.Caption = null;
            this.aStatusECB.Category = null;
            this.aStatusECB.Code = null;
            this.aStatusECB.Enabled = true;
            this.aStatusECB.MakeDisabledOnExec = true;
            // 
            // aStatusLicense
            // 
            this.aStatusLicense.Caption = null;
            this.aStatusLicense.Category = null;
            this.aStatusLicense.Code = null;
            this.aStatusLicense.Enabled = true;
            this.aStatusLicense.MakeDisabledOnExec = true;
            // 
            // aCondMonitorValid
            // 
            this.aCondMonitorValid.Caption = null;
            this.aCondMonitorValid.Category = null;
            this.aCondMonitorValid.Code = null;
            this.aCondMonitorValid.Enabled = true;
            this.aCondMonitorValid.MakeDisabledOnExec = true;
            // 
            // aSharer
            // 
            this.aSharer.Caption = null;
            this.aSharer.Category = null;
            this.aSharer.Code = "aSharer";
            this.aSharer.Enabled = true;
            this.aSharer.MakeDisabledOnExec = true;
            this.aSharer.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aSharer_Execute);
            // 
            // aReasonSuspensionECB
            // 
            this.aReasonSuspensionECB.Caption = null;
            this.aReasonSuspensionECB.Category = null;
            this.aReasonSuspensionECB.Code = null;
            this.aReasonSuspensionECB.Enabled = true;
            this.aReasonSuspensionECB.MakeDisabledOnExec = true;
            // 
            // aDecTreadCard
            // 
            this.aDecTreadCard.Caption = null;
            this.aDecTreadCard.Category = null;
            this.aDecTreadCard.Code = null;
            this.aDecTreadCard.Enabled = true;
            this.aDecTreadCard.MakeDisabledOnExec = true;
            // 
            // aProcess
            // 
            this.aProcess.Caption = null;
            this.aProcess.Category = null;
            this.aProcess.Code = null;
            this.aProcess.Enabled = true;
            this.aProcess.MakeDisabledOnExec = true;
            // 
            // aBondRegistry
            // 
            this.aBondRegistry.Caption = null;
            this.aBondRegistry.Category = null;
            this.aBondRegistry.Code = null;
            this.aBondRegistry.Enabled = true;
            this.aBondRegistry.MakeDisabledOnExec = true;
            // 
            // aBondReestr
            // 
            this.aBondReestr.Caption = null;
            this.aBondReestr.Category = null;
            this.aBondReestr.Code = null;
            this.aBondReestr.Enabled = true;
            this.aBondReestr.MakeDisabledOnExec = true;
            // 
            // aBondRefuseJournal
            // 
            this.aBondRefuseJournal.Caption = null;
            this.aBondRefuseJournal.Category = null;
            this.aBondRefuseJournal.Code = null;
            this.aBondRefuseJournal.Enabled = true;
            this.aBondRefuseJournal.MakeDisabledOnExec = true;
            // 
            // aShareJournalReestr
            // 
            this.aShareJournalReestr.Caption = null;
            this.aShareJournalReestr.Category = null;
            this.aShareJournalReestr.Code = "aShareJournalReestr";
            this.aShareJournalReestr.Enabled = true;
            this.aShareJournalReestr.MakeDisabledOnExec = true;
            // 
            // aShareJournalChanges
            // 
            this.aShareJournalChanges.Caption = null;
            this.aShareJournalChanges.Category = null;
            this.aShareJournalChanges.Code = "aShareJournalChanges";
            this.aShareJournalChanges.Enabled = true;
            this.aShareJournalChanges.MakeDisabledOnExec = true;
            // 
            // aShareReestr
            // 
            this.aShareReestr.Caption = null;
            this.aShareReestr.Category = null;
            this.aShareReestr.Code = "aShareReestr";
            this.aShareReestr.Enabled = true;
            this.aShareReestr.MakeDisabledOnExec = true;
            this.aShareReestr.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aShareReestr_Execute);
            // 
            // aShareJournalDenial
            // 
            this.aShareJournalDenial.Caption = null;
            this.aShareJournalDenial.Category = null;
            this.aShareJournalDenial.Code = "aShareJournalDenial";
            this.aShareJournalDenial.Enabled = true;
            this.aShareJournalDenial.MakeDisabledOnExec = true;
            this.aShareJournalDenial.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aShareJournalDenial_Execute);
            // 
            // aKazDepRecReestr
            // 
            this.aKazDepRecReestr.Caption = null;
            this.aKazDepRecReestr.Category = null;
            this.aKazDepRecReestr.Code = "aKazDepRecReestr";
            this.aKazDepRecReestr.Enabled = true;
            this.aKazDepRecReestr.MakeDisabledOnExec = true;
            this.aKazDepRecReestr.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aKazDepRecReestr_Execute);
            // 
            // aKazDepRecJournalDenial
            // 
            this.aKazDepRecJournalDenial.Caption = null;
            this.aKazDepRecJournalDenial.Category = null;
            this.aKazDepRecJournalDenial.Code = "aKazDepRecJournalDenial";
            this.aKazDepRecJournalDenial.Enabled = true;
            this.aKazDepRecJournalDenial.MakeDisabledOnExec = true;
            this.aKazDepRecJournalDenial.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aKazDepRecJournalDenial_Execute);
            // 
            // aIslamSecReestr
            // 
            this.aIslamSecReestr.Caption = null;
            this.aIslamSecReestr.Category = null;
            this.aIslamSecReestr.Code = "aIslamSecReestr";
            this.aIslamSecReestr.Enabled = true;
            this.aIslamSecReestr.MakeDisabledOnExec = true;
            this.aIslamSecReestr.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aIslamSecReestr_Execute);
            // 
            // aPaiReestr
            // 
            this.aPaiReestr.Caption = null;
            this.aPaiReestr.Category = null;
            this.aPaiReestr.Code = null;
            this.aPaiReestr.Enabled = true;
            this.aPaiReestr.MakeDisabledOnExec = true;
            // 
            // aPermJournal
            // 
            this.aPermJournal.Caption = null;
            this.aPermJournal.Category = null;
            this.aPermJournal.Code = null;
            this.aPermJournal.Enabled = true;
            this.aPermJournal.MakeDisabledOnExec = true;
            // 
            // aPermRegRefuse
            // 
            this.aPermRegRefuse.Caption = null;
            this.aPermRegRefuse.Category = null;
            this.aPermRegRefuse.Code = null;
            this.aPermRegRefuse.Enabled = true;
            this.aPermRegRefuse.MakeDisabledOnExec = true;
            // 
            // aPaiRefuse
            // 
            this.aPaiRefuse.Caption = null;
            this.aPaiRefuse.Category = null;
            this.aPaiRefuse.Code = null;
            this.aPaiRefuse.Enabled = true;
            this.aPaiRefuse.MakeDisabledOnExec = true;
            // 
            // aKndSanctions
            // 
            this.aKndSanctions.Caption = null;
            this.aKndSanctions.Category = null;
            this.aKndSanctions.Code = "aKndSanctions";
            this.aKndSanctions.Enabled = true;
            this.aKndSanctions.MakeDisabledOnExec = true;
            this.aKndSanctions.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aKndSanction_Execute);
            // 
            // aIslamSecJournalDenial
            // 
            this.aIslamSecJournalDenial.Caption = null;
            this.aIslamSecJournalDenial.Category = null;
            this.aIslamSecJournalDenial.Code = "aIslamSecJournalDenial";
            this.aIslamSecJournalDenial.Enabled = true;
            this.aIslamSecJournalDenial.MakeDisabledOnExec = true;
            this.aIslamSecJournalDenial.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aIslamSecJournalDenial_Execute);
            // 
            // aGovSecResstr
            // 
            this.aGovSecResstr.Caption = null;
            this.aGovSecResstr.Category = null;
            this.aGovSecResstr.Code = "aGovSecResstr";
            this.aGovSecResstr.Enabled = true;
            this.aGovSecResstr.MakeDisabledOnExec = true;
            this.aGovSecResstr.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aGovSecResstr_Execute);
            // 
            // aIssuer
            // 
            this.aIssuer.Caption = null;
            this.aIssuer.Category = null;
            this.aIssuer.Code = null;
            this.aIssuer.Enabled = true;
            this.aIssuer.MakeDisabledOnExec = true;
            // 
            // aBondCorrection
            // 
            this.aBondCorrection.Caption = null;
            this.aBondCorrection.Category = null;
            this.aBondCorrection.Code = null;
            this.aBondCorrection.Enabled = true;
            this.aBondCorrection.MakeDisabledOnExec = true;
            // 
            // aRepForm
            // 
            this.aRepForm.Caption = null;
            this.aRepForm.Category = null;
            this.aRepForm.Code = "aRepForm";
            this.aRepForm.Enabled = true;
            this.aRepForm.MakeDisabledOnExec = true;
            this.aRepForm.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aRepForm_Execute);
            // 
            // aPaiCorrection
            // 
            this.aPaiCorrection.Caption = null;
            this.aPaiCorrection.Category = null;
            this.aPaiCorrection.Code = null;
            this.aPaiCorrection.Enabled = true;
            this.aPaiCorrection.MakeDisabledOnExec = true;
            // 
            // aDepRepJournal
            // 
            this.aDepRepJournal.Caption = null;
            this.aDepRepJournal.Category = null;
            this.aDepRepJournal.Code = null;
            this.aDepRepJournal.Enabled = true;
            this.aDepRepJournal.MakeDisabledOnExec = true;
            // 
            // aCorrectionDepRep
            // 
            this.aCorrectionDepRep.Caption = null;
            this.aCorrectionDepRep.Category = null;
            this.aCorrectionDepRep.Code = null;
            this.aCorrectionDepRep.Enabled = true;
            this.aCorrectionDepRep.MakeDisabledOnExec = true;
            // 
            // aCorrectionPerm
            // 
            this.aCorrectionPerm.Caption = null;
            this.aCorrectionPerm.Category = null;
            this.aCorrectionPerm.Code = null;
            this.aCorrectionPerm.Enabled = true;
            this.aCorrectionPerm.MakeDisabledOnExec = true;
            // 
            // aCorrectionShare
            // 
            this.aCorrectionShare.Caption = null;
            this.aCorrectionShare.Category = null;
            this.aCorrectionShare.Code = null;
            this.aCorrectionShare.Enabled = true;
            this.aCorrectionShare.MakeDisabledOnExec = true;
            // 
            // aCorrectionKdr
            // 
            this.aCorrectionKdr.Caption = null;
            this.aCorrectionKdr.Category = null;
            this.aCorrectionKdr.Code = null;
            this.aCorrectionKdr.Enabled = true;
            this.aCorrectionKdr.MakeDisabledOnExec = true;
            // 
            // aCorrectionGovSec
            // 
            this.aCorrectionGovSec.Caption = null;
            this.aCorrectionGovSec.Category = null;
            this.aCorrectionGovSec.Code = null;
            this.aCorrectionGovSec.Enabled = true;
            this.aCorrectionGovSec.MakeDisabledOnExec = true;
            // 
            // aCorrectionIslam
            // 
            this.aCorrectionIslam.Caption = null;
            this.aCorrectionIslam.Category = null;
            this.aCorrectionIslam.Code = null;
            this.aCorrectionIslam.Enabled = true;
            this.aCorrectionIslam.MakeDisabledOnExec = true;
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
            // aViolation
            // 
            this.aViolation.Caption = null;
            this.aViolation.Category = null;
            this.aViolation.Code = null;
            this.aViolation.Enabled = true;
            this.aViolation.MakeDisabledOnExec = true;
            // 
            // aViolCapSize
            // 
            this.aViolCapSize.Caption = null;
            this.aViolCapSize.Category = null;
            this.aViolCapSize.Code = "aViolCapSize";
            this.aViolCapSize.Enabled = true;
            this.aViolCapSize.MakeDisabledOnExec = true;
            this.aViolCapSize.Execute += new BSB.Actions.MyAction.ExecuteDelegate(this.aViolCapSize_Execute);
            // 
            // aViolIssueReport
            // 
            this.aViolIssueReport.Caption = null;
            this.aViolIssueReport.Category = null;
            this.aViolIssueReport.Code = null;
            this.aViolIssueReport.Enabled = true;
            this.aViolIssueReport.MakeDisabledOnExec = true;
            // 
            // aViolRpmReport
            // 
            this.aViolRpmReport.Caption = null;
            this.aViolRpmReport.Category = null;
            this.aViolRpmReport.Code = null;
            this.aViolRpmReport.Enabled = true;
            this.aViolRpmReport.MakeDisabledOnExec = true;
            // 
            // aViolEnforc
            // 
            this.aViolEnforc.Caption = null;
            this.aViolEnforc.Category = null;
            this.aViolEnforc.Code = null;
            this.aViolEnforc.Enabled = true;
            this.aViolEnforc.MakeDisabledOnExec = true;
            // 
            // aViolSanctions
            // 
            this.aViolSanctions.Caption = null;
            this.aViolSanctions.Category = null;
            this.aViolSanctions.Code = null;
            this.aViolSanctions.Enabled = true;
            this.aViolSanctions.MakeDisabledOnExec = true;
            // 
            // aViolRefuseDoc
            // 
            this.aViolRefuseDoc.Caption = null;
            this.aViolRefuseDoc.Category = null;
            this.aViolRefuseDoc.Code = null;
            this.aViolRefuseDoc.Enabled = true;
            this.aViolRefuseDoc.MakeDisabledOnExec = true;
            // 
            // aCorrectionViolation
            // 
            this.aCorrectionViolation.Caption = null;
            this.aCorrectionViolation.Category = null;
            this.aCorrectionViolation.Code = null;
            this.aCorrectionViolation.Enabled = true;
            this.aCorrectionViolation.MakeDisabledOnExec = true;
            // 
            // aStatusLoadToSaid
            // 
            this.aStatusLoadToSaid.Caption = null;
            this.aStatusLoadToSaid.Category = null;
            this.aStatusLoadToSaid.Code = null;
            this.aStatusLoadToSaid.Enabled = true;
            this.aStatusLoadToSaid.MakeDisabledOnExec = true;
            // 
            // aGovSecJournalStatus
            // 
            this.aGovSecJournalStatus.Caption = null;
            this.aGovSecJournalStatus.Category = null;
            this.aGovSecJournalStatus.Code = null;
            this.aGovSecJournalStatus.Enabled = true;
            this.aGovSecJournalStatus.MakeDisabledOnExec = true;
            // 
            // aShareAffiliatesInfo
            // 
            this.aShareAffiliatesInfo.Caption = null;
            this.aShareAffiliatesInfo.Category = null;
            this.aShareAffiliatesInfo.Code = null;
            this.aShareAffiliatesInfo.Enabled = true;
            this.aShareAffiliatesInfo.MakeDisabledOnExec = true;
            // 
            // aDefaultList
            // 
            this.aDefaultList.Caption = null;
            this.aDefaultList.Category = null;
            this.aDefaultList.Code = null;
            this.aDefaultList.Enabled = true;
            this.aDefaultList.MakeDisabledOnExec = true;
            // 
            // aFounderList
            // 
            this.aFounderList.Caption = null;
            this.aFounderList.Category = null;
            this.aFounderList.Code = null;
            this.aFounderList.Enabled = true;
            this.aFounderList.MakeDisabledOnExec = true;
            // 
            // aAssignee
            // 
            this.aAssignee.Caption = null;
            this.aAssignee.Category = null;
            this.aAssignee.Code = null;
            this.aAssignee.Enabled = true;
            this.aAssignee.MakeDisabledOnExec = true;
            // 
            // aProvisionKnd
            // 
            this.aProvisionKnd.Caption = null;
            this.aProvisionKnd.Category = null;
            this.aProvisionKnd.Code = null;
            this.aProvisionKnd.Enabled = true;
            this.aProvisionKnd.MakeDisabledOnExec = true;
            // 
            // aAssets
            // 
            this.aAssets.Caption = null;
            this.aAssets.Category = null;
            this.aAssets.Code = null;
            this.aAssets.Enabled = true;
            this.aAssets.MakeDisabledOnExec = true;
            // 
            // aPeriodicity
            // 
            this.aPeriodicity.Caption = null;
            this.aPeriodicity.Category = null;
            this.aPeriodicity.Code = null;
            this.aPeriodicity.Enabled = true;
            this.aPeriodicity.MakeDisabledOnExec = true;
            // 
            // aProtocolIsin
            // 
            this.aProtocolIsin.Caption = null;
            this.aProtocolIsin.Category = null;
            this.aProtocolIsin.Code = null;
            this.aProtocolIsin.Enabled = true;
            this.aProtocolIsin.MakeDisabledOnExec = true;
            // 
            // myAction1
            // 
            this.myAction1.Caption = null;
            this.myAction1.Category = null;
            this.myAction1.Code = null;
            this.myAction1.Enabled = true;
            this.myAction1.MakeDisabledOnExec = true;
            // 
            // myAction2
            // 
            this.myAction2.Caption = null;
            this.myAction2.Category = null;
            this.myAction2.Code = null;
            this.myAction2.Enabled = true;
            this.myAction2.MakeDisabledOnExec = true;
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
            // tmCheckGovSec
            // 
            this.tmCheckGovSec.Enabled = true;
            this.tmCheckGovSec.Interval = 5000D;
            this.tmCheckGovSec.SynchronizingObject = this;
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
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(599, 415);
            this.Controls.Add(this.tcMDIChildren);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDockManager)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dpMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dpMessages.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIdle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmCheckGovSec)).EndInit();
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
        case (int) WinMessage.WM_ACTIVATEAPP:
          OnWMActivateApp(ref m);
          break;
        case (int) WinMessage.WM_QUERYOPEN:
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

    private const int WM_AFTERSHOW = (Int32) WinMessage.WM_USER + 1;
    private MyAction aChangePassword;
    private MyAction aConnect;
    public MyAction aDisconnect;
    private MyAction aLockApplication;
    private MyAction aRefreshOfficRights;
    private MyAction aSetCurrentLanguage;
    private Bar bar1;
    private Bar bar2;
    private Bar bar3;
    private BarButtonItem barButtonItemMenuPanel;
    private BarButtonItem barButtonItemMsgPanel;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarDockControl barDockControlTop;
    private BarStaticItem barHint;
    private BarMdiChildrenListItem BarMdiChildrenListItem;
    private BarSubItem BarSubItem1;
    private BarSubItem BarSubItem2;
    private BarSubItem barSubItemView;
    private GridColumn colStatus;
    private GridColumn colText;
    private GridColumn colType;
    private IContainer components;
    private ControlContainer controlContainer1;
    private DefaultLookAndFeel defaultLookAndFeel;
    private ControlContainer dockPanel1_Container;
    private DockPanel dpMenu;
    private DockPanel dpMessages;
    private GridControl gridMessages;
    private BarButtonItem iAbout;
    private BarButtonItem iCascade;
    private BarButtonItem iChangePassword;
    private BarButtonItem iCloseAllWindows;
    private BarButtonItem iConnect;
    private BarButtonItem iDisconnect;
    private BarButtonItem iExit;
    private BarButtonItem iLockApplication;
    private BarButtonItem iMenuCollapse;
    private BarButtonItem iMenuCollapseNode;
    private BarButtonItem iMenuExpand;
    private BarButtonItem iMenuExpandNode;
    public ImageList imMain;
    private ImageCollection imMessages;
    private BarButtonItem InfoGuide;
    private BarSubItem iPaintStyle;
    private BarButtonItem ipsO2003;
    private BarButtonItem ipsO2K;
    private BarButtonItem ipsOXP;
    private BarButtonItem ipsWXP;
    private BarButtonItem iRefresh;
    private BarButtonItem iSAsphaltWorld;
    private BarButtonItem iSCaramel;
    private BarButtonItem iSCoffee;
    private BarButtonItem iSGlassOceans;
    private BarSubItem iSkins;
    private BarButtonItem iSLiquidSky;
    private BarButtonItem iSLondonLiquidSky;
    private BarButtonItem iSMoneyTwins;
    private BarButtonItem iSStardust;
    private BarButtonItem iTileHorizontal;
    private BarButtonItem iTileVertical;
    private MyActionList MainActionList;
    public BarManager MainBarManager;
    private DockManager MainDockManager;
    private BarSubItem mWindow;
    private PopupMenu popupMenu;
    private RepositoryItemImageComboBox repositoryItemImageComboBox1;
    private RepositoryItemMemoEdit repositoryItemMemoEdit1;
    private RepositoryItemTextEdit repositoryItemTextEdit1;
    private TabControl tcMDIChildren;
    public Timer tmCheckInterval;
    public Timer tmIdle;
    private ToolTipController toolTipController;
    private TreeView tvMenu;
    private GridView viewMessages;
    private MyAction aFundKnd;
    private MyAction aIssueECB;
    private MyAction aCurrencyECB;
    private MyAction aIssuersGuidesList;
    private MyAction aBankCust;
    private MyAction aClassifierOKED;
    private MyAction aSpecBus;
    private MyAction aSignPartNores;
    private MyAction aCategoryControls;
    private MyAction aSpecIssuer;
    private MyAction aAbilityConvert;
    private MyAction aKindECB;
    private MyAction aIssOrganCont;
    private MyAction aDateTypeLocal;
    private MyAction aDocKnd;
    private MyAction aAddCategoryShare;
    private MyAction aCategoryECB;
    private MyAction aIndexRewards;
    private MyAction aProcessknd;
    private MyAction aProcess;
    private MyAction aOLF;
    private MyAction aListing;
    private MyAction aRating;
    private MyAction aRegOrganMU;
    private MyAction aStateShareUk;
    private MyAction aAppointment;
    private MyAction aRepKnd;
    private MyAction aSignatory;
    private MyAction aExecutor;
    private MyAction aCatHolderEcb;
    private MyAction aIssueStsECB;
    private MyAction aIssuersGCB;
    private MyAction aKindGCB;
    private MyAction aDebtRepayment;
    private MyAction aStsReport;
    private MyAction aKindRegBonds;
    private MyAction aArticlesKOAP;
    private MyAction aCauseChangesRep;
    private MyAction aSuspension;
    private MyAction aCountry;
    private MyAction aDecisionAdmOffences;
    private MyAction aFormCollection;
    private MyAction aJurPersSts;
    private MyAction aReasonAnnulECB;
    private MyAction aUnitDimPerECB;
    private MyAction aJurPersCreateMethod;
    private MyAction aMethodLocalECB;
    private MyAction aPlaceAccommECB;
    private MyAction aReasonChangeShareIssue;
    private MyAction aStsStAccommECB;
    private MyAction aDecVerifInf;
    private MyAction aBasePrescription;
    private MyAction aViolationKnd;
    private MyAction aOrganRegIssueECB;
    private MyAction aMRP;
    private MyAction aResolutionDR;
    private MyAction aStatusECB;
    private MyAction aStatusLicense;
    private MyAction aCondMonitorValid;
    private MyAction aSharer;
    private MyAction aReasonSuspensionECB;
    private MyAction aDecTreadCard;
    private MyAction aReg;
    private MyAction aRegion;
    private MyAction aAudit;
    private MyAction aBondRegistry;
    private MyAction aBondReestr;
    private MyAction aBondRefuseJournal;
    private AutoHideContainer hideContainerLeft;
    private MyAction aShareJournalReestr;
    private MyAction aShareJournalChanges;
    private MyAction aShareReestr;
    private MyAction aShareJournalDenial;
    private MyAction aKazDepRecReestr;
    private MyAction aKazDepRecJournalDenial;
    private MyAction aIslamSecReestr;
    private MyAction aPaiReestr;
    private MyAction aPermJournal;
    private MyAction aPaiRefuse;
    private MyAction aRepForm;
    private MyAction aKndSanctions;
    private MyAction aIslamSecJournalDenial;
    private MyAction aGovSecResstr;
    private MyAction aPermRegRefuse;
    private MyAction aIssuer;
    private MyAction aBondCorrection;
    private MyAction aPaiCorrection;
    private MyAction aDepRepJournal;
    private MyAction aCorrectionDepRep;
    private MyAction aCorrectionPerm;
    private MyAction aCorrectionShare;
    private MyAction aCorrectionKdr;
    private MyAction aCorrectionGovSec;
    private MyAction aCorrectionIslam;
    private BarButtonItem barButtonItem1;
    private BarSubItem barSubItem4;
    private BarSubItem barSubItem3;
    private BarSubItem barSubItem5;
    private BarCheckItem barCheckRu;
    private BarCheckItem barCheckKz;
    private MyAction aKazLang;
    private MyAction aRuLang;
    private MyAction aViolation;
    private MyAction aViolCapSize;
    private MyAction aViolIssueReport;
    private MyAction aViolRpmReport;
    private MyAction aViolEnforc;
    private MyAction aViolSanctions;
    private MyAction aViolRefuseDoc;
    private BarButtonItem barBtnSetTimesLoad;
    private MyAction aCorrectionViolation;
    private MyAction aDefaultList;
    private readonly string xmlPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Xml\";

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
            MessageBox.Show("OK");
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
      //dpMessages.Visibility = DockVisibility.AutoHide;        
      dmControler.Init(this);
      MainBarManager.Images = dmControler.frmMain.imMain;
      tcMDIChildren.ImageList = dmControler.frmMain.imMain;
      tvMenu.ImageList = dmControler.frmMain.imMain;
      Text = InitApplication.AppTitle;
      barHint.Caption = string.Format(LangTranslate.UiGetText("Версия: {0}"), Application.ProductVersion);
      InitBars();
      InitDockPanels();
      // Устанавливаем стиль приложения
      defaultLookAndFeel.LookAndFeel.SetStyle(InitApplication.style, InitApplication.useWindowsXPTheme,
        InitApplication.useDefaultLookAndFeel, InitApplication.skinName);

      switch (InitApplication.style)
      {
        case LookAndFeelStyle.Flat:
          ipsWXP.Down = true;
          break;
        case LookAndFeelStyle.UltraFlat:
          ipsOXP.Down = true;
          break;
        case LookAndFeelStyle.Style3D:
          ipsO2K.Down = true;
          break;
        case LookAndFeelStyle.Office2003:
          ipsO2003.Down = true;
          break;
        default:
          switch (InitApplication.skinName)
          {
            case "Caramel":
              iSCaramel.Down = true;
              break;
            case "The Asphalt World":
              iSAsphaltWorld.Down = true;
              break;
            case "Liquid Sky":
              iSLiquidSky.Down = true;
              break;
            case "Coffee":
              iSCoffee.Down = true;
              break;
            case "Stardust":
              iSStardust.Down = true;
              break;
            case "Glass Oceans":
              iSGlassOceans.Down = true;
              break;
            case "Money Twins":
              iSMoneyTwins.Down = true;
              break;
            case "London Liquid Sky":
              iSLondonLiquidSky.Down = true;
              break;
            default:
              break;
          }
          break;
      }
      ;

      if (SkinManager.AllowFormSkins)
        SkinManager.DisableFormSkins();
      else
        SkinManager.EnableFormSkins();
      LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

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
      MainBarManager.BeginUpdate();
      MainBarManager.EndUpdate();

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
       aRuLang.OnExecute();
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
          if (!((MDIChildForm) Children).CanClose())
            return;

      // Закрываем все активные окна
      foreach (var Children in MdiChildren)
        Children.Close();

      // Прячем Меню
      dpMenu.Visibility = DockVisibility.AutoHide;

      // Прячем панель сообщений
      dpMessages.Visibility = DockVisibility.Hidden;

      // Отключаемся от БД}
      //if (dmControler.frmMain.oracleConnection.State != ConnectionState.Closed)
     // {   
      
      
     // }

      SetConnectActions(false);

      // Уничтожаем меню
      DestroyMenu();

      // Уничтожаем панель сообщений
      DestroyMsgPanel();
      Text = InitApplication.AppTitle;

      if (!DBSupport.DisconnectFromOracle(dmControler.frmMain.oracleConnection))
          return;
    }

    /// <summary>
    ///   Подключение к БД
    /// </summary>
    private void aConnectExecute(object sender, TActionEventArgs e)
    {
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
        // Beles  DBSupport.CorrectCurrOfficGrants(dmControler.frmMain.oracleConnection);
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
      dpMenu.Visibility = DockVisibility.Visible;

      // Создаем панель сообщений
      CreateMsgPanel();

      // Показываем панель сообщений
      if (viewMessages.RowCount > 0)
        dpMessages.Visibility = DockVisibility.Hidden;
      else
        dpMessages.Visibility = DockVisibility.Hidden;

      Text = String.Format(LangTranslate.UiGetText("{0} [ пользователь - {1}@{2} ]"),
        LangTranslate.UiGetText(InitApplication.AppTitle), DBSupport.GetOfficialName(), dmControler.frmMain.DBDatabase);

      DBSupport.SetParams();

      // Читаем интервал неактивности до блокировки приложения
      var par = new TPkgParams();
      par.oc = dmControler.frmMain.oracleConnection;
      tmIdle.Interval = Int32.Parse(par.GetSystemSetupParam("APPLICATION_LOCK_INTERVAL"))*1000;
      tmCheckInterval.Interval = 1*1000;

      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
      if (!RightsItemChecking.GetRightsItem(100434))
          barBtnSetTimesLoad.Visibility = BarItemVisibility.Never;

    }

    #endregion

    #region [Создание, уничтожение и работа с панелью сообщений]

    private void CreateMsgPanel()
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
    }

    private void AddMessageToMsgPanel(ref DataTable dt_, Int32 status, string type, string text)
    {
      dt_.BeginLoadData();
      dt_.LoadDataRow(new object[] {status, type, text}, false);
      dt_.EndLoadData();
    }

    private void DestroyMsgPanel()
    {
      if (gridMessages.DataSource != null)
        ((DataTable) gridMessages.DataSource).Clear();
    }

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

    private void iMenuExpand_ItemClick(object sender, ItemClickEventArgs e)
    {
      tvMenu.ExpandAll();
    }

    private void iMenuCollapse_ItemClick(object sender, ItemClickEventArgs e)
    {
      tvMenu.CollapseAll();
    }

    private void iMenuExpandNode_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (tvMenu.SelectedNode != null)
        tvMenu.SelectedNode.Expand();
    }

    private void iMenuCollapseNode_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (tvMenu.SelectedNode != null)
        tvMenu.SelectedNode.Collapse();
    }

    private void tvMenu_AfterCollapse(object sender, TreeViewEventArgs e)
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
    }

    private void tvMenu_AfterExpand(object sender, TreeViewEventArgs e)
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
    }

    private TreeNode FindParentNode(TreeView tr, TreeNode node, Int32 ParentID)
    {
      TreeNode oResult = null;

      if (node == null)
      {
        foreach (TreeNode CurNode in tr.Nodes)
        {
          var mdata = (TMenuData) CurNode.Tag;
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
          var mdata = (TMenuData) CurNode.Tag;
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
        var md = (TMenuData) node.Tag;
        if (md.pAction != null)
        {
            if (md.pAction.Enabled)
            {
                //if (md.pAction.MakeDisabledOnExec)
                //{
                //    node.ForeColor = Color.FromArgb(100, 100, 100);
                //    md.pAction.Enabled = false;
                //}

                foreach (TabPage tp in tcMDIChildren.TabPages)
                {
                    if (tp.Tag == md.pForm)
                    {
                        UserSelTab = false;
                        tcMDIChildren.SelectedTab = tp;
                        tcMDIChildren_SelectedIndexChanged(sender,e);
                        IsExecute = false; ;
                        return;
                    }
                }
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
      var appActive = (((int) m.WParam != 0));

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
      tcMDIChildren.TabPages.Add(tp);
      tp.Text = LangTranslate.UiGetText(tp.Text);
    }

    private void win_Closed(object sender, EventArgs e)
    {
      foreach (TabPage tp in tcMDIChildren.TabPages)
      {
        if (tp.Tag == sender)
        {
          UserSelTab = false;
          tcMDIChildren.TabPages.Remove(tp);
        }
      }
    }

    private void win_Activated(object sender, EventArgs e)
    {
      if (!UserWinActivate)
      {
        UserWinActivate = true;
        return;
      }

      foreach (TabPage tp in tcMDIChildren.TabPages)
      {
        if (tp.Tag == sender)
        {
          UserSelTab = false;
          tcMDIChildren.SelectedTab = tp;
        }
      }
    }

    private void tcMDIChildren_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!UserSelTab)
      {
        UserSelTab = true;
        return;
      }

      if (tcMDIChildren.SelectedTab == null) return;

      var fr = (Form) tcMDIChildren.SelectedTab.Tag;
      UserWinActivate = false;
      fr.Activate();
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
          DestroyMsgPanel();
          // Создаем меню
          CreateMenu();
          // Создаем панель сообщений
          CreateMsgPanel();
          // Показываем панель сообщений
          if (viewMessages.RowCount > 0)
            dpMessages.Visibility = DockVisibility.Hidden;
          else
            dpMessages.Visibility = DockVisibility.Hidden;
        }
      }
      else
      {
        // Уничтожаем меню
        DestroyMenu();
        // Уничтожаем панель сообщений
        DestroyMsgPanel();
        // Создаем меню
        CreateMenu();
        // Создаем панель сообщений
        CreateMsgPanel();
        // Показываем панель сообщений
        if (viewMessages.RowCount > 0)
            dpMessages.Visibility = DockVisibility.Hidden;
        else
            dpMessages.Visibility = DockVisibility.Hidden;
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

    private void iSkins_ItemClick(object sender, ItemClickEventArgs e)
    {
      defaultLookAndFeel.LookAndFeel.Style = LookAndFeelStyle.Skin;
      defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;

      InitApplication.style = LookAndFeelStyle.Skin;
      InitApplication.skinName = e.Item.Caption;
    }

    private void ips_ItemClick(object sender, ItemClickEventArgs e)
    {
      switch (e.Item.Description)
      {
        case "WindowsXP":
          defaultLookAndFeel.LookAndFeel.Style = LookAndFeelStyle.Flat;
          break;
        case "OfficeXP":
          defaultLookAndFeel.LookAndFeel.Style = LookAndFeelStyle.UltraFlat;
          break;
        case "Office2000":
          defaultLookAndFeel.LookAndFeel.Style = LookAndFeelStyle.Style3D;
          break;
        case "Office2003":
          defaultLookAndFeel.LookAndFeel.Style = LookAndFeelStyle.Office2003;
          break;
        default:
          break;
      }

      InitApplication.style = defaultLookAndFeel.LookAndFeel.Style;
    }

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
      dpMessages.DockManager.SaveToXml(xmlPath + @"MsgPanel_DEFAULT.xml");
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

      iCascade.Enabled = ActiveMdiForm;
      iTileHorizontal.Enabled = ActiveMdiForm;
      iTileVertical.Enabled = ActiveMdiForm;
      iCloseAllWindows.Enabled = ActiveMdiForm;

      if (!ActiveMdiForm)
        tcMDIChildren.Visible = false;
      else if (!tcMDIChildren.Visible)
        tcMDIChildren.Visible = true;
    }

    private void InitDockPanels()
    {
      if (!Directory.Exists(xmlPath))
        Directory.CreateDirectory(xmlPath);
      //TODO:
      //if (File.Exists(xmlPath + @"MsgPanel_DEFAULT.xml"))
      //  dpMessages.DockManager.RestoreFromXml(xmlPath + @"MsgPanel_DEFAULT.xml");
      dpMenu.Visibility = DockVisibility.Hidden;
      dpMessages.Visibility = DockVisibility.Hidden;
    }

    private void dpMenu_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
      switch (dpMenu.Visibility)
      {
        case DockVisibility.Visible:
          barButtonItemMenuPanel.Down = true;
          break;
        case DockVisibility.Hidden:
          barButtonItemMenuPanel.Down = false;
          break;
        default:
          break;
      }
    }

    private void dpMessages_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
      switch (dpMessages.Visibility)
      {
        case DockVisibility.Visible:
          barButtonItemMsgPanel.Down = true;
          break;
        case DockVisibility.Hidden:
          barButtonItemMsgPanel.Down = false;
          break;
        default:
          break;
      }
    }

    private void barButtonItemMenuPanel_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (barButtonItemMenuPanel.Down)
        dpMenu.Visibility = DockVisibility.Visible;
      else
        dpMenu.Visibility = DockVisibility.Hidden;
    }

    private void barButtonItemMsgPanel_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (barButtonItemMsgPanel.Down)
          dpMessages.Visibility = DockVisibility.Hidden;
      else
        dpMessages.Visibility = DockVisibility.Hidden;
    }

    private void iCascade_ItemClick(object sender, ItemClickEventArgs e)
    {
      LayoutMdi(MdiLayout.Cascade);
    }

    private void iTileHorizontal_ItemClick(object sender, ItemClickEventArgs e)
    {
      LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void iTileVertical_ItemClick(object sender, ItemClickEventArgs e)
    {
      LayoutMdi(MdiLayout.TileVertical);
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
          cmd.CommandText = "begin prepared.pkg_lang.current_lang_id := " + (decimal) InitApplication.CurrentLangId +
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

    private void aRefShared_Execute(object sender, TActionEventArgs ae)
    {
        /*var frm = new MakeReportsBaseForm();
        frm.pAction = (MyAction)sender;
        frm.MdiParent = this;
        frm.Show();*/
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
        DestroyMsgPanel();
        CreateMenu();
        CreateMsgPanel();
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
        DestroyMsgPanel();
        CreateMenu();
        CreateMsgPanel();
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
    

    private void aViolCapSize_Execute(object sender, TActionEventArgs ae)
    {
        string msg = Monitoring.Check_CapSize();
        if (msg.Length > 0)
        {
            XtraMessageBox.Show(
            LangTranslate.UiGetText(msg),
            LangTranslate.UiGetText("Проверка на несоответствие уставного капитала АО прошла успешна"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    private void barBtnSetTimesLoad_ItemClick(object sender, ItemClickEventArgs e)
    {
       
    }
    private void tmCheckGovSec_Elapsed(object sender, ElapsedEventArgs e)
    {
      
    }
    public void KillClose()
    {
        foreach (var Children in MdiChildren)
            if (Children is MDIChildForm)
                if (!((MDIChildForm)Children).CanClose())
                    return;
        // Закрываем все активные окна
        foreach (var Children in MdiChildren)
            Children.Close();

        // Прячем Меню
        //dpMenu.Visibility =  DockVisibility.AutoHide;

       // Прячем панель сообщений
       //   dpMessages.Visibility = DockVisibility.Hidden;

       // Отключаемся от БД}
        
        if (!DBSupport.DisconnectFromOracle(dmControler.frmMain.oracleConnection))
            return;
        SetConnectActions(false);
        // Уничтожаем меню
        DestroyMenu();
        // Уничтожаем панель сообщений
        DestroyMsgPanel();
        Text = InitApplication.AppTitle;
    }
    public void CloseSystem()
    {
        
        foreach (var f in MdiChildren)
            f.Close();
        // Уничтожаем меню
        // Создаем меню
        tvMenu.Nodes.Clear();

        CreateMsgPanel();

        // Уничтожаем панель сообщений
        DestroyMsgPanel();        
        // Показываем панель сообщений
        dpMessages.Visibility = 0; 
    }

    private void barCheckRu_CheckedChanged(object sender, ItemClickEventArgs e)
    {

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
      if (m.Msg == (int) WinMessage.WM_MOUSEMOVE || m.Msg == (int) WinMessage.WM_NCMOUSEMOVE ||
          m.Msg == (int) WinMessage.WM_KEYDOWN || m.Msg == (int) WinMessage.WM_SYSKEYDOWN)
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
  #endregion  
}