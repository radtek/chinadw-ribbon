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
     * 25.	Сведения о зарегистрированных выпусках негосударственных ценных бумаг.	
     */
    public class RepInfRegIssSecur : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion
        protected DateTime dateBegin, dateEnd;
        protected decimal languageId;

        #region Constructors
        public RepInfRegIssSecur()
        {
        }

        public RepInfRegIssSecur(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepInfRegIssSecur(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "G_REP_INF_REG_ISS_SECUR_S";
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
                cmd.CommandText = "G_REP_INF_REG_ISS_SECUR_B";
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
                // ws.Range["A2"].Font.Bold = true;
                // ws.Range["A2"].Value = "Сводный отчет по выпускам эмиссионных ценных бумаг за период c " + dateBegin.ToShortDateString() + " г. по " + dateEnd.ToShortDateString() + " г.";

                System.Data.DataTable dt = Getcursor();


                int rowIndex = 1;

                //Console.WriteLine(dt.Rows.GetType());
                //int rowIndex = 1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                   // if (dt.Rows[i]["NAME_REGION_S"] != DBNull.Value)

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt.Rows[i]["NAME_REGION_S"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["NAME_EMIT_S"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["BO"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["NAME_SPEC_S"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["ADDRESS"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["NUM"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["ISIN"].ToString(); 
                    //if (dt.Rows[i]["DATE_REG"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["DATE_REG"].ToString();
                    //if (dt.Rows[i]["DATE_CANCEL"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["DATE_CANCEL"].ToString();
                    //if (dt.Rows[i]["DATE_CONFIRM_REP"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["DATE_CONFIRM_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["NAME_REG_S"].ToString();                    
                    rowIndex++;
                    rngColumnDataRow.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing);
                }


                Range rngData1 = ws.get_Range("DATA1", Type.Missing) as Range;
                Range rngDataRow1 = rngData1.Rows[rngData1.Rows.Count, Type.Missing] as Range;

                var rngBelowDataRow1 = ws.Rows[rngDataRow1.Row, Type.Missing] as Range;

                int rowIndex1 = 1;
                System.Data.DataTable dt1 = Getcursor1();

                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow1.Copy();
                    (rngDataRow1.Rows[rowIndex1, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                   // if (dt1.Rows[i]["NAME_REGION_B"] != DBNull.Value)

                    (rngDataRow1.Cells[rowIndex1, 1] as Range).Value2 = dt1.Rows[i]["NAME_REGION_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 2] as Range).Value2 = dt1.Rows[i]["NAME_EMIT_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 3] as Range).Value2 = dt1.Rows[i]["BO_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 4] as Range).Value2 = dt1.Rows[i]["NAME_SPEC_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 5] as Range).Value2 = dt1.Rows[i]["ADDRESS_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 6] as Range).Value2 = dt1.Rows[i]["NUM_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 7] as Range).Value2 = dt1.Rows[i]["NIN_B"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt1.Rows[i]["ISIN_B"].ToString(); 
                    (rngDataRow1.Cells[rowIndex1, 9] as Range).Value2 = dt1.Rows[i]["DATE_REG_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 10] as Range).Value2 = dt1.Rows[i]["DATE_ANNUL_B"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 11] as Range).Value2 = dt1.Rows[i]["PRICE"].ToString();
                    (rngDataRow1.Cells[rowIndex1, 12] as Range).Value2 = dt1.Rows[i]["NAME_REG_B"].ToString();                    
                    rowIndex1++;
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
                cmd.CommandText = "G_REP_INF_REG_ISS_SECUR_S";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
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

        protected virtual string GetXml2()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_INF_REG_ISS_SECUR_B";
                cmd.Parameters.Add("Begin_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("End_Date_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);
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

        protected virtual void CreateReportFromXml(string strXml, string strXml2)
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var doc = new XmlDocument();
                var doc2 = new XmlDocument();
                
                doc.LoadXml(strXml);
                doc2.LoadXml(strXml2);

                var ws = wb.Worksheets[1] as Worksheet;

                #region Report code

                ws.get_Range("DateBegin", Type.Missing).Value2 =
                  doc.DocumentElement.SelectSingleNode("StatisticPart/DateBegin").InnerText;

                XmlExcelProperty[] plist =
                {
                  new XmlExcelProperty("NAME_REGION_S", XmlExcelProperty.XmlType.xmlString),      
                  new XmlExcelProperty("NAME_EMIT_S", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("BO", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NAME_SPEC_S", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("ADDRESS", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NUM", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NIN", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("ISIN", XmlExcelProperty.XmlType.xmlString),       
                  new XmlExcelProperty("DATE_REG", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("DATE_CANCEL", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("DATE_CONFIRM_REP", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("NAME_REG_S", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("ID", XmlExcelProperty.XmlType.xmlDecimal)
                };
                XmlExcelProperty[] plist2 =
                {
                  new XmlExcelProperty("NAME_REGION_B", XmlExcelProperty.XmlType.xmlString),      
                  new XmlExcelProperty("NAME_EMIT_B", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("BO_B", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NAME_SPEC_B", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("ADDRESS_B", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NUM_B", XmlExcelProperty.XmlType.xmlString),
                  new XmlExcelProperty("NIN_B", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("ISIN_B", XmlExcelProperty.XmlType.xmlString),       
                  new XmlExcelProperty("DATE_REG_B", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("DATE_ANNUL_B", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("PRICE", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("NAME_REG_B", XmlExcelProperty.XmlType.xmlString),         
                  new XmlExcelProperty("ID_B", XmlExcelProperty.XmlType.xmlDecimal)                
                };
                createReportPartFromXmlFast(doc.DocumentElement.SelectSingleNode("CyclicPart"),
                  wb, ws, "", true, plist, "data");
                createReportPartFromXmlFast(doc2.DocumentElement.SelectSingleNode("CyclicPart"),
                 wb, ws, "", true, plist2, "data1");
                #endregion
            }
            finally
            {
                EndFillReport();
            }
        }


       
        public override void ShowReport()
        {
            CreateReportFromXml(GetXml(), GetXml2());


        }
    }
}
