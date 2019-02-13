using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Guides;
using ARM_User.BusinessLayer.Service;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides.Simple;
using ARM_User.MapperLayer.Guides;
using ARM_User.MapperLayer.Guides.Simple;
using ARM_User.BusinessLayer;
using ARM_User.BusinessLayer.Reports;
using ARM_User.MapperLayer.Reports;


namespace ARM_User.MapperLayer.Common
{
  public class MapperRegistry
  {
    #region Fields

    protected Dictionary<Type, AbstractMapper> reg = new Dictionary<Type, AbstractMapper>();

    #endregion

    #region Constructors

    public MapperRegistry()
    {
      #region Guides

      RegistryMapper(typeof(Shared), new SharedMapper());
      RegistryMapper(typeof(LocalText), new LocalTextMapper());
      RegistryMapper(typeof(CurrencyECB), new CurrencyECBMapper());
      RegistryMapper(typeof(RegOrganMU), new RegOrganMUMapper());
      RegistryMapper(typeof(Executor), new ExecutorMapper());
      RegistryMapper(typeof(Sharer), new SharerMapper());
      RegistryMapper(typeof(RepForm), new RepFormMapper());
      #endregion

      #region Services

      RegistryMapper(typeof (RightsItem), new RightsItemMapper());
      RegistryMapper(typeof (User), new UserMapper());            

      #endregion
        
      #region Reports

      RegistryMapper(typeof(YearsQuarterMonth), new YearsQuarterMonthMapper());
      RegistryMapper(typeof(Quarters), new QuartersMapper());
      RegistryMapper(typeof(Months), new MonthsMapper());

      #endregion
  
    }

    #endregion

    #region Protected methods

    protected void RegistryMapper(Type objType, AbstractMapper mapper)
    {
      reg.Add(objType, mapper);
    }

    #endregion

    #region Public methods

    public AbstractMapper GetMapper(Type objType)
    {
      AbstractMapper mapper = null;
      reg.TryGetValue(objType, out mapper);
      return mapper;
    }

    #endregion

    #region Guides

    public LocalTextMapper GetLocalTextMapper()
    {
      return (LocalTextMapper)reg[typeof(LocalText)];
    }
    public SharedMapper GetSharedMapper()
    {
      return (SharedMapper)reg[typeof(Shared)];
    }
    public CurrencyECBMapper GetCurrencyECBMapper()
    {
        return (CurrencyECBMapper)reg[typeof(CurrencyECB)];
    }
    public RegOrganMUMapper GetRegOrganMUMapper()
    {
        return (RegOrganMUMapper)reg[typeof(RegOrganMU)];
    }
    public ExecutorMapper GetExecutorMapper()
    {
        return (ExecutorMapper)reg[typeof(Executor)];
    }
   
    public SharerMapper GetSharerMapper()
    {
        return (SharerMapper)reg[typeof(Sharer)];
    }   
    public RepFormMapper GetRepFormMapper()
    {
        return (RepFormMapper)reg[typeof(RepForm)];
    }
   
    #endregion

    #region Service

    public RightsItemMapper GetRightsItemMapper()
    {
      return (RightsItemMapper) reg[typeof (RightsItem)];
    }
    public UserMapper GetUserMapper()
    {
      return (UserMapper) reg[typeof (User)];
    }

    
    #endregion
        

    #region Singelton implementation

    static MapperRegistry()
    {
      Instance = new MapperRegistry();
    }

    public static MapperRegistry Instance { get; private set; }

    #endregion

    #region Reports
    public YearsQuarterMonthMapper GetYearsQuarterMonthMapper()
    {
        return (YearsQuarterMonthMapper)reg[typeof(YearsQuarterMonth)];
    }
    public QuartersMapper GetQuartersMapper()
    {
        return (QuartersMapper)reg[typeof(Quarters)];
    }
    public MonthsMapper GetMonthsMapper()
    {
        return (MonthsMapper)reg[typeof(Months)];
    }
    #endregion

  
  }
}