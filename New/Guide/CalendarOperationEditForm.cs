using ARM_User.New.DB;
using BSB.Common;
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
    public partial class CalendarOperationEditForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        private DB_CalendarOperations db = null;
        //view parameter        
        public DateTime date_value;
        public Int32 status;

        public CalendarOperationEditForm()
        {
            InitializeComponent();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Cursor = Cursors.WaitCursor;

                if (status != comboBox1.SelectedIndex + 1)
                {
                    status = comboBox1.SelectedIndex + 1;
                    db = new DB_CalendarOperations(dmControler.frmMain.oracleConnection);
                    db.updateCalendar(date_value, status);
                }         
                DialogResult = DialogResult.OK;
                Close();
                Cursor = Cursors.Default;
            }
        }

        //protected override bool Validate()
        //{
        //    if ((status == 3 || status == 2) && comboBox1.SelectedIndex == 0)
        //    {
        //        XtraMessageBox.Show(
        //            LangTranslate.UiGetText("Выберите дату праздника"),
        //            LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        dateTimePicker2.Focus();
        //        return false;
        //    }
        //    return true;
        //}

        private void CalendarOperationEditForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = date_value;
            comboBox1.SelectedIndex = status-1;// отнимаю 1 потому что индекс combobox начинается с 0
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
