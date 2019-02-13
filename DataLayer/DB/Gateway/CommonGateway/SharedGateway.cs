using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
  public class SharedGateway : DataGateway
  {
    public SharedGateway()
    {
    }

    public SharedGateway(OracleConnection connection)
      : base(connection)
    {
    }

    public override void Load(DataTable dataTable)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "main.pkg_ref.read_shared_list";
          cmd.Parameters.Add("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
          cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
          cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          cmd.Parameters["p_err_msg"].Size = 4000;
          Adapter.SelectCommand = cmd;
          Adapter.Fill(dataTable);
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharedGateway)");
      }
    }
  }
}