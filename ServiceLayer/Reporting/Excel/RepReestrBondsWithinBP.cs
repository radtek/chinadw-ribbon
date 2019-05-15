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
     * 32.	Реестр облигаций в рамках облигационной программы
     */
    public class RepReestrBondsWithinBP : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal idBond;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regName, regNum, formIssueECB, numSeq, spec;
        protected string isFinagent, nameBondknd, NIN, amount, count, price, countDeploy, countBuy, period, bondNamests, isconvert, nameRewards, reward, paymentPeriod;
        protected string nameRegistrars, holderName, pagentName, nameAudit, origin, dateAnnul, comments, offName, idrest, idadvrpm, idpriorred, eventdefault;
        protected string restinfo, num2, numSeq2, dateReg, amount2, regDateUL, countHolders, countHoldersNonres;

        #region Constructors
        public RepReestrBondsWithinBP()
        {
        }

        public RepReestrBondsWithinBP(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepReestrBondsWithinBP(RepForm form, LanguageIds language, decimal idBond)
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
                cmd.CommandText = "G_REP_REESTR_BONDS_WITHIN_BP";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("Num2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Seq2_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Amount2_", OracleDbType.Varchar2, ParameterDirection.Output);

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
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Form_Issue_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Seq_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Finagent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Bondknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Amount_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Deploy_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Buy_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Bond_Namests_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Isconvert_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Rewards_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reward_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Payment_Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Registrars_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Holder_Name_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Pagent_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Audit_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Annul_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Off_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Idrest_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Idadvrpm_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Idpriorred_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Eventdefault_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Restinfo_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Holders_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Holders_Nonres_", OracleDbType.Varchar2, ParameterDirection.Output);

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

                cmd.Parameters["Num2_"].Size = 4000;
                cmd.Parameters["Num_Seq2_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Amount2_"].Size = 4000;

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
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Form_Issue_ECB_"].Size = 4000;

                cmd.Parameters["Num_Seq_"].Size = 4000;
                cmd.Parameters["Spec_"].Size = 4000;
                cmd.Parameters["Is_Finagent_"].Size = 4000;

                cmd.Parameters["Name_Bondknd_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Amount_"].Size = 4000;
                cmd.Parameters["Count_"].Size = 4000;
                cmd.Parameters["Price_"].Size = 4000;
                cmd.Parameters["Count_Deploy_"].Size = 4000;
                cmd.Parameters["Count_Buy_"].Size = 4000;
                cmd.Parameters["Period_"].Size = 4000;
                cmd.Parameters["Bond_Namests_"].Size = 4000;
                cmd.Parameters["Isconvert_"].Size = 4000;
                cmd.Parameters["Name_Rewards_"].Size = 4000;
                cmd.Parameters["Reward_"].Size = 4000;
                cmd.Parameters["Payment_Period_"].Size = 4000;
                cmd.Parameters["Name_Registrars_"].Size = 4000;
                cmd.Parameters["Holder_Name_"].Size = 4000;
                cmd.Parameters["Pagent_Name_"].Size = 4000;

                cmd.Parameters["Name_Audit_"].Size = 4000;
                cmd.Parameters["Date_Annul_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Off_Name_"].Size = 4000;

                cmd.Parameters["Idrest_"].Size = 4000;
                cmd.Parameters["Idadvrpm_"].Size = 4000;
                cmd.Parameters["Idpriorred_"].Size = 4000;
                cmd.Parameters["Eventdefault_"].Size = 4000;
                cmd.Parameters["Restinfo_"].Size = 4000;
                cmd.Parameters["Count_Holders_"].Size = 4000;
                cmd.Parameters["Count_Holders_Nonres_"].Size = 4000;


                cmd.ExecuteNonQuery();

                num2 = cmd.Parameters["Num2_"].Value.ToString();
                if (num2 == "null")
                {
                    num2 = string.Empty;
                }
                numSeq2 = cmd.Parameters["Num_Seq2_"].Value.ToString();
                if (numSeq2 == "null")
                {
                    numSeq2 = string.Empty;
                }
                dateReg = cmd.Parameters["Date_Reg_"].Value.ToString();
                if (dateReg == "null")
                {
                    dateReg = string.Empty;
                }
                amount2 = cmd.Parameters["Amount2_"].Value.ToString();
                if (amount2 == "null")
                {
                    amount2 = string.Empty;
                }

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
                NIN = cmd.Parameters["NIN_"].Value.ToString();
                if (NIN == "null")
                {
                    NIN = string.Empty;
                }
                amount = cmd.Parameters["Amount_"].Value.ToString();
                if (amount == "null")
                {
                    amount = string.Empty;
                }
                count = cmd.Parameters["Count_"].Value.ToString();
                if (count == "null")
                {
                    count = string.Empty;
                }
                price = cmd.Parameters["Price_"].Value.ToString();
                if (price == "null")
                {
                    price = string.Empty;
                }
                countDeploy = cmd.Parameters["Count_Deploy_"].Value.ToString();
                if (countDeploy == "null")
                {
                    countDeploy = string.Empty;
                }
                countBuy = cmd.Parameters["Count_Buy_"].Value.ToString(); ;
                if (countBuy == "null")
                {
                    countBuy = string.Empty;
                }
                period = cmd.Parameters["Period_"].Value.ToString();
                if (period == "null")
                {
                    period = string.Empty;
                }
                bondNamests = cmd.Parameters["Bond_Namests_"].Value.ToString();
                if (bondNamests == "null")
                {
                    bondNamests = string.Empty;
                }
                isconvert = cmd.Parameters["Isconvert_"].Value.ToString();
                if (isconvert == "null")
                {
                    isconvert = string.Empty;
                }
                nameRewards = cmd.Parameters["Name_Rewards_"].Value.ToString();
                if (nameRewards == "null")
                {
                    nameRewards = string.Empty;
                }
                reward = cmd.Parameters["Reward_"].Value.ToString();
                if (reward == "null")
                {
                    reward = string.Empty;
                }
                paymentPeriod = cmd.Parameters["Payment_Period_"].Value.ToString();
                if (paymentPeriod == "null")
                {
                    paymentPeriod = string.Empty;
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
                
                dateAnnul = cmd.Parameters["Date_Annul_"].Value.ToString();
                if (dateAnnul == "null")
                {
                    dateAnnul = string.Empty;
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

                idrest = cmd.Parameters["Idrest_"].Value.ToString();
                if (idrest == "null")
                {
                    idrest = string.Empty;
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
                countHolders = cmd.Parameters["Count_Holders_"].Value.ToString();
                if (countHolders == "null")
                {
                    countHolders = string.Empty;
                }
                countHoldersNonres = cmd.Parameters["Count_Holders_Nonres_"].Value.ToString();
                if (countHoldersNonres == "null")
                {
                    countHoldersNonres = string.Empty;
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
                cmd.CommandText = "G_REP_BONDS_PLA_WITHIN_BP";
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

        //Держатели облигаций: 
        public System.Data.DataTable Getcursor2()
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_BONDHOLDERS_WITHIN_BP";
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
                    oda.Fill(dt2);
                }

                return dt2;
            }
        }

        //Сведения о дефолте:
        public System.Data.DataTable Getcursor3()
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_BOND_DEFAULT_WITHIN_BP";
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
                  
                    ws.Range["A4"].Value = "Номер выпуска облигационной программы :   " + num2;
                    ws.Range["E4"].Value = "Порядковый номер :   " + numSeq2;
                    ws.Range["A5"].Value = "Дата регистрации выпуска облигационной программы :   " + dateReg;
                    ws.Range["A6"].Value = "Объем облигационной программы :";
                    ws.Range["D6"].Value = amount2;

                    ws.Range["A8"].Value = "Наименование на рус";
                    ws.Range["C8"].Value = nameRu;
                    ws.Range["A9"].Value = "Наименование на каз";
                    ws.Range["C9"].Value = nameKz;

                    ws.Range["A11"].Value = "Область";
                    ws.Range["B11"].Value = nameRegion;
                    ws.Range["D11"].Value = "Адрес   " + address;
                    ws.Range["F11"].Value = "БИН   " + BIN;
                    ws.Range["F12"].Value = "ОКПО   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A13"].Value = "Регистрация ЮЛ   " + nameULReg;
                    ws.Range["E13"].Value = regDateUL;
                    ws.Range["F13"].Value = "за №     " + numULReg;
                   // ws.Range["G13"].Value = numULReg;

                    ws.Range["A14"].Value = "Выпуск зарегистрирован   " + regName;
                    ws.Range["E14"].Value = dateReg;
                    ws.Range["F14"].Value = "за №    " + regNum;
                    //ws.Range["G14"].Value = regNum;
                    ws.Range["A15"].Value = "Форма выпуска   " + formIssueECB;
                    ws.Range["G15"].Value = numSeq;
                    ws.Range["A16"].Value = "Специализация    " + spec;
                    ws.Range["A17"].Value = "Статус эмитента (финансовое агентство)    " + isFinagent;
                    ws.Range["A18"].Value = "Вид облигаций :  " + nameBondknd;
                    ws.Range["F18"].Value = "НИН  " + NIN;
                    ws.Range["A19"].Value = "Объем выпуска";
                    ws.Range["C19"].Value = amount;
                    ws.Range["E19"].Value = "Количество облигаций";
                    ws.Range["F19"].Value = count;
                    ws.Range["A20"].Value = "Номинальная стоимость";
                    ws.Range["C20"].Value = price;
                    ws.Range["E20"].Value = "Количество размещенных облигаций";
                    ws.Range["F20"].Value = countDeploy;
                    ws.Range["E21"].Value = "из них выкупленных";
                    ws.Range["F21"].Value = countBuy;
                    ws.Range["A22"].Value = "Срок обращения   " + period;
                    // ws.Range["B20"].Value = period;
                    ws.Range["A23"].Value = "Состояние размещения на   " + bondNamests;
                    //ws.Range["B21"].Value = bondNamests;
                    ws.Range["A24"].Value = "Возможность конвертирования   " + isconvert;
                    ws.Range["A25"].Value = "Показатель вознаграждения   " + nameRewards;
                    ws.Range["E25"].Value = "Размер выплаты";
                    ws.Range["F25"].Value = reward;
                    ws.Range["A26"].Value = "Периодичность выплаты   " + paymentPeriod;
                    //ws.Range["B24"].Value = paymentPeriod;
                    ws.Range["A27"].Value = "Регистратор    " + nameRegistrars;
                    //ws.Range["B25"].Value = nameRegistrars;
                    ws.Range["A28"].Value = "Платежный агент    " + pagentName;
                    //ws.Range["B26"].Value = pagentName;
                    ws.Range["A29"].Value = "Представительдержателя облигаций    " + holderName;
                    // ws.Range["B27"].Value = holderName;
                    ws.Range["A30"].Value = "Аудитор";
                    ws.Range["B30"].Value = nameAudit;

                    ws.Range["A31"].Value = "Дата аннулирования";
                    ws.Range["C31"].Value = dateAnnul;
                    ws.Range["A33"].Value = "Примечание    " + comments;
                    //ws.Range["B31"].Value = comments;
                    ws.Range["A34"].Value = "Выпуск регистрировал  " + offName;
                    ws.Range["A42"].Value = "Держатели облигаций: " + countHolders;
                    ws.Range["A44"].Value = "Всего, из них нерезидентов: " + countHoldersNonres;
                    ws.Range["D51"].Value = idrest;
                    ws.Range["A52"].Value = "Досрочное погашение    " + idadvrpm;
                    ws.Range["A53"].Value = "Досрочный выкуп   " + idpriorred;
                    ws.Range["E54"].Value = eventdefault;

                    ws.Range["E74"].Value = restinfo;
                }
                else
                {
                    ws.Range["A4"].Value = "Облигациялық бағдарлама шығарылымының нөмірі :   " + num2;
                    ws.Range["E4"].Value = "Реттік нөмірі :   " + numSeq2;
                    ws.Range["A5"].Value = "Облигациялық бағдарлама шығарылымын тіркеу күні :  " + dateReg;
                    ws.Range["A6"].Value = "Облигациялық бағдарламаның көлемі :";
                    ws.Range["D6"].Value = amount2;

                    ws.Range["A8"].Value = "Атауы";
                    ws.Range["B8"].Value = nameRu;
                  //  ws.Range["A9"].Value = "Наименование на каз";
                   // ws.Range["C9"].Value = nameKz;

                    ws.Range["A11"].Value = "Облысы";
                    ws.Range["B11"].Value = nameRegion;
                    ws.Range["D11"].Value = "Мекен-жайы   " + address;
                    ws.Range["F11"].Value = "БСН   " + BIN;
                    ws.Range["F12"].Value = "КҰЖС   " + OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A13"].Value = "ЗТ тіркеу   " + nameULReg;
                    ws.Range["E13"].Value = regDateUL;
                    ws.Range["F13"].Value = "№   " + numULReg;
                    //ws.Range["G13"].Value = numULReg;

                    ws.Range["A14"].Value = "Шығарылым тіркелінді";
                    ws.Range["B14"].Value = regName;
                    ws.Range["E14"].Value = dateReg;
                    ws.Range["F14"].Value = "№   " + regNum;
                    //ws.Range["G14"].Value = regNum;
                    ws.Range["A15"].Value = "Шығарылымның нысаны   " + formIssueECB;
                    ws.Range["G15"].Value = numSeq;
                    ws.Range["A16"].Value = "Мамандануы    " + spec;
                    ws.Range["A17"].Value = "Эмитент мәртебесі (қаржылық агенттік)    " + isFinagent;
                    ws.Range["A18"].Value = "Облигациялардың түрі :  " + nameBondknd;
                    ws.Range["F18"].Value = "ҰБН   " + NIN;
                    ws.Range["A19"].Value = "Шығарылым көлемі";
                    ws.Range["C19"].Value = amount;
                    ws.Range["E19"].Value = "Облигациялар саны";
                    ws.Range["F19"].Value = count;
                    ws.Range["A20"].Value = "Номиналды құны";
                    ws.Range["C20"].Value = price;
                    ws.Range["E20"].Value = "Орналастырылғандар облигациялардың саныоблигаций";
                    ws.Range["G20"].Value = countDeploy;
                    ws.Range["E21"].Value = "онын ішінде сатып алынғандар";
                    ws.Range["G21"].Value = countBuy;
                    ws.Range["A22"].Value = "Айналыс мерзімі";
                    ws.Range["B22"].Value = period;
                    ws.Range["A23"].Value = "Орналасу күйі күніне   " + bondNamests;
                    //ws.Range["B21"].Value = bondNamests;
                    ws.Range["A24"].Value = "Айрбастау мүмкіндігі    " + isconvert;
                    ws.Range["A25"].Value = "Сыйақы көрсеткіші    " + nameRewards;
                    ws.Range["E25"].Value = "Сыйақы мөлшері";
                    ws.Range["F25"].Value = reward;
                    ws.Range["A26"].Value = "Сыйақының мерзімді төлемдері    " + paymentPeriod;
                    //ws.Range["B24"].Value = paymentPeriod;
                    ws.Range["A27"].Value = "Тіркеуші";// +nameRegistrars;
                    ws.Range["B27"].Value = nameRegistrars;
                    ws.Range["A28"].Value = "Төлемді агент";
                    ws.Range["B28"].Value = pagentName;
                    ws.Range["A29"].Value = "Ұстаушылардың төрағасы";
                    ws.Range["B29"].Value = holderName;
                    ws.Range["A30"].Value = "Аудитор";
                    ws.Range["B30"].Value = nameAudit;

                    ws.Range["A31"].Value = "Күшін жойған күн";
                    ws.Range["B31"].Value = dateAnnul;
                    ws.Range["A33"].Value = "Қосымша    " + comments;
                    //ws.Range["B31"].Value = comments;
                    ws.Range["A34"].Value = "Шығарылымды тіркеген  " + offName;
                    ws.Range["A42"].Value = "Облигацияны ұстаушылар: " + countHolders;
                    ws.Range["A44"].Value = "Барлығы , олардың ішінде резидент еместер : " + countHoldersNonres;
                    //ws.Range["D51"].Value = idrest;
                    ws.Range["A52"].Value = "Мезгілінен бұрын өтеу   " + idadvrpm;
                    ws.Range["A53"].Value = "Мезгілінен бұрын сатып алу    " + idpriorred;
                    ws.Range["D54"].Value = eventdefault;

                    ws.Range["E74"].Value = restinfo;
                }



                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt1.Rows[i]["NAME_KND_REP"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["DATE_CONFIRM"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["DATE_ENDPLC"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["COUNT_DEPLOY"]);
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["AMOUNT"]);

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

                    (rngDataRow2.Cells[rowIndex1, 1] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["NUMPP_HOLDERS"]);
                    (rngDataRow2.Cells[rowIndex1, 2] as Range).Value2 = dt2.Rows[i]["NAME_HOLDERS"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 3] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["HOLDERS_CNT"]);
                    (rngDataRow2.Cells[rowIndex1, 4] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["HOLDERS_CNTPLC"]);



                    rowIndex1++;
                    rngColumnDataRow2.Insert(XlInsertShiftDirection.xlShiftDown, Type.Missing);

                }


                Range rngData3 = ws.get_Range("DATA3", Type.Missing) as Range;
                Range rngDataRow3 = rngData3.Rows[rngData3.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow3 = ws.Rows[rngDataRow3.Row, Type.Missing] as Range;


                Range rngDataCountRow3 = rngData3.Rows[2, Type.Missing] as Range;
                var rngColumnDataRow3 = ws.Rows[rngDataCountRow3.Row, Type.Missing] as Range;
                System.Data.DataTable dt3 = Getcursor3();

                int rowIndex3 = 1;

                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    rngBelowDataRow3.Copy();
                    (rngDataRow3.Rows[rowIndex3, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow3.Cells[rowIndex3, 1] as Range).Value2 = dt3.Rows[i]["DEFAULT_PERIOD"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 2] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["DEBT_DEFAULT"]);
                    (rngDataRow3.Cells[rowIndex3, 3] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["SUMMARPM_DEFAULT"]);
                    (rngDataRow3.Cells[rowIndex3, 4] as Range).Value2 = dt3.Rows[i]["DATEOPER_DEFAULT"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 5] as Range).Value2 = dt3.Rows[i]["REASON_DEFAULT"].ToString();

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
