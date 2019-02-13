using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.DataLayer.DB;
using BSB.Common.DataGateway;

namespace ARM_User.DataLayer.Cache
{
  public class CacheDataGatewayFactory : DBDataGatewayFactory
  {
    private readonly Dictionary<Type, IDataGateway> store = new Dictionary<Type, IDataGateway>();

    protected void AddToCache(DataTable dataTable, IDataGateway cacheGateway)
    {
      store.Add(dataTable.GetType(), cacheGateway);
      CacheManager.Instance.RegisterTable(dataTable, base.GetGateway(dataTable.GetType()));
    }

    #region IDataGatewayFactory Members

    public override IDataGateway GetGateway(Type type)
    {
      if (store.ContainsKey(type))
        return store[type];
      return base.GetGateway(type);
    }

    #endregion
  }
}