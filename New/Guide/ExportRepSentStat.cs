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
    public partial class ExportRepSentStat : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
        public String INTEGR_STAT;
        public DateTime report_date;
        public Int32 reporter_id;
        public DateTime begin_date;
        public DateTime end_date;
        public Int32 err_code;
        public Int32 zo;

        private DB_ExportRep db;

        public ExportRepSentStat()
        {
            InitializeComponent();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            
            //report_date = Convert.ToDateTime(dtpRep_date.Value.ToString());
            begin_date = Convert.ToDateTime(dtpBegin_date.Value.ToString());
            end_date = Convert.ToDateTime(dtpEnd_date.Value.ToString());
            //zo = Convert.ToInt32(cheZO.EditValue);

            /*db = new DB_ExportRep();
             * err_code = db.getIntegrStat(reporter_id,
                                        INTEGR_STAT, 
                                        report_date, 
                                        begin_date, 
                                        end_date, 
                                        zo);*/

            DialogResult = DialogResult.OK;
            Close();
            Cursor = Cursors.Default;

        }
    }
}
