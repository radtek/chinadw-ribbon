using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARM_User.MapperLayer.Common;
using ARM_User.BusinessLayer;
using ARM_User.DataLayer.DataSet;
using BSB.Common.DataGateway.Oracle;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BSB.Common.DataGateway;

namespace ARM_User.DataLayer.DB.Gateway
{
    public interface IQuartersGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id_guides);
    }
    public class QuartersGateway : DataGateway, IQuartersGateway
    {
        public override void Load(DataTable dataTable)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "S_G_READ_YEARS_Q_M_LIST";
                    cmd.Parameters.Add("is_period_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                    cmd.Parameters["is_period_"].Value = 0;
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
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
        public void Load(DataTable dataTable, decimal id_guides)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "S_G_READ_YEARS_Q_M_LIST";
                    cmd.Parameters.Add("is_period_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);


                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'decimal' is never equal to 'null' of type 'decimal?'
                    cmd.Parameters["is_period_"].Value = (id_guides == null) ? (decimal?)null : id_guides;
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'decimal' is never equal to 'null' of type 'decimal?'
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
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
