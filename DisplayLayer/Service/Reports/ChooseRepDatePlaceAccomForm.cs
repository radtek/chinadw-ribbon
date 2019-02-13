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
  public partial class ChooseRepDatePlaceAccomForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idPlaceAccom = -1;
    public ChooseRepDatePlaceAccomForm()
    {
      InitializeComponent();
     
    }

    public DateTime DateBegin
    {
        get { return edDateBegin.DateTime; }
    }
    public DateTime DateEnd
    {
        get { return edDateEnd.DateTime; }
    }

    public Decimal RepPlaceAccom
    {
        get { return idPlaceAccom; }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
        isValid = true;
        if (edDateBegin.EditValue == null)
        {
            isValid = false;
            XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату начало"), LangTranslate.UiGetText("Информация"),
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        if (edDateEnd.EditValue == null)
        {
            isValid = false;
            XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату конец "), LangTranslate.UiGetText("Информация"),
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    private void ChooseRepDatePlaceAccomForm_Load(object sender, EventArgs e)
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

    private void cbKindCB_EditValueChanged(object sender, EventArgs e)
    {
        idPlaceAccom = cbKindCB.SelectedIndex;
    }

  
    
  }
}