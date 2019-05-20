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
  public partial class ChooseRepRegionDateForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idRegion;
    protected Decimal idCancelConfirmRep;
    public ChooseRepRegionDateForm()
    {
      InitializeComponent();
      
      BindingSource RegionBS = new BindingSource();
      luRegion.Properties.DataSource = RegionBS;
      //RegionBS.DataSource = MapperRegistry.Instance.GetRegionMapper().FindByCondition(3);
    
    }

    public DateTime DateBegin
    {
        get { return edDateBegin.DateTime; }
    }

   
#pragma warning disable CS0108 // 'ChooseRepRegionDateForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
    public Decimal Region
#pragma warning restore CS0108 // 'ChooseRepRegionDateForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
    {
        get { return idRegion; }
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
        XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату"), LangTranslate.UiGetText("Информация"),
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
     
      DialogResult = DialogResult.OK;
      Close();
    }

    private void luRegion_EditValueChanged(object sender, EventArgs e)
    
    {
            idRegion = (decimal)luRegion.EditValue;
    }

    //private void luRegion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    //{
    //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
    //    {
    //        idRegion = 0;
    //    }
    //}

    private void ChooseRepRegionDateForm_Load(object sender, EventArgs e)
    {

        edDateBegin.DateTime = DateTime.Now;
        //edDateEnd.DateTime = DateTime.Now;
        
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
        idCancelConfirmRep = cbTypeReport.SelectedIndex;
    }

  
    
  }
}