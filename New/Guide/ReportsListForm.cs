using ARM_User.New.DB;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagedList;
namespace ARM_User.New.Guide
{
    public partial class ReportsListForm : ARM_User.DisplayLayer.Guides.Base.ChinaGuideBaseForm
    {
        #region [field]
            private DB_Reports db;
        #endregion
        public ReportsListForm()
        {
            InitializeComponent();
            
        }

        private void ReportsListForm_Load(object sender, EventArgs e)
        {
            db = new DB_Reports();
            refreshPeriod();
            //gridView1.OptionsView.ColumnHeaderAutoHeight = true;

        }
        private void refreshPeriod()
        {
            
            db.getReadListPeriods(ref dsMain);


            DataTable dt = dsMain.Tables["tablePeriod"];
            foreach (DataRow row in dt.Rows)
            {
                //foreach (DataColumn col in dt.Columns)                    
                rPeriodComboBox.Items.Add(row[dt.Columns[1]]);
            }
        }
        private void refreshReports()
        {
            String s = bPeriod.EditValue.ToString();
            if (s != "") { 
                db.getReadReportList(ref dsMain, s.Substring(0, 1));
                bCount.Caption = dsMain.Tables["tableReports"].Rows.Count.ToString();
                //dataGridViewPaging1.DataSource = dsMain.Tables["tableReports"];
            }

        }               
        private void rbutton_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Boolean fsql_arm = getCurrentName("tableReports", "sql_arm").ToString()=="";
            Boolean frep_type = getCurrentName("tableReports", "rep_type").ToString() == "";
            String s = "SQL_ARM или REP_TYPE пусто";            
            
            if (fsql_arm && frep_type)
            {
                MessageBox.Show(s);
            }
            else
            {
                var frm = new ReportsCustomizeForm();
                frm.Height = Height;
                frm.Width = Convert.ToInt32(Width * 0.8);
                frm.rep_type_ = Convert.ToInt32(getCurrentName("tableReports", "rep_type"));
                frm.sql_arm_ = getCurrentName("tableReports", "sql_arm").ToString();
                frm.report_id_ = getCurrentID("tableReports", "report_id");
                frm.ShowDialog();
            }
                    
        }
        private void rPeriodComboBox_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            refreshReports();
        }
        #region [current date getting]
        // Получить текущий ID задав table и field
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
        private DateTime getCurrentReportDate(String sTable, String sField)
        {
            DateTime result = new DateTime();
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToDateTime(row[sField]);
            }
            catch (Exception ex)
            {
                //result = -1;
            }
            return result;
        }
        #endregion
    }
}
