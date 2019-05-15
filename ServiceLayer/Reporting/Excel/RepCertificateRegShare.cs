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
     * 36.	Свидетельство о государственной регистрации выпуска ценных бумаг 
     */
    public class RepCertificateRegShare : ReportToExcel
    {
        #region Fields
        protected  Microsoft.Office.Interop.Excel.Range range2;
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal? idShare;
        protected string numGosReg, dayCer, monthCer,monthCer2,monthCerKz, yearCer, nameJurPerson, address, name;
        protected string num, dayShare, monthShare, monthShare2, monthShareKz, yearShare, divided, count, NIN, num2, comm, chairman;
        #region Constructors
        public RepCertificateRegShare()
        {
        }

        public RepCertificateRegShare(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepCertificateRegShare(RepForm form, LanguageIds language, decimal? idShare)
            : this(form, language)
        {
            this.idShare = idShare;
            
        }

        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_CERTIFICATE_REG_SHARE";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Num_Gos_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Day_Cer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Cer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Cer2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Year_Cer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Jur_Person_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Day_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Share2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Year_Share_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Divided_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comm_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Chairman_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idShare;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Num_Gos_Reg_"].Size = 4000;
                cmd.Parameters["Day_Cer_"].Size = 4000;
                cmd.Parameters["Month_Cer_"].Size = 4000;
                cmd.Parameters["Month_Cer2_"].Size = 4000;
                cmd.Parameters["Year_Cer_"].Size = 4000;
                cmd.Parameters["Name_Jur_Person_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;

                cmd.Parameters["Name_"].Size = 4000;
                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["Day_Share_"].Size = 4000;
                cmd.Parameters["Month_Share_"].Size = 4000;
                cmd.Parameters["Month_Share2_"].Size = 4000;
                cmd.Parameters["Year_Share_"].Size = 4000;

                cmd.Parameters["Divided_"].Size = 4000;
                cmd.Parameters["Count_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Num2_"].Size = 4000;
                cmd.Parameters["Comm_"].Size = 4000;
                cmd.Parameters["Chairman_"].Size = 4000;
                cmd.ExecuteNonQuery();


                numGosReg = cmd.Parameters["Num_Gos_Reg_"].Value.ToString();
                if (numGosReg == "null")
                {
                    numGosReg = string.Empty;
                }
                dayCer = cmd.Parameters["Day_Cer_"].Value.ToString();
                if (dayCer == "null")
                {
                    dayCer = string.Empty;
                }
                monthCer = cmd.Parameters["Month_Cer_"].Value.ToString();
                if (monthCer == "null")
                {
                    monthCer = string.Empty;
                }
                monthCer2 = cmd.Parameters["Month_Cer2_"].Value.ToString();
                if (monthCer2 == "null")
                {
                    monthCer2 = string.Empty;
                }
                yearCer = cmd.Parameters["Year_Cer_"].Value.ToString();
                if (yearCer == "null")
                {
                    yearCer = string.Empty;
                }
                nameJurPerson = cmd.Parameters["Name_Jur_Person_"].Value.ToString();
                if (nameJurPerson == "null")
                {
                    nameJurPerson = string.Empty;
                }
                address = cmd.Parameters["Address_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
                }
                name = cmd.Parameters["Name_"].Value.ToString();
                if (name == "null")
                {
                    name = string.Empty;
                }
                num = cmd.Parameters["Num_"].Value.ToString();
                if (num == "null")
                {
                    num = string.Empty;
                }
                dayShare = cmd.Parameters["Day_Share_"].Value.ToString();
                if (dayShare == "null")
                {
                    dayShare = string.Empty;
                }
                monthShare = cmd.Parameters["Month_Share_"].Value.ToString();
                if (monthShare == "null")
                {
                    monthShare = string.Empty;
                }
                monthShare2 = cmd.Parameters["Month_Share2_"].Value.ToString();
                if (monthShare2 == "null")
                {
                    monthShare2 = string.Empty;
                }
                yearShare = cmd.Parameters["Year_Share_"].Value.ToString();
                if (yearShare == "null")
                {
                    yearShare = string.Empty;
                }
                divided = cmd.Parameters["Divided_"].Value.ToString();
                if (divided == "null")
                {
                    divided = string.Empty;
                }
                count = cmd.Parameters["Count_"].Value.ToString();
                if (count == "null")
                {
                    count = string.Empty;
                }
                NIN = cmd.Parameters["NIN_"].Value.ToString();
                if (NIN == "null")
                {
                    NIN = string.Empty;
                }
                num2 = cmd.Parameters["Num2_"].Value.ToString();
                if (num2 == "null")
                {
                    num2 = string.Empty;
                }
                comm = cmd.Parameters["Comm_"].Value.ToString();
                if (comm == "null")
                {
                    comm = string.Empty;
                }
                chairman = cmd.Parameters["Chairman_"].Value.ToString();
                if (chairman == "null")
                {
                    chairman = string.Empty;
                }
                
                
                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }

                return "";

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
                //Range rngDataBold = ws.get_Range("DATA", Type.Missing) as Range;
                //range2.get_Characters(1, num).Font.Bold = true;

                //string cellValue = range2.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, false, false).ToString();
               
                GetData();
                if (language == LanguageIds.Russian)
                {
                    if (monthCer2 == "01")
                    {
                        monthCer = "января";
                    }
                    if (monthCer2 == "02")
                    {
                        monthCer = "февраля";
                    }
                    if (monthCer2 == "03")
                    {
                        monthCer = "марта";
                    }
                    if (monthCer2 == "04")
                    {
                        monthCer = "апреля";
                    }
                    if (monthCer2 == "05")
                    {
                        monthCer = "мая";
                    }
                    if (monthCer2 == "06")
                    {
                        monthCer = "июня";
                    }
                    if (monthCer2 == "07")
                    {
                        monthCer = "июля";
                    }
                    if (monthCer2 == "08")
                    {
                        monthCer = "августа";
                    }
                    if (monthCer2 == "09")
                    {
                        monthCer = "сентября";
                    }
                    if (monthCer2 == "10")
                    {
                        monthCer = "октября";
                    }
                    if (monthCer2 == "11")
                    {
                        monthCer = "ноября";
                    }
                    if (monthCer2 == "12")
                    {
                        monthCer = "декабря";
                    }
                    /**/
                    if (monthShare2 == "01")
                    {
                        monthShare = "января";
                    }
                    if (monthShare2 == "02")
                    {
                        monthShare = "февраля";
                    }
                    if (monthShare2 == "03")
                    {
                        monthShare = "марта";
                    }
                    if (monthShare2 == "04")
                    {
                        monthShare = "апреля";
                    }
                    if (monthShare2 == "05")
                    {
                        monthShare = "мая";
                    }
                    if (monthShare2 == "06")
                    {
                        monthShare = "июня";
                    }
                    if (monthShare2 == "07")
                    {
                        monthShare = "июля";
                    }
                    if (monthShare2 == "08")
                    {
                        monthShare = "августа";
                    }
                    if (monthShare2 == "09")
                    {
                        monthShare = "сентября";
                    }
                    if (monthShare2 == "10")
                    {
                        monthShare = "октября";
                    }
                    if (monthShare2 == "11")
                    {
                        monthShare = "ноября";
                    }
                    if (monthShare2 == "12")
                    {
                        monthShare = "декабря";
                    }
                   
                    ws.Range["B9"].Value = "№  " + numGosReg;
                    ws.Range["B11"].Font.Bold = true;
                    // if (dayCer == null)
                    //{ dayCer = ""; }
                    ws.Range["B11"].Value = "«" + dayCer + "» " + monthCer + " " + yearCer + " года                            г. Алматы                                               № " + num;
                    //ws.Range["E11"].Font.Bold = true;
                    //ws.Range["E11"].Value = "№  " + num;
                    // ws.Range["A15"].Value = nameJurPerson 
                    ws.Range["B15"].Value = nameJurPerson + ",   юридический адрес:  " + address ;
                    //ws.Range["A16"].get_Characters(1, 9).Font.Bold = true;
                    //ws.Range["A16:E16"].get_Characters(1, 1).Font.Bold = false;
                    ws.Range["B16"].Value = "зарегистрированного   " + name + " №  " + num2 + "  от «" + dayShare + "»  " + monthShare + "  " + yearShare + " г.";
                   // ws.Range["D16"].Value = "№  " + num2 + "  от      «" + dayShare + "»  " + monthShare + "  " + yearShare + " г.";
                    ws.Range["B17"].Value = "Выпуск разделен на  " + divided ;
                    //ws.Range["C17"].Value = "в количестве   " + count;
                    // ws.Range["D10"].Value = count;

                    //ws.Range["A18"].Value = "которым  присвоен национальный идентификационный номер  " + NIN;
                    ws.Range["B18"].Value = "Выпуск внесен в Государственный реестр эмиссионных ценных бумаг за номером  " + num + ".";
                    ws.Range["B19"].Value = "Дополнительная информация о выпуске:  " + comm;
                    ws.Range["B21"].Value = "Председатель           " + chairman;
                }
                else
                {
                    if (monthCer2 == "01")
                    {
                        monthCerKz = "Қаңтар";
                    }
                    if (monthCer2 == "02")
                    {
                        monthCerKz = "Ақпан";
                    }
                    if (monthCer2 == "03")
                    {
                        monthCerKz = "Наурыз";
                    }
                    if (monthCer2 == "04")
                    {
                        monthCerKz = "Сәуір";
                    }
                    if (monthCer2 == "05")
                    {
                        monthCerKz = "Мамыр";
                    }
                    if (monthCer2 == "06")
                    {
                        monthCerKz = "Маусым";
                    }
                    if (monthCer2 == "07")
                    {
                        monthCerKz = "Шілде";
                    }
                    if (monthCer2 == "08")
                    {
                        monthCerKz = "Тамыз";
                    }
                    if (monthCer2 == "09")
                    {
                        monthCerKz = "Қыркүйек";
                    }
                    if (monthCer2 == "10")
                    {
                        monthCerKz = "Қазан";
                    }
                    if (monthCer2 == "11")
                    {
                        monthCerKz = "Қараша";
                    }
                    if (monthCer2 == "12")
                    {
                        monthCerKz = "Желтоқсан";
                    }
                    //--------
                    if (monthShare2 == "01")
                    {
                        monthShareKz = "Қаңтар";
                    }
                    if (monthShare2 == "02")
                    {
                        monthShareKz = "Ақпан";
                    }
                    if (monthShare2 == "03")
                    {
                        monthShareKz = "Наурыз";
                    }
                    if (monthShare2 == "04")
                    {
                        monthShareKz = "Сәуір";
                    }
                    if (monthShare2 == "05")
                    {
                        monthShareKz = "Мамыр";
                    }
                    if (monthShare2 == "06")
                    {
                        monthShareKz = "Маусым";
                    }
                    if (monthShare2 == "07")
                    {
                        monthShareKz = "Шілде";
                    }
                    if (monthShare2 == "08")
                    {
                        monthShareKz = "Тамыз";
                    }
                    if (monthShare2 == "09")
                    {
                        monthShareKz = "Қыркүйек";
                    }
                    if (monthShare2 == "10")
                    {
                        monthShareKz = "Қазан";
                    }
                    if (monthShare2 == "11")
                    {
                        monthShareKz = "Қараша";
                    }
                    if (monthShare2 == "12")
                    {
                        monthShareKz = "Желтоқсан";
                    }
                    ws.Range["B9"].Value = "№  " + numGosReg;
                    ws.Range["B11"].Font.Bold = true;
                    // if (dayCer == null)
                    //{ dayCer = ""; }
                    ws.Range["B11"].Value = "«" + dayCer + "» " + monthCerKz + " " + yearCer + "  жыл                                Алматы қ.                                                        № " + num;
                    //ws.Range["E11"].Font.Bold = true;
                    //ws.Range["E11"].Value = "№  " + num;
                    ws.Range["B14"].Value = "шығарылымының мемлекеттік тіркеуін жүргізді " + nameJurPerson + ",   заңды мекен-жайы: " + address;
                    //ws.Range["A16"].get_Characters(1, 9).Font.Bold = true;
                    //ws.Range["A16:E16"].get_Characters(1, 1).Font.Bold = false;
                    ws.Range["B15"].Value = "тіркелген   " + name + "  №  " + num2 + "  «" + dayShare + "»  " + monthShareKz + "  " + yearShare + " ж.";
                    //ws.Range["C15"].Value = "№  " + num2 + "  «" + dayShare + "»  " + monthShareKz + "  " + yearShare + " ж.";
                    ws.Range["B16"].Value = "Шығарылым бөлінген   " /*+ count*/ + divided;
                   // ws.Range["C16"].Value = "саны   " + count;
                    // ws.Range["D10"].Value = count;

                   // ws.Range["A17"].Value = "ұлттық бірегейлендіру нөмірі берілді   " + NIN;
                    ws.Range["B17"].Value = "Шығарылым мына нөмірмен эмиссиялық қағаздардың Мемлекеттік тізіліміне енгізілген    " + num;
                    ws.Range["B18"].Value = "Шығарылым туралы қосымша ақпарат:   " + comm;
                    ws.Range["B20"].Value = "Төраға  " + chairman;
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
