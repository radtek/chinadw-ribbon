using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
    public class SharerGateway : DataGateway
    {
        public override void Load(DataTable dataTable)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prepared.G_READ_SHARER_LIST";
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
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharerGateway).");
            }
        }
    }
}