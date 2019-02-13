using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Base
{
  public partial class DBEditBaseForm : BaseDialogForm
  {
    #region Fields
    protected Exception lastException;
    protected List<Control> readOnlyControls;
    #endregion

    #region Constructors
    public DBEditBaseForm()
    {
      InitializeComponent();
      readOnlyControls = new List<Control>();
    }
    #endregion

    #region Protected virtual methods
    protected virtual void SetEditorsStatus()
    {
    }
    #endregion

    private void MainBS_BindingComplete(object sender, BindingCompleteEventArgs e)
    {
      lastException = null;
      if (e.BindingCompleteState == BindingCompleteState.Exception)
      {
        lastException = e.Exception;
        if (e.Binding.Control is BaseEdit)
          (e.Binding.Control as BaseEdit).ErrorText = e.ErrorText;
      }
    }
  }
    }