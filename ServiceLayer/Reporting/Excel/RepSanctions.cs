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
     * 999 Административные правонарушения примененные в отношении эмитентов
     */
    public class RepSanctions : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId, idIssuer, idDecision, idUsr;
        #endregion
        protected DateTime? date1, date2;
        #region Constructors
        public RepSanctions()
        {
        }

        public RepSanctions(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepSanctions(RepForm form, LanguageIds language, DateTime? date1, DateTime? date2, Decimal idIssuer, Decimal idUsr, Decimal idDecision)
            : this(form, language)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.idIssuer = idIssuer;
            this.idUsr = idUsr;
            this.idDecision = idDecision;

        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SANCTIONS";
                cmd.Parameters.Add("Wd_Beg_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);

                cmd.Parameters.Add("Id_Issuer_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Usr_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Decision_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Beg_"].Value = date1;
                cmd.Parameters["Wd_End_"].Value = date2;


                cmd.Parameters["Id_Issuer_"].Value = idIssuer;
                cmd.Parameters["Id_Usr_"].Value = idUsr;
                cmd.Parameters["Id_Decision_"].Value = idDecision;
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

                ws.Range["B2"].Font.Bold = true;
                ws.Range["B2"].Value = " Административные правонарушения примененные в отношении эмитентов";
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
                        (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["EMITENT"].ToString();
                        (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["NAME"].ToString();
                     if (dt.Rows[i]["DATEPROTOCOL"] != DBNull.Value)
                        (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATEPROTOCOL"]);
                        (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                        (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["BASE_PRESCRIPTION"].ToString();
                        (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NUMDATE1"].ToString();
                        (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["NUMDATE2"].ToString();
                     if (dt.Rows[i]["DATEPLAN"] != DBNull.Value)
                        (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATEPLAN"]);
                        (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["NUMDATE3"].ToString();
                        (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["NUMDATE4"].ToString();
                    if (dt.Rows[i]["DATE_COURT"] != DBNull.Value)
                       (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATE_COURT"]);
                    if (dt.Rows[i]["DATEOUT_COURT"] != DBNull.Value)
                       (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATEOUT_COURT"]);
                       (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["NUMDATE5"].ToString();
                       (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = dt.Rows[i]["COMMENTS"].ToString();
                       (rngDataRow.Cells[rowIndex, 16] as Range).Value2 = dt.Rows[i]["NUMDATE6"].ToString();

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
                cmd.CommandText = "G_REP_SANCTIONS";
                cmd.Parameters.Add("Wd_Beg_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);
                
                cmd.Parameters.Add("Id_Usr_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Decision_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Beg_"].Value = date1;
                cmd.Parameters["Wd_End_"].Value = date2;

             
                cmd.Parameters["Id_Usr_"].Value = idUsr;
                cmd.Parameters["Id_Decision_"].Value = idDecision;
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
                      new XmlExcelProperty("EMITENT", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATEPROTOCOL", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NUM", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BASE_PRESCRIPTION", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NUMDATE1", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE1", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE2", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("DATEPLAN", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE3", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE4", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("DATE_COURT", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("DATEOUT_COURT", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE5", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("COMMENTS", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NUMDATE6", XmlExcelProperty.XmlType.xmlString),                   
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
