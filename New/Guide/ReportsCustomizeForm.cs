﻿using ARM_User.New.DB;
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
            refreshFormList(1);*/
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshFormList(rep_custom_type);
        }
        private void refreshFormList(Int32 rep_custom_type_)
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

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (i <= 3)
                    {
                        gridView1.Columns[i].Caption = header[i];
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                        gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                        gridView1.Columns[i].BestFit();
                    }
                    else
                    {
                        //gridView1.Columns[i].Width = 150;
                        gridView1.Columns[i].Caption = " ";
                        gridView1.Columns[i].AppearanceCell.BackColor = Color.SkyBlue;
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

            String s_date = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s_date);

            String s = ((Control)sender).Text;
            if (s.Trim() != "")
            {
                /*тип отчета*/
                switch (rep_type_)
                {
                    case 1: 
                        {
                            var frm = new ReportsCelleditForm();
                            frm.HTMLText = s;
                            frm.p_str_id = getCurrentID("tbForm21", "str_id");
                            frm.p_col_id = Convert.ToInt32(gridView1.FocusedColumn.FieldName);
                            frm.p_date = Convert.ToDateTime(FilterDateTime.Date);
                            frm.p_type = rep_type_;
                            frm.ShowDialog();
                            break;
                        }
                    default:
                        {
                            String s2 = getCurrentName("tbForm21", "str_id");
                            String s3 = gridView1.FocusedColumn.FieldName;
                            MessageBox.Show("["+s2 +":"+s3+"]");
                            break;
                        }
                
                
            }
            }
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
    }
}
