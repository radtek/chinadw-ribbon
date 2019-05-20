using ARM_User.New.DB;
using BSB.Common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class CalendarOperationsForm : MDIChildForm
    {

        private DB_CalendarOperations db = null;


        public CalendarOperationsForm()
        {
            InitializeComponent();          
            db = new DB_CalendarOperations(dmControler.frmMain.oracleConnection);
            gvCalendar.OptionsView.ShowAutoFilterRow = false;
            gvCalendar.OptionsFind.ClearFindOnClose = true;
            gvCalendar.OptionsFind.ShowFindButton = false;
            gvCalendar.OptionsFind.FindMode = FindMode.Always;
            refreshCalendar();
        }

        // Получить текущий ID задав table и field
        private Int32 getCurrentID(String sTable, String sField)
        {
            Int32 result = -1;
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[mainDS, sTable];
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

        private DateTime getCurrentReportDate(String sTable, String sField)
        {
            DateTime result = new DateTime();
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[mainDS, sTable];
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

        private void refreshCalendar()
        {
            //repositoryItemDateEdit1.val
            Cursor = Cursors.WaitCursor;          
            db.getReadList(ref mainDS);
            Int32 xCount = mainDS.Tables["CalendarOp"].Rows.Count;
            CountBar.EditValue = xCount.ToString();

            repositoryItemComboBox1.Items.Add(DateTime.Now.Year);
            Cursor = Cursors.Default;
        }

        private void CalendarOperations_Load(object sender, EventArgs e)
        {
            
        }

        private void gcCalendar_Click(object sender, EventArgs e)
        {

        }

        private void gvCalendar_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gvCalendar_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {           
            if(e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Вид дня"]);
                if(status == "Выходной" || status == "Праздничный")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshCalendar();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowSelected = gvCalendar.FocusedRowHandle;

            var frm = new CalendarOperationEditForm();
            frm.Text = "Редактирование реквизитов операционного дня";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            frm.date_value = getCurrentReportDate("CalendarOp", "DATE_VALUE");
            frm.status = getCurrentID("CalendarOp", "CALENDAR_STATUS_ID");
            frm.ShowDialog();
            refreshCalendar();
            gvCalendar.FocusedRowHandle = rowSelected;       
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (
              XtraMessageBox.Show(
                LangTranslate.UiGetText("Вы действительно хотите создать\\обновить календарь за текущий год? \n"),
                LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                db.upgradeCalendar();
                refreshCalendar();
                Cursor = Cursors.Default;
            }
        }

        private void gvCalendar_DoubleClick(object sender, EventArgs e)
        {
            int rowSelected = gvCalendar.FocusedRowHandle;

            var frm = new CalendarOperationEditForm();
            frm.Text = "Редактирование реквизитов операционного дня";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            frm.date_value = getCurrentReportDate("CalendarOp", "DATE_VALUE");
            frm.status = getCurrentID("CalendarOp", "CALENDAR_STATUS_ID");
            frm.ShowDialog();
            refreshCalendar();
            gvCalendar.FocusedRowHandle = rowSelected;
        }
    }
}
