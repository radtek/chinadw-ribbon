using ARM_User.New.Guide;
using BSB.Common.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_User.New.DB
{
    class  NewCreditImpPokaz : PanelAction
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
        public String code;
        public String name;

        public ServiceLayer.Service.Editor.EditorState State;
        public String Text;


        public NewCreditImpPokaz( 
             DateTime report_date,
             String ref_no,
             Int32 loan_sid,                        
             String contract_no,

             Int32 pokaz_id,
             String dim_name,
             String dim_part,
             Int32 abs_dimension_id,
             String code,
             String name
            )
        {
            this.report_date = report_date;
            this.ref_no = ref_no;
            this.loan_sid = loan_sid;
            this.contract_no = contract_no;

            this.pokaz_id = pokaz_id;
            this.dim_name = dim_name;
            this.dim_part = dim_part;
            this.abs_dimension_id = abs_dimension_id;
            this.code = code;
            this.name = name;
    }
        public void Delete()
        {
            try
            {
                db.pro_delete_loans_map(loan_sid, report_date, abs_dimension_id, pokaz_id);
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_LoansListForm.pro_delete_loans_map)");
            }
        }

        public void Insert()
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = Text;
            frm.report_date = report_date;
            frm.State = State;
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;
            frm.ShowDialog();
        }

        public void Update()
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = Text;

            frm.State = State;
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;
            frm.report_date = report_date;
            frm.dim_name = dim_name;
            frm.dim_part = dim_part;
            frm.abs_dimension_id = abs_dimension_id;
            frm.pokaz_id = pokaz_id;
            frm.code = code;
            frm.name = name;

            frm.ShowDialog();
        }

        public void View()
        {
            var frm = new CreditsLoansAddPokazForm();
            frm.Text = "Просмотр показателя";

            frm.State = State;
            frm.loan_sid = loan_sid;
            frm.contract_no = contract_no;
            frm.ref_no = ref_no;


            frm.report_date = report_date;
            frm.dim_name = dim_name;
            frm.dim_part = dim_part;
            frm.abs_dimension_id = abs_dimension_id;
            frm.pokaz_id = pokaz_id;
            frm.code = code;
            frm.name = name;

            frm.ShowDialog();
        }
    }
}
