using ARM_User.New.DB;
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
    
    public partial class ReportsCelleditFormShowEdit : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        public String p_NAME;
        public Int32 p_VALUE;

        private DB_RepSetupSQL db;

        public Int32 p_str_id;
        public Int32 p_col_id;
        public String p_sql_memo;
        public DateTime p_date;
        public Int32 p_type;
        public Int32 p_mart_col;
        public Int32 p_rep_setup_id;

        public ReportsCelleditFormShowEdit()
        {
            InitializeComponent();
        }
       

        private void ReportsCelleditFormShowEdit_Load(object sender, EventArgs e)
        {
            db = new DB_RepSetupSQL();
            te_value.Text = p_VALUE.ToString();            
        }
        protected override bool Validate()
        {
            if (te_value.Text.Trim() == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Введите значение"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                te_value.Focus();
                return false;
            }
            return true;
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            p_sql_memo = te_value.Text;
            
                Cursor = Cursors.WaitCursor;
                Int32 result = check();
                if (result == 0)
                {
                    if (State == ServiceLayer.Service.Editor.EditorState.Insert)
                    {
                        try
                        {
                            db.ins_sql_text_arm_proc(p_str_id, p_col_id, p_sql_memo, p_date, p_mart_col, p_type);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_insert_loans_map)");
                        }
                    }
                    else if (State == ServiceLayer.Service.Editor.EditorState.Edit)
                    {
                        try
                        {
                            db.upd_sql_text_arm_proc(p_rep_setup_id, p_sql_memo, p_date, p_type);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_update_loans_map)");
                        }
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                } else
                    XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;                            
        }
        private Int32 check()
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "begin" +
                                           " :result := prepared.pkg_rep.sql_check_arm_proc(:p_mart_col, :p_sql_memo, :p_dat, :p_type);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_mart_col", OracleDbType.Int32, p_mart_col, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type, ParameterDirection.Input);
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
        private void btnCheck_Click(object sender, EventArgs e)
        {

            Int32 result = check();
            if (result == 0)
                XtraMessageBox.Show("correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == 1)
                XtraMessageBox.Show("function null is not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == 2)
                XtraMessageBox.Show("column_name is not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
