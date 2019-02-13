using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public class RightsItem : DomainObject
  {
    protected decimal ownerType;
    protected decimal rightOwner;

    public RightsItem(
      decimal id,
      decimal rightOwner,
      decimal ownerType)
      : base(id)
    {
      this.rightOwner = rightOwner;
      this.ownerType = ownerType;
    }

    public decimal RightOwner
    {
      get { return rightOwner; }
    }

    public decimal OwnerType
    {
      get { return ownerType; }
    }

    public interface IRightsItemFinder : ISimpleFinder<RightsItem, RightsItemList>
    {
    }
  }

  public class RightsItemList : DOList<RightsItem>
  {
  }
}