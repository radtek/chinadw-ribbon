using ARM_User.New.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class CreditsPledgesCurencyPopupForm : ARM_User.DisplayLayer.Base.ChoiceTreeBaseForm
    {
        private DB_Pledges db;

        public DateTime report_date;
        public String code;

        public CreditsPledgesCurencyPopupForm()
        {
            InitializeComponent();
            db = new DB_Pledges();
            
        }

        private void PledgesCurencyPopupForm_Load(object sender, EventArgs e)
        {
            db.getReadCurrencyPledgesPopup(ref dsMain, report_date);
            Int32 count = dsMain.Tables[0].Rows.Count;

            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnOk.Location = new Point(this.Width - btnCancel.Width - btnOk.Width - 40, btnOk.Location.Y);
        }
        private Int32 getCurrentID(String sTable, String sField)
        {
            Int32 result = -1;
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
            row = (ManagerTable.Current as DataRowView).Row;
            result = Convert.ToInt32(row[sField]);
            return result;
        }
        private String getCurrentName(String sTable, String sField)
        {
            String result = "";
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
            row = (ManagerTable.Current as DataRowView).Row;
            result = Convert.ToString(row[sField]);
            return result;
        }
        private void treeMain_Resize(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnOk.Location = new Point(this.Width - btnCancel.Width - btnOk.Width - 40, btnOk.Location.Y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            code = getCurrentName("tsCurrency", "currency_code");
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            code = getCurrentName("tsCurrency", "currency_code");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
