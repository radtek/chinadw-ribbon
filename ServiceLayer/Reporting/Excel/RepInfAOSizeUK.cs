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
     Author: Tolebi Baimenov
     * 1.	Сведения об АО (созданных до 2003 года), размер УК которых не соответствует требованию законодательства по состоянию на ______ .
     */
    public class RepInfAOSizeUK : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime date;
        #region Constructors
        public RepInfAOSizeUK()
        {
        }

        public RepInfAOSizeUK(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepInfAOSizeUK(RepForm form, LanguageIds language, DateTime date)
            : this(form, language)
        {
            this.date = date;

        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_INF_AO_SIZE_UK";
                cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_"].Value = date;
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

                ws.Range["B2"].Font.Bold = true;
                ws.Range["B2"].Value = "Сведения об АО (созданных до 2003 года), размер УК которых не соответствует требованию законодательства по состоянию на " + date.ToShortDateString() + " года";
                ws.Range["B2", "J2"].MergeCells = true;
                ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                System.Data.DataTable dt = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    if (dt.Rows[i]["ID"] != DBNull.Value)

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NAME_AO"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["VALUE_CAPITAL"]);
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["DATE_REG"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["COUNT_SHARE"]);
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATE_CONFIRM_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["COUNT_DISPOSAL_SHARE"]);
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["TOTAL_DISPOSAL"]);



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
                cmd.CommandText = "G_REP_INF_AO_SIZE_UK";
                cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_"].Value = date;
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
                      new XmlExcelProperty("NAME_AO", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_REGION", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ADDRESS", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("VALUE_CAPITAL", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_REG", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("COUNT_SHARE", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_CONFIRM_REP", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("COUNT_DISPOSAL_SHARE", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("TOTAL_DISPOSAL", XmlExcelProperty.XmlType.xmlString),
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
