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
  public partial class ChooseRepPeriodUsrForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idUsr;
    protected Decimal idCancelConfirmRep;
    public ChooseRepPeriodUsrForm()
    {
      InitializeComponent();
      
      BindingSource UserBS = new BindingSource();
      luUsr.Properties.DataSource = UserBS;
      UserBS.DataSource = MapperRegistry.Instance.GetExecutorMapper().FindByCondition(3);
    
    }

    public DateTime DateBegin
    {
        get { return edDateBegin.DateTime; }
    }

    public DateTime DateEnd
    {
        get { return edDateEnd.DateTime; }
    }
    public Decimal IdUsr
    {
        get { return idUsr; }
    }

    public Decimal CancelConfirmRep
    {
        get { return idCancelConfirmRep; }
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

 
    //private void luRegion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    //{
    //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
    //    {
    //        idRegion = 0;
    //    }
    //}

    private void ChooseRepPeriodUsrForm_Load(object sender, EventArgs e)
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

    private void luUsr_EditValueChanged(object sender, EventArgs e)
    {
        idUsr = (decimal)luUsr.EditValue;
    }

   
  }
}