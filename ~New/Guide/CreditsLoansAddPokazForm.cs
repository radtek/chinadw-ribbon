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
    public partial class CreditsLoansAddPokazForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        public Int32 loan_sid;
        public String ref_no;
        public String contract_no;

        public String dim_name;
        public String dim_part;
        public Int32 abs_dimension_id;
        public Int32 pokaz_id;
        public String code;
        public String name;
        public DateTime report_date;
        #region [Preperties]
        private DB_LoansListForm db = null;
        #endregion
        public CreditsLoansAddPokazForm()
        {
            InitializeComponent();
        }

        private void LoansAddPokazForm_Load(object sender, EventArgs e)
        {
            te_loan_sid.Text = loan_sid.ToString();
            te_ref_no.Text = ref_no;
            te_contract_no.Text = contract_no;

            Boolean view = State == ServiceLayer.Service.Editor.EditorState.View;
            Boolean update = State == ServiceLayer.Service.Editor.EditorState.Edit;

            if (!view) db = new DB_LoansListForm(dmControler.frmMain.oracleConnection);
            if (view || update)
            {
                te_dim_name.Text = dim_name;
                te_dim_part.Text = dim_part;
                te_abs_dimension_id.Text = abs_dimension_id.ToString();
                te_pokaz_id.Text = pokaz_id.ToString();
                te_code.Text = code;
                te_name.Text = name;
                if (view) cbGuides.Enabled = false;
            }
            
        }
        protected override bool Validate()
        {
            if (te_dim_name.Text == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Заполните из спроавочника"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGuides.Focus();
                return false;
            }            
            return true;
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Cursor = Cursors.WaitCursor;
                loan_sid = Convert.ToInt32(te_loan_sid.Text);                
                
                abs_dimension_id = Convert.ToInt32(te_abs_dimension_id.Text);
                pokaz_id = Convert.ToInt32(te_pokaz_id.Text);


                if (State == ServiceLayer.Service.Editor.EditorState.Insert)
                {
                    try
                    {
                        db.pro_insert_loans_map(loan_sid, report_date, abs_dimension_id, pokaz_id);
                    }
                    catch (Exception oe)
                    {
                        DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_insert_loans_map)");
                    }
                }
                else if (State == ServiceLayer.Service.Editor.EditorState.Edit)
                {
                    try
                    {
                        db.pro_update_loans_map(loan_sid, report_date, abs_dimension_id, pokaz_id);
                    }
                    catch (Exception oe)
                    {
                        DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_update_loans_map)");
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
                Cursor = Cursors.Default;
            }
        }
        
        private void cbGuides_Click(object sender, EventArgs e)
        {
            var frm = new CreditsExtraPokazPopupForm();
            if (State == ServiceLayer.Service.Editor.EditorState.Edit) frm.id = pokaz_id;
            frm.report_date = report_date;
            frm.note = "LOAN";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                te_abs_dimension_id.Text = Convert.ToString(frm.abs_dimension_id);
                te_pokaz_id.Text = Convert.ToString(frm.pokaz_id);
                te_name.Text = Convert.ToString(frm.name);
                te_code.Text = Convert.ToString(frm.code);
                te_dim_name.Text = Convert.ToString(frm.dim_name);
                te_dim_part.Text = Convert.ToString(frm.dim_part);
            }
        }
    }
    
}
