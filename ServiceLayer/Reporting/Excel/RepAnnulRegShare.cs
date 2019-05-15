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

/*
 Author: Nurlan Ryskeldi  
  37.	Свидетельство об аннулировании регистрации выпуска акций 
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepAnnulRegShare : ReportToExcel
    {
        protected RepForm form;
        protected LanguageIds language;
        protected string firstName, lastName, D_Reg_Date, M_Reg_Date, M_Reg_Date2, Y_Reg_Date;
        protected string Name_Jur_Person, Address, Num, Num1, Day_Share, Month_Share,Month_Share2, Year_Share,Name, Name1, Cnt, Name2, Cnt1, Comments, Chairman;
        protected decimal? Id_Share;
        protected Decimal languageId;

        public RepAnnulRegShare(RepForm form, LanguageIds language, decimal? Id_Share)
        {
            this.form = form;
            this.language = language;
            this.Id_Share = Id_Share;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_ANNUL_REG_SHARE";
                cmd.Parameters.Add("Id_Share_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Name_Jur_Person_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Day_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Share2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Year_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num1_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("D_Reg_Date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("M_Reg_Date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("M_Reg_Date2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Y_Reg_Date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name1_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Cnt_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Cnt1_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Chairman_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_Share_"].Value = Id_Share;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Name_Jur_Person_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["Day_Share_"].Size = 4000;
                cmd.Parameters["Month_Share_"].Size = 4000;
                cmd.Parameters["Month_Share2_"].Size = 4000;
                cmd.Parameters["Year_Share_"].Size = 4000;
                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["Num1_"].Size = 4000;
                cmd.Parameters["D_Reg_Date_"].Size = 4000;
                cmd.Parameters["M_Reg_Date_"].Size = 4000;
                cmd.Parameters["M_Reg_Date2_"].Size = 4000;
                cmd.Parameters["Y_Reg_Date_"].Size = 4000;
                cmd.Parameters["Name_"].Size = 4000;
                cmd.Parameters["Name1_"].Size = 4000;
                cmd.Parameters["Cnt_"].Size = 4000;
                cmd.Parameters["Name2_"].Size = 4000;
                cmd.Parameters["Cnt1_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Chairman_"].Size = 4000;
               
                cmd.ExecuteNonQuery();

                Name_Jur_Person = cmd.Parameters["Name_Jur_Person_"].Value.ToString();
                if (Name_Jur_Person == "null")
                {
                    Name_Jur_Person = string.Empty;
                }

                Address = cmd.Parameters["Address_"].Value.ToString();
                if (Address == "null")
                {
                    Address = string.Empty;
                }
                Num = cmd.Parameters["Num_"].Value.ToString();
                if (Num == "null")
                {
                    Num = string.Empty;
                }

                Num1 = cmd.Parameters["Num1_"].Value.ToString();
                if (Num1 == "null")
                {
                    Num1 = string.Empty;
                }
                
                Day_Share = cmd.Parameters["Day_Share_"].Value.ToString();
                if (Day_Share == "null")
                {
                    Day_Share = string.Empty;
                }
                
                Month_Share = cmd.Parameters["Month_Share_"].Value.ToString();
                if (Month_Share == "null")
                {
                    Month_Share = string.Empty;
                }
                Month_Share2 = cmd.Parameters["Month_Share2_"].Value.ToString();
                if (Month_Share2 == "null")
                {
                    Month_Share2 = string.Empty;
                }
                
                Year_Share = cmd.Parameters["Year_Share_"].Value.ToString();
                if (Year_Share == "null")
                {
                    Year_Share = string.Empty;
                }
                Y_Reg_Date = cmd.Parameters["Y_Reg_Date_"].Value.ToString();
                if (Y_Reg_Date == "null")
                {
                    Y_Reg_Date = string.Empty;
                }
                M_Reg_Date2 = cmd.Parameters["M_Reg_Date2_"].Value.ToString();
                if (M_Reg_Date2 == "null")
                {
                    M_Reg_Date2 = string.Empty;
                }
                M_Reg_Date = cmd.Parameters["M_Reg_Date_"].Value.ToString();
                if (M_Reg_Date == "null")
                {
                    M_Reg_Date = string.Empty;
                }
                D_Reg_Date = cmd.Parameters["D_Reg_Date_"].Value.ToString();
                if (D_Reg_Date == "null")
                {
                    D_Reg_Date = string.Empty;
                }
                Name = cmd.Parameters["Name_"].Value.ToString();
                if (Name == "null")
                {
                    Name = string.Empty;
                }
                Name1 = cmd.Parameters["Name1_"].Value.ToString();
                if (Name1 == "null")
                {
                    Name1 = string.Empty;
                }

                Cnt = cmd.Parameters["Cnt_"].Value.ToString();
                if (Cnt == "null")
                {
                    Cnt = string.Empty;
                }

                Name2 = cmd.Parameters["Name2_"].Value.ToString();
                if (Name2 == "null")
                {
                    Name2 = string.Empty;
                }

                Cnt1 = cmd.Parameters["Cnt1_"].Value.ToString();
                if (Cnt1 == "null")
                {
                    Cnt1 = string.Empty;
                }
                
                Comments = cmd.Parameters["Comments_"].Value.ToString();
                if (Comments == "null")
                {
                    Comments = string.Empty;
                }
                
                Chairman = cmd.Parameters["Chairman_"].Value.ToString();
                if (Chairman == "null")
                {
                    Chairman = string.Empty;
                }

                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }
                return "";/*((OracleString)cmd.Parameters["Name_Jur_Person_"].Value).Value;
                return ((OracleString)cmd.Parameters["Address_"].Value).Value;
                return ((OracleString)cmd.Parameters["Day_Share_"].Value).Value;
                return ((OracleString)cmd.Parameters["Month_Share_"].Value).Value;
                return ((OracleString)cmd.Parameters["Year_Share_"].Value).Value;
                return ((OracleString)cmd.Parameters["Num_"].Value).Value;
                return ((OracleString)cmd.Parameters["Num1_"].Value).Value;
                return ((OracleString)cmd.Parameters["Name1_"].Value).Value;
                return ((OracleString)cmd.Parameters["Cnt_"].Value).Value;
                return ((OracleString)cmd.Parameters["Name2_"].Value).Value;
                return ((OracleString)cmd.Parameters["Cnt1_"].Value).Value;
                return ((OracleString)cmd.Parameters["Comments_"].Value).Value;
                return ((OracleString)cmd.Parameters["Chairman_"].Value).Value;*/
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

                GetData();
                if (language == LanguageIds.Russian)
                {
                    if (Month_Share2 == "01")
                    {
                        Month_Share = "января";
                    }
                    if (Month_Share2 == "02")
                    {
                        Month_Share = "февраля";
                    }
                    if (Month_Share2 == "03")
                    {
                        Month_Share = "марта";
                    }
                    if (Month_Share2 == "04")
                    {
                        Month_Share = "апреля";
                    }
                    if (Month_Share2 == "05")
                    {
                        Month_Share = "мая";
                    }
                    if (Month_Share2 == "06")
                    {
                        Month_Share = "июня";
                    }
                    if (Month_Share2 == "07")
                    {
                        Month_Share = "июля";
                    }
                    if (Month_Share2 == "08")
                    {
                        Month_Share = "августа";
                    }
                    if (Month_Share2 == "09")
                    {
                        Month_Share = "сентября";
                    }
                    if (Month_Share2 == "10")
                    {
                        Month_Share = "октября";
                    }
                    if (Month_Share2 == "11")
                    {
                        Month_Share = "ноября";
                    }
                    if (Month_Share2 == "12")
                    {
                        Month_Share = "декабря";
                    }
                    /*---*/
                    if (M_Reg_Date2 == "01")
                    {
                        M_Reg_Date = "января";
                    }
                    if (M_Reg_Date2 == "02")
                    {
                        M_Reg_Date = "февраля";
                    }
                    if (M_Reg_Date2 == "03")
                    {
                        M_Reg_Date = "марта";
                    }
                    if (M_Reg_Date2 == "04")
                    {
                        M_Reg_Date = "апреля";
                    }
                    if (M_Reg_Date2 == "05")
                    {
                        M_Reg_Date = "мая";
                    }
                    if (M_Reg_Date2 == "06")
                    {
                        M_Reg_Date = "июня";
                    }
                    if (M_Reg_Date2 == "07")
                    {
                        M_Reg_Date = "июля";
                    }
                    if (M_Reg_Date2 == "08")
                    {
                        M_Reg_Date = "августа";
                    }
                    if (M_Reg_Date2 == "09")
                    {
                        M_Reg_Date = "сентября";
                    }
                    if (M_Reg_Date2 == "10")
                    {
                        M_Reg_Date = "октября";
                    }
                    if (M_Reg_Date2 == "11")
                    {
                        M_Reg_Date = "ноября";
                    }
                    if (M_Reg_Date2 == "12")
                    {
                        M_Reg_Date = "декабря";
                    }

                    ws.Range["B5"].Font.Bold = true;
                    ws.Range["B5"].Value = "«" + Day_Share + "» " + Month_Share + " " + Year_Share + "  года                                    г. Алматы                                                    № " + Num;
                    //ws.Range["E5"].Font.Bold = true;
                 //   ws.Range["E5"].Value =  "№ " + Num;
                    //ws.Range["B8"].Font.Bold = false;
                    ws.Range["B8"].Value = Name_Jur_Person + ",    юридический     адрес: " + Address + ", зарегистрированного  " + Name + "  " + D_Reg_Date + " " + M_Reg_Date + " " + Y_Reg_Date + " г.   за  № " + Num1 + ".";
                    ws.Range["B9"].Value = "             Выпуск внесен в Государственный реестр эмиссионных ценных бумаг за номером " + Num + ".";
                    ws.Range["B10"].Value = "Выпуск разделен на " /*+ Cnt*/  + Name1 + ".";
                   // ws.Range["B15"].Value = Name2 + " в количестве " + Cnt1 + " (____________________), ";
                    ws.Range["B11"].Value = "          Выпуск аннулирован в связи с " + Comments;
                    ws.Range["B14"].Value = "Председатель           " + Chairman;
                }
                else if (language == LanguageIds.Kazakh)
                {
                    ws.Range["B5"].Font.Bold = true;
                    ws.Range["B5"].Value = "«" + Day_Share + "» " + Month_Share + " " + Year_Share + "  года                                    г. Алматы                                                    № " + Num;
                    //ws.Range["E5"].Font.Bold = true;
                    //   ws.Range["E5"].Value =  "№ " + Num;
                    //ws.Range["B8"].Font.Bold = false;
                    ws.Range["B8"].Value = Name_Jur_Person + ",    юридический     адрес: " + Address + ", зарегистрированного  " + Name + "  " + D_Reg_Date + " " + M_Reg_Date + " " + Y_Reg_Date + " г.   за  № " + Num1 + ".";
                    ws.Range["B9"].Value = "             Выпуск внесен в Государственный реестр эмиссионных ценных бумаг за номером " + Num + ".";
                    ws.Range["B10"].Value = "Выпуск разделен на " /*+ Cnt*/  + Name1;
                    // ws.Range["B15"].Value = Name2 + " в количестве " + Cnt1 + " (____________________), ";
                    ws.Range["B11"].Value = "          Выпуск аннулирован в связи с " + Comments;
                    ws.Range["B14"].Value = "Председатель           " + Chairman;
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