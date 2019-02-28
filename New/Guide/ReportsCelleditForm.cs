using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
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
            rtbText.Text = HTMLText;
            rtbSQL.Text = getSQLText(p_str_id, p_col_id, p_date);
        }
        private void check(Int32 p_str_id_, Int32 p_col_id_, DateTime p_date_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try { 
                
                cmd.CommandText = "begin" +
                                       " :result := prepared.pkg_rep.sql_check(:p_str_id, :p_col_id, :p_date);" +
                                  "end;";
                cmd.BindByName = true;
                cmd.Parameters.Add("p_str_id", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                cmd.Parameters.Add("p_col_id", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                cmd.Parameters.Add("p_date", OracleDbType.Date, p_date_, ParameterDirection.Input);
                cmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
                cmd.ExecuteNonQuery();
                Int32 result = ((OracleDecimal)cmd.Parameters["result"].Value).ToInt32();
                    
                if (result == 0)
                        XtraMessageBox.Show("correct","Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                        XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.pkg_rep.sql_check");
                }
            }
        }
        private String getSQLText(Int32 p_str_id_, Int32 p_col_id_, DateTime p_date_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := prepared.pkg_rep.get_sql_user(:p_str_id, :p_col_id, :p_date);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str_id", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col_id", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_date", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    cmd.Parameters["result"].Size = 1024;
                    cmd.ExecuteNonQuery();
                    String result = ((OracleString)cmd.Parameters["result"].Value).ToString();

                    return result;
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.pkg_rep.sql_check");
                    return "error SQL";
                }
            }
        }
        private void cbCheck_CheckedChanged(object sender, EventArgs e)
        {
            check(p_str_id, p_col_id, p_date);
            
        }
    }
}
