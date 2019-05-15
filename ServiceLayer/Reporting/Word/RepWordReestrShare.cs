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
    public class RepWordReestrShare : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idShare;
        protected string valueCapital, cntDecShare, priceShare, cntreppla;
        protected string nameRu, nameKz, nameRegion, address, BIN, OKPO, name, regDate, regNum, reg, dateReg, numReg, formIssueECB, num, activeknd, specActiveknd, spec;
        protected string isPublic, isFinagent, isRFCA, isGovhaveshare, isNonres, isHavecode, placementsts, dateCancel, reasonAnnul, nameReg, infoSharia, commentsStruct;
        protected string restinfo, num_serial;
        protected string managementCompany, custodian, registrars, payAgent, auditors, ishavetechbuy, dateplacement;

        protected string SvalueCapital, ScntDecShare, SpriceShare, Scntreppla;
        protected string SnameRu, SnameKz, SnameRegion, Saddress, SBIN, SOKPO, Sname, SregDate, SregNum, Sreg, SdateReg, SnumReg, SformIssueECB, Snum, Sactiveknd, SspecActiveknd, Sspec;
        protected string SisPublic, SisFinagent, SisRFCA, SisGovhaveshare, SisNonres, SisHavecode, Splacementsts, SdateCancel, SreasonAnnul, SnameReg, SinfoSharia, ScommentsStruct, SNumSerial;
        protected string Srestinfo, Stext, STextNum;
        protected string SmanagementCompany, Scustodian, Sregistrars, SpayAgent, Sauditors, SIshavetechbuy;

        protected string TableName1, TableName2, TableName3, TableName4, TableName5, TableName6, TableName7, Text, SText;
        protected int coloumn;                
        protected string[] template = new string[40];
        public RepWordReestrShare(RepForm form, LanguageIds language, decimal? idShare)
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
                cmd.Parameters.Add("Ishavetechbuy_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Placement_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Serial_", OracleDbType.Varchar2, ParameterDirection.Output);

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
                cmd.Parameters["Ishavetechbuy_"].Size = 4000;
                cmd.Parameters["Date_Placement_"].Size = 4000;
                cmd.Parameters["Num_Serial_"].Size = 4000;
                
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
                if (commentsStruct == "null")
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
                ishavetechbuy = cmd.Parameters["Ishavetechbuy_"].Value.ToString();
                if (ishavetechbuy == "null")
                {
                    ishavetechbuy = string.Empty;
                }
                dateplacement = cmd.Parameters["Date_Placement_"].Value.ToString();
                if (dateplacement == "null")
                {
                    dateplacement = string.Empty;
                }
                num_serial = cmd.Parameters["Num_Serial_"].Value.ToString();
                if (num_serial == "null")
                {
                    num_serial = string.Empty;
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
        //Акционеры, владеющие свыше 10% акций (по проспекту выпуска)
        public System.Data.DataTable Getcursor6()
        {
            System.Data.DataTable dt6 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SHAREFOUNDER";
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
                    oda.Fill(dt6);
                }

                return dt6;
            }
        }

        public System.Data.DataTable Getcursor7()
        {
            System.Data.DataTable dt7 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_SHAREINFOOFF";
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
                    Stext = "РЕЕСТР АКЦИЙ";
                    SnameRu = "Наименование на рус";//+nameRu;
                    SnameKz = "Наименование на каз";//+nameKz;
                    SnameRegion = "Область ";//+ nameRegion;
                    Saddress = "Адрес";//+ address;
                    SBIN = "БИН";//+ BIN;
                    SOKPO = "ОКПО";//+ OKPO;
                    Sname = "Регистрация ЮЛ";//+ name;
                    SregDate = "Дата";//+ regDate;
                    SregNum = "за №";//+ regNum;
                    Sreg = "Выпуск зарегистрирован";//+ reg;
                    SdateReg = "Дата";//+ dateReg;
                    SnumReg = "за №";//+ numReg;
                    SformIssueECB = "Форма выпуска";//+ formIssueECB;                    
                    //ws.Range["E11"].Value = num;
                    Sactiveknd = "Вид деятельности: ";// +activeknd;                    
                    SspecActiveknd = "Специализация по виду деятельности: ";//+ specActiveknd;
                    Sspec = "Специализация: ";//+ spec;
                    SisPublic = "Статус публичной компании: ";// + isPublic;
                    SisFinagent = "Статус эмитента (финансовое агентство): ";//+ isFinagent;
                    SisRFCA = "Участник РФЦА: ";// + isRFCA;
                    SisGovhaveshare = "Наличие госдоли в УК: ";// + isGovhaveshare;
                    SisNonres = "Участие нерезидентов РК в УК: ";// + isNonres;
                    SisHavecode = "Наличие кодекса корпоративного управления: ";// + isHavecode;
                    STextNum = "за №";
                    SvalueCapital = "Размер  УК: ";//+ valueCapital;                    
                    ScntDecShare = "Общее количество акций выпуска";// + cntDecShare;
                    SpriceShare = "Номинальная стоимость акций";//+ priceShare;
                    Splacementsts = "Состояние размещения акций на";// + placementsts;
                    Scntreppla = "Объем размещения по утвержденным отчетам";// + cntreppla;
                    SIshavetechbuy = "Наличие методики выкупа акций: ";
                    SdateCancel = "Дата аннулирования";
                    SreasonAnnul = "Причина аннулирования";// + reasonAnnul;
                    SnameReg = "Выпуск регистрировал";//+ nameReg;
                    //otchet

                    SmanagementCompany = "Управляющая компания";//+ managementCompany;
                    Scustodian = "Кастодиан";//+ custodian;
                    Sregistrars = "Регистратор";// + registrars;
                    SpayAgent = "Платежный агент";//+ payAgent;
                    Sauditors = "Аудитор";//+ auditors;

                    SinfoSharia = "Сведения о совете по шариату";                    
                    ScommentsStruct = "Примечание";                    
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента";
                    SNumSerial = "№ п/п выпуска";
                    TableName1 = "Структура выпуска: ";
                    template[0] = "Вид и категории акции";
                    template[1] = "НИН";
                    template[2] = "Количество";
                    template[3] = "Гарантир. размер дивидендов";
                    template[4] = "Примечание";
                    TableName2 = "Отчеты об итогах размещения акций: ";
                    template[5] = "Вид отчета";
                    template[6] = "Дата утверждения (принятия к сведению)";
                    template[7] = "Дата окончания размещения";
                    template[8] = "Общее количество размещенных акций";
                    template[9] = "Из них размещено за период";
                    template[10] = "Объем размещения, тг";

                    TableName3 = "Крупные акционеры (по отчету об итогах размещения акций): ";
                    template[11] = "№ п/п";
                    template[12] = "Наименование акционер";
                    template[13] = "Наименование и реквизиты УДЛ или номер и дата гос.регистрации ЮЛ";
                    template[14] = "Общее количество акций, принадлежащих акционеру";
                    template[15] = "Процентное соотношение акций к общему количеству размещенных акций %";
                    template[16] = "Процентное соотношение акций к общему количеству голосующих акций %";

                    TableName4 = "Иные выпуски ценных бумаг: ";
                    template[17] = "Номер выпуска";
                    template[18] = "Вид ценной бумаги";
                    template[19] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[20] = "Задолженности по выплате";
                    TableName5 = "Примененные ОМВ и санкции:";
                    template[21] = "№ п/п";
                    template[22] = "Дата рассмотрения";
                    template[23] = "Номер и дата письма";
                    template[24] = "Вид ОМВ/санкции";
                    template[25] = "Содержание";
                    template[26] = "Срок исполнения ";
                    template[27] = "Примечание";

                    TableName6 = "Акционеры, владеющие свыше 10% акций (по проспекту выпуска):";
                    template[28] = "№п/п";
                    template[29] = "Наименование акционера";
                    template[30] = "Наименование и реквизиты УДЛ или номер и дата гос.регистрации ЮЛ";
                    template[31] = "Количество акций предварительно оплаченных учредителем";
                    template[32] = "Процентное соотношение голосующих акций";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[33] = "№п/п";
                    template[34] = "Должность";
                    template[35] = "Фамилия, имя, при наличии отчество";
                    template[36] = "Количество акций предварительно оплаченных учредителем";
                    template[37] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству акций, размещенных Обществом";
                    #endregion 
                }
                else
                {
                    #region TextKz
                    Stext = "АКЦИЯЛАР ТІЗІЛІМІ";
                    SnameKz = "Атауы ";//+nameKz;
                    SnameRu = "Атауы";//+nameRu;
                    SnameRegion = "Обласы";//+ nameRegion;                    
                    Saddress = "Мекен-жайы";// + address;
                    SBIN = "БСН";// + BIN;
                    SOKPO = "КҰЖС";//+ OKPO;                    
                    Sname = "ЗТ тіркелу";// + name;
                    SregDate = " ";//+ regDate;
                    SregNum = "№ ";//+ regNum;

                    Sreg = "Шығарылым тіркелінді";// + reg;
                    SdateReg = " ";// + dateReg;
                    SnumReg = "№ ";// + numReg;
                    SNumSerial = "№ п/п выпуска";
                    SformIssueECB = "Шығарылымның нысаны";                    
                    //ws.Range["E10"].Value = num;

                    Sactiveknd = "Қызмет түрі: ";
                    SspecActiveknd = "Қызмет бойынша мамандануы: ";//+ specActiveknd;
                    Sspec = "Мамандануы :   " + spec;
                    SisPublic = "Бұқаралық компанияның мәртебесі: ";//+ isPublic;
                    SisFinagent = "Эмитент мәртебесі (қаржылық агенттік): ";// + isFinagent;
                    SisRFCA = "ААҚО қатысушысы: ";//+ isRFCA;
                    SisGovhaveshare = "Мемүлестің ЖК болуы: ";// + isGovhaveshare;
                    SisNonres = "ҚР резиденттері еместердің ЖК қатысуы: ";// + isNonres;
                    SisHavecode = "Корпоративтік басқару кодексінің болуы: ";// + isHavecode;

                    SvalueCapital = "ЖК көлемі: ";//+ valueCapital;
                    ScntDecShare = "Общее количество акций выпуска";//+ cntDecShare;
                    SpriceShare = "Номинальная стоимость акций";//+ priceShare;
                    Splacementsts = "Акциялардың орналасу күйі күніне";//+ placementsts;
                    Scntreppla = "Бекітілген есептер бойынша орналасу көлемі";// + cntreppla;

                    SdateCancel = "Күшін жойған күн";//+dateCancel;                    
                    SreasonAnnul = "Күшін жою себебі";//+ reasonAnnul;
                    SnameReg = "Шығарылымды тіркеген";// + nameReg;
                    //otchet

                    SmanagementCompany = "Басқарушы компания: ";//+ managementCompany;
                    Scustodian = "Кастодиан: ";//+ custodian;
                    Sregistrars = "Тіркеуші: ";//+ registrars;
                    SpayAgent = "Төлемді агенттің атауы: ";// + payAgent;
                    Sauditors = "Аудитор: ";//+ auditors;

                    SinfoSharia = "Шариат кеңесі: ";
                    ScommentsStruct = "Қосымша: ";//+ commentsStruct;                    
                    Srestinfo = "Основные сведения о реструктуризации обязательств эмитента: ";//+ restinfo;
                    STextNum = "№";
                    TableName1 = "Шығарылым құрылымы: ";
                    template[0] = "Акциялардың түрі мен санаттары";
                    template[1] = "ҰБН";
                    template[2] = "Саны";
                    template[3] = "Дивиденттердің кепілденген мөлшері";
                    template[4] = "Қосымша";
                    TableName2 = "Акцияларды орналастыру есебі: ";
                    template[5] = "Есептің түрі";
                    template[6] = "Бекіту күні(дерекке алу)";
                    template[7] = "Орналастыру сонғы куні";
                    template[8] = "Орналастырылған акциялар жалпы саны";
                    template[9] = "Онын ішінде кезең бойы орналыстырған";
                    template[10] = "Орналастыру көлемі, тг";

                    TableName3 = "Ірі акционерлер (акцияларды орналастыру есебі бойынша):";
                    template[11] = "№ р/н";
                    template[12] = "Акционердің атауы";
                    template[13] = "ЖБҚ атауы мен деректемелері немесе ЗТ мемтіркелу нөмірі мен күні";
                    template[14] = "Акционерге тиесілі акциялардың жалпы саны";
                    template[15] = "Акциялардың  орналасқан акциялардың жалпы санына пайыздық арақатынасы  %";
                    template[16] = "Акциялардың  дауысқа түсетін акциялардың жалпы санына пайыздық арақатынасы  %";

                    TableName4 = "Иные выпуски ценных бумаг:";
                    template[17] = "Шығарылым нөмірі";
                    template[18] = "Вид ценной бумаги";
                    template[19] = "Купонный период, за который допущен дефолт (в случае наличия)";
                    template[20] = "Задолженности по выплате";

                    TableName5 = "Примененные ОМВ и санкции:";
                    template[21] = "№ п/п";
                    template[22] = "Дата рассмотрения";
                    template[23] = "Номер и дата письма";
                    template[24] = "Вид ОМВ/санкции";
                    template[25] = "Содержание";
                    template[26] = "Срок исполнения ";
                    template[27] = "Примечание";

                    TableName6 = "Акционеры, владеющие свыше 10% акций (по проспекту выпуска):";
                    template[28] = "№п/п";
                    template[29] = "Наименование акционера";
                    template[30] = "Наименование и реквизиты УДЛ или номер и дата гос.регистрации ЮЛ";
                    template[31] = "Количество акций предварительно оплаченных учредителем";
                    template[32] = "Процентное соотношение голосующих акций";

                    TableName7 = "Сведения о должностных лицах эмитента:";
                    template[33] = "№п/п";
                    template[34] = "Должность";
                    template[35] = "Фамилия, имя, при наличии отчество";
                    template[36] = "Количество акций предварительно оплаченных учредителем";
                    template[37] = "Процентное соотношение акций, принадлежащих должностному лицу, к общему количеству акций, размещенных Обществом";
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
                FindAndReplace(wordApp, "${TEXT}", Stext);
                FindAndReplace(wordApp, "${TNameru}", SnameRu);
                FindAndReplace(wordApp, "${TNamekz}", SnameKz);
                FindAndReplace(wordApp, "${TNameRegion}", SnameRegion);
                FindAndReplace(wordApp, "${TAddress}", Saddress);
                FindAndReplace(wordApp, "${TBIN}", SBIN);
                FindAndReplace(wordApp, "${TOKPO}", SOKPO);
                FindAndReplace(wordApp, "${TTextNum}", STextNum);
                FindAndReplace(wordApp, "${TName}", Sname);
                FindAndReplace(wordApp, "${TNumReg}", SnumReg);
                FindAndReplace(wordApp, "${TRegNum}", SregNum);
                FindAndReplace(wordApp, "${TRegName}", Sreg);
                FindAndReplace(wordApp, "${TFormIssueECB}", SformIssueECB);
                FindAndReplace(wordApp, "${TNum}", SregNum);
                FindAndReplace(wordApp, "${TSpec}", Sspec);
                FindAndReplace(wordApp, "${TActiveknd}", Sactiveknd);
                FindAndReplace(wordApp, "${TSpecActiveknd}", SspecActiveknd);
                FindAndReplace(wordApp, "${TIsFinagent}", SisFinagent);
                FindAndReplace(wordApp, "${TIsPublic}", SisPublic);
                FindAndReplace(wordApp, "${TIsRFCA}", SisRFCA);
                FindAndReplace(wordApp, "${TIsGovhaveshare}", SisGovhaveshare);
                FindAndReplace(wordApp, "${TIsNonres}", SisNonres);
                FindAndReplace(wordApp, "${TIsHavecode}", SisHavecode);                
                FindAndReplace(wordApp, "${TValueCapital}", SvalueCapital);
                FindAndReplace(wordApp, "${TCntDecSharel}", ScntDecShare);
                FindAndReplace(wordApp, "${TPriceShare}", SpriceShare);
                FindAndReplace(wordApp, "${TPlacementsts}", Splacementsts);
                FindAndReplace(wordApp, "${TCntreppla}", Scntreppla);
                FindAndReplace(wordApp, "${TDateCancel}", SdateCancel);
                FindAndReplace(wordApp, "${TReasonAnnul}", SreasonAnnul);
                FindAndReplace(wordApp, "${TNameReg}", SnameReg);
                FindAndReplace(wordApp, "${TManagementCompany}", SmanagementCompany);
                FindAndReplace(wordApp, "${TNameCustodian}", Scustodian);
                FindAndReplace(wordApp, "${TNameRegistrars}", Sregistrars);
                FindAndReplace(wordApp, "${TNameAudit}", Sauditors);
                FindAndReplace(wordApp, "${TPayAgent}", SpayAgent);
                FindAndReplace(wordApp, "${TTInfoSharia}", SinfoSharia);
                FindAndReplace(wordApp, "${TInfoSharia}", infoSharia);
                FindAndReplace(wordApp, "${TCommentsStruct}", ScommentsStruct);
                FindAndReplace(wordApp, "${TRestinfo}", Srestinfo);
                FindAndReplace(wordApp, "${TNumSerial}", SNumSerial);
                FindAndReplace(wordApp, "${TIshavetechbuy}", SIshavetechbuy);
                
                FindAndReplace(wordApp, "${Nameru}", nameRu);
                FindAndReplace(wordApp, "${Namekz}", nameKz);
                FindAndReplace(wordApp, "${NameRegion}", nameRegion);
                FindAndReplace(wordApp, "${Address}", address);
                FindAndReplace(wordApp, "${BIN}", BIN);
                FindAndReplace(wordApp, "${OKPO}", OKPO);
                FindAndReplace(wordApp, "${TextNum}", STextNum);
                FindAndReplace(wordApp, "${Name}", name);
                FindAndReplace(wordApp, "${NumReg}", numReg);
                FindAndReplace(wordApp, "${RegNum}",regNum);
                FindAndReplace(wordApp, "${RegName}", reg);
                FindAndReplace(wordApp, "${FormIssueECB}", formIssueECB);
                FindAndReplace(wordApp, "${Num}", num);
                FindAndReplace(wordApp, "${Spec}", spec);
                FindAndReplace(wordApp, "${Activeknd}", activeknd);
                FindAndReplace(wordApp, "${SpecActiveknd}", specActiveknd);
                FindAndReplace(wordApp, "${IsFinagent}", isFinagent);
                FindAndReplace(wordApp, "${IsPublic}", isPublic);
                FindAndReplace(wordApp, "${IsRFCA}", isRFCA);
                FindAndReplace(wordApp, "${IsGovhaveshare}", isGovhaveshare);
                FindAndReplace(wordApp, "${IsNonres}", isNonres);
                FindAndReplace(wordApp, "${IsHavecode}", isHavecode);
                FindAndReplace(wordApp, "${ValueCapital}", valueCapital);
                FindAndReplace(wordApp, "${CntDecSharel}", cntDecShare);
                FindAndReplace(wordApp, "${PriceShare}", priceShare);
                FindAndReplace(wordApp, "${Placementsts}", placementsts);
                FindAndReplace(wordApp, "${Cntreppla}", cntreppla);
                FindAndReplace(wordApp, "${DateCancel}", dateCancel);
                FindAndReplace(wordApp, "${ReasonAnnul}", reasonAnnul);
                FindAndReplace(wordApp, "${NameReg}", nameReg);
                FindAndReplace(wordApp, "${ManagementCompany}", managementCompany);
                FindAndReplace(wordApp, "${NameCustodian}", custodian);
                FindAndReplace(wordApp, "${NameRegistrars}", registrars);
                FindAndReplace(wordApp, "${NameAudit}", auditors);
                FindAndReplace(wordApp, "${PayAgent}", payAgent);
                FindAndReplace(wordApp, "${InfoSharia}", infoSharia);
                FindAndReplace(wordApp, "${InfoSharia}", infoSharia);
                FindAndReplace(wordApp, "${CommentsStruct}", commentsStruct);
                FindAndReplace(wordApp, "${Restinfo}", restinfo);
                FindAndReplace(wordApp, "${ReDate}", regDate);
                FindAndReplace(wordApp, "${DateReg}", dateReg);
                FindAndReplace(wordApp, "${Ishavetechbuy}", ishavetechbuy);
                FindAndReplace(wordApp, "${DatePla}", dateplacement);
                FindAndReplace(wordApp, "${NumSerial}", num_serial);
                
                #endregion

                #region table1
                System.Data.DataTable dt1 = Getcursor1();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 5, 2, TableName1, true, true);                
                wordcellrange = wordtable.Cell(2, 1).Range; 
                wordcellrange.Text = template[0];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;               
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
                coloumn = 2;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt1.Rows[i]["NAMERU"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment =  WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["NIN"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                   // wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["CNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    //wordtable.Cell(coloumn, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["DGS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    //wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["COMMENTS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 5).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                #endregion
                #region TextTable1

                CreateTableWord(wordDoc, 5, 2, 3, null, false,false);
                coloumn = 0;
                for (var i = 0; i < 5; i++)
                {
                    coloumn = coloumn + 1;
                    if (coloumn == 1)
                    {
                        SText = SmanagementCompany;
                        Text = managementCompany;
                    }
                    else if (coloumn == 2)
                    {
                        SText = Scustodian;
                        Text = custodian;
                    }
                    else if (coloumn == 3)
                    {
                        SText = Sregistrars;
                        Text = registrars;
                    }
                    else if (coloumn == 4)
                    {
                        SText = SpayAgent;
                        Text = payAgent;
                    }
                    else if (coloumn == 5)
                    {
                        SText = Sauditors;
                        Text = auditors;
                    }
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = SText;
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = Text;
                    wordcellrange.Font.Bold = 1;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                
                #endregion
                #region table2
                System.Data.DataTable dt2 = Getcursor2();

                CreateTableWord(wordDoc, dt2.Rows.Count + 2, 6, 4, TableName2, true, true);                
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[5];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[6];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[7];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[8];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[9];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 6).Range;
                wordcellrange.Text = template[10];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;                
                coloumn = 2;
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt2.Rows[i]["NAME_KND_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt2.Rows[i]["DATE_PRV_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt2.Rows[i]["DATE_PLACEMENT_E"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt2.Rows[i]["TOTAL"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt2.Rows[i]["COUNT_PLA_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt2.Rows[i]["TOTAL_PLA_REP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table3
                System.Data.DataTable dt6 = Getcursor6();

                CreateTableWord(wordDoc, dt6.Rows.Count + 2, 5, 5, TableName6, true, true);
                wordcellrange.Font.Size = 9;
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[28];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[29];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[30];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[31];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[32];
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
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
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
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt6.Rows[i]["COUNT_PREV_SHARE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt6.Rows[i]["PERSENT_VOIT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;

                }
                #endregion
                #region table4
                System.Data.DataTable dt3 = Getcursor3();

                CreateTableWord(wordDoc, dt3.Rows.Count + 2, 6, 6, TableName3, true, true);                
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
                coloumn = 2;
                for (var i = 0; i < dt3.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt3.Rows[i]["NUM_PP"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt3.Rows[i]["NAME"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt3.Rows[i]["NUM"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt3.Rows[i]["TOTAL_SHARE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt3.Rows[i]["RATIO_TOTAL_PLA"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt3.Rows[i]["RATIO_TOTAL_VOTING"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                }
                #endregion
                #region table5
                System.Data.DataTable dt7 = Getcursor7();

                CreateTableWord(wordDoc, dt7.Rows.Count + 2, 4, 7, TableName7, true, true);
                wordcellrange.Font.Size = 9;
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[33];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[34];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[35];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[36];
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
                #region TextTable2
                CreateTableWord(wordDoc, 2, 2, 8, null, false,false);
                coloumn = 0;
                for (var i = 0; i < 2; i++)
                {
                    coloumn = coloumn + 1;
                    if (coloumn == 1)
                    {
                        SText = SinfoSharia;
                        Text = infoSharia;
                    }
                    else if (coloumn == 2)
                    {
                        SText = ScommentsStruct;
                        Text = commentsStruct;
                    }
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = SText;
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = Text;
                    wordcellrange.Font.Bold = 1;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }

                #endregion
                #region table6
                System.Data.DataTable dt4 = Getcursor4();

                CreateTableWord(wordDoc, dt4.Rows.Count + 2, 4, 9, TableName4, true, true);                
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[17];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[18];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[19];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[20];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;               
                coloumn = 2;
                for (var i = 0; i < dt4.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt4.Rows[i]["NOMER7"].ToString();
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
                #region table7
                System.Data.DataTable dt5 = Getcursor5();

                CreateTableWord(wordDoc, dt5.Rows.Count + 2, 7, 10, TableName5, true, true);
                wordcellrange.Font.Size = 9;
                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[21];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[22];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[23];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[24];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[25];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 6).Range;
                wordcellrange.Text = template[26];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordtable.Cell(2, 6).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; 
                wordcellrange = wordtable.Cell(2, 7).Range;
                wordcellrange.Text = template[27];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 9;
                wordtable.Cell(2, 7).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;                
                coloumn = 2;
                for (var i = 0; i < dt5.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt5.Rows[i]["NUM_PP2"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt5.Rows[i]["APPDATE"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt5.Rows[i]["NAME_OS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt5.Rows[i]["CONTENT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt5.Rows[i]["DATEEXEC"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordcellrange = wordtable.Cell(coloumn, 6).Range;
                    wordcellrange.Text = dt5.Rows[i]["COMMENTS_OS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 9;
                    wordtable.Cell(coloumn, 6).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 7).Range;
                    wordcellrange.Text = "";
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