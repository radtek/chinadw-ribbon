using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Drawing;

namespace ARM_User.DisplayLayer.Base
{
    public partial class SimpleReestrForm : ARM_User.DisplayLayer.Base.DBEditBaseForm
    {

        #region Fields

        protected EditorState state;

        #endregion


        public SimpleReestrForm()
        {
            InitializeComponent();
            //tcMain.TabPages.TabControl.Appearance.ForeColor = System.Drawing.Color.FromName("Cyprus");
        }

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


        protected override void SetEditorsStatus()
        {
            base.SetEditorsStatus();       
            EditorUtils.ReadOnlyControls(panelControl1.Controls, readOnlyControls,
              State != EditorState.Edit && State != EditorState.Insert);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
          
            Close();
          
        }

        protected virtual bool Validate() { return true; }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        #endregion


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
        tcMain.TabPages.TabControl.Appearance.ForeColor = System.Drawing.Color.FromName("Cyprus");
    }

    }
}
