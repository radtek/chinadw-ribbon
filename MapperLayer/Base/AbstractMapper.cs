using System;
using System.Collections.Generic;

using ARM_User.BusinessLayer.Common;
using BSB.Common.DataGateway.Oracle;
using Oracle.ManagedDataAccess.Client;

namespace ARM_User.MapperLayer.Common
{
    public abstract class AbstractMapper : IComparable
  {
    protected OracleConnection Connection
    {
      get { return ConnectionHolder.Instance.Connection; }
    }

    #region IComparable Members

    int IComparable.CompareTo(object obj)
    {
      if (!(obj is AbstractMapper))
        throw new ArgumentException();
      return GetPriority() - ((AbstractMapper) obj).GetPriority();
    }

    #endregion

    public virtual int GetPriority()
    {
      return 1;
    }

    protected abstract string IdName();
    public abstract void Insert(ICollection<DomainObject> objCollection);
    public abstract void Update(ICollection<DomainObject> objCollection);
    public abstract void Delete(ICollection<DomainObject> objCollection);

    public static bool BoolOracleToDotNet(decimal value)
    {
      return (value == 1);
    }

    public static decimal BoolDotNetToOracle(bool value)
    {
      return value ? 1 : 0;
    }

    public static decimal? GetDecimal(object obj)
    {
      if (obj is decimal)
        return (decimal) obj;
      return null;
    }

    public static DateTime? GetDateTime(object obj)
    {
      if (obj is DateTime)
        return (DateTime) obj;
      return null;
    }

    public static Boolean? GetBool(object obj)
    {
      if (obj is Boolean)
        return (Boolean) obj;
      return null;
    }

    public static string GetString(object obj)
    {
      if (obj is string)
        return (string) obj;
      if (obj == null || obj is DBNull)
        return "";
      return obj.ToString();
    }
  }
}