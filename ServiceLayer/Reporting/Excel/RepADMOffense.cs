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
     * 14.	Сроки исполнения постановления об административном правонарушении
     */
    public class RepADMOffense : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId, idSanc,idKoAP, idSts, idUsr;
        #endregion
        protected DateTime? date1, date2;
        #region Constructors
        public RepADMOffense()
        {
        }

        public RepADMOffense(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepADMOffense(RepForm form, LanguageIds language, DateTime? date1, DateTime? date2, Decimal idSanc, Decimal idKoAP, Decimal idUsr, Decimal idSts)
            : this(form, language)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.idSanc = idSanc;
            this.idSanc = idKoAP;
            this.idUsr = idUsr;
            this.idSts = idSts;

        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_ADM_OFFENSE";
                cmd.Parameters.Add("Wd_Beg_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);

                cmd.Parameters.Add("Id_Sanc_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_KoAP_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Usr_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("ID_Sts_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Beg_"].Value = date1;
                cmd.Parameters["Wd_End_"].Value = date2;


                cmd.Parameters["Id_Sanc_"].Value = idSanc;
                cmd.Parameters["Id_KoAP_"].Value = idKoAP;
                cmd.Parameters["Id_Usr_"].Value = idUsr;
                cmd.Parameters["ID_Sts_"].Value = idSts;

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
                ws.Range["B2"].Value = "Сроки исполнения постановления об административном правонарушении ";
                ws.Range["B2", "G2"].MergeCells = true;
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
                    if (dt.Rows[i]["DATEPROTOCOL"] != DBNull.Value)
                        (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATEPROTOCOL"]);
                        (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NUM"].ToString();

                        (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["KNDSANC"].ToString();
                        (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["DATENUM"].ToString();
                        (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["ADMCODE"].ToString();
                        (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["COMMENTS"].ToString();
                    




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
