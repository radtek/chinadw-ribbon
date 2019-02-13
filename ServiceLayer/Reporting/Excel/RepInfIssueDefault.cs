using ARM_User.BusinessLayer.Guides;
using ARM_User.Reports;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using Microsoft.Office.Interop.Excel;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
     * 79.	Сведения о дефолте выпуска
     */
    public class RepInfIssueDefault : ReportToExcel
    {
        #region Fields
        protected RepForm form;
        protected LanguageIds language;
        protected Decimal languageId;
        #endregion
        protected decimal idBond;
        protected string num, NIN, dateReg, datechange, nameEmit, spec, stsName, namests, countECB, amount, numPP, period, comments, reason, events, measure;
        protected string shareholders, bondholders, summarwd, summarpm, debt, dateexec, nameStsknd, infSuspension, infRenewal, commentsBond;
        

        #region Constructors
        public RepInfIssueDefault()
        {
        }

        public RepInfIssueDefault(RepForm form, LanguageIds language)
        {
            this.form = form;
            this.language = language;
        }
        #endregion

        public RepInfIssueDefault(RepForm form, LanguageIds language, decimal idBond)
            : this(form, language)
        {
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




        protected virtual void CreateReportFromCursor()
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var ws = wb.Worksheets[1] as Worksheet;



               // Range rngData = ws.get_Range("DATA", Type.Missing) as Range;
                //Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                //var rngBelowDataRow = ws.Rows[rngDataRow.Row, Type.Missing] as Range;

                //Range rngDataCountRow = rngData.Rows[2, Type.Missing] as Range;
//                var rngColumnDataRow = ws.Rows[rngDataCountRow.Row, Type.Missing] as Range;


                GetData();
                if (language == LanguageIds.Russian)
                {
                    ws.Range["B6"].Value = "Номер выпуска " +num;
                    ws.Range["C6"].Value = " НИН   " + NIN;
                    ws.Range["B7"].Value = "Дата регистрации " + dateReg;
                    ws.Range["D7"].Value = "Дата изменения выпуска  " + datechange;
                    ws.Range["B8"].Value = "Эмитент " +nameEmit;
                    ws.Range["B9"].Value = "Специализация " +spec;
                    ws.Range["B10"].Value = "Статус выпуска "+stsName;
                    ws.Range["C10"].Value = "Состояние размещения выпуска     " + namests;
                    ws.Range["B11"].Value = "Количество ЭЦБ " +countECB;

                    ws.Range["D11"].Value = "Объем выпуска "+ amount +"тенге";
                    ws.Range["C12"].Value = "Порядковый номер дефолта "+numPP;
                    ws.Range["C13"].Value = "Период "+period;
                    ws.Range["C14"].Value = "Информация о дефолте " +comments;
                    ws.Range["C15"].Value = "Причина дефолта  "+reason;
                    ws.Range["C16"].Value = "Мероприятия эмитента по выходу из дефолта " +events;
                    ws.Range["C18"].Value = "Принятые НБРК меры " +measure;
                    ws.Range["C19"].Value = "Крупные акционеры эмитента  " +shareholders;
                    ws.Range["C20"].Value = "Информация о держателях ЭЦБ " +bondholders;
                    ws.Range["C21"].Value = "Начисленная сумма вознаграждения " + summarwd;
                    ws.Range["C22"].Value = "Выплаченная сумма вознаграждения " + summarpm;
                    ws.Range["C23"].Value = "Остаток задолженности " +debt;
                    ws.Range["C24"].Value = "Дата погашения " + dateexec;
                    ws.Range["C25"].Value = "Состояние погашения задолженности " +nameStsknd;
                    ws.Range["C26"].Value = "Информация о приостановления размещения " +infSuspension;
                    ws.Range["C27"].Value = "Информация о возобновлении размещения " +infRenewal;
                    ws.Range["C28"].Value = "Примечание " + commentsBond;
                }
                else
                {
                    ws.Range["B6"].Value = num;
                    ws.Range["C6"].Value = "ҰСН   " + NIN;
                    ws.Range["B7"].Value = dateReg;
                    ws.Range["D7"].Value = datechange;
                    ws.Range["B8"].Value = nameEmit;
                    ws.Range["B9"].Value = spec;
                    ws.Range["B10"].Value = stsName;
                    ws.Range["C10"].Value = "Орналасу күйі      " + namests;
                    ws.Range["B11"].Value = countECB;

                    ws.Range["D11"].Value = amount;
                    ws.Range["B12"].Value = numPP;
                    ws.Range["B13"].Value = period;
                    ws.Range["B14"].Value = comments;
                    ws.Range["B15"].Value = reason;
                    ws.Range["B16"].Value = events;
                    ws.Range["B18"].Value = measure;
                    ws.Range["B19"].Value = shareholders;
                    ws.Range["B20"].Value = bondholders;
                    ws.Range["B21"].Value = summarwd;
                    ws.Range["B22"].Value = summarpm;
                    ws.Range["B23"].Value = debt;
                    ws.Range["B24"].Value = dateexec;
                    ws.Range["B25"].Value = nameStsknd;
                    ws.Range["B26"].Value = infSuspension;
                    ws.Range["B27"].Value = infRenewal;
                    ws.Range["B28"].Value = commentsBond;
                }


            }
            finally
            {
                EndFillReport();
            }
        }


        public override void ShowReport()
        {
            CreateReportFromCursor();

        }
    }
}
