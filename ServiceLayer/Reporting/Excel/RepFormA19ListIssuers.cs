﻿using ARM_User.BusinessLayer.Guides;
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
     Author: Tolebi Baimenov
     *80.	Форма А-19. Список действующих эмитентов по состоянию на __.__.____ года
     */
    public class RepFormA19ListIssuers : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected DateTime date;
        #region Constructors
        public RepFormA19ListIssuers()
        {
        }

        public RepFormA19ListIssuers(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepFormA19ListIssuers(RepForm form, LanguageIds language, DateTime date)
            : this(form, language)
        {
            this.date = date;

        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_FORM_A19_LIST_ISSUERS";
                cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_"].Value = date;
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


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt1);
                }

                return dt1;
            }
        }

        protected virtual void CreateReportFromXml()
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var ws = wb.Worksheets[1] as Worksheet;



                Range rngData = ws.get_Range("DATA", Type.Missing) as Range;
                Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                var rngBelowDataRow = ws.Rows[rngDataRow.Row, Type.Missing] as Range;

                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    ws.Range["B2"].Font.Bold = true;
                    ws.Range["B2"].Value = "Форма А-19. Список действующих эмитентов по состоянию на " + date.ToShortDateString() + " года";
                    ws.Range["B2", "G2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                else
                {
                    ws.Range["B2"].Font.Bold = true;
                    ws.Range["B2"].Value = "Әрекет ететін эмитентердің тізімі " + date.ToShortDateString() + "ж.";
                    ws.Range["B2", "G2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                     if (dt1.Rows[i]["ID"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToDecimal(dt1.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["REG_DATE"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["REREG_DATE"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt1.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt1.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt1.Rows[i]["ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt1.Rows[i]["NAME_BUS_SECTOR"].ToString();
                  


                    rowIndex++;


                }




            }
            finally
            {
                EndFillReport();
            }
        }

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_FORM_A19_LIST_ISSUERS";
                cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);          
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_"].Value = date;          
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
          new XmlExcelProperty("REG_DATE", XmlExcelProperty.XmlType.xmlString),      
          new XmlExcelProperty("REREG_DATE", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_OLF", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_JUR_PERSON", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("ADDRESS", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME_BUS_SECTOR", XmlExcelProperty.XmlType.xmlString),         
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
