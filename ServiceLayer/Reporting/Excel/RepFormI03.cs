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
     * 64.	Форма И-03. Журнал регистрации заявлений о выдаче разрешения за период
     */
    public class RepFormI03 : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        protected Decimal languageId;

        #region Constructors
        public RepFormI03()
        {
        }

        public RepFormI03(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepFormI03(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_FORM_I03";
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

                ws.Range["A2"].Font.Bold = true;
                if (InitApplication.CurrentLangId == LanguageIds.Russian) 
                    ws.Range["A2"].Value = "Форма И-03. Журнал регистрации заявлений о выдаче разрешения за период c " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                else if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                    ws.Range["A2"].Value = "Ислам арнайы қаржы компаниясын ерікті қайта құруға немесе таратуға рұқсат беру туралы өтініштер журналы " + dateBegin.ToShortDateString() + " ж. және " + dateEnd.ToShortDateString() + " ж. жағдайы бойынша";
                System.Data.DataTable dt = Getcursor();


                int rowIndex = 1;

                Console.WriteLine(dt.Rows.GetType());

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt.Rows[i]["ID"].ToString(); //Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["DATE_REC"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_DECLARATION"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["DATE_NOTIFICATION"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["DECISION_ORGAN"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["POCHTA_ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["ORGAN_REREG"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATE_REREG"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["BOR"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["COMMENTS"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["USER_NAME"].ToString();
                   
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
