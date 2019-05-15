using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.ManagedDataAccess.Client;
using BSB.Common.DataGateway;
using DevExpress.XtraReports.Design;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
    public interface IRegOrganMUGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id_guides, decimal id_ref);
    }
    public class RegOrganMUGateway : DataGateway, IRegOrganMUGateway
   { 
    public override void Load(DataTable dataTable)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "main.S_G_READ_REG_ORGAN_MU_LIST";
          cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
          cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
          cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
          cmd.Parameters["Err_Msg"].Size = 4000;
          Adapter.SelectCommand = cmd;
          Adapter.Fill(dataTable);
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUGateway).");
      }
      //catch (Exception ex)
      //{
      //  var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
      //  if (rethrow)
      //    throw;
      //}
    }
    public void Load(DataTable dataTable, decimal id_guides, decimal id_ref)
    {
        try
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "main.S_G_READ_REG_ORGAN_MU_LIST";
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("id_guides_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("id_ref_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["id_guides_"].Value = (id_guides == null) ? (decimal?)null : id_guides;
                cmd.Parameters["id_ref_"].Value = (id_ref == null) ? (decimal?)null : id_ref;
                cmd.Parameters["Err_Msg"].Size = 4000;
                Adapter.SelectCommand = cmd;
                Adapter.Fill(dataTable);
            }
        }
        catch (Exception oe)
        {
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUGateway).");
        }
    }
  }
}