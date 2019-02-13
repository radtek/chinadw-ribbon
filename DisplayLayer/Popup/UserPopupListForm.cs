using System;
using ARM_User.DisplayLayer.Base;
using ARM_User.MapperLayer.Common;

namespace ARM_User.DisplayLayer.Popup
{
  public partial class UserPopupListForm : ChoiceBaseForm
  {
    public UserPopupListForm()
    {
      InitializeComponent();
    }

    private void ChoiceUserPopupListForm_Load(object sender, EventArgs e)
    {
      MainBS.DataSource = MapperRegistry.Instance.GetUserMapper().FindByCondition(1);
    }
  }
}