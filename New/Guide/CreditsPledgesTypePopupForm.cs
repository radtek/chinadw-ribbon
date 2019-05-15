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
    public partial class CreditsPledgesTypePopupForm : ARM_User.DisplayLayer.Base.ChoiceTreeBaseForm
    {
        private DB_Pledges db;
        private ImageList x = new ImageList();

        public DateTime report_date;
        public Int32 pokaz_parent_id_;
        public String code;

        public CreditsPledgesTypePopupForm()
        {
            InitializeComponent();
            db = new DB_Pledges();
        }

        private void PledgesTypePopupForm_Load(object sender, EventArgs e)
        {
            db.getReadPledgestypePopup(ref dsMain, report_date, pokaz_parent_id_);
            treeMain.DataSource = dsMain;

            treeMain.DataSource = dsMain;
            treeMain.DataMember = "tsPledgesType";
            treeMain.KeyFieldName = "pokaz_id";
            treeMain.ParentFieldName = "parent_id";
            treeMain.PreviewFieldName = "NAME";
            treeMain.ExpandAll();
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnOk.Location = new Point(this.Width - btnCancel.Width - btnOk.Width - 40, btnOk.Location.Y);

            x.Images.Add(Properties.Resources.folder_horizontal);
            x.Images.Add(Properties.Resources.juldyz);
            
            treeMain.StateImageList = x;

        }
        private void treeMain_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (getCurrentID("tsPledgesType", "level_no") == 3)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;

            //treeMain.SelectImageList = x;
            
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
            result = row[sField].ToString();
            return result;
        }

        private void treeMain_Resize(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnOk.Location = new Point(this.Width - btnCancel.Width - btnOk.Width - 40, btnOk.Location.Y);
        }

        private void treeMain_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            String level = e.Node.GetValue(colLevel).ToString();

            if (e.Node.HasChildren == true)
                e.Node.StateImageIndex = 0;
            else 
                e.Node.StateImageIndex = 1;
        }

        private void treeMain_DoubleClick(object sender, EventArgs e)
        {
            code = getCurrentName("tsPledgesType", "code");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            code = getCurrentName("tsPledgesType", "code");
        }
    }
}
