using ARM_User.New.Guide;
using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_User.New.DB
{
    

    class NewCreditImpExtraPokaz : PanelAction
    {
        private DB_Pledges db = null;

        public DateTime report_date;
        public String ref_no;
        public Int32 loan_sid;
        public String contract_no;

        public Int32 pokaz_id;
        public String dim_name;
        public String dim_part;        
        public Int32 abs_dimension_id;
        public Int32 abs_constant_dimension_id;
        public Int32 abs_constant_loans_map_id;
        public String map_value;
        public String code;
        public String name;

        public ServiceLayer.Service.Editor.EditorState State;
        public String Text;
        public NewCreditImpExtraPokaz(
            Int32 loan_sid,
            String contract_no,
            String ref_no,

            DateTime report_date,
            String dim_name,
            String dim_part,
            Int32 abs_dimension_id,
            Int32 abs_constant_dimension_id,
            Int32 abs_constant_loans_map_id,        
            Int32 pokaz_id,
            String map_value,
            String code,
            String name)
        {
            this.loan_sid = loan_sid;
            this.contract_no = contract_no;
            this.ref_no = ref_no;

            this.report_date = report_date;
            this.dim_name = dim_name;
            this.dim_part = dim_part;
            this.abs_dimension_id = abs_dimension_id;
            this.abs_constant_dimension_id = abs_constant_dimension_id;
            this.abs_constant_loans_map_id = abs_constant_loans_map_id;
            this.pokaz_id = pokaz_id;
            this.map_value = map_value;
            this.code = code;
            this.name = name;
        }
        public void Delete()
        {
            try
            {
                db.pro_delete_loans_add_map(loan_sid, report_date, abs_constant_loans_map_id);
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_add_map)");                
            }
        }

        public void Insert()
        {
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Добавить дополнительный показатель";
            frm.State = ServiceLayer.Service.Editor.EditorState.Insert;
            // from credits
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;
            frm.abs_constant_dimension_id = abs_constant_dimension_id;            
            frm.report_date = report_date;

            frm.ShowDialog();
        }

        public void Update()
        {
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Изменить дополнительный показатель";
            frm.State = ServiceLayer.Service.Editor.EditorState.Edit;
            // from credits
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;

            frm.report_date = report_date;
            frm.name = name;
            frm.map_value = map_value;
            frm.abs_constant_dimension_id = abs_constant_dimension_id;
            frm.report_date = report_date;

            frm.ShowDialog();
        }

        public void View()
        {
            var frm = new CreditsLoansAddExtraPokazForm();
            frm.Text = "Просмотр дополнительного показателя";
            frm.State = ServiceLayer.Service.Editor.EditorState.View;
            // from credits
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;

            frm.report_date = report_date;
            frm.name = name;
            frm.map_value = map_value;

            frm.ShowDialog();
        }
    }
}
