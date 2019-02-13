using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseDateForm : ParametersForOutputForm
  {
    protected bool isValid;

    public ChooseDateForm()
    {
      InitializeComponent();
    }

    public DateTime Date
    {
      get { return edDateBegin.DateTime; }
    }

    

    private void btnOk_Click(object sender, EventArgs e)
    {
      isValid = true;
      if (edDateBegin.EditValue == null)
      {
        isValid = false;
        XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату "), LangTranslate.UiGetText("Информация"),
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      
    
      DialogResult = DialogResult.OK;
      Close();
    }

    private void ChooseDateForm_Load(object sender, EventArgs e)
    {
        edDateBegin.DateTime = DateTime.Now;
    }
  }
}