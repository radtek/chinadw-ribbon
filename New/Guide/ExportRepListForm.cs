using ARM_User.New.DB;
using BSB.Common;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ExportRepListForm : BSB.Common.MDIChildForm
    {
        #region [field]
            private DB_ExportRep db;
        public Boolean RowSelectFlag = false;        
        private ArrayList active_rows = new ArrayList();
        #endregion
        public ExportRepListForm()
        {
            InitializeComponent();
            db = new DB_ExportRep();
            repositoryItemDateEdit1.ShowClear = false;
        }

        private void ExportRepListForm_Load(object sender, EventArgs e)
        {
            refreshPeriod();
            gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            /*
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getReadExportRepList(ref dsMain, "M", FilterDateTime.Date, Convert.ToInt32(btSwitchZO.Checked));           
            bCount.Caption = dsMain.Tables["tableReports"].Rows.Count.ToString();
            */
            bPeriod.EditValue = rPeriodComboBox.Items[0].ToString();

        }
        private void rPeriodComboBox_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            refreshReports();
        }
        private void refreshPeriod()
        {

            db.getReadListPeriods(ref dsMain);

            //rPeriodComboBox.Items.Add("ALL");
            DataTable dt = dsMain.Tables["tablePeriod"];
            foreach (DataRow row in dt.Rows)
            {
                //foreach (DataColumn col in dt.Columns)                    
                rPeriodComboBox.Items.Add(row[dt.Columns[1]]);
            }
        }
        private void refreshReports()
        {
            int saveRowIndex;
            saveRowIndex = gridView1.FocusedRowHandle;

            if (ValidateData())
            {
                String s = bPeriod.EditValue.ToString();
                if (s != "")
                {
                    String sDate = beData.EditValue.ToString();
                    DateTime FilterDateTime = Convert.ToDateTime(sDate);
                    Int32 bzo_ = Convert.ToInt32(btSwitchZO.Checked);
                    db.getReadExportRepList(ref dsMain, s.Substring(0, 1), FilterDateTime.Date, bzo_);
                    bCount.Caption = dsMain.Tables["tableReports"].Rows.Count.ToString();

                    DataTable dt = dsMain.Tables["tableReports"];
                    foreach (DataRow row in dt.Rows)
                    {
                        //foreach (DataColumn col in dt.Columns)                    
                        //rPeriodComboBox.Items.Add(row[dt.Columns[1]]);
                        if (row[dt.Columns[17]].Equals(1))
                        active_rows.Add(row[dt.Columns[0]]);
                        //MessageBox.Show(dt.Columns[colis_active.VisibleIndex].ToString());
                    }
                    
                    //dataGridViewPaging1.DataSource = dsMain.Tables["tableReports"];
                }
            }
            gridView1.FocusedRowHandle = saveRowIndex;
            gridView1.SelectRow(saveRowIndex);
        }
        
        private void bbCounting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReCalculation();
            refreshReports();
        }
        

        private void bbSending_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReSending();
            refreshReports();
        }
        

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /*foreach (DataGridViewRow row in gridControl1.M)
            {
                if (row.Cells[3].Value != null && row.Cells[3].Value.Equals(true)) //3 is the column number of checkbox
                {
                    row.Selected = true;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                }
                else
                    row.Selected = false;
            }*/
        }
        private bool ValidateData()
        {
            
            if (bPeriod.EditValue.ToString().Trim() == "")
            {
                XtraMessageBox.Show(
                   LangTranslate.UiGetText("Выберите период"),
                   LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //set fucus for bPeriod
                return false;
            } else if (beData.EditValue.ToString()== "")
            {
                XtraMessageBox.Show( 
                  LangTranslate.UiGetText("Выберите период"),
                  LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //set fucus for beData
                return false;
            }
            return true;
        }
        private void bbRefresh_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {  
            refreshReports();
        }

        private void repositoryItemDateEdit1_Leave(object sender, EventArgs e)
        {
            refreshReports();
        }

        private void btSwitchZO_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshReports();
        }

        private void repositoryItemButtonHistory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            History();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            History();
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                MessageBox.Show("Home");
            }
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               // ExportPopupMenu.ShowPopup(Control.MousePosition);
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshReports();
        }
        private void History()

        {
            ArrayList rows = new ArrayList();
            // Add the selected rows to the list. 
            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                    rows.Add(gridView1.GetDataRow(selectedRowHandle));
            }
            try
            {
                //gridView1.BeginUpdate();
                Cursor = Cursors.WaitCursor;

                try
                {
                    splashScreenManager2.ShowWaitForm();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataRow row = rows[i] as DataRow;
                        // Change the field value.
                        /*db = new DB_ExportRep();
                        DateTime FilterDateTime = Convert.ToDateTime(beData.EditValue.ToString());
                        Int32 err_code = db.getCALL(row["CAL_REP"].ToString(), FilterDateTime.Date);
                        */
                        db.getReadExportRepHistoryList(ref dsMain, getCurrentID("tableReports", "rep_name_id"));
                        if (Convert.ToInt32(dsMain.Tables["tableHistory"].Rows.Count.ToString()) == 0)
                        {
                           
                            XtraMessageBox.Show(
                              LangTranslate.UiGetText("Журнал пуст"),
                              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                          
                        } else
                        {
                            var frm = new ExportRepHistory();
                            frm.Text = "Журнал";
                            frm.rep_name_id_ = getCurrentID("tableReports", "rep_name_id");//Convert.ToInt32(row["rep_name_id"].ToString()); //108;
                            frm.ShowDialog();
                        };
                       

                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                    System.Threading.Thread.Sleep(1000);
                    splashScreenManager2.CloseWaitForm();
                }
            }
            finally
            {

            }
            //MessageBox.Show("Журнал");
            
        }
        private void ReCalculation()
        {

            ArrayList rows = new ArrayList();
            // Add the selected rows to the list. 
            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                    rows.Add(gridView1.GetDataRow(selectedRowHandle));
            }
            try
            {   
                //gridView1.BeginUpdate();
                //Cursor = Cursors.WaitCursor;

                try
                {
                    splashScreenManager2.ShowWaitForm();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataRow row = rows[i] as DataRow;
                        // Change the field value.
                        db = new DB_ExportRep();                            
                        DateTime FilterDateTime = Convert.ToDateTime(beData.EditValue.ToString());
                        Int32 err_code = db.getCALL(row["CAL_REP"].ToString(), FilterDateTime.Date, Convert.ToInt32(btSwitchZO.Checked));
                        
                        
                    }
                }
                finally
                {
                    //Cursor = Cursors.Default;
                    System.Threading.Thread.Sleep(1000);
                    splashScreenManager2.CloseWaitForm();
                }
            }
            finally
            {
                
            }
        }
        private void ReSending()
        {
            ArrayList rows = new ArrayList();
            // Add the selected rows to the list. 
            Int32[] selectedRowHandles = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                    rows.Add(gridView1.GetDataRow(selectedRowHandle));
            }
            
                //gridView1.BeginUpdate();
               // Cursor = Cursors.WaitCursor;


                var frm = new ExportRepSentStat();
                frm.Text = "Отправить в статистику";
            //frm.INTEGR_STAT = row["INTEGR_STAT"].ToString();
            //frm.reporter_id = Convert.ToInt32(row["report_id"].ToString());
            Boolean bStat_param = Convert.ToBoolean(getCurrentID("tableReports", "stat_param"));
            if (bStat_param)
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataRow row = rows[i] as DataRow;

                        // Change the field value. 
                        splashScreenManager2.ShowWaitForm();

                        db = new DB_ExportRep();
                        DateTime FilterDateTime = Convert.ToDateTime(beData.EditValue.ToString());
                        try
                        {
                            Int32 err_code = db.getIntegrStat(Convert.ToBoolean(getCurrentID("tableReports", "stat_param")), Convert.ToInt32(row["report_id"].ToString()),
                                    row["INTEGR_STAT"].ToString(),
                                    FilterDateTime.Date, //frm.report_date,
                                    frm.begin_date,
                                    frm.end_date,
                                    Convert.ToInt32(btSwitchZO.Checked) //frm.zo
                                    );
                            splashScreenManager2.CloseWaitForm();
                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            splashScreenManager2.CloseWaitForm();
                        }

                    }
                }
            }
            else /*stat_param = 0 */
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;

                    // Change the field value. 
                    splashScreenManager2.ShowWaitForm();

                    db = new DB_ExportRep();
                    DateTime FilterDateTime = Convert.ToDateTime(beData.EditValue.ToString());
                    try
                    {
                        Int32 err_code = db.getIntegrStat(bStat_param, Convert.ToInt32(row["report_id"].ToString()),
                                row["INTEGR_STAT"].ToString(),
                                FilterDateTime.Date, //frm.report_date,
                                FilterDateTime.Date,
                                FilterDateTime.Date,
                                Convert.ToInt32(btSwitchZO.Checked) //frm.zo
                                );
                        splashScreenManager2.CloseWaitForm();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        splashScreenManager2.CloseWaitForm();
                    }
                }
            }
                
        }

        private void bbHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            History();
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = -1;
            }
            return result;
        }

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
            } else if (e.Column == colname || e.Column == colcode || e.Column == colperiod || e.Column == colrep_type
                || e.Column == coldate_begin || e.Column == coldate_end || e.Column == colcalc_status 
                || e.Column == colsend_status || e.Column == colis_active) 
            {
                if (RowSelectFlag) e.Appearance.BackColor = Color.LightBlue;
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            
           
        }
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ExportPopupMenu.ShowPopup(Control.MousePosition);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gridView1.FocusedColumn.Caption);
             if (gridView1.FocusedColumn == dcButton)
             {
                 History();
             }             
        }



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridView1.FocusedColumn = dcButton;
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            if (gridView1.FocusedColumn == dcButton)
            {
                History();
            }
        }
    }

}