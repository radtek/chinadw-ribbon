using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ARM_User.BusinessLayer;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service.Editor;
using DevExpress.XtraEditors;
using BSB.Common;
using ARM_User.DisplayLayer.Guides.PopupList;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Popup;
using ARM_User.MapperLayer.Common;
using ARM_User.DisplayLayer.Guides;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.IO;
using System.Runtime.InteropServices;
using BSB.Common.DataGateway.Oracle;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using ARM_User.DisplayLayer.Common;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Mask;
using BSB.Common.DB;
using BSB.Common.DB.Admin;

namespace ARM_User.DisplayLayer.Main
{
    public partial class ClientForm : ARM_User.DisplayLayer.Base.SimpleModulsEditSPForm
    {
        
        private   BindingSource methodpla, placeacc;
        protected Executor executor;
        protected DateTime? date;

        public ClientForm()
        {
            InitializeComponent();
            if (UnitOfWork.Instance.IsTransactionStarted)
                UnitOfWork.Instance.Rollback();
            UnitOfWork.Instance.BeginTransaction();
            //Client = Client.CreateNew();
        }
        public ClientForm(decimal id_rep_pla, EditorState state)
        {
            InitializeComponent();
            if (UnitOfWork.Instance.IsTransactionStarted)
                UnitOfWork.Instance.Rollback();
            UnitOfWork.Instance.BeginTransaction();            
            this.state = state;
         }
      
      
        private void ClientForm_Load(object sender, EventArgs e)
        {
            
        }
        protected override bool Validate()
        {
          

            return true;
        }    
        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            
           
        }
       


      
        private void btnFileRu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnFileKz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSlipPrep_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            
        }
              

        private void btnInsertDepNotif_Click(object sender, EventArgs e)
        {
            //var dep = new ShareRepPlaDepNotif(Client);
            //DepRepBS.Add(dep);
            //UnitOfWork.Instance.RegisterNew(dep);
        }

        private void btnDeleteDepNotif_Click(object sender, EventArgs e)
        {
            //((ShareRepPlaDepNotif)(DepRepBS.Current)).Delete();
        }

       
    }
}
