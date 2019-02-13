using System;
using ARM_User.ServiceLayer.Guides;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class SimpleGuideTreeBaseForm : SimpleGuideBaseForm
  {
    public SimpleGuideTreeBaseForm()
    {
      InitializeComponent();
    }

    private void SimpleGuideTreeBaseForm_Load(object sender, EventArgs e)
    {
      treeMain.DataSource = MainBS;
      treeMain.ExpandAll();
    }

    protected override void SetEditorsStatus()
    {
      base.SetEditorsStatus();
      treeMain.Enabled = Editor.StateIs(typeof (GuideEditorBase.ViewingState));
    }
  }
}