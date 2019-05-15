using ARM_User.New.DB;
using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Ionic.Zip;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ARM_User.New.Guide
{
    public partial class CreditsListForm : BSB.Common.MDIChildForm
    {
        private DB_Pledges db = null;

        public CreditsListForm()
        {
            InitializeComponent();
            db = new DB_Pledges();

            beData.EditValue = (DateTime)System.DateTime.Today;
            splitContainer1.SplitterDistance = splitContainer1.Height / 2;
            try
            {
                splashScreenManager.ShowWaitForm();
                refreshListCredits();
            }
            finally
            {
                splashScreenManager.CloseWaitForm();
            }

            //bgvExtraPokaz.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            bgvList2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            //bandedGridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            //gcList1.Visible = false;
            bgvList2.OptionsView.ShowGroupPanel = false;
            
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
        }
        public virtual void refreshListCredits()
        {
            //Cursor = Cursors.WaitCursor;
            //splashScreenManager.ShowWaitForm();
            bgvList2.BeginUpdate();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getReadListCredits(ref dsMain, FilterDateTime.Date);
            Int32 xCount = dsMain.Tables["tsCredits"].Rows.Count;
            bCount.Caption = xCount.ToString();
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


            bgvList2.EndUpdate();

        }
        public void refreshListPaymentPlan()
        {
            db.getReadPaymentPlan(ref dsMain, (DateTime)beData.EditValue, getCurrentID("tsCredits", "LOAN_SID"));
        }
        private void PledgesListForm_Load(object sender, EventArgs e)
        {
            bgvList2.OptionsView.ShowGroupPanel = false;
        }

        private void bbFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Boolean filtered = bgvList2.OptionsView.ShowAutoFilterRow;
            if (filtered)
            {
                bgvList2.ClearColumnsFilter();
                bbFilter.Glyph = Properties.Resources.filter;
            }
            else
                bbFilter.Glyph = Properties.Resources.filter_disable;
            bgvList2.OptionsView.ShowAutoFilterRow = !filtered;
        }

        private void bbSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean finded = bgvList2.OptionsFind.AlwaysVisible;
            if (finded) bgvList2.ApplyFindFilter("");
            bgvList2.OptionsFind.AlwaysVisible = !finded;
        }

        private void bbExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Export");
        }

        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshListCredits();
        }
        private void TabRefresh()
        {
            refreshListPaymentPlan();
            switch (xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage))
            {
                case 0: /*tab Pledges*/
                    {
                        refreshListPledges();
                        break;
                    }
                case 1: /*tab Pokaz*/
                    {
                        refreshListPokaz();
                        break;
                    }
                case 2: /*ExtraPokaz*/
                    {
                        refreshListExtraPokaz();
                        break;
                    }
            }
        }
        #region [refresh pokaz]
        public virtual void refreshListPokaz()
        {
            //splashScreenManager.ShowWaitForm();;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsPokaz"].Rows.Count;
                tstCount.Text = xCount.ToString();
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;
            }
            else
                if (dsMain.Tables.Contains("tsPokaz")) dsMain.Tables["tsPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        #endregion
        public virtual void refreshListPledges()
        {
            //splashScreenManager.ShowWaitForm();;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListPledges(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsPledges"].Rows.Count;
                tstCount.Text = xCount.ToString();
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;
            }
            else
                if (dsMain.Tables.Contains("tsPledges")) dsMain.Tables["tsPledges"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        public virtual void refreshListExtraPokaz()
        {
            //splashScreenManager.ShowWaitForm();;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListExtraPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsExtraPokaz"].Rows.Count;
                tstCount.Text = xCount.ToString();
                //MessageBox.Show(xCount.ToString());
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;
            }
            else
                if (dsMain.Tables.Contains("tsExtraPokaz")) dsMain.Tables["tsExtraPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
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
        private String getCurrentShortDate(String sTable, String sField)
        {
            String result = "";
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToDateTime(row[sField]).ToShortDateString();
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
        private void viewTabs(int index)
        {
            splashScreenManager.ShowWaitForm();
            
            switch (index) //
            {
                case 0: /*tab Pledges*/
                    {
                        var frm = new CreditsPledgesAddForm();
                        frm.Text = "Просмотр ";
                        frm.report_date = (DateTime)beData.EditValue;
                        frm.h_loan_sid = getCurrentID("tsCredits", "LOAN_SID");
                        frm.src_ddfrey = getCurrentName("tsCredits", "src_ddfrey");
                        frm.src_ddfref = getCurrentName("tsCredits", "src_ddfref");
                        frm.src_ddfcnt = getCurrentName("tsCredits", "src_ddfcnt");

                        frm.State = ServiceLayer.Service.Editor.EditorState.View;

                        frm.sat_loans_pledge_id = getCurrentID("tsPledges", "sat_loans_pledge_id");
                        frm.ple_contract_type = getCurrentName("tsPledges", "ple_contract_type");
                        frm.ple_contract_no = getCurrentName("tsPledges", "ple_contract_no");
                        frm.ple_contract_date = getCurrentShortDate("tsPledges", "ple_contract_date");
                        frm.ple_square_zu = getCurrentName("tsPledges", "ple_square_zu");
                        frm.ple_maturity_date = getCurrentShortDate("tsPledges", "ple_maturity_date");
                        frm.ple_region_kato = getCurrentName("tsPledges", "ple_region_kato");
                        frm.ple_region = getCurrentName("tsPledges", "ple_region");
                        frm.ple_placement = getCurrentName("tsPledges", "ple_placement");
                        frm.ple_evaluate_company = getCurrentName("tsPledges", "ple_evaluate_company");
                        frm.ple_report_no = getCurrentName("tsPledges", "ple_report_no");
                        frm.ple_revaluating_date = getCurrentShortDate("tsPledges", "ple_revaluating_date");
                        frm.ple_market_value = getCurrentName("tsPledges", "ple_market_value");
                        frm.ple_currency = getCurrentName("tsPledges", "ple_currency");
                        frm.ple_value_kzt = getCurrentName("tsPledges", "ple_value_kzt");
                        frm.ple_value = getCurrentName("tsPledges", "ple_value");
                        frm.ple_high_liquidity = getCurrentName("tsPledges", "ple_high_liquidity");
                        frm.ple_type_old_crreg = getCurrentName("tsPledges", "ple_type_old_crreg");
                        frm.ple_type_crreg = getCurrentName("tsPledges", "ple_type_crreg");
                        frm.ple_penalty_type = getCurrentName("tsPledges", "ple_penalty_type");
                        frm.ple_redemption_date = getCurrentShortDate("tsPledges", "ple_redemption_date");
                        frm.ple_returned_sum = getCurrentName("tsPledges", "ple_returned_sum");
                        frm.ple_coefficient = getCurrentName("tsPledges", "ple_coefficient");
                        frm.ShowDialog();
                        
                        break;
                    }
                case 1: /*tab Pokaz*/
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
                        //refreshListPokaz();
                        break;
                    }
                case 2: /*ExtraPokaz*/
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
                        //refreshListExtraPokaz();
                        break;
                    }
            }
            refereshTabs(index);
            splashScreenManager.CloseWaitForm();
        }
        private void refereshTabs(int index)
        {
            
            refreshListPaymentPlan();
            switch (index) //
            {
                case 0: /*tab Pledges*/
                    {
                        refreshListPledges();
                        break;
                    }
                case 1: /*tab Pokaz*/
                    {
                        refreshListPokaz();
                        break;
                    }
                case 2: /*ExtraPokaz*/
                    {
                        refreshListExtraPokaz();                        
                        break;
                    }
            }
            //splashScreenManager.CloseWaitForm();
        }
        private void insertTabs(int index)
        {
            splashScreenManager.ShowWaitForm();
            refreshListPaymentPlan();
            switch (index) //
            {
                case 0: /*tab Pledges*/
                    {
                        MessageBox.Show("Pledges insert");
                        break;
                    }
                case 1: /*tab Pokaz*/
                    {
                        var frm = new CreditsLoansAddPokazForm();
                        frm.Text = "Добавить показатель";

                        String s = beData.EditValue.ToString();
                        DateTime FilterDateTime = Convert.ToDateTime(s);

                        frm.report_date = Convert.ToDateTime(FilterDateTime.Date);
                        frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
                        frm.loan_sid = getCurrentID("tsCredits", "loan_sid");
                        frm.contract_no = getCurrentName("tsCredits", "contract_no");
                        frm.ref_no = getCurrentName("tsCredits", "ref_no");

                        frm.ShowDialog();
                        //refreshListPokaz();
                        break;
                    }
                case 2: /*ExtraPokaz*/
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
                        //refreshListExtraPokaz();
                        break;
                    }
            }
            refereshTabs(index);
            splashScreenManager.CloseWaitForm();
        }
        private void editTabs(int index)
        {
            splashScreenManager.ShowWaitForm();
            refreshListPaymentPlan();
            switch (index) //
            {
                case 0: /*tab Pledges*/
                    {
                        MessageBox.Show("Pledges edit");
                        break;
                    }
                case 1: /*tab Pokaz*/
                    {
                        var frm = new CreditsLoansAddPokazForm();
                        frm.Text = "Изменить показатель";

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
                        //refreshListPokaz();
                        break;
                    }
                case 2: /*ExtraPokaz*/
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
                        //refreshListExtraPokaz();
                        break;
                    }
            }
            refereshTabs(index);
            splashScreenManager.CloseWaitForm();
        }
        private void deleteTabs(int index)
        {
            splashScreenManager.ShowWaitForm();
            refreshListPaymentPlan();

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            DateTime report_date_ = Convert.ToDateTime(FilterDateTime.Date);
            Int32 loan_sid_ = getCurrentID("tsCredits", "loan_sid");

            switch (index) 
            {
                case 0: /*tab Pledges*/
                    {
                        MessageBox.Show("Pledges delete");
                        break;
                    }
                case 1: /*tab Pokaz*/
                    {
                        Int32 abs_dimension_id = getCurrentID("tsPokaz", "abs_dimension_id");
                        Int32 pokaz_id = getCurrentID("tsPokaz", "pokaz_id");

                        // Вы хотите удалить?
                        if (
                          XtraMessageBox.Show(
                            LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                            LangTranslate.UiGetText("Удаление показателя"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            try
                            {
                                db.pro_delete_loans_map(loan_sid_, report_date_, abs_dimension_id, pokaz_id);                               
                            }
                            catch (Exception oe)
                            {
                                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_map)");                                
                            }

                            //refreshListPokaz();

                        };
                        break;
                    }
                case 2: /*ExtraPokaz*/
                    {
                        Int32 abs_constant_loans_map_id_ = getCurrentID("tsExtraPokaz", "abs_constant_loans_map_id");
                        // Вы хотите удалить?
                        if (
                          XtraMessageBox.Show(
                            LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                            LangTranslate.UiGetText("Удаление дополнительного показателя"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            try
                            {
                                db.pro_delete_loans_add_map(loan_sid_, report_date_, abs_constant_loans_map_id_);                                
                            }
                            catch (Exception oe)
                            {
                                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_add_map)");
                                //splashScreenManager.CloseWaitForm();
                            }
                            //refreshListExtraPokaz();
                        }
                        break;
                    }
            }
            refereshTabs(index);
            splashScreenManager.CloseWaitForm();
        }
        private void bgvList2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            refereshTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
            splashScreenManager.CloseWaitForm();
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            if (getCurrentID("tsCredits", "loan_sid")>0)
            {
                viewTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
            } else
            {
                MessageBox.Show("Кредит не выбран!");
            }
            
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {
            //dockPanel1.Hide();
            dpPayment.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            dpPayment.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        }

        private void dpPayment_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            switch (dpPayment.Visibility)
            {
                case DockVisibility.Visible:
                    bPayment.Down = true;
                    break;
                case DockVisibility.Hidden:
                    bPayment.Down = false;
                    break;
                default:
                    break;
            }
        }

        private void bPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bPayment.Down)
                dpPayment.Visibility = DockVisibility.Visible;
            else
                dpPayment.Visibility = DockVisibility.Hidden;
        }

        private void bbEvenRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Boolean x = bgvList2.OptionsView.EnableAppearanceEvenRow;
            bgvList2.OptionsView.EnableAppearanceEvenRow = !x;

            bbEvenRow.Down = !bbEvenRow.Down;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (getCurrentID("tsCredits", "loan_sid") > 0)
            {
                insertTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
            } else
            {
                MessageBox.Show("Кредит не выбран!");
            }
        }

   

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void xtraTabControl1_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            refereshTabs(e.PageIndex);            
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (getCurrentID("tsCredits", "loan_sid") > 0)
            {
                editTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
            } else
            {
                MessageBox.Show("Кредит не выбран!");
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (getCurrentID("tsCredits", "loan_sid") > 0)
            {
                deleteTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
            } else
            {
                MessageBox.Show("Кредит не выбран!");
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refereshTabs(xtbCredits.TabPages.IndexOf(xtbCredits.SelectedTabPage));
        }
        private void createManifestXML(String mfile)
        {

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            writerSettings.CloseOutput = false;
            MemoryStream localMemoryStream = new MemoryStream();

            using (XmlWriter writer = XmlWriter.Create(mfile, writerSettings))
            {
                String s = beData.EditValue.ToString();
                DateTime FilterDateTime = Convert.ToDateTime(s);

                writer.WriteStartElement("manifest");
                writer.WriteElementString("product", "CREDIT");
                writer.WriteElementString("report_date", FilterDateTime.ToString("dd.MM.yyyy"));
                writer.WriteElementString("respondent", "913");
                writer.WriteEndElement();
                writer.Flush();

            }
        }
        private void bbXMLExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            //MessageBox.Show("XML export");
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            //db.create_XML(ref dsMain, FilterDateTime.Date);


            Int32 xCount = 1; //dsMain.Tables["tsXML"].Rows.Count;
            //bCount.Caption = xCount.ToString();
            if (xCount > 0)
            {
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {

                    saveFileDialog1.Filter = "XML FILE|*.xml";
                    saveFileDialog1.Title = "Save an XML File";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            String sfileName = saveFileDialog1.FileName;
                            FileInfo fi = new FileInfo(sfileName);
                            String mFileName = String.Format("{0}\\{1}", fi.DirectoryName, "usci_manifest.xml");
                            

                            createDataXML(sfileName);
                            createManifestXML(mFileName);
                            AddZip(sfileName, mFileName);
                        }
                        catch (Exception oe)
                        {
                            MessageBox.Show("Error: "+oe.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет данных.");
            }
            
        }
        
        private String getXML(DateTime p_date_)
        {
            String result;
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prepared.proc_xml_create_list";
                    cmd.BindByName = true;

                    cmd.Parameters.Add("xml", OracleDbType.Clob, ParameterDirection.Output);
                    cmd.Parameters.Add("report_date_", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    //cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                    //cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    //result = ((OracleString)cmd.Parameters["xml"].Value).ToString(); //(String)xml.Value; 
                    result = ((Oracle.ManagedDataAccess.Types.OracleClob)cmd.Parameters["xml"].Value).Value;
                    return result;
                }
                catch (Exception oe)
                {
                    String s = p_date_.ToString();
                    MessageBox.Show(oe.Message);
                    //DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "prepared.pkg_xml_generation.p_01_test_generate_xml\n " + s);
                    return "error get XML";
                }
            }
        }
        private void createDataXML(String path)
        {
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            String XML = getXML(FilterDateTime.Date);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
            writer.Write(XML);
            writer.Close();

        }
        private void AddZip(String sfileName, String mFileName)
        {
            FileInfo fi1 = new FileInfo(sfileName);
            FileInfo fi2 = new FileInfo(mFileName);
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            String zipFileName = "ChinaBankCredits-["+ FilterDateTime.Date.ToString("dd-MM-yyyy")+"]-"+DateTime.Now.ToString("HHmmss")+".zip";
            String zippath = String.Format("{0}\\{1}", fi1.DirectoryName, zipFileName);
            
            using (ZipFile zip = new ZipFile())
            {
                zip.Comment = "China Bank of Kazakhstan ";
                zip.AddFile(sfileName,"");
                zip.AddFile(mFileName,"");

                try
                {
                    zip.Save(zippath);
                    File.Delete(sfileName);
                    File.Delete(mFileName);
                    if (XtraMessageBox.Show(
                            LangTranslate.UiGetText("Вы хотите посмотреть XML в архиве?"),
                            LangTranslate.UiGetText("Открытие"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        openInExplorer(zippath);
                    }
                    
                } catch(Exception oe)
                {
                    MessageBox.Show("Error: create zip \n"+oe.Message);
                }
                
            }

        }
        static void openInExplorer(string path)
        {
            string cmd = "explorer.exe";
            string arg = "/select, " + path;
            Process.Start(cmd, arg);
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            Color backColor = Color.LightGreen;
            Color foreColor = Color.Brown;

            GridView view = sender as GridView;
            //DateTime _mark = (DateTime)view.GetRowCellValue(e.RowHandle, "RP_BEGIN_DATE");
            
            //MessageBox.Show(_mark.Date.ToString());
            //DateTime dt = new DateTime();            
            if (view.IsRowSelected(e.RowHandle))
            {
                e.Appearance.ForeColor = foreColor;
                e.Appearance.BackColor = backColor;
                /* This property controls whether settings provided by the RowStyle event have a higher priority 
                   than the appearances specified by GridViewAppearances.EvenRow 
                   and GridViewAppearances.OddRow properties */
                e.HighPriority = true;
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ToolTip tt = new ToolTip();            
            
            tt.SetToolTip(this, "Export XML");
        }
    }
}
