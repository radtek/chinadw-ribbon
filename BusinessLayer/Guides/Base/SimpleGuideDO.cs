using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public abstract class SimpleGuideDO : DomainObject
  {
    protected string name;

    public SimpleGuideDO()
    {
    }

    public SimpleGuideDO(
      decimal id,
      string name)
      : base(id)
    {
      this.name = name;
    }

    public string Name
    {
      get { return name; }
      set
      {
        NotifyBeforeObjectChange();
        name = value;
        NotifyPropertyChanged("Name");
      }
    }

    public override string ToString()
    {
      return Name;
    }

    #region IComparable Members

    public override int CompareTo(object obj)
    {
      if (obj is SimpleGuideDO)
      {
        var cmp = Name.CompareTo(((SimpleGuideDO) obj).Name);
        if (cmp != 0)
          return cmp;
      }
      return base.CompareTo(obj);
    }

    #endregion
  }
}