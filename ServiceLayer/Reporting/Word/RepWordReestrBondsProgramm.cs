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
    public class RepWordReestrBondsProgramm : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
#pragma warning disable CS0169 // The field 'RepWordReestrBondsProgramm.wordparagraph' is never used
#pragma warning disable CS0108 // 'RepWordReestrBondsProgramm.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0108 // 'RepWordReestrBondsProgramm.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning restore CS0169 // The field 'RepWordReestrBondsProgramm.wordparagraph' is never used
        public Document wordDoc;
        #endregion
        protected decimal? idBond;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regName, regNum, formIssueECB, numSeq, specActiveknd, spec;
        protected string isFinagent, nameBondknd, amount, nameRegistrars, pagentName, holderName, nameAudit, comments, offName, idadvrpm, idpriorred, eventdefault;
        protected string restinfo, regDateUL, dateReg;

        protected string SnameRu, SnameKz, SnameRegion, Saddress, SBIN, SOKPO, SnameULReg, SnumULReg, SregName, SregNum, SformIssueECB, SnumSeq, SspecActiveknd, Sspec;
        protected string SisFinagent, SnameBondknd, Samount, SnameRegistrars, SpagentName, SholderName, SnameAudit, Scomments, SoffName, Sidadvrpm, Sidpriorred, Seventdefault;
        protected string Srestinfo, SregDateUL, SdateReg, SAddInfo, STextTable, TextTable, STextAddInfo;


        protected string TableName1, TableName2, TableName3, TableName6, TableName7, Stext, STextNum, SNumSerial, Sidrest, idrest;
        protected int coloumn;
        protected string[] template = new string[35];
        public RepWordReestrBondsProgramm(RepForm form, LanguageIds language, decimal? idBond)
            : base(form, language)
        {
            this.form = form;
            this.idBond = idBond;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REESTR_BONDS_PROGRAMM";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("Name_Ru_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Kz_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("OKPO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_UL_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Date_UL_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_UL_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Form_Issue_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Seq_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_Activeknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Finagent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Bondknd_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Amount_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Registrars_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Pagent_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Holder_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Audit_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Off_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                //cmd.Parameters.Add("Idrest_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Idadvrpm_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Idpriorred_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Eventdefault_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Restinfo_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Name_Ru_"].Size = 4000;
                cmd.Parameters["Name_Kz_"].Size = 4000;
                cmd.Parameters["Name_Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["OKPO_"].Size = 4000;
                cmd.Parameters["Name_UL_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Date_UL_"].Size = 4000;
                cmd.Parameters["Num_UL_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Name_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Form_Issue_ECB_"].Size = 4000;

                cmd.Parameters["Num_Seq_"].Size = 4000;
                cmd.Parameters["Spec_Activeknd_"].Size = 4000;
                cmd.Parameters["Spec_"].Size = 4000;
                cmd.Parameters["Is_Finagent_"].Size = 4000;
                cmd.Parameters["Name_Bondknd_"].Size = 4000;
                cmd.Parameters["Amount_"].Size = 4000;
                cmd.Parameters["Name_Registrars_"].Size = 4000;
                cmd.Parameters["Holder_Name_"].Size = 4000;
                cmd.Parameters["Pagent_Name_"].Size = 4000;
                cmd.Parameters["Name_Audit_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Off_Name_"].Size = 4000;
                cmd.Parameters["Idadvrpm_"].Size = 4000;
                cmd.Parameters["Idpriorred_"].Size = 4000;
                cmd.Parameters["Eventdefault_"].Size = 4000;
                cmd.Parameters["Restinfo_"].Size = 4000;


                cmd.ExecuteNonQuery();

                nameRu = cmd.Parameters["Name_Ru_"].Value.ToString();
                if (nameRu == "null")
                {
                    nameRu = string.Empty;
                }
                nameKz = cmd.Parameters["Name_Kz_"].Value.ToString();
                if (nameKz == "null")
                {
                    nameKz = string.Empty;
                }
                nameRegion = cmd.Parameters["Name_Region_"].Value.ToString();
                if (nameRegion == "null")
                {
                    nameRegion = string.Empty;
                }
                address = cmd.Parameters["Address_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
                }
                BIN = cmd.Parameters["BIN_"].Value.ToString();
                if (BIN == "null")
                {
                    BIN = string.Empty;
                }
                OKPO = cmd.Parameters["OKPO_"].Value.ToString();
                if (OKPO == "null")
                {
                    OKPO = string.Empty;
                }
                nameULReg = cmd.Parameters["Name_UL_Reg_"].Value.ToString();
                if (nameULReg == "null")
                {
                    nameULReg = string.Empty;
                }
                regDateUL = cmd.Parameters["Reg_Date_UL_"].Value.ToString();
                if (regDateUL == "null")
                {
                    regDateUL = string.Empty;
                }
                numULReg = cmd.Parameters["Num_UL_Reg_"].Value.ToString();
                if (numULReg == "null")
                {
                    numULReg = string.Empty;
                }
                regName = cmd.Parameters["Reg_Name_"].Value.ToString();
                if (regName == "null")
                {
                    regName = string.Empty;
                }
                dateReg = cmd.Parameters["Date_Reg_"].Value.ToString();
                if (dateReg == "null")
                {
                    dateReg = string.Empty;
                }
                regNum = cmd.Parameters["Reg_Num_"].Value.ToString();
                if (regNum == "null")
                {
                    regNum = string.Empty;
                }

                formIssueECB = cmd.Parameters["Form_Issue_ECB_"].Value.ToString();
                if (formIssueECB == "null")
                {
                    formIssueECB = string.Empty;
                }
                numSeq = cmd.Parameters["Num_Seq_"].Value.ToString();
                if (numSeq == "null")
                {
                    numSeq = string.Empty;
                }
                specActiveknd = cmd.Parameters["Spec_Activeknd_"].Value.ToString();
                if (specActiveknd == "null")
                {
                    specActiveknd = string.Empty;
                }
                spec = cmd.Parameters["Spec_"].Value.ToString();
                if (spec == "null")
                {
                    spec = string.Empty;
                }
                isFinagent = cmd.Parameters["Is_Finagent_"].Value.ToString();
                if (isFinagent == "null")
                {
                    isFinagent = string.Empty;
                }
                nameBondknd = cmd.Parameters["Name_Bondknd_"].Value.ToString();
                if (nameBondknd == "null")
                {
                    nameBondknd = string.Empty;
                }

                amount = cmd.Parameters["Amount_"].Value.ToString();
                if (amount == "null")
                {
                    amount = string.Empty;
                }

                nameRegistrars = cmd.Parameters["Name_Registrars_"].Value.ToString();
                if (nameRegistrars == "null")
                {
                    nameRegistrars = string.Empty;
                }
                holderName = cmd.Parameters["Holder_Name_"].Value.ToString();
                if (holderName == "null")
                {
                    holderName = string.Empty;
                }
                restinfo = cmd.Parameters["Restinfo_"].Value.ToString();
                if (restinfo == "null")
                {
                    restinfo = string.Empty;
                }

                pagentName = cmd.Parameters["Pagent_Name_"].Value.ToString();
                if (pagentName == "null")
                {
                    pagentName = string.Empty;
                }
                nameAudit = cmd.Parameters["Name_Audit_"].Value.ToString();
                if (nameAudit == "null")
                {
                    nameAudit = string.Empty;
                }
                comments = cmd.Parameters["Comments_"].Value.ToString();
                if (comments == "null")
                {
                    comments = string.Empty;
                }
                offName = cmd.Parameters["Off_Name_"].Value.ToString();
                if (offName == "null")
                {
                    offName = string.Empty;
                }


                idadvrpm = cmd.Parameters["Idadvrpm_"].Value.ToString();
                if (idadvrpm == "null")
                {
                    idadvrpm = string.Empty;
                }

                idpriorred = cmd.Parameters["Idpriorred_"].Value.ToString();
                if (idpriorred == "null")
                {
                    idpriorred = string.Empty;
                }
                eventdefault = cmd.Parameters["Eventdefault_"].Value.ToString();
                if (eventdefault == "null")
                {
                    eventdefault = string.Empty;
                }
                restinfo = cmd.Parameters["Restinfo_"].Value.ToString();
                if (restinfo == "null")
                {
                    restinfo = string.Empty;
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


        //Отчеты об итогах размещения облигаций: 
        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_BONDS_PROGRAMM";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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

        //Иные выпуски ценных бумаг:
        public System.Data.DataTable Getcursor4()
        {
            System.Data.DataTable dt4 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_OTHER_ISSUES_BOND";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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
                    oda.Fill(dt4);
                }

                return dt4;
            }
        }

        //Примененные ОМВ и санкции
        public System.Data.DataTable Getcursor5()
        {
            System.Data.DataTable dt5 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_OMV_SANCTIONS_BOND";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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
                    oda.Fill(dt5);
                }

                return dt5;
            }
        }

        // Акционеры
        public System.Data.DataTable Getcursor6()
        {
            System.Data.DataTable dt6 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_BONDFOUNDER";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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
                    oda.Fill(dt6);
                }

                return dt6;
            }
        }
        // Должностных лиц
        public System.Data.DataTable Getcursor7()
        {
            System.Data.DataTable dt7 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_BONDINFOOFF";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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
                    oda.Fill(dt7);
                }

                return dt7;
            }
        }

        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
             
            
                if (language == LanguageIds.Russian)
                {
                    #region TextRu
                    Stext = "ОБЛИГАЦИОННАЯ ПРОГРАММА";
                    SnameRu = "Наименование на рус ";// +nameRu;
                    SnameKz = "Наименование на каз ";//+nameKz;
                    SnameRegion = "Область";//+ nameRegion;
                    Saddress = "Адрес   ";//+ address;
                    SBIN = "БИН";//+ BIN;
                    SOKPO = "ОКПО";//+ OKPO;
                    SnameULReg = "Регистрация ЮЛ";// + nameULReg + "  " + regDateUL;
                    SnumULReg = "за №";//+ numULReg;
                    SregName = "Выпуск зарегистрирован";//+ regName + "  " + dateReg;
                    SregNum = "за №";//+ regNum;
                    SformIssueECB = "Форма выпуска";//+ formIssueECB;
                    //ws.Range["D11"].Value = numSeq;
                    SspecActiveknd = "Специализация по виду деятельности: ";// + specActiveknd;
                    Sspec = "Специализация: ";// + spec;                    
                    Samount = "Объем выпуска";//+amount;                                        
                    SnameRegistrars = "Регистратор";//+nameRegistrars;                    
                    SpagentName = "Платежный агент";//+pagentName;                    
                    SholderName = "Представительдержателя облигаций";//+holderName;     
                    SisFinagent = "Статус эмитента (финансовое агентство): ";//+ isFinagent;                    
                    SnameAudit = "Аудитор";//+nameAudit;                                        
                    Scomments = "Примечание";//+comments;
                    SoffName = "Выпуск регистрировал";//+ offName;                    
                    Sidadvrpm = "Досрочное погашение";//+idadvrpm;
                    Sidpriorred = "Досрочный выкуп";//+ idpriorred;
                    Seventdefault = "События, при наступлении которых может быть объявлен дефолт: ";//+ eventdefault;
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента: ";//+ restinfo;
                    SAddInfo = "Дополнительные сведения о выпуске:";
                    SNumSerial = "№ п/п выпуска";
                    STextNum = "за №";
                    TableName1 = "Выпуски облигаций в рамках программы: ";                    
                    template[0] = "Номер выпуска";
                    template[1] = "Дата регистрации";
                    template[2] = "Дата утверждения последнего отчета";
                    template[3] = "Состояние размещения";
                    template[4] = "Объем выпуска, тг";
                    template[5] = "Объем погашения,тг";
                    template[6] = "Вид облигаций";

                    TableName2 = "Иные выпуски ценных бумаг:";
                    template[7] = "Номер выпуска";
                    template[8] = "Вид ценной бумаги";
                    template[9] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[10] = "Задолженности по выплате";                                  

                   

                    TableName3 = "Примененные ОМВ и санкции:";
                    template[11] = "№ п/п";
                    template[12] = "Дата рассмотрения";
                    template[13] = "Номер и дата письма";
                    template[14] = "Вид ОМВ/санкции";
                    template[15] = "Содержание";
                    template[16] = "Срок исполнения ";
                    template[17] = "Примечание";

                    TableName6 = "Учредители/Акционеры, владеющие свыше 10% акций (по проспекту выпуска):";
                    template[18] = "№ п/п";
                    template[19] = "Наименование учредителя/акционера";
                    template[20] = "ИИН/БИН/ОКПО";
                    template[21] = "Вид, номер, дата документа";
                    template[22] = "Процентное соотношение голосующих акций";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[23] = "Код";
                    template[24] = "Должность";
                    template[25] = "Фамилия, имя, при наличии отчества";
                    template[26] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству размещенных акций";

                    #endregion
                }
                else
                {
                    #region TextKz
                    Stext = "ОБЛИГАЦИЯЛЫҚ БАҒДАРЛАМА";
                    SnameKz = "Атауы ";//+nameKz;
                    SnameRu = "Атауы ";//+nameRu;
                    SnameRegion = "Обласы";//+ nameRegion;                    
                    Saddress = "Мекен-жайы";//+ address;
                    SBIN = "БСН";// + BIN;
                    SOKPO = "КҰЖС";// + OKPO;
                    SnameULReg = "ЗТ тіркеу";//+ nameULReg + "  " + regDateUL;
                    SnumULReg = "№";//+ numULReg;

                    SregName = "Шығарылым тіркелінді";//+ regName + "  " + dateReg;
                    SregNum = "№";//+ regNum;
                    SformIssueECB = "Шығарылымның нысаны";//+ formIssueECB;
                    //ws.Range["D10"].Value = numSeq;
                    SspecActiveknd = "Қызмет бойынша мамандануы: ";//+ specActiveknd;
                    Sspec = "Мамандануы: ";//+ spec;
                    SisFinagent = "Эмитент мәртебесі (қаржылық агенттік): ";//+ isFinagent;                    
                    Samount = "Шығарылым көлемі";//+ amount;                    
                    SnameRegistrars = "Тіркеуші";// + nameRegistrars;
                    SpagentName = "Төлемді агент";//+pagentName;
                    SholderName = "Ұстаушылардың төрағасы";//+holderName;                    
                    SnameAudit = "Аудитор";//+nameAudit;                                        
                    Scomments = "Қосымша";//+ comments;
                    SoffName = "Шығарылымды тіркеген";//+ offName;                    
                    Sidadvrpm = "Мезгілінен бұрын өтеу ескерілген жо?";//+ idadvrpm;
                    Sidpriorred = "Мезгілінен бұрын сатып алу ескерілген жо?";//+ idpriorred;
                    Seventdefault = "Дефолт жариялауды мүмкіндік әсер ететің оқиғалар:";//+ eventdefault;
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента:";//+ restinfo;
                    SAddInfo = "Дополнительные сведения о выпуске:";
                    TableName1 = "Бағдарлама шегінде облигациялар шығарылымдар:";
                    SNumSerial = "№ п/п выпуска";
                    STextNum = "№";
                    template[0] = "Шығарылым нөмірі";
                    template[1] = "Тіркеу күні";
                    template[2] = "Соңғы есеп бекітілген күні";
                    template[3] = "Орналасу күйі";
                    template[4] = "Шығарылым көлемі, тг";
                    template[5] = "Өтеу көлемі,тг";
                    template[6] = "Облигациялардың түрі";                                   

                    TableName2 = "Иные выпуски ценных бумаг:";
                    template[7] = "Шығарылым нөмірі";
                    template[8] = "Вид ценной бумаги";
                    template[9] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[10] = "Задолженности по выплате";

                    TableName3 = "Примененные ОМВ и санкции:";
                    template[11] = "№ п/п";
                    template[12] = "Дата рассмотрения";
                    template[13] = "Номер и дата письма";
                    template[14] = "Вид ОМВ/санкции";
                    template[15] = "Содержание";
                    template[16] = "Срок исполнения ";
                    template[17] = "Примечание";

                    TableName6 = "Учредители/Акционеры, владеющие свыше 10% акций (по проспекту выпуска):";
                    template[18] = "№ п/п";
                    template[19] = "Наименование учредителя/акционера";
                    template[20] = "ИИН/БИН/ОКПО";
                    template[21] = "Вид, номер, дата документа";
                    template[22] = "Процентное соотношение голосующих акций";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[23] = "Код";
                    template[24] = "Должность";
                    template[25] = "Фамилия, имя, при наличии отчества";
                    template[26] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству размещенных акций";

                    #endregion
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
                #region ChangeText
                ReplaceText(wordApp, "${Text}", Stext);
                ReplaceText(wordApp, "${Nameru}", nameRu);
                ReplaceText(wordApp, "${Namekz}", nameKz);
                ReplaceText(wordApp, "${NameRegion}", nameRegion);
                ReplaceText(wordApp, "${Address}", address);
                ReplaceText(wordApp, "${BIN}", BIN);
                ReplaceText(wordApp, "${OKPO}", OKPO);
                //ReplaceText(wordApp, "${TextNum}", STextNum);
                ReplaceText(wordApp, "${NameUlReg}", nameULReg);
                ReplaceText(wordApp, "${RegName}", regName);
                ReplaceText(wordApp, "${RegNum}", regNum);
                ReplaceText(wordApp, "${NumUlReg}", numULReg);
                ReplaceText(wordApp, "${FormIssueECB}", formIssueECB);
                ReplaceText(wordApp, "${Num}", numSeq);
                ReplaceText(wordApp, "${Spec}", spec);                
                ReplaceText(wordApp, "${SpecActiveknd}", specActiveknd);
                ReplaceText(wordApp, "${IsFinagent}", isFinagent);
                ReplaceText(wordApp, "${NameBondknd}", nameBondknd);
                ReplaceText(wordApp, "${Amount}", amount);                
                ReplaceText(wordApp, "${NameRegistrars}", nameRegistrars);
                ReplaceText(wordApp, "${PagentName}", pagentName);
                ReplaceText(wordApp, "${HolderName}",holderName);
                ReplaceText(wordApp, "${NameAudit}", nameAudit);
                ReplaceText(wordApp, "${Comments}", comments);
                ReplaceText(wordApp, "${OffName}", offName);
                ReplaceText(wordApp, "${Idadvrpm}", idadvrpm);
                ReplaceText(wordApp, "${Idpriorred}", idpriorred);
                ReplaceText(wordApp, "${Eventdefault}", eventdefault);               
                ReplaceText(wordApp, "${Restinfo}", restinfo);
                ReplaceText(wordApp, "${DateReg}", dateReg);
                ReplaceText(wordApp, "${regDateUL}", regDateUL);

                ReplaceText(wordApp, "${TNameru}", SnameRu);
                ReplaceText(wordApp, "${TNamekz}", SnameKz);
                ReplaceText(wordApp, "${TNameRegion}", SnameRegion);
                ReplaceText(wordApp, "${TAddress}", Saddress);
                ReplaceText(wordApp, "${TBIN}", SBIN);
                ReplaceText(wordApp, "${TOKPO}", SOKPO);
                ReplaceText(wordApp, "${TextNum}", STextNum);
                ReplaceText(wordApp, "${TNameUlReg}", SnameULReg);
                ReplaceText(wordApp, "${TRegName}", SregName);
                ReplaceText(wordApp, "${TRegNum}", SregNum);
                ReplaceText(wordApp, "${TNumUlReg}", SnumULReg);
                ReplaceText(wordApp, "${TFormIssueECB}", SformIssueECB);
                ReplaceText(wordApp, "${TNum}", SNumSerial);
                ReplaceText(wordApp, "${TSpec}", Sspec);
                ReplaceText(wordApp, "${TSpecActiveknd}", SspecActiveknd);
                ReplaceText(wordApp, "${TIsFinagent}", SisFinagent);
                //ReplaceText(wordApp, "${TNameBondknd}", SnameBondknd);
                ReplaceText(wordApp, "${TAmount}", Samount);
                ReplaceText(wordApp, "${TNameRegistrars}", SnameRegistrars);
                ReplaceText(wordApp, "${TPagentName}", SpagentName);
                ReplaceText(wordApp, "${THolderName}", SholderName);
                ReplaceText(wordApp, "${TNameAudit}", SnameAudit);
                ReplaceText(wordApp, "${TComments}", Scomments);
                ReplaceText(wordApp, "${TOffName}", SoffName);
                ReplaceText(wordApp, "${TIdadvrpm}", Sidadvrpm);
                ReplaceText(wordApp, "${TIdpriorred}", Sidpriorred);
                ReplaceText(wordApp, "${TEventdefault}", Seventdefault);
                ReplaceText(wordApp, "${TRestinfo}", Srestinfo);
                ReplaceText(wordApp, "${TAddInfo}", SAddInfo);
                ReplaceText(wordApp, "${TNum}", SNumSerial);
                #endregion
                #region table1
                System.Data.DataTable dt6 = Getcursor6();

                CreateTableWord(wordDoc, dt6.Rows.Count + 2, 5, 2, TableName6, true,true);
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[18];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[19];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[20];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[21];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[22];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                coloumn = 2;
                for (var i = 0; i < dt6.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt6.Rows[i]["NUM_PP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt6.Rows[i]["NAMERU"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt6.Rows[i]["NUM"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt6.Rows[i]["KIND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt6.Rows[i]["PERSENT_VOIT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table2
                System.Data.DataTable dt7 = Getcursor7();

                CreateTableWord(wordDoc, dt7.Rows.Count + 2, 4, 3, TableName7, true,true);
                wordcellrange.Font.Size = 11;
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[23];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[24];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[25];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[26];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                coloumn = 2;
                for (var i = 0; i < dt7.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt7.Rows[i]["NUM_PP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt7.Rows[i]["NAMERU"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt7.Rows[i]["FIO"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt7.Rows[i]["RATIO_SHARE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table3
                System.Data.DataTable dt1 = Getcursor1();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 7, 4, TableName1, true,true);

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
                wordcellrange = wordtable.Cell(2, 7).Range;
                wordcellrange.Text = template[6];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 7).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                
                coloumn = 2;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt1.Rows[i]["NUM_PROGRAMM"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["DT_REG_PR"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["DT_CONFIRM_PR"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["BOND_NAMESTS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["AMOUNT_PR"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt1.Rows[i]["AMOUNT_DEBT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 7).Range;
                    wordcellrange.Text = dt1.Rows[i]["NAME_BONDKND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                #endregion
                #region TextTable2
                CreateTableWord(wordDoc, 5, 2, 5, SAddInfo, true,false);
                coloumn = 1;
                for (var i = 0; i < 3; i++)
                {
                    coloumn = coloumn + 1;
                    if (coloumn == 2)
                    {
                        STextTable = Sidadvrpm;
                        TextTable = idadvrpm;
                    }
                    else if (coloumn == 3)
                    {
                        STextTable = Sidpriorred;
                        TextTable = idpriorred;
                    }
                    else if (coloumn == 4)
                    {
                        STextTable = Seventdefault;
                        TextTable = eventdefault;
                    }
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = STextTable;
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = TextTable;
                    wordcellrange.Font.Bold = 1;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }

                #endregion
                #region table4
                System.Data.DataTable dt2 = Getcursor4();

                CreateTableWord(wordDoc, dt2.Rows.Count + 2, 4, 6, TableName2, true,true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[7];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[8];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[9];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[10];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                coloumn = 2;
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt2.Rows[i]["NUM7"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt2.Rows[i]["KIND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt2.Rows[i]["PERIOD7"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt2.Rows[i]["DEBT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion                            
                #region table3
                System.Data.DataTable dt5 = Getcursor5();

                CreateTableWord(wordDoc, dt5.Rows.Count + 2, 7, 7, TableName3, true,true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[11];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[12];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[13];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[14];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[15];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 6).Range;
                wordcellrange.Text = template[16];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 7).Range;
                wordcellrange.Text = template[17];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 7).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                //for (int col = 0; col < wordtable.Columns.Count; col++)
                //{
                //    wordcellrange = wordtable.Cell(3, col + 1).Range;
                //    wordcellrange.Text = Convert.ToString(col + 1);
                //    wordcellrange.Font.Bold = 1;
                //    wordcellrange.Borders.Enable = 1;
                //}
                coloumn = 2;
                for (var i = 0; i < dt5.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt5.Rows[i]["NUM_PP2"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt5.Rows[i]["APPDATE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt5.Rows[i]["NUM_DATE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt5.Rows[i]["NAME_OS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt5.Rows[i]["CONTENT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt5.Rows[i]["DATEEXEC"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 7).Range;
                    wordcellrange.Text = dt5.Rows[i]["COMMENTS_OS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 7).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                #endregion
                #region TextTable3

                CreateTableWord(wordDoc, 1, 2, 8, null, false,false);
                wordcellrange = wordtable.Cell(1, 1).Range;
                wordcellrange.Text = Srestinfo;
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                wordcellrange = wordtable.Cell(1, 2).Range;
                wordcellrange.Text = restinfo;
                wordcellrange.Font.Bold = 0;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

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