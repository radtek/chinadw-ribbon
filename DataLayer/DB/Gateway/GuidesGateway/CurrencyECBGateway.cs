using System;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using BSB.Common.DataGateway;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using BSB.Common;
using System.Windows.Forms;

namespace ARM_User.DataLayer.DB.Gateway
{
    public interface ICurrencyECBGateway : IDataGateway
    {
        void Load(DataTable dataTable, decimal id_guides, decimal id);
    }
    public class CurrencyECBGateway : DataGateway, ICurrencyECBGateway
    {
        public override void Load(DataTable dataTable)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "main.g_read_g_currency_ecb_list";
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
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ArticlesKOAPMapper).");
            }
            /*catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
                if (rethrow)
                    throw;
            }*/
        }
        public void Load(DataTable dataTable, decimal id_guides, decimal id)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "main.g_read_g_currency_ecb_list";
                    cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add("id_guides_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("id_", OracleDbType.Decimal, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                    cmd.Parameters["id_guides_"].Value = id_guides;
                    cmd.Parameters["id_"].Value = id;
                    cmd.Parameters["Err_Msg"].Size = 4000;
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dataTable);
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ArticlesKOAPMapper).");
            }
        }
    }
}