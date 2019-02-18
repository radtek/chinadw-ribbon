using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Base;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class YesNoForm : SimpleDBEditGBForm
  {
    protected YesNo yesno;

    public YesNoForm()
    {
      InitializeComponent();

      UnitOfWork.Instance.BeginTransaction();
      yesno = YesNo.CreateNew();
      State = EditorState.Insert;
    }

    public YesNoForm(YesNo yesno, EditorState state)
    {
      InitializeComponent();
      this.state = state;
      if (State == EditorState.Edit)
        UnitOfWork.Instance.BeginTransaction();
      this.yesno = yesno;
    }

    public YesNo YesNo
    {
      get { return yesno; }
    }

    private void YesNoForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;

      MainBS.Add(yesno);
      edCode.DataBindings.Add("EditValue", MainBS, "Code", true);
      edNameRu.DataBindings.Add("EditValue", MainBS, "NameRu", true);
      edNameKz.DataBindings.Add("EditValue", MainBS, "NameKz", true);
      edAdvRepayRu.DataBindings.Add("EditValue", MainBS, "AdvRepayRu", true);
      edAdvRepayKz.DataBindings.Add("EditValue", MainBS, "AdvRepayKz", true);
      edBuyBackBondRu.DataBindings.Add("EditValue", MainBS, "BuyBackBondRu", true);
      edBuyBackBondKz.DataBindings.Add("EditValue", MainBS, "BuyBackBondKz", true);
      cbDel.DataBindings.Add("EditValue", MainBS, "Isdelete", true);
      wdDateLast.DataBindings.Add("EditValue", MainBS, "EditTime", true);
      wdUserName.DataBindings.Add("EditValue", MainBS, "EditUser", true);


      readOnlyControls.Add(wdDateLast);
      readOnlyControls.Add(wdUserName);

      SetEditorsStatus();

      foreach (var control in readOnlyControls)
        EditorUtils.ReadOnlyControl(control, true);

      if (State == EditorState.Insert)
        Text = "Ввод новых реквизитов справочника \"ДаНет\"";
      else if (State == EditorState.Edit)
        Text = "Редактирование реквизитов справочника \"ДаНет\"";
    }

    protected override bool Validate()
    {
      if (yesno.Code == null)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Код не заполнен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edCode.Focus();
        return false;
      }
      if (yesno.NameRu == null)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Наименование (рус) не заполнен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edNameRu.Focus();
        return false;
      }


      return true;
    }
  }
}