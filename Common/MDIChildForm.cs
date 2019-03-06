using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ARM_User;
using ARM_User.DisplayLayer.Common;
using ARM_User.Resources;
using BSB.Actions;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for frmMDIChildForm.
  /// </summary>
  public class MDIChildForm : XtraForm
  {
    public MDIChildForm()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      unTrControls = new List<Control>();
    }

    public bool AutoSizeEnabled
    {
      get { return pAutoSizeEnabled; }
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

    #region Windows Form Designer generated code

    /// <summary>
    ///   Required method for Designer support - do not modify
    ///   the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIChildForm));
            this.toolTipController = new DevExpress.Utils.ToolTipController();
            this.iEnableAutoSize = new DevExpress.XtraBars.BarButtonItem();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager = new DevExpress.XtraBars.BarManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // iEnableAutoSize
            // 
            this.iEnableAutoSize.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iEnableAutoSize.Caption = "Автоподгонка окна";
            this.iEnableAutoSize.Down = true;
            this.iEnableAutoSize.Hint = "Включение/выключение автоподгонки окна под размеры экрана";
            this.iEnableAutoSize.Id = 0;
            this.iEnableAutoSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iEnableAutoSize.ImageOptions.Image")));
            this.iEnableAutoSize.ImageOptions.ImageIndex = 0;
            this.iEnableAutoSize.Name = "iEnableAutoSize";
            this.iEnableAutoSize.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.iEnableAutoSize_DownChanged);
            this.iEnableAutoSize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iEnableAutoSize_DownChanged);
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iEnableAutoSize)});
            this.barMenu.Text = "Menu";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(505, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 397);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(505, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 366);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(505, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 366);
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iEnableAutoSize});
            this.barManager.MaxItemId = 1;
            this.barManager.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Never;
            this.barManager.ToolTipController = this.toolTipController;
            // 
            // MDIChildForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(505, 397);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MDIChildForm";
            this.ShowInTaskbar = false;
            this.Text = "MDIChildForm";
            this.Closed += new System.EventHandler(this.TfrmMDIChildForm_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TfrmMDIChildForm_FormClosing);
            this.Load += new System.EventHandler(this.TfrmMDIChildForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private void TfrmMDIChildForm_Load(object sender, EventArgs e)
    {
        try
        {
            // Проверяем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
            // Нужно проверять в случае наследования форм.
            if (DesignMode) return;
            pParentForm = (MainForm)ParentForm;
            //---- для вызова меню
            var md = (TMenuData)pParentForm.GetTvMenu().SelectedNode.Tag;
            md.pForm = this;
            //----



            
                pParentForm.AttachPanelToWindow(this);
                Icon = AppResource.MasterDetail;
            
            


            foreach (Control c in ParentForm.Controls)
            {
                if (c is MdiClient)
                {
                    pParentMdiClient = c as MdiClient;
                    if (c != null)
                    {
                        pParentMdiClient.Resize += ParentMdiClient_Resize;
                        break;
                    }
                }
            }

            if (pAutoSizeEnabled)
            {
                if (!iEnableAutoSize.Down)
                    iEnableAutoSize.Down = true;
                else
                    SetFullSize();
            }
            else
                iEnableAutoSize.Down = false;

            GridUtilities.RestoreGridLayouts(this);

            if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                new LangTranslate().UISetupTexts(this, unTrControls);
        }
        catch (Exception oe)
        {
        }

        }

    private void iEnableAutoSize_DownChanged(object sender, ItemClickEventArgs e)
    {
      SetFullSize();
    }

    private void ParentMdiClient_Resize(object sender, EventArgs e)
    {
      // Проверяем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
      // Нужно проверять в случае наследования форм.
      if (DesignMode) return;

      SetFullSize();
    }

    private void SetFullSize()
    {
      if (iEnableAutoSize.Down)
      {
        pAutoSizeEnabled = true;
        Bounds = pParentMdiClient.ClientRectangle;
      }
      else
        pAutoSizeEnabled = false;
    }

    private void TfrmMDIChildForm_Closed(object sender, EventArgs e)
    {
      // Проверяем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
      // Нужно проверять в случае наследования форм.
      if (DesignMode) return;

      if (pParentMdiClient != null)
        pParentMdiClient.Resize -= ParentMdiClient_Resize;

      if (pAction != null)
        pAction.Enabled = true;

      if (pParentForm != null)
        pParentForm.RepaintMenu();

      GridUtilities.SaveGridLayouts(this);
    }

    protected void CloseWindow()
    {
      BeginInvoke(new DCloseWindow(_CloseWindow));
    }

    private void _CloseWindow()
    {
      Close();
    }

    public virtual bool CanClose()
    {
      return true;
    }

    private void TfrmMDIChildForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (e.CloseReason == CloseReason.UserClosing)
        {
          if (!CanClose())
            e.Cancel = true;
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
        {
          throw;
        }
        e.Cancel = true;
      }
    }

    private delegate void DCloseWindow();

    #region Fields

    protected BarDockControl barDockControlBottom;
    protected BarDockControl barDockControlLeft;
    protected BarDockControl barDockControlRight;
    protected BarDockControl barDockControlTop;
    protected BarManager barManager;
    protected Bar barMenu;
    private IContainer components;
    protected BarButtonItem iEnableAutoSize;
    protected List<Control> unTrControls;
    public MyAction pAction = null;
    protected bool pAutoSizeEnabled = true;
    private MainForm pParentForm;
    private MdiClient pParentMdiClient;
    protected ToolTipController toolTipController;

    #endregion
  }
}