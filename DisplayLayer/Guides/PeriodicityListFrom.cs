﻿using System;
using System.ComponentModel;
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
using BSB.Common.DB;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class PeriodicityListForm : DBListROBaseForm
  {
    public PeriodicityListForm()
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
            MainBS.DataSource = MapperRegistry.Instance.GetPeriodicityMapper().FindAll();
            gridMain.DataSource = MainBS;
            UnitOfWork.Instance.Clear();
        }

        catch (Exception oe)
        {
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.PeriodicityListForm)");
        }
        finally
        {
            Cursor.Current = oldCursor;

        }
        UnitOfWork.Instance.Clear();
        if (gridMainView.RowCount > 0)
            count_record = gridMainView.RowCount;
        else
            count_record = MainBS.Count;
        edCountRecord.Caption = Convert.ToString(count_record);
    }

    private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
    {
        var form = new PeriodicityForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            btnRefresh.PerformClick();
        }
        if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
    }

    private void PeriodicityListForm_Load(object sender, EventArgs e)
    {
      btnRefresh.PerformClick();
    }

    private void BtnView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (MainBS.Current == null) return;
        new PeriodicityForm((Periodicity)MainBS.Current, EditorState.View).ShowDialog();
        if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
    }
    protected override void SetEditorsStatus()
    {
        if (MainBS.Current == null) return;
        if (MainBS.Current.GetType() == typeof(Periodicity))
        {
            var stateShareUk = (Periodicity)MainBS.Current;
            BtnDelete.Enabled = !stateShareUk.IsDelete;
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
            ((Periodicity)MainBS.Current).Delete();
        if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
        btnRefresh.PerformClick();
    }

    private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (MainBS.Current == null) return;
        try
        {
            var form = new PeriodicityForm((Periodicity)MainBS.Current, EditorState.Edit);
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
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.PeriodicityListForm)");
        }

    }

    private void gridMain_DoubleClick(object sender, EventArgs e)
    {
      btnEdit.PerformClick();
    }

    private void gridMain_Click(object sender, EventArgs e)
    {

    }
  }
}