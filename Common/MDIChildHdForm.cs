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
  ///   Summary description for frmMDIChildHdForm.
  /// </summary>
  public class MDIChildHdForm : XtraForm
  {
    public MDIChildHdForm()
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
        this.components = new System.ComponentModel.Container();
        this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
        this.SuspendLayout();
        // 
        // MDIChildHdForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
        this.ClientSize = new System.Drawing.Size(505, 397);
        this.MaximizeBox = false;
        this.Name = "MDIChildHdForm";
        this.ShowInTaskbar = false;
        this.Text = "MDIChildHdForm";
        this.Closed += new System.EventHandler(this.TfrmMDIChildHdForm_Closed);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TfrmMDIChildHdForm_FormClosing);
        this.Load += new System.EventHandler(this.TfrmMDIChildHdForm_Load);
        this.ResumeLayout(false);

    }

    #endregion

    private void TfrmMDIChildHdForm_Load(object sender, EventArgs e)
    {
      // ѕровер€ем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
      // Ќужно провер€ть в случае наследовани€ форм.
      if (DesignMode) return;

      pParentForm = (MainForm) ParentForm;
      //---- дл€ вызова меню
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

     

      GridUtilities.RestoreGridLayouts(this);

      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this, unTrControls);
    }

    private void iEnableAutoSize_DownChanged(object sender, ItemClickEventArgs e)
    {
      SetFullSize();
    }

    private void ParentMdiClient_Resize(object sender, EventArgs e)
    {
      // ѕровер€ем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
      // Ќужно провер€ть в случае наследовани€ форм.
      if (DesignMode) return;

      SetFullSize();
    }

    private void SetFullSize()
    {
      //if (iEnableAutoSize.Down)
      //{
      //  pAutoSizeEnabled = true;
      //  Bounds = pParentMdiClient.ClientRectangle;
      //}
      //else
      //  pAutoSizeEnabled = false;
    }

    private void TfrmMDIChildHdForm_Closed(object sender, EventArgs e)
    {
      // ѕровер€ем, в каком режиме запущенна форма, если в DesignMode то нечего не делаем.
      // Ќужно провер€ть в случае наследовани€ форм.
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

    private void TfrmMDIChildHdForm_FormClosing(object sender, FormClosingEventArgs e)
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

    private IContainer components;
    protected List<Control> unTrControls;
    public MyAction pAction = null;
    protected bool pAutoSizeEnabled = true;
    private MainForm pParentForm;
    private MdiClient pParentMdiClient;
    protected ToolTipController toolTipController;

    #endregion
  }
}