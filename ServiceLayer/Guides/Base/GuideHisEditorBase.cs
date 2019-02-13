using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;

namespace ARM_User.ServiceLayer.Guides
{
  public abstract class GuideHisEditorBase : GuideEditorBase
  {
    public GuideHisEditorBase()
    {
      State = new InitialHisState(this);
    }

    protected new StateHisBase State
    {
      get { return (StateHisBase) base.State; }
      set { base.State = value; }
    }

    protected virtual void doBeginHisEdit(IHistoricalObject obj)
    {
      UnitOfWork.Instance.BeginTransaction();
      try
      {
        obj.AddHistory();
      }
      catch (Exception)
      {
        UnitOfWork.Instance.Rollback();
        throw;
      }
    }

    public void BeginHisEdit(IHistoricalObject obj)
    {
      State.BeginHisEdit(obj);
    }

    protected virtual void doDeleteHis(IHistoricalObject obj)
    {
      try
      {
        UnitOfWork.Instance.BeginTransaction();
        obj.DeleteHistory();
        UnitOfWork.Instance.Commit();
      }
      catch (Exception)
      {
        UnitOfWork.Instance.Rollback();
        throw;
      }
    }

    public void DeleteHis(IHistoricalObject obj)
    {
      State.DeleteHis(obj);
    }

    public abstract class StateHisBase : StateBase
    {
      protected StateHisBase(GuideHisEditorBase editor)
        : base(editor)
      {
      }

      protected new GuideHisEditorBase Editor
      {
        get { return (GuideHisEditorBase) editor; }
      }

      public virtual void BeginHisEdit(IHistoricalObject obj)
      {
        throw new NotSupportedException();
      }

      public virtual void DeleteHis(IHistoricalObject obj)
      {
        throw new NotSupportedException();
      }
    }

    public class InitialHisState : StateHisBase
    {
      public InitialHisState(GuideHisEditorBase editor)
        : base(editor)
      {
      }

      public override void Load()
      {
        Editor.doLoad();
        Editor.State = new ViewingHisState(Editor);
      }
    }

    public class ViewingHisState : StateHisBase
    {
      public ViewingHisState(GuideHisEditorBase editor)
        : base(editor)
      {
      }

      public override void Load()
      {
        Editor.doLoad();
      }

      public override void BeginEdit()
      {
        Editor.doBeginEdit();
        Editor.State = new EditingHisState(Editor);
      }

      public override void BeginHisEdit(IHistoricalObject obj)
      {
        Editor.doBeginHisEdit(obj);
        Editor.State = new EditingHisState(Editor);
      }

      public override void DeleteHis(IHistoricalObject obj)
      {
        Editor.doDeleteHis(obj);
      }

      public override DomainObject Insert()
      {
        var obj = Editor.doInsert();
        Editor.State = new EditingHisState(Editor);
        return obj;
      }

      public override void Delete(DomainObject obj)
      {
        Editor.doDelete(obj);
      }
    }

    public class EditingHisState : StateHisBase
    {
      public EditingHisState(GuideHisEditorBase editor)
        : base(editor)
      {
      }

      public override void CancelEdit()
      {
        Editor.doCancelEdit();
        Editor.State = new ViewingHisState(Editor);
      }

      public override void Save()
      {
        Editor.doSave();
        Editor.State = new ViewingHisState(Editor);
      }
    }
  }
}