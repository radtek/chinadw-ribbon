using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.ManagedDataAccess.Client;
using BSB.Common.DataGateway;
using BSB.Common.DB;

namespace ARM_User.DataLayer.DB.Gateway
{
   
        public interface IUserGateway : IDataGateway
        {
            void Load(DataTable dataTable, decimal id_popup);
            void Load2(DataTable dataTable, decimal id);
        }

        public class UserGateway : DataGateway, IUserGateway
        {
            public override void Load(DataTable dataTable)
            {
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "prepared.pkg_user.read_user_list";
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
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.UserGateway).");
                }
            }
            public void Load(DataTable dataTable, decimal id_popup)
            {
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "S_G_READ_USER_LIST";
                        cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                        cmd.Parameters.Add("id_popup_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                        cmd.Parameters["id_popup_"].Value = (id_popup == null) ? (decimal?)null : id_popup;
                        cmd.Parameters["Err_Msg"].Size = 4000;
                        Adapter.SelectCommand = cmd;
                        Adapter.Fill(dataTable);
                    }
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.UserGateway).");
                }
            }

            public void Load2(DataTable dataTable, decimal id)
            {
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "S_G_READ_USER_SIMPLE";
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
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.UserGateway).");
                }
            }
        }
    
}