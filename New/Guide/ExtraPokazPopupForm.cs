using ARM_User.BusinessLayer.Common;
using ARM_User.New.DB;
using BSB.Common;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ExtraPokazPopupForm : ARM_User.DisplayLayer.Base.ChoiceTreeBaseForm
    {
        #region [Preperties]
            private DB_ExtraPokazListForm db = null;
            private ImageList x = new ImageList();

            public Int32 abs_dimension_id;
            public Int32 pokaz_id;
            public Int32 parent_id;
            public String name;
            public String code;
            public DateTime report_date;
            public String dim_name;
            public String dim_part;
            public String note;
            public Int32 level_no;

        #endregion
        public ExtraPokazPopupForm()
        {
            InitializeComponent();

        }

        private void ExtraPokazPopupForm_Load(object sender, EventArgs e)
        {
            db = new DB_ExtraPokazListForm(dmControler.frmMain.oracleConnection);            
            db.getPopupRead(ref dsMain);
            treeMain.DataSource = dsMain;
            treeMain.DataMember = "TablePopup";
            treeMain.KeyFieldName = "POKAZ_ID";
            treeMain.ParentFieldName = "PARENT_ID";
            treeMain.PreviewFieldName = "NAME";
            x.Images.Add(Properties.Resources.folder_horizontal);
            x.Images.Add(Properties.Resources.juldyz);
            treeMain.StateImageList = x;            
            
        }

        private void treeMain_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {   
            //treeMain.SelectImageList = x;
            String level = e.Node.GetValue(колLEVEL).ToString();
            if (e.Node.HasChildren == true)
                e.Node.StateImageIndex = 0;
            else
                e.Node.StateImageIndex = 1;
        }

        private void ExtraPokazPopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                this.abs_dimension_id = getCurrentID("TablePopup", "ABS_DIMENSION_ID");
                this.pokaz_id = getCurrentID("TablePopup", "POKAZ_ID");
                this.parent_id = getCurrentID("TablePopup", "PARENT_ID");
                this.name = getCurrentName("TablePopup", "NAME");
                this.code = getCurrentName("TablePopup", "CODE");
                this.report_date = getCurrentDate("TablePopup", "REPORT_DATE");
                this.dim_name = getCurrentName("TablePopup", "DIM_NAME");
                this.dim_part = getCurrentName("TablePopup", "DIM_PART");
            }
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
        private DateTime getCurrentDate(String sTable, String sField)
        {
            DateTime result = new DateTime();
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
            row = (ManagerTable.Current as DataRowView).Row;
            result = Convert.ToDateTime(row[sField]);
            return result;
        }

        private void treeMain_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (getCurrentID("TablePopup", "LEVEL_NO") == 3)            
                btnOk.Enabled = true;            
            else
                btnOk.Enabled = false;
        }

        public override void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (getCurrentID("TablePopup", "LEVEL_NO") == 3)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }
    }
}