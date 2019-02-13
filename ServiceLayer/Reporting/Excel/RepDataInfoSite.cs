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
     * 84.	Форма А-26. Сведения о дефолтах по состоянию на
     */
    public class RepDataInfoSite : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin;
        protected Decimal languageId;

        #region Constructors
        public RepDataInfoSite()
        {
        }

        public RepDataInfoSite(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepDataInfoSite(RepForm form, LanguageIds language, DateTime dateBegin)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
        }

        public System.Data.DataTable GetIssuer()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Data_Info_Site";                
                cmd.Parameters.Add("Is_Type_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters["Is_Type_"].Value = 1;                
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt);
                }

                return dt;
            }
        }
        public System.Data.DataTable GetShare()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Data_Info_Site";
                cmd.Parameters.Add("Is_Type_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters["Is_Type_"].Value = 2;                
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt1);
                }

                return dt1;
            }
        }
        public System.Data.DataTable GetBond()
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Data_Info_Site";
                cmd.Parameters.Add("Is_Type_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters["Is_Type_"].Value = 3;                
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt2);
                }

                return dt2;
            }
        }
        public System.Data.DataTable GetPai()
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Data_Info_Site";
                cmd.Parameters.Add("Is_Type_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters["Is_Type_"].Value = 4;                
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt3);
                }
                return dt3;
            }
        }
        protected virtual void CreateReportFromXml()
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);
                #region Эмитент
                var ws = wb.Worksheets[1] as Worksheet;

                Range rngData = ws.get_Range("DATA", Type.Missing) as Range;
                Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow = ws.Rows[rngDataRow.Row, Type.Missing] as Range;

                ws.Range["A2"].Font.Bold = true;
                
                ws.Range["A2"].Value = "Сведения о зарегистрированных выпусках негосударственных ценных бумаг по состоянию на " + dateBegin.ToShortDateString();                

                System.Data.DataTable dt = GetIssuer();
                int rowIndex = 1;
                Console.WriteLine(dt.Rows.GetType());
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ID"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NAME"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["SPECIALIZATION"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["TYPE"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["CODE"].ToString();                    
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["OBLAST"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["PHONE"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["FAX"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["PHONE"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["CITY"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["STREET"].ToString();
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt.Rows[i]["CAPITAL"].ToString();                    
                  
                    rowIndex++;
                }
                #endregion
                #region Акций
                var ws1 = wb.Worksheets[2] as Worksheet;

                Range rngData1 = ws1.get_Range("DATASHARE", Type.Missing) as Range;
                Range rngDataRow1 = rngData1.Rows[rngData1.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow1 = ws1.Rows[rngDataRow1.Row, Type.Missing] as Range;
                ws1.Range["A2"].Font.Bold = true;
                ws1.Range["A2"].Value = "Сведения о зарегистрированных выпусках негосударственных ценных бумаг по состоянию на " + dateBegin.ToShortDateString();                

                System.Data.DataTable dt1 = GetShare();
                int rowIndex1 = 1;                
                Console.WriteLine(dt1.Rows.GetType());
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow1.Copy();
                    (rngDataRow1.Rows[rowIndex1, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow1.Cells[rowIndex1, 1] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["ID_SHARE"]);
                    (rngDataRow1.Cells[rowIndex1, 2] as Range).Value2 = dt1.Rows[i]["TYPE_SHARE"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 3] as Range).Value2 = dt1.Rows[i]["NUMBERS"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 4] as Range).Value2 = dt1.Rows[i]["NIN"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 5] as Range).Value2 = dt1.Rows[i]["BEGINDATE"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 6] as Range).Value2 = dt1.Rows[i]["ANNULDATE"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 7] as Range).Value2 = dt1.Rows[i]["ANNULREASON"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 8] as Range).Value2 = dt1.Rows[i]["REGISTRATOR"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 9] as Range).Value2 = dt1.Rows[i]["REPORTDATE"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 10] as Range).Value2 = dt1.Rows[i]["ECODE"].ToString();                    

                    rowIndex1++;
                }
                #endregion
                #region Облигаций
                var ws2 = wb.Worksheets[3] as Worksheet;

                Range rngData2 = ws2.get_Range("DATABOND", Type.Missing) as Range;
                Range rngDataRow2 = rngData2.Rows[rngData2.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow2 = ws2.Rows[rngDataRow2.Row, Type.Missing] as Range;
                ws2.Range["A2"].Font.Bold = true;
                ws2.Range["A2"].Value = "Сведения о зарегистрированных выпусках негосударственных ценных бумаг по состоянию на " + dateBegin.ToShortDateString();                
                System.Data.DataTable dt2 = GetBond();
                int rowIndex2 = 1;
                Console.WriteLine(dt2.Rows.GetType());
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    rngBelowDataRow2.Copy();
                    (rngDataRow2.Rows[rowIndex2, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow2.Cells[rowIndex2, 1] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["ID_BOND"]);
                    (rngDataRow2.Cells[rowIndex2, 2] as Range).Value2 = dt2.Rows[i]["TYPEBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 3] as Range).Value2 = dt2.Rows[i]["NUMBERSBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 4] as Range).Value2 = dt2.Rows[i]["NINBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 5] as Range).Value2 = dt2.Rows[i]["BEGINDATEBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 6] as Range).Value2 = dt2.Rows[i]["ANNULDATEBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 7] as Range).Value2 = dt2.Rows[i]["NOMINALBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 8] as Range).Value2 = dt2.Rows[i]["REGISTRATORBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 9] as Range).Value2 = dt2.Rows[i]["QUANTITYBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 10] as Range).Value2 = dt2.Rows[i]["VOLUMEBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 11] as Range).Value2 = dt2.Rows[i]["STATUSBOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 12] as Range).Value2 = dt2.Rows[i]["ECODEBOND"].ToString();

                    rowIndex2++;
                }
                #endregion
                #region Паи
                var ws3 = wb.Worksheets[4] as Worksheet;

                Range rngData3 = ws3.get_Range("DATAPAI", Type.Missing) as Range;
                Range rngDataRow3 = rngData3.Rows[rngData3.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow3 = ws3.Rows[rngDataRow3.Row, Type.Missing] as Range;
                ws3.Range["A2"].Font.Bold = true;
                ws3.Range["A2"].Value = "Сведения о зарегистрированных выпусках негосударственных ценных бумаг по состоянию на " + dateBegin.ToShortDateString();                
                System.Data.DataTable dt3 = GetPai();
                int rowIndex3 = 1;
                Console.WriteLine(dt3.Rows.GetType());
                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    rngBelowDataRow3.Copy();
                    (rngDataRow3.Rows[rowIndex3, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow3.Cells[rowIndex3, 1] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["ID_PAI"]);
                    (rngDataRow3.Cells[rowIndex3, 2] as Range).Value2 = dt3.Rows[i]["TYPEPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 3] as Range).Value2 = dt3.Rows[i]["NUMBERSPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 4] as Range).Value2 = dt3.Rows[i]["NINPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 5] as Range).Value2 = dt3.Rows[i]["BEGINDATEPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 6] as Range).Value2 = dt3.Rows[i]["ANNULDATEPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 7] as Range).Value2 = dt3.Rows[i]["NOMINALPAI"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 8] as Range).Value2 = dt3.Rows[i]["ECODEPAI"].ToString();                    

                    rowIndex3++;
                }
                #endregion
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
