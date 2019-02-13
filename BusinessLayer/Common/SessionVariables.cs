using System;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer;
using ARM_User.DataLayer.Cache;
using BSB.Common.DB;

namespace ARM_User.BusinessLayer.Common
{
  public class SessionVariables
  {
    #region Public static methods

    public static void Clear()
    {
      instance = null;
    }

    #endregion

    #region Fields

    protected static SessionVariables instance;
    public IDataGatewayFactory CacheFactory;
    public CacheManager CacheManager;
    public RightsItemList CurrentRights;
    private DateTime? today;

    #endregion

    #region Properties

    public static SessionVariables Instance
    {
      get
      {
        if (instance == null)
          instance = new SessionVariables();
        return instance;
      }
    }

    public DateTime Now
    {
      get { return DBSupport.GetServerTime(); }
    }

    public DateTime Today
    {
      get
      {
        if (today == null)
          today = DBSupport.GetServerTime().Date;
        return today.Value;
      }
    }

    #endregion
  }
}