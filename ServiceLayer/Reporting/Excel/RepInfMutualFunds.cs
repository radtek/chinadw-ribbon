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
     Author: Tolebi Baimenov
     * 54.	Форма П-13 . Сведения о паевых инвестиционных фондах по состоянию на __.__.____ года
     */
    public class RepInfMutualFunds : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected DateTime date;
        #region Constructors
        public RepInfMutualFunds()
        {
        }

        public RepInfMutualFunds(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepInfMutualFunds(RepForm form, LanguageIds language, DateTime date)
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
                cmd.CommandText = "G_REP_INF_MUTUAL_FUNDS";
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
                    ws.Range["B3"].Font.Bold = true;
                    ws.Range["B3"].Value = "Форма П-13 . Сведения о паевых инвестиционных фондах по состоянию на " + date.ToShortDateString() + " года";
                    ws.Range["B3", "J3"].MergeCells = true;
                    ws.Range["B3"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                   
                }
                else
                {
                    ws.Range["B3"].Font.Bold = true;
                    ws.Range["B3"].Value = date.ToShortDateString() + "ж. жағдайы бойынша  инвестициялық пай қорлардың мәлiметтерi";
                    ws.Range["B3", "J3"].MergeCells = true;
                    ws.Range["B3"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    
                }

                System.Data.DataTable dt1 = Getcursor1();
                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    if (dt1.Rows[i]["ID"] != DBNull.Value)

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["NAME_FUNDKND"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["NAME_FUND"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["DATE_REG"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt1.Rows[i]["DATECHANGE"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt1.Rows[i]["PERIOD"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt1.Rows[i]["NAME_PERIOD"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt1.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["PRICE"]);
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt1.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = Convert.ToString(dt1.Rows[i]["ISIN"]);
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt1.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt1.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt1.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = dt1.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 16] as Range).Value2 = dt1.Rows[i]["ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 17] as Range).Value2 = dt1.Rows[i]["NAME_REGISTRARS"].ToString();
                    (rngDataRow.Cells[rowIndex, 18] as Range).Value2 = dt1.Rows[i]["NAME_CUSTADION"].ToString();
                    (rngDataRow.Cells[rowIndex, 19] as Range).Value2 = Convert.ToString(dt1.Rows[i]["DATE_CONFIRM"]);
                    (rngDataRow.Cells[rowIndex, 20] as Range).Value2 = Convert.ToString(dt1.Rows[i]["COUNT_DEPLOY"]);
                    (rngDataRow.Cells[rowIndex, 21] as Range).Value2 = Convert.ToString(dt1.Rows[i]["DATE_ENDPLC"]);
                    (rngDataRow.Cells[rowIndex, 22] as Range).Value2 = Convert.ToString(dt1.Rows[i]["AMOUNTPERIOD"]);
                    (rngDataRow.Cells[rowIndex, 23] as Range).Value2 = Convert.ToString(dt1.Rows[i]["AMOUNT"]);
                    (rngDataRow.Cells[rowIndex, 24] as Range).Value2 = Convert.ToString(dt1.Rows[i]["COUNT"]);
                    (rngDataRow.Cells[rowIndex, 25] as Range).Value2 = Convert.ToString( dt1.Rows[i]["NAME_PAIHOLDERKND"]);
                    

                    rowIndex++;


                }

            }
            finally
            {
                EndFillReport();
            }
        }


        public override void ShowReport()
        {
            CreateReportFromXml();


        }
    }
}
