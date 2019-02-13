using System;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class LocalizedSimpleGuideOneParamForm : SimpleGuideGridBaseForm
  {
    public LocalizedSimpleGuideOneParamForm()
    {
      InitializeComponent();
    }

    private void SimpleGuideOneParamForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;
      edName.DataBindings.Add("EditValue", MainBS, "NameRu", true);
      edNameKz.DataBindings.Add("EditValue", MainBS, "NameKz", true);
    }
  }
}