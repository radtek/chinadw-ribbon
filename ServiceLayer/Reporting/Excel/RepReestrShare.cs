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
     * 29.	Реестр акций
     */
    public class RepReestrShare : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal? idShare;
        protected string valueCapital, cntDecShare, priceShare, cntreppla;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, name, regDate, regNum, reg, dateReg, numReg, formIssueECB, num, activeknd, specActiveknd, spec;
        protected string isPublic, isFinagent, isRFCA, isGovhaveshare, isNonres, isHavecode, placementsts, dateCancel, reasonAnnul, nameReg, infoSharia, commentsStruct;
        protected string restinfo;
        protected string managementCompany, custodian, registrars, payAgent, auditors;
        
        
        #region Constructors
        public RepReestrShare()
        {
        }

        public RepReestrShare(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepReestrShare(RepForm form, LanguageIds language, decimal? idShare)
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
                cmd.CommandText = "G_REP_REESTR_SHARE";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
               
                cmd.Parameters.Add("Name_Ru_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Kz_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("OKPO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Form_Issue_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Activeknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_Activeknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Public_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Finagent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_RFCA_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Is_Govhaveshare_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Nonres_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Havecode_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Value_Capital_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Cnt_Dec_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_Share_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Placementsts_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Cnt_rep_pla_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Cancel_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reason_Annul_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Name_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_Struct_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Restinfo_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Info_Sharia_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Management_Company_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Custodian_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Registrars_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("PayAgent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Auditors_", OracleDbType.Varchar2, ParameterDirection.Output);

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
               
                cmd.Parameters["Name_Ru_"].Size = 4000;
                cmd.Parameters["Name_Kz_"].Size = 4000;
                cmd.Parameters["Name_Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["OKPO_"].Size = 4000;
                cmd.Parameters["Name_"].Size = 4000;
                cmd.Parameters["Reg_Date_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Reg_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Num_Reg_"].Size = 4000;
                cmd.Parameters["Form_Issue_ECB_"].Size = 4000;
                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["Activeknd_"].Size = 4000;
                cmd.Parameters["Spec_Activeknd_"].Size = 4000;
                cmd.Parameters["Spec_"].Size = 4000;
                cmd.Parameters["Is_Public_"].Size = 4000;
                cmd.Parameters["Is_Finagent_"].Size = 4000;
                cmd.Parameters["Is_RFCA_"].Size = 4000;
                cmd.Parameters["Is_Govhaveshare_"].Size = 4000;
                cmd.Parameters["Is_Nonres_"].Size = 4000;
                cmd.Parameters["Is_Havecode_"].Size = 4000;
                cmd.Parameters["Value_Capital_"].Size = 4000;
                cmd.Parameters["Cnt_Dec_Share_"].Size = 4000;
                cmd.Parameters["Price_Share_"].Size = 4000;
                cmd.Parameters["Placementsts_"].Size = 4000;
                cmd.Parameters["Cnt_rep_pla_"].Size = 4000;
                cmd.Parameters["Date_Cancel_"].Size = 4000;
                cmd.Parameters["Reason_Annul_"].Size = 4000;
                cmd.Parameters["Name_Reg_"].Size = 4000;
                cmd.Parameters["Info_Sharia_"].Size = 4000;
                cmd.Parameters["Comments_Struct_"].Size = 4000;
                cmd.Parameters["Restinfo_"].Size = 4000;
                
                cmd.Parameters["Management_Company_"].Size = 4000;
                cmd.Parameters["Custodian_"].Size = 4000;
                cmd.Parameters["Registrars_"].Size = 4000;
                cmd.Parameters["PayAgent_"].Size = 4000;
                cmd.Parameters["Auditors_"].Size = 4000;
               

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
                name = cmd.Parameters["Name_"].Value.ToString();
                if (name == "null")
                {
                    name = string.Empty;
                }
                regDate = cmd.Parameters["Reg_Date_"].Value.ToString();
                if (regDate == "null")
                {
                    regDate = string.Empty;
                }
                regNum = cmd.Parameters["Reg_Num_"].Value.ToString();
                if (regNum == "null")
                {
                    regNum = string.Empty;
                }
                reg = cmd.Parameters["Reg_"].Value.ToString();
                if (reg == "null")
                {
                    reg = string.Empty;
                }
                dateReg = cmd.Parameters["Date_Reg_"].Value.ToString();
                if (dateReg == "null")
                {
                    dateReg = string.Empty;
                }
                numReg = cmd.Parameters["Num_Reg_"].Value.ToString();
                if (numReg == "null")
                {
                    numReg = string.Empty;
                }
                formIssueECB = cmd.Parameters["Form_Issue_ECB_"].Value.ToString();
                if (formIssueECB == "null")
                {
                    formIssueECB = string.Empty;
                }
                num = cmd.Parameters["Num_"].Value.ToString();
                if (num == "null")
                {
                    num = string.Empty;
                }
                activeknd = cmd.Parameters["Activeknd_"].Value.ToString();
                if (activeknd == "null")
                {
                    activeknd = string.Empty;
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
                isPublic = cmd.Parameters["Is_Public_"].Value.ToString();
                if (isPublic == "null")
                {
                    isPublic = string.Empty;
                }
                isFinagent = cmd.Parameters["Is_Finagent_"].Value.ToString();
                if (isFinagent == "null")
                {
                    isFinagent = string.Empty;
                }
                isRFCA = cmd.Parameters["Is_RFCA_"].Value.ToString();
                if (isRFCA == "null")
                {
                    isRFCA = string.Empty;
                }
                isGovhaveshare = cmd.Parameters["Is_Govhaveshare_"].Value.ToString();
                if (isGovhaveshare == "null")
                {
                    isGovhaveshare = string.Empty;
                }
                isNonres = cmd.Parameters["Is_Nonres_"].Value.ToString();
                if (isNonres == "null")
                {
                    isNonres = string.Empty;
                }
                isHavecode = cmd.Parameters["Is_Havecode_"].Value.ToString();
                if (isHavecode == "null")
                {
                    isHavecode = string.Empty;
                }
                valueCapital = cmd.Parameters["Value_Capital_"].Value.ToString();
                if (valueCapital == "null")
                {
                    valueCapital = string.Empty;
                }
                cntDecShare = cmd.Parameters["Cnt_Dec_Share_"].Value.ToString(); ;
                if (cntDecShare == "null")
                {
                    cntDecShare = string.Empty;
                }
                priceShare = cmd.Parameters["Price_Share_"].Value.ToString();
                if (priceShare == "null")
                {
                    priceShare = string.Empty;
                }
                placementsts = cmd.Parameters["Placementsts_"].Value.ToString();
                if (placementsts == "null")
                {
                    placementsts = string.Empty;
                }
                cntreppla = cmd.Parameters["Cnt_rep_pla_"].Value.ToString();
                if (cntreppla == "null")
                {
                    cntreppla = string.Empty;
                }
                dateCancel = cmd.Parameters["Date_Cancel_"].Value.ToString();
                if (dateCancel == "null")
                {
                    dateCancel = string.Empty;
                }
                reasonAnnul = cmd.Parameters["Reason_Annul_"].Value.ToString();
                if (reasonAnnul == "null")
                {
                    reasonAnnul = string.Empty;
                }
                nameReg = cmd.Parameters["Name_Reg_"].Value.ToString();
                if (nameReg == "null")
                {
                    nameReg = string.Empty;
                }
                infoSharia = cmd.Parameters["Info_Sharia_"].Value.ToString();
                if (infoSharia == "null")
                {
                    infoSharia = string.Empty;
                }
                commentsStruct = cmd.Parameters["Comments_Struct_"].Value.ToString();
                 if(commentsStruct == "null")
                 {
                  commentsStruct = string.Empty;
                 }
                restinfo = cmd.Parameters["Restinfo_"].Value.ToString();
                if (restinfo == "null") 
                 {
                  restinfo = string.Empty;
                 }

                managementCompany = cmd.Parameters["Management_Company_"].Value.ToString();
                if (managementCompany == "null")
                {
                    managementCompany = string.Empty;
                }
                custodian = cmd.Parameters["Custodian_"].Value.ToString();
                if (custodian == "null")
                {
                    custodian = string.Empty;
                }
                registrars = cmd.Parameters["Registrars_"].Value.ToString();
                if (registrars == "null")
                {
                    registrars = string.Empty;
                }
                payAgent = cmd.Parameters["PayAgent_"].Value.ToString();
                if (payAgent == "null")
                {
                    payAgent = string.Empty;
                }
                auditors = cmd.Parameters["Auditors_"].Value.ToString();
                if (auditors == "null")
                {
                    auditors = string.Empty;
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


        //Структура выпуска:
        public System.Data.DataTable Getcursor1()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REL_STRUCTURE";
                cmd.Parameters.Add("Id_Share_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
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
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt1);
                }

                return dt1;
            }
        }

        //Отчеты об итогах размещения акций: 
        public System.Data.DataTable Getcursor2()
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SHARE_PLA";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idShare;
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt2);
                }

                return dt2;
            }
        }

        //Крупные акционеры (по отчету об итогах размещения акций)
        public System.Data.DataTable Getcursor3()
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_LARGE_SHAREHOLDERS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idShare;
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt3);
                }

                return dt3;
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
                cmd.CommandText = "G_REP_OTHER_ISSUES";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Id_"].Value = idShare;
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
                cmd.CommandText = "G_REP_OMV_SANCTIONS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
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
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt5);
                }

                return dt5;
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

                GetData();

                //if (nameRu == null) { nameRu = " "; }
                //if (restinfo == null) { restinfo = " "; }

                //ws.Range["B6"].Font.Bold = true;
                if (language == LanguageIds.Russian)
                {
                    ws.Range["A4"].Value = "Наименование на рус";
                }
                else
                {
                    ws.Range["A4"].Value = "Атауы";
                }
                ws.Range["B4"].Value = nameRu;
                if (language == LanguageIds.Russian)
                {
                    ws.Range["A5"].Value = "Наименование на каз";
                    ws.Range["B5"].Value = nameKz;
                }
                
                //ws.Range["B7"].Font.Bold = true;
                if (language == LanguageIds.Russian)
                {
                    ws.Range["A7"].Value = "Область ";
                    ws.Range["B7"].Value = nameRegion;
                }
                else
                {
                    ws.Range["A6"].Value = "Обласы ";
                    ws.Range["B6"].Value = nameRegion;
                }
                if (language == LanguageIds.Russian)
                {
                    ws.Range["C7"].Value = "Адрес   " + address;
                }
                else
                {
                    ws.Range["C6"].Value = "Мекен-жайы   " + address; 
                }
                if (language == LanguageIds.Russian)
                {
                    ws.Range["F7"].Value = "БИН   " + BIN;
                    ws.Range["F8"].Value = "ОКПО   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A9"].Value = "Регистрация ЮЛ   " + name;
                    ws.Range["D9"].Value = "Дата  " + regDate;
                    ws.Range["E9"].Value = "за №  " + regNum;
                    ws.Range["A10"].Value = "Выпуск зарегистрирован   " + reg;
                    ws.Range["D10"].Value = "Дата   " + dateReg;
                    ws.Range["E10"].Value = "за №  " + numReg;
                    ws.Range["A11"].Value = "Форма выпуска";
                    ws.Range["B11"].Value = formIssueECB;
                    ws.Range["E11"].Value = num;
                    ws.Range["A12"].Value = "Вид деятельности:  ";
                    ws.Range["B12"].Value = activeknd;
                    ws.Range["A13"].Value = "Специализация по виду деятельности :   " + specActiveknd;
                    ws.Range["A14"].Value = "Специализация :   " + spec;
                    ws.Range["A15"].Value = "Статус публичной компании :   " + isPublic;
                    ws.Range["D15"].Value = "Статус эмитента (финансовое агентство) :   " + isFinagent;
                    ws.Range["A16"].Value = "Участник РФЦА :   " + isRFCA;
                    ws.Range["A17"].Value = "Наличие госдоли в УК :   " + isGovhaveshare;
                    ws.Range["A18"].Value = "Участие нерезидентов РК в УК :   " + isNonres;
                    ws.Range["D19"].Value = "Наличие кодекса корпоративного управления :   " + isHavecode;

                    ws.Range["A20"].Value = "Размер  УК :";
                    ws.Range["B20"].Value = valueCapital;
                    ws.Range["C20"].Value = "Общее количество акций выпуска   " + cntDecShare;
                    ws.Range["C21"].Value = "Номинальная стоимость акций   " + priceShare;
                    ws.Range["A22"].Value = "Состояние размещения акций на :  " + placementsts;
                    ws.Range["A23"].Value = "Объем размещения по утвержденным отчетам :   " + cntreppla;

                    ws.Range["A24"].Value = "Дата аннулирования";
                    ws.Range["B24"].Value = dateCancel;
                    ws.Range["A25"].Value = "Причина аннулирования  " + reasonAnnul;
                    ws.Range["A26"].Value = "Выпуск регистрировал:  " + nameReg;
                    //otchet

                    ws.Range["A33"].Value = "Управляющая компания :   " + managementCompany;
                    ws.Range["A34"].Value = "Кастодиан :   " + custodian;
                    ws.Range["A35"].Value = "Регистратор :    " + registrars;
                    ws.Range["A36"].Value = "Платежный агент :   " + payAgent;
                    ws.Range["A37"].Value = "Аудитор :   " + auditors;

                    ws.Range["A51"].Value = "Сведения о совете по шариату:";
                    ws.Range["C51"].Value = infoSharia;
                    ws.Range["A53"].Value = "Примечание :";
                    ws.Range["A53"].Value = commentsStruct;
                    ws.Range["A68"].Value = "Основные сведения о реструктуризации обязательств эмитента :";
                    ws.Range["D68"].Value = restinfo;
                }
                else 
                {
                    ws.Range["F6"].Value = "БСН   " + BIN;
                    ws.Range["F7"].Value = "КҰЖС   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A8"].Value = "ЗТ тіркелу   " + name;
                    ws.Range["D8"].Value = " " + regDate;
                    ws.Range["E8"].Value = "№  " + regNum;

                    ws.Range["A9"].Value = "Шығарылым тіркелінді   " + reg;
                    ws.Range["D9"].Value = " " + dateReg;
                    ws.Range["E9"].Value = "№  " + numReg;

                    ws.Range["A10"].Value = "Шығарылымның нысаны";
                    ws.Range["B10"].Value = formIssueECB;
                    ws.Range["E10"].Value = num;

                    ws.Range["A11"].Value = "Қызмет түрі :  ";
                    ws.Range["B11"].Value = activeknd;
                    ws.Range["A12"].Value = "Қызмет бойынша мамандануы :   " + specActiveknd;
                    ws.Range["A13"].Value = "Мамандануы :   " + spec;
                    ws.Range["A14"].Value = "Бұқаралық компанияның мәртебесі :   " + isPublic;
                    ws.Range["D14"].Value = "Эмитент мәртебесі (қаржылық агенттік) :   " + isFinagent;
                    ws.Range["A15"].Value = "ААҚО қатысушысы :   " + isRFCA;
                    ws.Range["A16"].Value = "Мемүлестің ЖК болуы :   " + isGovhaveshare;
                    ws.Range["A17"].Value = "ҚР резиденттері еместердің ЖК қатысуы :   " + isNonres;
                    ws.Range["D18"].Value = "Корпоративтік басқару кодексінің болуы :   " + isHavecode;

                    ws.Range["A19"].Value = "ЖК көлемі :";
                    ws.Range["B19"].Value = valueCapital;
                    ws.Range["D19"].Value = cntDecShare;
                    ws.Range["D20"].Value = priceShare;
                    ws.Range["A21"].Value = "Акциялардың орналасу күйі күніне :  " + placementsts;
                    ws.Range["A22"].Value = "Бекітілген есептер бойынша орналасу көлемі :   " + cntreppla;

                    ws.Range["A23"].Value = "Күшін жойған күн";
                    ws.Range["B23"].Value = dateCancel;
                    ws.Range["A24"].Value = "Күшін жою себебі  " + reasonAnnul;
                    ws.Range["A25"].Value = "Шығарылымды тіркеген :  " + nameReg;
                    //otchet

                    ws.Range["A32"].Value = "Басқарушы компания :   " + managementCompany;
                    ws.Range["A33"].Value = "Кастодиан :   " + custodian;
                    ws.Range["A34"].Value = "Тіркеуші :   " + registrars;
                    ws.Range["A35"].Value = "Төлемді агенттің атауы :    " + payAgent;
                    ws.Range["A36"].Value = "Аудитор :   " + auditors;

                    ws.Range["A50"].Value = "Шариат кеңесі :";
                    ws.Range["B50"].Value = infoSharia;
                    ws.Range["A52"].Value = "Қосымша :";
                    ws.Range["B52"].Value = commentsStruct;
                    ws.Range["A67"].Value = "Основные сведения о реструктуризации обязательств эмитента :";
                    ws.Range["D68"].Value = restinfo;
                }
             


                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt1.Rows[i]["NAMERU"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["CNT"]);
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["DGS"]);
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt1.Rows[i]["COMMENTS"].ToString();
                    rowIndex++;
                    rngColumnDataRow.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 

                }


                Range rngData2 = ws.get_Range("DATA2", Type.Missing) as Range;
                Range rngDataRow2 = rngData2.Rows[rngData2.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow2 = ws.Rows[rngDataRow2.Row, Type.Missing] as Range;

                Range rngDataCountRow2 = rngData2.Rows[2, Type.Missing] as Range;
                var rngColumnDataRow2 = ws.Rows[rngDataCountRow2.Row, Type.Missing] as Range;
                System.Data.DataTable dt2 = Getcursor2();

                int rowIndex1 = 1;

                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    rngBelowDataRow2.Copy();
                    (rngDataRow2.Rows[rowIndex1, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow2.Cells[rowIndex1, 1] as Range).Value2 = dt2.Rows[i]["NAME_KND_REP"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 2] as Range).Value2 = dt2.Rows[i]["DATE_PRV_REP"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 3] as Range).Value2 = dt2.Rows[i]["DATE_PLACEMENT_E"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 4] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["TOTAL"]);
                    (rngDataRow2.Cells[rowIndex1, 5] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["COUNT_PLA_REP"]);
                    (rngDataRow2.Cells[rowIndex1, 6] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["TOTAL_PLA_REP"]);



                    rowIndex1++;
                    rngColumnDataRow2.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 

                }


                Range rngData3 = ws.get_Range("DATA3", Type.Missing) as Range;
                Range rngDataRow3 = rngData3.Rows[rngData3.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow3 = ws.Rows[rngDataRow3.Row, Type.Missing] as Range;

                Range rngDataCountRow3 = rngData3.Rows[3, Type.Missing] as Range;
                var rngColumnDataRow3 = ws.Rows[rngDataCountRow3.Row, Type.Missing] as Range;

                System.Data.DataTable dt3 = Getcursor3();

                int rowIndex3 = 1;

                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    rngBelowDataRow3.Copy();
                    (rngDataRow3.Rows[rowIndex3, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow3.Cells[rowIndex3, 1] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["NUM_PP"]);
                    (rngDataRow3.Cells[rowIndex3, 2] as Range).Value2 = dt3.Rows[i]["NAME"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 3] as Range).Value2 = dt3.Rows[i]["NUM"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 4] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["TOTAL_SHARE"]);
                    (rngDataRow3.Cells[rowIndex3, 5] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["RATIO_TOTAL_PLA"]);
                    (rngDataRow3.Cells[rowIndex3, 6] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["RATIO_TOTAL_VOTING"]);



                    rowIndex3++;
                    rngColumnDataRow3.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 

                }


                Range rngData4 = ws.get_Range("DATA4", Type.Missing) as Range;
                Range rngDataRow4 = rngData4.Rows[rngData4.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow4 = ws.Rows[rngDataRow4.Row, Type.Missing] as Range;

                Range rngDataCountRow4 = rngData4.Rows[3, Type.Missing] as Range;
                var rngColumnDataRow4 = ws.Rows[rngDataCountRow4.Row, Type.Missing] as Range;

                System.Data.DataTable dt4 = Getcursor4();

                int rowIndex4 = 1;

                for (var i = 0; i < dt4.Rows.Count; i++)
                {
                   
                    rngBelowDataRow4.Copy();
                    (rngDataRow4.Rows[rowIndex4, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow4.Cells[rowIndex4, 1] as Range).Value2 = dt4.Rows[i]["NOMER7"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 2] as Range).Value2 = dt4.Rows[i]["KIND"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 3] as Range).Value2 = dt4.Rows[i]["PERIOD7"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 4] as Range).Value2 = dt4.Rows[i]["DEBT"].ToString(); 

                    rowIndex4++;
                   
                    rngColumnDataRow4.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 
                    
                }
               
                
                
                Range rngData5 = ws.get_Range("DATA5", Type.Missing) as Range;
                Range rngDataRow5 = rngData5.Rows[rngData5.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow5 = ws.Rows[rngDataRow5.Row, Type.Missing] as Range;


                Range rngDataCountRow5 = rngData5.Rows[2, Type.Missing] as Range;
                var rngColumnDataRow5 = ws.Rows[rngDataCountRow5.Row, Type.Missing] as Range;

                System.Data.DataTable dt5 = Getcursor5();

                int rowIndex5 = 1;

                for (var i = 0; i < dt5.Rows.Count; i++)
                {
                    rngBelowDataRow5.Copy();
                    (rngDataRow5.Rows[rowIndex5, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow5.Cells[rowIndex5, 1] as Range).Value2 = Convert.ToInt32(dt5.Rows[i]["NUM_PP2"]);
                    (rngDataRow5.Cells[rowIndex5, 2] as Range).Value2 = dt5.Rows[i]["APPDATE"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 3] as Range).Value2 = dt5.Rows[i]["NAME_OS"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 4] as Range).Value2 = dt5.Rows[i]["CONTENT"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 5] as Range).Value2 = dt5.Rows[i]["DATEEXEC"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 6] as Range).Value2 = dt5.Rows[i]["COMMENTS_OS"].ToString();
                   

                    rowIndex5++;
                    rngColumnDataRow5.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing); 

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
