using ARM_User.BusinessLayer.Guides;
using ARM_User.Reports;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Office.Interop.Excel;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
    public class RepCorporationsRefShares2 : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        protected DateTime dateBegin, dateEnd;
        protected Decimal idRegion;
        #endregion

        #region Constructors
        public RepCorporationsRefShares2()
        {
        }

        public RepCorporationsRefShares2(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        public RepCorporationsRefShares2(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, Decimal idRegion)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.idRegion = idRegion;

        }
        #endregion

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Corporations_Reg_Shares2";
                cmd.Parameters.Add("Date_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("G_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                cmd.Parameters["Lang_id_"].Value = language;
                cmd.Parameters["G_Region_"].Value = idRegion;
                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;
                cmd.Parameters["Err_Msg"].Size = 4000;

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
          new XmlExcelProperty("NUM", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_REG_CHANGE", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_REG", XmlExcelProperty.XmlType.xmlString),     
          new XmlExcelProperty("NAME_JUR_PERSON", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_REGION", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_SPEC", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_BUS_SECTOR", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("COUNT", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("ISIN", XmlExcelProperty.XmlType.xmlString),       
          new XmlExcelProperty("NAME_FOUNDER", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_FOUNDER_REP", XmlExcelProperty.XmlType.xmlString),       
          new XmlExcelProperty("ORGANS_SOCIETY", XmlExcelProperty.XmlType.xmlString),       
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
