using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class LoansListForm : BSB.Common.MDIChildForm
    {
        public LoansListForm()
        {
            InitializeComponent();
        }

        private void bbFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean filtered = gvList1.OptionsView.ShowAutoFilterRow;
            if (filtered)
            {
                gvList1.ClearColumnsFilter();
                bbFilter.Glyph = Properties.Resources.filter;
            }
            else
                bbFilter.Glyph = Properties.Resources.filter_disable;
            gvList1.OptionsView.ShowAutoFilterRow = !filtered;
        }

        private void bbSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean finded = gvList1.OptionsFind.AlwaysVisible;
            if (finded) gvList1.ApplyFindFilter("");
            gvList1.OptionsFind.AlwaysVisible = !finded;
        }
        
        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshList1();
        }
        #region[REFRESH VIRTUAL]
        public virtual void refreshList1()
        {
        }
        public virtual void refeshList2()
        {
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refeshList2();
        }

        private void beData_EditValueChanged(object sender, EventArgs e)
        {
            refreshList1();
        }
    }
}
