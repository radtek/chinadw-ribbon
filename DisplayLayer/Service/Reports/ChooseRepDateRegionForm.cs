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
  public partial class ChooseRepDateRegionForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idRegion;
   
    public ChooseRepDateRegionForm()
    {
      InitializeComponent();
      
      BindingSource RegionBS = new BindingSource();
      luRegion.Properties.DataSource = RegionBS;
     // RegionBS.DataSource = MapperRegistry.Instance.GetRegionMapper().FindByCondition(3);
    
    }

    public DateTime Date
    {
        get { return edDateBegin.DateTime; }
    }

    
    public Decimal Region
    {
        get { return idRegion; }
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
     
      DialogResult = DialogResult.OK;
      Close();
    }

    private void luRegion_EditValueChanged(object sender, EventArgs e)
    
    {
            idRegion = (decimal)luRegion.EditValue;
    }

    private void ChooseRepDateRegionForm_Load(object sender, EventArgs e)
    {
        edDateBegin.DateTime = DateTime.Now;
       
    }

  
  
    
  }
}