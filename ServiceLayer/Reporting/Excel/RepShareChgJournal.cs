using ARM_User.BusinessLayer.Guides;
using ARM_User.Reports;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Office.Interop.Excel;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
     * Author: Wansak_vitomin
     * Date: 20.11.2017
     */
    public class RepShareChgJournal : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;        
        protected DateTime dateBegin, dateEnd;
        #endregion

        #region Constructors
        public RepShareChgJournal()
        {
        }
        public RepShareChgJournal(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        public RepShareChgJournal(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
            : this(form, language)
        {            
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.language = language;
        }
        #endregion 

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_ShareChg_Journal";
                cmd.Parameters.Add("Date_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_E_", OracleDbType.Date, ParameterDirection.Input);               
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    cmd.Parameters["Lang_id_"].Value = 1;
                }
                if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                {
                    cmd.Parameters["Lang_id_"].Value = 2;
                }
                cmd.Parameters["err_msg"].Size = 4000;

                cmd.ExecuteNonQuery();

                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }

                var clob = (OracleClob)cmd.Parameters["Report_"].Value;
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
          new XmlExcelProperty("DATE_REC", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NUM", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_CHANGE", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_JUR_PERSON", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("ADDRESS", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("REG_ORGAN_NAME", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_REG", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("ISIN", XmlExcelProperty.XmlType.xmlString),       
          new XmlExcelProperty("EXEC_NAME", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("COMMENTS", XmlExcelProperty.XmlType.xmlString),
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
