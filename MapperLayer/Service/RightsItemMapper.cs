using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.MapperLayer.Common;

namespace ARM_User.MapperLayer.Guides
{
  public class RightsItemMapper :
    SimpleMapper
      <RightsItem, RightsItemList, RightsItemDS._CURRENT_OFFICIAL_RIGHTS_DataTable,
        RightsItemDS._CURRENT_OFFICIAL_RIGHTS_Row>, RightsItem.IRightsItemFinder
  {
    public override RightsItem Find(decimal id)
    {
      if (SessionVariables.Instance.CurrentRights == null)
      {
        SessionVariables.Instance.CurrentRights = FindAll();
        SessionVariables.Instance.CurrentRights.GetSource();
      }
      return (RightsItem) UnitOfWork.Instance.FindObject(typeof (RightsItem), id, false);
    }

    protected override RightsItem CreateByRow(RightsItemDS._CURRENT_OFFICIAL_RIGHTS_Row row)
    {
      var obj = new RightsItem(
        row.RIGHTS_ITEM,
        row.RIGHT_OWNER,
        row.OWNER_TYPE);
      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    public override void Delete(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    protected override string IdName()
    {
      return "RIGHTS_ITEM";
    }
  }
}