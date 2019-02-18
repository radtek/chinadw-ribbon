﻿using ARM_User.BusinessLayer.Common;
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

    public partial class ExtraPokazADDForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
#region [Preperties]
        private DB_ExtraPokazListForm db = null;
        //view parameter        
        public Int32 customer_sid_;
        public String customer_name;
        public Int32 customer_code;
        public DateTime report_date_;
        public Int32 abs_dimension_id_;
        public Int32 pokaz_id_;
        // Ratings
        public String dim_name_ ;
        public String part_name ;
        public String abs_name_ ;
        public String abs_code_ ;
        public String customer_name_;
        public String customer_no_;
        private Boolean isChanched;
#endregion
        public ExtraPokazADDForm()
        {
            InitializeComponent();
            db = new DB_ExtraPokazListForm(dmControler.frmMain.oracleConnection);
            
            /*if (State == ServiceLayer.Service.Editor.EditorState.Edit || 
                State == ServiceLayer.Service.Editor.EditorState.Insert)
            {
                if (!UnitOfWork.Instance.IsTransactionStarted)
                    UnitOfWork.Instance.BeginTransaction();
            }*/
        }

        private void btGuides_Click(object sender, EventArgs e)
        {
            var frm = new ExtraPokazPopupForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbABSDimId.Text = Convert.ToString(frm.abs_dimension_id);
                tbPokazId.Text = Convert.ToString(frm.pokaz_id);
                tbName.Text = Convert.ToString(frm.name);
                tbCode.Text = Convert.ToString(frm.code);
                tbDimName.Text = Convert.ToString(frm.dim_name);
                tbDimPart.Text = Convert.ToString(frm.dim_part);
            }

        }

        void viewData(Int32 customer_sid_,
                      DateTime report_date_,
                      Int32 abs_dimension_id_,
                      Int32 pokaz_id_                                    
                                    )
        {
            /*String dim_name_="";
            String part_name = "";
            String abs_name_ = "";
            String abs_code_ = "";
            String customer_name_ = "";
            String customer_no_ = "";*/
            db.viewCusomerMap(customer_sid_, report_date_, abs_dimension_id_, pokaz_id_, 
                            out dim_name_, out part_name, out abs_name_, out abs_code_, out customer_name_, out customer_no_);
            tbDimName.Text = dim_name_;
            tbDimPart.Text = part_name;
            tbCode.Text = abs_code_;

            tbCustomerName.Text = customer_name_;
            tbCustomerCode.Text = Convert.ToString(customer_code);
            tbCustomerSid.Text = customer_no_;
            tbName.Text = abs_name_;
        }

        private void ExtraPokazADDForm_Load(object sender, EventArgs e)
        {
            
            tbCustomerSid.Text = Convert.ToString(customer_sid_);
            tbCustomerName.Text = Convert.ToString(customer_name);
            tbCustomerCode.Text = Convert.ToString(customer_code);
            // VIEW
            Boolean update = State == ServiceLayer.Service.Editor.EditorState.Edit;
            Boolean insert = State == ServiceLayer.Service.Editor.EditorState.View;
            if (insert || update)
            {
                tbDimName.Text = Convert.ToString(dim_name_);
                tbDimPart.Text = Convert.ToString(part_name);
                tbABSDimId.Text = Convert.ToString(abs_dimension_id_);
                tbPokazId.Text = Convert.ToString(pokaz_id_);
                tbCode.Text = Convert.ToString(abs_code_);
                tbName.Text = abs_name_;
                if(insert) btGuides.Enabled = false;
            }
            
            //viewData(customer_sid_, report_date_, abs_dimension_id_, pokaz_id_);
            
        }
        protected override bool Validate()
        {
            if (tbDimName.Text =="")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Выберите показатель из справочника"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btGuides.Focus();                
                return false;
            }
            return true;
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Cursor = Cursors.WaitCursor;
                customer_sid_ = Convert.ToInt32(tbCustomerSid.Text);
                abs_dimension_id_ = Convert.ToInt32(tbABSDimId.Text);
                pokaz_id_ = Convert.ToInt32(tbPokazId.Text);

                if (State == ServiceLayer.Service.Editor.EditorState.Insert)
                {
                    db.insertCostomerMap(customer_sid_, report_date_, abs_dimension_id_, pokaz_id_);
                }
                else if (State == ServiceLayer.Service.Editor.EditorState.Edit)
                {
                    db.updateCostomerMap(customer_sid_, report_date_, abs_dimension_id_, pokaz_id_);
                }
                DialogResult = DialogResult.OK;
                Close();
                Cursor = Cursors.Default;
            }
        }
    }
    
}