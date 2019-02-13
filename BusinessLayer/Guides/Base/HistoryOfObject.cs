using System;
using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public abstract class HistoryOfObject : DomainObject
  {
    public abstract void CopyAddedPropertiesTo(HistoryOfObject obj);

    #region Constructors

    public HistoryOfObject(
      decimal idParent)
    {
      this.idParent = idParent;      
      isLast = true;
    }

    public HistoryOfObject(
      decimal idParent,      
      bool isLast)
    {
      this.idParent = idParent;
      this.isLast = isLast;
    }

    public HistoryOfObject(
      decimal id,
      decimal idParent,
      bool isLast)
      : base(id)
    {
      this.idParent = idParent;
      this.isLast = isLast;
    }

    public HistoryOfObject(
      decimal id,
      User editUser,
      DateTime? editTime,
      decimal idParent,
      bool isLast)
      : base(id, editUser, editTime)
    {
      this.idParent = idParent;
      this.isLast = isLast;
    }

    #endregion

    #region Fields

    protected decimal idParent;
    protected bool isLast;
    protected DateTime datechange;  

    #endregion

    #region Properties

    public decimal IdParent
    {
      get { return idParent; }
      set
      {
        NotifyBeforeObjectChange();
        idParent = value;
        NotifyPropertyChanged("IdParent");
      }
    }

   public bool IsLast
    {
      get { return isLast; }
      set
      {
        NotifyBeforeObjectChange();
        isLast = value;
        NotifyPropertyChanged("IsLast");
      }
    }

    #endregion
  }
}