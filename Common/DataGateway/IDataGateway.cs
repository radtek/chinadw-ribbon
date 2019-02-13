using System;
using System.Data;

namespace BSB.Common.DataGateway
{
  public interface IDataGateway
  {
    void Load(DataTable dataTable);
    void Load(Decimal key, DataTable dataTable);
    void Lock(DataRow dataRow);
    void Update(DataTable dataTable);
  }

  public interface IChildDataGateway : IDataGateway
  {
    void LoadByParent(decimal idParent, DataTable dataTable);
  }

  public interface IChildGroupDataGateway : IDataGateway
  {
    void LoadByParents(decimal[] idParents, DataTable dataTable);
  }
}