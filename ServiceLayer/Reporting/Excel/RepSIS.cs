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
     Author: Nurlan Ryskeldi
     * 19.	Сводный отчет по выпускам эмиссионных ценных бумаг за период	
     */
    public class RepSIS : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        
        #region Constructors
        public RepSIS()
        {
        }

        public RepSIS(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepSIS(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                // intervalDate = cmd.Parameters["Inteval_date_"].Value.ToString();     
                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt);
                }

                return dt;
            }
        }
        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_SHARES";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                // intervalDate = cmd.Parameters["Inteval_date_"].Value.ToString();     
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
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_BOND";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt2);
                }

                return dt2;
            }
        }

        public System.Data.DataTable Getcursor3()
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_ICB";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt3);
                }

                return dt3;
            }
        }

        public System.Data.DataTable Getcursor4()
        {
            System.Data.DataTable dt4 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_PAI";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt4);
                }

                return dt4;
            }
        }

        public System.Data.DataTable Getcursor5()
        {
            System.Data.DataTable dt5 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_KDR";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt5);
                }

                return dt5;
            }
        }

        public System.Data.DataTable Getcursor6()
        {
            System.Data.DataTable dt6 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SUM_ISSUE_SECUR_DRIB";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Begin_Date_"].Value = dateBegin;
                cmd.Parameters["End_Date_"].Value = dateEnd;
                cmd.Parameters["Err_Msg"].Size = 4000;

                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt6);
                }

                return dt6;
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

                ws.Range["A2"].Font.Bold = true;
                ws.Range["A2"].Value = "Сводный отчет по выпускам эмиссионных ценных бумаг за период c " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г."; 

                System.Data.DataTable dt = Getcursor();


                int rowIndex = 1;

                Console.WriteLine(dt.Rows.GetType());

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt.Rows[i]["All_CB"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["Shares"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["Bond"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["Pai"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["ICB"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["KDR"].ToString();
                   
                    rowIndex++;
                }

                
                Range rngData1 = ws.get_Range("DATA1", Type.Missing) as Range;
                Range rngDataRow1 = rngData1.Rows[rngData1.Rows.Count, Type.Missing] as Range;
                int rowIndex1 = 1;
                System.Data.DataTable dt1 = Getcursor1();

                for (var i = 0; i < dt1.Rows.Count; i++)
                {

                    (rngDataRow1.Cells[rowIndex1, 1] as Range).Value2 = dt1.Rows[i]["NAME_SHARES"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 2] as Range).Value2 = dt1.Rows[i]["CNT_ALL"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 3] as Range).Value2 = dt1.Rows[i]["CNT_AIF"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 4] as Range).Value2 = dt1.Rows[i]["CNT_ISLAM_COMPANY"].ToString();

                    rowIndex1++;
                }

                Range rngData2 = ws.get_Range("DATA2", Type.Missing) as Range;
                Range rngDataRow2 = rngData2.Rows[rngData2.Rows.Count, Type.Missing] as Range;
                int rowIndex2 = 1;
                System.Data.DataTable dt2 = Getcursor2();

                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    (rngDataRow2.Cells[rowIndex2, 1] as Range).Value2 = dt2.Rows[i]["NAME_BOND"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 2] as Range).Value2 = dt2.Rows[i]["CNT_V1"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 3] as Range).Value2 = dt2.Rows[i]["OB_VYP1"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 4] as Range).Value2 = dt2.Rows[i]["CNT_V2"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 5] as Range).Value2 = dt2.Rows[i]["CNT_O2"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 6] as Range).Value2 = dt2.Rows[i]["OB_VYP2"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 7] as Range).Value2 = dt2.Rows[i]["CNT_V3"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 8] as Range).Value2 = dt2.Rows[i]["CNT_O3"].ToString();
                    (rngDataRow2.Cells[rowIndex2, 9] as Range).Value2 = dt2.Rows[i]["OB_VYP3"].ToString();

                    rowIndex2++;
                }

                Range rngData3 = ws.get_Range("DATA3", Type.Missing) as Range;
                Range rngDataRow3 = rngData3.Rows[rngData3.Rows.Count, Type.Missing] as Range;
                int rowIndex3 = 1;
                System.Data.DataTable dt3 = Getcursor3();

                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    (rngDataRow3.Cells[rowIndex3, 1] as Range).Value2 = dt3.Rows[i]["NAME_ICB"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 2] as Range).Value2 = dt3.Rows[i]["CNT_ALL_ICB"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 3] as Range).Value2 = dt3.Rows[i]["CNT_AIF_ICB"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 4] as Range).Value2 = dt3.Rows[i]["CNT_ISLAM_COMPANY_ICB"].ToString();
                  
                    rowIndex3++;
                }

                Range rngData4 = ws.get_Range("DATA4", Type.Missing) as Range;
                Range rngDataRow4 = rngData4.Rows[rngData4.Rows.Count, Type.Missing] as Range;
                int rowIndex4 = 1;
                System.Data.DataTable dt4 = Getcursor4();

                for (var i = 0; i < dt4.Rows.Count; i++)
                {
                    (rngDataRow4.Cells[rowIndex4, 1] as Range).Value2 = dt4.Rows[i]["NAME_PAI"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 2] as Range).Value2 = dt4.Rows[i]["CNT_FOND"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 3] as Range).Value2 = dt4.Rows[i]["CNT_CLOSE"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 4] as Range).Value2 = dt4.Rows[i]["CNT_OPEN"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 5] as Range).Value2 = dt4.Rows[i]["CNT_INTERVAL"].ToString();
                    
                    rowIndex4++;
                }

                Range rngData5 = ws.get_Range("DATA5", Type.Missing) as Range;
                Range rngDataRow5 = rngData5.Rows[rngData5.Rows.Count, Type.Missing] as Range;
                int rowIndex5 = 1;
                System.Data.DataTable dt5 = Getcursor5();

                for (var i = 0; i < dt5.Rows.Count; i++)
                {
                    (rngDataRow5.Cells[rowIndex5, 1] as Range).Value2 = dt5.Rows[i]["NAME_KDR"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 2] as Range).Value2 = dt5.Rows[i]["CNT_ALL_KDR"].ToString();
                    
                    rowIndex5++;
                }

                Range rngData6 = ws.get_Range("DATA6", Type.Missing) as Range;
                Range rngDataRow6 = rngData6.Rows[rngData6.Rows.Count, Type.Missing] as Range;
                int rowIndex6 = 1;
                System.Data.DataTable dt6 = Getcursor6();

                for (var i = 0; i < dt6.Rows.Count; i++)
                {
                    (rngDataRow6.Cells[rowIndex6, 1] as Range).Value2 = dt6.Rows[i]["NAME_DRIB"].ToString();
                    (rngDataRow6.Cells[rowIndex6, 2] as Range).Value2 = dt6.Rows[i]["CNT1"].ToString();
                    (rngDataRow6.Cells[rowIndex6, 3] as Range).Value2 = dt6.Rows[i]["CNT2"].ToString();
                    (rngDataRow6.Cells[rowIndex6, 4] as Range).Value2 = dt6.Rows[i]["CNT3"].ToString();
                    (rngDataRow6.Cells[rowIndex6, 5] as Range).Value2 = dt6.Rows[i]["CNT4"].ToString();
                    (rngDataRow6.Cells[rowIndex6, 6] as Range).Value2 = dt6.Rows[i]["CNT5"].ToString();
                 
                    rowIndex6++;
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
