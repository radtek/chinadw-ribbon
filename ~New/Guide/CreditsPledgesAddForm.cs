using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class CreditsPledgesAddForm : ARM_User.DisplayLayer.Guides.Base.ChinaSimpleEditForm
    {
        public Int32 h_loan_sid;
        public String src_ddfrey;
        public String src_ddfref;
        public String src_ddfcnt;

        public Int32 sat_loans_pledge_id;
        public String ple_contract_type;
        public String ple_contract_no;
        public String ple_contract_date;
        public String ple_square_zu;
        public String ple_maturity_date;
        public String ple_region_kato;
        public String ple_region;
        public String ple_placement;
        public String ple_evaluate_company;
        public String ple_report_no;
        public String ple_revaluating_date;
        public String ple_market_value;
        public String ple_currency;
        public String ple_value_kzt;
        public String ple_value;
        public String ple_high_liquidity;
        public String ple_type_old_crreg;
        public String ple_type_fcb;
        public String ple_type_crreg;
        public String ple_penalty_type;
        public String ple_redemption_date;
        public String ple_returned_sum;
        public String ple_coefficient;

        public DateTime report_date;
        public CreditsPledgesAddForm()
        {
            InitializeComponent();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PledgesAddForm_Load(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnSave.Location = new Point(this.Width - btnCancel.Width - btnSave.Width - 40, btnSave.Location.Y);

            te_h_loan_sid.Text = h_loan_sid.ToString();
            te_src_ddfrey.Text = src_ddfrey;
            te_src_ddfref.Text = src_ddfref;
            te_src_ddfcnt.Text = src_ddfcnt;
            Boolean view = State == ServiceLayer.Service.Editor.EditorState.View;
            Boolean edit = State == ServiceLayer.Service.Editor.EditorState.Edit;
            if (view||edit)
            {
                te_sat_loans_pledge_id.Text = sat_loans_pledge_id.ToString();
                te_ple_contract_type.Text = ple_contract_type;
                te_ple_contract_no.Text = ple_contract_no;
                te_ple_contract_date.EditValue = ple_contract_date;                
                te_ple_square_zu.Text = ple_square_zu;
                te_ple_maturity_date.EditValue = ple_maturity_date;
                te_ple_region_kato.Text = ple_region_kato;
                te_ple_region.Text = ple_region;
                te_ple_placement.Text = ple_placement;
                te_ple_evaluate_company.Text = ple_evaluate_company;
                te_ple_report_no.Text = ple_report_no;
                te_ple_revaluating_date.EditValue = ple_revaluating_date;
                te_ple_market_value.Text = ple_market_value;
                te_ple_value_kzt.Text = ple_value_kzt;
                te_ple_currency.Text = ple_currency;
                te_ple_value_kzt.Text = ple_value_kzt;
                te_ple_value.Text = ple_value;
                te_ple_high_liquidity.Text = ple_high_liquidity;
                te_ple_type_old_crreg.Text = ple_type_old_crreg;
                te_ple_type_fcb.Text = ple_type_fcb;
                te_ple_type_crreg.Text = ple_type_crreg;
                te_ple_penalty_type.Text = ple_penalty_type;
                te_ple_redemption_date.EditValue = ple_redemption_date;
                te_ple_returned_sum.Text = ple_returned_sum;
                te_ple_coefficient.Text = ple_coefficient;
            }
            
        }

        private void PledgesAddForm_SizeChanged(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnSave.Location = new Point(this.Width - btnCancel.Width - btnSave.Width - 40, btnSave.Location.Y);
        }

        private void te_ple_currency_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new CreditsPledgesCurencyPopupForm();
            frm.Text = "Справочник валют";
            frm.report_date = report_date;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                te_ple_currency.Text = frm.code;
            }
        }

        private void te_ple_type_old_crreg_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new CreditsPledgesTypePopupForm();
            frm.Text = "Вид обеспечения по старому кредитному регистру";
            frm.report_date = report_date;
            frm.pokaz_parent_id_ = 501;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                te_ple_type_old_crreg.Text = frm.code;
            }
        }

        private void te_ple_type_fcb_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new CreditsPledgesTypePopupForm();
            frm.Text = "Вид обеспечения по справочнику кредитного бюро";
            frm.pokaz_parent_id_ = 505;
            frm.report_date = report_date;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                te_ple_type_fcb.Text = frm.code;
            }
        }

        private void te_ple_type_crreg_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new CreditsPledgesTypePopupForm();
            frm.Text = "Вид обеспечения по справочнику кредитного регистра";
            frm.pokaz_parent_id_ = 511;
            frm.report_date = report_date;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                te_ple_type_crreg.Text = frm.code;
            }
        }
    }
}
