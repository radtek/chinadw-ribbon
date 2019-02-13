using System;
using System.ComponentModel;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Registers;

namespace ARM_User.ServiceLayer.Guides
{
  public abstract class GuideEditorBase : IReadOnly
  {
    protected DomainObject insertedObject;
    protected IDOList objectList;
    private StateBase state;

    public GuideEditorBase()
    {
      State = new InitialState(this);
    }

    #region IReadOnly Members

    public abstract bool ReadOnly { get; }

    #endregion

    protected abstract ISimpleFinder GetFinder();

    #region Selectors

    public virtual IDOList ObjectList
    {
      get { return objectList; }
    }

    public DomainObject InsertedObject
    {
      get { return insertedObject; }
    }

    public bool StateIs(Type t)
    {
      return (state.GetType().Equals(t));
    }

    #endregion

    #region Public methods

    public void Load()
    {
      State.Load();
    }

    public void BeginEdit()
    {
      State.BeginEdit();
    }

    public void CancelEdit()
    {
      State.CancelEdit();
    }

    public DomainObject Insert()
    {
      return State.Insert();
    }

    public void Delete(DomainObject obj)
    {
      State.Delete(obj);
    }

    public void Save()
    {
      State.Save();
    }

    #endregion

    #region Protected methods

    protected abstract DomainObject CreateNew();

    protected StateBase State
    {
      get { return state; }
      set
      {
        if (state != value)
        {
          state = value;
          if (StateChange != null)
            StateChange(this, new StateChangeEventArgs(state));
        }
      }
    }

    protected virtual void doLoad()
    {
      objectList = GetFinder().FindAll();
    }

    protected virtual void doBeginEdit()
    {
      UnitOfWork.Instance.BeginTransaction();
    }

    protected virtual void doCancelEdit()
    {
      UnitOfWork.Instance.Rollback();
      if (insertedObject != null)
      {
        ObjectList.Remove(insertedObject);
        insertedObject = null;
      }
      objectList.NotifyListChanged(ListChangedType.Reset, 0);
    }

    protected virtual DomainObject doInsert()
    {
      UnitOfWork.Instance.BeginTransaction();
      insertedObject = CreateNew();
      ObjectList.Add(insertedObject);
      return insertedObject;
    }

    protected virtual void doDelete(DomainObject obj)
    {
      UnitOfWork.Instance.BeginTransaction();
      try
      {
        obj.Delete();
        UnitOfWork.Instance.Commit();
      }
      catch (Exception)
      {
        UnitOfWork.Instance.Rollback();
        throw;
      }
    }

    protected virtual void doSave()
    {
      UnitOfWork.Instance.Commit();
      insertedObject = null;
      objectList.NotifyListChanged(ListChangedType.Reset, 0);
    }

    #endregion

    #region State implementation

    public class StateChangeEventArgs : EventArgs
    {
      private readonly Type stateType;

      public StateChangeEventArgs(StateBase state)
      {
        stateType = state.GetType();
      }

      public bool StateIs(Type t)
      {
        return (stateType.Equals(t));
      }
    }

    public delegate void StateChangeEventHandler(Object sender, StateChangeEventArgs args);

    public event StateChangeEventHandler StateChange;

    public abstract class StateBase
    {
      protected GuideEditorBase editor;

      protected StateBase(GuideEditorBase editor)
      {
        this.editor = editor;
      }

      protected GuideEditorBase Editor
      {
        get { return editor; }
      }

      public virtual void Load()
      {
        throw new NotSupportedException();
      }

      public virtual void BeginEdit()
      {
        throw new NotSupportedException();
      }

      public virtual DomainObject Insert()
      {
        throw new NotSupportedException();
      }

      public virtual void Delete(DomainObject obj)
      {
        throw new NotSupportedException();
      }

      public virtual void CancelEdit()
      {
        throw new NotSupportedException();
      }

      public virtual void Save()
      {
        throw new NotSupportedException();
      }
    }

    public class InitialState : StateBase
    {
      public InitialState(GuideEditorBase editor)
        :
          base(editor)
      {
      }

      public override void Load()
      {
        Editor.doLoad();
        Editor.State = new ViewingState(Editor);
      }
    }

    public class ViewingState : StateBase
    {
      public ViewingState(GuideEditorBase editor)
        :
          base(editor)
      {
      }

      public override void Load()
      {
        Editor.doLoad();
      }

      public override void BeginEdit()
      {
        Editor.doBeginEdit();
        Editor.State = new EditingState(Editor);
      }

      public override DomainObject Insert()
      {
        var obj = Editor.doInsert();
        Editor.State = new EditingState(Editor);
        return obj;
      }

      public override void Delete(DomainObject obj)
      {
        Editor.doDelete(obj);
      }
    }

    public class EditingState : StateBase
    {
      public EditingState(GuideEditorBase editor)
        :
          base(editor)
      {
      }

      public override void CancelEdit()
      {
        Editor.doCancelEdit();
        Editor.State = new ViewingState(Editor);
      }

      public override void Save()
      {
        Editor.doSave();
        Editor.State = new ViewingState(Editor);
      }
    }

    #endregion
  }
}