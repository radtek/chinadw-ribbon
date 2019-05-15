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
using System.Windows.Forms;
using System.Xml;


namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
     Author: Tolebi Baimenov
     * 18.	Отчет о количестве оказанных государственных услуг
     */
    public class RepCntStateServices : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected string intervalDate;
        #region Constructors
        public RepCntStateServices()
        {
        }

        public RepCntStateServices(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepCntStateServices(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_CNT_STATE_SERVICES";
                cmd.Parameters.Add("Wd_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Wd_Begin_"].Value = dateBegin;
                cmd.Parameters["Wd_End_"].Value = dateEnd;
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


                ws.Range["C2"].Font.Bold = true;
                ws.Range["C2"].Value = "Отчет о количестве оказанных государственных услуг за период с " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";
                ws.Range["C2", "H2"].MergeCells = true;
                ws.Range["C2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
          
                System.Data.DataTable dt = Getcursor();
             
                int rowIndex = 1;

                for (var i = 0; i < dt.Rows.Count; i++)

                {
                  

                   rngBelowDataRow.Copy();
                  (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                   XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);


                 if (dt.Rows[i]["NUM_PP"] != DBNull.Value) 
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["NUM_PP"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["PERIOD_MONTHS"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["NAME"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["BIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["FIO_SP"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["DATE_NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["OUTCOME"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["NOTE"].ToString();
                    //(rngDataRow.Cells[rowIndex, 0] as Range).Value2 = Convert.ToInt32(dt.Rows[i]["ROW_STATUS"]);
                    


                    rowIndex++;
                }

              
            }
            finally
            {
                EndFillReport();
            }
        }

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_CNT_STATE_SERVICES";
                cmd.Parameters.Add("Wd_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Wd_End_", OracleDbType.Date, ParameterDirection.Input);                                
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);

                cmd.Parameters["Wd_Begin_"].Value = dateBegin;
                cmd.Parameters["Wd_End_"].Value = dateEnd;              
                cmd.Parameters["err_msg"].Size = 4000;

                cmd.ExecuteNonQuery();

                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }

                var clob = (OracleClob)cmd.Parameters["Report_"].Value;
                return clob.Value;
            }
        }

        protected virtual void CreateReportFromXml(string strXml)
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var doc = new XmlDocument();
                doc.LoadXml(strXml);

                var ws = wb.Worksheets[1] as Worksheet;

                #region Report code

                ws.get_Range("DateBegin", Type.Missing).Value2 =
                  doc.DocumentElement.SelectSingleNode("StatisticPart/DateBegin").InnerText;

                XmlExcelProperty[] plist =
        {
          new XmlExcelProperty("NUM_PP", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("PERIOD_MONTHS", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NAME", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("BIN", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("FIO_SP", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("DATE_NUM", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("OUTCOME", XmlExcelProperty.XmlType.xmlString),
          new XmlExcelProperty("NOTE", XmlExcelProperty.XmlType.xmlString)
        };
                createReportPartFromXmlFast(doc.DocumentElement.SelectSingleNode("CyclicPart"),
                  wb, ws, "", true, plist);
                #endregion
            }
            finally
            {
                EndFillReport();
            }
        }

        public override void ShowReport()
        {
            CreateReportFromXml(GetXml());
        }
    }
}
