using System;
using BSB.Common;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Guides.Base
{
  public partial class DBListROBaseForm : MDIChildForm
  {
      protected int count_record;
    public DBListROBaseForm()
    {
      InitializeComponent();      
    }

    private void DBListRoForm_Load(object sender, EventArgs e)
    {
        gridMain.DataSource = MainBS;
        
    }

    protected virtual void SetEditorsStatus()
    {
    }

    protected void doSaveToExcel()
    {
      saveFileDialog1.FileName = Text;
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        gridMainView.ExportToXls(saveFileDialog1.FileName);
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
    public void  CountRecord()
    {
        count_record = 0;
        if (gridMainView.RowCount > 0)
            count_record = gridMainView.RowCount;
        else
            count_record = MainBS.Count;        
        edCountRecord.Caption = Convert.ToString(count_record);
    }

    private void MainBS_CurrentChanged(object sender, EventArgs e)
    {
        SetEditorsStatus();      
    }
   
  }
}