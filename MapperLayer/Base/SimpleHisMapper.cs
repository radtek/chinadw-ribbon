using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.DataLayer;
using ARM_User.DataLayer.Cache;

namespace ARM_User.MapperLayer.Common
{
  public abstract class SimpleHisMapper<ObjectType, ObjectListType, TableType, RowType, ObjectHisType, ObjectHisListType,
    TableHisType, RowHisType>
    : SimpleMapper<ObjectType, ObjectListType, TableType, RowType>
    where ObjectType : DomainObject
    where ObjectListType : DOList<ObjectType>, new()
    where TableType : DataTable, new()
    where RowType : DataRow
    where ObjectHisType : DomainObject
    where ObjectHisListType : DOList<ObjectHisType>, new()
    where TableHisType : DataTable, new()
    where RowHisType : DataRow
  {
    protected TableHisType tabHis = new TableHisType();
    protected abstract ObjectType CreateByRow(RowType row, DataRow[] rowsHis);
    protected abstract ObjectHisType CreateHisByRow(RowHisType row);
    protected abstract string RootIdName();

    protected override void MarkAsNeedLoad()
    {
      base.MarkAsNeedLoad();
      CacheManager.Instance.MarkAsNeedLoad(typeof (TableHisType));
    }

    protected override ObjectType CreateByRow(RowType row)
    {
      var id = Convert.ToDecimal(row[IdName()]);
      var rowsHis = tabHis.Select(RootIdName() + "=" + id);
      return CreateByRow(row, rowsHis);
    }

    protected override List<ObjectType> FindByTableLoader(TableLoader tabLoader, bool forceRewrite)
    {
      var gwHis = DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof (TableHisType));
      gwHis.Load(tabHis);
      return base.FindByTableLoader(tabLoader, forceRewrite);
    }

    protected ObjectHisListType FindHis(DataRow[] rowsHis)
    {
      var objList = new ObjectHisListType();

      foreach (var r in rowsHis)
      {
        var row = (RowHisType) r;

        var id = Convert.ToDecimal(row[IdName()]);

        var obj = (ObjectHisType) UnitOfWork.Instance.FindObject(typeof (ObjectHisType), id, false);
        if (obj == null)
        {
          if (!UnitOfWork.Instance.IsObjectRegisteredAsRemoved(typeof (ObjectHisType), id, false))
          {
            obj = CreateHisByRow(row);
            UnitOfWork.Instance.RegisterClean(obj);
          }
        }

        if (obj != null)
          objList.Add(obj);
      }
      return objList;
    }
  }
}