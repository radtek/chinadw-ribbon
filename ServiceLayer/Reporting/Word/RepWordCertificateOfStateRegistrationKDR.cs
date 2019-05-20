using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors;
using System.Drawing;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordCertificateOfStateRegistrationKDR : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
#pragma warning disable CS0169 // The field 'RepWordCertificateOfStateRegistrationKDR.wordparagraph' is never used
#pragma warning disable CS0108 // 'RepWordCertificateOfStateRegistrationKDR.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0108 // 'RepWordCertificateOfStateRegistrationKDR.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning restore CS0169 // The field 'RepWordCertificateOfStateRegistrationKDR.wordparagraph' is never used
        public Document wordDoc;
        #endregion
        protected decimal? idKDR;
        protected string authorizedName, numSerial, nameEmit, nameReg, numReg, dateReg, nameEcbKind, nameIssuersBaseAsset, country, nameRegOrganMu, numGosReg;
        protected string dateGosReg, countDepreceipt, isin, nameCountSecurities, fio, position;

        public RepWordCertificateOfStateRegistrationKDR(RepForm form, LanguageIds language, decimal? idKDR)
            : base(form, language)
        {
            this.form = form;
            this.idKDR = idKDR;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_CERTIF_OF_STATE_REG_KDR";
                cmd.Parameters.Add("ID_KDR_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("LANG_ID_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("AUTHORIZED_NAME_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_SERIAL_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_EMIT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DATE_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_ECB_KIND_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_ISSUERS_BASE_ASSET_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("COUNTRY_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_REG_ORGAN_MU_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_GOS_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DATE_GOS_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("COUNT_DEPRECEIPT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_COUNT_SECURITIES_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FIO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("POSITION_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("ERR_CODE", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["ID_KDR_"].Value = idKDR;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["LANG_ID_"].Value = languageId;

                cmd.Parameters["AUTHORIZED_NAME_"].Size = 4000;
                cmd.Parameters["NUM_SERIAL_"].Size = 4000;
                cmd.Parameters["NAME_EMIT_"].Size = 4000;
                cmd.Parameters["NAME_REG_"].Size = 4000;
                cmd.Parameters["NUM_REG_"].Size = 4000;
                cmd.Parameters["DATE_REG_"].Size = 4000;
                cmd.Parameters["NAME_ECB_KIND_"].Size = 4000;
                cmd.Parameters["NAME_ISSUERS_BASE_ASSET_"].Size = 4000;
                cmd.Parameters["COUNTRY_"].Size = 4000;
                cmd.Parameters["NAME_REG_ORGAN_MU_"].Size = 4000;
                cmd.Parameters["NUM_GOS_REG_"].Size = 4000;
                cmd.Parameters["DATE_GOS_REG_"].Size = 4000;
                cmd.Parameters["COUNT_DEPRECEIPT_"].Size = 4000;
                cmd.Parameters["ISIN_"].Size = 4000;
                cmd.Parameters["NAME_COUNT_SECURITIES_"].Size = 4000;
                cmd.Parameters["FIO_"].Size = 4000;
                cmd.Parameters["POSITION_"].Size = 4000;

                cmd.ExecuteNonQuery();

                authorizedName = cmd.Parameters["AUTHORIZED_NAME_"].Value.ToString();
                if (authorizedName == "null")
                {
                    authorizedName = string.Empty;
                }
                numSerial = cmd.Parameters["NUM_SERIAL_"].Value.ToString();
                if (numSerial == "null")
                {
                    numSerial = string.Empty;
                }
                nameEmit = cmd.Parameters["NAME_EMIT_"].Value.ToString();
                if (nameEmit == "null")
                {
                    nameEmit = string.Empty;
                }
                nameReg = cmd.Parameters["NAME_REG_"].Value.ToString();
                if (nameReg == "null")
                {
                    nameReg = string.Empty;
                }
                numReg = cmd.Parameters["NUM_REG_"].Value.ToString();
                if (numReg == "null")
                {
                    numReg = string.Empty;
                }
                dateReg = cmd.Parameters["DATE_REG_"].Value.ToString();
                if (dateReg == "null")
                {
                    dateReg = string.Empty;
                }
                nameEcbKind = cmd.Parameters["NAME_ECB_KIND_"].Value.ToString();
                if (nameEcbKind == "null")
                {
                    nameEcbKind = string.Empty;
                }
                nameIssuersBaseAsset = cmd.Parameters["NAME_ISSUERS_BASE_ASSET_"].Value.ToString();
                if (nameIssuersBaseAsset == "null")
                {
                    nameIssuersBaseAsset = string.Empty;
                }
                country = cmd.Parameters["COUNTRY_"].Value.ToString();
                if (country == "null")
                {
                    country = string.Empty;
                }
                nameRegOrganMu = cmd.Parameters["NAME_REG_ORGAN_MU_"].Value.ToString();
                if (nameRegOrganMu == "null")
                {
                    nameRegOrganMu = string.Empty;
                }
                numGosReg = cmd.Parameters["NUM_GOS_REG_"].Value.ToString();
                if (numGosReg == "null")
                {
                    numGosReg = string.Empty;
                }
                dateGosReg = cmd.Parameters["DATE_GOS_REG_"].Value.ToString();
                if (dateGosReg == "null")
                {
                    dateGosReg = string.Empty;
                }
                countDepreceipt = cmd.Parameters["COUNT_DEPRECEIPT_"].Value.ToString();
                if (countDepreceipt == "null")
                {
                    countDepreceipt = string.Empty;
                }
                isin = cmd.Parameters["ISIN_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
                }
                nameCountSecurities = cmd.Parameters["NAME_COUNT_SECURITIES_"].Value.ToString();
                if (nameCountSecurities == "null")
                {
                    nameCountSecurities = string.Empty;
                }

                fio = cmd.Parameters["FIO_"].Value.ToString();
                if (fio == "null")
                {
                    fio = string.Empty;
                }

                position = cmd.Parameters["POSITION_"].Value.ToString();
                if (position == "null")
                {
                    position = string.Empty;
                }

                if (!((OracleDecimal)cmd.Parameters["ERR_CODE"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["ERR_CODE"].Value).ToInt32();
                    var errMsg = cmd.Parameters["ERR_MSG"].Value.ToString();
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
                #region ChangeText
                ReplaceText(wordApp, "${AuthorizedName}", authorizedName);
                ReplaceText(wordApp, "${NumSerial}", numSerial);
                ReplaceText(wordApp, "${NameEmit}", nameEmit);
                ReplaceText(wordApp, "${NameReg}", nameReg);
                ReplaceText(wordApp, "${NumReg}", numReg);
                ReplaceText(wordApp, "${DateReg}", dateReg);
                ReplaceText(wordApp, "${NameEcbKind}", nameEcbKind);
                ReplaceText(wordApp, "${NameIssuersBaseAsset}", nameIssuersBaseAsset);
                ReplaceText(wordApp, "${Country}", country);
                ReplaceText(wordApp, "${NameRegOrganMu}", nameRegOrganMu);
                ReplaceText(wordApp, "${NumGosReg}", numGosReg);
                ReplaceText(wordApp, "${DateGosReg}", dateGosReg);
                ReplaceText(wordApp, "${CountDepreceipt}", countDepreceipt);
                ReplaceText(wordApp, "${Isin}", isin);
                ReplaceText(wordApp, "${NameCountSecurities}", nameCountSecurities);
                ReplaceText(wordApp, "${Fio}", fio);
                ReplaceText(wordApp, "${Position}", position);
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