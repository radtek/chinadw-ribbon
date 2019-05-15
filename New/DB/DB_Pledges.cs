using BSB.Common;
using BSB.Common.DB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM_User.New.DB
{
    class DB_Pledges
    {
        private OracleConnection pConncection;
        public DB_Pledges()
        {
            pConncection = dmControler.frmMain.oracleConnection;
        }
        public void getReadListCredits(ref DataSet ds, DateTime date_)
        {
            if (ds.Tables.Contains("tsCredits")) ds.Tables["tsCredits"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_list_credits";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsCredits"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.getReadListCredits)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadListPledges(ref DataSet ds, DateTime date_, Int32 loan_sid_)
        {
            if (ds.Tables.Contains("tsPledges")) ds.Tables["tsPledges"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_list_pledges";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsPledges"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.getReadListPledges)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadCurrencyPledgesPopup(ref DataSet ds, DateTime date_)
        {
            if (ds.Tables.Contains("tsCurrency")) ds.Tables["tsCurrency"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.g_read_pledge_currency_popup";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);                
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsCurrency"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.getReadCurrencyPledgesPopup)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadPledgestypePopup(ref DataSet ds, DateTime date_, Int32 pokaz_parent_id_)
        {
            if (ds.Tables.Contains("tsPledgesType")) ds.Tables["tsPledgesType"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.g_read_pledge_pokaz_popup";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_parent_id_", OracleDbType.Int32, pokaz_parent_id_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsPledgesType"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.getReadPledgestypePopup)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadPaymentPlan(ref DataSet ds, DateTime date_, Int32 loan_sid_)
        {
            if (ds.Tables.Contains("tsPaymentPlan")) ds.Tables["tsPaymentPlan"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_list_repayment_plan";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsPaymentPlan"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.getReadPaymentPlan)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadListPokaz(ref DataSet ds, DateTime date_, Int32 loan_sid)
        {
            if (ds.Tables.Contains("tsPokaz")) ds.Tables["tsPokaz"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_list_pokaz";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsPokaz"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.getReadListPokaz)");
                }
                finally
                {
                    oda.Dispose();
                }
            }

        }
        public void pro_delete_loans_map(Int32 loan_sid_, DateTime report_date_, Int32 abs_dimension_id_, Int32 pokaz_id_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_delete_loans_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_dimension_id_", OracleDbType.Int32, abs_dimension_id_, ParameterDirection.Input);
                cmd.Parameters.Add("pokaz_id_", OracleDbType.Int32, pokaz_id_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_map)");
            }
        }
        public void getReadListExtraPokaz(ref DataSet ds, DateTime date_, Int32 loan_sid)
        {
            if (ds.Tables.Contains("tsExtraPokaz")) ds.Tables["tsExtraPokaz"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_list_extrapokaz";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {

                    oda.Fill(ds.Tables["tsExtraPokaz"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.getReadListExtraPokaz)");
                }
                finally
                {
                    oda.Dispose();
                }
            }

        }
        public void pro_delete_loans_add_map(Int32 loan_sid_, DateTime report_date_, Int32 abs_constant_loans_map_id_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_delete_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("abs_constant_loans_map_id_", OracleDbType.Int32, abs_constant_loans_map_id_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_DELETE_LOANS_ADD_MAP)");
            }
        }
        public void create_XML(ref DataSet ds, DateTime date_)
        {
            if (ds.Tables.Contains("tsXML")) ds.Tables["tsXML"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.proc_xml_create_list";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tsXML"]);
                }
                catch (Exception oe)
                {
                    //DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Pledges.create_XML)");
                    MessageBox.Show(oe.Message);
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
    }
}
