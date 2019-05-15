using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.ManagedDataAccess.Client;
using BSB.Common.DataGateway;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
    public interface IExecutorGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id_guides, decimal idknd);
        void Load(DataTable dataTable, decimal id);
    }
    public class ExecutorGateway : DataGateway, IExecutorGateway
  {
    public override void Load(DataTable dataTable)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "main.S_G_READ_EXECUTOR_LIST";
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
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorGateway).");
      }
      //catch (Exception ex)
      //{
      //  var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
      //  if (rethrow)
      //    throw;
      //}
    }
    public void Load(DataTable dataTable, decimal id_guides, decimal idknd)
    {
        try
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "main.S_G_READ_EXECUTOR_LIST";
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("id_guides_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("IdKnd_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["id_guides_"].Value = (id_guides == null) ? (decimal?)null : id_guides;
                cmd.Parameters["IdKnd_"].Value = (id_guides == null) ? (decimal?)null : idknd;
                cmd.Parameters["Err_Msg"].Size = 4000;
                Adapter.SelectCommand = cmd;
                Adapter.Fill(dataTable);
            }
        }
        catch (Exception oe)
        {
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorGateway).");
        }
        //catch (Exception ex)
        //{
        //    var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
        //    if (rethrow)
        //        throw;
        //}
    }

    public void Load(DataTable dataTable, decimal id)
    {
        try
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "main.S_G_READ_EXECUTOR_SIMPLE";
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("id_", OracleDbType.Decimal, ParameterDirection.Input);                
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["id_"].Value = id;                
                cmd.Parameters["Err_Msg"].Size = 4000;
                Adapter.SelectCommand = cmd;
                Adapter.Fill(dataTable);
            }
        }
        catch (Exception oe)
        {
            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorGateway).");
        }    
    }
   
  }
}