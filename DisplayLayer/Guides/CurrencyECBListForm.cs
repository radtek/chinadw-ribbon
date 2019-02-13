using System;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Guides.Base;
using ARM_User.MapperLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.ComponentModel;

using BSB.Common.DB;

namespace ARM_User.DisplayLayer.Guides
{
    public partial class CurrencyECBListForm : DBListROBaseForm
    {
        public CurrencyECBListForm()
        {
            InitializeComponent();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            var oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                UnitOfWork.Instance.Clear();
                MainBS.DataSource = MapperRegistry.Instance.GetCurrencyECBMapper().FindAll();
                gridMain.DataSource = MainBS;
                UnitOfWork.Instance.Clear();
            }

            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.CurrencyECBListForm)");
            }
            finally
            {
                Cursor.Current = oldCursor;

            }
            //oldCursor = null;
            UnitOfWork.Instance.Clear();            
            if (gridMainView.RowCount > 0 )
              count_record = gridMainView.RowCount;
            else                
              count_record = MainBS.Count;
            edCountRecord.Caption = Convert.ToString(count_record);
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = new CurrencyECBForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                btnRefresh.PerformClick();
            }
            if (!UnitOfWork.Instance.IsTransactionStarted)
                UnitOfWork.Instance.BeginTransaction();
        }

        private void CurrencyECBListForm_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void BtnView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainBS.Current == null) return;
            new CurrencyECBForm((CurrencyECB)MainBS.Current, EditorState.View).ShowDialog();
        }

        protected override void SetEditorsStatus()
        {
            if (MainBS.Current == null) return;
            if (MainBS.Current.GetType() == typeof(CurrencyECB))
            {
                var currencyECB = (CurrencyECB)MainBS.Current;
                BtnDelete.Enabled = !currencyECB.Isdelete;
            }
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainBS.Current == null)
                return;
            if (
              XtraMessageBox.Show(
                LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                ((CurrencyECB)MainBS.Current).Delete();
            if (!UnitOfWork.Instance.IsTransactionStarted)
                UnitOfWork.Instance.BeginTransaction();
            btnRefresh.PerformClick();
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainBS.Current == null) return;
            try
            {
                var form = new CurrencyECBForm((CurrencyECB)MainBS.Current, EditorState.Edit);
                if (form.ShowDialog() == DialogResult.Cancel)
                {
                    if (UnitOfWork.Instance.IsTransactionStarted)
                        UnitOfWork.Instance.Rollback();
                    MainBS.CancelEdit();
                    ((IDOList)MainBS.DataSource).NotifyListChanged(ListChangedType.Reset, 0);
                }
                else
                {
                    btnRefresh.PerformClick();
                }
                if (!UnitOfWork.Instance.IsTransactionStarted)
                    UnitOfWork.Instance.BeginTransaction();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.CurrencyECBListForm)");
            }
        }

        private void gridMain_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}