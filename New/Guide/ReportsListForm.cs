using ARM_User.New.DB;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            gridView1.OptionsNavigation.UseOfficePageNavigation = true;
            gridView1.MoveNextPage();
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
            db.getReadReportList(ref dsMain, s.Substring(0, 1));
            bCount.Caption = dsMain.Tables["tableReports"].Rows.Count.ToString();
        }               
        private void rbutton_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show("Кнопка нажата");
        }
        private void rPeriodComboBox_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            refreshReports();
        }
    }
}
