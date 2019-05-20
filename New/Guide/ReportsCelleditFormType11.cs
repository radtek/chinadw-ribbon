using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ReportsCelleditFormType11 : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        #region
        public Int32 p_str_id;
        public Int32 p_col_id;
        public DateTime p_date;
        public Int32 p_cell_type;
        #endregion
        public ReportsCelleditFormType11()
        {
            InitializeComponent();
        }

        private void ReportsCelleditFormType11_Load(object sender, EventArgs e)
        {
            getCellList(ref dsMain);            
        }
        
        #region [READ LIST]
        private void getCellList(ref DataSet ds)
        {
            if (ds.Tables.Contains("tbForm11")) ds.Tables["tbForm11"].Clear();
            ds.Tables["tbForm11"].Columns.Clear();
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT c.name, t.sql_text, t.head_gl_str_id, t.head_gl_col_id, t.rep_mart_col_gl_id, t.rep_setup_id " +
                                  "FROM reporter.REP_SETUP t, reporter.rep_mart_cols c " +
                                 "WHERE " +
                                   "t.setup_type = :REP_TYPE " +
                                   " and t.rep_mart_col_gl_id = c.rep_mart_col_gl_id " +
                                   " and t.date_begin < :P_REP_DATE " +
                                   " and t.date_end > :P_REP_DATE " +
                                   " and t.head_gl_str_id = :P_STR_ID" +
                                   " and t.head_gl_col_id = :P_COL_ID " +
                                 "ORDER BY t.rep_setup_id";
                cmd.Parameters.Add("REP_TYPE", OracleDbType.Int32, p_cell_type, ParameterDirection.Input);
                cmd.Parameters.Add("P_REP_DATE", OracleDbType.Date, p_date, ParameterDirection.Input);
                cmd.Parameters.Add("P_STR_ID", OracleDbType.Int32, p_str_id, ParameterDirection.Input);
                cmd.Parameters.Add("P_COL_ID", OracleDbType.Int32, p_col_id, ParameterDirection.Input);
                
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
                        ds.Tables["tbForm11"].Columns.Add(table_column);
                    }

                    int count = dr.FieldCount;
                    object[] values = new object[count];

                    while (dr.Read())
                    {
                        try
                        {
                            dr.GetValues(values);
                            ds.Tables["tbForm11"].LoadDataRow(values, true);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in ReportsCelleditFormType11) " + "PREPARED.getReportsListF21");
                        }
                    }
                    tslCount.Text = dsMain.Tables["tbForm11"].Rows.Count.ToString();
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in ReportsCelleditFormType11) ");
                }

            }
        }
        #endregion
        
        #region [current data]
        private Int32 getCurrentID(String sTable, String sField)
        {
            Int32 result = -1;
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToInt32(row[sField]);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = 0;
            }
            return result;
        }
        private String getCurrentName(String sTable, String sField)
        {
            String result = "";
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = row[sField].ToString();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = "";
            }
            return result;
        }
        #endregion
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            getCellList(ref dsMain);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var frm = new ReportsCelleditFormShowEdit();
            frm.Text = "Редакирование значения";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            frm.p_NAME = getCurrentName("tbForm11", "name");
            frm.p_VALUE = getCurrentID("tbForm11", "sql_text");
            frm.p_str_id = getCurrentID("tbForm11", "head_gl_str_id");
            frm.p_col_id = getCurrentID("tbForm11", "head_gl_col_id");
            frm.p_mart_col = getCurrentID("tbForm11", "rep_mart_col_gl_id");
            frm.p_rep_setup_id = getCurrentID("tbForm11", "rep_setup_id");
            frm.p_date = p_date;
            frm.p_type = p_cell_type;
            frm.ShowDialog();
            getCellList(ref dsMain);
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            var frm = new ReportsCelleditFormShowEdit();
            frm.Text = "Добавить значение";
            frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
            frm.p_NAME = ""; //getCurrentName("tbForm11", "name");
            //frm.p_VALUE = 0; //getCurrentID("tbForm11", "sql_text");
            frm.p_str_id = getCurrentID("tbForm11", "head_gl_str_id");
            frm.p_col_id = getCurrentID("tbForm11", "head_gl_col_id");
            frm.p_mart_col = getCurrentID("tbForm11", "rep_mart_col_gl_id");
            frm.p_date = p_date;
            frm.p_type = p_cell_type;
            frm.ShowDialog();
            getCellList(ref dsMain);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            tsbEdit_Click(sender, e);
        }
    }
}
