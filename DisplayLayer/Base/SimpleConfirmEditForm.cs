using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Base
{
  public partial class SimpleConfirmEditForm : DBEditBaseForm
  {
    #region Fields

    protected EditorState state;

    #endregion

    #region Constructors

    public SimpleConfirmEditForm()
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
         
        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
       UnitOfWork.Instance.Rollback();
        if (sender == null)
          throw;
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    protected virtual bool Validate() { return true; }


    private void btnCancel_Click(object sender, EventArgs e)
    {
      try
      {

          Close();
      
      }
      catch (Exception ex)
      {
        UnitOfWork.Instance.Rollback();
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
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

    private void SimpleDBEditGBForm_Load(object sender, EventArgs e)
    {


    }
  }
}