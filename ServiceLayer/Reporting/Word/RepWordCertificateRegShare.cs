using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using Oracle.DataAccess.Types;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Oracle.DataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors;
using System.Drawing;

/*
 Author: Tolebi Baimenov
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordCertificateRegShare : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idShare;
        protected string numGosReg, dayCer, monthCer, monthCer2, monthCerKz, yearCer, nameJurPerson, address, name;
        protected string num, dayShare, monthShare, monthShare2, monthShareKz, yearShare, count, NIN, num2, comm, chairman, CertificateName, SMonthYear, SnumGosReg, SNameJurPerson, SRegName, SDivided;
        protected string SNum, SComm, SChairman, SCategoryText, SNinText, dividednameord, dividedcountord, dividednamepref, dividedcountpref, dividednin, SNumText, SFromText, SDateReg, SCategoryTextOrd, SCategoryTextPref;
        public RepWordCertificateRegShare(RepForm form, LanguageIds language, decimal? idShare)
            : base(form, language)
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
                cmd.Parameters.Add("dividedname_ord_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("dividedcount_ord_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("dividedname_pref_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("dividedcount_pref_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("dividednin_", OracleDbType.Varchar2, ParameterDirection.Output);
                
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

                cmd.Parameters["dividedname_ord_"].Size = 4000;
                cmd.Parameters["dividedcount_ord_"].Size = 4000;
                cmd.Parameters["dividedname_pref_"].Size = 4000;
                cmd.Parameters["dividedcount_pref_"].Size = 4000;
                cmd.Parameters["dividednin_"].Size = 4000;
                cmd.Parameters["Count_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Num2_"].Size = 4000;
                cmd.Parameters["Comm_"].Size = 4000;
                cmd.Parameters["Chairman_"].Size = 4000;
                cmd.ExecuteNonQuery();

                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
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
                dividednameord = cmd.Parameters["dividedname_ord_"].Value.ToString();
                if (dividednameord == "null")
                {
                    dividednameord = string.Empty;
                }
                dividedcountord = cmd.Parameters["dividedcount_ord_"].Value.ToString();
                if (dividedcountord == "null")
                {
                    dividedcountord = string.Empty;
                }
                dividednamepref = cmd.Parameters["dividedname_pref_"].Value.ToString();
                if (dividednamepref == "null")
                {
                    dividednamepref = string.Empty;
                }
                dividedcountpref = cmd.Parameters["dividedcount_pref_"].Value.ToString();
                if (dividedcountpref == "null")
                {
                    dividedcountpref = string.Empty;
                }
                dividednin = cmd.Parameters["dividednin_"].Value.ToString();
                if (dividednin == "null")
                {
                    dividednin = string.Empty;
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
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
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
                SMonthYear = string.Empty;
                //SnumGosReg = numGosReg;                
                SMonthYear = "«" + dayCer + "» " + monthCer + " " + yearCer;// //" года                            г. Алматы                                               № " + num;
                SNameJurPerson = nameJurPerson;// +", юридический адрес: " + address;
                SRegName = "зарегистрированного "; //+name + "№ " + num2 + "от «" + dayShare + "» " + monthShare + yearShare + "г.";
                SNumText = "№";
                SFromText = "от";
                SDateReg = "«" + dayShare + "» " + monthShare + " " + yearShare;
                if (dividedcountord != string.Empty)
                    SCategoryTextOrd = "в количестве";
                if (dividedcountpref != string.Empty)
                    SCategoryTextPref = "в количестве";
                SNinText = "которым присвоен национальный идентификационный номер ";
                SDivided = "Выпуск разделен на "; //;+ divided;
                SNum = "Выпуск внесен в Государственный реестр эмиссионных ценных бумаг за номером ";// +num + ".";
                SComm = "Дополнительная информация о выпуске: ";// +comm;
                SChairman = "Председатель ";// +chairman;  
            }
            else
            {
                #region
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
                #endregion
                SMonthYear = string.Empty;
                SMonthYear = "«" + dayCer + "» " + monthCerKz + " " + yearCer;// +"  жыл                                Алматы қ.                                                        № " + num;                
                SNameJurPerson = "шығарылымының мемлекеттік тіркеуін жүргізді ";// +nameJurPerson + ",   заңды мекен-жайы: " + address;
                SRegName = "тіркелген ";// +name + "  №  " + num2 + "  «" + dayShare + "»  " + monthShareKz + "  " + yearShare + " ж.";
                SNumText = "№ ";
                SFromText = "бастап ";
                SDateReg = "«" + dayShare + "» " + monthShare + " " + yearShare;
                if (dividedcountord != string.Empty)
                    SCategoryTextOrd = "саны";
                if (dividedcountpref != string.Empty)
                    SCategoryTextPref = "саны";                
                SNinText = "Ұлттық бірегейлендіру нөмірі берілді ";
                SDivided = "Шығарылым бөлінген ";///*+ count*/ +divided;                
                SNum = "Шығарылым мына нөмірмен эмиссиялық қағаздардың Мемлекеттік тізіліміне енгізілген ";// + num;
                SComm = "Шығарылым туралы қосымша ақпарат: ";// +comm;
                SChairman = "Төраға ";// +chairman;
                
            }
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

                FindAndReplace(wordApp, "${NumGosReg}", numGosReg);
                FindAndReplace(wordApp, "${MonthYear}", SMonthYear);
                FindAndReplace(wordApp, "${NameJurPerson}", SNameJurPerson);
                FindAndReplace(wordApp, "${RegName}", SRegName);                
                FindAndReplace(wordApp, "${Num}", num);
                FindAndReplace(wordApp, "${Comm}", comm);
                FindAndReplace(wordApp, "${TDivided}", SDivided);
                FindAndReplace(wordApp, "${TCategoryTextOrd}", SCategoryTextOrd);
                FindAndReplace(wordApp, "${TCategoryTextPref}", SCategoryTextPref);
                FindAndReplace(wordApp, "${DividedNameOrd}", dividednameord);                
                FindAndReplace(wordApp, "${DividedCountOrd}", dividedcountord);
                FindAndReplace(wordApp, "${DividedNamePref}", dividednamepref);
                FindAndReplace(wordApp, "${DividedCountPref}", dividedcountpref);
                FindAndReplace(wordApp, "${TNinText}", SNinText);
                FindAndReplace(wordApp, "${DividedNin}", dividednin);
                FindAndReplace(wordApp, "${TNum}", SNum);
                FindAndReplace(wordApp, "${Num}", num);
                FindAndReplace(wordApp, "${TComm}", SComm);
                FindAndReplace(wordApp, "${Comm}", comm);
                FindAndReplace(wordApp, "${Chairman}", SChairman);
                FindAndReplace(wordApp, "${TName}", name);

                FindAndReplace(wordApp, "${Adress}", address);
                FindAndReplace(wordApp, "${TRegName}", SRegName);
                FindAndReplace(wordApp, "${Name}", name);
                FindAndReplace(wordApp, "${TNumText}", SNumText);
                FindAndReplace(wordApp, "${Num2}", num2);
                FindAndReplace(wordApp, "${TFromText}", SFromText);
                FindAndReplace(wordApp, "${DateReg}", SDateReg);               
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