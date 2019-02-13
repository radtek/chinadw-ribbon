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
using System.Windows.Forms;
using System.Xml;


namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
     Author: Tolebi Baimenov
     *12.	Представление эмитентами информации о фактах неисполнения либо ненадлежащего исполнения обязательств по облигациям.
     */
    public class Rep12InfFactsBond : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion

        protected decimal isReported;
        protected DateTime dateBegin, dateEnd;
        protected string intervalDate;
        #region Constructors
        public Rep12InfFactsBond()
        {
        }

        public Rep12InfFactsBond(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public Rep12InfFactsBond(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, decimal isReported)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.isReported = isReported;
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
                cmd.CommandText = "G_REP_12_INF_FACTS_BOND";
                cmd.Parameters.Add("Wd_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Is_Reported_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Begin_"].Value = dateBegin;
                cmd.Parameters["Wd_End_"].Value = dateEnd;
                cmd.Parameters["Is_Reported_"].Value = isReported;
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
                ws.Range["B2"].Value = "Представление эмитентами информации о фактах неисполнения либо ненадлежащего исполнения обязательств по облигациям  за период с  " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                //ws.Range["C2", "K2"].MergeCells = true;
                //ws.Range["C2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                System.Data.DataTable dt = Getcursor();

                int rowIndex = 1;

                for (var i = 0; i < dt.Rows.Count; i++)
                {


                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                     XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


                    if (dt.Rows[i]["NUM_PP"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["NUM_PP"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["ISIN"].ToString(); 
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["SHAREHOLDERS"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["OFFICIALS"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["DEFAULT_PERIOD"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATESUBM"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["SUMB_INF"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt.Rows[i]["ISRIGHTCLAIM"].ToString();
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["OF_NAME"].ToString();                    


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
