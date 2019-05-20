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
    public class RepWordCertificateOfStateRegistrationIS : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
#pragma warning disable CS0108 // 'RepWordCertificateOfStateRegistrationIS.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'RepWordCertificateOfStateRegistrationIS.wordparagraph' is never used
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0169 // The field 'RepWordCertificateOfStateRegistrationIS.wordparagraph' is never used
#pragma warning restore CS0108 // 'RepWordCertificateOfStateRegistrationIS.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        public Document wordDoc;
        #endregion
        protected decimal? idIslam;
        protected string dateStr, nameRegion, nameCategoryEcb, nameIssuer, address, numReg, dateReg, countIs, isin, nominalValue, amountIssue, commentsDefault, fio, position;

        public RepWordCertificateOfStateRegistrationIS(RepForm form, LanguageIds language, decimal? idIslam)
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
                cmd.CommandText = "G_REP_CERTIF_OF_STATE_REG_IS";
                cmd.Parameters.Add("ID_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("LANG_ID_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("DATE_STR_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_REGION_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_CATEGORY_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_ISSUER_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ADDRESS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("DATE_REG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("COUNT_IS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NOMINAL_VALUE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("AMOUNT_ISSUE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("COMMENTS_DEFAULT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FIO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("POSITION_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("ERR_CODE", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["ID_"].Value = idIslam;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["LANG_ID_"].Value = languageId;

                cmd.Parameters["DATE_STR_"].Size = 4000;
                cmd.Parameters["NAME_REGION_"].Size = 4000;
                cmd.Parameters["NAME_CATEGORY_ECB_"].Size = 4000;
                cmd.Parameters["NAME_ISSUER_"].Size = 4000;
                cmd.Parameters["ADDRESS_"].Size = 4000;
                cmd.Parameters["NUM_REG_"].Size = 4000;
                cmd.Parameters["DATE_REG_"].Size = 4000;
                cmd.Parameters["COUNT_IS_"].Size = 4000;
                cmd.Parameters["ISIN_"].Size = 4000;
                cmd.Parameters["NOMINAL_VALUE_"].Size = 4000;
                cmd.Parameters["AMOUNT_ISSUE_"].Size = 4000;
                cmd.Parameters["COMMENTS_DEFAULT_"].Size = 4000;
                cmd.Parameters["FIO_"].Size = 4000;
                cmd.Parameters["POSITION_"].Size = 4000;

                cmd.ExecuteNonQuery();

                dateStr = cmd.Parameters["DATE_STR_"].Value.ToString();
                if (dateStr == "null")
                {
                    dateStr = string.Empty;
                }
                nameRegion = cmd.Parameters["NAME_REGION_"].Value.ToString();
                if (nameRegion == "null")
                {
                    nameRegion = string.Empty;
                }

                nameCategoryEcb = cmd.Parameters["NAME_CATEGORY_ECB_"].Value.ToString();
                if (nameCategoryEcb == "null")
                {
                    nameCategoryEcb = string.Empty;
                }

                nameIssuer = cmd.Parameters["NAME_ISSUER_"].Value.ToString();
                if (nameIssuer == "null")
                {
                    nameIssuer = string.Empty;
                }

                address = cmd.Parameters["ADDRESS_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
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

                countIs = cmd.Parameters["COUNT_IS_"].Value.ToString();
                if (countIs == "null")
                {
                    countIs = string.Empty;
                }

                isin = cmd.Parameters["ISIN_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
                }

                nominalValue = cmd.Parameters["NOMINAL_VALUE_"].Value.ToString();
                if (nominalValue == "null")
                {
                    nominalValue = string.Empty;
                }

                amountIssue = cmd.Parameters["AMOUNT_ISSUE_"].Value.ToString();
                if (amountIssue == "null")
                {
                    amountIssue = string.Empty;
                }

                commentsDefault = cmd.Parameters["COMMENTS_DEFAULT_"].Value.ToString();
                if (commentsDefault == "null")
                {
                    commentsDefault = string.Empty;
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
                ReplaceText(wordApp, "${DateStr}", dateStr);
                ReplaceText(wordApp, "${NameRegion}", nameRegion);
                ReplaceText(wordApp, "${NameCategoryEcb}", nameCategoryEcb);
                ReplaceText(wordApp, "${NameIssuer}", nameIssuer);
                ReplaceText(wordApp, "${Address}", address);
                ReplaceText(wordApp, "${NumReg}", numReg);
                ReplaceText(wordApp, "${DateReg}", dateReg);
                ReplaceText(wordApp, "${CountIs}", countIs);
                ReplaceText(wordApp, "${Isin}", isin);
                ReplaceText(wordApp, "${NominalValue}", nominalValue);
                ReplaceText(wordApp, "${AmountIssue}", amountIssue);
                ReplaceText(wordApp, "${CommentsDefault}", commentsDefault);
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