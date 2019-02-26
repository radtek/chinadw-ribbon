using ARM_User.New.DB;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class Form2 : ARM_User.DisplayLayer.Guides.Base.ChinaGuideBaseForm
    {
        #region [field]
            private DB_Reports db;
        #endregion
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            refreshFormList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshFormList();
        }
        private void refreshFormList()
        {
            
            db.getReportsListF21(ref dsMain, "1");
            gridControl1.RefreshDataSource();
            gridView1.PopulateColumns();

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                if (i > 3)
                {
                    gridView1.Columns[i].Width = 70;
                }
                else
                {
                    gridView1.Columns[i].BestFit();
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    gridView1.Columns[i].OptionsColumn.AllowFocus = false;
                }
            }
            db.getReadReporHeadertList(ref dsMain, "1", new DateTime(2017,1,5));
            DataTable dt = dsMain.Tables["tableReportsHeader"];
            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                gridView1.Columns[j+3].Caption = row[dt.Columns[1]].ToString();
                j++;
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            for(int i=4; i<gridView1.Columns.Count; i++)
            {
                if (e.Column == gridView1.Columns[i])
                {
                    e.Column.ColumnEdit = rbEdit;
                }
            }
            
        }

        private void rbEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            String s = ((Control)sender).Text;
            var frm = new DialogHTMLCelleditForm();
            frm.HTMLText = s;
            frm.ShowDialog();

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            //refreshFormList();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            db = new DB_Reports();
            refreshFormList();
        }
    }
}
