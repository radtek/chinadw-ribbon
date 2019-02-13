using System;
using System.ComponentModel;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.ServiceLayer.Guides;
using ARM_User.ServiceLayer.Service;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class SimpleHisGuideBaseForm : GuideBaseForm
  {
    protected GuideHisEditorBase editor;

    public SimpleHisGuideBaseForm()
    {
      try
      {
        InitEditor();
        InitializeComponent();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    protected virtual GuideHisEditorBase Editor
    {
      get { return editor; }
    }

    protected virtual void InitEditor()
    {
    }

    private void SimpleHisGuideBaseForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;

      try
      {
        if (Editor != null)
        {
          Editor.StateChange += OnStateChange;
          Editor.Load();
          MainBS.DataSource = Editor.ObjectList;
          gridMain.DataSource = MainBS;
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    private void MainBS_CurrentChanged(object sender, EventArgs e)
    {
      try
      {
        if (MainBS.Current != null)
        {
          var obj = (IHistoricalObject) MainBS.Current;
          HistoryBS.DataSource = obj.History;
          gridHistory.DataSource = HistoryBS;
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    private void OnStateChange(object o, GuideEditorBase.StateChangeEventArgs arg)
    {
      SetEditorsStatus();
    }

    protected virtual void SetEditorsStatus()
    {
      btnInsert.Enabled =
        Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) &&
        !Editor.ReadOnly;

      btnDelete.Enabled =
        Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnBeginEdit.Enabled =
        Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnHistoryAdd.Enabled =
        Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnHistoryDelete.Enabled =
        Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnRefresh.Enabled = (Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState)) ||
                            Editor.StateIs(typeof (GuideHisEditorBase.InitialHisState)));
      btnSave.Enabled = Editor.StateIs(typeof (GuideHisEditorBase.EditingHisState));
      btnCancelEdit.Enabled = Editor.StateIs(typeof (GuideHisEditorBase.EditingHisState));

      gridMain.Enabled = Editor.StateIs(typeof (GuideHisEditorBase.ViewingHisState));

      if (Editor.StateIs(typeof (GuideHisEditorBase.EditingHisState)))
        EditorUtils.ReadOnlyControls(panelControl1.Controls, null, false);
      else
        EditorUtils.ReadOnlyControls(panelControl1.Controls, null, true);
    }

    private void MainBS_ListChanged(object sender, ListChangedEventArgs e)
    {
      SetEditorsStatus();
    }

    private void btnInsert_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        var obj = Editor.Insert();
        MainBS.Position = ((IDOList) MainBS.DataSource).IndexOf(obj);
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)        
          throw;
      }
    }

    private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        if (MainBS.Current != null)
          if (
            XtraMessageBox.Show(LangTranslate.UiGetText("Вы действительно хотите удалить эту запись?"),
              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            Editor.Delete((DomainObject) MainBS.Current);
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;        
        btnRefresh_ItemClick(null, null);
      }
    }

    private void btnBeginEdit_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        Editor.BeginEdit();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    private void btnHistoryAdd_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        var obj = (IHistoricalObject) MainBS.Current;
        Editor.BeginHisEdit(obj);
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    private void btnHistoryDelete_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        if (MainBS.Current != null)
          if (
            XtraMessageBox.Show(
              LangTranslate.UiGetText("Вы действительно хотите удалить последнюю историю этой записи?"),
              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
          {
            var obj = (IHistoricalObject) MainBS.Current;
            Editor.DeleteHis(obj);
          }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    protected override void EndEdit()
    {
      base.EndEdit();
      MainBS.EndEdit();
    }

    private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        EndEdit();
        Editor.Save();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    protected override void CancelEdit()
    {
      base.CancelEdit();
      MainBS.CancelEdit();
    }

    private void btnCancelEdit_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        CancelEdit();
        Editor.CancelEdit();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        Editor.Load();
        MainBS.DataSource = Editor.ObjectList;
        gridMain.DataSource = MainBS;
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
          throw;
      }
    }

    public override bool CanClose()
    {
      if (Editor.StateIs(typeof (GuideHisEditorBase.EditingHisState)))
      {
        if (
          XtraMessageBox.Show(LangTranslate.UiGetText("Вы действительно хотите выйти без сохранения?"), LangTranslate.UiGetText("Внимание"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
          Editor.CancelEdit();
          return true;
        }
        return false;
      }
      return base.CanClose();
    }

    private void MainBS_BindingComplete(object sender, BindingCompleteEventArgs e)
    {
      if (e.BindingCompleteState == BindingCompleteState.Exception)
      {
        if (e.Binding.Control is BaseEdit)
          ((BaseEdit) e.Binding.Control).ErrorText = e.ErrorText;
      }
    }

    private void barButtonItemExcel_ItemClick(object sender, ItemClickEventArgs e)
    {
      doSaveToExcel();
    }

    protected virtual void doSaveToExcel()
    {
      saveFileDialog1.FileName = Text;
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        gridMainView.ExportToXls(saveFileDialog1.FileName);
    }

    private void SimpleHisGuideBaseForm_Shown(object sender, EventArgs e)
    {
      if (gridMainView.VisibleColumns.Count > 0 &&
          gridMainView.VisibleColumns[0].SummaryItem.SummaryType == SummaryItemType.None)
        gridMainView.VisibleColumns[0].SummaryItem.SummaryType = SummaryItemType.Count;
    }
  }
}