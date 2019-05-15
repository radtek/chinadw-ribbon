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
    public class RepWordCertificateOfStateRegistrationShare : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idShare;
        protected string dateStr, nameRegion, nameJurPerson, address, nameRegOrganMu, regNum, regDate, bin, nameCategiryOrg, categoryCount, isin, comments, fio, position, nominalvalue, iscommerce;

        public RepWordCertificateOfStateRegistrationShare(RepForm form, LanguageIds language, decimal? idShare)
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
                cmd.CommandText = "G_REP_CERT_OF_STATE_REG_SHARE";
                cmd.Parameters.Add("ID_SHARE_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("LANG_ID_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("DATE_STR_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_REGION_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_JUR_PERSON_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ADDRESS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_REG_ORGAN_MU_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("REGNUM_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("REG_DATE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_CATEGORY_ORG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("CATEGORY_COUNT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("COMMENTS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FIO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("POSITION_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NOMINAL_VALUE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISCOMMERCE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_CODE", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["ID_SHARE_"].Value = idShare;
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
                cmd.Parameters["NAME_JUR_PERSON_"].Size = 4000;
                cmd.Parameters["ADDRESS_"].Size = 4000;
                cmd.Parameters["NAME_REG_ORGAN_MU_"].Size = 4000;
                cmd.Parameters["REGNUM_"].Size = 4000;
                cmd.Parameters["REG_DATE_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["NAME_CATEGORY_ORG_"].Size = 4000;
                cmd.Parameters["CATEGORY_COUNT_"].Size = 4000;
                cmd.Parameters["ISIN_"].Size = 4000;
                cmd.Parameters["COMMENTS_"].Size = 4000;
                cmd.Parameters["FIO_"].Size = 4000;
                cmd.Parameters["POSITION_"].Size = 4000;
                cmd.Parameters["NOMINAL_VALUE_"].Size = 4000;
                cmd.Parameters["ISCOMMERCE_"].Size = 4000;
                
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

                nameJurPerson = cmd.Parameters["NAME_JUR_PERSON_"].Value.ToString();
                if (nameJurPerson == "null")
                {
                    nameJurPerson = string.Empty;
                }

                address = cmd.Parameters["ADDRESS_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
                }

                nameRegOrganMu = cmd.Parameters["NAME_REG_ORGAN_MU_"].Value.ToString();
                if (nameRegOrganMu == "null")
                {
                    nameRegOrganMu = string.Empty;
                }

                regNum = cmd.Parameters["REGNUM_"].Value.ToString();
                if (regNum == "null")
                {
                    regNum = string.Empty;
                }

                regDate = cmd.Parameters["REG_DATE_"].Value.ToString();
                if (regDate == "null")
                {
                    regDate = string.Empty;
                }

                
                bin = cmd.Parameters["BIN_"].Value.ToString();
                if (bin == "null")
                {
                    bin = string.Empty;
                }

                nameCategiryOrg = cmd.Parameters["NAME_CATEGORY_ORG_"].Value.ToString();
                if (nameCategiryOrg == "null")
                {
                    nameCategiryOrg = string.Empty;
                }

                categoryCount = cmd.Parameters["CATEGORY_COUNT_"].Value.ToString();
                if (categoryCount == "null")
                {
                    categoryCount = string.Empty;
                }
                
                isin = cmd.Parameters["ISIN_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
                }

                comments = cmd.Parameters["COMMENTS_"].Value.ToString();
                if (comments == "null")
                {
                    comments = string.Empty;
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
                nominalvalue = cmd.Parameters["NOMINAL_VALUE_"].Value.ToString();
                if (position == "null")
                {
                    position = string.Empty;
                }
                iscommerce = cmd.Parameters["ISCOMMERCE_"].Value.ToString();
                if (iscommerce == "null")
                {
                    iscommerce = string.Empty;
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
                ReplaceText(wordApp, "${NameJurPerson}", nameJurPerson);
                ReplaceText(wordApp, "${Address}", address);
                ReplaceText(wordApp, "${NameRegOrganMu}", nameRegOrganMu);
                ReplaceText(wordApp, "${RegNum}", regNum);
                ReplaceText(wordApp, "${RegDate}", regDate);
                ReplaceText(wordApp, "${Bin}", bin);
                ReplaceText(wordApp, "${NameCategiryOrg}", nameCategiryOrg);
                ReplaceText(wordApp, "${CategoryCount}", categoryCount);
                ReplaceText(wordApp, "${Isin}", isin);
                ReplaceText(wordApp, "${Comments}", comments);
                ReplaceText(wordApp, "${Fio}", fio);
                ReplaceText(wordApp, "${Position}", position);
                ReplaceText(wordApp, "${Nominal_Value}", nominalvalue);
                ReplaceText(wordApp, "${Iscommerce}", iscommerce);
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