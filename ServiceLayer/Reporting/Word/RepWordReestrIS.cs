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
    public class RepWordReestrIS : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
#pragma warning disable CS0169 // The field 'RepWordReestrIS.wordparagraph' is never used
#pragma warning disable CS0108 // 'RepWordReestrIS.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0108 // 'RepWordReestrIS.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning restore CS0169 // The field 'RepWordReestrIS.wordparagraph' is never used
        public Document wordDoc;
        #endregion
        protected decimal idIslam;
        protected string nameIssuer, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regDateUL, regName, dateReg, regNum, formIssueECB, numSerial, spec;
        protected string isFinagent, nameListing, nameRating, valueCapital, nameAudit, nameRegistrars, holderName, numLicense, dateLicense, originator, nameISknd, NIN;
        protected string amountIssue, countIS, nominalValue, totalPla, countBuy, period, termCirculation, placementsts, isconvert, incomeValue, comPaymentPeriod, comPaymentIncom;
        protected string dateRepay, comRepayment, methodlocalecb, placeaccommecb, commentsRepayment, commentsRedemption, pagentName, comUsePlaIS, dateCancel, comments, offName, commentsDefault;
        protected string totalnonresidents, totalholders, datepla;
        protected string SnameIssuer, SnameRegion, Saddress, SBIN, SOKPO, SnameULReg, SnumULReg, SregDateUL, SregName, SdateReg, SregNum, SformIssueECB, SnumSerial, Sspec, SdatemLicense;
        protected string SisFinagent, SnameListing, SnameRating, SvalueCapital, SnameAudit, SnameRegistrars, SholderName, SnumLicense, SdateLicense, Soriginator, SnameISknd, SNIN, Syear;
        protected string SamountIssue, ScountIS, SnominalValue, StotalPla, ScountBuy, Speriod, StermCirculation, Splacementsts, Sisconvert, SincomeValue, ScomPaymentPeriod, ScomPaymentIncom;
        protected string SdateRepay, ScomRepayment, Smethodlocalecb, Splaceaccommecb, ScommentsRepayment, ScommentsRedemption, SpagentName, ScomUsePlaIS, SdateCancel, Scomments, SoffName, ScommentsDefault;
        protected string Stotalnonresidents, Stotalholders, STextNum, ScountBuye, Stext, TableName1, TableName2, TableName3, TableName4, TableName5;
        protected int coloumn;                
        protected string[] template = new string[25]; 
        public RepWordReestrIS(RepForm form, LanguageIds language, decimal idIslam)
            : base(form, language)
        {
            this.form = form;
            this.idIslam = idIslam;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REESTR_IS";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("Name_Issuer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("OKPO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_UL_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_UL_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Date_UL_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Reg_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Form_Issue_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Serial_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Is_Finagent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Listing_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Rating_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Value_Capital_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Audit_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Registrars_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Holder_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_License_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_License_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Originator_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_ISknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Amount_Issue_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_IS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Nominal_Value_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Total_Pla_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Buy_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Term_Circulation_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Placementsts_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Isconvert_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Income_Value_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Com_Payment_Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Com_Payment_Incom_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Repay_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Com_Repayment_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Methodlocalecb_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Placeaccommecb_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_Repayment_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_Redemption_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Pagent_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Com_Use_Pla_IS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Cancel_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Off_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_Default_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Pla_", OracleDbType.Varchar2, ParameterDirection.Output);
                
                cmd.Parameters.Add("Totalnonresidents_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Totalholders_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;
                if (language  == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Name_Issuer_"].Size = 4000;
                cmd.Parameters["Name_Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["OKPO_"].Size = 4000;
                cmd.Parameters["Name_UL_Reg_"].Size = 4000;
                cmd.Parameters["Num_UL_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Date_UL_"].Size = 4000;
                cmd.Parameters["Reg_Name_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Form_Issue_ECB_"].Size = 4000;
                cmd.Parameters["Num_Serial_"].Size = 4000;
                cmd.Parameters["Spec_"].Size = 4000;
                cmd.Parameters["Is_Finagent_"].Size = 4000;

                cmd.Parameters["Name_Listing_"].Size = 4000;
                cmd.Parameters["Name_Rating_"].Size = 4000;
                cmd.Parameters["Value_Capital_"].Size = 4000;
                cmd.Parameters["Name_Audit_"].Size = 4000;
                cmd.Parameters["Name_Registrars_"].Size = 4000;
                cmd.Parameters["Holder_Name_"].Size = 4000;

                cmd.Parameters["Num_License_"].Size = 4000;
                cmd.Parameters["Date_License_"].Size = 4000;
                cmd.Parameters["Originator_"].Size = 4000;
                cmd.Parameters["Name_ISknd_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Amount_Issue_"].Size = 4000;
                cmd.Parameters["Count_IS_"].Size = 4000;

                cmd.Parameters["Nominal_Value_"].Size = 4000;
                cmd.Parameters["Total_Pla_"].Size = 4000;
                cmd.Parameters["Count_Buy_"].Size = 4000;
                cmd.Parameters["Period_"].Size = 4000;
                cmd.Parameters["Term_Circulation_"].Size = 4000;
                cmd.Parameters["Placementsts_"].Size = 4000;
                cmd.Parameters["Isconvert_"].Size = 4000;
                cmd.Parameters["Income_Value_"].Size = 4000;
                cmd.Parameters["Com_Payment_Period_"].Size = 4000;
                cmd.Parameters["Com_Payment_Incom_"].Size = 4000;
                cmd.Parameters["Date_Repay_"].Size = 4000;
                cmd.Parameters["Com_Repayment_"].Size = 4000;
                cmd.Parameters["Methodlocalecb_"].Size = 4000;
                cmd.Parameters["Placeaccommecb_"].Size = 4000;
                cmd.Parameters["Comments_Repayment_"].Size = 4000;
                cmd.Parameters["Comments_Redemption_"].Size = 4000;
                cmd.Parameters["Pagent_Name_"].Size = 4000;
                cmd.Parameters["Com_Use_Pla_IS_"].Size = 4000;
                cmd.Parameters["Date_Cancel_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Off_Name_"].Size = 4000;
                cmd.Parameters["Comments_Default_"].Size = 4000;
                cmd.Parameters["Date_Pla_"].Size = 4000;
                
                cmd.Parameters["Totalnonresidents_"].Size = 4000;
                cmd.Parameters["Totalholders_"].Size = 4000;


                cmd.ExecuteNonQuery();
                
                                nameIssuer = cmd.Parameters["Name_Issuer_"].Value.ToString();
                                if (nameIssuer == "null")
                                {
                                    nameIssuer = string.Empty;
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
                                numULReg = cmd.Parameters["Num_UL_Reg_"].Value.ToString();
                                if (numULReg == "null")
                                {
                                    numULReg = string.Empty;
                                }
                                regDateUL = cmd.Parameters["Reg_Date_UL_"].Value.ToString();
                                if (regDateUL == "null")
                                {
                                    regDateUL = string.Empty;
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
                                numSerial = cmd.Parameters["Num_Serial_"].Value.ToString();
                                if (numSerial == "null")
                                {
                                    numSerial = string.Empty;
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
                                nameListing = cmd.Parameters["Name_Listing_"].Value.ToString();
                                if (nameListing == "null")
                                {
                                    nameListing = string.Empty;
                                }
                                nameRating = cmd.Parameters["Name_Rating_"].Value.ToString();
                                if (nameRating == "null")
                                {
                                    nameRating = string.Empty;
                                }
                                valueCapital = cmd.Parameters["Value_Capital_"].Value.ToString();
                                if (valueCapital == "null")
                                {
                                    valueCapital = string.Empty;
                                }
                                nameAudit = cmd.Parameters["Name_Audit_"].Value.ToString();
                                if (nameAudit == "null")
                                {
                                    nameAudit = string.Empty;
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
                                numLicense = cmd.Parameters["Num_License_"].Value.ToString();
                                if (numLicense == "null")
                                {
                                    numLicense = string.Empty;
                                }
                                dateLicense = cmd.Parameters["Date_License_"].Value.ToString();
                                if (dateLicense == "null")
                                {
                                    dateLicense = string.Empty;
                                }
                                originator = cmd.Parameters["Originator_"].Value.ToString();
                                if (originator == "null")
                                {
                                    originator = string.Empty;
                                }
                                nameISknd = cmd.Parameters["Name_ISknd_"].Value.ToString();
                                if (nameISknd == "null")
                                {
                                    nameISknd = string.Empty;
                                }
                                NIN = cmd.Parameters["NIN_"].Value.ToString();
                                if (NIN == "null")
                                {
                                    NIN = string.Empty;
                                }
                                amountIssue = cmd.Parameters["Amount_Issue_"].Value.ToString();
                                if (amountIssue == "null")
                                {
                                    amountIssue = string.Empty;
                                }
                                countIS = cmd.Parameters["Count_IS_"].Value.ToString();
                                if (countIS == "null")
                                {
                                    countIS = string.Empty;
                                }
                                nominalValue = cmd.Parameters["Nominal_Value_"].Value.ToString();
                                if (nominalValue == "null")
                                {
                                    nominalValue = string.Empty;
                                }
                                totalPla = cmd.Parameters["Total_Pla_"].Value.ToString();
                                if (totalPla == "null")
                                {
                                    totalPla = string.Empty;
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
                                termCirculation = cmd.Parameters["Term_Circulation_"].Value.ToString();
                                if (termCirculation == "null")
                                {
                                    termCirculation = string.Empty;
                                }
                                placementsts = cmd.Parameters["Placementsts_"].Value.ToString();
                                if (placementsts == "null")
                                {
                                    placementsts = string.Empty;
                                }
                                isconvert = cmd.Parameters["Isconvert_"].Value.ToString();
                                if (isconvert == "null")
                                {
                                    isconvert = string.Empty;
                                }

                                incomeValue = cmd.Parameters["Income_Value_"].Value.ToString();
                                if (incomeValue == "null")
                                {
                                    incomeValue = string.Empty;
                                }
                                comPaymentPeriod = cmd.Parameters["Com_Payment_Period_"].Value.ToString();
                                if (comPaymentPeriod == "null")
                                {
                                    comPaymentPeriod = string.Empty;
                                }

                                comPaymentIncom = cmd.Parameters["Com_Payment_Incom_"].Value.ToString();
                                if (comPaymentIncom == "null")
                                {
                                    comPaymentIncom = string.Empty;
                                }
                                dateRepay = cmd.Parameters["Date_Repay_"].Value.ToString();
                                if (dateRepay == "null")
                                {
                                    dateRepay = string.Empty;
                                }
                                comRepayment = cmd.Parameters["Com_Repayment_"].Value.ToString();
                                if (comRepayment == "null")
                                {
                                    comRepayment = string.Empty;
                                }

                                methodlocalecb = cmd.Parameters["Methodlocalecb_"].Value.ToString();
                                if (methodlocalecb == "null")
                                {
                                    methodlocalecb = string.Empty;
                                }

                                placeaccommecb = cmd.Parameters["Placeaccommecb_"].Value.ToString();
                                if (placeaccommecb == "null")
                                {
                                    placeaccommecb = string.Empty;
                                }

                                commentsRepayment = cmd.Parameters["Comments_Repayment_"].Value.ToString();
                                if (commentsRepayment == "null")
                                {
                                    commentsRepayment = string.Empty;
                                }
                                commentsRedemption = cmd.Parameters["Comments_Redemption_"].Value.ToString();
                                if (commentsRedemption == "null")
                                {
                                    commentsRedemption = string.Empty;
                                }
                                pagentName = cmd.Parameters["Pagent_Name_"].Value.ToString();
                                if (pagentName == "null")
                                {
                                    pagentName = string.Empty;
                                }


                                comUsePlaIS = cmd.Parameters["Com_Use_Pla_IS_"].Value.ToString();
                                if (comUsePlaIS == "null")
                                {
                                    comUsePlaIS = string.Empty;
                                }
                                dateCancel = cmd.Parameters["Date_Cancel_"].Value.ToString();
                                if (dateCancel == "null")
                                {
                                    dateCancel = string.Empty;
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

                              commentsDefault = cmd.Parameters["Comments_Default_"].Value.ToString();
                                if (commentsDefault == "null")
                                {
                                    commentsDefault = string.Empty;
                                }

                                totalnonresidents = cmd.Parameters["Totalnonresidents_"].Value.ToString();
                                if (totalnonresidents == "null")
                                {
                                    totalnonresidents = string.Empty;
                                }

                                totalholders = cmd.Parameters["Totalholders_"].Value.ToString();
                                if (totalholders == "null")
                                {
                                    totalholders = string.Empty;
                                }
                                datepla = cmd.Parameters["Date_Pla_"].Value.ToString();
                                if (datepla == "null")
                                {
                                    datepla = string.Empty;
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
                cmd.CommandText = "G_REP_FOUNDERS_IS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;
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

        //Сведения о должностных лицах эмитента:
        public System.Data.DataTable Getcursor2()
        {
            System.Data.DataTable dt2 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_INF_ISSUER";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;
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

        //Отчеты об итогах размещения ИЦБ: 
        public System.Data.DataTable Getcursor3()
        {
            System.Data.DataTable dt3 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_OUTCOME_IS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;
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

        //Держатели ИЦБ:
        public System.Data.DataTable Getcursor4()
        {
            System.Data.DataTable dt4 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_HOLDERS_IS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;
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


        //Сведения о дефолте:
        public System.Data.DataTable Getcursor5()
        {
            System.Data.DataTable dt5 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_DEFAULT_IS";
                cmd.Parameters.Add("Id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idIslam;

                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt5);
                }

                return dt5;
            }
        }
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
            if (language == LanguageIds.Russian)
            {
                Stext = "РЕЕСТР ИСЛАМСКИХ ЦЕННЫХ БУМАГ";
                SnameRegion = "Область";// +nameRegion;
                Saddress = "Адрес";//+ address;
                SBIN = "БИН";//+BIN;
                SOKPO = "ОКПО";//+OKPO;
                SnameULReg = "Регистрация ЮЛ";// + nameULReg + "    " + regDateUL;
                STextNum = "за №";
                SregName = "Выпуск зарегистрирован";//+ regName + "    " + dateReg;                  
                SformIssueECB = "Форма выпуска";// + formIssueECB;
                SnumSerial = "№ п/п выпуска";// + numSerial;
                SnameIssuer = "наименование эмитента";
                Sspec = "Специализация ";// + spec;
                SisFinagent = "Статус эмитента (финансовое агентство): ";// + isFinagent;
                SnameListing = "Листинг ";//+ nameListing;
                SnameRating = "Рейтинг ";// + nameRating;
                SvalueCapital = "Размер уставного капитала ";//+ valueCapital;
                SnameAudit = "Аудитор эмитента ";//+ nameAudit;
                SnameRegistrars = "Регистратор эмитента ";//+ nameRegistrars;
                SholderName = "Представитель держателя ИЦБ ";// + holderName;
                SnumLicense = "Лицензия: номер ";//+ numLicense + "    дата    " + dateLicense + " г.";
                SdatemLicense = "дата ";
                Syear = "г. ";
                Soriginator = "Оригинатор ";// + originator;
                SnameISknd = "Вид ИЦБ ";//+ nameISknd;
                SNIN = "НИН ";//+ NIN;
                SamountIssue = "Объем выпуска";//+ amountIssue;
                ScountIS = "Количество ИЦБ";// + countIS;
                SnominalValue = "Номинальная стоимость";//+ nominalValue;
                StotalPla = "Количество размещенных ИЦБ";// + totalPla;
                ScountBuye = "из них выкупленных";// + countBuy;
                Speriod = "Период размещения";//+period;
                StermCirculation = "Срок обращения ";// + termCirculation;
                Splacementsts = "Состояние размещения на";// + placementsts;
                Sisconvert = "Возможность конвертирования ";// + isconvert;
                SincomeValue = "Размер дохода ";//+ incomeValue;
                ScomPaymentPeriod = "Периодичность выплаты дохода ";//+ comPaymentPeriod;
                ScomPaymentIncom = "Прочие условия выплаты дохода ";//+ comPaymentIncom;
                SdateRepay = "Дата погашения";//+ dateRepay + " г.";
                ScomRepayment = "Условия погашения";//+ comRepayment;
                Smethodlocalecb = "Место погашения";//+ methodlocalecb;
                Splaceaccommecb = "Способ погашения";//+ placeaccommecb;

                ScommentsRepayment = "Порядок и условия досрочного погашения ИЦБ";//+ commentsRepayment;
                ScommentsRedemption = "Порядок и условия досрочного выкупа ИЦБ";//+ commentsRedemption;
                SpagentName = "Платежный агент";//+ pagentName;
                ScomUsePlaIS = "Использование денег от размещения ИЦБ";// + comUsePlaIS;
                SdateCancel = "Дата аннулирования";//+ dateCancel;
                Scomments = "Примечание";// + comments;
                SoffName = "Выпуск регистрировал";//+ offName;
                Stotalholders = totalholders;
                Stotalnonresidents = totalnonresidents;
                ScommentsDefault = "События, при наступлении которых может быть объявлен дефолт:";//+ commentsDefault;
                TableName1 = "Учредители/Акционеры, владеющие свыше 10% акций (по проспекту выпуска):";
                template[0] = "№ п/п";
                template[1] = "Наименование учредителя/акционера";
                template[2] = "ИИН/БИН/ОКПО";
                template[3] = "Вид, номер, дата документа";
                template[4] = "Процентное соотношение голосующих акций";
                TableName2 = "Сведения о должностных лицах эмитента:";
                template[5] = "Код";
                template[6] = "Должность";
                template[7] = "Фамилия, имя, при наличии отчества";
                template[8] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству размещенных акций";
                TableName3 = "Отчеты об итогах размещения ИЦБ:";
                template[9] = "Вид отчета";
                template[10] = "Дата утверждения (принятия к сведению)";
                template[11] = "Дата окончания размещения";
                template[12] = "Количество размещенных ИЦБ";
                template[13] = "Объем привлеченных средств, тг";
                TableName4 = "Держатели ИЦБ:";
                template[14] = "№ п/п";
                template[15] = "Категория держателей ИЦБ";
                template[16] = "Количество держателей";
                template[17] = "Количество размещенных ИЦБ";
                TableName5 = "Сведения о дефолте:";
                template[18] = "Период выплаты";
                template[19] = "Сумма задолженности, тенге";
                template[20] = "Погашение задолженности";
                template[21] = "Дата погашения";
                template[22] = "Примечание";
            }
            else
            {
                Stext = "ИСЛАМ БАҒАЛЫ ҚАҒАЗДАР ТІЗІЛІМІ";
                SnameRegion = "Облысы";// +nameRegion;
                Saddress = "Мекен-жайы ";// + address;
                SBIN = "БСН";//+ BIN;
                SOKPO = "КҰЖС";//+ OKPO;
                SnameULReg = "ЗТ тіркеу";//+ nameULReg + "    " + regDateUL;
                STextNum = "за №";
                SregName = "Шығарылым тіркелінді";// + regName + "    " + dateReg;
                SformIssueECB = "Шығарылымның нысаны";// + formIssueECB;
                SnumSerial = "№ п/п выпуска";//+ numSerial;

                Sspec = "Мамандануы ";// + spec;
                SisFinagent = "Эмитент мәртебесі (қаржылық агенттік): ";// + isFinagent;
                SnameListing = "Листинг ";// + nameListing;
                SnameRating = "Рейтинг ";// + nameRating;
                SvalueCapital = "Жарғылық капиталдың мөлшері ";//+ valueCapital;
                SnameAudit = "Аудитор ";//+ nameAudit;
                SnameRegistrars = "Регистратор эмитента ";//+ nameRegistrars;
                SholderName = "Ұстаушылардың төрағасы ";//+ holderName;
                SnumLicense = "Лицензия: номер ";// + numLicense + "    датасы    " + dateLicense + " ж.";
                Syear = "ж. ";
                SdatemLicense = "датасы ";
                Soriginator = "Оригинатор ";//+ originator;
                SnameIssuer = "эмитенттің атауы";
                SnameISknd = "ИБҚ түрі ";// + nameISknd;
                SNIN = "ҰБН ";//+ NIN;
                SamountIssue = "Шығарылым көлемі";// + amountIssue;
                ScountIS = "ИБҚ саны";//+ countIS;
                SnominalValue = "Номиналды құны";//+ nominalValue;
                StotalPla = "Орналастырылғандар саны";//+ totalPla;
                ScountBuye = "онын ішінде сатып алынғандар";//+ countBuy;
                Speriod = "Период размещения";//+ period;
                StermCirculation = "Айналыс мерзімі ";//+ termCirculation;
                Splacementsts = "Орналасу күйі күніне";//+ placementsts;
                Sisconvert = "Айрбастау мүмкіндігі ";// + isconvert;
                SincomeValue = "Табыс мөлшері ";//+ incomeValue;
                ScomPaymentPeriod = "Төлемнің мерзімділігі ";// + comPaymentPeriod;
                ScomPaymentIncom = "Табысты төлеу шарты ";// + comPaymentIncom;
                SdateRepay = "Өтеу күні";// + dateRepay + " г.";
                ScomRepayment = "Өтеу шарты";// + comRepayment;
                Smethodlocalecb = "Өтеу өткізілетін орыны";//+ methodlocalecb;
                Splaceaccommecb = "Өтеу тәсілі";// + placeaccommecb;

                ScommentsRepayment = "Порядок и условия досрочного погашения ИЦБ";// + commentsRepayment;
                ScommentsRedemption = "Порядок и условия досрочного выкупа ИЦБ";// + commentsRedemption;
                SpagentName = "Төлемді агент";//+ pagentName;
                ScomUsePlaIS = "Орналастырудан түскен ақшаны пайдалану";//+ comUsePlaIS;
                SdateCancel = "Күшін жойған күн";// + dateCancel;
                Scomments = "Қосымша";//+ comments;

                SoffName = "Шығарылымды тіркеген";// + offName;
                Stotalholders = totalholders;
                Stotalnonresidents = totalnonresidents;
                ScommentsDefault = "Дефолт жариялауды мүмкіндік әсер ететің оқиғалар:";//+ commentsDefault;

                TableName1 = "10%-тан артық акцияларға ие акционерлер (шығарылым анықтамалығы бойынша):";
                template[0] = "№";
                template[1] = "Акционердiң атауы";
                template[2] = "ИСН/БСН/ҚҰЖС";
                template[3] = "ЖБҚ атауы мен деректемелері немесе ЗТ мемтіркелу нөмірі мен күні";
                template[4] = "Акциялардың жалпы дауысқа түсетін санына % арақатынасы";
                TableName2 = "Эмитенттің лауазымды тұлғалары туралы деректер:";
                template[5] = "Коды";
                template[6] = "Лаузымы";
                template[7] = "Тегі, аты, бар болса әкесінің аты";
                template[8] = "Лауазымды тұлғаға, қоғамның орналастырған акцияларының жалпы санына тиесілі акциялардың пайыздық арақатынасы";
                TableName3 = "ИБҚ орналастыру есебі:";
                template[9] = "Есептің түрі";
                template[10] = "Бекіту күні(дерекке алу)";
                template[11] = "Орналастыру сонғы куні";
                template[12] = "Орналастырылған ИБҚ саны";
                template[13] = "Кезең ішінде тарту құралдарының көлемі, тг";
                TableName4 = "ИБҚ ұстаушылар:";
                template[14] = "№";
                template[15] = "ИБҚ ұстаушылардың санаты";
                template[16] = "Ұстаушылар саны";
                template[17] = "Орналастырылған ИБҚ саны";
                TableName5 = "Дефолт туралы деректер:";
                template[18] = "Сыйақы кезені";
                template[19] = "Берешек сомасы, теңге";
                template[20] = "Берешек өтеу";
                template[21] = "Өтелген күні";
                template[22] = "Дефолт себебі";
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
                FindAndReplace(wordApp, "${Text}", Stext);
                FindAndReplace(wordApp, "${NameIssuer}", nameIssuer);
                FindAndReplace(wordApp, "${NameRegion}", nameRegion);
                FindAndReplace(wordApp, "${Address}", address);
                FindAndReplace(wordApp, "${BIN}", BIN);
                FindAndReplace(wordApp, "${OKPO}", OKPO);
                FindAndReplace(wordApp, "${TextNum}", STextNum);
                FindAndReplace(wordApp, "${numULReg}", numULReg);
                FindAndReplace(wordApp, "${NameULReg}", nameULReg);
                FindAndReplace(wordApp, "${RegNum}", regNum);
                FindAndReplace(wordApp, "${RegName}", regName);
                FindAndReplace(wordApp, "${FormIssueECB}", formIssueECB);
                FindAndReplace(wordApp, "${NumSerial}", numSerial);
                FindAndReplace(wordApp, "${Spec}", spec);
                FindAndReplace(wordApp, "${IsFinagent}", isFinagent);
                FindAndReplace(wordApp, "${NameListing}", nameListing);
                FindAndReplace(wordApp, "${NameRating}", nameRating);
                FindAndReplace(wordApp, "${ValueCapital}", valueCapital);
                FindAndReplace(wordApp, "${NameAudit}", nameAudit);
                FindAndReplace(wordApp, "${NameRegistrars}", nameRegistrars);
                FindAndReplace(wordApp, "${HolderName}", holderName);
                FindAndReplace(wordApp, "${NumLicense}", numLicense);
                FindAndReplace(wordApp, "${Originator}", originator);
                FindAndReplace(wordApp, "${NameISknd}", nameISknd);
                FindAndReplace(wordApp, "${NIN}", NIN);
                FindAndReplace(wordApp, "${AmountIssue}", amountIssue);
                FindAndReplace(wordApp, "${CountIS}", countIS);
                FindAndReplace(wordApp, "${NominalValue}", nominalValue);
                FindAndReplace(wordApp, "${TotalPla}", totalPla);
                FindAndReplace(wordApp, "${CountBuy}", countBuy);
                FindAndReplace(wordApp, "${Period}", period);
                FindAndReplace(wordApp, "${TermCirculation}", termCirculation);
                FindAndReplace(wordApp, "${Placementsts}", placementsts);
                FindAndReplace(wordApp, "${Isconvert}", isconvert);
                FindAndReplace(wordApp, "${IncomeValue}", incomeValue);
                FindAndReplace(wordApp, "${ComPaymentPeriod}", comPaymentPeriod);
                FindAndReplace(wordApp, "${ComPaymentIncom}", comPaymentIncom);
                FindAndReplace(wordApp, "${DateRepay}", dateRepay);
                FindAndReplace(wordApp, "${ComRepayment}", comRepayment);
                FindAndReplace(wordApp, "${Methodlocalecb}", methodlocalecb);
                FindAndReplace(wordApp, "${Placeaccommecb}", placeaccommecb);
                FindAndReplace(wordApp, "${CommentsRepayment}", commentsRepayment);
                FindAndReplace(wordApp, "${CommentsRedemption}", commentsRedemption);
                FindAndReplace(wordApp, "${PagentName}", pagentName);
                FindAndReplace(wordApp, "${ComUsePlaIS}", comUsePlaIS);
                FindAndReplace(wordApp, "${DateCancel}", dateCancel);
                FindAndReplace(wordApp, "${Comments}", comments);
                FindAndReplace(wordApp, "${OffName}", offName);
                FindAndReplace(wordApp, "${DateReg}", dateReg);
                FindAndReplace(wordApp, "${regDateUL}", regDateUL);
                FindAndReplace(wordApp, "${NumLicense}", numLicense);
                FindAndReplace(wordApp, "${DateLicense}", dateLicense);
                FindAndReplace(wordApp, "${TY}", Syear);
                FindAndReplace(wordApp, "${CommentsDefault}", commentsDefault);
                FindAndReplace(wordApp, "${DatePla}", datepla);
                
                FindAndReplace(wordApp, "${TCommentsDefault}", ScommentsDefault);
                FindAndReplace(wordApp, "${TNameIssuer}", SnameIssuer);
                FindAndReplace(wordApp, "${TNameRegion}", SnameRegion);
                FindAndReplace(wordApp, "${TAddress}", Saddress);
                FindAndReplace(wordApp, "${TBIN}", SBIN);
                FindAndReplace(wordApp, "${TOKPO}", SOKPO);
                FindAndReplace(wordApp, "${TextNum}", STextNum);
                FindAndReplace(wordApp, "${TnumULReg}", SnumULReg);
                FindAndReplace(wordApp, "${TNameULReg}", SnameULReg);
                FindAndReplace(wordApp, "${TRegNum}", SregNum);
                FindAndReplace(wordApp, "${TRegName}", SregName);
                FindAndReplace(wordApp, "${TFormIssueECB}", SformIssueECB);
                FindAndReplace(wordApp, "${TNumSerial}", SnumSerial);
                FindAndReplace(wordApp, "${TSpec}", Sspec);
                FindAndReplace(wordApp, "${TIsFinagent}", SisFinagent);
                FindAndReplace(wordApp, "${TNameListing}", SnameListing);
                FindAndReplace(wordApp, "${TNameRating}", SnameRating);
                FindAndReplace(wordApp, "${TValueCapital}", SvalueCapital);
                FindAndReplace(wordApp, "${TNameAudit}", SnameAudit);
                FindAndReplace(wordApp, "${TNameRegistrars}", SnameRegistrars);
                FindAndReplace(wordApp, "${THolderName}", SholderName);
                FindAndReplace(wordApp, "${TNumLicense}", SnumLicense);
                FindAndReplace(wordApp, "${TOriginator}", Soriginator);
                FindAndReplace(wordApp, "${TNameISknd}", SnameISknd);
                FindAndReplace(wordApp, "${TNIN}", SNIN);
                FindAndReplace(wordApp, "${TAmountIssue}", SamountIssue);
                FindAndReplace(wordApp, "${TCountIS}", ScountIS);
                FindAndReplace(wordApp, "${TNominalValue}", SnominalValue);
                FindAndReplace(wordApp, "${TTotalPla}", StotalPla);
                FindAndReplace(wordApp, "${TCountBuy}", ScountBuy);
                FindAndReplace(wordApp, "${TPeriod}", Speriod);
                FindAndReplace(wordApp, "${TTermCirculation}", StermCirculation);
                FindAndReplace(wordApp, "${TPlacementsts}", Splacementsts);
                FindAndReplace(wordApp, "${TIsconvert}", Sisconvert);
                FindAndReplace(wordApp, "${TIncomeValue}", SincomeValue);
                FindAndReplace(wordApp, "${TComPaymentPeriod}", ScomPaymentPeriod);
                FindAndReplace(wordApp, "${TComPaymentIncom}", ScomPaymentIncom);
                FindAndReplace(wordApp, "${TDateRepay}", SdateRepay);
                FindAndReplace(wordApp, "${TComRepayment}", ScomRepayment);
                FindAndReplace(wordApp, "${TMethodlocalecb}", Smethodlocalecb);
                FindAndReplace(wordApp, "${TPlaceaccommecb}", Splaceaccommecb);
                FindAndReplace(wordApp, "${TCommentsRepayment}", ScommentsRepayment);
                FindAndReplace(wordApp, "${TCommentsRedemption}", ScommentsRedemption);
                FindAndReplace(wordApp, "${TPagentName}", SpagentName);
                FindAndReplace(wordApp, "${TComUsePlaIS}", ScomUsePlaIS);
                FindAndReplace(wordApp, "${TDateCancel}", SdateCancel);
                FindAndReplace(wordApp, "${TComments}", Scomments);
                FindAndReplace(wordApp, "${TOffName}", SoffName);
                FindAndReplace(wordApp, "${TDateReg}", dateReg);
                FindAndReplace(wordApp, "${TregDateUL}", regDateUL);
                FindAndReplace(wordApp, "${TNumLicense}", numLicense);
                FindAndReplace(wordApp, "${TDateLicense}", dateLicense);
                #endregion
                #region table1
                System.Data.DataTable dt1 = Getcursor1();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 5, 2, TableName1, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[0];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[1];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[2];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[3];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[4];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
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
                    wordcellrange.Text = dt1.Rows[i]["NUM_PP_F"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["NAME_FOUNDER"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["NUM_FOUNDER"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["DOCKND"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; 
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["PERSENT_VOIT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                }
                #endregion
                #region table2
                System.Data.DataTable dt2 = Getcursor2();

                CreateTableWord(wordDoc, dt2.Rows.Count + 2, 4, 3, TableName2, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[5];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[6];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[7];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[8];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
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
                    wordcellrange.Text = dt2.Rows[i]["CODE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt2.Rows[i]["NAME_APP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt2.Rows[i]["FIO"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt2.Rows[i]["RATIO_SHARE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                }
                #endregion
                #region table3
                System.Data.DataTable dt3 = Getcursor3();

                CreateTableWord(wordDoc, dt3.Rows.Count + 2, 5, 4, TableName3, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[9];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[10];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[11];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[12];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[13];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
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
                    wordcellrange.Text = dt3.Rows[i]["NAME_KND_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt3.Rows[i]["DATE_CONFIRM_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt3.Rows[i]["DATE_PLACEMENT_E"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt3.Rows[i]["TOTAL_PLA_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt3.Rows[i]["TOTAL_BORROWED"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                }
                #endregion
                #region table4
                System.Data.DataTable dt4 = Getcursor4();

                CreateTableWord(wordDoc, dt4.Rows.Count + 2, 4, 5, TableName4, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[14];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[15];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[16];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[17];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
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
                    wordcellrange.Text = dt4.Rows[i]["NUMPP_H"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt4.Rows[i]["NAME_HOLDER_ECB"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt4.Rows[i]["COUNT_HOLDERS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt4.Rows[i]["COUNT_PLA_HOLDERS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                }
                #endregion
                #region TextTable3

                CreateTableWord(wordDoc, 1, 2, 6, null, false,false);
                wordcellrange = wordtable.Cell(1, 1).Range;
                wordcellrange.Text = ScommentsDefault;
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                wordcellrange = wordtable.Cell(1, 2).Range;
                wordcellrange.Text = commentsDefault;
                wordcellrange.Font.Bold = 0;
                wordcellrange.Borders.Enable = 0;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                #endregion
                #region table5
                System.Data.DataTable dt5 = Getcursor5();

                CreateTableWord(wordDoc, dt5.Rows.Count + 2, 5, 7, TableName5, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[18];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[19];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[20];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[21];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[22];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
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
                    wordcellrange.Text = dt5.Rows[i]["DEFAULT_PERIOD"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt5.Rows[i]["DEBT_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt5.Rows[i]["SUMMARPM_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt5.Rows[i]["DATEOPER_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt5.Rows[i]["COMMENTS_DEFAULT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
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