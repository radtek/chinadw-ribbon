using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Drawing;
using BSB.Common;
using System.Data;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Base
{
    public partial class SimpleModulsEditSPForm : ARM_User.DisplayLayer.Base.DBEditBaseForm
    {

        #region Fields

        protected EditorState state;

        #endregion


        public SimpleModulsEditSPForm()
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
                        // if (!Validate()) return;

                        MainBS.EndEdit();
                        if (lastException != null)
                            throw lastException;

                        UnitOfWork.Instance.Commit();
                    }

                    State = EditorState.View;

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MainBS.CancelEdit();
                 UnitOfWork.Instance.Rollback();                
                if (sender == null)
                    throw;
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
            }
        }

#pragma warning disable CS0108 // 'SimpleModulsEditSPForm.Validate()' hides inherited member 'ContainerControl.Validate()'. Use the new keyword if hiding was intended.
        protected virtual bool Validate() { return true; }
#pragma warning restore CS0108 // 'SimpleModulsEditSPForm.Validate()' hides inherited member 'ContainerControl.Validate()'. Use the new keyword if hiding was intended.


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
            {
                XtraMessageBox.Show(
              LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
              LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            {
                try
                {
                    if (State == EditorState.Insert || State == EditorState.Edit)
                    {
                        MainBS.CancelEdit();
                        if (UnitOfWork.Instance.IsTransactionStarted)
                            UnitOfWork.Instance.Rollback();
                        State = EditorState.View;
                    }
                }
                catch (Exception ex)
                {
                    MainBS.CancelEdit();
                    UnitOfWork.Instance.Rollback();
                    var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                    if (rethrow)
                        throw;
                }
            }
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

    }

    }
}
