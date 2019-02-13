using System;
using System.ComponentModel;
using System.Reflection;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;

namespace ARM_User.BusinessLayer.Common
{
  public enum DOState
  {
    Detached,
    Clean,
    New,
    VirtualNew,
    Dirty,
    Deleted
  };

  public enum DeleteRule
  {
    Restrict,
    SetNull,
    Cascade,
    Nothing
  };

  public sealed class DeleteRuleAttribute : Attribute
  {
    public DeleteRuleAttribute(DeleteRule rule)
    {
      Rule = rule;
    }

    public DeleteRule Rule { get; private set; }
  }

  public sealed class ParentIdAttribute : Attribute
  {
    public ParentIdAttribute(string propertyName)
    {
      PropertyName = propertyName;
    }

    public string PropertyName { get; private set; }
  }

  public sealed class SetParentDirtyAttribute : Attribute
  {
  }

  public abstract class DomainObject : INotifyPropertyChanged, IComparable
  {
    #region IComparable Members

    public virtual int CompareTo(object obj)
    {
      return Id.CompareTo(((DomainObject) obj).Id);
    }

    #endregion

    #region Constructors

    private static decimal num = 1;
    private decimal NumObj;

    protected DomainObject()
      : this(IdGenerator.GetNextId())
    {
    }

    protected DomainObject(decimal id)
    {
      this.id = id;
      state = DOState.Detached;

      NumObj = num;
      num = num + 1;
    }

    protected DomainObject(decimal id, User editUser, DateTime? editTime) : this(id)
    {
      this.editUser = editUser;
      this.editTime = editTime;
    }

    protected DomainObject(decimal id, decimal ver)
      : this(id)
    {
      this.ver = ver;
      newVer = ver;
    }

    public static ObjectType CreateNew<ObjectType>()
      where ObjectType : DomainObject, new()
    {
      var obj = new ObjectType();
      UnitOfWork.Instance.RegisterNew(obj);
      return obj;
    }

    #endregion

    #region Fields

    protected decimal id,iscorrection;
    protected decimal ver;
    protected decimal newVer;
    protected DOState state;
    protected User editUser;
    protected DateTime? editTime;

    #endregion

    #region Properties

    public decimal Id
    {
      get { return id; }
    }

    public decimal Ver
    {
      get { return ver; }
    }

    public DOState State
    {
      get { return state; }
    }

    public User EditUser
    {
      get { return editUser; }
      set
      {
        NotifyBeforeObjectChange();
        editUser = value;
        NotifyPropertyChanged("EditUser");
      }
    }
    public decimal IsCorrection
    {
        get { return iscorrection; }
        set
        {
            NotifyBeforeObjectChange();
            iscorrection = value;
            NotifyPropertyChanged("IsCorrection");
        }
    }

    public DateTime? EditTime
    {
      get { return editTime; }
      set
      {
        NotifyBeforeObjectChange();
        editTime = value;
        NotifyPropertyChanged("EditTime");
      }
    }

    #endregion

    #region Methods

    public virtual void Delete()
    {
      NotifyBeforeObjectDelete();
      if (State == DOState.Clean || State == DOState.Dirty || State == DOState.New || State == DOState.VirtualNew)
      {
        UnitOfWork.Instance.RegisterRemoved(this);
      }

      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null)
        {
          var listObj = (IDOList) pi.GetValue(this, null);
          if (listObj != null && listObj.Count > 0)
          {
            var rule = DeleteRule.Restrict;
            foreach (var attr in pi.GetCustomAttributes(typeof (DeleteRuleAttribute), false))
            {
              rule = ((DeleteRuleAttribute) attr).Rule;
            }
            if (rule == DeleteRule.Restrict)
              throw new ApplicationException(LangTranslate.UiGetText("Нельзя удалить объект на который ссылаются другие"));
            if (rule == DeleteRule.Cascade)
            {
              var arr = new DomainObject[listObj.Count];
              listObj.CopyTo(arr, 0);
              foreach (var objChild in arr)
              {
                objChild.Delete();
              }
            }
            if (rule == DeleteRule.SetNull)
            {
              listObj.Clear();
            }
          }
        }
      }
      NotifyObjectDeleted();
      UnsetListners();
    }


    public static decimal? GetId(DomainObject obj)
    {
      return (obj == null) ? (decimal?) null : obj.Id;
    }

    #endregion

    #region Methods for UnitOfWork only

    public DomainObject Clone()
    {
      return (DomainObject) MemberwiseClone();
    }

    public void CopyTo(DomainObject objTo)
    {
      if (GetType() != objTo.GetType())
        throw new Exception(LangTranslate.UiGetText("Нельзя скопировать объект в объект другого типа"));

      foreach (var f in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        if (f.FieldType.GetInterface("IDOList") != null)
        {
          if (f.GetValue(this) != f.GetValue(objTo))
          {
            ((IDOList) f.GetValue(this)).CopyTo((IDOList) f.GetValue(objTo));
            ((IDOList) f.GetValue(objTo)).GetSourceList();
          }
        }
        else
          f.SetValue(objTo, f.GetValue(this));
      }
      objTo.NotifyPropertyChanged("");
    }

    public new Type GetType()
    {
      return base.GetType();
    }

    public void SetState(DOState state)
    {
      this.state = state;
      if (state == DOState.Clean)
      {
        foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
          if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null)
          {
            var list = (IDOList) pi.GetValue(this, null);
            if (list != null)
              list.SetState(DOState.Clean);
          }
        }
      }
    }

    public virtual void Validate()
    {
    }

    #endregion

    #region Methods for Mapper only

    public void SetId(decimal id_new)
    {
      UnitOfWork.Instance.ChangeId(this, Id, id_new);
      id = id_new;
      ChangeIdInChildCollections(id_new);
    }

    protected void ChangeIdInChildCollections(decimal id_new)
    {
      // Меняем IdParent в детских коллекциях
      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null)
        {
          var listObj = (IDOList) pi.GetValue(this, null);

          var childIdName = "";
          foreach (var attr in pi.GetCustomAttributes(typeof (ParentIdAttribute), true))
          {
            childIdName = ((ParentIdAttribute) attr).PropertyName;
          }
          if (childIdName != "")
          {
            foreach (DomainObject objChild in listObj)
            {
              objChild.GetType().GetProperty(childIdName).SetValue(objChild, id_new, null);
            }
          }
        }
      }
    }

    public void SetVer(decimal ver)
    {
      newVer = ver;
    }

    public void ApplayVer()
    {
      if (newVer > ver)
        ver = newVer;
    }

    #endregion

    #region Notifications

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(String info)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }

    //public event EventHandler BeforeObjectChanging;

    protected void NotifyBeforeObjectChange()
    {
      if (State == DOState.Clean)
      {
        UnitOfWork.Instance.RegisterDirty(this);
      }
    }

    public event EventHandler ObjectDeleted;

    protected void NotifyObjectDeleted()
    {
      if (ObjectDeleted != null)
      {
        ObjectDeleted(this, new EventArgs());
      }
    }

    protected event EventHandler BeforeObjectDelete;

    protected void NotifyBeforeObjectDelete()
    {
      if (BeforeObjectDelete != null)
      {
        BeforeObjectDelete(this, new EventArgs());
      }
    }

    #endregion

    #region Listners

    public void SetListners()
    {
      SetListners(false);
    }

    public void SetListners(bool firstTime)
    {
      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanWrite && pi.CanRead &&
            pi.PropertyType.IsSubclassOf(typeof (DomainObject)) &&
            pi.GetCustomAttributes(typeof (DeleteRuleAttribute), true).Length > 0)
        {
          var parentObj = (DomainObject) pi.GetValue(this, null);
          if (parentObj != null)
          {
            if (!firstTime)
              parentObj.BeforeObjectDelete -= BeforeParentDeleteEventHandler;
            parentObj.BeforeObjectDelete += BeforeParentDeleteEventHandler;
          }
        }
        if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null)
        {
          var listObj = (IDOList) pi.GetValue(this, null);
          if (listObj != null)
          {
            if (!firstTime)
              listObj.DOListChanged -= DOListChangedEventHandler;
            listObj.DOListChanged += DOListChangedEventHandler;
          }
        }
      }
    }

    public void UnsetListners()
    {
      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanWrite && pi.CanRead &&
            pi.PropertyType.IsSubclassOf(typeof (DomainObject)) &&
            pi.GetCustomAttributes(typeof (DeleteRuleAttribute), true).Length > 0)
        {
          var parentObj = (DomainObject) pi.GetValue(this, null);
          if (parentObj != null)
          {
            parentObj.BeforeObjectDelete -= BeforeParentDeleteEventHandler;
          }
        }
        if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null)
        {
          var listObj = (IDOList) pi.GetValue(this, null);
          if (listObj != null)
          {
            listObj.DOListChanged -= DOListChangedEventHandler;
          }
        }
      }
    }

    public void SetParentObjectListners()
    {
      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanWrite && pi.CanRead &&
            pi.PropertyType.IsSubclassOf(typeof (DomainObject)) &&
            pi.GetCustomAttributes(typeof (DeleteRuleAttribute), true).Length > 0)
        {
          var parentObj = (DomainObject) pi.GetValue(this, null);
          if (parentObj != null)
          {
            parentObj.BeforeObjectDelete += BeforeParentDeleteEventHandler;
          }
        }
      }
    }

    public void UnsetParentObjectListners()
    {
      foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (pi.CanWrite && pi.CanRead &&
            pi.PropertyType.IsSubclassOf(typeof (DomainObject)) &&
            pi.GetCustomAttributes(typeof (DeleteRuleAttribute), true).Length > 0)
        {
          var parentObj = (DomainObject) pi.GetValue(this, null);
          if (parentObj != null)
          {
            parentObj.BeforeObjectDelete -= BeforeParentDeleteEventHandler;
          }
        }
      }
    }

    public void BeforeParentDeleteEventHandler(object sender, EventArgs e)
    {
      if (State == DOState.Clean || State == DOState.Dirty || State == DOState.New || State == DOState.VirtualNew)
      {
        if (sender is DomainObject)
        {
          var parentObj = (DomainObject) sender;
          foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
          {
            if (pi.CanWrite && pi.CanRead)
            {
              if (parentObj == pi.GetValue(this, null))
              {
                var rule = DeleteRule.Nothing;
                foreach (var attr in pi.GetCustomAttributes(typeof (DeleteRuleAttribute), false))
                {
                  rule = ((DeleteRuleAttribute) attr).Rule;
                }
                if (rule == DeleteRule.Restrict)
                  throw new ApplicationException(
                    LangTranslate.UiGetText("Нельзя удалить объект на который ссылаются другие"));
                if (rule == DeleteRule.Cascade)
                  Delete();
                if (rule == DeleteRule.SetNull)
                  pi.SetValue(this, null, null);
              }
            }
          }
        }
      }
    }

    public void DOListChangedEventHandler(object sender, DOListChangedEventArgs e)
    {
      if (State == DOState.Clean || State == DOState.Dirty || State == DOState.New || State == DOState.VirtualNew)
      {
        if (sender is IDOList)
        {
          var list = (IDOList) sender;

          foreach (var pi in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
          {
            if (pi.CanRead && pi.PropertyType.GetInterface("IDOList") != null && list == pi.GetValue(this, null))
            {
              #region Sets IdParent in Child Objects

              var childIdName = "";
              foreach (var attr in pi.GetCustomAttributes(typeof (ParentIdAttribute), true))
              {
                childIdName = ((ParentIdAttribute) attr).PropertyName;
              }
              if (childIdName != "" && childIdName != null)
              {
                if (e.ListChangedType == DOListChangedType.ItemAdded &&
                    e.NewObject != null)
                {
                  var piIdParentInChild = e.NewObject.GetType().GetProperty(childIdName);
                  if (piIdParentInChild == null)
                    throw new Exception("В объекте типа " + e.NewObject.GetType() + " нет свойсва " + childIdName);
                  if (!piIdParentInChild.CanWrite)
                    throw new Exception("В объекте типа " + e.NewObject.GetType() + " свойсво " + childIdName +
                                        " только для чтения");
                  piIdParentInChild.SetValue(e.NewObject, Id, null);
                }

                if (e.ListChangedType == DOListChangedType.ItemDeleted &&
                    e.OldObject != null)
                {
                  var piChild = e.OldObject.GetType().GetProperty(childIdName);
                  if (piChild.PropertyType == typeof (decimal?))
                    piChild.SetValue(e.OldObject, null, null);
                }

                if (e.ListChangedType == DOListChangedType.ItemChanged &&
                    e.NewObject != null &&
                    e.OldObject != null)
                {
                  var hasLEOneElement = true;
                  var firstOccurrance = list.IndexOf(e.OldObject);
                  if (firstOccurrance >= 0)
                  {
                    var lastOccurrance = list.LastIndexOf(e.OldObject);
                    if (lastOccurrance >= 0 && lastOccurrance != firstOccurrance)
                      hasLEOneElement = false;
                  }
                  if (hasLEOneElement)
                    e.NewObject.GetType().GetProperty(childIdName).SetValue(e.OldObject, null, null);
                  e.NewObject.GetType().GetProperty(childIdName).SetValue(e.NewObject, Id, null);
                }

                if (e.ListChangedType == DOListChangedType.Reset)
                {
                  foreach (DomainObject objChild in list)
                  {
                    objChild.GetType().GetProperty(childIdName).SetValue(objChild, null, null);
                  }
                }
              }

              #endregion

              #region Escalation of locking

              var setDirty = (pi.GetCustomAttributes(typeof (SetParentDirtyAttribute), true).Length > 0);
              if (setDirty)
              {
                NotifyBeforeObjectChange();
                NotifyPropertyChanged("");
              }

              #endregion
            }
          }
        }
      }
    }

    #endregion
  }
}