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
        public Int32 cell_type;
        #endregion
        public ReportsCustomizeForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new DB_Reports();
            /*barEditItemType.EditValue = repositoryItemComboBox2.Items[1].ToString();
            /*refreshFormList(1);*/
            bandedGridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            bandedGridView1.OptionsView.RowAutoHeight = false;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cell_type = repositoryItemComboBox2.Items.IndexOf(barEditItemType.EditValue) + 1;
            /*if (rep_type_ == 11)
            {
                rep_custom_type += 10;
            }*/

            refreshFormList(cell_type);
        }
        private int saveRowIndex;
        private GridColumn saveCellIndex;
        public void refreshFormList(Int32 rep_custom_type_)
        {
            saveRowIndex = bandedGridView1.FocusedRowHandle;
            saveCellIndex = bandedGridView1.FocusedColumn;

            Cursor = Cursors.WaitCursor;
            
            String s = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            
            db.getReadReporHeadertList(ref dsMain, report_date_, report_id_);

            try
            {
                //splashScreenManager.ShowWaitForm();
                //bandedGridView1.ShowLoadingPanel();
                db.getReportsListF21(ref dsMain, sql_arm_, rep_custom_type_, report_date_);
                bCount.Caption = dsMain.Tables["tbForm21"].Rows.Count.ToString();
                //bandedGridView1.HideLoadingPanel();
            }
            catch (Exception oe)
            {
                //bandedGridView1.HideLoadingPanel();
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(Ошибка при чтений формы ) ");
                
                return;
            }

            
            gridControl1.RefreshDataSource();
            bandedGridView1.PopulateColumns();
            
            
            string[] header = new string[] { "№", "num", "Найменование", "код" };

            if (bandedGridView1.Columns.Count > 8) this.WindowState = FormWindowState.Maximized;
               else this.WindowState = FormWindowState.Normal;

            //Band
            bandedGridView1.Bands.Clear();
            
            for (int i = 0; i < bandedGridView1.Columns.Count; i++)
                {
                if (i <= 3)
                {
                    var colband = bandedGridView1.Bands.AddBand(header[i]);

                    colband.View.BeginUpdate();
                    bandedGridView1.Columns[i].Caption = "  \n";
                    bandedGridView1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    bandedGridView1.Columns[i].OptionsColumn.AllowFocus = false;
                    bandedGridView1.Columns[i].BestFit();
                    bandedGridView1.Columns[i].ColumnEdit = repositoryItemMemoEdit1;
                    bandedGridView1.Columns[i].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    if (i != 2) {
                        bandedGridView1.Columns[i].BestFit();                        
                        bandedGridView1.OptionsView.ColumnAutoWidth = false;
                    } else {
                        bandedGridView1.Columns[i].Width = 250;
                        bandedGridView1.OptionsView.ColumnAutoWidth = false;
                        
                    }
                                       
                    bandedGridView1.Columns[i].OwnerBand = colband;
                    colband.RowCount = 3;
                    bandedGridView1.Columns[i].Fixed = FixedStyle.Left;
                    bandedGridView1.Bands[i].Fixed = FixedStyle.Left;
                    colband.View.EndUpdate();
                }
                    else
                    {
                    
                    bandedGridView1.Columns[i].Width = 230;
                    bandedGridView1.Columns[i].Caption = " ";

                    bandedGridView1.Columns[i].ColumnEdit = repositoryItemMemoEdit1; //rbEdit;

                    ///gridView1.Columns[i].BestFit();
                    //bandedGridView1.Columns[i].AppearanceCell.Font = new Font("Times New Roman", 7);
                    //gridView1.Columns[i].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    bandedGridView1.Columns[i].OptionsColumn.AllowFocus = true;
                    bandedGridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    
                    if (i % 2 == 0) bandedGridView1.Columns[i].AppearanceCell.BackColor = Color.LightBlue;
                    else {
                        bandedGridView1.Columns[i].AppearanceCell.BackColor = Color.White;                        
                    }
                    bandedGridView1.Columns[i].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                }
                }
            bandedGridView1.RowHeight = 70;

            DataTable dt = dsMain.Tables["tableReportsHeader"];
                int j = 0;
            int delta = 4;
            int CountHeader = dsMain.Tables["tableReportsHeader"].Rows.Count;
            if (CountHeader >= 0)
            {
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var colband = bandedGridView1.Bands.AddBand(row[dt.Columns[1]].ToString());

                        colband.View.BeginUpdate();
                        bandedGridView1.Columns[delta + j].Caption = row[dt.Columns[0]].ToString();
                        bandedGridView1.Columns[delta + j].FieldName = row[dt.Columns[0]].ToString();
                        bandedGridView1.Columns[delta + j].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                        bandedGridView1.Columns[delta + j].AppearanceHeader.BackColor = Color.Indigo;
                        

                        bandedGridView1.Columns[delta + j].OwnerBand = colband;
                        //colband.RowCount = 3;
                        colband.View.EndUpdate();
                        j++;
                    }
                }
                catch(Exception oe)
                {
                    //splashScreenManager.CloseWaitForm();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(Ошибка при чтений формы ) refreshFormList ");                    
                    return;
                }
                
            }
            Cursor = Cursors.Default;
            //splashScreenManager.CloseWaitForm();
            bandedGridView1.FocusedRowHandle = saveRowIndex;
            bandedGridView1.FocusedColumn = saveCellIndex;
            bandedGridView1.RefreshRowCell(saveRowIndex, saveCellIndex);
            //gridView1.SelectRow(saveRowIndex);
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
            
        }

        private void rbEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Customize(sender);
        }
        private void Customize(Object xObject)
        {
            Cursor = Cursors.WaitCursor;
            String s_date = barEditItemDate.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s_date);
           
            saveRowIndex = bandedGridView1.FocusedRowHandle;
            saveCellIndex = bandedGridView1.FocusedColumn;




            String s = xObject.ToString();
            String g = s;
            if (s != String.Empty)
            {

                Int32 str_id = getCurrentID("tbForm21", "str_id");
                Int32 col_id = Convert.ToInt32(bandedGridView1.FocusedColumn.FieldName);
                DateTime rep_date = Convert.ToDateTime(FilterDateTime);

                if (rep_type_ == 1) cell_type += 0;
                if (rep_type_ == 11) cell_type += 10;
                
                switch (cell_type) 
                {
                    
                    case 11:
                        {

                            var frm = new ReportsCelleditFormType11();
                            //frm.Text = "Редактирование ячейки";
                            
                            frm.Text = g.Substring(0, g.Length < 255 ? s.Length : 255);
                            frm.p_str_id = str_id;
                            frm.p_col_id = col_id;
                            frm.p_date = rep_date;
                            frm.p_cell_type = cell_type;
                            frm.ShowDialog();

                            cell_type -= 10;
                            refreshFormList(cell_type);
                            break;
                        }
                    default:
                        {
                            var frm = new ReportsCelleditForm();
                             frm.Text = g.Substring(0, g.Length< 255? g.Length : 255);
                             frm.HTMLText = s;
                             frm.p_str_id = str_id;
                             frm.p_col_id = col_id;
                             frm.p_date = rep_date;
                             frm.p_cell_type = cell_type; 
                             if (frm.ShowDialog() == DialogResult.OK) {                                
                                 bandedGridView1.SetRowCellValue(saveRowIndex, saveCellIndex, frm.StrResult);                               
                             } else
                             {
                                 //((Control)sender).Text = s;
                                 bandedGridView1.SetRowCellValue(saveRowIndex, saveCellIndex, s);
                             }
                             if (cell_type > 10) cell_type -= 10;
                           
                            break;  
                        }


                }
                
            }
            Cursor = Cursors.Default;
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
            //refreshFormList();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            Visible = false;
            barEditItemType.EditValue = repositoryItemComboBox2.Items[0].ToString();
            refreshFormList(1);
            Visible = true;
        }

        private void barEditItemDate_EditValueChanged(object sender, EventArgs e)
        {
            cell_type = repositoryItemComboBox2.Items.IndexOf(barEditItemType.EditValue) + 1;            
            refreshFormList(cell_type);
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            for (int i = 4; i < bandedGridView1.Columns.Count; i++)
            {
                if (e.Column == bandedGridView1.Columns[i])
                {
                    e.Column.ColumnEdit = rbEdit;                   
                }
            }
        }

        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void bandedGridView1_ShownEditor(object sender, EventArgs e)
        {
            BandedGridView view = sender as BandedGridView;
            
            view.ActiveEditor.MouseWheel += ActiveEditor_MouseWheel;
           
        }
        void ActiveEditor_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bandedGridView1.HideEditor();
            bandedGridView1.CloseEditor();
        }

        private void repositoryItemMemoEdit1_Click(object sender, EventArgs e)
        {
            
        }
        private void repositoryItemMemoEdit1_DoubleClick(object sender, EventArgs e)
        {
            // Customize(sender);
            MessageBox.Show("Double click!");
        }

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)           
                if (checkColumn(e.Column) == 0)
                {
                    Customize(e.CellValue);
                }
        }
        private int checkColumn(GridColumn xColumn)
        {
            int result = 0;
            for(int i=0; i<4; i++)
            {
                if (bandedGridView1.Columns[i] == xColumn) {
                    result = 1;
                    break;
                }
            }
            return result;
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
