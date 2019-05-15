using ARM_User.New.DB;
using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class LoansListForm : BSB.Common.MDIChildForm
    {
        private DB_LoansListForm db = null;

        public LoansListForm()
        {
            InitializeComponent();
            db = new DB_LoansListForm(dmControler.frmMain.oracleConnection);
            beData.EditValue = (DateTime)System.DateTime.Today;
            splitContainer1.SplitterDistance = splitContainer1.Height - 150;
            try
            {
                splashScreenManager.ShowWaitForm();
                refreshListCredits();
            }
            finally
            {
                splashScreenManager.CloseWaitForm();
            }

            bgvExtraPokaz.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            bandedGridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridControl1.Visible = false;
            

        }

        private void bbFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Boolean filtered = bandedGridView1.OptionsView.ShowAutoFilterRow;            
            if (filtered)
            {
                bandedGridView1.ClearColumnsFilter();
                bbFilter.Glyph = Properties.Resources.filter;
            }
            else
                bbFilter.Glyph = Properties.Resources.filter_disable;
            bandedGridView1.OptionsView.ShowAutoFilterRow = !filtered;
        }

        private void bbSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean finded = bandedGridView1.OptionsFind.AlwaysVisible;
            if (finded) bandedGridView1.ApplyFindFilter("");
            bandedGridView1.OptionsFind.AlwaysVisible = !finded;
        }
        
        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshListCredits();
        }
        #region[REFRESH VIRTUAL]
        public virtual void refreshListCredits()
        {
            //Cursor = Cursors.WaitCursor;
            //splashScreenManager.ShowWaitForm();
            gcList1.BeginUpdate();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getReadListCredits(ref dsMain, FilterDateTime.Date);
            Int32 xCount = dsMain.Tables["tsCredits"].Rows.Count;
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
            //Cursor = Cursors.Default;
            //splashScreenManager.CloseWaitForm();

            refreshListExtraPokaz();
            gcList1.EndUpdate();
            
        }
        public virtual void refreshListExtraPokaz()
        {
            //splashScreenManager.ShowWaitForm();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            
            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");
            
            if (loan_sid > 0)
            {
                db.getReadListExtraPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsExtraPokaz"].Rows.Count;
                //MessageBox.Show(xCount.ToString());
                Boolean xPermission = xCount == 0;                
                tsbExtraPokazView.Enabled = !xPermission;                
                tsbExtraPokazEdit.Enabled = !xPermission;
                tsbExtraPokazDelete.Enabled = !xPermission;
            }
            else
                if (dsMain.Tables.Contains("tsExtraPokaz")) dsMain.Tables["tsExtraPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        public virtual void refreshListPokaz()
        {
            //splashScreenManager.ShowWaitForm();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");
            
            if (loan_sid > 0)
            {
                db.getReadListPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsPokaz"].Rows.Count;
                Boolean xPermission = xCount == 0;
                tsbPokazView.Enabled = !xPermission;
                tsbPokazEdit.Enabled = !xPermission;
                tsbPokazDelete.Enabled = !xPermission;
            }
            else
                if (dsMain.Tables.Contains("tsPokaz")) dsMain.Tables["tsPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refreshListExtraPokaz();
        }

        private void beData_EditValueChanged(object sender, EventArgs e)
        {
            refreshListCredits();
        }

        private void LoansListForm_Load(object sender, EventArgs e)
        {

            
        }
        private void gvList1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            refreshListExtraPokaz();
            refreshListPokaz();
            splashScreenManager.CloseWaitForm();
        }
        #region [GET urrent Data]
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            refreshListPokaz();
        }

        private void tsbExtraPokazAdd_Click(object sender, EventArgs e)
        {
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Добавить дополнительный показатель";
            frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
            // from credits
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");
            frm.abs_constant_dimension_id = getCurrentID("tsExtraPokaz", "abs_constant_dimension_id");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            frm.report_date = Convert.ToDateTime(FilterDateTime.Date);

            frm.ShowDialog();
            refreshListExtraPokaz();
        }

        private void tsbExtraPokazEdit_Click(object sender, EventArgs e)
        {
            
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Изменить дополнительный показатель";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            // from credits
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");

            frm.report_date = getCurrentReportDate("tsExtraPokaz", "report_date");
            frm.name = getCurrentName("tsExtraPokaz", "name");
            frm.map_value = getCurrentName("tsExtraPokaz", "map_value");
            frm.abs_constant_dimension_id = getCurrentID("tsExtraPokaz", "abs_constant_dimension_id");

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            frm.report_date = Convert.ToDateTime(FilterDateTime.Date);

            frm.ShowDialog();
            refreshListExtraPokaz();
        }

        private void tsbExtraPokazView_Click(object sender, EventArgs e)
        {
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Просмотр дополнительного показателя";
            frm.State = ServiceLayer.Service.Editor.EditorState.View;
            // from credits
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");

            frm.report_date = getCurrentReportDate("tsExtraPokaz", "report_date");
            frm.name = getCurrentName("tsExtraPokaz", "name");
            frm.map_value = getCurrentName("tsExtraPokaz", "map_value");

            frm.ShowDialog();
            refreshListExtraPokaz();
        }

        private void tsbExtraPokazDelete_Click(object sender, EventArgs e)
        {
            Int32 loan_sid_ = getCurrentID("tsCredits", "loan_sid");
            Int32 abs_constant_loans_map_id_ = getCurrentID("tsExtraPokaz", "abs_constant_loans_map_id");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);

            // Вы хотите удалить?
            if (
              XtraMessageBox.Show(
                LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                try
                {
                    splashScreenManager.ShowWaitForm();
                    db.pro_delete_loans_add_map(loan_sid_, report_date_, abs_constant_loans_map_id_);
                    splashScreenManager.CloseWaitForm();
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_add_map)");
                    splashScreenManager.CloseWaitForm();
                }                

                refreshListExtraPokaz();
                
            }
        }

        private void tsbPokazAdd_Click(object sender, EventArgs e)
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = "Добавить дополнительный показатель";

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            frm.report_date = Convert.ToDateTime(FilterDateTime.Date);
            frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");

            frm.ShowDialog();
            refreshListPokaz();
        }

        private void tsbPokazView_Click(object sender, EventArgs e)
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = "Просмотр дополнительного показателя";

            frm.State = ServiceLayer.Service.Editor.EditorState.View;
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            frm.report_date = Convert.ToDateTime(FilterDateTime.Date);
            frm.dim_name = getCurrentName("tsPokaz", "dim_name");
            frm.dim_part = getCurrentName("tsPokaz", "dim_part");
            frm.abs_dimension_id = getCurrentID("tsPokaz", "abs_dimension_id");
            frm.pokaz_id = getCurrentID("tsPokaz", "pokaz_id");
            frm.code = getCurrentName("tsPokaz", "code_pokaz");
            frm.name = getCurrentName("tsPokaz", "name_pokaz");

            frm.ShowDialog();
            refreshListPokaz();
        }

        private void tsbPokazEdit_Click(object sender, EventArgs e)
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = "Изменить дополнительный показатель";

            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
            frm.contract_no = getCurrentName("tsCredits", "contract_no");
            frm.ref_no = getCurrentName("tsCredits", "ref_no");

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            frm.report_date = Convert.ToDateTime(FilterDateTime.Date);
            frm.dim_name = getCurrentName("tsPokaz", "dim_name");
            frm.dim_part = getCurrentName("tsPokaz", "dim_part");
            frm.abs_dimension_id = getCurrentID("tsPokaz", "abs_dimension_id");
            frm.pokaz_id = getCurrentID("tsPokaz", "pokaz_id");
            frm.code = getCurrentName("tsPokaz", "code_pokaz");
            frm.name = getCurrentName("tsPokaz", "name_pokaz");

            frm.ShowDialog();
            refreshListPokaz();
        }

        private void tsbPokazDelete_Click(object sender, EventArgs e)
        {
            Int32 loan_sid_ = getCurrentID("tsCredits", "loan_sid");

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            Int32 abs_dimension_id = getCurrentID("tsPokaz", "abs_dimension_id");
            Int32 pokaz_id = getCurrentID("tsPokaz", "pokaz_id");

            // Вы хотите удалить?
            if (
              XtraMessageBox.Show(
                LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                try
                {
                    splashScreenManager.ShowWaitForm();
                    db.pro_delete_loans_map(loan_sid_, report_date_, abs_dimension_id, pokaz_id);
                    splashScreenManager.CloseWaitForm();
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_map)");
                    splashScreenManager.CloseWaitForm();
                }
                
                refreshListPokaz();
                
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean x = bandedGridView1.OptionsView.EnableAppearanceOddRow;            
            bandedGridView1.OptionsView.EnableAppearanceOddRow = !x;
        }

        private void bbExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcList1.Visible = false;
            gridControl1.Visible = true;
            gridControl1.Dock = DockStyle.Fill;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getLoansExportList(ref dsMain2, FilterDateTime.Date);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String sfile = saveFileDialog1.FileName;
                try
                {
                    gridControl1.ExportToXls(sfile);
                }
                catch(Exception oe)
                {
                    MessageBox.Show("Ошибка при экспорте: "+oe.Message);
                }
            }
            gcList1.Visible = true;
            gridControl1.Visible = false;
        }
    }
}
