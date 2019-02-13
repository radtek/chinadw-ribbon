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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordCertificateOfStateRegistrationPai : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idP;
        protected string dateStr, nameFund, nameJurPerson, isin, fio, position;

        public RepWordCertificateOfStateRegistrationPai(RepForm form, LanguageIds language, decimal? idP)
            : base(form, language)
        {
            this.form = form;
            this.idP = idP;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_CERTIF_OF_STATE_REG_PAI";
                cmd.Parameters.Add("ID_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("LANG_ID_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("DATE_STR_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_FUND_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_JUR_PERSON_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FIO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("POSITION_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("ERR_CODE", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["ID_"].Value = idP;
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
                cmd.Parameters["NAME_FUND_"].Size = 4000;
                cmd.Parameters["NAME_JUR_PERSON_"].Size = 4000;
                cmd.Parameters["ISIN_"].Size = 4000;
                cmd.Parameters["FIO_"].Size = 4000;
                cmd.Parameters["POSITION_"].Size = 4000;

                cmd.ExecuteNonQuery();

                dateStr = cmd.Parameters["DATE_STR_"].Value.ToString();
                if (dateStr == "null")
                {
                    dateStr = string.Empty;
                }
                nameFund = cmd.Parameters["NAME_FUND_"].Value.ToString();
                if (nameFund == "null")
                {
                    nameFund = string.Empty;
                }

                nameJurPerson = cmd.Parameters["NAME_JUR_PERSON_"].Value.ToString();
                if (nameJurPerson == "null")
                {
                    nameJurPerson = string.Empty;
                }
                isin = cmd.Parameters["ISIN_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
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
                ReplaceText(wordApp, "${NameFund}", nameFund);
                ReplaceText(wordApp, "${NameJurPerson}", nameJurPerson);
                ReplaceText(wordApp, "${Isin}", isin);
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