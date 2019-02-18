﻿using ARM_User.BusinessLayer.Guides;
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
     Author: Tolebi Baimenov
     * 2.	Сведения о сроках представления эмитентами отчетов об итогах размещения акций за период
     */
    public class RepShares1 : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected Decimal idRegion, cancelConfirmRep;

        #region Constructors
        public RepShares1()
        {
        }

        public RepShares1(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepShares1(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, Decimal idRegion, Decimal cancelConfirmRep)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.idRegion = idRegion;
            this.cancelConfirmRep = cancelConfirmRep;
        }

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SHARES";
                cmd.Parameters.Add("Date_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cancel_Confirm_Rep_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                cmd.Parameters["Id_Region_"].Value = idRegion;
                cmd.Parameters["Cancel_Confirm_Rep_"].Value = cancelConfirmRep;
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
          new XmlExcelProperty("NUM", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_REG", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_AO", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_CONFIRM_REP", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_CANCEL", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_CURR_REP", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("VALUE_CAPITAL", XmlExcelProperty.XmlType.xmlDecimal),
          new XmlExcelProperty("COUNT_DECLARED_SHARE", XmlExcelProperty.XmlType.xmlDecimal),
          new XmlExcelProperty("COUNT_DISPOSAL_SHARE", XmlExcelProperty.XmlType.xmlDecimal),
          new XmlExcelProperty("TOTAL_DISPOSAL", XmlExcelProperty.XmlType.xmlDecimal),
          new XmlExcelProperty("NAME_STS", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_REGION", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
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