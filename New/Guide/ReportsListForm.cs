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
using BSB.Common;
using System.Collections;

namespace ARM_User.New.Guide
{
    public partial class ReportsListForm : ARM_User.DisplayLayer.Guides.Base.ChinaGuideBaseForm
    {
        #region [field]
            private DB_Reports db;
            public Boolean RowSelectFlag = false;
            private ArrayList active_rows = new ArrayList();
        #endregion
        public ReportsListForm()
        {
            InitializeComponent();
            //just
            db = new DB_Reports();
            
        }

        private void ReportsListForm_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            refreshPeriod();
            //db.getReadReportList(ref dsMain, "A");
            //bCount.Caption = dsMain.Tables["tableReports"].Rows.Count.ToString();
            //bPeriod.EditValue = rPeriodComboBox.Items[0].ToString();


            
            bPeriod.EditValue = rPeriodComboBox.Items[0].ToString();
        }
        private void refreshPeriod()
        {
            
            db.getReadListPeriods(ref dsMain);

            rPeriodComboBox.Items.Add("ALL");
            
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

                DataTable dt = dsMain.Tables["tableReports"];
                foreach (DataRow row in dt.Rows)
                {
                    //Int32 val = Convert.ToInt32(row[dt.Columns[8]]);
                    if (row[dt.Columns[8]].Equals(1))
                        active_rows.Add(row[dt.Columns[0]]);
                }
            }

        }
        private void rbutton_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //MessageBox.Show(" report_id:"+getCurrentID("tableReports", "report_id").ToString());

            Boolean fsql_arm = getCurrentName("tableReports", "sql_arm").ToString().Trim()=="";
            Boolean frep_type = getCurrentName("tableReports", "rep_type").ToString().Trim() == "";
            String s = "SQL_ARM или REP_TYPE пусто";            
            
            if (fsql_arm || frep_type)
            {
                MessageBox.Show(s);
            }
            else
            {
                Int32 rep_id = getCurrentID("tableReports", "report_id");
                var frm = new ReportsCustomizeForm();                
                frm.Text = "["+rep_id.ToString()+"] "+getCurrentName("tableReports", "name").ToString();
                frm.Height = Height;
                frm.Width = Convert.ToInt32(Width * 0.8);
                frm.rep_type_ = Convert.ToInt32(getCurrentName("tableReports", "rep_type")); /*Тип отчета*/
                frm.sql_arm_ = getCurrentName("tableReports", "sql_arm").ToString();
                frm.report_id_ = rep_id;
                frm.ShowDialog();
            }
            //Cursor = Cursors.Default;
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //result = -1;
            }
            return result;
        }
        #endregion

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colrep_num)
            {
                String s = e.CellValue.ToString();
                Int32 i = Convert.ToInt32(s);

                if (!active_rows.Contains(i))

                {
                    RowSelectFlag = true;
                    e.Appearance.BackColor = Color.LightBlue;
                }
                else
                {
                    RowSelectFlag = false;
                }
            }
            else if (e.Column == colname || e.Column == colcode || e.Column == colperiod || e.Column == colrep_type
              || e.Column == coldate_begin || e.Column == coldate_end || e.Column == colis_active)
            {
                if (RowSelectFlag) e.Appearance.BackColor = Color.LightBlue;
            }
        }

        private void bPeriod_EditValueChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
    }
}