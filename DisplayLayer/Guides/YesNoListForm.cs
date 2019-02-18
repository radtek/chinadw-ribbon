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

namespace ARM_User.DisplayLayer.Guides
{
  public partial class YesNoListForm : DBListROBaseForm
  {
    public YesNoListForm()
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
            MainBS.DataSource = MapperRegistry.Instance.GetYesNoMapper().FindAll();
            gridMain.DataSource = MainBS;
            UnitOfWork.Instance.Clear();
        }

        catch (Exception ex)
        {
            var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
            if (rethrow)
                throw;
        }
        finally
        {
            Cursor.Current = oldCursor;

        }
        UnitOfWork.Instance.Clear();  

    }

    private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
    {
        var form = new YesNoForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            MainBS.Add(form.YesNo);
            MainBS.Position = ((IDOList)MainBS.DataSource).IndexOf(form.YesNo);
        }
    }

    private void YesNoListForm_Load(object sender, EventArgs e)
    {
      btnRefresh.PerformClick();
    }

    private void BtnView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (MainBS.Current == null) return;
        new YesNoForm((YesNo)MainBS.Current, EditorState.View).ShowDialog();
    }
    protected override void SetEditorsStatus()
    {
        if (MainBS.Current == null) return;
        if (MainBS.Current.GetType() == typeof(YesNo))
        {
            var yesno = (YesNo)MainBS.Current;
            BtnDelete.Enabled = !yesno.IsDelete;
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
            ((YesNo)MainBS.Current).Delete();
    }

    private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (MainBS.Current == null) return;
        try
        {
            var form = new YesNoForm((YesNo)MainBS.Current, EditorState.Edit);
            if (form.ShowDialog() == DialogResult.Cancel)
                if (UnitOfWork.Instance.IsTransactionStarted)
                    UnitOfWork.Instance.Rollback();
                    MainBS.CancelEdit();
                    ((IDOList)MainBS.DataSource).NotifyListChanged(ListChangedType.Reset, 0);
        }
        catch (Exception ex)
        {
            var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
            if (rethrow)
                throw;
        }

    }

    private void gridMain_DoubleClick(object sender, EventArgs e)
    {
      btnEdit.PerformClick();
    }
  }
}