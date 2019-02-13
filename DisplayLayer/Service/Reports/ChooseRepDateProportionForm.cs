using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ARM_User.DisplayLayer.Popup;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using ARM_User.BusinessLayer.Common;
using BSB.Common.DB;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseRepDateProportionForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idProportion;
    public ChooseRepDateProportionForm()
    {
      InitializeComponent();
     
    }

    public DateTime DateBegin
    {
        get { return edDateBegin.DateTime; }
    }

    public Decimal RepProportion
    {
        get { return idProportion; }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
      isValid = true;
      if (edDateBegin.EditValue == null)
      {
        isValid = false;
        XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату"), LangTranslate.UiGetText("Информация"),
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
   
      DialogResult = DialogResult.OK;
      Close();
    }

    private void ChooseRepDateProportionForm_Load(object sender, EventArgs e)
    {
        //UnitOfWork.Instance.Clear();

        //if (cbAllRegion.Checked == true)
        //{
        //    luRegion.Enabled = false;
        //}
        //else if (cbAllRegion.Checked == false)
        //{
        //    btnRefresh.PerformClick(); 
        //    luRegion.Enabled = true;
        //    btnRefresh.PerformClick();
        //}
        
        //UnitOfWork.Instance.Clear();

    }

    private void cbTypeReport_EditValueChanged(object sender, EventArgs e)
    {
        idProportion = cbTypeReport.SelectedIndex;
    }

  
    
  }
}