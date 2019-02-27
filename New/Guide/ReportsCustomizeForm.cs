using ARM_User.New.DB;
using BSB.Common.DB;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ReportsCustomizeForm : ARM_User.DisplayLayer.Guides.Base.ChinaGuideBaseForm
    {
        #region [field]
            private DB_Reports db;

        public Int32 rep_type_;
        public String sql_arm_;
        #endregion
        public ReportsCustomizeForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            refreshFormList();
            barEditItemType.EditValue = repositoryItemComboBox2.Items[1];
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshFormList();
        }
        private void refreshFormList()
        {
            String s = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);            
            rep_type_ = repositoryItemComboBox2.Items.IndexOf(barEditItemType.EditValue) + 1;


            /*try
            {*/
            try
            {
                db.getReportsListF21(ref dsMain, sql_arm_, rep_type_, report_date_);
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(Ошибка при чтений формы ) ");
                return;
            }

            db.getReadReporHeadertList(ref dsMain, rep_type_, report_date_);
                gridControl1.RefreshDataSource();
                gridView1.PopulateColumns();

                string[] header = new string[] { "№", "num", "Найменование", "код" };

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (i > 3)
                    {
                        gridView1.Columns[i].Width = 150;
                        gridView1.Columns[i].AppearanceCell.BackColor = Color.SkyBlue;
                    }
                    else
                    {
                        gridView1.Columns[i].Caption = header[i];
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                        gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                        gridView1.Columns[i].BestFit();
                    }
                }


                DataTable dt = dsMain.Tables["tableReportsHeader"];
                int j = 0;
                int delta = 4;
            if (dsMain.Tables["tableReportsHeader"].Rows.Count >= 0)
            {
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        gridView1.Columns[delta + j].Caption = row[dt.Columns[1]].ToString();
                        j++;
                    }
                }
                catch(Exception oe)
                {

                }
                
            }                
            //}
            /*catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + sql_arm_ + "(occured in refreshFormList) ");
            }*/
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            for(int i=4; i<gridView1.Columns.Count; i++)
            {
                if (e.Column == gridView1.Columns[i])
                {
                    e.Column.ColumnEdit = rbEdit;
                }
            }
            
        }

        private void rbEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            String s = ((Control)sender).Text;
            var frm = new ReportsCelleditForm();
            frm.HTMLText = s;
            frm.ShowDialog();

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //refreshFormList();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            db = new DB_Reports();
            refreshFormList();
        }

        private void barEditItemDate_EditValueChanged(object sender, EventArgs e)
        {
            refreshFormList();
        }
    }
}
