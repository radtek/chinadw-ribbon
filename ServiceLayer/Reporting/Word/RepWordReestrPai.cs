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
    public class RepWordReestrPai : GeneralWordReport
    {
        protected decimal idPai;
       // protected string NameFundKnd1, NameFund1;
        protected string NameFundKnd, NameFund, NameJurPerson, NameRegion, Address, OKPO, BIN, Managenum, NameSts, Datereg, Num, Period, Price, NIN, Condtion, Status;
        protected string NameCustadion,NumLicenseCustodian,CustDate,NameRegistrars,Licensenumber,LicenseDate,Shariatcom,DateClose,Comments,RegPai, NameManage;
#pragma warning disable CS0108 // 'RepWordReestrPai.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'RepWordReestrPai.wordparagraph' is never used
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0169 // The field 'RepWordReestrPai.wordparagraph' is never used
#pragma warning restore CS0108 // 'RepWordReestrPai.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        public Document wordDoc;
        protected Decimal languageId;
        protected int coloumn;                
        protected string[] template = new string[10];    
        protected string SNameFundKnd, SNameFund, SNameJurPerson, SNameRegion, SAddress, SOKPO, SBIN, SManagenum, SNameSts, SDatereg, SNum, SPeriod, SPrice, SNIN, SCondtion, SStatus, SRegNationalBank;
        protected string SNameCustadion, SNumLicenseCustodian, SCustDate, SNameRegistrars, SLicensenumber, SLicenseDate, SShariatcom, SDateClose, SComments, SRegPai, SPaiName, STableName1, STableName2;
        protected string SYearNum, SYear, SFrom, namecurrency, SNameManage;
        public RepWordReestrPai(RepForm form, LanguageIds language, decimal idPai)
            : base(form, language)
        {
            this.idPai = idPai;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REESTR_PAI";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Name_Fundknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Fund_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Jur_Person_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("OKPO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Managenum_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Sts_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Datereg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Condtion_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Status_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Custadion_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_License_Custodian_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Custdate_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Registrars_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("License_number_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("License_date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Shariatcom_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Dateclose_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Pai_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Manage_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Currency_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idPai;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Name_Fundknd_"].Size = 4000;
                cmd.Parameters["Name_Fund_"].Size = 4000;
                cmd.Parameters["Name_Jur_Person_"].Size = 4000;
                cmd.Parameters["Name_Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["OKPO_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["Managenum_"].Size = 4000;
                cmd.Parameters["Name_Sts_"].Size = 4000;
                cmd.Parameters["Datereg_"].Size = 4000;
                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["Period_"].Size = 4000;
                cmd.Parameters["Price_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Condtion_"].Size = 4000;
                cmd.Parameters["Status_"].Size = 4000;
                cmd.Parameters["Name_Custadion_"].Size = 4000;
                cmd.Parameters["Num_License_Custodian_"].Size = 4000;
                cmd.Parameters["Custdate_"].Size = 4000;
                cmd.Parameters["Name_Registrars_"].Size = 4000;
                cmd.Parameters["License_number_"].Size = 4000;
                cmd.Parameters["License_date_"].Size = 4000;
                cmd.Parameters["Shariatcom_"].Size = 4000;
                cmd.Parameters["Dateclose_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Reg_Pai_"].Size = 4000;
                cmd.Parameters["Manage_Name_"].Size = 4000;
                cmd.Parameters["Name_Currency_"].Size = 4000;

                cmd.ExecuteNonQuery();

                NameFundKnd = cmd.Parameters["Name_Fundknd_"].Value.ToString();
                if (NameFundKnd == "null")
                {
                    NameFundKnd = string.Empty;
                }
                NameFund = cmd.Parameters["Name_Fund_"].Value.ToString();
                if (NameFund == "null")
                {
                    NameFund = string.Empty;
                }
                NameJurPerson = cmd.Parameters["Name_Jur_Person_"].Value.ToString();
                if (NameJurPerson == "null")
                {
                    NameJurPerson = string.Empty;
                }
                NameRegion = cmd.Parameters["Name_Region_"].Value.ToString();
                if (NameRegion == "null")
                {
                    NameRegion = string.Empty;
                }
                Address = cmd.Parameters["Address_"].Value.ToString();
                if (Address == "null")
                {
                    Address = string.Empty;
                }
                OKPO = cmd.Parameters["OKPO_"].Value.ToString();
                if (OKPO == "null")
                {
                    OKPO = string.Empty;
                }
                BIN = cmd.Parameters["BIN_"].Value.ToString();
                if (BIN == "null")
                {
                    BIN = string.Empty;
                }
                Managenum = cmd.Parameters["Managenum_"].Value.ToString();
                if (Managenum == "null")
                {
                    Managenum = string.Empty;
                }
                NameSts = cmd.Parameters["Name_Sts_"].Value.ToString();
                if (NameSts == "null")
                {
                    NameSts = string.Empty;
                }
                Datereg = cmd.Parameters["Datereg_"].Value.ToString();
                if (Datereg == "null")
                {
                    Datereg = string.Empty;
                }
                Num = cmd.Parameters["Num_"].Value.ToString();
                if (Num == "null")
                {
                    Num = string.Empty;
                }
                Period = cmd.Parameters["Period_"].Value.ToString();
                if (Period == "null")
                {
                    Period = string.Empty;
                }
                Price = cmd.Parameters["Price_"].Value.ToString();
                if (Price == "null")
                {
                    Price = string.Empty;
                }
                NIN = cmd.Parameters["NIN_"].Value.ToString();
                if (NIN == "null")
                {
                    NIN = string.Empty;
                }
                Condtion = cmd.Parameters["Condtion_"].Value.ToString();
                if (Condtion == "null")
                {
                    Condtion = string.Empty;
                }
                Status = cmd.Parameters["Status_"].Value.ToString();
                if (Status == "null")
                {
                    Status = string.Empty;
                }
                NameCustadion = cmd.Parameters["Name_Custadion_"].Value.ToString();
                if (NameCustadion == "null")
                {
                    NameCustadion = string.Empty;
                }
                NumLicenseCustodian = cmd.Parameters["Num_License_Custodian_"].Value.ToString();
                if (NumLicenseCustodian == "null")
                {
                    NumLicenseCustodian = string.Empty;
                }
                CustDate = cmd.Parameters["Custdate_"].Value.ToString();
                if (CustDate == "null")
                {
                    CustDate = string.Empty;
                }

                NameRegistrars = cmd.Parameters["Name_Registrars_"].Value.ToString();
                if (NameRegistrars == "null")
                {
                    NameRegistrars = string.Empty;
                }
                Licensenumber = cmd.Parameters["License_number_"].Value.ToString();
                if (Licensenumber == "null")
                {
                    Licensenumber = string.Empty;
                }
                LicenseDate = cmd.Parameters["License_date_"].Value.ToString();
                if (LicenseDate == "null")
                {
                    LicenseDate = string.Empty;
                }
                Shariatcom = cmd.Parameters["Shariatcom_"].Value.ToString();
                if (Shariatcom == "null")
                {
                    Shariatcom = string.Empty;
                }
                DateClose = cmd.Parameters["Dateclose_"].Value.ToString();
                if (DateClose == "null")
                {
                    DateClose = string.Empty;
                }
                Comments = cmd.Parameters["Comments_"].Value.ToString(); ;
                if (Comments == "null")
                {
                    Comments = string.Empty;
                }
                RegPai = cmd.Parameters["Reg_Pai_"].Value.ToString();
                if (RegPai == "null")
                {
                    RegPai = string.Empty;
                }
                NameManage = cmd.Parameters["Manage_Name_"].Value.ToString();
                if (NameManage == "null")
                {
                    NameManage = string.Empty;
                }
                namecurrency = cmd.Parameters["Name_Currency_"].Value.ToString();
                if (namecurrency == "null")
                {
                    namecurrency = string.Empty;
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
        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_RESULTS_PAI_PLA";
                cmd.Parameters.Add("Id_Pai_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_Pai_"].Value = idPai;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;
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
                cmd.CommandText = "G_REP_INF_OWNERS_PAI_PLA";
                cmd.Parameters.Add("Id_Pai_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_Pai_"].Value = idPai;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt2);
                }

                return dt2;
            }
        }
        
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
            if (language == LanguageIds.Russian)
            {
                SPaiName = "Реестр паев";
                SNameFundKnd = "Вид Фонда " ;              
                SNameFund = "Наименование фонда ";
                SNameRegion = "Область " ;
                SAddress = "Адрес " ;
                SOKPO = "ОКПО " ;
                SBIN = "БИН " ;
                SManagenum = "Лицензия на управление инвестиционным портфелем: № ";
                SRegNationalBank = "Выпуск зарегистрирован Национальный Банк Республики Казахстан ";                
                SPeriod = "Срок обращения: " ;
                SPrice = "Номинальная стоимость пая: ";
                //STenge = "тенге ";
                SFrom = "от ";
                SYear = "г. ";
                SYearNum = "г. за № ";
                SNIN = "НИН: ";
                SCondtion = "Условия начала размещения паев: " ;
                SStatus = "Состояние размещения паев на " ;
                SNameCustadion = "Кастодиан: " ;
                SNumLicenseCustodian = "Лицензия на осуществление кастодианской деятельности: № " ;                
                SNameRegistrars = "Регистратор: " ;
                SLicensenumber = "Лицензия на осуществление деятельности по ведению системы держателей ЦБ: № " ;
                SShariatcom = "Сведения о совете по шариату: " ;
                SDateClose = "Дата закрытия фонда: " ;
                SComments = "Примечание: ";
                SRegPai = "Выпуск зарегистрировал: " ;
                STableName1 = "Отчеты об итогах размещения паев";
                SNameManage = "наименование управляющей компании";
                STableName2 = "Сведения о собственниках паев на дату окончания размещения паев";
                template[0] = "Вид отчета";
                template[1] = "Дата утверждения (принятия к сведению)";
                template[2] = "Период размещения паев";
                template[3] = "Количество размещенных паев за период";
                template[4] = "Сумма денег поступившая в оплату паев за отчетный период";
                template[5] = "Стоимость чистых активов Фонда на дату размещения";

                template[6] = "Категория собственников паев";
                template[7] = "Количество собственников";
                template[8] = "Из них нерезидентов";
                template[9] = "Количество размещенных паев";     
            }
            else
            {
                SPaiName = "ПАЙЛАР ТІЗІЛІМІ";
                SNameFundKnd = "Қор түрі " ;
                SNameFund = "Қордың атауы " ;
                SNameRegion = "Облыс ";
                SAddress = "Мекен - жай ";
                SOKPO = "КҰЖС ";
                SBIN = "БСН ";
                SManagenum = "Инвестициялық портфельді басқарудың лицензиясы: № " ;
                SRegNationalBank = "Шығарылым тіркелінді Қазақстан Республикасының Ұлттық Банкі ";
                SPeriod = "Айналым мерзімі: " ;
                SPrice = "Номиналды құны: ";
                SNIN = "ҰБН: " ;
                SCondtion = "Пайлар орналастырудың бастапқы шарттары: " ;
                SStatus = "Орналасу күйі ";
                SNameCustadion = "Кастодиан: ";
                SNumLicenseCustodian = "Кастодиан қызметті іске асыруға берілген лицензия: № " ;
                SNameRegistrars = "Регистратор: ";
                SLicensenumber = "БҚ ұстаушылар жүйесіндегі қызметті іске асыруға берілген лицензия: № " ;
                SShariatcom = "Шариат кеңесі: ";
                SDateClose = "ИПҚ жабылуы күнi: " ;
                SComments = "Қосымша: ";
                SRegPai = "Шығарылымды тіркеген: ";
                //STenge = "тенге ";
                SFrom = "мына күннен ";
                SYear = "ж. ";
                SYearNum = "ж. № ";
                SNameManage = "басқарушы компанияның атауы";

                STableName1 = "Пайларды орналастырудың қорытынды есебі";
                STableName2 = "Орналастыру сонғы күніне жекеменшік пайлар мәліметі";
                template[0] = "Есеп түрі";
                template[1] = "Бекітілген күн (мәліметке алу)";
                template[2] = "Орналастыру кезені";
                template[3] = "Кезең бойынша орналасқан пайлар саны";                
                template[4] = "Қорытынды кезең бойынша пайларды төлеуге түскен қаражат соммасы";
                template[5] = "Орналастыру күніне қордың таза активтерінің құны";

                template[6] = "Жекеменшік пайлар категориясы";
                template[7] = "Жекеменшіктер саны";
                template[8] = "Резидент еместердің саны";
                template[9] = "Орналасқан пайлар саны";                
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

                FindAndReplace(wordApp, "${PaiName}", SPaiName);
                FindAndReplace(wordApp, "${NameFundKnd}", SNameFundKnd);
                FindAndReplace(wordApp, "${TNameFundKnd}", NameFundKnd);
                FindAndReplace(wordApp, "${NameFund}", SNameFund);
                FindAndReplace(wordApp, "${TNameFund}", NameFund);
                FindAndReplace(wordApp, "${NameJurPerson}", SNameJurPerson);
                FindAndReplace(wordApp, "${TNameJurPerson}", NameJurPerson);
                FindAndReplace(wordApp, "${NameRegion}", SNameRegion);
                FindAndReplace(wordApp, "${TNameRegion}", NameRegion);
                FindAndReplace(wordApp, "${RegNationalBank}", SRegNationalBank);
                FindAndReplace(wordApp, "${TDatereg}", Datereg);
                FindAndReplace(wordApp, "${TYearNum}", SYearNum);
             //   FindAndReplace(wordApp, "${TNum}", SNum);
                FindAndReplace(wordApp, "${Address}", SAddress);
                FindAndReplace(wordApp, "${TAddress}", Address);
                FindAndReplace(wordApp, "${OKPO}", SOKPO);
                FindAndReplace(wordApp, "${TOKPO}", OKPO);
                FindAndReplace(wordApp, "${BIN}", SBIN);
                FindAndReplace(wordApp, "${TBIN}", BIN);
                FindAndReplace(wordApp, "${Managenum}", SManagenum);
                FindAndReplace(wordApp, "${TManagenum}", Managenum);
                FindAndReplace(wordApp, "${NameSts}", SNameSts);
                FindAndReplace(wordApp, "${TNameSts}", NameSts);
                FindAndReplace(wordApp, "${Datereg}", SDatereg);                
                FindAndReplace(wordApp, "${Num}", SNum);
                FindAndReplace(wordApp, "${TNum}", Num);
                FindAndReplace(wordApp, "${Period}", SPeriod);
                FindAndReplace(wordApp, "${TPeriod}", Period);
                FindAndReplace(wordApp, "${Price}", Price);
                FindAndReplace(wordApp, "${TPrice}", SPrice);                
                FindAndReplace(wordApp, "${NIN}", SNIN);
                FindAndReplace(wordApp, "${TNIN}", NIN);
                FindAndReplace(wordApp, "${Condtion}", SCondtion);
                FindAndReplace(wordApp, "${TCondtion}", Condtion);
                FindAndReplace(wordApp, "${Status}", SStatus);
                FindAndReplace(wordApp, "${TStatus}", Status);
                FindAndReplace(wordApp, "${NameCustadion}", SNameCustadion);
                FindAndReplace(wordApp, "${TNameCustadion}", NameCustadion);
                FindAndReplace(wordApp, "${NumLicenseCustodian}", SNumLicenseCustodian);
                FindAndReplace(wordApp, "${TNumLicenseCustodian}", NumLicenseCustodian);
                FindAndReplace(wordApp, "${TFrom}", SFrom);
                FindAndReplace(wordApp, "${CustDate}", SCustDate);
                FindAndReplace(wordApp, "${TCustDate}", CustDate);
                FindAndReplace(wordApp, "${NameRegistrars}", SNameRegistrars);
                FindAndReplace(wordApp, "${TNameRegistrars}", NameRegistrars);
                FindAndReplace(wordApp, "${Licensenumber}", SLicensenumber);
                FindAndReplace(wordApp, "${TNumLicensenumber}", Licensenumber);
                FindAndReplace(wordApp, "${LicenseDate}", SLicenseDate);
                FindAndReplace(wordApp, "${TLicenseDate}", LicenseDate);
                FindAndReplace(wordApp, "${Shariatcom}", SShariatcom);
                FindAndReplace(wordApp, "${TShariatcom}", Shariatcom);
                FindAndReplace(wordApp, "${DateClose}", SDateClose);
                FindAndReplace(wordApp, "${TDateClose}", DateClose);
                FindAndReplace(wordApp, "${Comments}", SComments);
                FindAndReplace(wordApp, "${TComments}", Comments);
                FindAndReplace(wordApp, "${RegPai}", SRegPai);
                FindAndReplace(wordApp, "${TRegPai}", RegPai);
                FindAndReplace(wordApp, "${TTenge}", namecurrency);
                FindAndReplace(wordApp, "${TYear}", SYear);
                FindAndReplace(wordApp, "${TYear}", SYear);
                FindAndReplace(wordApp, "${NameManage}", NameManage);
                FindAndReplace(wordApp, "${TNameManage}", SNameManage);       
                
                #region table1
                System.Data.DataTable dt1 = Getcursor1();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 6, 2, STableName1, true,true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[0];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[1];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[2];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[3];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[4];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 6).Range;
                wordcellrange.Text = template[5];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                //for (int col = 0; col < wordtable.Columns.Count; col++)
                //{
                //    wordcellrange = wordtable.Cell(3, col + 1).Range;
                //    wordcellrange.Text = Convert.ToString(col + 1);
                //    wordcellrange.Font.Bold = 1;
                //    wordcellrange.Borders.Enable = 1;
                //}                
                coloumn = 2;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt1.Rows[i]["NAME_REPKND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["DATE_REPORT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["PERIOD"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["COUNT_DEPLOY"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["AMOUNTPERIOD"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt1.Rows[i]["AMOUNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table2

                System.Data.DataTable dt2 = Getcursor2();
                CreateTableWord(wordDoc, dt2.Rows.Count + 2, 4, 3, STableName2, true, true);
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[6];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[7];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[8];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[9];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                //for (int col = 0; col < wordtable.Columns.Count; col++)
                //{
                //    wordcellrange = wordtable.Cell(3, col + 1).Range;
                //    wordcellrange.Text = Convert.ToString(col + 1);
                //    wordcellrange.Font.Bold = 1;
                //    wordcellrange.Borders.Enable = 1;
                //}
                coloumn = 2;
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt2.Rows[i]["NAME_CATEGORY"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;                    
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt2.Rows[i]["COUNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt2.Rows[i]["COUNTNORES"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt2.Rows[i]["COUNTPLC"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
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