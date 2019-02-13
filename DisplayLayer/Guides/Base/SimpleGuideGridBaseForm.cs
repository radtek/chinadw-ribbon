using System;
using System.Windows.Forms;
using ARM_User.ServiceLayer.Guides;
using DevExpress.Data;

namespace ARM_User.DisplayLayer.Guides
{
  public partial class SimpleGuideGridBaseForm : SimpleGuideBaseForm
  {
    public SimpleGuideGridBaseForm()
    {
      InitializeComponent();
    }

    private void SimpleGuideGridBaseForm_Load(object sender, EventArgs e)
    {
      gridMain.DataSource = MainBS;
    }

    protected override void SetEditorsStatus()
    {
      base.SetEditorsStatus();
      gridMain.Enabled = Editor.StateIs(typeof (GuideEditorBase.ViewingState));

      gridMainView.ActiveFilterEnabled = Editor.StateIs(typeof (GuideEditorBase.ViewingState));
    }

    protected override void doSaveToExcel()
    {
      saveFileDialog1.FileName = Text;
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        gridMainView.ExportToXls(saveFileDialog1.FileName);
    }

    private void SimpleGuideGridBaseForm_Shown(object sender, EventArgs e)
    {
      if (gridMainView.VisibleColumns.Count > 0 &&
          gridMainView.VisibleColumns[0].SummaryItem.SummaryType == SummaryItemType.None)
        gridMainView.VisibleColumns[0].SummaryItem.SummaryType = SummaryItemType.Count;
    }
  }
}