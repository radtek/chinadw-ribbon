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
     * 7. Сведения о сроках представления эмитентами отчетов об итогах погашения казахстанских депозитарных расписок
     */
    public class RepICBRepayment : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected DateTime dateBegin, dateEnd;
        protected Decimal idRegion, cancelConfirmRep;
        #endregion
        #region Constructors
        public RepICBRepayment()
        {
        }

        public RepICBRepayment(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepICBRepayment(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, Decimal idRegion, Decimal cancelConfirmRep)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.idRegion = idRegion;
            this.cancelConfirmRep = cancelConfirmRep;

        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_ICB_REPAYMENT";
                cmd.Parameters.Add("Date_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cancel_Confirm_Rep_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;


                cmd.Parameters["Id_Region_"].Value = idRegion;
                cmd.Parameters["Cancel_Confirm_Rep_"].Value = cancelConfirmRep;

                cmd.Parameters["Lang_id_"].Value = 1;
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

                ws.Range["B3"].Font.Bold = true;
                ws.Range["B3"].Value = " Сведения о сроках представления эмитентами отчетов об итогах погашения исламских ценных бумаг, за период с   " + dateBegin + " по " + dateEnd;
                ws.Range["B3", "J3"].MergeCells = true;
                ws.Range["B3"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                System.Data.DataTable dt = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    if (dt.Rows[i]["ID"] != DBNull.Value)
                        (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_REG"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NAME_EMITENT"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["DATE_CONFIRM_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["DATE_REP_PAY"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["DATE_CONFIRM_PRV_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATE_REP_TERM_PLA"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["DATE_SUBMISSION_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["COUNT_ICB"]);
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["COUNT_PL"]);
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["VALUE_CAPITAL"]);
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["NAME_PLACEMENT"].ToString();
                    (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = dt.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 16] as Range).Value2 = dt.Rows[i]["BIN"].ToString();





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
