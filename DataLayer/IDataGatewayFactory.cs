using System;
using BSB.Common.DataGateway;
using ARM_User.DataLayer.DB.Gateway;
using ARM_User.DataLayer.DB;

namespace ARM_User.DataLayer
{
  public interface IDataGatewayFactory
  {
    IDataGateway GetGateway(Type type);

    #region Guides
    IDataGateway                GetLocalTextGateway();
    IDataGateway                GetSharedGateway();
    ICurrencyECBGateway         GetCurrencyECBGateway();
    IRegOrganMUGateway          GetRegOrganMUGateway();
    IExecutorGateway            GetExecutorGateway();    
    IDataGateway                GetSharerGateway();
    IRepFormGatewayGateway GetRepFormGateway();
    #endregion   

    #region Service

    IDataGateway RightsItemDataGateway();
    IUserGateway GetUserGateway();
    

    #endregion

    #region Reports
    IYearsQuarterMonthGateway GetYearsQuarterMonthGateway();
    IQuartersGateway GetQuartersGateway();
    IMonthsGateway GetMonthsGateway();
    #endregion
    

  }
}