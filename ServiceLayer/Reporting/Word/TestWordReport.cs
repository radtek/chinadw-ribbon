using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

/*
 Authors: Tolebi Baimenov, Nurlan Ryskeldi, Zhandos Iskakov
 */
namespace ARM_User.ServiceLayer.Reporting
{
  public class TestWordReport : GeneralWordReport
  {
    protected string firstName, lastName;
    protected string firstName1, lastName1;
    protected DateTime dateBegin, dateEnd;



    public TestWordReport(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
        : base(form, language)
    {
        this.dateBegin = dateBegin;
        this.dateEnd = dateEnd;    
    }
    protected virtual string GetData()
    {
       /* try
        {
            */
        using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
        {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Word_Report";
            cmd.Parameters.Add("Date_Begin_", OracleDbType.Date, ParameterDirection.Input);
            cmd.Parameters.Add("Date_End_", OracleDbType.Date, ParameterDirection.Input);
            cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("fm_", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("nm_", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters["Date_Begin_"].Value = dateBegin;
            cmd.Parameters["Date_End_"].Value = dateEnd;
            cmd.Parameters["fm_"].Size = 4000;
            cmd.Parameters["nm_"].Size = 4000;
            cmd.ExecuteNonQuery();
            
            firstName1 = cmd.Parameters["fm_"].Value.ToString();
            lastName1 = cmd.Parameters["nm_"].Value.ToString();
            if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
            {
                var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                if (errCode != 0)
                    throw new OraCustomException(errCode, errMsg);
            }
             return ((OracleString)cmd.Parameters["fm_"].Value).Value;
             return ((OracleString)cmd.Parameters["nm_"].Value).Value;
       
        }  
    }
   
    public override void ShowReport()
    {
      
      BeginFillReport();
      GetData(); 

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
/*
        foreach (Section section in wordDoc.Sections)
        {
          var headerRange =
            section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
          headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
          headerRange.ParagraphFormat.Alignment =
            WdParagraphAlignment.wdAlignParagraphCenter;
          headerRange.Font.ColorIndex = WdColorIndex.wdBlue;
          headerRange.Font.Size = 10;
          headerRange.Text = "Header text goes here";
        }

        foreach (Section wordSection in wordDoc.Sections)
        {
          //Get the footer range and add the footer details.
          var footerRange =
            wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
          footerRange.Font.ColorIndex = WdColorIndex.wdDarkRed;
          footerRange.Font.Size = 10;
          footerRange.ParagraphFormat.Alignment =
            WdParagraphAlignment.wdAlignParagraphCenter;
          footerRange.Text = "Footer text goes here";
        }

        wordDoc.Content.SetRange(0, 0);
        wordDoc.Content.Text = "This is test document ";

        wordDoc.Content.SetRange(80, 80);
        wordDoc.Content.Text = "adsadsadsadsadsad " + Environment.NewLine;

        //Add paragraph with Heading 1 style
        var para1 = wordDoc.Content.Paragraphs.Add(Missing.Value);
        object styleHeading1 = "Heading 1";
        para1.Range.set_Style(ref styleHeading1);
        para1.Range.Text = "Para 1 text";
        para1.Range.InsertParagraphAfter();

        var para2 = wordDoc.Content.Paragraphs.Add(Missing.Value);
        object styleHeading2 = "Heading 2";
        para2.Range.set_Style(ref styleHeading2);
        para2.Range.Text = "Para 2 text";
        para2.Range.InsertParagraphAfter();

        var firstTable = wordDoc.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

        firstTable.Borders.Enable = 1;
        foreach (Row row in firstTable.Rows)
        {
          foreach (Cell cell in row.Cells)
          {
            //Header row
            if (cell.RowIndex == 1)
            {
              cell.Range.Text = "Column " + cell.ColumnIndex;
              cell.Range.Font.Bold = 1;
              //other format properties goes here
              cell.Range.Font.Name = "verdana";
              cell.Range.Font.Size = 10;
              //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
              cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
              //Center alignment for the Header cells
              cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
              cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            //Data row
            else
            {
              cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
            }
          }
        }


        for (int i = 1; i <= wordDoc.Bookmarks.Count; i++)
        {
          Console.WriteLine(wordDoc.Bookmarks[i].Name + Environment.NewLine);
        }
            */
        //SetBookmarkText(wordDoc, "testbookmark", "Tolebi test bookmark");


      //  var firstName1 = firstName;
      //  GetData(); 

       /* FindAndReplace(wordApp, "${firstName}", firstName1);
        FindAndReplace(wordApp, "${lastName}", lastName1);
*/
        
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

        /*if (wordDoc != null)
        {
          wordDoc.Close(ref missing, ref missing, ref missing);
          wordDoc = null;
        }
        if (wordApp != null)
        {
          wordApp.Quit(ref missing, ref missing, ref missing);
          wordApp = null;
        }*/
      }
    }
  }
}