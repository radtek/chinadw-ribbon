using ARM_User.BusinessLayer.Guides;
using ARM_User.Reports;
using BSB.Common;

/*
 Authors: Tolebi Baimenov, Nurlan Ryskeldi, Zhandos Iskakov
 */
namespace ARM_User.ServiceLayer.Reporting
{
  public abstract class GeneralWordReport : WordReport
  {
    #region Fields

    protected RepForm form;
    protected LanguageIds language;

    #endregion

    #region Constructors

    public GeneralWordReport()
    {
    }

    public GeneralWordReport(RepForm form, LanguageIds language)
    {
      this.form = form;
      this.language = language;
    }

    #endregion

    //Пример
    /*
    public override void ShowReport()
    {
      // сюда процедура Oracle 
      
      BeginFillReport();

      try
      {
        var path = SaveTemplateFile(form.GetTemplate(language));

        Document wordDoc =
          wordApp.Documents.Open(path, ref varMissing,
            false,
            ref varMissing, ref varMissing, ref varMissing, ref varMissing,
            ref varMissing, ref varMissing, ref varMissing,
            ref varMissing, ref varMissing, ref varMissing, ref varMissing,
            ref varMissing, ref varMissing);
        wordDoc.Activate();

        //FindAndReplace(wordApp, "${firstName}", "Tolebi");
        //FindAndReplace(wordApp, "${lastName}", "Baimenov");

        wordDoc.Save();
        wordApp.Visible = true;
      }
      catch (Exception varE)
      {
        MessageBox.Show("Error:\n" + varE.Message, "Error message");
      }
      finally
      {
        EndFillReport();
      }
    }
    */

  }
}