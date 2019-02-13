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
     * 33.	 Реестр исламских ценных бумаг
     */
    public class RepReestrIS : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal idIslam;
        protected string nameIssuer, nameRegion, address, BIN, OKPO, nameULReg, numULReg, regDateUL, regName, dateReg, regNum, formIssueECB, numSerial, spec;
        protected string isFinagent, nameListing, nameRating, valueCapital, nameAudit, nameRegistrars, holderName, numLicense, dateLicense, originator,nameISknd, NIN;
        protected string amountIssue, countIS, nominalValue, totalPla, countBuy, period, termCirculation, placementsts, isconvert, incomeValue, comPaymentPeriod, comPaymentIncom;
        protected string dateRepay, comRepayment, methodlocalecb, placeaccommecb, commentsRepayment, commentsRedemption, pagentName, comUsePlaIS, dateCancel, comments, offName, commentsDefault;
        protected string totalnonresidents, totalholders;

        #region Constructors
        public RepReestrIS()
        {
        }

        public RepReestrIS(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepReestrIS(RepForm form, LanguageIds language, decimal idIslam)
            : this(form, language)
        {
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


        //Учредители/Акционеры, владеющие свыше 10% акций (по проспекту выпуска):
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
                if (language  == LanguageIds.Russian)
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
                if (language  == LanguageIds.Russian)
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

                    ws.Range["A4"].Value = nameIssuer;
                    ws.Range["A7"].Value = "Область";
                    ws.Range["B7"].Value = nameRegion;
                    ws.Range["D7"].Value = "Адрес   " + address;
                    ws.Range["G7"].Value = "БИН";
                    ws.Range["H7"].Value = BIN;
                    ws.Range["G8"].Value = "ОКПО";
                    ws.Range["H8"].Value = OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A10"].Value = "Регистрация ЮЛ  " + nameULReg + "    " + regDateUL;
                    ws.Range["F10"].Value = "за №";
                    ws.Range["G10"].Value = numULReg;
                    ws.Range["A12"].Value = "Выпуск зарегистрирован";
                    ws.Range["B12"].Value = regName + "    " + dateReg;
                    ws.Range["F12"].Value = "за №";
                    ws.Range["G12"].Value = regNum;
                    ws.Range["A13"].Value = "Форма выпуска  " + formIssueECB;
                    ws.Range["F13"].Value = numSerial;

                    ws.Range["A14"].Value = "Специализация    " + spec;
                    ws.Range["A15"].Value = "Статус эмитента (финансовое агентство)    " + isFinagent;
                    ws.Range["D15"].Value = "Листинг    " + nameListing;
                    ws.Range["E15"].Value = "Рейтинг    " + nameRating;
                    ws.Range["A16"].Value = "Размер уставного капитала";
                    ws.Range["C16"].Value = valueCapital;
                    ws.Range["A17"].Value = "Аудитор эмитента     " + nameAudit;
                    ws.Range["A18"].Value = "Регистратор эмитента    " + nameRegistrars;
                    ws.Range["A19"].Value = "Представитель держателя ИЦБ     " + holderName;
                    ws.Range["A20"].Value = "Лицензия: номер    " + numLicense + "    дата    " + dateLicense + " г.";
                    ws.Range["A21"].Value = "Оригинатор    " + originator;

                    ws.Range["A22"].Value = "Вид ИЦБ";
                    ws.Range["B22"].Value = nameISknd;
                    ws.Range["F22"].Value = "НИН  " + NIN;
                    ws.Range["A23"].Value = "Объем выпуска";
                    ws.Range["B23"].Value = amountIssue;
                    ws.Range["D23"].Value = "Количество ИЦБ";
                    ws.Range["E23"].Value = countIS;
                    ws.Range["A24"].Value = "Номинальная стоимость";
                    ws.Range["B24"].Value = nominalValue;
                    ws.Range["D24"].Value = "Количество размещенных ИЦБ";
                    ws.Range["E24"].Value = totalPla;
                    ws.Range["D25"].Value = "из них выкупленных";
                    ws.Range["E25"].Value = countBuy;
                    ws.Range["A26"].Value = "Период размещения ";
                    ws.Range["B26"].Value = period;

                    ws.Range["D26"].Value = "Срок обращения";
                    ws.Range["E26"].Value = termCirculation;

                    ws.Range["A27"].Value = "Состояние размещения на";
                    ws.Range["B27"].Value = placementsts;
                    ws.Range["A28"].Value = "Возможность конвертирования    " + isconvert;
                    ws.Range["A29"].Value = "Размер дохода";
                    ws.Range["B29"].Value = incomeValue;
                    ws.Range["D29"].Value = "Периодичность выплаты дохода";
                    ws.Range["F29"].Value = comPaymentPeriod;
                    ws.Range["A30"].Value = "Прочие условия выплаты дохода     " + comPaymentIncom;
                    ws.Range["A31"].Value = "Дата погашения   " + dateRepay + " г.";
                    ws.Range["C31"].Value = "Условия погашения    " + comRepayment;
                    ws.Range["A33"].Value = "Место погашения     " + methodlocalecb;
                    ws.Range["E33"].Value = "Способ погашения    " + placeaccommecb;



                    ws.Range["A34"].Value = "Порядок и условия досрочного погашения ИЦБ     " + commentsRepayment;
                    ws.Range["A35"].Value = "Порядок и условия досрочного выкупа ИЦБ    " + commentsRedemption;
                    ws.Range["A36"].Value = "Платежный агент   " + pagentName;
                    ws.Range["A37"].Value = "Использование денег от размещения ИЦБ    " + comUsePlaIS;
                    ws.Range["A38"].Value = "Дата аннулирования    " + dateCancel;
                    ws.Range["A39"].Value = "Примечание     " + comments;

                    ws.Range["A40"].Value = "Выпуск регистрировал   " + offName;
                    ws.Range["B63"].Value = totalholders;
                    ws.Range["D63"].Value = totalnonresidents;
                    ws.Range["A69"].Value = "События, при наступлении которых может быть объявлен дефолт:    " + commentsDefault;
                }
                else
                {
                    ws.Range["A4"].Value = nameIssuer;
                    ws.Range["A7"].Value = "Облысы";
                    ws.Range["B7"].Value = nameRegion;
                    ws.Range["D7"].Value = "Мекен-жайы   " + address;
                    ws.Range["G7"].Value = "БСН";
                    ws.Range["H7"].Value = BIN;
                    ws.Range["G8"].Value = "КҰЖС";
                    ws.Range["H8"].Value = OKPO;
                    // ws.Range["A8"].Font.Bold = true;
                    ws.Range["A10"].Value = "ЗТ тіркеу";
                    ws.Range["B10"].Value =  nameULReg;
                    ws.Range["E10"].Value = regDateUL;
                    ws.Range["F10"].Value = "за №";
                    ws.Range["G10"].Value = numULReg;
                    ws.Range["A12"].Value = "Шығарылым тіркелінді";
                    ws.Range["B12"].Value = regName;
                    ws.Range["E12"].Value = dateReg;
                    ws.Range["F12"].Value = "за №";
                    ws.Range["G12"].Value = regNum;

                    ws.Range["A13"].Value = "Шығарылымның нысаны";
                    ws.Range["B13"].Value = formIssueECB;
                    ws.Range["F13"].Value = numSerial;

                    ws.Range["A14"].Value = "Мамандануы    " + spec;
                    ws.Range["A15"].Value = "Эмитент мәртебесі (қаржылық агенттік)    " + isFinagent;
                    ws.Range["D15"].Value = "Листинг    " + nameListing;
                    ws.Range["E15"].Value = "Рейтинг    " + nameRating;
                    ws.Range["A16"].Value = "Жарғылық капиталдың мөлшері";
                    ws.Range["C16"].Value = valueCapital;
                    ws.Range["A17"].Value = "Аудитор";
                    ws.Range["B17"].Value = nameAudit;
                    ws.Range["A18"].Value = "Регистратор эмитента"; 
                    ws.Range["B18"].Value = nameRegistrars;
                    ws.Range["A19"].Value = "Ұстаушылардың төрағасы"; 
                    ws.Range["B19"].Value =holderName;
                    ws.Range["A20"].Value = "Лицензия:  " + numLicense + "        " + dateLicense + " г.";
                    ws.Range["A21"].Value = "Оригинатор    " + originator;

                    ws.Range["A22"].Value = "ИБҚ түрі";
                    ws.Range["B22"].Value = nameISknd;
                    ws.Range["F22"].Value = "ҰБН  " + NIN;
                    ws.Range["A23"].Value = "Шығарылым көлемі";
                    ws.Range["B23"].Value = amountIssue;
                    ws.Range["D23"].Value = "ИБҚ саны";
                    ws.Range["E23"].Value = countIS;
                    ws.Range["A24"].Value = "Номиналды құны";
                    ws.Range["B24"].Value = nominalValue;
                    ws.Range["D24"].Value = "Орналастырылғандар саны";
                    ws.Range["E24"].Value = totalPla;
                    ws.Range["D25"].Value = "онын ішінде сатып алынғандар";
                    ws.Range["E25"].Value = countBuy;
                    ws.Range["A26"].Value = "Период размещения ";
                    ws.Range["B26"].Value = period;

                    ws.Range["D26"].Value = "Айналыс мерзімі";
                    ws.Range["E26"].Value = termCirculation;

                    ws.Range["A27"].Value = "Орналасу күйі күніне";
                    ws.Range["B27"].Value = placementsts;
                    ws.Range["A28"].Value = "Айрбастау мүмкіндігі    " + isconvert;
                    ws.Range["A29"].Value = "Табыс мөлшері";
                    ws.Range["B29"].Value = incomeValue;
                    ws.Range["D29"].Value = "Төлемнің мерзімділігі";
                    ws.Range["F29"].Value = comPaymentPeriod;
                    ws.Range["A30"].Value = "Табысты төлеу шарты     " + comPaymentIncom;
                    ws.Range["A31"].Value = "Өтеу күні   " + dateRepay + " г.";
                    ws.Range["C31"].Value = "Өтеу шарты    " + comRepayment;
                    ws.Range["A33"].Value = "Өтеу өткізілетін орыны     " + methodlocalecb;
                    ws.Range["E33"].Value = "Өтеу тәсілі    " + placeaccommecb;



                    ws.Range["A34"].Value = "Порядок и условия досрочного погашения ИЦБ     " + commentsRepayment;
                    ws.Range["A35"].Value = "Порядок и условия досрочного выкупа ИЦБ    " + commentsRedemption;
                    ws.Range["A36"].Value = "Төлемді агент   " + pagentName;
                    ws.Range["A37"].Value = "Орналастырудан түскен ақшаны пайдалану    " + comUsePlaIS;
                    ws.Range["A38"].Value = "Күшін жойған күн     " + dateCancel;
                    ws.Range["A39"].Value = "Қосымша     " + comments;

                    ws.Range["A40"].Value = "Шығарылымды тіркеген   " + offName;
                    ws.Range["B63"].Value = totalholders;
                    ws.Range["E63"].Value = totalnonresidents;
                    ws.Range["A69"].Value = "Дефолт жариялауды мүмкіндік әсер ететің оқиғалар:    " + commentsDefault;
                }

                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["NUM_PP_F"]);
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["NAME_FOUNDER"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["NUM_FOUNDER"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt1.Rows[i]["DOCKND"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["PERSENT_VOIT"]);
                    

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

                    (rngDataRow2.Cells[rowIndex1, 1] as Range).Value2 = dt2.Rows[i]["CODE"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 2] as Range).Value2 = dt2.Rows[i]["NAME_APP"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 3] as Range).Value2 = dt2.Rows[i]["FIO"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 4] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["RATIO_SHARE"]);



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

                    (rngDataRow3.Cells[rowIndex3, 1] as Range).Value2 = dt3.Rows[i]["NAME_KND_REP"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 2] as Range).Value2 = dt3.Rows[i]["DATE_CONFIRM_REP"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 3] as Range).Value2 = dt3.Rows[i]["DATE_PLACEMENT_E"].ToString();
                    (rngDataRow3.Cells[rowIndex3, 4] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["TOTAL_PLA_REP"]);
                    (rngDataRow3.Cells[rowIndex3, 5] as Range).Value2 = Convert.ToInt32(dt3.Rows[i]["TOTAL_BORROWED"]);
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

                    (rngDataRow4.Cells[rowIndex4, 1] as Range).Value2 = Convert.ToInt32(dt4.Rows[i]["NUMPP_H"]);
                    (rngDataRow4.Cells[rowIndex4, 2] as Range).Value2 = dt4.Rows[i]["NAME_HOLDER_ECB"].ToString();
                    (rngDataRow4.Cells[rowIndex4, 3] as Range).Value2 = Convert.ToInt32(dt4.Rows[i]["COUNT_HOLDERS"]);
                    (rngDataRow4.Cells[rowIndex4, 4] as Range).Value2 = Convert.ToInt32(dt4.Rows[i]["COUNT_PLA_HOLDERS"]);
                   

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

                    
                    (rngDataRow5.Cells[rowIndex5, 1] as Range).Value2 = dt5.Rows[i]["DEFAULT_PERIOD"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 2] as Range).Value2 = Convert.ToInt32(dt5.Rows[i]["DEBT_DEFAULT"]);
                    (rngDataRow5.Cells[rowIndex5, 3] as Range).Value2 = Convert.ToInt32(dt5.Rows[i]["SUMMARPM_DEFAULT"]);
                    (rngDataRow5.Cells[rowIndex5, 4] as Range).Value2 = dt5.Rows[i]["DATEOPER_DEFAULT"].ToString();
                    (rngDataRow5.Cells[rowIndex5, 5] as Range).Value2 = dt5.Rows[i]["COMMENTS_DEFAULT"].ToString();
                   

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
