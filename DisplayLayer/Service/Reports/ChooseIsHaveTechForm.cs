using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseIsHaveTechForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal isHaveTech;

    public ChooseIsHaveTechForm()
    {
      InitializeComponent();
    }
    public Decimal HaveTech
    {
        get { return isHaveTech; }
    }
  

    private void btnOk_Click(object sender, EventArgs e)
    {
      isValid = true;
    
      DialogResult = DialogResult.OK;
      Close();
    }

    private void cbIsHaveTech_EditValueChanged(object sender, EventArgs e)
    {
        isHaveTech = cbIsHaveTech.SelectedIndex;
    }
  }
}