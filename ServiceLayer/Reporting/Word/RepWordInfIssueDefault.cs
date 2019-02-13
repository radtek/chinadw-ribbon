using System;
using System.Reflection;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using Microsoft.Office.Interop.Word;
using Oracle.DataAccess.Types;
using System.Data;
using BSB.Common.DataGateway.Oracle;
using Oracle.DataAccess.Client;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors;
using System.Drawing;

/*
 Author: Tolebi Baimenov
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepWordInfIssueDefault : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected decimal idBond;
        protected string num, NIN, dateReg, datechange, nameEmit, spec, stsName, namests, countECB, amount, numPP, period, comments, reason, events, measure;
        protected string shareholders, bondholders, summarwd, summarpm, debt, dateexec, nameStsknd, infSuspension, infRenewal, commentsBond;
        protected string Snum, SNIN, SdateReg, Sdatechange, SnameEmit, Sspec, SstsName, Snamests, ScountECB, Samount, SnumPP, Speriod, Scomments, Sreason, Sevents, Smeasure;
        protected string Sshareholders, Sbondholders, Ssummarwd, Ssummarpm, Sdebt, Sdateexec, SnameStsknd, SinfSuspension, SinfRenewal, ScommentsBond, Stext, Stenge, Sbondknd, bondknd;
      
        public RepWordInfIssueDefault(RepForm form, LanguageIds language, decimal idBond)
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
                cmd.CommandText = "G_REP_INF_ISSUE_DEFAULT";
                cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);

                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Datechange_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Emit_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Spec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Sts_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Namests_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_ECB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Amount_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Num_PP_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Period_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reason_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Events_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Measure_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Shareholders_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Bondholders_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Summarwd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Summarpm_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Debt_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Dateexec_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Stsknd_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Inf_Suspension_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Inf_Renewal_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_Bond_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Bond_Knd_", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_"].Value = idBond;
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
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Datechange_"].Size = 4000;
                cmd.Parameters["Name_Emit_"].Size = 4000;
                cmd.Parameters["Spec_"].Size = 4000;
                cmd.Parameters["Sts_Name_"].Size = 4000;
                cmd.Parameters["Namests_"].Size = 4000;
                cmd.Parameters["Count_ECB_"].Size = 4000;
                cmd.Parameters["Amount_"].Size = 4000;

                cmd.Parameters["Num_PP_"].Size = 4000;
                cmd.Parameters["Period_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["Reason_"].Size = 4000;

                cmd.Parameters["Events_"].Size = 4000;
                cmd.Parameters["Measure_"].Size = 4000;
                cmd.Parameters["Shareholders_"].Size = 4000;
                cmd.Parameters["Bondholders_"].Size = 4000;
                cmd.Parameters["Summarwd_"].Size = 4000;
                cmd.Parameters["Summarpm_"].Size = 4000;
                cmd.Parameters["Debt_"].Size = 4000;
                cmd.Parameters["Dateexec_"].Size = 4000;
                cmd.Parameters["Name_Stsknd_"].Size = 4000;
                cmd.Parameters["Inf_Suspension_"].Size = 4000;
                cmd.Parameters["Inf_Renewal_"].Size = 4000;
                cmd.Parameters["Comments_Bond_"].Size = 4000;
                cmd.Parameters["Bond_Knd_"].Size = 4000;

                cmd.ExecuteNonQuery();

                num = cmd.Parameters["Num_"].Value.ToString();
                if (num == "null")
                {
                    num = string.Empty;
                }
                NIN = cmd.Parameters["NIN_"].Value.ToString();
                if (NIN == "null")
                {
                    NIN = string.Empty;
                }
                dateReg = cmd.Parameters["Date_Reg_"].Value.ToString();
                if (dateReg == "null")
                {
                    dateReg = string.Empty;
                }
                datechange = cmd.Parameters["Datechange_"].Value.ToString();
                if (datechange == "null")
                {
                    datechange = string.Empty;
                }
                nameEmit = cmd.Parameters["Name_Emit_"].Value.ToString();
                if (nameEmit == "null")
                {
                    nameEmit = string.Empty;
                }
                spec = cmd.Parameters["Spec_"].Value.ToString();
                if (spec == "null")
                {
                    spec = string.Empty;
                }
                stsName = cmd.Parameters["Sts_Name_"].Value.ToString();
                if (stsName == "null")
                {
                    stsName = string.Empty;
                }
                namests = cmd.Parameters["Namests_"].Value.ToString();
                if (namests == "null")
                {
                    namests = string.Empty;
                }
                countECB = cmd.Parameters["Count_ECB_"].Value.ToString();
                if (countECB == "null")
                {
                    countECB = string.Empty;
                }
                amount = cmd.Parameters["Amount_"].Value.ToString();
                if (amount == "null")
                {
                    amount = string.Empty;
                }

                numPP = cmd.Parameters["Num_PP_"].Value.ToString();
                if (numPP == "null")
                {
                    numPP = string.Empty;
                }
                period = cmd.Parameters["Period_"].Value.ToString();
                if (period == "null")
                {
                    period = string.Empty;
                }
                comments = cmd.Parameters["Comments_"].Value.ToString();
                if (comments == "null")
                {
                    comments = string.Empty;
                }
                reason = cmd.Parameters["Reason_"].Value.ToString();
                if (reason == "null")
                {
                    reason = string.Empty;
                }
                events = cmd.Parameters["Events_"].Value.ToString();
                if (events == "null")
                {
                    events = string.Empty;
                }
                measure = cmd.Parameters["Measure_"].Value.ToString();
                if (measure == "null")
                {
                    measure = string.Empty;
                }
                shareholders = cmd.Parameters["Shareholders_"].Value.ToString();
                if (shareholders == "null")
                {
                    shareholders = string.Empty;
                }
                bondholders = cmd.Parameters["Bondholders_"].Value.ToString();
                if (bondholders == "null")
                {
                    bondholders = string.Empty;
                }
                summarwd = cmd.Parameters["Summarwd_"].Value.ToString();
                if (summarwd == "null")
                {
                    summarwd = string.Empty;
                }
                summarpm = cmd.Parameters["Summarpm_"].Value.ToString();
                if (summarpm == "null")
                {
                    summarpm = string.Empty;
                }
                debt = cmd.Parameters["Debt_"].Value.ToString();
                if (debt == "null")
                {
                    debt = string.Empty;
                }
                dateexec = cmd.Parameters["Dateexec_"].Value.ToString(); ;
                if (dateexec == "null")
                {
                    dateexec = string.Empty;
                }
                nameStsknd = cmd.Parameters["Name_Stsknd_"].Value.ToString();
                if (nameStsknd == "null")
                {
                    nameStsknd = string.Empty;
                }
                infSuspension = cmd.Parameters["Inf_Suspension_"].Value.ToString();
                if (infSuspension == "null")
                {
                    infSuspension = string.Empty;
                }
                infRenewal = cmd.Parameters["Inf_Renewal_"].Value.ToString();
                if (infRenewal == "null")
                {
                    infRenewal = string.Empty;
                }
                commentsBond = cmd.Parameters["Comments_Bond_"].Value.ToString();
                if (commentsBond == "null")
                {
                    commentsBond = string.Empty;
                }

                bondknd = cmd.Parameters["Bond_Knd_"].Value.ToString();
                if (bondknd == "null")
                {
                    bondknd = string.Empty;
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
             
            
                if (language == LanguageIds.Russian)
                {
                    Stext = "СВЕДЕНИЯ О ДЕФОЛТЕ ВЫПУСКА";
                    Snum = "Номер выпуска ";// +num;
                    SNIN = " НИН ";//+ NIN;
                    SdateReg = "Дата регистрации ";//+ dateReg;
                    Sdatechange = "Дата изменения выпуска ";//+ datechange;
                    SnameEmit = "Эмитент ";//+ nameEmit;
                    Sspec = "Специализация ";//+ spec;
                    SstsName = "Статус выпуска ";//+ stsName;
                    Snamests = "Состояние размещения выпуска ";//+ namests;
                    ScountECB = "Количество ЭЦБ ";//+ countECB;

                    Samount = "Объем выпуска ";//+ amount + "    тенге";
                    SnumPP = "Порядковый номер дефолта";//+ numPP;
                    Speriod = "Период";//+ period;
                    Scomments = "Информация о дефолте";// + comments;
                    Sreason = "Причина дефолта";//+ reason;
                    Sevents = "Мероприятия эмитента по выходу из дефолта";//+ events;
                    Smeasure = "Принятые НБРК меры";//+ measure;
                    Sshareholders = "Крупные акционеры эмитента";// + shareholders;
                    Sbondholders = "Информация о держателях ЭЦБ";// + bondholders;
                    Ssummarwd = "Начисленная сумма вознаграждения";//+ summarwd;
                    Ssummarpm = "Выплаченная сумма вознаграждения";//+ summarpm;
                    Sdebt = "Остаток задолженности";//+ debt;
                    Sdateexec = "Дата погашения";//+ dateexec;
                    SnameStsknd = "Состояние погашения задолженности";//+ nameStsknd;
                    SinfSuspension = "Информация о приостановлении размещения";//+ infSuspension;
                    SinfRenewal = "Информация о возобновлении размещения";//+ infRenewal;
                    ScommentsBond = "Примечание";//+ commentsBond;
                    Stenge = "тенге";
                    Sbondknd = "Вид облигаций ";
                }
                else 
                {
                    Stext = "ДЕФОЛТ ТУРАЛЫ ДЕРЕКТЕР";
                    Snum = "Шығарылым нөмірі ";//+ num;
                    SNIN = " ҰСН ";//+ NIN;
                    SdateReg = "Тіркеу күні ";//+ dateReg;
                    Sdatechange = "Өзгерткен күні ";// + datechange;
                    SnameEmit = "Эмитент ";//+ nameEmit;
                    Sspec = "Мамандануы ";// + spec;
                    SstsName = "Шығарылым мәртебесі ";// + stsName;
                    Snamests = "Орналасу күйі ";//+ namests;
                    ScountECB = "ЭБҚ саны ";//+ countECB;

                    Samount = "Шығарылым көлемі ";//+ amount + "    теңге";
                    SnumPP = "Дефолт реттік нөмірі";// + numPP;
                    Speriod = "Кезеңі";//+ period;
                    Scomments = "Дефолт деректері";//+ comments;
                    Sreason = "Дефолт себебі";// + reason;
                    Sevents = "Эмитентпен дефолттан шығуға қабылданған шаралары";//+ events;
                    Smeasure = "ҚРҰБ қабылданған шаралары";//+ measure;
                    Sshareholders = "Эмитенттің ірі акционерлері";// + shareholders;
                    Sbondholders = "ЭБҚ ұстаушылары";// + bondholders;
                    Ssummarwd = "Есептелген сыйақы соммасы";//+ summarwd;
                    Ssummarpm = "Өтелген сыйақы соммасы";// + summarpm;
                    Sdebt = "Берешектің жетіспеу соммасы";//+ debt;
                    Sdateexec = "Өтеу күні";//+ dateexec;
                    SnameStsknd = "Берешекті өтеу күйі";//+ nameStsknd;
                    SinfSuspension = "Орналастыруды тоқтату туралу ақпарат";//+ infSuspension;
                    SinfRenewal = "Қайта орналастыруды туралу ақпарат";// + infRenewal;
                    ScommentsBond = "Қосымша";// + commentsBond;
                    Stenge = "тенге";
                    Sbondknd = "Вид облигаций ";
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

                FindAndReplace(wordApp, "${TEXT}", Stext);
                FindAndReplace(wordApp, "${num}", num);
                FindAndReplace(wordApp, "${NIN}", NIN);
                FindAndReplace(wordApp, "${dateReg}", dateReg);
                FindAndReplace(wordApp, "${datechange}", datechange);
                FindAndReplace(wordApp, "${nameEmit}", nameEmit);
                FindAndReplace(wordApp, "${spec}", spec);
                FindAndReplace(wordApp, "${stsName}", stsName);
                FindAndReplace(wordApp, "${namests}",namests);
                FindAndReplace(wordApp, "${countECB}", countECB);
                FindAndReplace(wordApp, "${amount}", amount);
                FindAndReplace(wordApp, "${numPP}", numPP);
                FindAndReplace(wordApp, "${period}", period);
                FindAndReplace(wordApp, "${comments}", comments);
                FindAndReplace(wordApp, "${reason}", reason);
                FindAndReplace(wordApp, "${events}", events);
                FindAndReplace(wordApp, "${measure}", measure);
                FindAndReplace(wordApp, "${shareholders}", shareholders);
                FindAndReplace(wordApp, "${bondholders}", bondholders);
                FindAndReplace(wordApp, "${summarwd}", summarwd);
                FindAndReplace(wordApp, "${summarpm}",summarpm);
                FindAndReplace(wordApp, "${debt}", debt);
                FindAndReplace(wordApp, "${dateexec}", dateexec);
                FindAndReplace(wordApp, "${nameStsknd}", nameStsknd);
                FindAndReplace(wordApp, "${infSuspension}", infSuspension);
                FindAndReplace(wordApp, "${infRenewal}", infRenewal);
                FindAndReplace(wordApp, "${commentsBond}", commentsBond);
                FindAndReplace(wordApp, "${BondKnd}", bondknd);

                FindAndReplace(wordApp, "${Tnum}", Snum);
                FindAndReplace(wordApp, "${TNIN}", SNIN);
                FindAndReplace(wordApp, "${TdateReg}", SdateReg);
                FindAndReplace(wordApp, "${Tdatechange}", Sdatechange);
                FindAndReplace(wordApp, "${TnameEmit}", SnameEmit);
                FindAndReplace(wordApp, "${Tspec}", Sspec);
                FindAndReplace(wordApp, "${TstsName}", SstsName);
                FindAndReplace(wordApp, "${Tnamests}", Snamests);
                FindAndReplace(wordApp, "${TcountECB}", ScountECB);
                FindAndReplace(wordApp, "${Tamount}", Samount);
                FindAndReplace(wordApp, "${TnumPP}", SnumPP);
                FindAndReplace(wordApp, "${Tperiod}", Speriod);
                FindAndReplace(wordApp, "${Tcomments}", Scomments);
                FindAndReplace(wordApp, "${Treason}", Sreason);
                FindAndReplace(wordApp, "${Tevents}", Sevents);
                FindAndReplace(wordApp, "${Tmeasure}", Smeasure);
                FindAndReplace(wordApp, "${Tshareholders}", Sshareholders);
                FindAndReplace(wordApp, "${Tbondholders}", Sbondholders);
                FindAndReplace(wordApp, "${Tsummarwd}", Ssummarwd);
                FindAndReplace(wordApp, "${Tsummarpm}", Ssummarpm);
                FindAndReplace(wordApp, "${Tdebt}", Sdebt);
                FindAndReplace(wordApp, "${Tdateexec}", Sdateexec);
                FindAndReplace(wordApp, "${TnameStsknd}", SnameStsknd);
                FindAndReplace(wordApp, "${TinfSuspension}", SinfSuspension);
                FindAndReplace(wordApp, "${TinfRenewal}", SinfRenewal);
                FindAndReplace(wordApp, "${TcommentsBond}", ScommentsBond);
                FindAndReplace(wordApp, "${TBondKnd}", Sbondknd);
                FindAndReplace(wordApp, "${TTenge}", Stenge);
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