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
    public partial class ChoiceTreeBaseForm : DevExpress.XtraEditors.XtraForm
    {
        protected DomainObject firstSelectedObject;
    protected DomainObject getObj;
    /* protected DomainObjects[] SelectedObjects;*/


    public ChoiceTreeBaseForm()
    {
      InitializeComponent();
    }

    public bool MultiSelect
    {
      get { return treeMain.OptionsSelection.MultiSelect; }
      set { treeMain.OptionsSelection.MultiSelect = value; }
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
        if (treeMain.Selection != null)
        {
          list = new List<DomainObject>();
          list.Add((DomainObject) MainBS.Current);
          //foreach (int rowHandle in treeMain.Fo)
          //{
          //  DomainObject dObj = (DomainObject)gridView1.GetRow(rowHandle);
          //  list.Add(dObj);
          //}
        }
        return list;
      }
    }

    public DomainObject GetObj
    {
      get { return getObj; }
      set { getObj = value; }
    }

    public virtual void gridView1_DoubleClick(object sender, EventArgs e)
    {
      if (treeMain.Selection.Count != 0)
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
        //TODO: bop like
        MainBS.Position = 0;
    }

    private void ChoiceTreeBaseForm_Load(object sender, EventArgs e)
    {
      GridUtilities.RestoreGridLayouts(this);
      if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        new LangTranslate().UISetupTexts(this);     
    }

    private void ChoiceTreeBaseForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      GridUtilities.SaveGridLayouts(this);
    }
  }
}