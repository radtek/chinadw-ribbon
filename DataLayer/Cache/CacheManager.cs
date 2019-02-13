using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using BSB.Common.DataGateway;

namespace ARM_User.DataLayer.Cache
{
  public class CacheManager
  {
    private readonly Dictionary<Type, CacheTable> tables;

    protected CacheManager()
    {
      tables = new Dictionary<Type, CacheTable>();
    }

    #region Singelton implementation

    //static CacheManager instance;

    //static CacheManager()
    //{
    //  instance = new CacheManager();
    //}

    public static CacheManager Instance
    {
      get
      {
        if (SessionVariables.Instance.CacheManager == null)
          SessionVariables.Instance.CacheManager = new CacheManager();
        return SessionVariables.Instance.CacheManager;
      }
    }

    #endregion

    public DataTable GetTable(Type tableType)
    {
      return tables[tableType].Store;
    }

    public void RegisterTable(DataTable store, IDataGateway gateway)
    {
      tables.Add(store.GetType(), new CacheTable(store, gateway));
    }

    public void MarkAsNeedLoad(Type tableType)
    {
      if (tables.ContainsKey(tableType))
        tables[tableType].NeedLoad = true;
    }

    private class CacheTable
    {
      private bool needLoad = true;
      private readonly IDataGateway gateway;
      private readonly DataTable store;

      public CacheTable(DataTable store, IDataGateway gateway)
      {
        this.store = store;
        this.gateway = gateway;
      }

      public bool NeedLoad
      {
        get { return needLoad; }
        set { needLoad = value; }
      }

      public DataTable Store
      {
        get
        {
          if (NeedLoad)
          {
            Load();
          }
          return store;
        }
      }

      private void Load()
      {
        store.Clear();
        gateway.Load(store);
        needLoad = false;
      }
    }
  }
}