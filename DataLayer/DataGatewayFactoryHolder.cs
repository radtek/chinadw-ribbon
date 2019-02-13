using ARM_User.BusinessLayer.Common;
using ARM_User.DataLayer.Cache;

namespace ARM_User.DataLayer
{
  public class DataGatewayFactoryHolder
  {
    public static IDataGatewayFactory CacheFactory
    {
      get
      {
        if (SessionVariables.Instance.CacheFactory == null)
          SessionVariables.Instance.CacheFactory = new CacheDataGatewayFactory();
        return SessionVariables.Instance.CacheFactory;
      }
    }
  }
}