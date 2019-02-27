using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ReportsCelleditForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
    # region [field]
            public String HTMLText;
        public Int32 p_str_id;
        public Int32 p_col_id;
        public DateTime p_date;
        #endregion
        public ReportsCelleditForm()
        {
            InitializeComponent();
        }

        private void DialogHTMLCelleditForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = HTMLText;
        }
        private void check(Int32 p_str_id, Int32 p_col_id, DateTime p_date)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText =
                                "begin" +
                                    "-- Call the function" +
                                    ":result:= pkg_rep.sql_check(p_str_id => :p_str_id," +
                                               "p_col_id => :p_col_id," +
                                               "p_date => :p_date);" +
                                "end;";
                cmd.Parameters.Add("p_str_id", OracleDbType.Int32, p_str_id, ParameterDirection.Input);
                cmd.Parameters.Add("p_col_id", OracleDbType.Int32, p_col_id, ParameterDirection.Input);
                cmd.Parameters.Add("p_date", OracleDbType.Date, p_date, ParameterDirection.Input);
                cmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
                cmd.ExecuteNonQuery();
                if (((OracleDecimal)cmd.Parameters["result"].Value).ToInt32() == 1)
                    MessageBox.Show("Check - OK");
                else
                    MessageBox.Show("Check - not check");

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
                        dsMain.Tables["tableReportsHeader"].Columns.Add(dc);
                    }

                    int count = dr.FieldCount;
                    object[] values = new object[count];

                    while (dr.Read())
                    {
                        try
                        {
                            dr.GetValues(values);
                            dsMain.Tables["tableReportsHeader"].LoadDataRow(values, true);
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

        private void cbCheck_CheckedChanged(object sender, EventArgs e)
        {
            check(p_str_id, p_col_id, p_date);
        }
    }
}
