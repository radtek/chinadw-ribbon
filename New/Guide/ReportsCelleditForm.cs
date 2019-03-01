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
        public Int32 p_type;
        #endregion
        public ReportsCelleditForm()
        {
            InitializeComponent();
        }

        private void DialogHTMLCelleditForm_Load(object sender, EventArgs e)
        {
            rtbText.Text = HTMLText;
            String str = null;
            String result = getSQLText(p_str_id, p_col_id, p_date, p_type);

            if (result == "null")
                rtbSQL.Text = "";
            else
                rtbSQL.Text = result; 
        }
        private Int32 check(String p_sql_memo, DateTime p_date_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "begin" +
                                           " :result := pkg_rep.sql_check_arm(:p_sql_memo, :p_date);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters["p_sql_memo"].Size = 1024;
                    cmd.Parameters.Add("p_date", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
                    cmd.ExecuteNonQuery();
                    Int32 result = ((OracleDecimal)cmd.Parameters["result"].Value).ToInt32();

                    return result;
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "PREPARED.pkg_rep.sql_check");
                    return -1;
                }
            }
        }
        private String getSQLText(Int32 p_str_id_, Int32 p_col_id_, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := prepared.pkg_rep.get_rep_setup_sql_text(:p_str, :p_col, :p_dat, :p_type);" +
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
                    String s = "[get_rep_setup_sql_text] p_str_id_:" + p_str_id_.ToString()+ " p_col:"+ p_col_id_.ToString()+ " p_dat:"+ p_date_.ToString()+ " p_type:"+ p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + s);
                    return "error SQL";
                }
            }
        }
        private void saveSQLText(Int32 p_str_id_, Int32 p_col_id_, String p_sql_memo, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prepared.pkg_rep.upd_rep_setup_sql_text";
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
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "prepared.pkg_rep.get_rep_setup_sql_text\n " + s);
                    
                }
            }
        }
        private void cbCheck_CheckedChanged(object sender, EventArgs e)
        {
            String s = rtbSQL.Text;
            Int32 result = check(s, p_date);            
            if (result == 0)                
                XtraMessageBox.Show("correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else  if(result == 1)
                XtraMessageBox.Show("function null is not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == 2)
                XtraMessageBox.Show("column_name is not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    
        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {   
                if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
                {
                    XtraMessageBox.Show(
                  LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
                  LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    
                    if (check(rtbSQL.Text, p_date) == 0)
                    {
                        saveSQLText(p_str_id, p_col_id, rtbSQL.Text, p_date, p_type);
                        DialogResult = DialogResult.OK;
                        Close();    
                    }                        
                    else
                        XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in saveSQLText)");
            }
        }

        private void rtbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtabSQL;
        }
    }
}
