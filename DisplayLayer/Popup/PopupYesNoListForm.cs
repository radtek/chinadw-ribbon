using System;
using ARM_User.DisplayLayer.Base;
using ARM_User.MapperLayer.Common;

namespace ARM_User.DisplayLayer.Guides.PopupList
{
  public partial class PopupYesNoListForm : ChoiceBaseForm
  {
    public PopupYesNoListForm()
    {
      InitializeComponent();
    }

    private void ChoiceYesNoListForm_Load(object sender, EventArgs e)
    {
      MainBS.DataSource = MapperRegistry.Instance.GetYesNoMapper().FindAll();
    }
  }
}