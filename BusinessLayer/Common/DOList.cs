using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using BSB.Common;

namespace ARM_User.BusinessLayer.Common
{
  public enum DOListChangedType
  {
    Reset = 0,
    ItemAdded = 1,
    ItemDeleted = 2,
    ItemMoved = 3,
    ItemChanged = 4
  }

  public class DOListChangedEventArgs : EventArgs
  {
    public DOListChangedEventArgs(DOListChangedType listChangedType, DomainObject newObject, DomainObject oldObject)
    {
      ListChangedType = listChangedType;
      NewObject = newObject;
      OldObject = oldObject;
    }

    public DOListChangedType ListChangedType { get; private set; }
    public DomainObject NewObject { get; private set; }
    public DomainObject OldObject { get; private set; }
  }

  public delegate void DOListChangedEventHandler(object sender, DOListChangedEventArgs e);

  public interface IDOList
    : IList, IBindingList
  {
    DOState State { get; }
    void SetState(DOState state);
    IList GetSourceList();
    void RegisterListnersForAllObjects();
    void UnRegisterListnersForAllObjects();
    int Find(string propertyName, object val, int index);
    void CopyTo(IDOList objTo);
    void DeleteAll();
    event DOListChangedEventHandler DOListChanged;
    void NotifyListChanged(ListChangedType listChangedType, int newIndex);
    void Sort();
    int IndexOf(DomainObject item, int index);
    int IndexOf(DomainObject item, int index, int count);
    int LastIndexOf(DomainObject item);
    int LastIndexOf(DomainObject item, int index);
    int LastIndexOf(DomainObject item, int index, int count);
  }

  public interface IDOList<T>
    : IDOList, IList<T>
    where T : DomainObject
  {
    bool Exists(Predicate<T> match);
    T Find(Predicate<T> match);
    List<T> FindAll(Predicate<T> match);
    int FindIndex(Predicate<T> match);
    int FindIndex(int startIndex, Predicate<T> match);
    int FindIndex(int startIndex, int count, Predicate<T> match);
    T FindLast(Predicate<T> match);
    int FindLastIndex(Predicate<T> match);
    int FindLastIndex(int startIndex, Predicate<T> match);
    int FindLastIndex(int startIndex, int count, Predicate<T> match);
    void Sort(Comparison<T> comparison);
    void Sort(IComparer<T> comparer);
    void Sort(int index, int count, IComparer<T> comparer);
    int IndexOf(T item, int index);
    int IndexOf(T item, int index, int count);
    int LastIndexOf(T item);
    int LastIndexOf(T item, int index);
    int LastIndexOf(T item, int index, int count);
  }

  public abstract class DOList<T>
    : IDOList<T>
    where T : DomainObject
  {
    protected IVirtualListLoader<T> loader;
    protected List<T> source;

    public DOList()
    {
      AllowRemove = false;
      AllowNew = false;
      AllowEdit = false;
      State = DOState.Detached;
    }

    public DOList(IVirtualListLoader<T> loader)
    {
      AllowRemove = false;
      AllowNew = false;
      AllowEdit = false;
      this.loader = loader;
      State = DOState.Detached;
    }

    public DOList(List<T> source)
    {
      AllowRemove = false;
      AllowNew = false;
      AllowEdit = false;
      if (source != null)
      {
        this.source = source;
        RegisterListnersForAllObjects();
      }
      State = DOState.Detached;
    }

    public IVirtualListLoader<T> Loader
    {
      get { return loader; }
      set { loader = value; }
    }

    public IList GetSourceList()
    {
      return (IList) GetSource();
    }

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
      return GetSource().GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable) GetSource()).GetEnumerator();
    }

    #endregion

    public IList<T> GetSource()
    {
      if (source == null)
      {
        if (loader != null)
        {
          source = loader.Load();
          if (source != null)
            RegisterListnersForAllObjects();
        }
        else
          source = new List<T>();
      }
      return source;
    }

    public void SetSource(List<T> source)
    {
      if (this.source == null && source != null)
      {
        this.source = source;
        RegisterListnersForAllObjects();
      }
    }

    #region Like List Methods

    public bool Exists(Predicate<T> match)
    {
      return ((List<T>) GetSource()).Exists(match);
    }

    public T Find(Predicate<T> match)
    {
      return ((List<T>) GetSource()).Find(match);
    }

    public List<T> FindAll(Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindAll(match);
    }

    public int FindIndex(Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindIndex(match);
    }

    public int FindIndex(int startIndex, Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindIndex(startIndex, match);
    }

    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindIndex(startIndex, count, match);
    }

    public T FindLast(Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindLast(match);
    }

    public int FindLastIndex(Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindLastIndex(match);
    }

    public int FindLastIndex(int startIndex, Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindLastIndex(startIndex, match);
    }

    public int FindLastIndex(int startIndex, int count, Predicate<T> match)
    {
      return ((List<T>) GetSource()).FindLastIndex(startIndex, count, match);
    }

    public void Sort()
    {
      ((List<T>) GetSource()).Sort();
      NotifyListChanged(ListChangedType.Reset, 0);
    }

    public void Sort(Comparison<T> comparison)
    {
      ((List<T>) GetSource()).Sort(comparison);
      NotifyListChanged(ListChangedType.Reset, 0);
    }

    public void Sort(IComparer<T> comparer)
    {
      ((List<T>) GetSource()).Sort(comparer);
      NotifyListChanged(ListChangedType.Reset, 0);
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
      ((List<T>) GetSource()).Sort(index, count, comparer);
      NotifyListChanged(ListChangedType.Reset, 0);
    }

    public int IndexOf(T item, int index)
    {
      return ((List<T>) GetSource()).IndexOf(item, index);
    }

    public int IndexOf(T item, int index, int count)
    {
      return ((List<T>) GetSource()).IndexOf(item, index, count);
    }

    public int LastIndexOf(T item)
    {
      return ((List<T>) GetSource()).LastIndexOf(item);
    }

    public int LastIndexOf(T item, int index)
    {
      return ((List<T>) GetSource()).LastIndexOf(item, index);
    }

    public int LastIndexOf(T item, int index, int count)
    {
      return ((List<T>) GetSource()).LastIndexOf(item, index, count);
    }

    public int IndexOf(DomainObject item, int index)
    {
      return IndexOf((T) item, index);
    }

    public int IndexOf(DomainObject item, int index, int count)
    {
      return IndexOf((T) item, index, count);
    }

    public int LastIndexOf(DomainObject item)
    {
      return LastIndexOf((T) item);
    }

    public int LastIndexOf(DomainObject item, int index)
    {
      return LastIndexOf((T) item, index);
    }

    public int LastIndexOf(DomainObject item, int index, int count)
    {
      return LastIndexOf((T) item, index, count);
    }

    #endregion

    #region IDOList

    public DOState State { get; private set; }

    public void SetState(DOState state)
    {
      State = state;
    }

    public event DOListChangedEventHandler DOListChanged;

    protected void NotifyDOListChanged(DOListChangedType listChangedType, DomainObject newObject, DomainObject oldObject)
    {
      if (State == DOState.Clean)
      {
        UnitOfWork.Instance.RegisterDirty(this);
      }
      if (DOListChanged != null)
      {
        DOListChanged(this, new DOListChangedEventArgs(listChangedType, newObject, oldObject));
      }
    }

    public int Find(string propertyName, object val, int index)
    {
      var pi = typeof (T).GetProperty(propertyName);
      if (pi != null)
      {
        for (var i = index; i < Count; i++)
        {
          var propertyVal = pi.GetValue(this[i], null);
          if (propertyVal == null)
          {
            if (val == null)
              return i;
          }
          else if (propertyVal == val || propertyVal.Equals(val))
            return i;
        }
      }
      return -1;
    }

    public T FindObject(string propertyName, object val, int index)
    {
      var i = Find(propertyName, val, index);
      if (i >= 0)
        return this[i];
      return null;
    }

    public void CopyTo(IDOList objTo)
    {
      if (GetType() != objTo.GetType())
        throw new Exception(LangTranslate.UiGetText("Нельзя скопировать объект в объект другого типа"));

      objTo.UnRegisterListnersForAllObjects();
      foreach (var f in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        f.SetValue(objTo, f.GetValue(this));
      }
      objTo.RegisterListnersForAllObjects();
      objTo.NotifyListChanged(ListChangedType.Reset, 0);
    }

    public void DeleteAll()
    {
      foreach (var obj in new List<T>(GetSource()))
        obj.Delete();
    }

    #endregion

    #region DomainObject Listners

    private void OnObjectDeleted(object sender, EventArgs e)
    {
      Remove((T) sender);
    }

    public void OnObjectChanged(object sender, PropertyChangedEventArgs e)
    {
      NotifyListChanged(ListChangedType.ItemChanged, IndexOf((T) sender));
    }

    public void RegisterListnersForAllObjects()
    {
      if (source != null)
        foreach (var obj in source)
          RegisterListners(obj);
    }

    public void UnRegisterListnersForAllObjects()
    {
      if (source != null)
        foreach (var obj in source)
          UnRegisterListners(obj);
    }

    protected void RegisterListners(T obj)
    {
      obj.ObjectDeleted -= OnObjectDeleted;
      obj.ObjectDeleted += OnObjectDeleted;
      obj.PropertyChanged -= OnObjectChanged;
      obj.PropertyChanged += OnObjectChanged;
    }

    protected void UnRegisterListners(T obj)
    {
      obj.ObjectDeleted -= OnObjectDeleted;
      obj.PropertyChanged -= OnObjectChanged;
    }

    #endregion

    #region Fields for IBindingList implementation

    #endregion

    #region IBindingList Members

    public bool AllowEdit { get; set; }

    public bool AllowNew { get; set; }

    public bool AllowRemove { get; set; }

    public bool IsSorted
    {
      get { return false; }
    }

    public ListSortDirection SortDirection
    {
      get { throw new NotSupportedException("The method or operation is not implemented."); }
    }

    public PropertyDescriptor SortProperty
    {
      get { throw new NotSupportedException("The method or operation is not implemented."); }
    }

    public bool SupportsChangeNotification
    {
      get { return true; }
    }

    public bool SupportsSearching
    {
      get { return false; }
    }

    public bool SupportsSorting
    {
      get { return false; }
    }

    public void AddIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public object AddNew()
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public int Find(PropertyDescriptor property, object key)
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public void RemoveIndex(PropertyDescriptor property)
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public void RemoveSort()
    {
      throw new NotSupportedException("The method or operation is not implemented.");
    }

    public event ListChangedEventHandler ListChanged;

    public void NotifyListChanged(ListChangedType listChangedType, int newIndex)
    {
      if (ListChanged != null)
      {
        ListChanged(this, new ListChangedEventArgs(listChangedType, newIndex));
      }
    }

    #endregion

    #region IList<T> Members

    public int IndexOf(T item)
    {
      return GetSource().IndexOf(item);
    }

    public void Insert(int index, T item)
    {
      NotifyDOListChanged(DOListChangedType.ItemAdded, item, null);
      GetSource().Insert(index, item);
      RegisterListners(item);
      NotifyListChanged(ListChangedType.ItemAdded, GetSource().IndexOf(item));
    }

    public void RemoveAt(int index)
    {
      var obj = GetSource()[index];
      NotifyDOListChanged(DOListChangedType.ItemDeleted, null, obj);
      UnRegisterListners(obj);
      GetSource().RemoveAt(index);
      NotifyListChanged(ListChangedType.ItemDeleted, index);
    }

    public T this[int index]
    {
      get { return GetSource()[index]; }
      set
      {
        UnRegisterListnersForAllObjects();

        var obj = GetSource()[index];

        NotifyDOListChanged(DOListChangedType.ItemChanged, value, obj);

        GetSource()[index] = value;

        NotifyListChanged(ListChangedType.ItemChanged, index);

        RegisterListnersForAllObjects();
//        RegisterListners(value);
      }
    }

    #endregion

    #region IList Members

    int IList.Add(object value)
    {
      Add((T) value);
      return IndexOf((T) value);
    }

    void IList.Clear()
    {
      Clear();
    }

    bool IList.Contains(object value)
    {
      return (Contains((T) value));
    }

    int IList.IndexOf(object value)
    {
      return IndexOf((T) value);
    }

    void IList.Insert(int index, object value)
    {
      Insert(index, (T) value);
    }

    bool IList.IsFixedSize
    {
      get { return ((IList) GetSource()).IsFixedSize; }
    }

    bool IList.IsReadOnly
    {
      get { return IsReadOnly; }
    }

    void IList.Remove(object value)
    {
      Remove((T) value);
    }

    void IList.RemoveAt(int index)
    {
      RemoveAt(index);
    }

    object IList.this[int index]
    {
      get { return this[index]; }
      set { this[index] = (T) value; }
    }

    #endregion

    #region ICollection<T> Members

    public virtual void Add(T item)
    {
      NotifyDOListChanged(DOListChangedType.ItemAdded, item, null);
      GetSource().Add(item);
      NotifyListChanged(ListChangedType.ItemAdded, GetSource().Count - 1);
      RegisterListners(item);
    }

    public void Clear()
    {
      NotifyDOListChanged(DOListChangedType.Reset, null, null);
      NotifyListChanged(ListChangedType.Reset, 0);
      GetSource().Clear();
    }

    public bool Contains(T item)
    {
      return GetSource().Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      GetSource().CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get { return GetSource().Count; }
    }

    public bool IsReadOnly
    {
      get { return GetSource().IsReadOnly; }
    }

    public virtual bool Remove(T item)
    {
      var index = IndexOf(item);
      if (index >= 0)
      {
        NotifyDOListChanged(DOListChangedType.ItemDeleted, null, item);
        UnRegisterListners(item);
        var res = GetSource().Remove(item);
        NotifyListChanged(ListChangedType.ItemDeleted, index);
        return res;
      }
      return false;
    }

    #endregion

    #region ICollection Members

    void ICollection.CopyTo(Array array, int index)
    {
      ((ICollection) GetSource()).CopyTo(array, index);
    }

    int ICollection.Count
    {
      get { return Count; }
    }

    bool ICollection.IsSynchronized
    {
      get { return ((ICollection) GetSource()).IsSynchronized; }
    }

    object ICollection.SyncRoot
    {
      get { return ((ICollection) GetSource()).SyncRoot; }
    }

    #endregion
  }
}