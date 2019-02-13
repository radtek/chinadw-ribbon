using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors;
using System.Drawing;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordRegistrationInsideOfBondProgramms : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal? idBond;
        protected string name, address, bin, nameBondKnd, regNum, regOrgName, bondCount, isin, bondPrice, bondAmount, changeCause, dateStr, fio, position, num, numSeq;

        public RepWordRegistrationInsideOfBondProgramms(RepForm form, LanguageIds language, decimal? idBond)
            : base(form, language)
        {
            this.form = form;
            this.idBond = idBond;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REG_INSIDE_OF_BOND_PRG";
                cmd.Parameters.Add("ID_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("LANG_ID_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("DATE_STR_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ADDRESS_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("REGNUM_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NAME_BOND_KND_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("REG_ORG_NAME_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BOND_COUNT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("ISIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NUM_SEQ_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BOND_PRICE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("BOND_AMOUNT_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("CHANGE_CAUSE_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("FIO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("POSITION_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("ERR_CODE", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["ID_"].Value = idBond;
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
                cmd.Parameters["NAME_"].Size = 4000;
                cmd.Parameters["ADDRESS_"].Size = 4000;
                cmd.Parameters["REGNUM_"].Size = 4000;
                cmd.Parameters["BIN_"].Size = 4000;
                cmd.Parameters["NAME_BOND_KND_"].Size = 4000;
                cmd.Parameters["REG_ORG_NAME_"].Size = 4000;
                cmd.Parameters["BOND_COUNT_"].Size = 4000;
                cmd.Parameters["ISIN_"].Size = 4000;
                cmd.Parameters["NUM_"].Size = 4000;
                cmd.Parameters["NUM_SEQ_"].Size = 4000;
                cmd.Parameters["BOND_PRICE_"].Size = 4000;
                cmd.Parameters["BOND_AMOUNT_"].Size = 4000;
                cmd.Parameters["CHANGE_CAUSE_"].Size = 4000;
                cmd.Parameters["FIO_"].Size = 4000;
                cmd.Parameters["POSITION_"].Size = 4000;

                cmd.ExecuteNonQuery();

                dateStr = cmd.Parameters["DATE_STR_"].Value.ToString();
                if (dateStr == "null")
                {
                    dateStr = string.Empty;
                }
                name = cmd.Parameters["NAME_"].Value.ToString();
                if (name == "null")
                {
                    name = string.Empty;
                }

                address = cmd.Parameters["ADDRESS_"].Value.ToString();
                if (address == "null")
                {
                    address = string.Empty;
                }
                regNum = cmd.Parameters["REGNUM_"].Value.ToString();
                if (regNum == "null")
                {
                    regNum = string.Empty;
                }
                bin = cmd.Parameters["BIN_"].Value.ToString();
                if (bin == "null")
                {
                    bin = string.Empty;
                }
                nameBondKnd = cmd.Parameters["NAME_BOND_KND_"].Value.ToString();
                if (nameBondKnd == "null")
                {
                    nameBondKnd = string.Empty;
                }
                regOrgName = cmd.Parameters["REG_ORG_NAME_"].Value.ToString();
                if (regOrgName == "null")
                {
                    regOrgName = string.Empty;
                }
                bondCount = cmd.Parameters["BOND_COUNT_"].Value.ToString();
                if (bondCount == "null")
                {
                    bondCount = string.Empty;
                }
                isin = cmd.Parameters["ISIN_"].Value.ToString();
                if (isin == "null")
                {
                    isin = string.Empty;
                }
                num = cmd.Parameters["NUM_"].Value.ToString();
                if (num == "null")
                {
                    num = string.Empty;
                }
                numSeq = cmd.Parameters["NUM_SEQ_"].Value.ToString();
                if (numSeq == "null")
                {
                    numSeq = string.Empty;
                }
                bondPrice = cmd.Parameters["BOND_PRICE_"].Value.ToString();
                if (bondPrice == "null")
                {
                    bondPrice = string.Empty;
                }
                bondAmount = cmd.Parameters["BOND_AMOUNT_"].Value.ToString();
                if (bondAmount == "null")
                {
                    bondAmount = string.Empty;
                }
                changeCause = cmd.Parameters["CHANGE_CAUSE_"].Value.ToString();
                if (changeCause == "null")
                {
                    changeCause = string.Empty;
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
                ReplaceText(wordApp, "${Name}", name);
                ReplaceText(wordApp, "${Address}", address);
                ReplaceText(wordApp, "${BIN}", bin);
                ReplaceText(wordApp, "${NameBondKnd}", nameBondKnd);
                ReplaceText(wordApp, "${RegNum}", regNum);
                ReplaceText(wordApp, "${RegOrgName}", regOrgName);
                ReplaceText(wordApp, "${BondCount}", bondCount);
                ReplaceText(wordApp, "${Isin}", isin);
                ReplaceText(wordApp, "${Num}", num);
                ReplaceText(wordApp, "${NumSeq}", numSeq);
                ReplaceText(wordApp, "${BondPrice}", bondPrice);
                ReplaceText(wordApp, "${BondAmount}", bondAmount);
                ReplaceText(wordApp, "${ChangeCause}", changeCause);
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