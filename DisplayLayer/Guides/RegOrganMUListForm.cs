using System;
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
  public partial class RegOrganMUListForm : DBListTreeBaseForm
  {
      public RegOrganMUForm formRegOrganMU;
   //   public String NAME;
    public RegOrganMUListForm()
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
            MainBS.DataSource = MapperRegistry.Instance.GetRegOrganMUMapper().FindAll();
            treeList1.DataSource = MainBS;
            UnitOfWork.Instance.Clear();
        }

        catch (Exception oe)
        {
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUListForm)");
        }
        finally
        {
            Cursor.Current = oldCursor;

        }
        UnitOfWork.Instance.Clear();
        
        count_record = MainBS.Count;
        edCountRecord.Caption = Convert.ToString(count_record);

      //try
      //{
      //  MainBS.DataSource = MapperRegistry.Instance.GetRegOrganMUMapper().FindAll();
      //  treeList1.DataSource = MainBS;
      //}
      //catch (Exception ex)
      //{
      //  var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
      //  if (rethrow)
      //    throw;
      //}
    }

    private void GetRegOrganMUForm_Load(object sender, EventArgs e)
    {
      btnRefresh.PerformClick();
    }

    private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
    {
      var form = new RegOrganMUForm();
      if (form.ShowDialog() == DialogResult.OK)
      {
          btnRefresh.PerformClick();
       }
      else
        CancelEdit(form.RegOrganMU);
      if (!UnitOfWork.Instance.IsTransactionStarted)
          UnitOfWork.Instance.BeginTransaction();
    }

    private void btnAddChild_ItemClick(object sender, ItemClickEventArgs e)
    {
      var form = new RegOrganMUForm();

      form.idParent = (decimal) treeList1.FocusedNode.GetValue("Id");
      if (form.ShowDialog() == DialogResult.OK)
      {
        MainBS.Add(form.RegOrganMU);
        MainBS.Position = ((IDOList) MainBS.DataSource).IndexOf(form.RegOrganMU);
      }
      else
        CancelEdit(form.RegOrganMU);
      if (!UnitOfWork.Instance.IsTransactionStarted)
          UnitOfWork.Instance.BeginTransaction();
    }

    public void CancelEdit(RegOrganMU regorganMU)
    {
      if (UnitOfWork.Instance.IsTransactionStarted)
        UnitOfWork.Instance.Rollback();
      MainBS.CancelEdit();
      ((IDOList) MainBS.DataSource).NotifyListChanged(ListChangedType.Reset, 0);
    }

    private void BtnView_ItemClick(object sender, ItemClickEventArgs e)
    {
      var regorgannMU = (RegOrganMU) MainBS.Current;
      if (regorgannMU == null) return;
      new RegOrganMUForm(regorgannMU, EditorState.View).ShowDialog();
      if (!UnitOfWork.Instance.IsTransactionStarted)
          UnitOfWork.Instance.BeginTransaction();
    }

    //protected override void SetEditorsStatus()
    //{
    //    if (MainBS.Current == null) return;
    //    if (MainBS.Current.GetType() == typeof(RegOrganMU))
    //    {
    //        //var RegOrganMU = (RegOrganMU)MainBS.Current;
    //        Name = ((RegOrganMU)MainBS.Current).Name;
    //        //Name = RegOrganMU.Name;
    //    }
    //}

    private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
    {
      //  btnRefresh.PerformClick();

      if (MainBS.Current == null) return;

      try
      {
        if (((RegOrganMU) MainBS.Current).LastElementHierarchy == 0)
        {
          XtraMessageBox.Show(
            LangTranslate.UiGetText("Обнаружена порожденная запись"),
            LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
          if (
            XtraMessageBox.Show(
              LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          {
            UnitOfWork.Instance.BeginTransaction();
            ((RegOrganMU) MainBS.Current).Delete();
            UnitOfWork.Instance.Commit();
           
          }
        }
        if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUListForm)");
      }
      btnRefresh.PerformClick();
    }

    private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (MainBS.Current == null) return;
      try
      {
        var form = new RegOrganMUForm((RegOrganMU) MainBS.Current, EditorState.Edit);
       // form.id = (decimal)treeList1.FocusedNode.GetValue("Id");
        if (form.ShowDialog() == DialogResult.Cancel)
        { CancelEdit(form.RegOrganMU); }
        else
        {
            btnRefresh.PerformClick();
        }
        if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUListForm)");
      }
    }

    private void gridMain_DoubleClick(object sender, EventArgs e)
    {
      btnEdit.PerformClick();
    }

    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
      btnAddChild.PerformClick();
    }

    private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      btnAdd.PerformClick();
    }

    private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
    {

    }
  }
}