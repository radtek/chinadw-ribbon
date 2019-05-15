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

namespace ARM_User.New.DB
{
    class DB_RepSetupSQL
    {
        private OracleConnection pConncection;
        public DB_RepSetupSQL()
        {
            pConncection = dmControler.frmMain.oracleConnection;
        }
        public String get_rep_setup_sql_text(Int32 p_str_id_, Int32 p_col_id_, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := reporter.pkg_rep.get_rep_setup_sql_text(:p_str, :p_col, :p_dat, :p_type);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    cmd.Parameters["result"].Size = 1024;
                    cmd.ExecuteNonQuery();
                    String result = ((OracleString)cmd.Parameters["result"].Value).ToString();

                    return result;
                }
                catch (Exception oe)
                {
                    String s = "[get_rep_setup_sql_text] p_str_id_:" + p_str_id_.ToString() + " p_col:" + p_col_id_.ToString() + " p_dat:" + p_date_.ToString() + " p_type:" + p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + s);
                    return "error SQL";
                }
            }
        }
        public void upd_rep_setup_sql_text(Int32 p_str_id_, Int32 p_col_id_, String p_sql_memo, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "reporter.pkg_rep.upd_rep_setup_sql_text";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception oe)
                {
                    String s = "p_str_id_:" + p_str_id_.ToString() + "\n p_col:" + p_col_id_.ToString() + "\n p_sql_memo:" + p_sql_memo + "\n p_dat:" + p_date_.ToString() + "\n p_type:" + p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.get_rep_setup_sql_text\n " + s);

                }
            }
        }
        public void ins_rep_setup_sql_text(Int32 p_str_id_, Int32 p_col_id_, String p_sql_memo, DateTime p_date_, Int32 p_mart_col,  Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "reporter.pkg_rep.ins_rep_setup_sql_text";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_mart_col", OracleDbType.Int32, p_mart_col, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception oe)
                {
                    String s = "p_str_id_:" + p_str_id_.ToString() + "\n p_col:" + p_col_id_.ToString() + "\n p_sql_memo:" + p_sql_memo + "\n p_dat:" + p_date_.ToString() + "\n p_type:" + p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.get_rep_setup_sql_text\n " + s);

                }
            }
        }
        public void ins_sql_text_arm_proc(Int32 p_str_id_, Int32 p_col_id_, String p_sql_memo, DateTime p_date_, Int32 p_mart_col, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "reporter.pkg_rep.ins_sql_text_arm_proc";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_mart_col", OracleDbType.Int32, p_mart_col, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception oe)
                {
                    String s = "p_str_id_:" + p_str_id_.ToString() + "\n p_col:" + p_col_id_.ToString() + "\n p_sql_memo:" + p_sql_memo + "\n p_dat:" + p_date_.ToString() + "\n p_type:" + p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.get_rep_setup_sql_text\n " + s);

                }
            }
        }
        public void upd_sql_text_arm_proc(Int32 p_rep_setup_id, String p_sql_memo, DateTime p_date_,  Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "reporter.pkg_rep.upd_sql_text_arm_proc";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_rep_setup_id", OracleDbType.Int32, p_rep_setup_id, ParameterDirection.Input);                    
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);                    
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception oe)
                {                    
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.upd_sql_text_arm_proc\n " );
                }
            }
        }
    }
}
