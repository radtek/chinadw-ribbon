using System;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Microsoft.Office.Interop.Excel;
using ARM_User.BusinessLayer.Guides;
using System.IO;
using ARM_User.MapperLayer.Common;

namespace ARM_User.Reports
{
  /// <summary>
  /// Для вывода отчетов в Excel.
  /// </summary>
  public abstract class ReportToExcel
  {

    public virtual string XltFileName
    {
        get
        {
            throw new NotImplementedException("Not yet implemented.");
        }
    }
    public abstract void ShowReport();


    /// <summary>
    /// Приложение Excel
    /// </summary>
    protected ApplicationClass appExcel = null;
    protected CultureInfo appCulture;
    protected CultureInfo excelCulture;
    protected Workbook wb;

      protected static string xmlDateFormatPattern = "dd.MM.yyyy";
    protected static IFormatProvider xmlNumberFormatProvider
    {
      get
      {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";
        return nfi;
      }
    }

      protected static IFormatProvider xmlDateFormatProvider
      {
          get
          {
              DateTimeFormatInfo dfi = new DateTimeFormatInfo();
              dfi.DateSeparator = "dd.MM.yyyy";
              return dfi;
          }
      }

    protected static string excelPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Excel\";

    protected static string excelError = String.Format("Ошибка вывода в Excel.{0}Возможно количество выводимых строк больше 65536", Environment.NewLine);

    //private string xmlPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Xml\";

    public virtual string GetTemplateFilePath()
    {
        throw new NotImplementedException("Not yet Implemented.");
    }

    public string SaveTemplateFile(byte[] bytes)
    {        
        string directory = Path.Combine(Path.GetTempPath(), "GERCB", "Excel");
        if (Directory.Exists(directory) == false)
        {
            Directory.CreateDirectory(directory);
        }
        string path = Path.Combine(directory, Path.GetRandomFileName() + ".xlt");
        File.WriteAllBytes(path, bytes);

        return path;
    }

    /// <summary>
    /// Создает и инициализирует обьект Excel
    /// </summary>
    protected void createExcel()
    {
      // Культура под которой следует запускать методы Excel
      excelCulture = null;

      appCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

      appExcel = new ApplicationClass();
      try
      {
        appExcel.Wait(Type.Missing);
        excelCulture = appCulture;
      }
      catch
      {
        if (appCulture.Name == "ru-RU")
          excelCulture = new CultureInfo("en-US");
        else
          excelCulture = new CultureInfo("ru-RU");
      }
    }

    protected void BeginFillReport()
    {
      createExcel();

      System.Threading.Thread.CurrentThread.CurrentCulture = excelCulture;

      appExcel.Visible = false;
      appExcel.UserControl = false;
      appExcel.ScreenUpdating = false;
      appExcel.DisplayAlerts = false;
      appExcel.EnableAnimations = false;

      //appExcel.Visible = true;
      //appExcel.UserControl = true;
      //appExcel.ScreenUpdating = true;
    }

    protected void EndFillReport()
    {
      appExcel.UserControl = true;
      appExcel.DisplayAlerts = true;
      appExcel.Visible = true;
      appExcel.ScreenUpdating = true;
      appExcel.EnableAnimations = true;

      appExcel.CutCopyMode = XlCutCopyMode.xlCopy;

      appExcel.WindowState = XlWindowState.xlMaximized;

      System.Runtime.InteropServices.Marshal.FinalReleaseComObject(appExcel);
      appExcel = null;

      System.Threading.Thread.CurrentThread.CurrentCulture = appCulture;
    }

    protected bool HasName(Workbook wb, string name)
    {
      foreach (Name xlName in wb.Names)
        if (xlName.Name == name)
          return true;
      return false;
    }

    protected static string GetAttributeString(XmlAttribute attr)
    {
      return (attr == null) ? "" : attr.Value;
    }
    protected static DateTime? GetAttributeDate(XmlAttribute attr)
    {
      string strDateTime = GetAttributeString(attr);
      if (strDateTime == "")
          return null;
      else
          return DateTime.ParseExact(strDateTime, xmlDateFormatPattern,null);
    }
    protected static decimal? GetAttributeDecimal(XmlAttribute attr)
    {
      string strDecimal = GetAttributeString(attr);
      if (strDecimal == "")
        return null;
      else
        return decimal.Parse(strDecimal, xmlNumberFormatProvider);
    }

    protected virtual object ConvertToExcelValue(string excelRangeName, object obj)
    {
        return ConvertToExcelValue(obj);
    }

    protected object ConvertToExcelValue(object obj)
    {
      if (obj == null)
        return null;
      if (obj is string ||
          obj is decimal ||
          obj is int ||
          obj is double)
        return obj;

      if (obj is DateTime)
        if ((DateTime)obj >= new DateTime(1900, 1, 1))
          return ((DateTime)obj);
        else
          return ((DateTime)obj).ToString();

      if (obj is DateTime?)
      {
        if (((DateTime?)obj).HasValue)
          if (((DateTime?)obj).Value >= new DateTime(1900, 1, 1))
            return ((DateTime?)obj).Value;
          else
            return ((DateTime?)obj).Value.ToString();
        else
          return null;
      }
      else if (obj is decimal?)
      {
        if (((decimal?)obj).HasValue)
          return ((decimal?)obj).Value;
        else
          return null;
      }
      return obj.ToString();
    }

    //protected int createReportPartWithColsFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix)
    //{
    //  int nonFixedColCount = 0;
    //  bool hasStrNum = HasName(wb, prefix + "str_num");
    //  bool hasStrCode = HasName(wb, prefix + "str_code");
    //  bool hasStrName = HasName(wb, prefix + "str_name");
    //  bool hasColCode = HasName(wb, prefix + "col_code");
    //  bool hasColName = HasName(wb, prefix + "col_name");

    //  if (ReportPartNode != null)
    //  {
    //    Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;

    //    XmlNodeList colNodeList = ReportPartNode.SelectNodes("COLS/COL");

    //    int allColCount = colNodeList.Count;
    //    bool[] colFixed = new bool[allColCount];
    //    string[] colType = new string[allColCount];
    //    bool firstCol = true;
    //    for (int i = 0; i < allColCount; i++)
    //    {
    //      XmlNode colNode = colNodeList.Item(i);
    //      colFixed[i] = (GetAttributeString(colNode.Attributes["FIXED"]) == "1");
    //      colType[i] = GetAttributeString(colNode.Attributes["COL_TYPE"]);

    //      if (!colFixed[i])
    //      {
    //        Range rngLastCol = rngData.Columns[rngData.Columns.Count, Type.Missing] as Range;

    //        if (!firstCol)
    //        {
    //          rngLastCol.Copy(Type.Missing);
    //          rngLastCol.Insert(XlInsertShiftDirection.xlShiftToRight);
    //        }

    //        if (hasColName)
    //          ws.get_Range(prefix + "col_name", Type.Missing).Value2 = GetAttributeString(colNode.Attributes["NAME"]);
    //        if (hasColCode)
    //          ws.get_Range(prefix + "col_code", Type.Missing).Value2 = GetAttributeString(colNode.Attributes["CODE"]);

    //        firstCol = false;
    //        nonFixedColCount++;
    //      }
    //    }

    //    XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
    //    for (int i = 0; i < strNodeList.Count; i++)
    //    {
    //      XmlNode strNode = strNodeList.Item(i);
    //      Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

    //      if (i != 0)
    //      {
    //        rngDataRow.EntireRow.Copy(Type.Missing);
    //        rngDataRow.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown);
    //      }

    //      if (hasStrNum)
    //        ws.get_Range(prefix + "str_num", Type.Missing).Value2 = i + 1;
    //      if (hasStrName)
    //        ws.get_Range(prefix + "str_name", Type.Missing).Value2 = GetAttributeString(strNode.Attributes["NAME"]);
    //      if (hasStrCode)
    //        ws.get_Range(prefix + "str_code", Type.Missing).Value2 = GetAttributeString(strNode.Attributes["CODE"]);


    //      XmlNodeList valNodeList = strNode.SelectNodes("VALS/VAL");
    //      for (int j = 0; j < valNodeList.Count; j++)
    //      {
    //        XmlNode valNode = valNodeList[j];
    //        Range rngValue;
    //        if (colFixed[j])
    //        {
    //          string colName = prefix + "col_" + (j + 1);
    //          rngValue = ws.get_Range(colName, Type.Missing);
    //        }
    //        else
    //        {
    //          rngValue = rngDataRow.Columns[rngDataRow.Columns.Columns.Count - valNodeList.Count + j + 1, Type.Missing] as Range;
    //        }
    //        if (colType[j] == "NUMBER")
    //          rngValue.Value2 = GetAttributeDecimal(valNode.Attributes["VAL"]);
    //        else if (colType[j] == "DATE")
    //          rngValue.Value2 = ConvertToExcelValue(GetAttributeDate(valNode.Attributes["VAL"]));
    //        else if (colType[j] == "VARCHAR2")
    //          rngValue.Value2 = GetAttributeString(valNode.Attributes["VAL"]);
    //        else
    //          rngValue.Value2 = GetAttributeString(valNode.Attributes["VAL"]);
    //      }
    //    }
    //  }
    //  return nonFixedColCount;
    //}

    protected int createReportPartWithColsFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix)
    {
      return createReportPartWithColsFast(ReportPartNode, wb, ws, prefix, true);
    }
    protected int createReportPartWithColsFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, bool insertRows)
    {
      try
      {
        int nonFixedColCount = 0;

        if (ReportPartNode != null)
        {
          appExcel.Visible = true;

          bool hasStrNum = HasName(wb, prefix + "str_num");
          bool hasStrCode = HasName(wb, prefix + "str_code");
          bool hasStrName = HasName(wb, prefix + "str_name");
          bool hasColCode = HasName(wb, prefix + "col_code");
          bool hasColName = HasName(wb, prefix + "col_name");

          Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
          Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

          XmlNodeList colNodeList = ReportPartNode.SelectNodes("COLS/COL");
          XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");

          int allColCount = colNodeList.Count;
          int allStrCount = strNodeList.Count;

          XmlExcelProperty excelPropertyStrNum = new XmlExcelProperty();
          XmlExcelProperty excelPropertyStrCode = new XmlExcelProperty();
          XmlExcelProperty excelPropertyStrName = new XmlExcelProperty();

          if (hasStrNum)
          {
            excelPropertyStrNum.excelRangeName = prefix + "str_num";
            excelPropertyStrNum.xmlType = XmlExcelProperty.XmlType.xmlDecimal;
            excelPropertyStrNum.values = new object[allStrCount, 1];
          }
          if (hasStrCode)
          {
            excelPropertyStrCode.excelRangeName = prefix + "str_code";
            excelPropertyStrCode.xmlType = XmlExcelProperty.XmlType.xmlString;
            excelPropertyStrCode.values = new object[allStrCount, 1];
            excelPropertyStrCode.xmlAttributeName = "CODE";
          }
          if (hasStrName)
          {
            excelPropertyStrName.excelRangeName = prefix + "str_name";
            excelPropertyStrName.xmlType = XmlExcelProperty.XmlType.xmlString;
            excelPropertyStrName.values = new object[allStrCount, 1];
            excelPropertyStrName.xmlAttributeName = "NAME";
          }

          List<Int32> notUsedFixedColList = new List<Int32>();
          List<XmlExcelProperty> excelPropertyList = new List<XmlExcelProperty>();

          bool firstCol = true;
          for (int i = 0; i < allColCount; i++)
          {
            XmlNode colNode = colNodeList.Item(i);

            bool colFixed = (GetAttributeString(colNode.Attributes["FIXED"]) == "1");
            if (colFixed)
            {
                bool hasFixedCol = HasName(wb, prefix + "col_" + (i + 1));
                if (hasFixedCol == false)
                {
                    notUsedFixedColList.Add(i);
                    continue;
                }
            }

            XmlExcelProperty excelProperty = new XmlExcelProperty();

            excelProperty.xmlAttributeName = "VAL";
            excelProperty.values = new object[allStrCount, 1];

            string colType = GetAttributeString(colNode.Attributes["COL_TYPE"]);

            if (colType == "NUMBER")
              excelProperty.xmlType = XmlExcelProperty.XmlType.xmlDecimal;
            else if (colType == "DATE")
              excelProperty.xmlType = XmlExcelProperty.XmlType.xmlDate;
            else if (colType == "VARCHAR2")
              excelProperty.xmlType = XmlExcelProperty.XmlType.xmlString;
            else
              excelProperty.xmlType = XmlExcelProperty.XmlType.xmlString;

            if (colFixed)
            {
              excelProperty.excelRangeName = prefix + "col_" + (i + 1);
            }
            else
            {
              Range rngLastCol = rngData.Columns[rngData.Columns.Count, Type.Missing] as Range;

              if (!firstCol)
              {
                rngLastCol.Copy(Type.Missing);
                rngLastCol.Insert(XlInsertShiftDirection.xlShiftToRight, null);
              }

              if (hasColName)
              {
                  ws.get_Range(prefix + "col_name", Type.Missing).Value2 = GetAttributeString(colNode.Attributes["NAME"]);
              }
              else
              {
                  XmlNodeList colNameNodeList = colNode.SelectNodes("COL_NAMES/COL_NAME");

                  int allColNameCount = colNameNodeList.Count;
                  if (allColNameCount > 0)
                  {
                      for (int j = 0; j < allColNameCount; j++)
                      {
                          XmlNode colNameNode = colNameNodeList.Item(j);
                          ws.get_Range(prefix + "col_name_" + (j + 1), Type.Missing).Value2 = GetAttributeString(colNameNode.Attributes["NAME"]);
                      }
                  }
              }
              if (hasColCode)
                ws.get_Range(prefix + "col_code", Type.Missing).Value2 = GetAttributeString(colNode.Attributes["CODE"]);

              firstCol = false;
              nonFixedColCount++;

              excelProperty.excelRangeName = (rngLastCol.Rows[rngLastCol.Rows.Count, Type.Missing] as Range).get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
            }
            excelPropertyList.Add(excelProperty);
          }

          for (int k = 0; k < allStrCount; k++)
          {
            XmlNode strNode = strNodeList.Item(k);

            if (hasStrNum)
              excelPropertyStrNum.values[k, 0] = k + 1;
            if (hasStrCode)
              excelPropertyStrCode.values[k, 0] = ConvertToExcelValue(excelPropertyStrCode.GetValue(strNode));
            if (hasStrName)
              excelPropertyStrName.values[k, 0] = ConvertToExcelValue(excelPropertyStrName.GetValue(strNode));

            int index = 0;
            XmlNodeList valNodeList = strNode.SelectNodes("VALS/VAL");
            for (int j = 0; j < valNodeList.Count; j++)
            {
                if (notUsedFixedColList.Contains(j) == false)
                {
                    XmlNode valNode = valNodeList[j];
                    excelPropertyList[index].values[k, 0] = ConvertToExcelValue(excelPropertyList[index].GetValue(valNode));
                    index++;
                }
            }
          }

          if (insertRows)
          {
            Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
            for (int r = 0; r < allStrCount - 1; r++)
              rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown, null);
          }

          if (strNodeList.Count > 1)
            rngDataRow.get_Resize(allStrCount, Type.Missing).FillDown();

          List<XmlExcelProperty> arr = new List<XmlExcelProperty>(excelPropertyList);
          if (hasStrNum)
            arr.Add(excelPropertyStrNum);
          if (hasStrCode)
            arr.Add(excelPropertyStrCode);
          if (hasStrName)
            arr.Add(excelPropertyStrName);

          foreach (XmlExcelProperty oneExcelProperty in arr)
          {
            Range objRange = ws.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
            if (allStrCount > 1)
              objRange = objRange.get_Resize(allStrCount, 1);
            objRange.Value2 = oneExcelProperty.values;
          }
        }
        return nonFixedColCount;
      }
      catch (COMException ex)
      {
        if (ex.ErrorCode == -2146827284)
          throw new ApplicationException(excelError);
        else
          throw;
      }
    }

    protected void createReportPartFromXmlFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix)
    {
      createReportPartFromXmlFast(ReportPartNode, wb, ws, prefix, false, null);
    }
    protected void createReportPartFromXmlFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, bool insertRows)
    {
      createReportPartFromXmlFast(ReportPartNode, wb, ws, prefix, insertRows, null);
    }
    protected void createReportPartFromXmlFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, bool insertRows, XmlExcelProperty[] xmlExcelPropertyList)
    {
        int countStrNodeList = 0;
        int countData = 0;
      try
      {
        if (ReportPartNode != null)
        {
          XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
          if (strNodeList.Count > 0)
          {
              countStrNodeList = strNodeList.Count;  
            appExcel.Visible = true;
            Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
            Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

            countData = rngData.Rows.Count;

            List<XmlExcelProperty> arr;

            if (xmlExcelPropertyList == null)
            {
              arr = new List<XmlExcelProperty>();

              for (int i = 1; i <= wb.Names.Count; i++)
              {
                Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
                if (xlName.Name.StartsWith(prefix) && xlName.Name.Substring(prefix.Length) != "data")
                {
                  string xmlAttributeName = xlName.Name.Substring(prefix.Length);
                  object[,] listValues = new object[strNodeList.Count, 1];
                  arr.Add(new XmlExcelProperty(xlName.Name, xmlAttributeName, listValues));
                }
              }
            }
            else
            {
              arr = new List<XmlExcelProperty>(xmlExcelPropertyList);
              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                oneExcelProperty.excelRangeName = prefix + oneExcelProperty.xmlAttributeName;
                oneExcelProperty.values = new object[strNodeList.Count, 1];
              }
            }

            for (int k = 0; k < strNodeList.Count; k++)
            {
              XmlNode strNode = strNodeList.Item(k);
              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                oneExcelProperty.values[k, 0] = ConvertToExcelValue(oneExcelProperty.GetValue(strNode));
              }
            }

            if (insertRows)
            {
              Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
              for (int r = 0; r < strNodeList.Count - 1; r++)
                rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown, null);
            }

            if (strNodeList.Count > 1)
              rngDataRow.get_Resize(strNodeList.Count, Type.Missing).FillDown();

            foreach (XmlExcelProperty oneExcelProperty in arr)
            {
              Range objRange = ws.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
              if (strNodeList.Count > 1)
                objRange = objRange.get_Resize(strNodeList.Count, 1);
              objRange.Value2 = oneExcelProperty.values;
            }
          }
        }
      }
      catch (COMException ex)
      {
        if (ex.ErrorCode == -2146827284)
            throw new ApplicationException(excelError + "\r\n" + "( " + ex.StackTrace + ")" + "\r\n" + ws.Name + "\r\n" + prefix + "data" + "\r\n" + "StrNodeList := " + countStrNodeList.ToString() + "\r\n" + "rngData.Rows.Count := " + countData.ToString());
        else
          throw;
      }
    }

    protected void createReportPartFromXmlFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, bool insertRows, XmlExcelProperty[] xmlExcelPropertyList, string rangename)
    {
        int countStrNodeList = 0;
        int countData = 0;
        try
        {
            if (ReportPartNode != null)
            {
                XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
                if (strNodeList.Count > 0)
                {
                    countStrNodeList = strNodeList.Count;
                    appExcel.Visible = true;
                    Range rngData = ws.get_Range(prefix + rangename, Type.Missing) as Range;
                    Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                    countData = rngData.Rows.Count;

                    List<XmlExcelProperty> arr;

                    if (xmlExcelPropertyList == null)
                    {
                        arr = new List<XmlExcelProperty>();

                        for (int i = 1; i <= wb.Names.Count; i++)
                        {
                            Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
                            if (xlName.Name.StartsWith(prefix) && xlName.Name.Substring(prefix.Length) != rangename)
                            {
                                string xmlAttributeName = xlName.Name.Substring(prefix.Length);
                                object[,] listValues = new object[strNodeList.Count, 1];
                                arr.Add(new XmlExcelProperty(xlName.Name, xmlAttributeName, listValues));
                            }
                        }
                    }
                    else
                    {
                        arr = new List<XmlExcelProperty>(xmlExcelPropertyList);
                        foreach (XmlExcelProperty oneExcelProperty in arr)
                        {
                            oneExcelProperty.excelRangeName = prefix + oneExcelProperty.xmlAttributeName;
                            oneExcelProperty.values = new object[strNodeList.Count, 1];
                        }
                    }

                    for (int k = 0; k < strNodeList.Count; k++)
                    {
                        XmlNode strNode = strNodeList.Item(k);
                        foreach (XmlExcelProperty oneExcelProperty in arr)
                        {
                            oneExcelProperty.values[k, 0] = ConvertToExcelValue(oneExcelProperty.GetValue(strNode));
                        }
                    }

                    if (insertRows)
                    {
                        Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
                        for (int r = 0; r < strNodeList.Count - 1; r++)
                            rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown, null);
                    }

                    if (strNodeList.Count > 1)
                        rngDataRow.get_Resize(strNodeList.Count, Type.Missing).FillDown();

                    foreach (XmlExcelProperty oneExcelProperty in arr)
                    {
                        Range objRange = ws.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
                        if (strNodeList.Count > 1)
                            objRange = objRange.get_Resize(strNodeList.Count, 1);
                        objRange.Value2 = oneExcelProperty.values;
                    }
                }
            }
        }
        catch (COMException ex)
        {
            if (ex.ErrorCode == -2146827284)
                throw new ApplicationException(excelError + "\r\n" + "( " + ex.StackTrace + ")" + "\r\n" + ws.Name + "\r\n" + prefix + "data" + "\r\n" + "StrNodeList := " + countStrNodeList.ToString() + "\r\n" + "rngData.Rows.Count := " + countData.ToString());
            else
                throw;
        }
    }

    protected void createReportPartFromXmlByColsFast(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, bool insertCols, XmlExcelProperty[] xmlExcelPropertyList)
    {
      try
      {
        if (ReportPartNode != null)
        {
          XmlNodeList colsNodeList = ReportPartNode.SelectNodes("COLS/COL");
          if (colsNodeList.Count > 0)
          {
            appExcel.Visible = true;
            Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;

            Range rngDataCols = rngData.Columns[rngData.Columns.Count, Type.Missing] as Range;

            List<XmlExcelProperty> arr;

            arr = new List<XmlExcelProperty>(xmlExcelPropertyList);
            foreach (XmlExcelProperty oneExcelProperty in arr)
            {
              oneExcelProperty.excelRangeName = prefix + oneExcelProperty.xmlAttributeName;
              oneExcelProperty.values = new object[1, colsNodeList.Count];
            }

            for (int k = 0; k < colsNodeList.Count; k++)
            {
              XmlNode colNode = colsNodeList.Item(k);
              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                oneExcelProperty.values[0, k] = ConvertToExcelValue(oneExcelProperty.GetValue(colNode));
              }
            }

            if (insertCols)
            {
              Range rngBelowDataCols = ws.Columns[rngDataCols.Column + 1, Type.Missing] as Range;
              for (int r = 0; r < colsNodeList.Count - 1; r++)
                rngBelowDataCols.Insert(XlInsertShiftDirection.xlShiftDown, null);
            }

            if (colsNodeList.Count > 1)
              rngDataCols.get_Resize(colsNodeList.Count, Type.Missing).FillDown();

            foreach (XmlExcelProperty oneExcelProperty in arr)
            {
              Range objRange = ws.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
              if (colsNodeList.Count > 1)
                objRange = objRange.get_Resize(1, colsNodeList.Count);
              objRange.Value2 = oneExcelProperty.values;
            }
          }
        }
      }
      catch (COMException ex)
      {
        if (ex.ErrorCode == -2146827284)
          throw new ApplicationException(excelError);
        else
          throw;
      }
    }

    protected void createReportPartFromXmlFastEx(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix)
    {
      if (ReportPartNode != null)
      {
        XmlNodeList colNodeList = ReportPartNode.SelectNodes("COLS/COL");
        XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
        if (strNodeList.Count > 0)
        {
          appExcel.Visible = true;
          Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
          Range rngDataRow = rngData.EntireRow;
          Range rndColCode = ws.get_Range(ws.Cells[rngData.Row - 1, rngData.Column], ws.Cells[rngData.Row - 1, rngData.Column]);
          List<int> arrXmlCols = new List<int>();

          do
          {
            string xlCodeColValue = rndColCode.Value2.ToString();
            IEnumerator en = colNodeList.GetEnumerator();
            int indRow = 0;
            arrXmlCols.Add(-1);
            while (en.MoveNext())
            {
              XmlNode colNode = (XmlNode)en.Current;

              if (GetAttributeString(colNode.Attributes["CODE"]) == xlCodeColValue)
              {
                arrXmlCols[arrXmlCols.Count - 1] = indRow;
                break;
              }
              indRow++;
            }
            rndColCode = ws.get_Range(ws.Cells[rndColCode.Row, rndColCode.Column + 1], ws.Cells[rndColCode.Row, rndColCode.Column + 1]);
          }
          while (rndColCode.Value2 != null);

          object[,] arrayValue = new object[strNodeList.Count, arrXmlCols.Count];
          object[,] arrayCodeRows = new object[strNodeList.Count, 1];
          object[,] arrayNameRows = new object[strNodeList.Count, 1];

          for (int i = 0; i < strNodeList.Count; i++)
          {
            XmlNode rowNode = strNodeList[i];
            arrayCodeRows[i, 0] = GetAttributeString(rowNode.Attributes["CODE"]);
            arrayNameRows[i, 0] = GetAttributeString(rowNode.Attributes["NAME"]);
            XmlNodeList valNodeList = rowNode.SelectNodes("VALS/VAL");
            for (int j = 0; j < arrXmlCols.Count; j++)
            {
              if (arrXmlCols[j] != -1)
              {
                arrayValue[i, j] = GetAttributeDecimal(valNodeList[arrXmlCols[j]].Attributes["VAL"]);
              }
            }
          }

          if (strNodeList.Count > 1)
            rngDataRow.get_Resize(strNodeList.Count, Type.Missing).FillDown();

          Range rngDataRated = rngData.get_Resize(strNodeList.Count, arrXmlCols.Count);
          rngDataRated.Value2 = arrayValue;

          Range rndCodeRows = ws.get_Range(ws.Cells[rngData.Row, rngData.Column - 2], ws.Cells[rngData.Row, rngData.Column - 2]);
          Range rndCodeRowsRated = rndCodeRows.get_Resize(strNodeList.Count, 1);
          rndCodeRowsRated.Value2 = arrayCodeRows;

          Range rndNameRows = ws.get_Range(ws.Cells[rngData.Row, rngData.Column - 1], ws.Cells[rngData.Row, rngData.Column - 1]);
          Range rndNameRowsRated = rndNameRows.get_Resize(strNodeList.Count, 1);
          rndNameRowsRated.Value2 = arrayNameRows;
        }
      }
    }

    protected void createReportPartFromListFast<T>(ICollection<T> list, Workbook wb, Worksheet ws, string prefix)
    {
      createReportPartFromListFast<T>(list, wb, ws, prefix, false);
    }
    protected void createReportPartFromListFast<T>(ICollection<T> list, Workbook wb, Worksheet ws, string prefix, bool insertRows)
    {
      try
      {
        if (list != null && list.Count > 0)
        {

          /*decimal listCount = list.Count;
          if (listCount > 60000)
            listCount = 60000;
          */


          //wb.Worksheets.Add(ws1, ws1, 1, Type.Missing);

          appExcel.Visible = true;
          Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
          Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;
          Regex regex = new Regex("[\\.]");

          List<ObjectExcelProperty> arr = new List<ObjectExcelProperty>();

          for (int i = 1; i <= wb.Names.Count; i++)
          {
            Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
            if (xlName.Name.StartsWith(prefix) && xlName.Name.Substring(prefix.Length) != "data")
            {
              string[] propertiesName = regex.Split(xlName.Name.Substring(prefix.Length));

              PropertyInfo[] piArray = new PropertyInfo[propertiesName.Length];
              bool goodPath = true;
              Type currentType = typeof(T);
              for (int j = 0; j < propertiesName.Length; j++)
              {
                string propertyName = propertiesName[j];
                PropertyInfo pi = currentType.GetProperty(propertyName);
                if (pi != null && pi.CanRead)
                {
                  piArray[j] = pi;
                  currentType = pi.PropertyType;
                }
                else
                {
                  goodPath = false;
                  break;
                }
              }
              if (goodPath)
              {
                object[,] listValues = new object[list.Count, 1];
                arr.Add(new ObjectExcelProperty(xlName.Name, piArray, listValues));
              }
            }
          }

          int k = 0;
          foreach (T element in list)
          {
            foreach (ObjectExcelProperty oneExcelProperty in arr)
            {
              oneExcelProperty.values[k, 0] = ConvertToExcelValue(oneExcelProperty.excelRangeName, oneExcelProperty.GetValue(element));
            }
            k++;
          }

          if (insertRows)
          {
            Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
            for (int r = 0; r < list.Count - 1; r++)
              rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown, null);
          }

          if (list.Count > 1)
            rngDataRow.get_Resize(list.Count, Type.Missing).FillDown();

          foreach (ObjectExcelProperty oneExcelProperty in arr)
          {
            Range objRange = ws.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
            if (list.Count > 1)
              objRange = objRange.get_Resize(list.Count, 1);
            objRange.Value2 = oneExcelProperty.values;
          }
        }
      }
      catch (COMException ex)
      {
        if (ex.ErrorCode == -2146827284)
          throw new ApplicationException(excelError);
        else
          throw;
      }
    }

    //protected void createBigReportPartFromListFast<T>(ICollection<T> list, Workbook wb, Worksheet ws, string prefix, bool insertRows)
    //{
    //  createReportPartFromListFast(list, wb, ws, "", true);
    //}

    public class ExcelProperty
    {
      public string excelRangeName;
      public object[,] values;
      public ExcelProperty()
      { }
      public ExcelProperty(string excelRangeName, object[,] values)
      {
        this.excelRangeName = excelRangeName;
        this.values = values;
      }
    }

    public class XmlExcelProperty : ExcelProperty
    {
      public enum XmlType { xmlString, xmlDate, xmlDecimal };

      public XmlType xmlType;
      public string xmlAttributeName;

      public XmlExcelProperty()
        : base()
      { }

      public XmlExcelProperty(string xmlAttributeName, XmlType xmlType)
        : base(null, null)
      {
        this.xmlAttributeName = xmlAttributeName;
        this.xmlType = xmlType;
      }

      public XmlExcelProperty(string excelRangeName, string xmlAttributeName, XmlType xmlType, object[,] values)
        : base(excelRangeName, values)
      {
        this.xmlAttributeName = xmlAttributeName;
        this.xmlType = xmlType;
      }

      public XmlExcelProperty(string excelRangeName, string xmlAttributeName, object[,] values)
        : this(excelRangeName, xmlAttributeName, XmlType.xmlString, values)
      { }

      public XmlExcelProperty(string excelRangeName, string xmlAttributeName)
        : this(excelRangeName, xmlAttributeName, XmlType.xmlString, null)
      { }

      public object GetValue(XmlNode node)
      {
        if (xmlType == XmlType.xmlString)
          return GetAttributeString(node.Attributes[xmlAttributeName]);
        else if (xmlType == XmlType.xmlDate)
          return GetAttributeDate(node.Attributes[xmlAttributeName]);
        else if (xmlType == XmlType.xmlDecimal)
          return GetAttributeDecimal(node.Attributes[xmlAttributeName]);
        else
          return null;
      }
    }

    public class ObjectExcelProperty : ExcelProperty
    {
      public PropertyInfo[] piArray;

      public ObjectExcelProperty(string excelRangeName, PropertyInfo[] piArray, object[,] values)
        : base(excelRangeName, values)
      {
        this.piArray = piArray;
      }

      public object GetValue(object obj)
      {
        object currentVal = obj;
        foreach (PropertyInfo pi in piArray)
        {
          if (currentVal != null)
            currentVal = pi.GetValue(currentVal, null);
          else
            break;
        }
        return currentVal;
      }
    }

    //protected void createReportPartFromList<T>(ICollection<T> list, Workbook wb, Worksheet ws, string prefix)
    //{
    //  if (list != null)
    //  {
    //    Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;

    //    bool firstRow = true;
    //    foreach (T element in list)
    //    {
    //      Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

    //      if (!firstRow)
    //      {
    //        rngDataRow.EntireRow.Copy(Type.Missing);
    //        rngDataRow.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown);
    //      }
    //      firstRow = false;

    //      for (int i = 1; i <= wb.Names.Count; i++)
    //      {
    //        Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
    //        if (xlName.Name.StartsWith(prefix))
    //        {
    //          string propertyName = xlName.Name.Substring(prefix.Length);
    //          PropertyInfo pi = element.GetType().GetProperty(propertyName);
    //          if (pi != null && pi.CanRead)
    //          {
    //            object o = pi.GetValue(element, null);
    //            ws.get_Range(xlName.Name, Type.Missing).Value2 = o.ToString();
    //          }
    //        }
    //      }
    //    }
    //  }
    //}

    protected void createReportPartFromXmlFastWithTransition(XmlNode ReportPartNode, Workbook wb, Worksheet ws, string prefix, /*bool insertRows,*/ XmlExcelProperty[] xmlExcelPropertyList)
    {
      try
      {
        if (ReportPartNode != null)
        {
          XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
          if (strNodeList.Count > 0)
          {
            appExcel.Visible = true;

            List<XmlExcelProperty> arr;

            if (xmlExcelPropertyList == null)
            {
              arr = new List<XmlExcelProperty>();

              for (int i = 1; i <= wb.Names.Count; i++)
              {
                Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
                if (xlName.Name.StartsWith(prefix) && xlName.Name.Substring(prefix.Length) != "data")
                {
                  string xmlAttributeName = xlName.Name.Substring(prefix.Length);
                  arr.Add(new XmlExcelProperty(xlName.Name, xmlAttributeName));
                }
              }
            }
            else
            {
              arr = new List<XmlExcelProperty>(xmlExcelPropertyList);
              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                oneExcelProperty.excelRangeName = prefix + oneExcelProperty.xmlAttributeName;
              }
            }

            //if (insertRows)
            //{
            //  Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
            //  for (int r = 0; r < strNodeList.Count - 1; r++)
            //    rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown);
            //}

            Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
            Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

            int maxRows = 65536;
            int rowsInSheet = maxRows - rngDataRow.Row + 1;
            int sheetsCount = (strNodeList.Count + rowsInSheet - 1) / rowsInSheet;

            Worksheet wsc = ws;

            for (int sheetNum = 1; sheetNum < sheetsCount; sheetNum++)
            {
              ws.Copy(Type.Missing, wsc);
              wsc = wsc.Next as Worksheet;
            }

            for (int sheetNum = 0, strNum = 0; sheetNum < sheetsCount; sheetNum++, strNum += rowsInSheet)
            {
              int strCount = Math.Min(rowsInSheet, strNodeList.Count - strNum);

              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                oneExcelProperty.values = new object[strCount, 1];
              }

              for (int k = 0; k < strCount; k++)
              {
                XmlNode strNode = strNodeList.Item(strNum + k);
                foreach (XmlExcelProperty oneExcelProperty in arr)
                {
                  oneExcelProperty.values[k, 0] = ConvertToExcelValue(oneExcelProperty.GetValue(strNode));
                }
              }

              wsc = wb.Worksheets[ws.Index + sheetNum] as Worksheet;
              rngData = wsc.get_Range(prefix + "data", Type.Missing) as Range;
              rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

              if (strCount > 1)
                rngDataRow.get_Resize(strCount, Type.Missing).FillDown();

              foreach (XmlExcelProperty oneExcelProperty in arr)
              {
                Range objRange = wsc.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
                if (strCount > 1)
                  objRange = objRange.get_Resize(strCount, 1);
                objRange.Value2 = oneExcelProperty.values;
              }
            }
          }
        }
      }
      catch (COMException ex)
      {
        if (ex.ErrorCode == -2146827284)
          throw new ApplicationException(excelError);
        else
          throw;
      }
    }

      protected void createReportPartFromXmlFastWithTransition(XmlNode ReportPartNode, XmlNode ReportPartNode1, Workbook wb, Worksheet ws, string prefix, /*bool insertRows,*/ XmlExcelProperty[] xmlExcelPropertyList)
      {
          try
          {
              if (ReportPartNode != null)
              {

                  XmlNodeList strNodeList = ReportPartNode.SelectNodes("STRS/STR");
                  XmlNodeList strNodeList1 = ReportPartNode1.SelectNodes("STRS/STR");
                  ArrayList arrListAll = new ArrayList();

                  int countNodeList = strNodeList.Count;

                  for (int i = 0; i <= countNodeList - 1; i++)
                  {
                      XmlNode xmlNode  =  strNodeList[i];
                      XmlNode xmlNode1 =  strNodeList1[i];
                      int countNodeList1 = xmlNode1.Attributes.Count;
                      for (int k = 0; k <= countNodeList1 - 1; k++)
                      {
                        XmlAttribute a = xmlNode1.Attributes[k];
                        xmlNode.Attributes.Append(a);
                      }
                      arrListAll.Add(xmlNode);
                  }


                  if ((strNodeList.Count > 0) && (strNodeList1.Count > 0))
                  {
                      appExcel.Visible = true;

                      List<XmlExcelProperty> arr;

                      if ((xmlExcelPropertyList == null))
                      {
                          arr = new List<XmlExcelProperty>();

                          for (int i = 1; i <= wb.Names.Count; i++)
                          {
                              Name xlName = wb.Names.Item(i, Type.Missing, Type.Missing);
                              if (xlName.Name.StartsWith(prefix) && xlName.Name.Substring(prefix.Length) != "data")
                              {
                                  string xmlAttributeName = xlName.Name.Substring(prefix.Length);
                                  arr.Add(new XmlExcelProperty(xlName.Name, xmlAttributeName));
                              }
                          }
                      }
                      else
                      {
                          //xmlExcelPropertyList = xmlExcelPropertyList + xmlExcelPropertyList1;

                          arr = new List<XmlExcelProperty>(xmlExcelPropertyList);
                          foreach (XmlExcelProperty oneExcelProperty in arr)
                          {
                              oneExcelProperty.excelRangeName = prefix + oneExcelProperty.xmlAttributeName;
                          }
                      }

                      //if (insertRows)
                      //{
                      //  Range rngBelowDataRow = ws.Rows[rngDataRow.Row + 1, Type.Missing] as Range;
                      //  for (int r = 0; r < strNodeList.Count - 1; r++)
                      //    rngBelowDataRow.Insert(XlInsertShiftDirection.xlShiftDown);
                      //}

                      Range rngData = ws.get_Range(prefix + "data", Type.Missing) as Range;
                      Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                      int maxRows = 65536;
                      int rowsInSheet = maxRows - rngDataRow.Row + 1;
                      int sheetsCount = (strNodeList.Count + rowsInSheet - 1) / rowsInSheet;

                      Worksheet wsc = ws;

                      for (int sheetNum = 1; sheetNum < sheetsCount; sheetNum++)
                      {
                          ws.Copy(Type.Missing, wsc);
                          wsc = wsc.Next as Worksheet;
                      }

                      for (int sheetNum = 0, strNum = 0; sheetNum < sheetsCount; sheetNum++, strNum += rowsInSheet)
                      {
                          int strCount = Math.Min(rowsInSheet, strNodeList.Count - strNum);

                          foreach (XmlExcelProperty oneExcelProperty in arr)
                          {
                              oneExcelProperty.values = new object[strCount, 1];
                          }

                          for (int k = 0; k < strCount; k++)
                          {
                              XmlNode strNode = (XmlNode)arrListAll[strNum + k]; //strNodeList.Item(strNum + k);
                              foreach (XmlExcelProperty oneExcelProperty in arr)
                              {
                                  oneExcelProperty.values[k, 0] = ConvertToExcelValue(oneExcelProperty.GetValue(strNode));
                              }
                          }

                          wsc = wb.Worksheets[ws.Index + sheetNum] as Worksheet;
                          rngData = wsc.get_Range(prefix + "data", Type.Missing) as Range;
                          rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                          if (strCount > 1)
                              rngDataRow.get_Resize(strCount, Type.Missing).FillDown();

                          foreach (XmlExcelProperty oneExcelProperty in arr)
                          {
                              Range objRange = wsc.get_Range(oneExcelProperty.excelRangeName, Type.Missing);
                              if (strCount > 1)
                                  objRange = objRange.get_Resize(strCount, 1);
                              objRange.Value2 = oneExcelProperty.values;
                          }
                      }
                  }
              }
          }
          catch (COMException ex)
          {
              if (ex.ErrorCode == -2146827284)
                  throw new ApplicationException(excelError);
              else
                  throw;
          }
      }

      protected XmlNode createXml(XmlDocument doc, System.Data.DataTable dt, string nameElement)
      {
          try
          {
            XmlNode xmlCredit = doc.CreateElement(nameElement);
            XmlNode xmlStrs = doc.CreateElement("STRS");
            foreach (DataRow row in dt.Rows)
            {
              XmlNode xmlStr = doc.CreateElement("STR");
              xmlStrs.AppendChild(xmlStr); 
              foreach (DataColumn col in dt.Columns)
              {
                xmlStr.Attributes.Append(doc.CreateAttribute(col.ColumnName));
                object obj = ConvertToExcelValue(row[col.ColumnName]);
                xmlStr.Attributes[col.ColumnName].Value = obj.ToString();
              }
            }
            xmlCredit.AppendChild(xmlStrs);
            return xmlCredit;   
          }
          catch (COMException ex)
          {
              if (ex.ErrorCode == -2146827284)
                  throw new ApplicationException(excelError);
              else
                  throw;
          }
      }

  /*    public class XmlFromTable
      {
          private XmlDocument xmlDoc;
          private System.Data.DataTable dt;
          private System.Data.DataTable dtTitle;

          public System.Data.DataTable DatTab
          {
              get { return dt;  }
              set { dt = value; }
          }

          public System.Data.DataTable DatTabTitle
          {
              get { return dtTitle; }
              set { dtTitle = value; }
          }

          public XmlDocument XmlDocum
          {
              get { return xmlDoc; }
          }
          
          public XmlFromTable()
          {
              xmlDoc = new XmlDocument();
              dt = new System.Data.DataTable();
              dtTitle = new System.Data.DataTable();
          }


          public XmlNode XmlAddElement(string nameElement)
          {
              return xmlDoc.CreateElement(nameElement);
          }

          public XmlNode XmlAddChild(XmlNode xmlNodeParent, XmlNode child)
          {
              xmlNodeParent.AppendChild(child);
              return xmlNodeParent;
          }

          public XmlNode ConvertToXmlFromDataTable(string nameElement)
          {
              try
              {
                  XmlNode result = null;
                  if ((dt != null) && (dt.Rows.Count != 0) && (dt.Columns.Count != 0))
                  {
                      XmlNode xmlData = XmlAddElement(nameElement);
                      XmlNode xmlStrs = XmlAddElement("STRS");
                      foreach (DataRow row in dt.Rows)
                      {
                          XmlNode xmlStr = XmlAddElement("STR");
                          XmlAddChild(xmlStrs, xmlStr);
                          foreach (DataColumn col in dt.Columns)
                          {
                              xmlStr.Attributes.Append(xmlDoc.CreateAttribute(col.ColumnName));
                              object obj = row[col.ColumnName];
                              xmlStr.Attributes[col.ColumnName].Value = obj.ToString();
                          }
                      }
                      XmlAddChild(xmlData, xmlStrs);
                      result = xmlData;
                  }
                  return result;
              }
              catch (COMException ex)
              {
                  if (ex.ErrorCode == -2146827284)
                      throw new ApplicationException(excelError);
                  else
                      throw;
              }
          }

          protected XmlNode ConvertToXmlTitle()
          {
              try
              {
                  XmlNode result = null;
                  if ((dtTitle != null) &&  (dtTitle.Rows.Count != 0) && (dtTitle.Columns.Count != 0))
                  {
                      XmlNode xmlTitle = XmlAddElement("TITLE");
                      foreach (DataRow row in dtTitle.Rows)
                      {
                          foreach (DataColumn col in dtTitle.Columns)
                          {
                              xmlTitle.Attributes.Append(xmlDoc.CreateAttribute(col.ColumnName));
                              object obj = row[col.ColumnName];
                              xmlTitle.Attributes[col.ColumnName].Value = obj.ToString();
                          }
                      }
                      result = xmlTitle;
                  }
                  return result;
              }
              catch (COMException ex)
              {
                  if (ex.ErrorCode == -2146827284)
                      throw new ApplicationException(excelError);
                  else
                      throw;
              }
          
          }

          protected void XmlShablon(string[] namesData)
          {
              try
              {
                  XmlNode xmlReport = XmlAddElement("REPORT");
                  XmlNode xmlTitle = ConvertToXmlTitle();
                  XmlNode xmlData = XmlAddElement("DATA");

                  foreach (string str in namesData)
                      XmlAddChild(xmlData, ConvertToXmlFromDataTable(str));
                  
                 xmlReport.AppendChild(xmlTitle);
                 xmlReport.AppendChild(xmlData);
                 xmlDoc.AppendChild(xmlReport);
              }
              catch (COMException ex)
              {
                  if (ex.ErrorCode == -2146827284)
                      throw new ApplicationException(excelError);
                  else
                      throw;
              }
          }
      

      }*/


  }
}
