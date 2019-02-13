using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ARM_User.MapperLayer.Common;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;

namespace ARM_User.BusinessLayer.Common
{
  public class UnitOfWork
  {
    private OracleTransaction trans;
    private readonly ObjectStorage allObjects = new ObjectStorage(); // new, clean, dirty

    private readonly ObjectStorage allOldVersionObjects = new ObjectStorage();
      // old versions of dirty and deleted objects

    private readonly ListStorage allOldVersionsLists = new ListStorage();
    private readonly ObjectStorage cleanObjects = new ObjectStorage();
    private readonly ObjectStorage dirtyObjects = new ObjectStorage();
    private readonly ObjectStorage newObjects = new ObjectStorage();
    private readonly ObjectStorage removedObjects = new ObjectStorage();
    public bool IsTransactionStarted { get; private set; }

    public void Clear()
    {
      allObjects.Clear();
      cleanObjects.Clear();
      newObjects.Clear();
      dirtyObjects.Clear();
      removedObjects.Clear();
      allOldVersionObjects.Clear();
      trans = null;
      SessionVariables.Clear();      
    }

    protected void AddToStorage(DomainObject obj, decimal id, ObjectStorage storage)
    {
      if (!storage.ContainsKey(obj.GetType()))
        storage.Add(obj.GetType(), new SortedDictionary<decimal, DomainObject>());
      storage[obj.GetType()].Add(id, obj);
    }

    public void AddToStorage(DomainObject obj, ObjectStorage storage)
    {
      AddToStorage(obj, obj.Id, storage);
    }

    protected bool RemoveFromStorage(DomainObject obj, decimal id, ObjectStorage storage)
    {
      if (storage.ContainsKey(obj.GetType()))
        return storage[obj.GetType()].Remove(id);
      return false;
    }

    protected bool RemoveFromStorage(DomainObject obj, ObjectStorage storage)
    {
      return RemoveFromStorage(obj, obj.Id, storage);
    }

    protected bool IsObjectInStorage(Type objType, decimal id, ObjectStorage storage, bool scanSubClasses)
    {
      if (storage.ContainsKey(objType))
        if (storage[objType].ContainsKey(id))
          return true;

      if (scanSubClasses)
        foreach (var arr in storage)
          if (arr.Key.GetType().IsSubclassOf(objType))
            return arr.Value.ContainsKey(id);

      return false;
    }

    protected bool IsObjectInStorage(DomainObject obj, ObjectStorage storage)
    {
      return IsObjectInStorage(obj.GetType(), obj.Id, storage, false);
    }

    public void RegisterNew(DomainObject obj)
    {
      if (!IsTransactionStarted)
        throw new Exception(LangTranslate.UiGetText("Перед созданием объекта необходимо начать транзакцию"));
#if CHECK_OBJECT
      if (obj.State != DOState.Detached)
        throw new Exception(LangTranslate.UIGetText("Объект не в отсоединенном состоянии"));
      if (IsObjectInStorage(obj, allObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован"));
      if (IsObjectInStorage(obj, removedObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован как удаленный"));
#endif

      AddToStorage(obj, newObjects);
      AddToStorage(obj, allObjects);

      obj.SetState(DOState.New);
    }

    public void RegisterDirty(DomainObject obj)
    {
      if (!IsTransactionStarted)
        throw new Exception(LangTranslate.UiGetText("Перед изменением объекта необходимо начать транзакцию"));
#if CHECK_OBJECT
      if (obj.State != DOState.Clean)
        throw new Exception(LangTranslate.UIGetText("Объект не в чистом состоянии"));
      if (!IsObjectInStorage(obj, cleanObjects))
        throw new Exception(LangTranslate.UIGetText("Объект не зарегестрирован как чистый"));
      if (IsObjectInStorage(obj, dirtyObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован как грязный"));
#endif

      RemoveFromStorage(obj, cleanObjects);
      AddToStorage(obj, dirtyObjects);

#if CHECK_OBJECT
      if (!IsObjectInStorage(obj, allOldVersionObjects))
        AddToStorage(obj.Clone(), allOldVersionObjects);
#else
      AddToStorage(obj.Clone(), allOldVersionObjects);
#endif

      obj.SetState(DOState.Dirty);
    }

    public void RegisterRemoved(DomainObject obj)
    {
      if (!IsTransactionStarted)
        throw new Exception(LangTranslate.UiGetText("Перед удалением объекта необходимо начать транзакцию"));

      if (obj.State != DOState.Clean &&
          obj.State != DOState.Dirty &&
          obj.State != DOState.New  &&
          obj.State != DOState.VirtualNew)
        throw new Exception(LangTranslate.UiGetText("Объект не в живом состоянии"));

#if CHECK_OBJECT
      if (!IsObjectInStorage(obj, allObjects))
        throw new Exception(LangTranslate.UIGetText("Объект не зарегестрирован"));
      if (IsObjectInStorage(obj, removedObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован как удаленный"));

      if (IsObjectInStorage(obj, newObjects))
      {
        RemoveFromStorage(obj, newObjects);
        RemoveFromStorage(obj, allObjects);
      }
      else
      {
        if (IsObjectInStorage(obj, cleanObjects))
        {
          RemoveFromStorage(obj, cleanObjects);
          RemoveFromStorage(obj, allObjects);
        }
        else if (IsObjectInStorage(obj, dirtyObjects))
        {
          RemoveFromStorage(obj, dirtyObjects);
          RemoveFromStorage(obj, allObjects);
        }
        AddToStorage(obj, removedObjects);
        if (!IsObjectInStorage(obj, allOldVersionObjects))
          AddToStorage(obj.Clone(), allOldVersionObjects);
      }
#else
      if (obj.State == DOState.New || obj.State == DOState.VirtualNew)
      {
        RemoveFromStorage(obj, newObjects);
        RemoveFromStorage(obj, allObjects);
      }
      else
      {
        if (obj.State == DOState.Clean)
        {
          RemoveFromStorage(obj, cleanObjects);
          RemoveFromStorage(obj, allObjects);
        }
        else if (obj.State == DOState.Dirty)
        {
          RemoveFromStorage(obj, dirtyObjects);
          RemoveFromStorage(obj, allObjects);
        }
        AddToStorage(obj, removedObjects);
        if (!IsObjectInStorage(obj, allOldVersionObjects))
          AddToStorage(obj.Clone(), allOldVersionObjects);
      }
#endif

      obj.SetState(DOState.Deleted);
    }

    public void RegisterClean(DomainObject obj)
    {
#if CHECK_OBJECT
      if (obj.State != DOState.Detached)
        throw new Exception(LangTranslate.UIGetText("Объект не в отсоединенном состоянии"));
      if (IsObjectInStorage(obj, allObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован"));
      if (IsObjectInStorage(obj, removedObjects))
        throw new Exception(LangTranslate.UIGetText("Объект уже зарегестрирован как удаленный"));
#endif

      AddToStorage(obj, cleanObjects);
      AddToStorage(obj, allObjects);

      obj.SetState(DOState.Clean);
    }

    public bool IsObjectRegisteredAsRemoved(Type objType, decimal id, bool scanSubClasses)
    {
      return IsObjectInStorage(objType, id, removedObjects, scanSubClasses);
    }

    public bool IsObjectRegisteredAsAlive(Type objType, decimal id, bool scanSubClasses)
    {
      return IsObjectInStorage(objType, id, allObjects, scanSubClasses);
    }

    public void ChangeId(DomainObject obj, decimal id_old, decimal id_new)
    {
#if CHECK_OBJECT
      if (!IsObjectInStorage(obj.GetType(), id_old, newObjects, false))
        throw new Exception(LangTranslate.UIGetText("Объект не зарегестрирован как новый"));
#endif

      RemoveFromStorage(obj, id_old, newObjects);
      RemoveFromStorage(obj, id_old, allObjects);
      AddToStorage(obj, id_new, newObjects);
      AddToStorage(obj, id_new, allObjects);
    }

    public DomainObject FindObject(Type objType, decimal id, bool scanSubClasses)
    {
      if (allObjects.ContainsKey(objType))
        if (allObjects[objType].ContainsKey(id))
          return allObjects[objType][id];

      if (scanSubClasses)
        foreach (var arr in allObjects)
          if (arr.Key.IsSubclassOf(objType))
            if (arr.Value.ContainsKey(id))
              return arr.Value[id];

      return null;
    }

    public void RegisterDirty(IDOList list)
    {
      if (list.State == DOState.Clean)
      {
        var listClean = new ArrayList(list);
        allOldVersionsLists.Add(list, listClean);
        list.SetState(DOState.Dirty);
      }
    }

    public void BeginTransaction()
    {
      if (IsTransactionStarted)
        throw new OneTransactionException(LangTranslate.UiGetText("Транзакция уже запущена"));
      IsTransactionStarted = true;
    }

    public void Commit()
    {
      if (!IsTransactionStarted)
        throw new Exception(LangTranslate.UiGetText("Перед сохранением необходимо начать транзакцию"));

      try
      {
        Validate();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Business Policy");
        if (rethrow)
        {
          throw;
        }
      }

      try
      {
        var i = 0;
        var proceed = false;
        // Цикл пытается выполнить сохранение несколько раз если была потеряна связь.
        while (!proceed)
        {
          i++;
          try
          {
            InnerTransactionsBegin();

            UpdateDirty();
            DeleteRemoved();
            InsertNew();
            ApplayVer();

            InnerTransactionsCommit();
            proceed = true;
          }
          catch (ApplicationException)
          {
            proceed = true;
            try
            {
              InnerTransactionsRollback();
            }
            catch (Exception)
            {
            }

            throw;
          }
          catch (Exception)
          {
            try
            {
              InnerTransactionsRollback();
            }
            catch (Exception)
            {
            }

            if (i > 2)
              throw;
          }
        }

        foreach (var arr in newObjects)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
            obj.SetState(DOState.Clean);
            AddToStorage(obj, cleanObjects);
          }
        }

        foreach (var arr in dirtyObjects)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
            obj.SetState(DOState.Clean);
            AddToStorage(obj, cleanObjects);
          }
        }

        foreach (var lists in allOldVersionsLists)
        {
          lists.Key.SetState(DOState.Clean);
        }

        newObjects.Clear();
        dirtyObjects.Clear();
        removedObjects.Clear();
        allOldVersionObjects.Clear();
        allOldVersionsLists.Clear();

        IsTransactionStarted = false;
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Business Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    public void Rollback()
    {
      if (!IsTransactionStarted)
        throw new Exception(LangTranslate.UiGetText("Перед отменой необходимо начать транзакцию"));

      try
      {
        foreach (var arr in newObjects)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
            obj.UnsetListners();
            RemoveFromStorage(obj, allObjects);
          }
        }

        foreach (var arr in dirtyObjects)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
#if CHECK_OBJECT
          if (!IsObjectInStorage(obj, allOldVersionObjects))
            throw new Exception(LangTranslate.UIGetText("Невозможно откатить текущую бизнес транзакцию. Копия объекта не найдена"));
#endif
            obj.UnsetListners();

            var oldObj = allOldVersionObjects[obj.GetType()][obj.Id];
            oldObj.CopyTo(obj);
            AddToStorage(obj, cleanObjects);

            obj.SetListners();
          }
        }

        foreach (var arr in removedObjects)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
#if CHECK_OBJECT
          if (!IsObjectInStorage(obj, allOldVersionObjects))
            throw new Exception(LangTranslate.UIGetText("Невозможно откатить текущую бизнес транзакцию. Копия объекта не найдена"));
#endif
            obj.UnsetListners();

            var oldObj = allOldVersionObjects[obj.GetType()][obj.Id];
            oldObj.CopyTo(obj);
            AddToStorage(obj, cleanObjects);
            AddToStorage(obj, allObjects);

            obj.SetListners();
          }
        }

        foreach (var lists in allOldVersionsLists)
        {
          lists.Key.UnRegisterListnersForAllObjects();
          lists.Key.GetSourceList().Clear();
          foreach (var obj in lists.Value)
            lists.Key.GetSourceList().Add(obj);
          lists.Key.RegisterListnersForAllObjects();
          lists.Key.SetState(DOState.Clean);
          lists.Key.NotifyListChanged(ListChangedType.Reset, 0);
        }

        newObjects.Clear();
        dirtyObjects.Clear();
        removedObjects.Clear();
        allOldVersionObjects.Clear();
        allOldVersionsLists.Clear();

        //InnerTransactionsRollback();
        IsTransactionStarted = false;
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Business Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    public void Rollback(List<DomainObject> objList)
    {
     try
        {
            foreach (var obj in objList)
            {
              if (obj.State == DOState.New)
              {
                RemoveFromStorage(obj, allObjects);
                RemoveFromStorage(obj, newObjects);
              }
              else if (obj.State == DOState.Dirty || obj.State == DOState.VirtualNew)
              {
                obj.UnsetListners();

                DOState oldState = obj.State;
                var oldObj = allOldVersionObjects[obj.GetType()][obj.Id];
                oldObj.CopyTo(obj);
                obj.SetState(oldState);

                obj.SetListners();
              }
            }
        }
        catch (Exception ex)
        {
            var rethrow = ExceptionPolicy.HandleException(ex, "Business Policy");
            if (rethrow)
            {
                throw;
            }
        }
    }


    protected void Validate()
    {
      foreach (var arr in newObjects)
      {
        foreach (var keyVal in arr.Value)
        {
          keyVal.Value.Validate();
        }
      }
      foreach (var arr in dirtyObjects)
      {
        foreach (var keyVal in arr.Value)
        {
          keyVal.Value.Validate();
        }
      }
    }

    protected void InsertNew()
    {
      var storage = new SortedObjectStorage(newObjects, new MapperAscComparer());
      foreach (var arr in storage)
      {
        if (arr.Value.Count > 0)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
            obj.EditTime = DateTime.Now;
            obj.EditUser = InitApplication.currentUser;
          }
          var mapper = MapperRegistry.Instance.GetMapper(arr.Key);
          if (mapper != null)
            mapper.Insert(new List<DomainObject>(arr.Value.Values));
        }
      }
    }

    protected void UpdateDirty()
    {
      foreach (var arr in dirtyObjects)
      {
        if (arr.Value.Count > 0)
        {
          foreach (var keyVal in arr.Value)
          {
            var obj = keyVal.Value;
            obj.EditTime = DateTime.Now;
            obj.EditUser = InitApplication.currentUser;
          }
          var mapper = MapperRegistry.Instance.GetMapper(arr.Key);
          if (mapper != null)
            mapper.Update(arr.Value.Values);
        }
      }
    }

    protected void DeleteRemoved()
    {
      var storage = new SortedObjectStorage(removedObjects, new MapperDescComparer());
      foreach (var arr in storage)
      {
        if (arr.Value.Count > 0)
        {
          var mapper = MapperRegistry.Instance.GetMapper(arr.Key);
          if (mapper != null)
            mapper.Delete(arr.Value.Values);
        }
      }
    }

    protected void ApplayVer()
    {
      var storageNew = new SortedObjectStorage(newObjects, new MapperAscComparer());
      foreach (var arr in storageNew)
      {
        foreach (var obj in arr.Value.Values)
        {
          obj.ApplayVer();
        }
      }
      var storageDirty = new SortedObjectStorage(dirtyObjects, new MapperAscComparer());
      foreach (var arr in storageDirty)
      {
        foreach (var obj in arr.Value.Values)
        {
          obj.ApplayVer();
        }
      }
    }

    protected void InnerTransactionsBegin()
    {
      if (trans != null)
        throw new Exception(LangTranslate.UiGetText("Предыдущая транзакция Oracle не окончена"));

      if (ConnectionHolder.Instance.Connection.State != ConnectionState.Open)
      {
        ConnectionHolder.Instance.Connection.Open();
      }

      trans = ConnectionHolder.Instance.Connection.BeginTransaction();
    }

    protected void InnerTransactionsCommit()
    {
      if (trans == null)
        throw new Exception(LangTranslate.UiGetText("Транзакция Oracle не начата"));
      try
      {
        trans.Commit();
        trans.Dispose();
        trans = null;
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    protected void InnerTransactionsRollback()
    {
      if (trans == null)
        throw new Exception(LangTranslate.UiGetText("Транзакция Oracle не начата"));
      try
      {
        trans.Rollback();
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
        if (rethrow)
        {
          throw;
        }
      }
      finally
      {
        trans.Dispose();
        trans = null;
      }
    }

    protected class MapperAscComparer : IComparer<Type>
    {
      int IComparer<Type>.Compare(Type x, Type y)
      {
        int xPriority, yPriority;
        xPriority = MapperRegistry.Instance.GetMapper(x).GetPriority();
        yPriority = MapperRegistry.Instance.GetMapper(y).GetPriority();
        if (xPriority != yPriority)
          return xPriority - yPriority;
        return x.Name.CompareTo(y.Name);
      }
    }

    public void SaveOldVersion(DomainObject obj)
    {
      if (!allOldVersionObjects.ContainsKey(obj.GetType()))
        allOldVersionObjects.Add(obj.GetType(), new SortedDictionary<decimal, DomainObject>());
      if (!allOldVersionObjects[obj.GetType()].ContainsKey(obj.Id))
        allOldVersionObjects[obj.GetType()].Add(obj.Id, obj.Clone());
      else
        allOldVersionObjects[obj.GetType()][obj.Id] = obj.Clone();
    }

    protected class MapperDescComparer : IComparer<Type>
    {
      int IComparer<Type>.Compare(Type x, Type y)
      {
        int xPriority, yPriority;
        xPriority = MapperRegistry.Instance.GetMapper(x).GetPriority();
        yPriority = MapperRegistry.Instance.GetMapper(y).GetPriority();
        if (xPriority != yPriority)
          return yPriority - xPriority;
        return y.Name.CompareTo(x.Name);
      }
    }

    protected class SortedObjectStorage : SortedDictionary<Type, SortedDictionary<decimal, DomainObject>>
    {
      public SortedObjectStorage(IDictionary<Type, SortedDictionary<decimal, DomainObject>> dictionary,
        IComparer<Type> comparer)
        : base(dictionary, comparer)
      {
      }
    }

    public class ObjectStorage : Dictionary<Type, SortedDictionary<decimal, DomainObject>>
    {
    }

    protected class ListStorage : Dictionary<IDOList, IList>
    {
    }

    #region Singelton implementation

    static UnitOfWork()
    {
      Instance = new UnitOfWork();
    }

    public UnitOfWork()
    {
      IsTransactionStarted = false;
    }

    public static UnitOfWork Instance { get; private set; }

    #endregion
  }
}