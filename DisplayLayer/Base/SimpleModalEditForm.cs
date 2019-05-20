using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BSB.Common.DB;
using BSB.Common;
using System.Data;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Base
{
  public partial class SimpleModalEditForm : DBEditBaseForm
  {
    protected DomainObject editObject;

    #region Fields

    protected EditorState state;

    #endregion

    #region Constructors

    public SimpleModalEditForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Properties

    public EditorState State
    {
      get { return state; }
      set
      {
        state = value;
        if (StateChange != null)
          StateChange(this, new StateChangeEventArgs(state));
      }
    }

    #endregion

    protected override void SetEditorsStatus()
    {
      base.SetEditorsStatus();
      //barButtonItemBeginEdit.Enabled = State == EditorState.View;
      //barButtonItemCancelEdit.Enabled = State == EditorState.Edit || State == EditorState.Insert;
      //barButtonItemSave.Enabled = State == EditorState.Edit || State == EditorState.Insert;
      //barButtonItemRefresh.Enabled = State == EditorState.View;
      EditorUtils.ReadOnlyControls(panelControl1.Controls, readOnlyControls,
        State != EditorState.Edit && State != EditorState.Insert);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
          //if (State == EditorState.View)
          //{
          //    DialogResult = DialogResult.OK;
          //    Close();
          //}
          if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
          {
              XtraMessageBox.Show(
                  LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
                  LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
              Close();
          }
          else
          {
              if (state == EditorState.Insert || state == EditorState.Edit)
              {
                  if (state == EditorState.Insert)
                      editObject.SetState(DOState.VirtualNew);

                  if (!Validate()) return;

                  MainBS.EndEdit();
                  if (lastException != null)
                      throw lastException;

                  //  UnitOfWork.Instance.Commit();
              }
          }

        State = EditorState.View;

        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
        MainBS.CancelEdit();
        UnitOfWork.Instance.Rollback();
        DBSupport.DBErrorHandler(942, ex.Message + Environment.NewLine + "(occured in DBSupport.SimpleModalEditForm)");
        /*if (sender == null)
          throw;
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;*/
      }
    }

#pragma warning disable CS0108 // 'SimpleModalEditForm.Validate()' hides inherited member 'ContainerControl.Validate()'. Use the new keyword if hiding was intended.
    protected virtual bool Validate() { return true; }
#pragma warning restore CS0108 // 'SimpleModalEditForm.Validate()' hides inherited member 'ContainerControl.Validate()'. Use the new keyword if hiding was intended.


    protected virtual void btnCancel_Click(object sender, EventArgs e)
    {
        if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
        {
            XtraMessageBox.Show(
          LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
          LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }
        else
        {
            try
            {
                if (State == EditorState.Insert || State == EditorState.Edit)
                {
                    if (UnitOfWork.Instance.IsTransactionStarted)
                    {
                        MainBS.CancelEdit();
                        UnitOfWork.Instance.Rollback(new List<DomainObject>() { editObject });

                    }
                    State = EditorState.View;
                }
            }
            catch (Exception ex)
            {
                //MainBS.CancelEdit();
                //UnitOfWork.Instance.Rollback(new List<DomainObject>() { editObject });
                //var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                //if (rethrow)
                //  throw;
                DBSupport.DBErrorHandler(942, ex.Message + Environment.NewLine + "(occured in DBSupport.SimpleModalEditForm)");
            }
        }
    }

    #region State implementation

    public class StateChangeEventArgs : EventArgs
    {
      public StateChangeEventArgs(EditorState state)
      {
        State = state;
      }

      public EditorState State { get; set; }
    }

    public delegate void StateChangeEventHandler(Object sender, StateChangeEventArgs args);

    public event StateChangeEventHandler StateChange;

    #endregion

    protected virtual void SimpleModalEditForm_Load_1(object sender, EventArgs e)
    {
      if (Site != null) return;
      if (editObject.State == DOState.New || editObject.State == DOState.Dirty || editObject.State == DOState.VirtualNew)
        UnitOfWork.Instance.SaveOldVersion(editObject);
    }
  }
}