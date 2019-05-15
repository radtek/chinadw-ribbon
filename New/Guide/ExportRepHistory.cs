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
    public partial class ExportRepHistory : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        private DB_ExportRep db;
        public Int32 rep_name_id_;
        public ExportRepHistory()
        {
            InitializeComponent();
            db = new DB_ExportRep();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                
            }
            finally
            {
                Close();
                //Cursor = Cursors.Default;
            }
        }

        private void ExportRepHistory_Load(object sender, EventArgs e)
        {
            db.getReadExportRepHistoryList(ref dsMain, rep_name_id_);
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnSave.Location = new Point(this.Width - btnCancel.Width - btnSave.Width - 40, btnSave.Location.Y);
        }

        private void ExportRepHistory_ResizeEnd(object sender, EventArgs e)
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30,btnCancel.Location.Y);
            btnSave.Location = new Point(this.Width - btnCancel.Width - btnSave.Width - 40, btnSave.Location.Y);
        }
    }
}
