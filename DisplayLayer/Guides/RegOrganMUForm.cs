using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Base;
using ARM_User.DisplayLayer.Popup;
using ARM_User.MapperLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class RegOrganMUForm : SimpleDBEditGBTreeForm
  {
    public decimal idParent;
    public decimal id;
  //  public string NameRegOrganMU;
    protected RegOrganMU regorganMU;

    public RegOrganMUForm()
    {
      InitializeComponent();
      if (!UnitOfWork.Instance.IsTransactionStarted)
      UnitOfWork.Instance.BeginTransaction();
      regorganMU = RegOrganMU.CreateNew();
      State = EditorState.Insert;
     
      
    }

    public RegOrganMUForm(RegOrganMU regorganMU, EditorState state)
    {
      InitializeComponent();
      this.state = state;
      if (State == EditorState.Edit)
      {
          if (!UnitOfWork.Instance.IsTransactionStarted)
          UnitOfWork.Instance.BeginTransaction();
      }
      if (State == EditorState.View)

        cBoxTypeElement.Enabled = false;
      this.regorganMU = regorganMU;
    }

    public RegOrganMU RegOrganMU
    {
      get { return regorganMU; }
    }

    private void RegOrganMUForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;


      MainBS.Add(regorganMU);

      if (idParent != 0)

      regorganMU.RegOrganMUParent = MapperRegistry.Instance.GetRegOrganMUMapper().Find(idParent);
       
      cBoxTypeElement.DataBindings.Add("SelectedIndex", MainBS, "TypeElement", true);
      edName.DataBindings.Add("EditValue", MainBS, "Name", true);
      edParentName.DataBindings.Add("EditValue", MainBS, "RegOrganMUParent.Name", true);
      cbDel.DataBindings.Add("EditValue", MainBS, "Isdelete", true);

      SetEditorsStatus();

      foreach (var control in readOnlyControls)
        EditorUtils.ReadOnlyControl(control, true);

      if (State == EditorState.Insert)
        Text = LangTranslate.UiGetText("Ввод новых реквизитов справочника \"Регистрирующий орган МЮ\"");
      else if (State == EditorState.Edit)
        Text = LangTranslate.UiGetText("Редактирование реквизитов справочника \"Регистрирующий орган МЮ\"");
    }

    protected override bool Validate()
    {
  /*    if (regorganMU.ParentId == null && regorganMU.TypeElement == 0)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Выберите родительскую группу!"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edParentName.Focus();
        return false;
      }*/

      if (regorganMU.Name == null)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Наименование не заполнен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edName.Focus();
        return false;
      }


      return true;
    }

    private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      var f = new RegOrganMUPopupListForm();
      f.SelectedObject = regorganMU.RegOrganMUParent;

      if (f.ShowDialog() == DialogResult.OK)
      {
        regorganMU.RegOrganMUParent = (RegOrganMU) f.SelectedObject;
        edParentName.Text = regorganMU.RegOrganMUParent.Name;
      }
    }
  }
}