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
     * 68.	Форма И-13.  Перечень юридических лиц, представивших отчеты об итогах размещения (погашения) исламских ценных бумаг позже срока по состоянию на  __.__.____ года
     */
    public class RepForm13ICBSubmRep : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected DateTime date;
        #region Constructors
        public RepForm13ICBSubmRep()
        {
        }

        public RepForm13ICBSubmRep(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepForm13ICBSubmRep(RepForm form, LanguageIds language, DateTime date)
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
                cmd.CommandText = "G_REP_FORM_13_ICB_SUBM_REP";
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
                    ws.Range["B2"].Value = "Форма И-13.  Перечень юридических лиц, представивших отчеты об итогах размещения (погашения) исламских ценных бумаг позже срока по состоянию на " + date.ToShortDateString() + " года";
                    ws.Range["B2", "J2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
                else
                {
                    ws.Range["B2"].Font.Bold = true;
                    ws.Range["B2"].Value = "Ислам бағалы қағаздарды орналастыру және өтеу қорытындылары жөніндегі ережені мерзімнен кейін ұсынған заңды тулғалардың тізімі " + date.ToShortDateString() + "ж. жағдайы бойынша";
                    ws.Range["B2", "J2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
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
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NAME_BUS_SECTOR"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["DATE_LAST_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATE_SUBM"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["STS_NAME"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["NAME_HOLDERS"].ToString();



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
