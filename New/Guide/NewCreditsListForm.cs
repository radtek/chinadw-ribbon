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
    public partial class NewCreditsListForm : BSB.Common.MDIChildForm
    {
        private DB_Pledges db = null;

        public NewCreditsListForm()
        {
            InitializeComponent();
            db = new DB_Pledges();

            beData.EditValue = (DateTime)System.DateTime.Today;
            
            try
            {
                splashScreenManager.ShowWaitForm();
                refreshListCredits();
            }
            finally
            {
                splashScreenManager.CloseWaitForm();
            }

            
            bgvCredits.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            bgvSheduler.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            
            bgvCredits.OptionsView.ShowGroupPanel = false;
            bgvSheduler.OptionsView.ShowGroupPanel = false;

            

            //colh_loan_sid.Fixed = FixedStyle.Left;
        }
        private void bgvList2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            splashScreenManager.ShowWaitForm();            
            refreshListPaymentPlan();
            refreshListPledges();
            refreshListPokaz();
            refreshListExtraPokaz();
            splashScreenManager.CloseWaitForm();
        }
        public void refreshListPaymentPlan()
        {
            gridBand2.Caption = String.Format("График оплаты - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));
            
            db.getReadPaymentPlan(ref dsMain, (DateTime)beData.EditValue, getCurrentID("tsCredits", "LOAN_SID"));
        }
        public virtual void refreshListCredits()
        {
            //Cursor = Cursors.WaitCursor;
            //splashScreenManager.ShowWaitForm();
            bgvCredits.BeginUpdate();
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
            db.getReadListCredits(ref dsMain, FilterDateTime.Date);
            Int32 xCount = dsMain.Tables["tsCredits"].Rows.Count;
            bCount.Caption = xCount.ToString();
            if (xCount == 0)
            {
                pBottomContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                pLeftContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            }
            else
            {
                pBottomContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                pLeftContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            }
            //Cursor = Cursors.Default;
            //splashScreenManager.CloseWaitForm();


            bgvCredits.EndUpdate();

        }
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
                gdbPledges.Caption = String.Format("Залоги - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));
                int x = bandedGridView3.Columns.Count;
                for (int i = 0; i < x / 2; i++)
                {
                    bandedGridView3.Columns[i].Fixed = FixedStyle.Left;
                }

                /*
                tstCount.Text = xCount.ToString();
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;*/
            }
            else
                if (dsMain.Tables.Contains("tsPledges")) dsMain.Tables["tsPledges"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
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
                gbPokaz.Caption = String.Format("Показатели - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));
                /*tstCount.Text = xCount.ToString();
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;*/
            }
            else
                if (dsMain.Tables.Contains("tsPokaz")) dsMain.Tables["tsPokaz"].Clear();

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
                gbExtraPokaz.Caption = String.Format("Доп.оказатели - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));
                /*tstCount.Text = xCount.ToString();
                //MessageBox.Show(xCount.ToString());
                Boolean xPermission = xCount == 0;
                tsbView.Enabled = !xPermission;
                tsbEdit.Enabled = !xPermission;
                tsbDelete.Enabled = !xPermission;*/
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

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*dpSheduler.Text = String.Format("[{0}-{1}]", getCurrentShortDate("tsPaymentPlan", "RP_BEGIN_DATE"),
                getCurrentShortDate("tsPaymentPlan", "RP_END_DATE"));*/
        }
    }
}
