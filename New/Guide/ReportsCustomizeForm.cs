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
        public Int32 report_id_;
        public Int32 rep_custom_type;
        #endregion
        public ReportsCustomizeForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            /*barEditItemType.EditValue = repositoryItemComboBox2.Items[1].ToString();
            /*refreshFormList(1);*/
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rep_custom_type = repositoryItemComboBox2.Items.IndexOf(barEditItemType.EditValue) + 1;
            /*if (rep_type_ == 11)
            {
                rep_custom_type += 10;
            }*/

            refreshFormList(rep_custom_type);
        }
        public void refreshFormList(Int32 rep_custom_type_)
        {
            String s = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            

            try
            {
                db.getReportsListF21(ref dsMain, sql_arm_, rep_custom_type_, report_date_);
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(Ошибка при чтений формы ) ");
                return;
            }

            db.getReadReporHeadertList(ref dsMain, report_date_, report_id_);
            gridControl1.RefreshDataSource();
            gridView1.PopulateColumns();

            string[] header = new string[] { "№", "num", "Найменование", "код" };

            if (gridView1.Columns.Count > 15) this.WindowState = FormWindowState.Maximized;
               else this.WindowState = FormWindowState.Normal;

            for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                if (i <= 3)
                {
                    gridView1.Columns[i].Caption = header[i];
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                    if (i != 2) {
                        gridView1.Columns[i].BestFit();
                        gridView1.OptionsView.ColumnAutoWidth = false;
                    } else {
                        gridView1.Columns[i].Width = 250;
                        gridView1.OptionsView.ColumnAutoWidth = true;
                    }

                    gridView1.Columns[i].Fixed = FixedStyle.Left;

                }
                    else
                    {
                        //gridView1.Columns[i].Width = 150;
                        gridView1.Columns[i].Caption = " ";
                        //gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    if (i % 2 == 0) gridView1.Columns[i].AppearanceCell.BackColor = Color.LightBlue;
                    else {
                        gridView1.Columns[i].AppearanceCell.BackColor = Color.White;                        
                    }
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
                        gridView1.Columns[delta + j].FieldName = row[dt.Columns[0]].ToString();                        
                        j++;
                    }
                }
                catch(Exception oe)
                {

                }
                
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
            for (int i=4; i<gridView1.Columns.Count; i++)
            {
                if (e.Column == gridView1.Columns[i])
                {
                    e.Column.ColumnEdit = rbEdit;
                }
            }
        }

        private void rbEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            String s_date = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s_date);

            String s = ((Control)sender).Text;
            if (s.Trim() != "")
            {
                
                Int32 str_id = getCurrentID("tbForm21", "str_id");
                Int32 col_id = Convert.ToInt32(gridView1.FocusedColumn.FieldName);
                DateTime rep_date = Convert.ToDateTime(FilterDateTime.Date);
                if (rep_type_==11) rep_custom_type += 10;
                
                /*тип отчета*/
                switch (rep_custom_type)
                {
                    /*case 1: 
                        {
                            var frm = new ReportsCelleditForm();
                            frm.HTMLText = s;
                            frm.p_str_id = str_id;
                            frm.p_col_id = col_id;
                            frm.p_date = rep_date;
                            frm.p_type = rep_custom_type; //rep_type_;
                            frm.ShowDialog();
                            break;
                        }*/
                    case 11:
                        {
                            var frm = new ReportsCelleditFormType11();
                            frm.Text = "Редактирование ячейки";
                            frm.p_str_id = str_id;
                            frm.p_col_id = col_id;
                            frm.p_date = rep_date;
                            frm.p_setup_type = rep_custom_type;// +10; //rep_type_; 
                            frm.ShowDialog();
                            rep_custom_type -= 10;
                            break;
                        }
                    default:
                        {
                            var frm = new ReportsCelleditForm();
                            frm.HTMLText = s;
                            frm.p_str_id = str_id;
                            frm.p_col_id = col_id;
                            frm.p_date = rep_date;
                            frm.p_type = rep_custom_type; //rep_type_;
                            frm.ShowDialog();
                            if (rep_custom_type > 10) rep_custom_type -= 10;
                            break;
                            /*String s2 = getCurrentName("tbForm21", "str_id");
                            String s3 = gridView1.FocusedColumn.FieldName;
                            MessageBox.Show("["+s2 +":"+s3+"]");
                            break;*/
                        }
                
                
            }
                refreshFormList(rep_custom_type);
            }
            Cursor = Cursors.Default;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //refreshFormList();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            db = new DB_Reports();
            barEditItemType.EditValue = repositoryItemComboBox2.Items[0].ToString();
            refreshFormList(1);            
        }

        private void barEditItemDate_EditValueChanged(object sender, EventArgs e)
        {
            rep_custom_type = repositoryItemComboBox2.Items.IndexOf(barEditItemType.EditValue) + 1;
            //if (rep_type_ == 11) rep_custom_type += 10;
            refreshFormList(rep_custom_type);
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

        private void gridView1_ColumnPositionChanged(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {            
            //richTextBox1.Text = e.CellValue.ToString();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            MessageBox.Show("OK!..");
        }
    }
}
