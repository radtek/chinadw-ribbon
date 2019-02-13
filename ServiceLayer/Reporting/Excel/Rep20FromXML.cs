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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
    Author: Tolebi Baimenov
     * 20.	Динамика изменения количества эмитентов и выпусков ценных бумаг
    
     */
    public class Rep20FromXML : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected OracleClob clob;
        protected string fileName;
        

        #region Constructors
        public Rep20FromXML()
        {
        }

        public Rep20FromXML(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public Rep20FromXML(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
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
                cmd.CommandText = "g_rep_20_from_xml";
                cmd.Parameters.Add("Date_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_End_", OracleDbType.Date, ParameterDirection.Input);               
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Date_Begin_"].Value = dateBegin;
                cmd.Parameters["Date_End_"].Value = dateEnd;              
               
                cmd.Parameters["Err_Msg"].Size = 4000;
                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt);
                }

                return dt;
            }
        }

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "g_rep_20_from_xml";
                cmd.Parameters.Add("Date_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Report_", OracleDbType.Clob, ParameterDirection.Output);               
               
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);


                cmd.Parameters["Date_Begin_"].Value = dateBegin;
                cmd.Parameters["Date_End_"].Value = dateEnd;             
                cmd.Parameters["Err_Msg"].Size = 4000;

                cmd.ExecuteNonQuery();

                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }              

                clob = (OracleClob)cmd.Parameters["Report_"].Value;
                

 
                return clob.Value;

                
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
                System.Data.DataTable dt = Getcursor();
                int rowIndex = 1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                     XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt.Rows[i]["DATE_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["DATE_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["DATE_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["DATE_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["DATE_STR_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = dt.Rows[i]["DATE_STR_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt.Rows[i]["DATE_STR_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 8] as Range).Value2 = dt.Rows[i]["DATE_STR_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 9] as Range).Value2 = dt.Rows[i]["SHARE_CNT1_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 10] as Range).Value2 = dt.Rows[i]["SHARE_CNT1_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 11] as Range).Value2 = dt.Rows[i]["SHARE_CNT1_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 12] as Range).Value2 = dt.Rows[i]["SHARE_CNT1_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 13] as Range).Value2 = dt.Rows[i]["REP_CNT_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 14] as Range).Value2 = dt.Rows[i]["REP_CNT_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 15] as Range).Value2 = dt.Rows[i]["REP_CNT_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 16] as Range).Value2 = dt.Rows[i]["REP_CNT_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 17] as Range).Value2 = dt.Rows[i]["ANNUL_CNT_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 18] as Range).Value2 = dt.Rows[i]["ANNUL_CNT_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 19] as Range).Value2 = dt.Rows[i]["ANNUL_CNT_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 20] as Range).Value2 = dt.Rows[i]["ANNUL_CNT_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 21] as Range).Value2 = dt.Rows[i]["SHARE_CNT2_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 22] as Range).Value2 = dt.Rows[i]["SHARE_CNT2_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 23] as Range).Value2 = dt.Rows[i]["SHARE_CNT2_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 24] as Range).Value2 = dt.Rows[i]["SHARE_CNT2_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 25] as Range).Value2 = dt.Rows[i]["AO_CNT_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 26] as Range).Value2 = dt.Rows[i]["AO_CNT_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 27] as Range).Value2 = dt.Rows[i]["AO_CNT_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 28] as Range).Value2 = dt.Rows[i]["AO_CNT_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 29] as Range).Value2 = dt.Rows[i]["VOLUME_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 30] as Range).Value2 = dt.Rows[i]["VOLUME_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 31] as Range).Value2 = dt.Rows[i]["VOLUME_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 32] as Range).Value2 = dt.Rows[i]["VOLUME_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 33] as Range).Value2 = dt.Rows[i]["BOND_CNT1_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 34] as Range).Value2 = dt.Rows[i]["BOND_CNT1_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 35] as Range).Value2 = dt.Rows[i]["BOND_CNT1_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 36] as Range).Value2 = dt.Rows[i]["BOND_CNT1_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 37] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT1_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 38] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT1_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 39] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT1_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 40] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT1_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 41] as Range).Value2 = dt.Rows[i]["BOND_CNT2_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 42] as Range).Value2 = dt.Rows[i]["BOND_CNT2_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 43] as Range).Value2 = dt.Rows[i]["BOND_CNT2_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 44] as Range).Value2 = dt.Rows[i]["BOND_CNT2_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 45] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT2_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 46] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT2_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 47] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT2_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 48] as Range).Value2 = dt.Rows[i]["BOND_AMOUNT2_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 49] as Range).Value2 = dt.Rows[i]["ICB_CNT1_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 50] as Range).Value2 = dt.Rows[i]["ICB_CNT1_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 51] as Range).Value2 = dt.Rows[i]["ICB_CNT1_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 52] as Range).Value2 = dt.Rows[i]["ICB_CNT1_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 53] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT1_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 54] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT1_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 55] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT1_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 56] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT1_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 57] as Range).Value2 = dt.Rows[i]["ICB_CNT2_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 58] as Range).Value2 = dt.Rows[i]["ICB_CNT2_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 59] as Range).Value2 = dt.Rows[i]["ICB_CNT2_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 60] as Range).Value2 = dt.Rows[i]["ICB_CNT2_4"].ToString();
                    (rngDataRow.Cells[rowIndex, 61] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT2_1"].ToString();
                    (rngDataRow.Cells[rowIndex, 62] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT2_2"].ToString();
                    (rngDataRow.Cells[rowIndex, 63] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT2_3"].ToString();
                    (rngDataRow.Cells[rowIndex, 64] as Range).Value2 = dt.Rows[i]["ICB_AMOUNT2_4"].ToString();
                    rowIndex++;
                }


            }
            finally
            {
                EndFillReport();
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

                XmlExcelProperty[] plist =
                    {
                      new XmlExcelProperty("DATE_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_STR_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_STR_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_STR_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("DATE_STR_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT1_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT1_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT1_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT1_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("REP_CNT_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("REP_CNT_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("REP_CNT_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("REP_CNT_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ANNUL_CNT_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ANNUL_CNT_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ANNUL_CNT_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ANNUL_CNT_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT2_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT2_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT2_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("SHARE_CNT2_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AO_CNT_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AO_CNT_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AO_CNT_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("AO_CNT_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("VOLUME_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("VOLUME_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("VOLUME_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("VOLUME_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT1_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT1_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT1_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT1_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT1_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT1_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT1_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT1_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT2_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT2_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT2_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_CNT2_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT2_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT2_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT2_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("BOND_AMOUNT2_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT1_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT1_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT1_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT1_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT1_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT1_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT1_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT1_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT2_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT2_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT2_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_CNT2_4", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT2_1", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT2_2", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT2_3", XmlExcelProperty.XmlType.xmlString),
                      new XmlExcelProperty("ICB_AMOUNT2_4", XmlExcelProperty.XmlType.xmlString),
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
