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
using System.Windows.Forms;
using System.Xml;


namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
     Author: Tolebi Baimenov
     * 41.	Форма А-14.  Перечень акционерных обществ, аннулировавших выпуски акций за период c __.__.____г. по __.__.____г. 
     */
    public class RepListCancelShares: ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected string intervalDate;
        #region Constructors
        public RepListCancelShares()
        {
        }

        public RepListCancelShares(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepListCancelShares(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_LIST_CANCEL_SHARES";
                cmd.Parameters.Add("Wd_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Begin_"].Value = dateBegin;
                cmd.Parameters["Wd_End_"].Value = dateEnd;
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

                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    ws.Range["C2"].Font.Bold = true;
                    ws.Range["C2"].Value = "Форма А-14.  Перечень акционерных обществ, аннулировавших выпуски акций за период с " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                    ws.Range["C2", "M2"].MergeCells = true;
                    ws.Range["C2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    ws.Range["C2"].Font.Bold = true;
                    ws.Range["C2"].Value = "Ациялар шығарылымды жойған акционерлік қоғамдардың тізімі " + dateBegin.ToShortDateString() + "ж.- " + dateEnd.ToShortDateString() + "ж.";
                    ws.Range["C2", "M2"].MergeCells = true;
                    ws.Range["C2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                }
                System.Data.DataTable dt = Getcursor();

                int rowIndex = 1;

                for (var i = 0; i < dt.Rows.Count; i++)
                {


                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                     XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


                    if (dt.Rows[i]["ID"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_CANCEL"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NAME_SPEC"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NAME_BUS_SECTOR"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["NAME_REASON_CANCEL"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["COUNT_SHARE_CANCEL"]);
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["SUM_SHARE_CANCEL"]);
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["VALUE_CAPITAL"]);
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["NAME_REGISTRARS"].ToString();
                   

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
                cmd.CommandText = "G_REP_LIST_CANCEL_SHARES";
                cmd.Parameters.Add("Wd_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Begin_"].Value = dateBegin;
                cmd.Parameters["Wd_End_"].Value = dateEnd;
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
                      new XmlExcelProperty("DATE_CANCEL", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_JUR_PERSON", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_REGION", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_SPEC", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("NAME_BUS_SECTOR", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NAME_REASON_CANCEL", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("COUNT_SHARE_CANCEL", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("SUM_SHARE_CANCEL", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("VALUE_CAPITAL", XmlExcelProperty.XmlType.xmlString),                   
                      new XmlExcelProperty("NIN", XmlExcelProperty.XmlType.xmlString),     
                      new XmlExcelProperty("ISIN", XmlExcelProperty.XmlType.xmlString),       
                      new XmlExcelProperty("NAME_REGISTRARS", XmlExcelProperty.XmlType.xmlString),                   
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
