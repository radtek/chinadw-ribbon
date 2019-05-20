using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ARM_User.DisplayLayer.Popup;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using ARM_User.BusinessLayer.Common;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseRegDateForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal idRegion;
    public ChooseRegDateForm()
    {
      InitializeComponent();
      
      BindingSource RegionBS = new BindingSource();
      luRegion.Properties.DataSource = RegionBS;      
     // RegionBS.DataSource = MapperRegistry.Instance.GetRegionMapper().FindAll();
    
    }

    public DateTime DateBegin
    {
      get { return edDateBegin.DateTime; }
    }

    public DateTime DateEnd
    {
        get { return edDateEnd.DateTime; }
    }
#pragma warning disable CS0108 // 'ChooseRegDateForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
    public Decimal Region
#pragma warning restore CS0108 // 'ChooseRegDateForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
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

    private void luRegion_EditValueChanged(object sender, EventArgs e)
    {
        if (luRegion.Properties.DisplayMember == "Nameru")
        {
            idRegion = (decimal)luRegion.EditValue;
        }
        else if (luRegion.Properties.DisplayMember != "Nameru")
        {
             idRegion = 0;
        }
    }

    private void luRegion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
        if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
        {
            idRegion = 0;
        }
    }

    private void ChooseRegDateForm_Load(object sender, EventArgs e)
    {
        edDateBegin.DateTime = DateTime.Now;
        edDateEnd.DateTime = DateTime.Now;
    }

    
  }
}