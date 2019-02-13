﻿using System;
using System.ComponentModel;
using BSB.Common;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.ServiceLayer.Service;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Guides.Base
{
  public partial class DBListTreeBaseForm : MDIChildForm
  {
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

    private void MainBS_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
    {
      SetEditorsStatus();
    }

    private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
    }
    private void MainBS_CurrentChanged(object sender, System.EventArgs e)
    {
        SetEditorsStatus();
    }
  }
}