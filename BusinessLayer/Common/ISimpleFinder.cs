namespace ARM_User.BusinessLayer.Common
{
  public interface ISimpleFinder
  {
    DomainObject Find(decimal id);
    IDOList FindAll();
    void Refresh(decimal id);
  }

  public interface ISimpleFinder<ObjectType, ObjectListType>
  {
    ObjectType Find(decimal id);
    ObjectListType FindAll();
    void Refresh(decimal id);
  }
}