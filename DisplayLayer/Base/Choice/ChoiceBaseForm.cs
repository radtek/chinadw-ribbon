using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.DisplayLayer.Common;
using BSB.Common;
using DevExpress.XtraEditors;

namespace ARM_User.DisplayLayer.Base
{
  public partial class ChoiceBaseForm : XtraForm
  {
    protected DomainObject firstSelectedObject;
    protected DomainObject getObj;
    /* protected DomainObjects[] SelectedObjects;*/

    public ChoiceBaseForm()
    {
      InitializeComponent();
    }

    public bool MultiSelect
    {
      get { return gridView1.OptionsSelection.MultiSelect; }
      set { gridView1.OptionsSelection.MultiSelect = value; }
    }

    public DomainObject SelectedObject
    {
      get { return (DomainObject) MainBS.Current; }
      set { firstSelectedObject = value; }
    }

    public List<DomainObject> SelectedObjects
    {
      get
      {
        List<DomainObject> list = null;
        var rowHandles = gridView1.GetSelectedRows();
        if (rowHandles != null)
        {
          list = new List<DomainObject>();
          foreach (var rowHandle in rowHandles)
          {
            var dObj = (DomainObject) gridView1.GetRow(rowHandle);
            list.Add(dObj);
          }
        }
        return list;
      }
    }

    public DomainObject GetObj
    {
      get { return getObj; }
      set { getObj = value; }
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
      if (gridMain.MainView.RowCount != 0)
      {
        DialogResult = DialogResult.OK;
        Close();
      }
    }

    private void ChoiceBaseForm_Shown(object sender, EventArgs e)
    {
      if (Site != null) return;
      if (firstSelectedObject != null)
        MainBS.Position = ((IDOList) MainBS.DataSource).IndexOf(firstSelectedObject);
      else
        gridView1.SelectRow(0);
    }

    private void ChoiceBaseForm_Load(object sender, EventArgs e)
    {
      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);
      GridUtilities.RestoreGridLayouts(this);
    }

    private void ChoiceBaseForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      GridUtilities.SaveGridLayouts(this);
    }
  }
}