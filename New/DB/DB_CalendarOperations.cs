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
    class DB_CalendarOperations
    {
        private OracleConnection pConncection;

        public DB_CalendarOperations(OracleConnection conn)
        {
            pConncection = conn;
        }
        public void getReadList(ref DataSet ds)
        {
            if (ds.Tables.Contains("CalendarOp")) ds.Tables["CalendarOp"].Clear();

            OracleCommand cmd = pConncection.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.G_Read_G_CALENDAR_List"; //gzet_manual_obl --> get_adm_users                
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
                //cmd.Parameters.Add("date_", OracleDbType.Date, date_.Date, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {                   
                    oda.Fill(ds.Tables["CalendarOp"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_CalendarOperations.getReadList)");
                }
                finally
                {
                    oda.Dispose();
                }
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void updateCalendar(DateTime reportdate, int status)
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_calendar_op.PRO_UPDATE_CALENDAR";
                cmd.Parameters.Add("reportdate", OracleDbType.Date, reportdate, ParameterDirection.Input);
                cmd.Parameters.Add("status", OracleDbType.Int32, status, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_CalendarOperations.updateCalendar)");
            }
        }

        public void upgradeCalendar()
        {
            try
            {
                OracleCommand cmd = pConncection.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.pkg_interface_calendar_op.insert_p_calendar_day";
                cmd.ExecuteNonQuery();
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_CalendarOperations.upgradeCalendar)");
            }
        }
    }
}
