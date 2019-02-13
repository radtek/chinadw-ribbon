using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Base;
using ARM_User.DisplayLayer.Popup;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ARM_User.MapperLayer.Common;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class ExecutorForm : SimpleDBEditGBForm
  {
    protected Executor executor;
    protected User user;
    protected string signaturefnf;
    protected decimal IDOfficial;
    
    public ExecutorForm()
    {
      InitializeComponent();
      if (!UnitOfWork.Instance.IsTransactionStarted)
      UnitOfWork.Instance.BeginTransaction();
      executor = Executor.CreateNew();
      State = EditorState.Insert;
    }

    public ExecutorForm(Executor executor, EditorState state)
    {
      InitializeComponent();
      this.state = state;
      if (State == EditorState.Edit)
      {
          if (!UnitOfWork.Instance.IsTransactionStarted)
              UnitOfWork.Instance.BeginTransaction();
      }
          this.executor = executor;
      
    }

    public Executor Executor
    {
      get { return executor; }
    }

    private void ExecutorForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;
      MainBS.Add(executor);
      edLogin.DataBindings.Add("EditValue", MainBS, "Login", true);
      edApp.DataBindings.Add("EditValue", MainBS, "AppName", true);
      //if (executor.Login != null) 
         // edSignatureFNF.DataBindings.Add("EditValue", MainBS, "Executor.User.Name", true);
      edSignatureFNF.DataBindings.Add("EditValue", MainBS, "SignatureFNF", true);
      cbDel.DataBindings.Add("EditValue", MainBS, "IsDelete", true);
      wdDateLast.DataBindings.Add("EditValue", MainBS, "EditTime", true);
      wdUserName.DataBindings.Add("EditValue", MainBS, "EditUser", true);
        
      readOnlyControls.Add(wdDateLast);
      readOnlyControls.Add(wdUserName);

      SetEditorsStatus();

      foreach (var control in readOnlyControls)
        EditorUtils.ReadOnlyControl(control, true);

      if (State == EditorState.Insert)
        Text = LangTranslate.UiGetText("Ввод новых реквизитов справочника \"Исполнители\"");
      else if (State == EditorState.Edit)
        Text = LangTranslate.UiGetText("Редактирование реквизитов справочника \"Исполнители\"");
    }

    protected override bool Validate()
    {
      if (executor.Login == null)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Логин не выбран"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edLogin.Focus();
        return false;
      }
      if (executor.AppName == null)
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Должность не выбрана"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edApp.Focus();
        return false;
      }
      if (edSignatureFNF.Text == null || edSignatureFNF.Text == "")
      {
        XtraMessageBox.Show(
          LangTranslate.UiGetText("Подпись (Ф.И.О.) не заполнен"),
          LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        edSignatureFNF.Focus();
        return false;
      }
      //if (executor.User.Id == IDOfficial)//|| edLogin.Text == Executor.User.Username)
      //{
      //    XtraMessageBox.Show(
      //      LangTranslate.UiGetText("Исполнитель с таким логином уже существует"),
      //      LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
      //    edLogin.Focus();
      //    return false;
      //}    

      return true;
    }

    private void edLogin_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      var f = new UserPopupListForm();
      f.SelectedObject = executor.User;
      // f.ShowDialog();UserPopupListForm

      if (f.ShowDialog() == DialogResult.OK)
      {
          if (f.SelectedObject != null)
          {
              Executor.User = (User)f.SelectedObject;
              edLogin.EditValue = Executor.User.Username;
              Executor.Login = Executor.User.Username;
              edSignatureFNF.EditValue = Executor.User.Name;
              Executor.SignatureFNF = Executor.User.Name;
              IDOfficial = Executor.User.Id;
          }
      }
    }

    private void edApp_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
        
    }

    private void edLogin_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
  }
}