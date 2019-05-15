using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSB.Common;
using BSB.Common.DB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace ARM_User.New.DB
{
    class DB_ExportRep
    {
        private OracleConnection pConncection;

        public DB_ExportRep()
        {
            pConncection = dmControler.frmMain.oracleConnection;
        }
        public void getReadListPeriods(ref DataSet ds)
        {
            getStandartReadList(ref ds, "tablePeriod", "PREPARED.g_read_g_reports_period_list");
        }
        public void getReadExportRepList(ref DataSet ds, String filter_text_, DateTime report_date_, Int32 zo_)
        {

            if (ds.Tables.Contains("tableReports")) ds.Tables["tableReports"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_export_rep_list";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("filter_text_", OracleDbType.Varchar2, filter_text_, ParameterDirection.Input);
                cmd.Parameters.Add("report_date_", OracleDbType.Date, report_date_, ParameterDirection.Input);
                cmd.Parameters.Add("zo_", OracleDbType.Int32, zo_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tableReports"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.g_read_g_export_rep_list");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public void getReadExportRepHistoryList(ref DataSet ds, Int32 rep_name_id_)
        {

            if (ds.Tables.Contains("tableHistory")) ds.Tables["tableHistory"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_export_history_list";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("rep_name_id_", OracleDbType.Int32, rep_name_id_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tableHistory"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.g_read_g_export_history_list");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        public Int32 getCALL(String cal_rep_, DateTime date_, Int32 p_zo)
        {   
            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                Int32 result = -1;
                
                try
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = cal_rep_;  //"reporter.pkg_041_fs_zpd_msfo.ins_data"; //
                    cmd.Parameters.Add("p_rep_date", OracleDbType.Date, date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_zo", OracleDbType.Int32, p_zo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_err_code", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.Parameters.Add("p_err_msg", OracleDbType.Clob, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    //result = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();
                    
                    return result;
                }
                catch (Exception oe)
                {
                    var emsg = String.Format("\nПараметры:\n P_REP_DATE: {0}\n", date_.Date );
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExportRep) " + cal_rep_+ emsg);
                    return result;
                }
            }
        }
        public Int32 getIntegrStat(Boolean stat_param, Int32 report_id, String integr_stat_, DateTime rep_date_,DateTime begin_date_, DateTime end_date_, Int32 zo_)
        {
            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                Int32 result = 0;

                try
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = integr_stat_; // :P_REP_DATE, :P_BEGIN_DATE, :P_END_DATE, :P_ZO, :P_ERR_CODE
                    cmd.Parameters.Add("p_report_id", OracleDbType.Decimal, report_id, ParameterDirection.Input);
                    cmd.Parameters.Add("p_rep_date", OracleDbType.Date, rep_date_.Date, ParameterDirection.Input);
                    if (stat_param)
                    {
                        cmd.Parameters.Add("p_begin_date", OracleDbType.Date, begin_date_, ParameterDirection.Input);
                        cmd.Parameters.Add("p_end_date", OracleDbType.Date, end_date_.Date, ParameterDirection.Input);
                    }                    
                    cmd.Parameters.Add("p_zo", OracleDbType.Decimal, zo_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_err_code", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.Parameters.Add("p_err_msg", OracleDbType.Clob, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    result = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();

                    return result;
                }
                catch (Exception oe)
                {
                    var emsg = String.Format("\nПараметры:\n P_REP_DATE: {0}\nP_BEGIN_DATE: {1}\nP_END_DATE: {2}\nP_ZO: {3}\nREPORT_ID: {4}", rep_date_.Date, begin_date_.Date, end_date_.Date, zo_, report_id); 
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_ExportRep) " + integr_stat_+emsg);
                    return result;
                }
            }
        }
        public void getStandartReadList(ref DataSet ds, String table, String scmd)
        {
            if (ds.Tables.Contains(table)) ds.Tables[table].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = scmd;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables[table]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + scmd);
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
    }
}
