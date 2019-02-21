using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ARM_User.New.DB
{
    class DB_LoansListForm
    {
        private OracleConnection pConncection;
        

        public DB_LoansListForm(OracleConnection conn)
        {
            pConncection = conn;
        }
        // READ CREDITS
        public void getReadListCredits(ref DataSet ds, DateTime date_)
        {
            if (ds.Tables.Contains("tsCredits")) ds.Tables["tsCredits"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())                
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
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
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.getReadListCredits)");
                }
                finally
                {
                    oda.Dispose();
                }
            }                
        }
        // READ EXTRA POKAZ
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
        //READ POKAZ
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
        // INSERT LOANS EXTRA POKAZ
        public void pro_insert_loans_add_map(Int32 loan_sid_, DateTime report_date_, 
            String p_creg_contract_no_, String p_creg_contract_date_, String p_crreg_line_contract_no_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_insert_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("p_creg_contract_no_", OracleDbType.Varchar2, p_creg_contract_no_, ParameterDirection.Input);
                cmd.Parameters.Add("p_creg_contract_date_", OracleDbType.Varchar2, p_creg_contract_date_, ParameterDirection.Input);
                cmd.Parameters.Add("p_crreg_line_contract_no_", OracleDbType.Varchar2, p_crreg_line_contract_no_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_INSERT_LOANS_ADD_MAP)");
            }
        }
        // UPDATE LOANS EXTRA POKAZ
        public void pro_update_loans_add_map(Int32 loan_sid_, DateTime report_date_,
            String p_creg_contract_no_, String p_creg_contract_date_, String p_crreg_line_contract_no_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_update_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("p_creg_contract_no_", OracleDbType.Varchar2, p_creg_contract_no_, ParameterDirection.Input);
                cmd.Parameters.Add("p_creg_contract_date_", OracleDbType.Varchar2, p_creg_contract_date_, ParameterDirection.Input);
                cmd.Parameters.Add("p_crreg_line_contract_no_", OracleDbType.Varchar2, p_crreg_line_contract_no_, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_UPDATE_LOANS_ADD_MAP)");
            }
        }
        // DELETE LOANS EXTRA POKAZ
        public void pro_delete_loans_add_map(Int32 loan_sid_, DateTime report_date_)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_orepations.pro_delete_loans_add_map";
                cmd.Parameters.Add("loan_sid_", OracleDbType.Int32, loan_sid_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);                
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_DELETE_LOANS_ADD_MAP)");
            }
        }
    }
    
}
