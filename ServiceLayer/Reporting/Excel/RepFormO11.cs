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
     Author: Nurlan Ryskeldi
     * 45.	Форма О-11. Перечень юридических лиц, утвердивших отчеты об итогах размещения облигаций за период
     */
    public class RepFormO11 : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        protected Decimal languageId;

        #region Constructors
        public RepFormO11()
        {
        }

        public RepFormO11(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepFormO11(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
        }

        public System.Data.DataTable Getcursor()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_FORM_O11";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
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
                    oda.Fill(dt);
                }

                return dt;
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

                ws.Range["A2"].Font.Bold = true;
                if (InitApplication.CurrentLangId == LanguageIds.Russian) 
                    ws.Range["A2"].Value = "Форма О-11. Перечень юридических лиц, утвердивших отчеты об итогах размещения облигаций за период с " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                else if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                    ws.Range["A2"].Value = "Облигацияларды орналастыру және өтеу қорытындылары жөніндегі ережені бекіткен заңды тулғалардың тізімі " + dateBegin.ToShortDateString() + " ж. және " + dateEnd.ToShortDateString() + " ж. жағдайы бойынша";

                System.Data.DataTable dt = Getcursor();


                int rowIndex = 1;

                Console.WriteLine(dt.Rows.GetType());

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_CONFIRM"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_EMIT"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NAME_REG"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NAME_SBS"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["BOND_KND"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["DATE_RPM"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["AMOUNT"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["COUNT"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["COUNT_DEPLOY"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["AMOUNT1"].ToString();
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt.Rows[i]["COUNT1"].ToString();
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["AMOUNT2"].ToString();
                    (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = dt.Rows[i]["NAME"].ToString();
                    (rngDataRow.Cells[rowIndex, 16] as Range).Value2 = dt.Rows[i]["NAMERU"].ToString();
                    (rngDataRow.Cells[rowIndex, 17] as Range).Value2 = dt.Rows[i]["NAMERU_HOLDER"].ToString();

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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_FORM_O11";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;
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
                      new XmlExcelProperty("DATE_CONFIRM", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_EMIT", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_REG", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_SBS", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_KND", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_RPM", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AMOUNT", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("COUNT", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("COUNT_DEPLOY", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AMOUNT1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("COUNT1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AMOUNT2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAMERU", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAMERU_HOLDER", XmlExcelProperty.XmlType.xmlString),
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
