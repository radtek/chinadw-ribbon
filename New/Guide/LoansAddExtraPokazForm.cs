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
    public partial class LoansAddExtraPokazForm : ARM_User.DisplayLayer.Guides.Base.ChinaSimpleEditForm
    {
        private DB_ExtraPokazListForm db = null;

    #region [global fields ]
        public Int32 loan_sid;        
        public String contract_no;
        public String ref_no;
        /**/
        public DateTime report_date;
        public String name;
        public String map_value;
        public Int32 abs_constant_dimension_id;
        public String note;
    #endregion 

        public LoansAddExtraPokazForm()
        {
            InitializeComponent();

        }
        protected override bool Validate()
        {
            if (te_name.Text == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Выберите показатель"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                te_name.Focus();
                return false;
            } else if (te_map_value.Text.Trim() =="")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Введите значение"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                te_map_value.Focus();
                return false;
            }
            return true;
        }
        private void LoansAddExtraPokazForm_Load(object sender, EventArgs e)
        {
            te_loan_sid.Text = loan_sid.ToString();
            te_ref_no.Text = ref_no.ToString();
            te_contract_no.Text = contract_no.ToString();
            Boolean view = State == ServiceLayer.Service.Editor.EditorState.View;
            Boolean update = State == ServiceLayer.Service.Editor.EditorState.Edit;
            Boolean insert = State == ServiceLayer.Service.Editor.EditorState.Insert;

            if (view||update)
            {
                de_report_date.EditValue = report_date;
                te_name.Text = name;
                te_map_value.Text = map_value;
                
                de_report_date.ReadOnly = !update;
                te_name.ReadOnly = true;
                te_map_value.ReadOnly = !update;
            }
            if (update) te_name.Enabled = false;
            if (insert) de_report_date.EditValue = report_date;
            db = new DB_ExtraPokazListForm(dmControler.frmMain.oracleConnection);

        }

        private void te_name_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show("Тип показателей");
            var frm = new LoansAddPopupForm();
            frm.Text = "Тип показателей";
            frm.loan_sid = loan_sid;
            frm.report_date = report_date;
            if (frm.ShowDialog()==DialogResult.OK)
            {
                te_name.Text = frm.NAME;
                abs_constant_dimension_id = frm.ABS_CONSTANT_DIMENSION_ID;
                note = frm.NOTE;
            }
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Cursor = Cursors.WaitCursor;
                map_value = te_map_value.Text;
                report_date = Convert.ToDateTime(de_report_date.EditValue);

                if (State == ServiceLayer.Service.Editor.EditorState.Insert)
                {
                    db.insertLoansAddMap(loan_sid, report_date, abs_constant_dimension_id, map_value, note);
                }
                else if (State == ServiceLayer.Service.Editor.EditorState.Edit)
                {
                    db.updateLoansAddMap(loan_sid, report_date, abs_constant_dimension_id, map_value, note);
                }
                DialogResult = DialogResult.OK;
                Close();
                Cursor = Cursors.Default;
            }
        }
    }
}
