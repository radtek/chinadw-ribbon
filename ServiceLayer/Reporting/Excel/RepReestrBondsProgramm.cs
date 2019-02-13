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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ARM_User.ServiceLayer.Reporting.Excel
{

    /*
     Author: Tolebi Baimenov
     * 31.	Реестр облигационной программы
     */
    public class RepReestrBondsProgramm : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal idBond;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regName, regNum, formIssueECB, numSeq, specActiveknd, spec;
        protected string isFinagent, nameBondknd, amount, nameRegistrars, pagentName, holderName, nameAudit, comments, offName, idadvrpm, idpriorred, eventdefault;
        protected string restinfo,regDateUL, dateReg;

        #region Constructors
        public RepReestrBondsProgramm()
        {
        }

        public RepReestrBondsProgramm(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepReestrBondsProgramm(RepForm form, LanguageIds language, decimal idBond)
            : this(form, language)
        {
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


        protected virtual void CreateReportFromCursor()
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
                if (language == LanguageIds.Russian)
                {
                    ws.Range["A4"].Value = "Наименование на рус";
                    ws.Range["C4"].Value = nameRu;
                    ws.Range["A5"].Value = "Наименование на каз";
                    ws.Range["C5"].Value = nameKz;
                    //ws.Range["B7"].Font.Bold = true;
                    ws.Range["A7"].Value = "Область ";
                    ws.Range["B7"].Value = nameRegion;
                    ws.Range["D7"].Value = "Адрес " + address;
                    ws.Range["G7"].Value = "БИН   " + BIN;
                    ws.Range["G8"].Value = "ОКПО   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A9"].Value = "Регистрация ЮЛ  " + nameULReg;
                    ws.Range["E9"].Value = regDateUL;
                    ws.Range["F9"].Value = "за №   " + numULReg;

                    ws.Range["A10"].Value = "Выпуск зарегистрирован  " + regName;
                    ws.Range["E10"].Value = dateReg;
                    ws.Range["F10"].Value = "за №  " + regNum;
                    ws.Range["A11"].Value = "Форма выпуска  " + formIssueECB;
                    ws.Range["F11"].Value = numSeq;
                    ws.Range["A12"].Value = "Специализация по виду деятельности :  " + specActiveknd;
                    ws.Range["A13"].Value = "Специализация :  " + spec;
                    ws.Range["A14"].Value = "Статус эмитента (финансовое агентство) :  " + isFinagent;
                    // ws.Range["A15"].Value = "Вид облигаций :  " + nameBondknd;
                    ws.Range["A15"].Value = "Объем выпуска";
                    ws.Range["C15"].Value = amount;

                    ws.Range["A16"].Value = "Регистратор   " + nameRegistrars;
                    // ws.Range["B25"].Value = nameRegistrars;
                    ws.Range["A17"].Value = "Платежный агент   " + pagentName;
                    // ws.Range["B26"].Value = pagentName;
                    ws.Range["A18"].Value = "Представительдержателя облигаций   " + holderName;
                    //ws.Range["B27"].Value = holderName;
                    ws.Range["A19"].Value = "Аудитор";
                    ws.Range["B19"].Value = nameAudit;
                    ws.Range["A20"].Value = "Примечание   " + comments;
                    //ws.Range["B31"].Value = comments;

                    ws.Range["A21"].Value = "Выпуск регистрировал  " + offName;
                    // ws.Range["C46"].Value = idrest;
                    ws.Range["A30"].Value = "Досрочное погашение   " + idadvrpm;
                    ws.Range["A31"].Value = "Досрочный выкуп   " + idpriorred;
                    ws.Range["E32"].Value = eventdefault;
                    ws.Range["E45"].Value = restinfo;

                }
                else
                {
                    ws.Range["A4"].Value = "Атауы";
                    ws.Range["B4"].Value = nameRu;
                   
                    //ws.Range["B7"].Font.Bold = true;
                    ws.Range["A6"].Value = "Облысы  ";
                    ws.Range["B6"].Value = nameRegion;
                    ws.Range["D6"].Value = "Мекен-жайы " + address;
                    ws.Range["G6"].Value = "БСН   " + BIN;
                    ws.Range["G7"].Value = "КҰЖС   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A8"].Value = "ЗТ тіркеу  " + nameULReg;
                    ws.Range["E8"].Value = regDateUL;
                    ws.Range["F8"].Value = "№";
                    ws.Range["G8"].Value = numULReg;

                    ws.Range["A9"].Value = "Шығарылым тіркелінді  " + regName;
                    ws.Range["E9"].Value = dateReg;
                    ws.Range["F9"].Value = "№";
                    ws.Range["G9"].Value = regNum;

                    ws.Range["A10"].Value = "Шығарылымның нысаны  " + formIssueECB;
                    ws.Range["G10"].Value = numSeq;

                    ws.Range["A11"].Value = "Қызмет бойынша мамандануы :  " + specActiveknd;
                    ws.Range["A12"].Value = "Мамандануы :  " + spec;
                    ws.Range["A13"].Value = "Эмитент мәртебесі (қаржылық агенттік) :  " + isFinagent;
                    // ws.Range["A15"].Value = "Вид облигаций :  " + nameBondknd;
                    ws.Range["A14"].Value = "Шығарылым көлемі";
                    ws.Range["C14"].Value = amount;

                    ws.Range["A15"].Value = "Тіркеуші";
                    ws.Range["C15"].Value = nameRegistrars;
                    ws.Range["A16"].Value = "Төлемді агент";
                    ws.Range["C16"].Value = pagentName;
                    ws.Range["A17"].Value = "Ұстаушылардың төрағасы";
                    ws.Range["C17"].Value = holderName;

                    ws.Range["A18"].Value = "Аудитор";
                    ws.Range["C18"].Value = nameAudit;
                    ws.Range["A19"].Value = "Қосымша   " + comments;
                    //ws.Range["B31"].Value = comments;

                    ws.Range["A20"].Value = "Шығарылымды тіркеген  " + offName;
                    // ws.Range["C46"].Value = idrest;
                    ws.Range["A29"].Value = "Мезгілінен бұрын өтеу   " + idadvrpm;
                    ws.Range["A30"].Value = "Мезгілінен бұрын сатып алу   " + idpriorred;
                    ws.Range["E31"].Value = eventdefault;
                    ws.Range["E44"].Value = restinfo;
                }


                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    if (dt1.Rows[i]["AMOUNT_PR"] != DBNull.Value)
                    if (dt1.Rows[i]["AMOUNT_DEBT"] != DBNull.Value)
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt1.Rows[i]["NUM_PROGRAMM"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["DT_REG_PR"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["DT_CONFIRM_PR"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["BOND_NAMESTS"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = Convert.ToInt64(dt1.Rows[i]["AMOUNT_PR"]);
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["AMOUNT_DEBT"]);
                    (rngDataRow.Cells[rowIndex, 7] as Range).Value2 = dt1.Rows[i]["NAME_BONDKND"].ToString();

                    rowIndex++;
                    rngColumnDataRow.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing);

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

                    (rngDataRow4.Cells[rowIndex4, 1] as Range).Value2 = dt4.Rows[i]["NUM7"].ToString();
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
                    (rngDataRow5.Cells[rowIndex5, 3] as Range).Value2 = dt5.Rows[i]["NUM_DATE"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 4] as Range).Value2 = dt5.Rows[i]["NAME_OS"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 5] as Range).Value2 = dt5.Rows[i]["CONTENT"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 6] as Range).Value2 = dt5.Rows[i]["DATEEXEC"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 7] as Range).Value2 = dt5.Rows[i]["COMMENTS_OS"].ToString();


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
            CreateReportFromCursor();

        }
    }
}
