using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using System;

/*
 Authors: Tolebi Baimenov, Nurlan Ryskeldi, Zhandos Iskakov
 */
namespace ARM_User.Reports
{
  public abstract class WordReport
  {
    protected CultureInfo appCulture;
    protected object missing = Missing.Value;
    protected Application wordApp;
    protected CultureInfo wordCulture;
    protected object varMissing = Type.Missing;
    protected Word.Table wordtable;
    protected Word.Range wordcellrange;
    protected Word.Paragraph wordparagraph;
    protected Word.Range wordrange;
    protected Document doc;
    protected void CreateWord()
    {
      wordCulture = null;

      appCulture = Thread.CurrentThread.CurrentCulture;

      wordApp = new Application();
      try
      {
        wordCulture = appCulture;
        wordApp.Visible = false;
        wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
        wordApp.WindowState = WdWindowState.wdWindowStateMaximize;
      }
      catch
      {
        if (appCulture.Name == "ru-RU")
          wordCulture = new CultureInfo("en-US");
        else
          wordCulture = new CultureInfo("ru-RU");
      }
    }

    protected void CloseWord()
    {
      if (wordApp != null)
      {
          
          wordApp.Quit(ref missing, ref missing, ref missing);
          wordApp = null;          
      }   
    }

    protected void SetBookmarkText(Document doc, string bookmarkName, string text)
    {
      doc.Bookmarks[bookmarkName].Range.Text = text;      
    }

    public bool ReplaceText(Application doc, string TfindText, string TreplaceWithText)
    {
        string zReplacement = TreplaceWithText.Replace('\n', '\r');
        // Чтобы обойти ограничение на 255 символов, делаем такой финт ушами 
        // Заменяем 230 символов и добавляем спец метку, которую заменяем на оставшиеся 
        if (zReplacement.Length > 255)
        {
            string zNewReplacement = zReplacement.Substring(0, 230) + "{{{continue_continue}}}";
            // Если ничего не нашли то дальше можно не мучаться 
            if (!ReplaceText(doc, TfindText, zNewReplacement)) return false;
            // Берем следующие 230 символов и дальше по рекурсии 
            return ReplaceText(doc,"{{{continue_continue}}}", zReplacement.Substring(230));
        }
        else
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object findText = TfindText;
            object replaceWithText = TreplaceWithText;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            return doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
    }
    protected void FindAndReplace(Application doc, string TfindText, string TreplaceWithText)
    {
      //options
        
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object findText = TfindText;
            object replaceWithText = TreplaceWithText;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        
    }

    public string SaveTemplateFile(byte[] bytes)
    {
      var directory = Path.Combine(Path.GetTempPath(), "GERCB", "Word");
      if (Directory.Exists(directory) == false)
        Directory.CreateDirectory(directory);
      var path = Path.Combine(directory, Path.GetRandomFileName() + ".dot");
      File.WriteAllBytes(path, bytes);
      return path;
    }

    protected void BeginFillReport()
    {
     // CreateWord();

      Thread.CurrentThread.CurrentCulture = wordCulture;
      wordApp.Visible = false;
      wordApp.ScreenUpdating = false;
    }

    protected void EndFillReport()
    {
      wordApp.Visible = true;
      wordApp.ScreenUpdating = true;      
      Marshal.FinalReleaseComObject(wordApp);
      wordApp = null;      
      Thread.CurrentThread.CurrentCulture = appCulture;      
    }
    protected void CreateTableWord(Document wordDoc, int rowcount, int columncount, int table,string text, Boolean firstpage, Boolean tableshift)
    {
        
        Microsoft.Office.Interop.Word.Paragraph para = wordDoc.Content.Paragraphs.Add(ref missing);
        para.Range.InsertParagraphAfter();

        Object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
        Object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;
        
        wordtable = wordDoc.Tables.Add(para.Range, rowcount, columncount, ref defaultTableBehavior, ref autoFitBehavior);        
        wordcellrange = wordDoc.Tables[table].Range;

        wordtable = wordDoc.Tables[table];        
        wordtable.ApplyStyleFirstColumn = true;
        wordtable.ApplyStyleHeadingRows = true;
        wordtable.ApplyStyleLastRow = false;
        wordtable.ApplyStyleLastColumn = false;
        wordcellrange.Borders[Word.WdBorderType.wdBorderRight].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth025pt;
        wordcellrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        /*if (newpage)
        {
            object oType;
            oType = Word.WdBreakType.wdSectionBreakNextPage;
            wordApp.Selection.InsertBreak(ref oType);
        }   */
        if (firstpage)
        {
            object begCell = wordtable.Cell(1, 1).Range.Start;
            object endCell = wordtable.Cell(1, columncount).Range.End;
            wordcellrange = wordDoc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordApp.Selection.Cells.Merge();
            wordcellrange.Text = text;
            wordcellrange.Borders.Enable = 0;
            wordcellrange.Font.Bold = 1;
            if (tableshift)
                wordcellrange.Font.Size = 9;
            else
                wordcellrange.Font.Size = 11;
            wordcellrange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
        }
    }
    public abstract void ShowReport();

  }
}