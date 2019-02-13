using System;
using BSB.Common;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Guides.Base
{
    public partial class DBHdBaseForm : MDIChildForm
    {
        protected int count_record;
        public DBHdBaseForm()
        {
            InitializeComponent();
        }

        private void DBListRoForm_Load(object sender, EventArgs e)
        {

        }

        protected virtual void SetEditorsStatus()
        {
        }

        protected void doSaveToExcel()
        {

        }

        private void MainBS_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            // SetEditorsStatus();      
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CountRecord();
        }

        private void gridMain_MouseMove(object sender, MouseEventArgs e)
        {
            CountRecord();
        }
        public void CountRecord()
        {

        }

        private void MainBS_CurrentChanged(object sender, EventArgs e)
        {
            SetEditorsStatus();
        }
    }
}
   
