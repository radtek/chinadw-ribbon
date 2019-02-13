using System;
using System.Collections.Generic;
using ARM_User.DataLayer.DataSet.GuidesDataSet;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.DataLayer.DB.Gateway;
using BSB.Common.DataGateway;
using ARM_User.DataLayer.DataSet;
using ARM_User.DataLayer.DataSet.Reports;


namespace ARM_User.DataLayer.DB
{
  public class DBDataGatewayFactory : IDataGatewayFactory
  {
    #region Fields

    private readonly Dictionary<Type, IDataGateway> store = new Dictionary<Type, IDataGateway>();

    #endregion

    #region Constructors

    public DBDataGatewayFactory()
    {
      #region Simple Guides

      store.Add(typeof(ARM_User.DataLayer.DataSet.CommonDataSet.SharedDS.REF_SHAREDDataTable), new SharedGateway());
      store.Add(typeof(LocalTextDS.REF_LOCAL_TEXTDataTable), new LocalTextGateway());      
      store.Add(typeof(CurrencyECBDS.S_G_CURRENCY_ECBDataTable), new CurrencyECBGateway());
      store.Add(typeof(RegOrganMUDS.S_G_REG_ORGAN_MUDataTable), new RegOrganMUGateway());
      store.Add(typeof(ExecutorDS.S_G_EXECUTORDataTable), new ExecutorGateway());
      store.Add(typeof(SharerDS.S_G_SHARERDataTable), new SharerGateway());
      store.Add(typeof(RepFormDS.G_FORMDataTable), new RepFormGateway());
      #endregion

     #region Services

      store.Add(typeof (UserDS.UserDSDataTable), new UserGateway());
      store.Add(typeof (RightsItemDS._CURRENT_OFFICIAL_RIGHTS_DataTable), new RightsItemGateway());
      
      #endregion

      #region Reports
      store.Add(typeof(YearsQuarterMonthDS.G_REPORT_STRDataTable), new YearsQuarterMonthGateway());
      store.Add(typeof(QuartersDS.G_QUARTERSDataTable), new QuartersGateway());
      store.Add(typeof(MonthsDS.G_MONTHSDataTable), new MonthsGateway());
      #endregion
    
    }
  


    #endregion

    #region Public methods

    public virtual IDataGateway GetGateway(Type type)
    {
      return store[type];
    }

    #endregion

    #region Guides
   
    public ICurrencyECBGateway GetCurrencyECBGateway()
    {
        return (ICurrencyECBGateway)GetGateway(typeof(CurrencyECBDS.S_G_CURRENCY_ECBDataTable));
    }
    
    public IDataGateway GetSharedGateway()
    {
      return GetGateway(typeof (ARM_User.DataLayer.DataSet.CommonDataSet.SharedDS.REF_SHAREDDataTable));
    }
    public IDataGateway GetLocalTextGateway()
    {
      return GetGateway(typeof (LocalTextDS.REF_LOCAL_TEXTDataTable));
    }
   
    public IRegOrganMUGateway GetRegOrganMUGateway()
    {
        return (IRegOrganMUGateway)GetGateway(typeof(RegOrganMUDS.S_G_REG_ORGAN_MUDataTable));
    }
    
    public IExecutorGateway GetExecutorGateway()
    {
      return (IExecutorGateway)GetGateway(typeof (ExecutorDS.S_G_EXECUTORDataTable));
    }
    
    public IDataGateway GetSharerGateway()
    {
        return GetGateway(typeof(SharerDS.S_G_SHARERDataTable));
    }
    
    public IRepFormGatewayGateway GetRepFormGateway()
    {
        return (IRepFormGatewayGateway)GetGateway(typeof(RepFormDS.G_FORMDataTable));
    }   
    #endregion

    #region Services

    public IDataGateway RightsItemDataGateway()
    {
      return GetGateway(typeof (RightsItemDS._CURRENT_OFFICIAL_RIGHTS_DataTable));
    }    
    public IUserGateway GetUserGateway()
    {
        return (IUserGateway)GetGateway(typeof(UserDS.UserDSDataTable));
    }
 
    #endregion 
    

    #region Reports
    public IYearsQuarterMonthGateway GetYearsQuarterMonthGateway()
    {
        return (IYearsQuarterMonthGateway)GetGateway(typeof(YearsQuarterMonthDS.G_REPORT_STRDataTable));
    }
    public IQuartersGateway GetQuartersGateway()
    {
        return (IQuartersGateway)GetGateway(typeof(QuartersDS.G_QUARTERSDataTable));
    }
    public IMonthsGateway GetMonthsGateway()
    {
        return (IMonthsGateway)GetGateway(typeof(MonthsDS.G_MONTHSDataTable));
    }
    #endregion
   

  }
}

