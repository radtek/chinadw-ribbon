using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
        public void getReportsListF21(ref DataSet ds, String sql_arm_, Int32 rep_type_, DateTime date_)
        {
            if (ds.Tables.Contains("tbForm21")) ds.Tables["tbForm21"].Clear();
            ds.Tables["tbForm21"].Columns.Clear();
            using (OracleCommand cmd = pConncection.CreateCommand())
            {                
                cmd.BindByName = true;
                cmd.CommandType = CommandType.Text; 
                cmd.CommandText = sql_arm_+ " WHERE TYPE=:REP_TYPE"; 
                cmd.Parameters.Add("P_REP_DATE", OracleDbType.Date, date_, ParameterDirection.Input);
                cmd.Parameters.Add("REP_TYPE", OracleDbType.Int32, rep_type_, ParameterDirection.Input);
                try
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    // fileds of dataset
                    for (Int32 i = 0; i < dr.FieldCount; i++)
                    {
                        String str = dr.GetName(i);
                        DataColumn table_column = new DataColumn();
                        table_column.Caption = str;
                        table_column.ColumnName = str;
                        table_column.DataType = dr.GetFieldType(i);
                        ds.Tables["tbForm21"].Columns.Add(table_column);
                    }

                    int count = dr.FieldCount;
                    object[] values = new object[count];

                    while (dr.Read())
                    {
                        try
                        {
                            dr.GetValues(values);
                            ds.Tables["tbForm21"].LoadDataRow(values, true);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports) " + "PREPARED.getReportsListF21");
                        }
                    }
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports) " + sql_arm_);
                }
            }
        }
        public void getReadReporHeadertList(ref DataSet ds, DateTime date_, Int32 report_id_)
        {
            if (ds.Tables.Contains("tableReportsHeader"))
            {
                ds.Tables["tableReportsHeader"].Clear();
                ds.Tables["tableReportsHeader"].Columns.Clear();
            }
            else
            {
                ds.Tables.Add("tableReportsHeader");
            }

            using (OracleCommand cmd = pConncection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_reports_header";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);                
                cmd.Parameters.Add("report_id_", OracleDbType.Int32, report_id_, ParameterDirection.Input);
                cmd.Parameters.Add("date_", OracleDbType.Date, date_, ParameterDirection.Input);
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);
                try
                {
                    OracleDataReader dr = cmd.ExecuteReader();


                    // fileds of dataset
                    for (Int32 i = 0; i < dr.FieldCount; i++)
                    {
                        DataColumn dc = new DataColumn();
                        dc.Caption = dr.GetName(i); ;
                        dc.ColumnName = dr.GetName(i); ;
                        dc.DataType = dr.GetFieldType(i);
                        ds.Tables["tableReportsHeader"].Columns.Add(dc);
                    }

                    int count = dr.FieldCount;
                    object[] values = new object[count];

                    while (dr.Read())
                    {
                        try
                        {
                            dr.GetValues(values);
                            ds.Tables["tableReportsHeader"].LoadDataRow(values, true);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.g_read_g_reports_header");
                        }
                    }
                
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.g_read_g_reports_header");
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