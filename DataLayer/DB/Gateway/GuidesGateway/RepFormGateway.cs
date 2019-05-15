using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.ManagedDataAccess.Client;
using BSB.Common.DataGateway;
using BSB.Common.DB;
using BSB.Common;

namespace ARM_User.DataLayer.DB.Gateway
{
    public interface IRepFormGatewayGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id_kind);
        void Load(DataTable dataTable, Int64 id_rep);
    }
    public class RepFormGateway : DataGateway, IRepFormGatewayGateway
    {
        public override void Load(DataTable dataTable)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "main.G_READ_REP_FORM_LIST";
                    cmd.Parameters.Add("Report_Knd_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("IdUsr_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Report_Knd_"].Value = 0;
                    cmd.Parameters["IdUsr_"].Value = InitApplication.currentUser.Id;
                    cmd.Parameters["Err_Msg"].Size = 4000;                    
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dataTable);
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RepFormGateway).");
            }
            //catch (Exception ex)
            //{
            //    var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
            //    if (rethrow)
            //        throw;
            //}
        }
        public void Load(DataTable dataTable, decimal id_kind)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "G_READ_REP_FORM_LIST";
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Report_Knd_", OracleDbType.Decimal, ParameterDirection.Input);                   


                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                    cmd.Parameters["Report_Knd_"].Value = (id_kind == null) ? (decimal?)null : id_kind;                    
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dataTable);
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RepFormGateway).");
            }
        }
        public void Load(DataTable dataTable, Int64 id_rep)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "G_READ_FORM_SIMPLE";
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Id_Rep_", OracleDbType.Decimal, ParameterDirection.Input);


                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                    cmd.Parameters["Id_Rep_"].Value = 101;// (id_rep == null) ? (decimal?)null : id_rep;
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dataTable);
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RepFormGateway).");
            }
        }
    }
}