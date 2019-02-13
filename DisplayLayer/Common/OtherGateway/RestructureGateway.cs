using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using BSB.Common.DataGateway;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;

namespace ARM_User.DataLayer.DB.Gateway
{

    public interface IRestructureGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id, decimal idsts);
    }

    public class RestructureGateway : DataGateway, IRestructureGateway
    {

        public override void Load(DataTable dataTable)
        {
            throw new NotImplementedException();
        }

        public void Load(DataTable dataTable, decimal id, decimal idsts)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "main.R_Read_Restructure_List";
                    cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("IdSts_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
                    cmd.Parameters["Id_"].Value = id;
                    cmd.Parameters["IdSts_"].Value = idsts;
                    Adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
                if (rethrow)
                    throw;
            }

        }
    }
}