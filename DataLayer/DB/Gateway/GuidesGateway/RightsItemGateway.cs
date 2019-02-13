using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
  public class RightsItemGateway : DataGateway
  {
    public override void Load(DataTable dataTable)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = "begin " +
                            "  open :p_cur for " +
                            "    select * from ADM.CURRENT_OFFICIAL_RIGHTS#; " +
                            "end;";
          cmd.Parameters.Add("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
          Adapter.SelectCommand = cmd;
          Adapter.Fill(dataTable);
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RightsItemGateway).");
      }
    }
  }
}