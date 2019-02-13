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
  public partial class ChooseRepADMOffenseForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idSanc, idKoAP;
    protected Decimal idSts, idUsers;
    public ChooseRepADMOffenseForm ()
    {
      InitializeComponent();
      
      BindingSource KndSanctionsBS = new BindingSource();
      luKndSanc.Properties.DataSource = KndSanctionsBS;
      //KndSanctionsBS.DataSource = MapperRegistry.Instance.GetKndSanctionsMapper().FindByCondition(3,1);

      BindingSource UsersBS = new BindingSource();
      luUsers.Properties.DataSource = UsersBS;
      UsersBS.DataSource = MapperRegistry.Instance.GetExecutorMapper().FindByCondition(3);
      
      BindingSource KoAPBS = new BindingSource();
      luKoAP.Properties.DataSource = KoAPBS;
     // KoAPBS.DataSource = MapperRegistry.Instance.GetBasePrescriptionMapper().FindByCondition(3);
    
    }

    public DateTime? Date1
    {
        get { return (DateTime?)edDt1.EditValue; }
    }

    public DateTime? Date2
    {
        get { return (DateTime?)edDt2.EditValue; }
    }
    
    public Decimal KndSanc
    {
        get { return idSanc; }
    }
    public Decimal KoAP
    {
        get { return idKoAP; }
    }

    public Decimal TypeSecurities
    {
        get { return idSts; }
    }
    public Decimal Users
    {
        get { return idUsers; }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
      isValid = true;
      //if (edDt1.EditValue == null)
      //{
      //  isValid = false;
      //  XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату начало"), LangTranslate.UiGetText("Информация"),
      //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //  return;
      //}
      //if (edDt2.EditValue == null)
      //{
      //    isValid = false;
      //    XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату конец "), LangTranslate.UiGetText("Информация"),
      //      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //    return;
      //}
      DialogResult = DialogResult.OK;
      Close();
    }

   
   
    private void ChooseRepRegionPeriodDenialForm_Load(object sender, EventArgs e)
    {
        edDt1.DateTime = DateTime.Now;
        edDt2.DateTime = DateTime.Now;
    }

    private void cbTypeReport_EditValueChanged(object sender, EventArgs e)
    {
        idSts = cbTypeSecurities.SelectedIndex;
    }

    private void luUsers_EditValueChanged(object sender, EventArgs e)
    {
        idUsers = (decimal)luUsers.EditValue;
    }

    
    private void luKoAP_EditValueChanged(object sender, EventArgs e)
    {
        idKoAP = (decimal)luKoAP.EditValue;
    }

    private void luKndSanc_EditValueChanged(object sender, EventArgs e)
    {
        idSanc = (decimal)luKndSanc.EditValue;
    }

  
    
  }
}