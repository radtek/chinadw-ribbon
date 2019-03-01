using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class LoansAddPopupForm : ARM_User.DisplayLayer.Base.ChoiceTreeBaseForm
    {
        public Int32 ABS_CONSTANT_DIMENSION_ID;
        public String NAME;
        public String CODE;
        public String NOTE;

        public LoansAddPopupForm()
        {
            InitializeComponent();
        }
        #region [Read List]
        public void getReadPopuptList(ref DataSet ds)
        {
            if (ds.Tables.Contains("tablePopupList")) ds.Tables["tablePopupList"].Clear();

            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PREPARED.g_read_g_loans_popup";
                cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);                
                cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                try
                {
                    oda.Fill(ds.Tables["tablePopupList"]);
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in LoansAddPopupForm)" + "PREPARED.g_read_g_loans_popup");
                }
                finally
                {
                    oda.Dispose();
                }
            }
        }
        #endregion

        #region [Current Data]
        private void LoansAddPopupForm_Load(object sender, EventArgs e)
        {
            getReadPopuptList(ref dsMain);            
        }
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
            catch (Exception ex)
            {
                result = -1;
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
                result = Convert.ToString(row[sField]);
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }

        private void LoansAddPopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ABS_CONSTANT_DIMENSION_ID = getCurrentID("tablePopupList", "abs_constant_dimension_id");
            NAME = getCurrentName("tablePopupList", "name");
            CODE = getCurrentName("tablePopupList", "code");
            NOTE = getCurrentName("tablePopupList", "note");
        }
    }
    #endregion
}
