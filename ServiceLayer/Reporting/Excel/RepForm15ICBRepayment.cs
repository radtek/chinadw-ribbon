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
     * 70.	Форма И-15 . Список погашенных выпусков исламских ценных бумаг, за период c __.__.____г. по __.__.____г.
     */
    public class RepForm15ICBRepayment : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected string intervalDate;
        #region Constructors
        public RepForm15ICBRepayment()
        {
        }

        public RepForm15ICBRepayment(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepForm15ICBRepayment(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
        }

        protected virtual string GetXml()
        {
            return "";
        }

        public System.Data.DataTable Getcursor()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_FORM_15_ICB_REPAYMENT";
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
                    ws.Range["B2"].Font.Bold = true;
                    ws.Range["B2"].Value = "Форма И-15 . Список погашенных выпусков исламских ценных бумаг, за период c " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                    ws.Range["B2", "K2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                else
                {
                    ws.Range["B2"].Font.Bold = true;
                    ws.Range["B2"].Value = "Өтелген ислам бағалы қағаздардың шығарылым тізімі  " + dateBegin.ToShortDateString() + "ж. - " + dateEnd.ToShortDateString() + "ж.";
                    ws.Range["B2", "K2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                System.Data.DataTable dt = Getcursor();

                int rowIndex = 1;

                for (var i = 0; i < dt.Rows.Count; i++)
                {


                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                     XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


                    if (dt.Rows[i]["ID"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_REPAYMENT"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["DATE_END"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NAME_BUS_SECTOR"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["NAME_CATEGORYECB"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["ISIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["SUM_REPAYMENT"]);
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["COUNT_REPAYMENT"]);
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["SUM_ORIGINATOR"]);
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["SUM_BORROWED"]);
                    (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["SUM_INCOME"]);                    
                    


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
