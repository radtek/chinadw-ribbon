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
     Author: Tolebi Baimenov
     * 13.	Сроки исполнения ОМВ
     */
    public class RepDateOMVExec : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId, idOMV, idSts, idUsr;
        #endregion
        protected DateTime? date1, date2, date3, date4, date5, date6;
        #region Constructors
        public RepDateOMVExec()
        {
        }

        public RepDateOMVExec(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepDateOMVExec(RepForm form, LanguageIds language, DateTime? date1, DateTime? date2, DateTime? date3, DateTime? date4, DateTime? date5, DateTime? date6, Decimal idOMV, Decimal idUsr, Decimal idSts)
            : this(form, language)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.date3 = date3;
            this.date4 = date4;
            this.date5 = date5;
            this.date6 = date6;

            this.idOMV = idOMV;
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
                cmd.CommandText = "G_REP_DATES_OMV_EXEC";
                cmd.Parameters.Add("Dt1_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Dt2_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Dt3_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Dt4_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Dt5_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Dt6_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Id_OMV_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Id_Usr_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("ID_Sts_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Dt1_"].Value = date1;
                cmd.Parameters["Dt2_"].Value = date2;
                cmd.Parameters["Dt3_"].Value = date3;
                cmd.Parameters["Dt4_"].Value = date4;
                cmd.Parameters["Dt5_"].Value = date5;
                cmd.Parameters["Dt6_"].Value = date6;

                cmd.Parameters["Id_OMV_"].Value = idOMV;
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
                    ws.Range["B2"].Value = "Сроки исполнения ОМВ ";
                    ws.Range["B2", "I2"].MergeCells = true;
                    ws.Range["B2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                System.Data.DataTable dt = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    if (dt.Rows[i]["ID"] != DBNull.Value)

                       (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToDecimal(dt.Rows[i]["ID"]);
                       (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NAME_EMITENT"].ToString();
                       (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    if (dt.Rows[i]["APPDATE"] != DBNull.Value)
                       (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["APPDATE"]);
                       (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["KND_SANC"].ToString();
                       (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NAME_BASE_PRE"].ToString();
                    if (dt.Rows[i]["DEADDATE"] != DBNull.Value)
                       (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DEADDATE"]);
                    if (dt.Rows[i]["DATEEXEC"] != DBNull.Value)
                       (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = Convert.ToDateTime(dt.Rows[i]["DATEEXEC"]);
                       (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["COMMENTS"].ToString();
                       (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["NAME"].ToString();
                     



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
