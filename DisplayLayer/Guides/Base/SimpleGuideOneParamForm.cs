using System;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class SimpleGuideOneParamForm : SimpleGuideGridBaseForm
  {
    public SimpleGuideOneParamForm()
    {
      InitializeComponent();
    }

    private void SimpleGuideOneParamForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;
      edName.DataBindings.Add("EditValue", MainBS, "Name", true);
    }
  }
}