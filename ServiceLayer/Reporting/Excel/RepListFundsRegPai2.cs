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
    * Author: Wansak_vitomin
    * Date: 20.11.2017
    */

    public class RepListFundsRegPai2 : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        protected DateTime dateBegin, dateEnd;
        protected Decimal idRegion;
        #endregion        

        #region Constructor
        public RepListFundsRegPai2()
        {
        }

        public RepListFundsRegPai2(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }        

        public RepListFundsRegPai2(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, Decimal idRegion)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.idRegion = idRegion;
        }
        #endregion

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_List_Funds_Reg_Pai_2";
                cmd.Parameters.Add("Date_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("G_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                cmd.Parameters["Lang_id_"].Value = language;
                cmd.Parameters["G_Region_"].Value = idRegion;
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

                ws.Range["B2"].Font.Bold = true;
                if (InitApplication.CurrentLangId == LanguageIds.Russian)
                {
                    ws.Range["B2"].Value = "Форма П-10. Перечень паевых инвестиционных фондов, зарегистрировавших за период с " + dateBegin.ToShortDateString() + " по " + dateEnd.ToShortDateString();
                }                
                ws.Range["B2", "I2"].MergeCells = true;
                ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    if (dt1.Rows[i]["ID"] != DBNull.Value)

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["DATE_REG"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["DATECHANGE"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt1.Rows[i]["NAME_FUND"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt1.Rows[i]["NAME_FUNDKND"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["PRICE"]);
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt1.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt1.Rows[i]["ISIN"].ToString(); 
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt1.Rows[i]["NAME_JUR_PERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt1.Rows[i]["NAME_CUSTADION"].ToString();
                    

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
