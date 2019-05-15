using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ARM_User.DisplayLayer.Common;
using ARM_User.Resources;
using DevExpress.XtraEditors;

namespace BSB.Common
{
  public partial class BaseDialogForm : XtraForm
  {
    #region Fields
    protected List<Control> unTrControls;
    #endregion

    public BaseDialogForm()
    {
      InitializeComponent();
      unTrControls = new List<Control>();
     
    }

    private void BaseDialogForm_Load(object sender, EventArgs e)
    {
        //Icon = AppResource.MasterDetail;
        if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
            new LangTranslate().UISetupTexts(this, unTrControls);
        GridUtilities.RestoreGridLayouts(this);
    }

    private void BaseDialogForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      GridUtilities.SaveGridLayouts(this);
    }
  }
}