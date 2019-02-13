using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseReportDateForm : ParametersForOutputForm
  {
    protected bool isValid;

    public ChooseReportDateForm()
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

    private void ChooseReportDateForm_Load(object sender, EventArgs e)
    {
        edDateBegin.DateTime = DateTime.Now;
        edDateEnd.DateTime = DateTime.Now;
    }
  }
}