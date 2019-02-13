using System.Collections.Generic;

namespace ARM_User.BusinessLayer.Common
{
  public interface IVirtualListLoader<ObjectType>
    where ObjectType : DomainObject
  {
    List<ObjectType> Load();
  }
}