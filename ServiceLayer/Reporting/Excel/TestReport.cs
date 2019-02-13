using System;
using System.Data;
using System.Xml;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Office.Interop.Excel;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ARM_User.Reports
{
  /*
   Authors: Tolebi Baimenov, Zhandos Iskakov   
   */
  public class TestReport : ReportToExcel
  {
    #region Fields
    protected RepForm form;
    protected LanguageIds language;
    #endregion

    protected DateTime dateBegin, dateEnd;
    
    #region Constructors
    public TestReport()
    {
    }

    public TestReport(RepForm form, LanguageIds language)
    {
      this.form = form;
      this.language = language;      
    }
    #endregion

    public TestReport(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd) : this(form, language)
    {
      this.dateBegin = dateBegin;
      this.dateEnd = dateEnd;      
    }

    protected virtual string GetXml()
    {
      using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
      {
        cmd.BindByName = true;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "main.test_report";
        cmd.Parameters.Add("p_date_begin", OracleDbType.Date, ParameterDirection.Input);
        cmd.Parameters.Add("p_date_end", OracleDbType.Date, ParameterDirection.Input);
        cmd.Parameters.Add("p_lang_id", OracleDbType.Int32, ParameterDirection.Input);
        cmd.Parameters.Add("p_err_code", OracleDbType.Int32, ParameterDirection.Output);
        cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        cmd.Parameters.Add("p_report", OracleDbType.Clob, ParameterDirection.Output);

        cmd.Parameters["p_date_begin"].Value = dateBegin;

        cmd.ExecuteNonQuery();

        if (!((OracleDecimal) cmd.Parameters["p_err_code"].Value).IsNull)
        {
          var errCode = ((OracleDecimal) cmd.Parameters["p_err_code"].Value).ToInt32();
          var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
          if (errCode != 0)
            throw new OraCustomException(errCode, errMsg);
        }

        var clob = (OracleClob) cmd.Parameters["p_report"].Value;
        return clob.Value;
      }
    }

    protected virtual void CreateReportFromXml(string strXml)
    {
      BeginFillReport();

      try
      {
        var path = SaveTemplateFile(form.GetTemplate(language));

        var wb = appExcel.Workbooks.Add(path);

        var doc = new XmlDocument();
        doc.LoadXml(strXml);

        var ws = wb.Worksheets[1] as Worksheet;

        #region Report code

        ws.get_Range("DateBegin", Type.Missing).Value2 =
          doc.DocumentElement.SelectSingleNode("StatisticPart/DateBegin").InnerText;

        XmlExcelProperty[] plist =
        {
          new XmlExcelProperty("NAME_RU", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_KZ", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("ID", XmlExcelProperty.XmlType.xmlDecimal)
        };

        createReportPartFromXmlFast(doc.DocumentElement.SelectSingleNode("CyclicPart"),
          wb, ws, "", true, plist);
        #endregion
      }
      finally
      {
        EndFillReport();
      }
    }

    public override void ShowReport()
    {
      CreateReportFromXml(GetXml());
    }
  }
}