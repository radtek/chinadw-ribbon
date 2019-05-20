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
    public class RepWordPermission : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
#pragma warning disable CS0108 // 'RepWordPermission.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'RepWordPermission.wordparagraph' is never used
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0169 // The field 'RepWordPermission.wordparagraph' is never used
#pragma warning restore CS0108 // 'RepWordPermission.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        public Document wordDoc;
        #endregion
        protected decimal idperm;
        protected string nameissue, region, address, phone, fax, mail, regname, regdate, reg_num, okpo, bin, datepermission, bondKnd, country, price, currency, countbond, valuecapital, comments, username;

        public RepWordPermission(RepForm form, LanguageIds language, decimal idperm)
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
                cmd.CommandText = "G_Rep_Reestr_Permission";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("NameIssue_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Region_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Phone_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Fax_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Mail_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("RegName_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("RegDate_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Okpo_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Bin_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DatePermission_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BondKnd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Country_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Currency_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("CountBond_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("ValueCapital_", OracleDbType.Varchar2, ParameterDirection.Output);
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

                cmd.Parameters["NameIssue_"].Size = 4000;
                cmd.Parameters["Region_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["Phone_"].Size = 4000;
                cmd.Parameters["Fax_"].Size = 4000;
                cmd.Parameters["Mail_"].Size = 4000;
                cmd.Parameters["RegName_"].Size = 4000;
                cmd.Parameters["RegDate_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Okpo_"].Size = 4000;

                cmd.Parameters["Bin_"].Size = 4000;
                cmd.Parameters["DatePermission_"].Size = 4000;
                cmd.Parameters["BondKnd_"].Size = 4000;
                cmd.Parameters["Country_"].Size = 4000;
                cmd.Parameters["Price_"].Size = 4000;
                cmd.Parameters["Currency_"].Size = 4000;
                cmd.Parameters["CountBond_"].Size = 4000;

                cmd.Parameters["ValueCapital_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["UserName_"].Size = 4000;    

                cmd.ExecuteNonQuery();

                nameissue = cmd.Parameters["NameIssue_"].Value.ToString();
                if (nameissue == "null")
                {
                    nameissue = string.Empty;
                }
                region = cmd.Parameters["Region_"].Value.ToString();
                if (region == "null")
                {
                    region = string.Empty;
                }
                address = cmd.Parameters["Address_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
                }
                phone = cmd.Parameters["Phone_"].Value.ToString();
                if (phone == "null")
                {
                    phone = string.Empty;
                }
                fax = cmd.Parameters["Fax_"].Value.ToString();
                if (fax == "null")
                {
                    fax = string.Empty;
                }
                mail = cmd.Parameters["Mail_"].Value.ToString();
                if (mail == "null")
                {
                    mail = string.Empty;
                }
                regname = cmd.Parameters["RegName_"].Value.ToString();
                if (regname == "null")
                {
                    regname = string.Empty;
                }
                regdate = cmd.Parameters["RegDate_"].Value.ToString();
                if (regdate == "null")
                {
                    regdate = string.Empty;
                }
                reg_num = cmd.Parameters["Reg_Num_"].Value.ToString();
                if (reg_num == "null")
                {
                    reg_num = string.Empty;
                }
                okpo = cmd.Parameters["Okpo_"].Value.ToString();
                if (okpo == "null")
                {
                    okpo = string.Empty;
                }

                bin = cmd.Parameters["Bin_"].Value.ToString();
                if (bin == "null")
                {
                    bin = string.Empty;
                }
                datepermission = cmd.Parameters["Datepermission_"].Value.ToString();
                if (datepermission == "null")
                {
                    datepermission = string.Empty;
                }
                bondKnd = cmd.Parameters["BondKnd_"].Value.ToString();
                if (bondKnd == "null")
                {
                    bondKnd = string.Empty;
                }
                country = cmd.Parameters["Country_"].Value.ToString();
                if (country == "null")
                {
                    country = string.Empty;
                }
                price = cmd.Parameters["Price_"].Value.ToString();
                if (price == "null")
                {
                    price = string.Empty;
                }
                currency = cmd.Parameters["Currency_"].Value.ToString();
                if (currency == "null")
                {
                    currency = string.Empty;
                }
                countbond = cmd.Parameters["CountBond_"].Value.ToString();
                if (countbond == "null")
                {
                    countbond = string.Empty;
                }
                valuecapital = cmd.Parameters["ValueCapital_"].Value.ToString();
                if (valuecapital == "null")
                {
                    valuecapital = string.Empty;
                }
                comments = cmd.Parameters["Comments_"].Value.ToString();
                if (comments == "null")
                {
                    comments = string.Empty;
                }
                username = cmd.Parameters["Username_"].Value.ToString();
                if (username == "null")
                {
                    username = string.Empty;
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

                FindAndReplace(wordApp, "${NameIssue}", nameissue);
                FindAndReplace(wordApp, "${Region}", region);
                FindAndReplace(wordApp, "${Address}", address);
                FindAndReplace(wordApp, "${Phone}", phone);
                FindAndReplace(wordApp, "${Fax}", fax);
                FindAndReplace(wordApp, "${Mail}", mail);
                FindAndReplace(wordApp, "${RegName}", regname);
                FindAndReplace(wordApp, "${RegDate}", regdate);
                FindAndReplace(wordApp, "${Reg_Num}", reg_num);
                FindAndReplace(wordApp, "${Okpo}", okpo);
                FindAndReplace(wordApp, "${Bin}", bin);
                FindAndReplace(wordApp, "${DatePermission}", datepermission);
                FindAndReplace(wordApp, "${BondKnd}", bondKnd);
                FindAndReplace(wordApp, "${Country}", country);
                FindAndReplace(wordApp, "${Price}", price);
                FindAndReplace(wordApp, "${CountBond}", countbond);
                FindAndReplace(wordApp, "${ValueCapital}", valuecapital);
                FindAndReplace(wordApp, "${Comments}", comments);
                FindAndReplace(wordApp, "${UserName}", username);
                FindAndReplace(wordApp, "${Currency}", currency);
              
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