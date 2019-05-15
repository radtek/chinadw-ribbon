using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors;
using System.Drawing;

/*
 Author: Tolebi Baimenov
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordAnnulRegShare : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected string firstName, lastName, D_Reg_Date, M_Reg_Date, M_Reg_Date2, Y_Reg_Date;
        protected string Name_Jur_Person, Address, Num, Num1, Day_Share, Month_Share, Month_Share2, Year_Share, Name, Name1, Cnt, Name2, Cnt1, Comments, Chairman;
        protected string SMonthYear, SNameJurPerson, SNum, SName1, SComments, SChairman, SCategoryTextOrd,SCategoryTextPref, SNinText, dividedname, dividedcount, dividednin, SNumText, SFromText, SDateReg, SRegName, SNameText, NameCategoryOrg,
                         NameCountOrg, NameCategoryPref, NameCountPref, numshare, date_annul, bin, isin, day_reg, month_reg, year_reg, month_reg_t, datereg, yeartext;
        protected decimal? idShare;
        public RepWordAnnulRegShare(RepForm form, LanguageIds language, decimal? idShare)
            : base(form, language)
        {
            this.form = form;
            this.idShare = idShare;
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
                cmd.Parameters.Add("name_category_org_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("name_count_org_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("name_category_pref_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("name_count_pref_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Annul_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Bin_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Isin_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Day_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Month_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Year_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters["Id_Share_"].Value = idShare;
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
                cmd.Parameters["name_category_org_"].Size = 4000;
                cmd.Parameters["name_count_org_"].Size = 4000;
                cmd.Parameters["name_category_pref_"].Size = 4000;
                cmd.Parameters["name_count_pref_"].Size = 4000;
                cmd.Parameters["Num_Share_"].Size = 4000;
                cmd.Parameters["Date_Annul_"].Size = 4000;
                cmd.Parameters["Bin_"].Size = 4000;
                cmd.Parameters["Isin_"].Size = 4000;
                cmd.Parameters["Day_Reg_"].Size = 4000;
                cmd.Parameters["Month_Reg_"].Size = 4000;
                cmd.Parameters["Year_Reg_"].Size = 4000;
                cmd.ExecuteNonQuery();


                day_reg = cmd.Parameters["Day_Reg_"].Value.ToString();
                if (day_reg == "null")
                {
                    day_reg = string.Empty;
                }
                month_reg = cmd.Parameters["Month_Reg_"].Value.ToString();
                if (month_reg == "null")
                {
                    month_reg = string.Empty;
                }

                year_reg = cmd.Parameters["Year_Reg_"].Value.ToString();
                if (year_reg == "null")
                {
                    year_reg = string.Empty;
                }
                
                date_annul = cmd.Parameters["Date_Annul_"].Value.ToString();
                if (date_annul == "null")
                {
                    date_annul = string.Empty;
                }
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

                NameCategoryOrg = cmd.Parameters["name_category_org_"].Value.ToString();
                if (NameCategoryOrg == "null")
                {
                    NameCategoryOrg = string.Empty;
                }

                NameCountOrg = cmd.Parameters["name_count_org_"].Value.ToString();
                if (NameCountOrg == "null")
                {
                    NameCountOrg = string.Empty;
                }
                NameCategoryPref = cmd.Parameters["name_category_pref_"].Value.ToString();
                if (NameCategoryPref == "null")
                {
                    NameCategoryPref = string.Empty;
                }

                NameCountPref = cmd.Parameters["name_count_pref_"].Value.ToString();
                if (NameCountPref == "null")
                {
                    NameCountPref = string.Empty;
                }
                numshare = cmd.Parameters["Num_Share_"].Value.ToString();
                if (numshare == "null")
                {
                    numshare = string.Empty;
                }
                bin = cmd.Parameters["Bin_"].Value.ToString();
                if (bin == "null")
                {
                    bin = string.Empty;
                }
                isin = cmd.Parameters["Isin_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
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
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
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
            }
            else
            {
                if (Month_Share2 == "01")
                {
                    Month_Share = "Қаңтар";
                }
                if (Month_Share2 == "02")
                {
                    Month_Share = "Ақпан";
                }
                if (Month_Share2 == "03")
                {
                    Month_Share = "Наурыз";
                }
                if (Month_Share2 == "04")
                {
                    Month_Share = "Сәуір";
                }
                if (Month_Share2 == "05")
                {
                    Month_Share = "Мамыр";
                }
                if (Month_Share2 == "06")
                {
                    Month_Share = "Маусым";
                }
                if (Month_Share2 == "07")
                {
                    Month_Share = "Шілде";
                }
                if (Month_Share2 == "08")
                {
                    Month_Share = "Тамыз";
                }
                if (Month_Share2 == "09")
                {
                    Month_Share = "Қыркүйек";
                }
                if (Month_Share2 == "10")
                {
                    Month_Share = "Қазан";
                }
                if (Month_Share2 == "11")
                {
                    Month_Share = "Қараша";
                }
                if (Month_Share2 == "12")
                {
                    Month_Share = "Желтоқсан";
                }
            }
            if (language == LanguageIds.Russian)
            {
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
            }
            else
            {
                if (M_Reg_Date2 == "01")
                {
                    M_Reg_Date = "Қаңтар";
                }
                if (M_Reg_Date2 == "02")
                {
                    M_Reg_Date = "Ақпан";
                }
                if (M_Reg_Date2 == "03")
                {
                    M_Reg_Date = "Наурыз";
                }
                if (M_Reg_Date2 == "04")
                {
                    M_Reg_Date = "Сәуір";
                }
                if (M_Reg_Date2 == "05")
                {
                    M_Reg_Date = "Мамыр";
                }
                if (M_Reg_Date2 == "06")
                {
                    M_Reg_Date = "Маусым";
                }
                if (M_Reg_Date2 == "07")
                {
                    M_Reg_Date = "Шілде";
                }
                if (M_Reg_Date2 == "08")
                {
                    M_Reg_Date = "Тамыз";
                }
                if (M_Reg_Date2 == "09")
                {
                    M_Reg_Date = "Қыркүйек";
                }
                if (M_Reg_Date2 == "10")
                {
                    M_Reg_Date = "Қазан";
                }
                if (M_Reg_Date2 == "11")
                {
                    M_Reg_Date = "Қараша";
                }
                if (M_Reg_Date2 == "12")
                {
                    M_Reg_Date = "Желтоқсан";
                }
            }
            /*--------------------*/
            if (language == LanguageIds.Russian)
            {
                if (month_reg == "01")
                {
                    month_reg_t = "января";
                }
                if (month_reg == "02")
                {
                    month_reg_t = "февраля";
                }
                if (month_reg == "03")
                {
                    month_reg_t = "марта";
                }
                if (month_reg == "04")
                {
                    month_reg_t = "апреля";
                }
                if (month_reg == "05")
                {
                    month_reg_t = "мая";
                }
                if (month_reg == "06")
                {
                    month_reg_t = "июня";
                }
                if (month_reg == "07")
                {
                    month_reg_t = "июля";
                }
                if (month_reg == "08")
                {
                    month_reg_t = "августа";
                }
                if (month_reg == "09")
                {
                    month_reg_t = "сентября";
                }
                if (month_reg == "10")
                {
                    month_reg_t = "октября";
                }
                if (month_reg == "11")
                {
                    month_reg_t = "ноября";
                }
                if (month_reg == "12")
                {
                    month_reg_t = "декабря";
                }
            }
            else
            {
                if (month_reg == "01")
                {
                    month_reg_t = "Қаңтар";
                }
                if (month_reg == "02")
                {
                    month_reg_t = "Ақпан";
                }
                if (month_reg == "03")
                {
                    month_reg_t = "Наурыз";
                }
                if (month_reg == "04")
                {
                    month_reg_t = "Сәуір";
                }
                if (month_reg == "05")
                {
                    month_reg_t = "Мамыр";
                }
                if (month_reg == "06")
                {
                    month_reg_t = "Маусым";
                }
                if (month_reg == "07")
                {
                    month_reg_t = "Шілде";
                }
                if (month_reg == "08")
                {
                    month_reg_t = "Тамыз";
                }
                if (month_reg == "09")
                {
                    month_reg_t = "Қыркүйек";
                }
                if (month_reg == "10")
                {
                    month_reg_t = "Қазан";
                }
                if (month_reg == "11")
                {
                    month_reg_t = "Қараша";
                }
                if (month_reg == "12")
                {
                    month_reg_t = "Желтоқсан";
                }
            }
            if (language == LanguageIds.Russian)
            {
                yeartext = " года.";
                SMonthYear = "«_____»_______ 20___ года";
            }
            else
            {
                yeartext = " жылы.";
                SMonthYear = "20 __ жылғы «___» ________";
            }
                //SMonthYear = "«" + Day_Share + "» " + Month_Share + " " + Year_Share;// +"  года                                    г. Алматы                                                    № " + Num;
                SNameJurPerson = Name_Jur_Person;// +",    юридический     адрес: " + Address + ", зарегистрированного  " + Name + "  " + D_Reg_Date + " " + M_Reg_Date + " " + Y_Reg_Date + " г.   за  № " + Num1 + ".";
              if (language == LanguageIds.Russian)
                SRegName = "зарегистрированного ";// ", зарегистрированного  " + Name + "  " + D_Reg_Date + " " + M_Reg_Date + " " + Y_Reg_Date + " г.   за  № " + Num1 + ".";
              else
                  SRegName = "акционерлік қоғамды мемлекеттік тіркеу ";
            
                SNumText = "за № ";
                SDateReg = D_Reg_Date + " " + M_Reg_Date + " " + Y_Reg_Date;
                SNameText = Name + " "+SDateReg+" ";
                SCategoryTextOrd = "в количестве ";
                SCategoryTextPref = "в количестве ";
                SNum = "Выпуск внесен в Государственный реестр эмиссионных ценных бумаг за номером ";// +Num + ".";
                SName1 = "Выпуск разделен на " /*+ Cnt*/ ;// +Name1;// +".";
                SComments = "Выпуск аннулирован в связи с ";// +Comments;
                SChairman = Chairman;                
                datereg = day_reg + " " + month_reg_t + " " + year_reg + yeartext;
           /* }
            else
            {
                       
            }*/
            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));
                
                wordDoc =
                  wordApp.Documents.Open(path, ref varMissing,
                    false,
                    ref varMissing, ref varMissing, ref varMissing, ref varMissing,
                    ref varMissing, ref varMissing, ref varMissing,
                    ref varMissing, ref varMissing, ref varMissing, ref varMissing,
                    ref varMissing, ref varMissing);

                wordDoc.Activate();               
               
                FindAndReplace(wordApp, "${Num}",Num);
                FindAndReplace(wordApp, "${NameJurPerson}",Name_Jur_Person);
                FindAndReplace(wordApp, "${Adress}",Address);
                FindAndReplace(wordApp, "${TRegName}",SRegName);
                FindAndReplace(wordApp, "${NameText}" ,SNameText);
                FindAndReplace(wordApp, "${TNumText}",SNumText);
                FindAndReplace(wordApp, "${Num1}",Num1);
                FindAndReplace(wordApp, "${TNum}",SNum);                
                FindAndReplace(wordApp, "${TName1}",SName1);
                FindAndReplace(wordApp, "${NameCountOrd}" ,NameCountOrg);
                FindAndReplace(wordApp, "${NameCategoryOrd}",NameCategoryOrg);
                FindAndReplace(wordApp, "${NameCountPref}", NameCountPref);
                FindAndReplace(wordApp, "${NameCategoryPref}", NameCategoryPref);
                FindAndReplace(wordApp, "${TComments}",SComments);
                FindAndReplace(wordApp, "${Comments}",Comments);
                FindAndReplace(wordApp, "${SDateReg}", datereg);
                FindAndReplace(wordApp, "${TChairman}", SChairman);
                FindAndReplace(wordApp, "${Chairman}", Chairman);
                FindAndReplace(wordApp, "${MonthYear}", SMonthYear);
                FindAndReplace(wordApp, "${DateAnnul}", SMonthYear);
                FindAndReplace(wordApp, "${TBIN}", bin);
                FindAndReplace(wordApp, "${ISIN}", isin);

                FindAndReplace(wordApp, "${CategoryTextOrd}", SCategoryTextOrd);
                FindAndReplace(wordApp, "${CategoryTextPref}", SCategoryTextPref);
                FindAndReplace(wordApp, "${NumShare}", numshare);
                wordDoc.Save();                               
            }
            catch (Exception varE)
            {
                EndFillReport();            
                MessageBox.Show("Error:\n" + varE.Message, "Error message");                
            }
            finally
            {
                EndFillReport();
            }
        }
    }
}