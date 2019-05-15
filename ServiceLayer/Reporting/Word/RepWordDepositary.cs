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
    public class RepWordDepositary : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal idperm;
        protected string Num, DateReg, HolderName, AddressDr, PhoneDr, FaxDr, MailDr, NameIssue, Region, Address, Phone, Fax, Mail, Govhaveshare, Nonres, RegName, RegDate, RegNum, Okpo,
                         Bin, DatePermission, EcbKndBa, Nin, CountBa, PricePla, Ratio, Country, EcbKnd, Isin, Price, CountDr, ValueCapital, Currency, Period, PeriodKnd, Custodian, Underwriter,
                         Comments, UserName;
        public RepWordDepositary(RepForm form, LanguageIds language, decimal idperm)
            : base(form, language)
        {
            this.form = form;
            this.idperm = idperm;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_Rep_Reestr_Depositary_Rec";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DateReg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("HolderName_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("AddressDr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("PhoneDr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FaxDr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("MailDr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NameIssue_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);                
                cmd.Parameters.Add("Phone_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Fax_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Mail_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Govhaveshare_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Nonres_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("RegName_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("RegDate_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Okpo_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Bin_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DatePermission_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("EcbKndBa_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Nin_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("CountBa_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("PricePla_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Ratio_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Country_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("EcbKnd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Isin_", OracleDbType.Varchar2, ParameterDirection.Output);                
                cmd.Parameters.Add("Price_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("CountDr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ValueCapital_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Currency_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("PeriodKnd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Custodian_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Underwriter_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("UserName_", OracleDbType.Varchar2, ParameterDirection.Output);                
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idperm;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["DateReg_"].Size = 4000;
                cmd.Parameters["HolderName_"].Size = 4000;
                cmd.Parameters["AddressDr_"].Size = 4000;
                cmd.Parameters["PhoneDr_"].Size = 4000;
                cmd.Parameters["FaxDr_"].Size = 4000;
                cmd.Parameters["MailDr_"].Size = 4000;
                cmd.Parameters["NameIssue_"].Size = 4000;
                cmd.Parameters["Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["Phone_"].Size = 4000;
                cmd.Parameters["Fax_"].Size = 4000;
                cmd.Parameters["Mail_"].Size = 4000;
                cmd.Parameters["Govhaveshare_"].Size = 4000;
                cmd.Parameters["Nonres_"].Size = 4000;
                cmd.Parameters["RegName_"].Size = 4000;
                cmd.Parameters["RegDate_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Okpo_"].Size = 4000;
                cmd.Parameters["Bin_"].Size = 4000;
                cmd.Parameters["DatePermission_"].Size = 4000;
                cmd.Parameters["EcbKndBa_"].Size = 4000;
                cmd.Parameters["Nin_"].Size = 4000;
                cmd.Parameters["CountBa_"].Size = 4000;
                cmd.Parameters["PricePla_"].Size = 4000;
                cmd.Parameters["Ratio_"].Size = 4000;
                cmd.Parameters["Country_"].Size = 4000;
                cmd.Parameters["EcbKnd_"].Size = 4000;
                cmd.Parameters["Isin_"].Size = 4000;
                cmd.Parameters["Price_"].Size = 4000;
                cmd.Parameters["CountDr_"].Size = 4000;
                cmd.Parameters["ValueCapital_"].Size = 4000;
                cmd.Parameters["Currency_"].Size = 4000;
                cmd.Parameters["Period_"].Size = 4000;
                cmd.Parameters["PeriodKnd_"].Size = 4000;
                cmd.Parameters["Custodian_"].Size = 4000;
                cmd.Parameters["Underwriter_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["UserName_"].Size = 4000;  

                cmd.ExecuteNonQuery();
                #region
                Num = cmd.Parameters["Num_"].Value.ToString();
                if (Num == "null")
                {
                    Num = string.Empty;
                }
                AddressDr = cmd.Parameters["AddressDr_"].Value.ToString();
                if (AddressDr == "null")
                {
                    AddressDr = string.Empty;
                }
                HolderName = cmd.Parameters["HolderName_"].Value.ToString();
                if (HolderName == "null")
                {
                    HolderName = string.Empty;
                }
                PhoneDr = cmd.Parameters["PhoneDr_"].Value.ToString();
                if (PhoneDr == "null")
                {
                    PhoneDr = string.Empty;
                }
                FaxDr = cmd.Parameters["FaxDr_"].Value.ToString();
                if (FaxDr == "null")
                {
                    FaxDr = string.Empty;
                }
                MailDr = cmd.Parameters["MailDr_"].Value.ToString();
                if (MailDr == "null")
                {
                    MailDr = string.Empty;
                }
                NameIssue = cmd.Parameters["NameIssue_"].Value.ToString();
                if (NameIssue == "null")
                {
                    NameIssue = string.Empty;
                }
                Region = cmd.Parameters["Region_"].Value.ToString();
                if (Region == "null")
                {
                    Region = string.Empty;
                }
                Address = cmd.Parameters["Address_"].Value.ToString();
                if (Address == "null")
                {
                    Address = string.Empty;
                }
                Phone = cmd.Parameters["Phone_"].Value.ToString();
                if (Phone == "null")
                {
                    Phone = string.Empty;
                }
                Fax = cmd.Parameters["Fax_"].Value.ToString();
                if (Fax == "null")
                {
                    Fax = string.Empty;
                }
                Mail = cmd.Parameters["Mail_"].Value.ToString();
                if (Mail == "null")
                {
                    Mail = string.Empty;
                }
                Govhaveshare = cmd.Parameters["Govhaveshare_"].Value.ToString();
                if (Govhaveshare == "null")
                {
                    Govhaveshare = string.Empty;
                }
                Nonres = cmd.Parameters["Nonres_"].Value.ToString();
                if (Nonres == "null")
                {
                    Nonres = string.Empty;
                }
                RegName = cmd.Parameters["RegName_"].Value.ToString();
                if (RegName == "null")
                {
                    RegName = string.Empty;
                }
                RegDate = cmd.Parameters["RegDate_"].Value.ToString();
                if (RegDate == "null")
                {
                    RegDate = string.Empty;
                }
                RegNum = cmd.Parameters["Reg_Num_"].Value.ToString();
                if (RegNum == "null")
                {
                    RegNum = string.Empty;
                }
                Okpo = cmd.Parameters["Okpo_"].Value.ToString();
                if (Okpo == "null")
                {
                    Okpo = string.Empty;
                }
                Bin = cmd.Parameters["Bin_"].Value.ToString();
                if (Bin == "null")
                {
                    Bin = string.Empty;
                }
                DatePermission = cmd.Parameters["DatePermission_"].Value.ToString();
                if (DatePermission == "null")
                {
                    DatePermission = string.Empty;
                }
                EcbKndBa = cmd.Parameters["EcbKndBa_"].Value.ToString();
                if (EcbKndBa == "null")
                {
                    EcbKndBa = string.Empty;
                }
                Nin = cmd.Parameters["Nin_"].Value.ToString();
                if (Nin == "null")
                {
                    Nin = string.Empty;
                }
                CountBa = cmd.Parameters["CountBa_"].Value.ToString();
                if (CountBa == "null")
                {
                    CountBa = string.Empty;
                }
                PricePla = cmd.Parameters["PricePla_"].Value.ToString();
                if (PricePla == "null")
                {
                    PricePla = string.Empty;
                }
                Ratio = cmd.Parameters["Ratio_"].Value.ToString();
                if (Ratio == "null")
                {
                    Ratio = string.Empty;
                }
                Country = cmd.Parameters["Country_"].Value.ToString();
                if (Country == "null")
                {
                    Country = string.Empty;
                }
                EcbKnd = cmd.Parameters["EcbKnd_"].Value.ToString();
                if (EcbKnd == "null")
                {
                    EcbKnd = string.Empty;
                }
                Isin = cmd.Parameters["Isin_"].Value.ToString();
                if (Isin == "null")
                {
                    Isin = string.Empty;
                }
                Price = cmd.Parameters["Price_"].Value.ToString();
                if (Price == "null")
                {
                    Price = string.Empty;
                }
                CountDr = cmd.Parameters["CountDr_"].Value.ToString();
                if (CountDr == "null")
                {
                    CountDr = string.Empty;
                }
                ValueCapital = cmd.Parameters["ValueCapital_"].Value.ToString();
                if (ValueCapital == "null")
                {
                    ValueCapital = string.Empty;
                }
                Currency = cmd.Parameters["Currency_"].Value.ToString();
                if (Currency == "null")
                {
                    Currency = string.Empty;
                }
                Period = cmd.Parameters["Period_"].Value.ToString();
                if (Period == "null")
                {
                    Period = string.Empty;
                }
                PeriodKnd = cmd.Parameters["PeriodKnd_"].Value.ToString();
                if (PeriodKnd == "null")
                {
                    PeriodKnd = string.Empty;
                }
                Custodian = cmd.Parameters["Custodian_"].Value.ToString();
                if (Custodian == "null")
                {
                    Custodian = string.Empty;
                }
                Underwriter = cmd.Parameters["Underwriter_"].Value.ToString();
                if (Underwriter == "null")
                {
                    Underwriter = string.Empty;
                }
                Comments = cmd.Parameters["Comments_"].Value.ToString();
                if (Comments == "null")
                {
                    Comments = string.Empty;
                }
                UserName = cmd.Parameters["UserName_"].Value.ToString();
                if (UserName == "null")
                {
                    UserName = string.Empty;
                }
                #endregion
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

        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
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

                FindAndReplace(wordApp, "${Num}", Num);
                FindAndReplace(wordApp, "${DateReg}",DateReg );
                FindAndReplace(wordApp, "${HolderName}",HolderName );
                FindAndReplace(wordApp, "${AddressDr}", AddressDr);
                FindAndReplace(wordApp, "${PhoneDr}", PhoneDr);
                FindAndReplace(wordApp, "${FaxDr}", FaxDr);
                FindAndReplace(wordApp, "${MailDr}", MailDr);
                FindAndReplace(wordApp, "${NameIssue}" ,NameIssue );
                FindAndReplace(wordApp, "${Region}", Region);
                FindAndReplace(wordApp, "${Address}", Address);
                FindAndReplace(wordApp, "${Phone}", Phone);
                FindAndReplace(wordApp, "${Fax}", Fax);
                FindAndReplace(wordApp, "${Mail}",Mail);
                FindAndReplace(wordApp, "${Govhaveshare}", Govhaveshare);
                FindAndReplace(wordApp, "${Nonres}" ,Nonres );
                FindAndReplace(wordApp, "${RegName}",RegName);
                FindAndReplace(wordApp, "${RegDate}", RegDate);
                FindAndReplace(wordApp, "${Reg_Num}",RegNum );
                FindAndReplace(wordApp, "${Okpo}", Okpo);
                FindAndReplace(wordApp, "${Bin}",Bin );
                FindAndReplace(wordApp, "${DatePermission}",DatePermission );
                FindAndReplace(wordApp, "${EcbKndBa}", EcbKndBa);
                FindAndReplace(wordApp, "${Nin}", Nin);
                FindAndReplace(wordApp, "${CountBa}",CountBa );
                FindAndReplace(wordApp, "${PricePla}",PricePla );
                FindAndReplace(wordApp, "${Ratio}",Ratio );
                FindAndReplace(wordApp, "${Country}", Country);
                FindAndReplace(wordApp, "${EcbKnd}",EcbKnd );
                FindAndReplace(wordApp, "${Isin}", Isin);
                FindAndReplace(wordApp, "${Price}",Price );
                FindAndReplace(wordApp, "${CountDr}",CountDr) ;
                FindAndReplace(wordApp, "${ValueCapital}",ValueCapital );
                FindAndReplace(wordApp, "${Currency}",Currency );
                FindAndReplace(wordApp, "${Period}",Period );
                FindAndReplace(wordApp, "${PeriodKnd}",PeriodKnd );
                FindAndReplace(wordApp, "${Custodian}",Custodian );
                FindAndReplace(wordApp, "${Underwriter}",Custodian) ;
                FindAndReplace(wordApp, "${Comments}",Comments );
                FindAndReplace(wordApp, "${UserName}",UserName );




              
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