namespace ARM_User.BusinessLayer.Common
{
  public static class IdGenerator
  {
    private static decimal sqn;

    public static decimal GetNextId()
    {
      sqn = sqn - 1;
      return sqn;
    }
  }
}