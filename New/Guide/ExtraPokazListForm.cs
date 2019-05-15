using ARM_User.New.DB;
using ARM_User.New.Guide;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.DisplayLayer.Guides
{
    public partial class ExtraPokazListForm : BSB.Common.MDIChildForm
    {
        #region [Preperties]
            private DB_ExtraPokazListForm db = null;
        #endregion

        public ExtraPokazListForm()
        {   
            InitializeComponent();
            db = new DB_ExtraPokazListForm(dmControler.frmMain.oracleConnection);
            beData.EditValue = (DateTime)System.DateTime.Today;
            gvCustomers.OptionsView.ShowAutoFilterRow = false;
            barButtonItemFilter.Glyph = Properties.Resources.filter;
            gvCustomers.OptionsFind.ClearFindOnClose = true;
            gvCustomers.OptionsFind.ShowFindButton = false;
            gvCustomers.OptionsFind.FindMode = FindMode.Always;
            refreshCustomer();
        }        
        private void ExtraPokazListForm_Load(object sender, EventArgs e)
        {
            //reSize();
        }
        private void refreshCustomer()
        {
            //repositoryItemDateEdit1.val
            splashScreenManager.ShowWaitForm();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getReadList(ref dsMain, FilterDateTime.Date);

            Int32 xCount = dsMain.Tables["TableList1"].Rows.Count;            
            bCount.EditValue = xCount.ToString();
            if (xCount == 0)
            {                
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
            }
            splashScreenManager.CloseWaitForm();
        }
        private void refreshRating()
        {
            splashScreenManager.ShowWaitForm();
            Int32 iID = getCurrentID("TableList1", "CUSTOMER_SID");            
            if (iID > 0)
            {
                String s = beData.EditValue.ToString();
                DateTime FilterDateTime = Convert.ToDateTime(s);
                db.getReadList2(ref dsMain, FilterDateTime.Date, iID);
                Int32 xCount = dsMain.Tables["TableList2"].Rows.Count;
                tsbView.Enabled = xCount == 0 ? false : true;
                tsbEdit.Enabled = xCount == 0 ? false : true;
                tsbDelete.Enabled = xCount == 0 ? false : true;
            }
            else
            {
                if (dsMain.Tables.Contains("TableList2")) dsMain.Tables["TableList2"].Clear();
            }
            //System.Threading.Thread.Sleep(5000);
            splashScreenManager.CloseWaitForm();
        }
        private void reSize()
        {            
            splitContainer1.Panel1.Height = Convert.ToInt32(splitContainer1.Height * 1.5);
            splitContainer1.Panel2.Height = splitContainer1.Height - splitContainer1.Panel1.Height;
        }
        private void barButtonRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshCustomer();
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
            DateTime result= new DateTime();
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
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            refreshRating();            
        }

        private void barButtonItemFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean filtered = gvCustomers.OptionsView.ShowAutoFilterRow;
            if (filtered)
            {
                gvCustomers.ClearColumnsFilter();
                barButtonItemFilter.Glyph = Properties.Resources.filter;
            }
            else
                barButtonItemFilter.Glyph = Properties.Resources.filter_disable;
            gvCustomers.OptionsView.ShowAutoFilterRow = !filtered;

        }

        private void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean finded = gvCustomers.OptionsFind.AlwaysVisible;
            if (finded) gvCustomers.ApplyFindFilter("");
            gvCustomers.OptionsFind.AlwaysVisible = !finded;
            
        }

        private void ExtraPokazListForm_Resize(object sender, EventArgs e)
        {
            //reSize();
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {   
            var frm = new CreditsExtraPokazADDForm();
            frm.Text = "Вставить показатель";
            frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
            
            // from clients
            frm.customer_sid_ = getCurrentID("TableList1", "CUSTOMER_SID");
            frm.customer_name = getCurrentName("TableList1", "FULL_NAME");
            frm.customer_code = getCurrentID("TableList1", "SRC_CUSTOMER_NO");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            frm.report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            frm.ShowDialog();
            refreshRating();
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            var frm = new CreditsExtraPokazADDForm();
            frm.Text = "Просмотр показателя";
            frm.State = ServiceLayer.Service.Editor.EditorState.View;
            
            frm.customer_sid_ = getCurrentID("TableList1", "CUSTOMER_SID");
            frm.customer_name = getCurrentName("TableList1", "FULL_NAME");
            frm.customer_code = getCurrentID("TableList1", "SRC_CUSTOMER_NO");
            // from ratings
            frm.dim_name_ = getCurrentName("TableList2", "DIM_NAME");
            frm.part_name = getCurrentName("TableList2", "DIM_PART");
            frm.abs_dimension_id_ = getCurrentID("TableList2", "ABS_DIMENSION_ID");
            frm.abs_code_ = getCurrentName("TableList2", "CODE_POKAZ");
            frm.pokaz_id_ = getCurrentID("TableList2", "POKAZ_ID");
            frm.abs_name_ = getCurrentName("TableList2","NAME_POKAZ");
            
            frm.ShowDialog();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var frm = new CreditsExtraPokazADDForm();
            frm.Text = "Редактирование показателя";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            frm.customer_sid_ = getCurrentID("TableList1", "CUSTOMER_SID");
            frm.customer_name = getCurrentName("TableList1", "FULL_NAME");
            frm.customer_code = getCurrentID("TableList1", "SRC_CUSTOMER_NO");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            frm.report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            // from ratings
            frm.dim_name_ = getCurrentName("TableList2", "DIM_NAME");
            frm.part_name = getCurrentName("TableList2", "DIM_PART");
            frm.abs_dimension_id_ = getCurrentID("TableList2", "ABS_DIMENSION_ID");
            frm.abs_code_ = getCurrentName("TableList2", "CODE_POKAZ");
            frm.pokaz_id_ = getCurrentID("TableList2", "POKAZ_ID");
            frm.abs_name_ = getCurrentName("TableList2", "NAME_POKAZ");
            frm.ShowDialog();
            refreshRating();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refreshRating();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Int32 customer_sid_ = getCurrentID("TableList1", "CUSTOMER_SID");
            Int32 abs_dimension_id_ = getCurrentID("TableList2", "ABS_DIMENSION_ID");
            Int32 pokaz_id_ = getCurrentID("TableList2", "POKAZ_ID");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            // Вы хотите удалить?
            if (
              XtraMessageBox.Show(
                LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                splashScreenManager.ShowWaitForm();
                db.deleteLoansDeleteMap(customer_sid_, report_date_, abs_dimension_id_, pokaz_id_);
                splashScreenManager.CloseWaitForm();

                refreshRating();
                
            }
                
        }

        private void ExtraPokazListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gvCustomers.ApplyFindFilter("");
            //gvCustomers.OptionsView.ShowAutoFilterRow = false;
            gvCustomers.OptionsFind.AlwaysVisible = false;
        }

        private void barEditItemDate_EditValueChanged(object sender, EventArgs e)
        {
            refreshCustomer();            
        }

        private void ExtraPokazListForm_Shown(object sender, EventArgs e)
        {

        }
    }
}