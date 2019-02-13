using System.Data;
using ARM_User.DataLayer.DB.Gateway;

namespace ARM_User.DataLayer.Cache.Gateway
{
  public class CacheRightsItemGateway : RightsItemGateway
  {
    public override void Load(DataTable dataTable)
    {
      //TODO:
      //DataTable t = CacheManager.Instance.GetTable(typeof(RightsItemDS.CURRENT_OFFICIAL_RIGHTSDataTable));
      //dataTable.Load(t.CreateDataReader());
    }
  }
}