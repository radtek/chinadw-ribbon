using System;
using System.ComponentModel;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Guides;
using ARM_User.ServiceLayer.Service;
using ARM_User.ServiceLayer.Service.Editor;
using BSB.Common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class SimpleGuideBaseForm : GuideBaseForm
  {
    protected GuideEditorBase editor;

    public SimpleGuideBaseForm()
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
        {
          throw;
        }
      }
    }

    protected virtual GuideEditorBase Editor
    {
      get { return editor; }
    }

    protected virtual void InitEditor()
    {
    }

    private void SimpleGuideBaseForm_Load(object sender, EventArgs e)
    {
      try
      {
        if (Editor != null)
        {
          Editor.StateChange += OnStateChange;
          Editor.Load();
          MainBS.DataSource = Editor.ObjectList;
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    private void OnStateChange(object o, GuideEditorBase.StateChangeEventArgs arg)
    {
      SetEditorsStatus();
    }

    protected virtual void SetEditorsStatus()
    {
      btnInsert.Enabled =
        Editor.StateIs(typeof (GuideEditorBase.ViewingState)) &&
        !Editor.ReadOnly;

      btnDelete.Enabled =
        Editor.StateIs(typeof (GuideEditorBase.ViewingState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnBeginEdit.Enabled =
        Editor.StateIs(typeof (GuideEditorBase.ViewingState)) &&
        !Editor.ReadOnly &&
        MainBS.Current != null;

      btnRefresh.Enabled = (Editor.StateIs(typeof (GuideEditorBase.ViewingState)) ||
                            Editor.StateIs(typeof (GuideEditorBase.InitialState)));
      btnSave.Enabled = Editor.StateIs(typeof (GuideEditorBase.EditingState));
      btnCancelEdit.Enabled = Editor.StateIs(typeof (GuideEditorBase.EditingState));

      EditorUtils.ReadOnlyControls(panelControl1.Controls, null, !Editor.StateIs(typeof (GuideEditorBase.EditingState)));
    }

    private void MainBS_ListChanged(object sender, ListChangedEventArgs e)
    {
      SetEditorsStatus();
    }

    protected virtual void btnInsert_ItemClick(object sender, ItemClickEventArgs e)
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
        {
          throw;
        }
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
        {
          throw;
        }
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
        {
          throw;
        }
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
        {
          throw;
        }
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
        {
          throw;
        }
      }
    }

    protected virtual void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        var oldCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        try
        {
          Editor.Load();
          MainBS.DataSource = Editor.ObjectList;
        }
        finally
        {
          Cursor.Current = oldCursor;
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    public override bool CanClose()
    {
      if (Editor.StateIs(typeof (GuideEditorBase.EditingState)))
      {
/*
        if (XtraMessageBox.Show("Вы действительно хотите выйти без сохранения?", InitApplication.MessageResourceManager.GetString("ATTENTION"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
          Editor.CancelEdit();
          return true;
        }
        else
          return false;*/

        switch (
          XtraMessageBox.Show(LangTranslate.UiGetText("Сохранить изменения?"), LangTranslate.UiGetText("Внимание"),
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
        {
          case DialogResult.Yes:
            EndEdit();
            Editor.Save();
            return base.CanClose();
          case DialogResult.No:
            CancelEdit();
            Editor.CancelEdit();
            return base.CanClose();
          default:
            return false;
        }
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
      throw new NotSupportedException("The method or operation is not implemented.");
    }
  }
}