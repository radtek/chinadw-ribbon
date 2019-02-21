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
    public partial class LoansAddExtraPokazForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        public Int32 loan_sid;
        public DateTime report_date;
        public String contract_no;
        public String ref_no;
        /**/
        public String creg_contract_no;
        public String creg_contract_date;
        public String crreg_line_contract_no;

        #region [Preperties]
            private DB_LoansListForm db = null;
        #endregion
        public LoansAddExtraPokazForm()
        {
            InitializeComponent();
        }

        private void LoansAddExtraPokazForm_Load(object sender, EventArgs e)
        {
            tbLoan_sid.Text = loan_sid.ToString();
            tbContract_no.Text = contract_no;
            tbRef_no.Text = ref_no;
            //VIEW
            Boolean update = State == ServiceLayer.Service.Editor.EditorState.Edit;
            Boolean view = State == ServiceLayer.Service.Editor.EditorState.View;
            if (!view) db = new DB_LoansListForm(dmControler.frmMain.oracleConnection);
            if (update || view)
            {                
                tbCrreg_line_contract_no.Text = crreg_line_contract_no;
                tbGreg_contract_no.Text = creg_contract_no;
                dttCreg_contract_date.Value = Convert.ToDateTime(creg_contract_date);
                if(view)
                {
                    tbCrreg_line_contract_no.ReadOnly = true;
                    tbGreg_contract_no.ReadOnly = true;
                    dttCreg_contract_date.Enabled = false;
                }
            }
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Cursor = Cursors.WaitCursor;
                
                creg_contract_no = tbGreg_contract_no.Text;
                creg_contract_date = dttCreg_contract_date.Text;
                crreg_line_contract_no = tbCrreg_line_contract_no.Text;

                if (State == ServiceLayer.Service.Editor.EditorState.Insert)
                {
                    try
                    {
                        db.pro_insert_loans_add_map(loan_sid, report_date, creg_contract_no, creg_contract_date, crreg_line_contract_no);
                    }                        
                    catch (Exception oe)                    
                    {
                        DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_INSERT_LOANS_ADD_MAP)");
                    }
                }
                else if (State == ServiceLayer.Service.Editor.EditorState.Edit)
                {
                    try
                    {
                        db.pro_update_loans_add_map(loan_sid, report_date, creg_contract_no, creg_contract_date, crreg_line_contract_no);
                    }                    
                    catch (Exception oe)
                    {
                        DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.PRO_INSERT_LOANS_ADD_MAP)");
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
                Cursor = Cursors.Default;
            }            
        }
        protected override bool Validate()
        {
            if (tbGreg_contract_no.Text == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Заполните № договора"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbGreg_contract_no.Focus();
                return false;
            }
            if (tbCrreg_line_contract_no.Text == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Заполните № договора кред линии"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCrreg_line_contract_no.Focus();
                return false;
            }
            return true;
        }        
    }
}
