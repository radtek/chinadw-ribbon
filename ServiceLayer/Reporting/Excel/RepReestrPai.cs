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
     * 34.	Реестр паев 
     */
    public class RepReestrPai : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal idPai;
        protected string NameFundKnd, NameFund, NameJurPerson, NameRegion, Address, OKPO, BIN, Managenum, NameSts, Datereg, Num, Period, Price, NIN, Condtion, Status;
        protected string NameCustadion, NumLicenseCustodian, CustDate, NameRegistrars, Licensenumber, LicenseDate, Shariatcom, DateClose, Comments, RegPai;
        #region Constructors
        public RepReestrPai()
        {
        }

        public RepReestrPai(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepReestrPai(RepForm form, LanguageIds language, decimal idPai)
            : this(form, language)
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

               
                GetData();
                if (language == LanguageIds.Russian)
                {
                    //ws.Range["B6"].Font.Bold = true;
                    ws.Range["A6"].Value = "Вид Фонда";
                    ws.Range["B6"].Value = NameFundKnd;
                    ws.Range["A7"].Value = "Наименование фонда";
                    ws.Range["B7"].Value = NameFund;
                    //ws.Range["A8"].Font.Bold = true; 
                    ws.Range["A8"].Value = NameJurPerson;

                    //ws.Range["B10"].Font.Bold = true; 
                    ws.Range["B10"].Value = NameRegion;
                    //ws.Range["B11"].Font.Bold = true; 
                    ws.Range["B11"].Value = OKPO;
                    //ws.Range["D10"].Font.Bold = true; 
                    ws.Range["D10"].Value = Address;
                    //ws.Range["D11"].Font.Bold = true; 
                    ws.Range["D11"].Value = BIN;

                    ws.Range["A12"].Value = "Лицензия на управление инвестиционным портфелем: №    " + Managenum;
                    ws.Range["A13"].Value = "Выпуск зарегистрирован Национальный Банк Республики Казахстан " + Datereg + " г. за № " + Num;
                    ws.Range["A14"].Value = "Срок обращения: " + Period;
                    ws.Range["D14"].Value = Price;
                    ws.Range["B15"].Value = NIN;

                    ws.Range["A16"].Value = "Условия начала размещения паев:   " + Condtion;
                    ws.Range["A17"].Value = "Состояние размещения паев на   " + Status;

                    ws.Range["B18"].Value = NameCustadion;
                    ws.Range["A19"].Value = "Лицензия на осуществление кастодианской деятельности: № " + NumLicenseCustodian + " от " + CustDate + " г.";
                    ws.Range["B20"].Value = NameRegistrars;
                    ws.Range["A21"].Value = "Лицензия на осуществление деятельности по ведению системы держателей ЦБ: № " + Licensenumber + " от " + LicenseDate + " г."; ;
                    ws.Range["A23"].Value = "Сведения о совете по шариату: " + Shariatcom;
                    ws.Range["B24"].Value = DateClose;
                    ws.Range["B25"].Value = Comments;
                    ws.Range["A26"].Value = "Выпуск зарегистрировал: " + RegPai;
                }
                else
                {
                    //ws.Range["B6"].Font.Bold = true;
                    ws.Range["A6"].Value = "Қор түрі";
                    ws.Range["B6"].Value = NameFundKnd;
                    ws.Range["A7"].Value = "Қордың атауы";
                    ws.Range["B7"].Value = NameFund;
                    //ws.Range["A8"].Font.Bold = true; 
                    ws.Range["A8"].Value = NameJurPerson;

                    //ws.Range["B10"].Font.Bold = true; 
                    ws.Range["B10"].Value = NameRegion;
                    //ws.Range["B11"].Font.Bold = true; 
                    ws.Range["B11"].Value = OKPO;
                    //ws.Range["D10"].Font.Bold = true; 
                    ws.Range["D10"].Value = Address;
                    //ws.Range["D11"].Font.Bold = true; 
                    ws.Range["D11"].Value = BIN;

                    ws.Range["A12"].Value = "Инвестициялық портфельді басқарудың лицензиясы : №    " + Managenum;
                    ws.Range["A13"].Value = "Шығарылым тіркелінді Қазақстан Республикасының Ұлттық Банкі " + Datereg + " ж. № " + Num;
                    ws.Range["A14"].Value = "Айналым мерзімі :   " + Period;
                    ws.Range["D14"].Value = Price;
                    ws.Range["B15"].Value = NIN;

                    ws.Range["A16"].Value = "Пайлар орналастырудың бастапқы шарттары :   " + Condtion;
                    ws.Range["A17"].Value = "Орналасу күйі    " + Status;

                    ws.Range["B18"].Value = NameCustadion;
                    ws.Range["A19"].Value = "Кастодиан қызметті іске асыруға берілген лицензия : № " + NumLicenseCustodian + " мына күннен  " + CustDate + " ж.";
                    ws.Range["B20"].Value = NameRegistrars;
                    ws.Range["A21"].Value = "БҚ ұстаушылар жүйесіндегі қызметті іске асыруға берілген лицензия : №  " + Licensenumber + " мына күннен " + LicenseDate + " ж."; ;
                    ws.Range["A23"].Value = "Шариат кеңесі : " + Shariatcom;
                    ws.Range["B24"].Value = DateClose;
                    ws.Range["B25"].Value = Comments;
                    ws.Range["A26"].Value = "Шығарылымды тіркеген : " + RegPai;
                }
                System.Data.DataTable dt1 = Getcursor1();


                int rowIndex = 1;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    
                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt1.Rows[i]["NAME_REPKND"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt1.Rows[i]["DATE_REPORT"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt1.Rows[i]["PERIOD"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["COUNT_DEPLOY"]);
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["AMOUNTPERIOD"]);
                    (rngDataRow.Cells[rowIndex, 6] as Range).Value2 = Convert.ToInt32(dt1.Rows[i]["AMOUNT"]);
                    rowIndex++;

                }

                Range rngData2 = ws.get_Range("DATA2", Type.Missing) as Range;
                Range rngDataRow2 = rngData2.Rows[rngData2.Rows.Count, Type.Missing] as Range;
                var rngBelowDataRow2 = ws.Rows[rngDataRow2.Row, Type.Missing] as Range;

                System.Data.DataTable dt2 = Getcursor2();

                int rowIndex1 = 1;

                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    rngBelowDataRow2.Copy();
                    (rngDataRow2.Rows[rowIndex1, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                        
                    (rngDataRow2.Cells[rowIndex1, 1] as Range).Value2 = dt2.Rows[i]["NAME_CATEGORY"].ToString();
                    (rngDataRow2.Cells[rowIndex1, 2] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["COUNT"]);
                    (rngDataRow2.Cells[rowIndex1, 3] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["COUNTNORES"]);
                    (rngDataRow2.Cells[rowIndex1, 4] as Range).Value2 = Convert.ToInt32(dt2.Rows[i]["COUNTPLC"]);



                    rowIndex1++;

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
