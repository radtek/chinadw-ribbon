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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
    Author: Tolebi Baimenov
     * 75.	Динамика изменения количества паевых инвестиционных фондов 
    
     */
    public class Rep75FromXML : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        #endregion

        protected DateTime dateBegin, dateEnd;
        protected OracleClob clob;
        protected byte[] blob;
        protected string fileName;

        protected int j;
        #region Constructors
        public Rep75FromXML()
        {
        }

        public Rep75FromXML(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public Rep75FromXML(RepForm form, LanguageIds language, DateTime dateBegin, DateTime dateEnd)
            : this(form, language)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd;
        }

        protected virtual string GetXml()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "g_rep_75_from_xml";
                cmd.Parameters.Add("Date_Begin_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Date_End_", OracleDbType.Date, ParameterDirection.Input);
                cmd.Parameters.Add("Body_File_", OracleDbType.Clob, ParameterDirection.Output);
                cmd.Parameters.Add("Body_Blob_", OracleDbType.Blob, ParameterDirection.Output);
                cmd.Parameters.Add("File_Name_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);


                cmd.Parameters["Date_Begin_"].Value = dateBegin;
                cmd.Parameters["Date_End_"].Value = dateEnd;

                cmd.Parameters["File_Name_"].Size = 4000;
                cmd.Parameters["Err_Msg"].Size = 4000;

                cmd.ExecuteNonQuery();

                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }

                fileName = cmd.Parameters["File_Name_"].Value.ToString();
                blob = (byte[])((OracleBlob)(cmd.Parameters["Body_Blob_"].Value)).Value;
                clob = (OracleClob)cmd.Parameters["Body_File_"].Value;             
                return clob.Value;


            }
        }
        protected virtual void CreateReportFromXml(string strXml)
        {
            /*string path = Path.GetTempPath();
            string fileName = "{" + Convert.ToString(j) + "}" + blob + ".xlsx";
            j++;
            string fullPath = Path.Combine(path, fileName);
            File.WriteAllBytes(fullPath, blob);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fullPath;
            process.Start();*/
            BeginFillReport();
            try
            {


                string TempPath = System.IO.Path.GetTempPath();

                var coding = System.Text.Encoding.GetEncoding(1251);

                var dirxml = TempPath;
                string xmlfilename = Convert.ToString(fileName) + ".xls";
                if (Directory.Exists(dirxml) == false)
                    Directory.CreateDirectory(dirxml);
                string Path = System.IO.Path.Combine(dirxml, xmlfilename);



                using (StreamWriter writer = new StreamWriter(Path, false, coding))
                {
                    writer.WriteLine(Convert.ToString(clob.Value));
                }


                var wb = appExcel.Workbooks.Add(Path);  //(Worksheet)appExcel.Sheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                var doc = new XmlDocument();
                doc.LoadXml(strXml);
                var ws =  wb.Worksheets[1] as Worksheet;



                #region Report code


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
