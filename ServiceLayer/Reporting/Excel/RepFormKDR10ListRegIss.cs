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
     Author: Nurlan Ryskeldi
     * 56.	Форма КДР-10.  Перечень эмитентов, зарегистрировавших выпуски казахстанских депозитарных расписок за период
     */
    public class RepFormKDR10ListRegIss : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        protected Decimal languageId;

        #region Constructors
        public RepFormKDR10ListRegIss()
        {
        }

        public RepFormKDR10ListRegIss(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepFormKDR10ListRegIss(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_FORM_KRD10_LIST_REG_ISS";
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
                    ws.Range["A2"].Value = "Форма КДР-10.  Перечень эмитентов, зарегистрировавших выпуски казахстанских депозитарных расписок за период c " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                else if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                    ws.Range["A2"].Value = "Қазақстандық депозитарлы қолхаттар шығарылымдарды мемлекеттік тіркеуді жүзеге асырған эмитенттердің тізімі " + dateBegin.ToShortDateString() + " ж. және " + dateEnd.ToShortDateString() + " ж. жағдайы бойынша";

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
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATEREG"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_EMIT"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["BO"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["COUNT_DEPRECEIPT"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NAME_COUNT_SECURITIES"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["ISIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["TERM_CIRCULATION"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["INF_BASE_ACTIV"].ToString();                    
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
