using System;
using ARM_User.DisplayLayer.Base;
using ARM_User.MapperLayer.Common;
using ARM_User.BusinessLayer.Guides;

namespace ARM_User.DisplayLayer.Popup
{
  public partial class RegOrganMUPopupListForm : ChoiceTreeBaseForm
  {
      protected RegOrganMU regorganmu;
    public RegOrganMUPopupListForm()
    {
      InitializeComponent();
    }

    private void RegOrganMUPopupListForm_Load(object sender, EventArgs e)
    {
       
        MainBS.DataSource = MapperRegistry.Instance.GetRegOrganMUMapper().FindByCondition(2);
    }

    private void MainBS_CurrentChanged(object sender, EventArgs e)
    {
        regorganmu = (RegOrganMU)MainBS.Current;
    }

    private void treeMain_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
    {
        regorganmu = (RegOrganMU)MainBS.Current;
        if (e.Node.HasChildren == true)
        {
            e.CanFocus = false;
            btnOk.Enabled = false;
        }
        else
            btnOk.Enabled = true;
    }
  }
}