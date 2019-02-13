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
    public class RepWordReestrBondsWithinBP : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idBond;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regName, regNum, formIssueECB, numSeq, spec;
        protected string isFinagent, nameBondknd, NIN, amount, count, price, countDeploy, countBuy, period, bondNamests, isconvert, nameRewards, reward, paymentPeriod;
        protected string nameRegistrars, holderName, pagentName, nameAudit, origin, dateAnnul, comments, offName, idrest, idadvrpm, idpriorred, eventdefault;
        protected string restinfo, num2, numSeq2, dateReg, amount2, regDateUL, countHolders, countHoldersNonres;

        protected string SnameRu, SnameKz, SnameRegion, Saddress, SBIN, SOKPO, SnameULReg, SnumULReg, SregName, SregNum, SformIssueECB, SnumSeq, Sspec;
        protected string SisFinagent, SnameBondknd, SNIN, Samount, Scount, Sprice, ScountDeploy, ScountBuy, Speriod, SbondNamests, Sisconvert, SnameRewards, Sreward, SpaymentPeriod;
        protected string SnameRegistrars, SholderName, SpagentName, SnameAudit, Sorigin, SdateAnnul, Scomments, SoffName, Sidrest, Sidadvrpm, Sidpriorred, Seventdefault;
        protected string Srestinfo, Snum2, SnumSeq2, SdateReg, Samount2, SregDateUL, ScountHolders, ScountHoldersNonres, Stenge;

        protected string TableName1, TableName2, TableName3, TableName4, TableName5, Stext, STextNum, SAddInfo, SNumSerial, SspecActiveknd, specActiveknd, TableName7, STextTable, TextTable, STotalcountHolders;
        protected int coloumn;                
        protected string[] template = new string[37];
        public RepWordReestrBondsWithinBP(RepForm form, LanguageIds language, decimal? idBond)
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
                cmd.Parameters.Add("Spec_Activeknd_", OracleDbType.Varchar2, ParameterDirection.Output);

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
                cmd.Parameters["Spec_Activeknd_"].Size = 4000;

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
                specActiveknd = cmd.Parameters["Spec_Activeknd_"].Value.ToString();
                if (specActiveknd == "null")
                {
                    specActiveknd = string.Empty;
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
                    Stext = "Реестр облигаций в рамках облигационной программы";
                    Snum2 = "Номер выпуска облигационной программы: ";// +num2;
                    SnumSeq2 = "Порядковый номер: ";// + numSeq2;
                    SdateReg = "Дата регистрации выпуска облигационной программы: ";//+ dateReg;
                    Samount2 = "Объем облигационной программы: ";// + amount2 + "   тенге";      
                    Stenge = "тенге";
                    SnameRu = "Наименование на рус ";//+nameRu;
                    SnameKz = "Наименование на каз ";//+nameKz;
                    SnameRegion = "Область";//+ nameRegion;
                    Saddress = "Адрес";//+ address;
                    SBIN = "БИН";//+ BIN;
                    SOKPO = "ОКПО";//+ OKPO;
                    SnameULReg = "Регистрация ЮЛ";//+ nameULReg + "  " + regDateUL;
                    SnumULReg = "за №";// + numULReg;
                    SregName = "Выпуск зарегистрирован";//+ regName + "  " + dateReg;
                    SregNum = "за № ";//+ regNum;
                    SformIssueECB = "Форма выпуска";// + formIssueECB;
                    //ws.Range["D11"].Value = numSeq;        
                    SspecActiveknd = "Специализация по виду деятельности: ";
                    SnameBondknd = "Вид облигаций: ";
                    Sspec = "Специализация: ";//+ spec;
                    SisFinagent = "Статус эмитента (финансовое агентство): ";// + isFinagent;
                    SnameBondknd = "Вид облигаций: ";// + nameBondknd;
                    SNIN = "НИН: ";//+ NIN;
                    Samount = "Объем выпуска ";//+amount;                    
                    Scount = "Количество облигаций";//+count;                    
                    Sprice = "Номинальная стоимость";//+price;                    
                    ScountDeploy = "Количество размещенных облигаций";//+countDeploy;                    
                    ScountBuy = "из них выкупленных";//+countBuy;                    
                    Speriod = "Срок обращения";//+period;                    
                    SbondNamests = "Состояние размещения на";//+bondNamests;
                    Sisconvert = "Возможность конвертирования ";// + isconvert;
                    SnameRewards = "Показатель вознаграждения ";//+ nameRewards;
                    Sreward = "Размер выплаты ";//+reward;                    
                    SpaymentPeriod = "Периодичность выплаты ";//+paymentPeriod;                    
                    SnameRegistrars = "Регистратор";//+nameRegistrars;                    
                    SpagentName = "Платежный агент";//+pagentName;                    
                    SholderName = "Представительдержателя облигаций";//+holderName;                    
                    SnameAudit = "Аудитор";//+nameAudit;                    
                    Sorigin = "Оригинатор";//+origin;                   
                    SdateAnnul = "Дата аннулирования";//+dateAnnul;                    
                    Scomments = "Примечание";//+comments;
                    SoffName = "Выпуск регистрировал";//+ offName;
                    ScountHolders = "Держатели облигаций:";//+ countHolders;
                    ScountHoldersNonres = "из них нерезидентов";//+ countHoldersNonres;
                    STotalcountHolders = "Всего";//+ countHoldersNonres;
                    Sidrest = "Выпуск в связи с реструктуризацией?";// +idrest;
                    Sidadvrpm = "Досрочное погашение";//+idadvrpm;
                    Sidpriorred = "Досрочный выкуп";//+ idpriorred;
                    Seventdefault = "События, при наступлении которых может быть объявлен дефолт:";//+ eventdefault;
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента:";//+ restinfo;
                    SAddInfo = "Дополнительные сведения о выпуске:";
                    STextNum = "за №";


                    SNumSerial = "№ п/п выпуска";
                    TableName1 = "Отчеты об итогах размещения облигаций: ";
                    template[0] = "Вид отчета";
                    template[1] = "Дата утверждения (принятия к сведению)";
                    template[2] = "Дата окончания размещения";
                    template[3] = "Количество размещенных облигаций";
                    template[4] = "Объем привлеченных средств, тг";
                    template[29] = "Общее количество размещенных облигаций";
                    TableName2 = "Держатели облигаций: ";
                    template[5] = "№п/п";
                    template[6] = "Категория держателей облигаций";
                    template[7] = "Количество держателей";
                    template[8] = "Количество размещенных облигаций";

                    TableName3 = "Сведения о дефолте: ";
                    template[9] = "Период выплаты";
                    template[10] = "Сумма задолженности, тенге";
                    template[11] = "Погашение задолженности";
                    template[12] = "Дата погашения";
                    template[13] = "Причина дефолта";                    

                    TableName4 = "Иные выпуски ценных бумаг:";
                    template[14] = "Номер выпуска";
                    template[15] = "Вид ценной бумаги";
                    template[16] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[17] = "Задолженности по выплате";

                    TableName5 = "Примененные ОМВ и санкции:";
                    template[18] = "№ п/п";
                    template[19] = "Дата рассмотрения";
                    template[20] = "Номер и дата письма";
                    template[21] = "Вид ОМВ/санкции";
                    template[22] = "Содержание";
                    template[23] = "Срок исполнения ";
                    template[24] = "Примечание";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[25] = "Код";
                    template[26] = "Должность";
                    template[27] = "Фамилия, имя, при наличии отчества";
                    template[28] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству размещенных акций";
                    #endregion
                }
                else
                {
                    #region TextKz
                    Stext = "ОБЛИГАЦИЯЛЫҚ БАҒДАРЛАМА ШЕГІНДЕ ОБЛИГАЦИЯЛАР ТІЗІЛІМІ";
                    Snum2 = "Облигациялық бағдарлама шығарылымының нөмірі: ";// + num2;
                    SnumSeq2 = "Реттік нөмірі: ";//+ numSeq2;
                    SdateReg = "Облигациялық бағдарлама шығарылымын тіркеу күні: ";//+ dateReg;
                    Samount2 = "Облигациялық бағдарламаның көлемі: ";// + amount2 + "   тенге";  

                    SnameKz = "Атауы ";//+nameKz;
                    SnameRu = "Атауы ";//+nameRu;
                    SnameRegion = "Обласы";//+ nameRegion;                    
                    Saddress = "Мекен-жайы";//+ address;
                    SBIN = "БСН";//+ BIN;
                    SOKPO = "КҰЖС";//+ OKPO;
                    SnameULReg = "ЗТ тіркеу";//+ nameULReg + "  " + regDateUL;
                    SnumULReg = "№";//+ numULReg;
                    STextNum = "№";
                    SregName = "Шығарылым тіркелінді";// + regName + "  " + dateReg;
                    SregNum = "№";//+ regNum;
                    SformIssueECB = "Шығарылымның нысаны";//+ formIssueECB;
                    SnumSeq = "№ п/п выпуска";// + numSeq;                    
                    Sspec = "Мамандануы :  ";//+ spec;
                    SisFinagent = "Эмитент мәртебесі (қаржылық агенттік): ";//+ isFinagent;
                    SnameBondknd = "Облигациялардың түрі: ";//+ nameBondknd;
                    SNIN = "ҰБН";// + NIN;
                    Samount = "Шығарылым көлемі";//+ amount;
                    Scount = "Облигациялар саны";//+ count;
                    Sprice = "Номиналды құны";//+ price;
                    ScountDeploy = "Орналастырылғандар облигациялардың саны";//+ countDeploy;
                    ScountBuy = "онын ішінде сатып алынғандар";// + countBuy;
                    Speriod = "Айналыс мерзімі";//+ period;
                    SbondNamests = "Орналасу күйі күніне";// + bondNamests;
                    Sisconvert = "Айрбастау мүмкіндігі ";// + isconvert;
                    SnameRewards = "Сыйақы көрсеткіші ";// + nameRewards;
                    Sreward = "Сыйақы мөлшері ";// + reward;                    
                    SpaymentPeriod = "Сыйақының мерзімді төлемдері ";// + paymentPeriod;
                    SnameRegistrars = "Тіркеуші";// + nameRegistrars;
                    SpagentName = "Төлемді агент";//+pagentName;
                    SholderName = "Ұстаушылардың төрағасы";//+holderName;                    
                    SnameAudit = "Аудитор";//+nameAudit;                    
                    Sorigin = "Оригинатор";//+origin;
                    SdateAnnul = "Күшін жойған күн";//+dateAnnul;
                    Scomments = "Қосымша";// + comments;
                    SoffName = "Шығарылымды тіркеген";//+ offName;
                    Stenge = "тенге";
                    ScountHolders = "Облигацияны ұстаушылар:";//+ countHolders;
                    ScountHoldersNonres = "олардың ішінде резидент еместер";//+ countHoldersNonres;                
                    STotalcountHolders = "Барлығы";//+ countHoldersNonres;
                    Sidrest = "Выпуск в связи с реструктуризацией?";// + idrest;
                    Sidadvrpm = "Мезгілінен бұрын өтеу ескерілген жо?"  ;//+idadvrpm;
                    Sidpriorred = "Мезгілінен бұрын сатып алу ескерілген жо?" ;//+ idpriorred;
                    Seventdefault = "Дефолт жариялауды мүмкіндік әсер ететің оқиғалар:" ;//+ eventdefault;
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента:";// + restinfo;
                    SAddInfo = "Дополнительные сведения о выпуске:";
                    SNumSerial = "№ п/п выпуска";
                    TableName1 = "Облигацияларды орналастыру есебі: ";
                    template[0] = "Есептің түрі";
                    template[1] = "Бекіту күні(дерекке алу)";
                    template[2] = "Орналастыру сонғы куні";
                    template[3] = "Орналастырылған облигациялар саны";
                    template[4] = "Кезең ішінде тарту құралдарының көлемі, тг";
                    template[29] = "Орналастырылған облигациялар жалпы саны";                
                    TableName2 = "Облигацияны ұстаушылар: ";
                    template[5] = "№";
                    template[6] = "Облигацияларды ұстаушылардың санаты";
                    template[7] = "Ұстаушылар саны";
                    template[8] = "Орналастырылған облигациялар саны";

                    TableName3 = "Дефолт туралы деректер: ";
                    template[9] = "Сыйақы кезені";
                    template[10] = "Берешек сомасы, теңге";
                    template[11] = "Берешек өтеу";
                    template[12] = "Өтелген күні";
                    template[13] = "Дефолт себебі";                    

                    TableName4 = "Иные выпуски ценных бумаг:";
                    template[14] = "Шығарылым нөмірі";
                    template[15] = "Вид ценной бумаги";
                    template[16] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[17] = "Задолженности по выплате";

                    TableName5 = "Примененные ОМВ и санкции:";
                    template[18] = "№ п/п";
                    template[19] = "Дата рассмотрения";
                    template[20] = "Номер и дата письма";
                    template[21] = "Вид ОМВ/санкции";
                    template[22] = "Содержание";
                    template[23] = "Срок исполнения ";
                    template[24] = "Примечание";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[25] = "Код";
                    template[26] = "Должность";
                    template[27] = "Фамилия, имя, при наличии отчества";
                    template[28] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству размещенных акций";
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
                #region ChamgeText
                ReplaceText(wordApp, "${Text}", Stext);
                ReplaceText(wordApp, "${Num}", num2);
                ReplaceText(wordApp, "${NumSeq2}", numSeq2);
                ReplaceText(wordApp, "${DateReg}", dateReg);
                ReplaceText(wordApp, "${Amount2}", amount2);
                ReplaceText(wordApp, "${NumSeq}", numSeq);
                ReplaceText(wordApp, "${Nameru}", nameRu);
                ReplaceText(wordApp, "${Namekz}", nameKz);
                ReplaceText(wordApp, "${NameRegion}", nameRegion);
                ReplaceText(wordApp, "${Address}", address);
                ReplaceText(wordApp, "${BIN}", BIN);
                ReplaceText(wordApp, "${OKPO}", OKPO);
                ReplaceText(wordApp, "${TextNum}", STextNum);
                ReplaceText(wordApp, "${NameUlReg}", nameULReg);
                ReplaceText(wordApp, "${RegName}", regName);
                ReplaceText(wordApp, "${RegNum}", regNum);
                ReplaceText(wordApp, "${NumUlReg}", numULReg);
                ReplaceText(wordApp, "${DateUlReg}", regDateUL);
                ReplaceText(wordApp, "${FormIssueECB}", formIssueECB);
                ReplaceText(wordApp, "${Num}", numSeq);
                ReplaceText(wordApp, "${Spec}", spec);                                
                ReplaceText(wordApp, "${IsFinagent}", isFinagent);
                ReplaceText(wordApp, "${NameBondknd}", nameBondknd);
                ReplaceText(wordApp, "${Nin}", NIN);
                ReplaceText(wordApp, "${Count}", count);
                ReplaceText(wordApp, "${Price}", price);
                ReplaceText(wordApp, "${CountDeploy}", countDeploy);
                ReplaceText(wordApp, "${CountBuy}", countBuy);
                ReplaceText(wordApp, "${Amount}", amount);                
                ReplaceText(wordApp, "${Period}", period);
                ReplaceText(wordApp, "${BondNamests}", bondNamests);
                ReplaceText(wordApp, "${Isconvert}", isconvert);
                ReplaceText(wordApp, "${NameRewards}", nameRewards);
                ReplaceText(wordApp, "${Reward}", reward);
                ReplaceText(wordApp, "${PaymentPeriod}", paymentPeriod);
                ReplaceText(wordApp, "${NameRegistrars}", nameRegistrars);
                ReplaceText(wordApp, "${PagentName}", pagentName);
                ReplaceText(wordApp, "${HolderName}", holderName);
                ReplaceText(wordApp, "${NameAudit}", nameAudit);                
                ReplaceText(wordApp, "${DateAnnul}", dateAnnul);
                ReplaceText(wordApp, "${Comments}", comments);
                ReplaceText(wordApp, "${OffName}", offName);
                ReplaceText(wordApp, "${CountHoldersNonres}", countHoldersNonres);
                ReplaceText(wordApp, "${Idrest}", idrest);
                ReplaceText(wordApp, "${Idadvrpm}", idadvrpm);
                ReplaceText(wordApp, "${Idpriorred}", idpriorred);
                ReplaceText(wordApp, "${Eventdefault}", eventdefault);               
                ReplaceText(wordApp, "${Restinfo}", restinfo);
                ReplaceText(wordApp, "${TTenge}", Stenge);
                ReplaceText(wordApp, "${DateReg}", dateReg);
                ReplaceText(wordApp, "${regDateUL}", regDateUL);
                ReplaceText(wordApp, "${CountHolders}", countHolders);
                ReplaceText(wordApp, "${Isconvert}", isconvert);
                ReplaceText(wordApp, "${SpecActiveknd}", specActiveknd);

                ReplaceText(wordApp, "${TNum}", Snum2);
                ReplaceText(wordApp, "${TNumSeq2}", SnumSeq2);
                ReplaceText(wordApp, "${TDateReg}", SdateReg);
                ReplaceText(wordApp, "${TAmount2}", Samount2);                
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
                ReplaceText(wordApp, "${TIsFinagent}", SisFinagent);
                ReplaceText(wordApp, "${TNameBondknd}", SnameBondknd);
                ReplaceText(wordApp, "${TNin}", SNIN);
                ReplaceText(wordApp, "${TCount}", Scount);
                ReplaceText(wordApp, "${TPrice}", Sprice);
                ReplaceText(wordApp, "${TCountDeploy}", ScountDeploy);
                ReplaceText(wordApp, "${TCountBuy}", ScountBuy);
                ReplaceText(wordApp, "${TAmount}", Samount);                
                ReplaceText(wordApp, "${TPeriod}", Speriod);
                ReplaceText(wordApp, "${TBondNamests}", SbondNamests);
                ReplaceText(wordApp, "${TIsconvert}", Sisconvert);
                ReplaceText(wordApp, "${TNameRewards}", SnameRewards);
                ReplaceText(wordApp, "${TReward}", Sreward);
                ReplaceText(wordApp, "${TPaymentPeriod}", SpaymentPeriod);
                ReplaceText(wordApp, "${TNameRegistrars}", SnameRegistrars);
                ReplaceText(wordApp, "${TPagentName}", SpagentName);
                ReplaceText(wordApp, "${THolderName}", SholderName);
                ReplaceText(wordApp, "${TNameAudit}", SnameAudit);
                ReplaceText(wordApp, "${TOrigin}", Sorigin);
                ReplaceText(wordApp, "${TDateAnnul}", SdateAnnul);
                ReplaceText(wordApp, "${TComments}", Scomments);
                ReplaceText(wordApp, "${TOffName}", SoffName);
                ReplaceText(wordApp, "${TCountHoldersNonres}", ScountHoldersNonres);
                ReplaceText(wordApp, "${TIdrest}", Sidrest);
                ReplaceText(wordApp, "${TIdadvrpm}", Sidadvrpm);
                ReplaceText(wordApp, "${TIdpriorred}", Sidpriorred);
                ReplaceText(wordApp, "${TEventdefault}", Seventdefault);               
                ReplaceText(wordApp, "${TRestinfo}", Srestinfo);
                ReplaceText(wordApp, "${TCountHolders} ", ScountHolders);
                ReplaceText(wordApp, "${TAddInfo}", SAddInfo);
                ReplaceText(wordApp, "${TIsconvert}", Sisconvert);
                ReplaceText(wordApp, "${TSpecActiveknd}", SspecActiveknd);
                #endregion
                #region table1
                System.Data.DataTable dt7 = Getcursor7();

                CreateTableWord(wordDoc, dt7.Rows.Count + 2, 4, 2, TableName7, true, true);
                wordcellrange.Font.Size = 9;
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[25];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[26];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[27];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[28];
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
                #region table2
                System.Data.DataTable dt1 = Getcursor1();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 6, 3, TableName1, true,true);

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
                wordcellrange.Text = template[29];
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
                    wordcellrange.Text = dt1.Rows[i]["NAME_KND_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["DATE_CONFIRM"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["DATE_ENDPLC"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["COUNT_DEPLOY"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["AMOUNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt1.Rows[i]["TOTAL"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region TextTable1
                CreateTableWord(wordDoc, 3, 2, 4, ScountHolders, true,false);
                coloumn = 1;
                for (var i = 0; i < 2; i++)
                {
                    coloumn = coloumn + 1;
                    if (coloumn == 2)
                    {
                        STextTable = STotalcountHolders;//  "Всего";
                        TextTable = countHolders;
                    }
                    else if (coloumn == 3)
                    {
                        STextTable = ScountHoldersNonres; //"из них нерезидентов";
                        TextTable = countHoldersNonres;
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
                #region table2
                System.Data.DataTable dt2 = Getcursor2();

                CreateTableWord(wordDoc, dt2.Rows.Count + 1, 4, 5, TableName2, false,true);

                wordcellrange = wordtable.Cell(1, 1).Range;
                wordcellrange.Text = template[5];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(1, 2).Range;
                wordcellrange.Text = template[6];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(1, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(1, 3).Range;
                wordcellrange.Text = template[7];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(1, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(1, 4).Range;
                wordcellrange.Text = template[8];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(1, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                coloumn = 1;
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt2.Rows[i]["NUMPP_HOLDERS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt2.Rows[i]["NAME_HOLDERS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt2.Rows[i]["HOLDERS_CNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt2.Rows[i]["HOLDERS_CNTPLC"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region TextTable2
                CreateTableWord(wordDoc, 3, 2, 6, SAddInfo, true,false);
                coloumn = 1;
                for (var i = 0; i < 2; i++)
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
                #region TextTable3

                CreateTableWord(wordDoc, 1, 2, 7, null, false,false);
                wordcellrange = wordtable.Cell(1, 1).Range;
                wordcellrange.Text = Seventdefault;
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                wordcellrange = wordtable.Cell(1, 2).Range;
                wordcellrange.Text = eventdefault;
                wordcellrange.Font.Bold = 0;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                #endregion
                #region table3
                System.Data.DataTable dt3 = Getcursor3();

                CreateTableWord(wordDoc, dt3.Rows.Count + 2, 5, 8, TableName3, true,true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[9];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[10];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[11];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[12];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[13];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //for (int col = 0; col < wordtable.Columns.Count; col++)
                //{
                //    wordcellrange = wordtable.Cell(3, col + 1).Range;
                //    wordcellrange.Text = Convert.ToString(col + 1);
                //    wordcellrange.Font.Bold = 1;
                //    wordcellrange.Borders.Enable = 1;
                //}
                coloumn = 2;
                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt3.Rows[i]["DEFAULT_PERIOD"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt3.Rows[i]["DEBT_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt3.Rows[i]["SUMMARPM_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;                    
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt3.Rows[i]["DATEOPER_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;                    
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt3.Rows[i]["REASON_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                #endregion
                #region table4
                System.Data.DataTable dt4 = Getcursor4();

                CreateTableWord(wordDoc, dt4.Rows.Count + 2, 4, 9, TableName4, true,true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[14];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[15];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[16];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[17];
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
                for (var i = 0; i < dt4.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt4.Rows[i]["NUM7"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt4.Rows[i]["KIND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt4.Rows[i]["PERIOD7"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt4.Rows[i]["DEBT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table5
                System.Data.DataTable dt5 = Getcursor5();

                CreateTableWord(wordDoc, dt5.Rows.Count + 2, 7, 10, TableName5, true,true);

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
                wordcellrange = wordtable.Cell(2, 6).Range;
                wordcellrange.Text = template[23];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 7).Range;
                wordcellrange.Text = template[24];
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

                CreateTableWord(wordDoc, 1, 2, 11, null, false,false);
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