using System;
using System.ComponentModel;
using BSB.Common;
using DevExpress.XtraBars;

namespace ARM_User.DisplayLayer.Guides.Base
{
  public partial class DBListTreeBaseForm : MDIChildForm
  {
    protected int count_record;
      public DBListTreeBaseForm()
    {
      InitializeComponent();
    }

    private void DBListRoForm_Load(object sender, EventArgs e)
    {
      //  gridMain.DataSource = MainBS;
    }

    protected virtual void SetEditorsStatus()
    {
    }

    //protected void doSaveToExcel()
    //{
    //  saveFileDialog1.FileName = Text;
    //  if (saveFileDialog1.ShowDialog() == DialogResult.OK)
    //    gridMainView.ExportToXls(saveFileDialog1.FileName);
    //}

    private void MainBS_ListChanged(object sender, ListChangedEventArgs e)
    {
      SetEditorsStatus();
    }

    private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
    {
        CountRecord();
    }

    private void treeList1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        CountRecord();
    }
    public void CountRecord()
    {
        count_record = 0;
        count_record = MainBS.Count;
        edCountRecord.Caption = Convert.ToString(count_record);
    }
  }
}