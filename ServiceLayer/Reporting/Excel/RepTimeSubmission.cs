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
     Author: Tolebi Baimenov
     * 16.	Сроки представления документов после отказа
     */
    public class RepTimeSubmission : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        protected Decimal idRegion, typeSecurities, idOfficial;
        #region Constructors
        public RepTimeSubmission()
        {
        }

        public RepTimeSubmission(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepTimeSubmission(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd, Decimal idRegion,Decimal typeSecurities,Decimal idOfficial)
            : this(form, language)
        {   
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
            this.idRegion = idRegion;
            this.typeSecurities = typeSecurities; 
            this.idOfficial = idOfficial;
        }

        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_TIME_SUBMISSION";
                cmd.Parameters.Add("DATE_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("DATE_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Type_Securities_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("G_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Official_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                cmd.Parameters["Type_Securities_"].Value = typeSecurities;
                cmd.Parameters["G_Region_"].Value = idRegion;
                cmd.Parameters["Official_"].Value = idOfficial;
                cmd.Parameters["Err_Msg"].Size = 4000;

                
                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt1);
                }

                return dt1;
            }
        }
        public System.Data.DataTable Getcursor2()
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_TIME_SUBMISSION_2";
                cmd.Parameters.Add("DATE_B_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("DATE_E_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Type_Securities_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("G_Region_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Official_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_B_"].Value = dateBegin;
                cmd.Parameters["Date_E_"].Value = dateEnd;
                cmd.Parameters["Type_Securities_"].Value = typeSecurities;
                cmd.Parameters["G_Region_"].Value = idRegion;
                cmd.Parameters["Official_"].Value = idOfficial;
                cmd.Parameters["Err_Msg"].Size = 4000;

              
                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt2);
                }

                return dt2;
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

                Range rngDataCountRow = rngData.Rows[2, Type.Missing] as Range;
                var rngColumnDataRow = ws.Rows[rngDataCountRow.Row, Type.Missing] as Range;


                ws.Range["B2"].Font.Bold = true;
                ws.Range["B2"].Value = "Сроки представления документов после отказа за период с " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г."; 
                System.Data.DataTable dt1 = Getcursor1();

               
                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);  
                    if (dt1.Rows[i]["ID"] != DBNull.Value)

                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["NAME_JURPERSON"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["NAME_OLF"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt1.Rows[i]["ISIN"].ToString(); 
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt1.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt1.Rows[i]["DATEREFUSE"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt1.Rows[i]["DATEPLAN"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt1.Rows[i]["NAME_REGION"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt1.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt1.Rows[i]["OF_NAME"].ToString();
                    
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["ID"]);
                   // (rngDataRow.Cells[rowIndex, 0] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ROW_STATUS"]);

                     rowIndex++;
                     rngColumnDataRow.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 
                   

                }
               

                Range rngData2 = ws.get_Range("DATA2", Type.Missing) as Range;
                Range rngDataRow2 = rngData2.Rows[rngData2.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow2 = ws.Rows[rngDataRow2.Row, Type.Missing] as Range;

                System.Data.DataTable dt2 = Getcursor2();
                
                int rowIndex1 = 1;
                
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    rngBelowDataRow2.Copy();
                    (rngDataRow2.Rows[rowIndex1, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    if (dt2.Rows[i]["IDD"] != DBNull.Value)

                    (rngDataRow2.Cells[rowIndex1, 1] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["IDD"]);
                    (rngDataRow2.Cells[rowIndex1, 2] as Range).Value2 = dt2.Rows[i]["NAME_JURPERSON2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 3] as Range).Value2 = dt2.Rows[i]["NAME_OLF2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 4] as Range).Value2 = dt2.Rows[i]["NIN2"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt2.Rows[i]["ISIN2"].ToString(); 
                    (rngDataRow2.Cells[rowIndex1, 6] as Range).Value2 = dt2.Rows[i]["NUM2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 7] as Range).Value2 = dt2.Rows[i]["DATEREFUSE2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 8] as Range).Value2 = dt2.Rows[i]["DATEPLAN2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 9] as Range).Value2 = dt2.Rows[i]["NAME_REGION2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 10] as Range).Value2 = dt2.Rows[i]["BIN2"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 11] as Range).Value2 = dt2.Rows[i]["OF_NAME2"].ToString();                    
                    // (rngDataRow.Cells[rowIndex, 0] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ROW_STATUS"]);



                    rowIndex1++;
                   
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
