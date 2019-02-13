using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSB.Common.DataGateway.Oracle;
using System.Data;
using Oracle.DataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DataLayer.DB.Gateway
{
    public class JurPersonGateway : DataGateway
    {
        public override void Load(DataTable dataTable)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "G_Read_G_Jur_Person_List";
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
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
