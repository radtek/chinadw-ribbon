using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using ARM_User.ServiceLayer.Service.Editor;
using System.Data;
using System;
using ARM_User.Resources;
using ARM_User.DisplayLayer.Common;

namespace ARM_User.DisplayLayer.Service
{
  public partial class MultiPageListRoBaseForm : MDIChildForm
  {
    protected BindingSource[] bs;
    protected BindingSource currentBS;
    protected GridControl currentGrid;
    protected GridControl[] grids; 
    protected EditorState state;

    public MultiPageListRoBaseForm()
    {
      InitializeComponent();
    }
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
    private void tcMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
    {
//      if (DesignMode) return;
      //currentBS = bs[tcMain.SelectedTabPageIndex];
      //currentGrid = grids[tcMain.SelectedTabPageIndex];
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
    protected virtual bool Validate() { return true; }

    private void MultiPageListRoBaseForm_Load(object sender, EventArgs e)
    {
        Icon = AppResource.MasterDetail;
        if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
            new LangTranslate().UISetupTexts(this, unTrControls);
        GridUtilities.RestoreGridLayouts(this);
    }    
    
  }
}