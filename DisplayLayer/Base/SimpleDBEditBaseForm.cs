using System;
using ARM_User.ServiceLayer.Service.Editor;

namespace ARM_User.DisplayLayer.Base
{
  public partial class SimpleDBEditBaseForm : DBEditBaseForm
  {
    #region Fields

    protected EditorState state;

    #endregion

    #region Constructors

    public SimpleDBEditBaseForm()
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
      barButtonItemBeginEdit.Enabled = State == EditorState.View;
      barButtonItemCancelEdit.Enabled = State == EditorState.Edit || State == EditorState.Insert;
      barButtonItemSave.Enabled = State == EditorState.Edit || State == EditorState.Insert;
      barButtonItemRefresh.Enabled = State == EditorState.View;
      EditorUtils.ReadOnlyControls(panelControl1.Controls, readOnlyControls, State != EditorState.Edit && State != EditorState.Insert);
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
  }
}