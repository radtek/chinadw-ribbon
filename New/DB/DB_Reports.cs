using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_User.New.DB
{
    class DB_Reports
    {
        private OracleConnection pConncection;

        public DB_Reports()
        {
            pConncection = dmControler.frmMain.oracleConnection;
        }

        public DB_Reports(OracleConnection conn)
        {
            pConncection = conn;
        }
        // READ CREDITS
        public void getReadListPeriods(ref DataSet ds)
        {
            getStandartReadList(ref ds, "tablePeriod", "PREPARED.g_read_g_reports_period_list");
        }
        public void getReadReportList(ref DataSet ds, String filter_text_)
        {            
            if (ds.Tables.Contains("tableReports")) ds.Tables["tableReports"].Clear();

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_reports_report_list";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("filter_text_",OracleDbType.Varchar2, filter_text_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tableReports"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.g_read_g_reports_report_list");
                }
                finally
                {
                    oda.Dispose();
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
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)"+ scmd);
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
    }
}
