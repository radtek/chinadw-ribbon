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

/*
 Author: Nurlan Ryskeldi  
  73.	Карточка запроса на присвоение НИН ГЦБ 
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepCardNINGCB : ReportToExcel
    {
        protected RepForm form;
        protected LanguageIds language;
        protected string Num, Date_Proposal, Name_Jur_Person, Name_Knd_GCB, NIN, Date_NIN, Num_Serial, Name_Currency, Term_Circulation, Name_UD, Date_Placement, Comments, User_Name,
                         Num_Cer, Date_GloCer, Nominal_Value, Total_Placement, Count_Pla, Date_Begin_Deal, Date_Repayment, Average_Price_Pla, Income_ACQ;
        protected decimal Id_GOVSECURITIES;
        protected Decimal languageId;

        public RepCardNINGCB(RepForm form, LanguageIds language, decimal Id_GOVSECURITIES)
        {
            this.form = form;
            this.language = language;
            this.Id_GOVSECURITIES = Id_GOVSECURITIES;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_CARD_NIN_GCB";
                cmd.Parameters.Add("Id_GOVSECURITIES_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Proposal_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Jur_Person_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Knd_GCB_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("NIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_NIN_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Serial_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Currency_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Term_Circulation_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_UD_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Placement_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Comments_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("User_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Cer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_GloCer_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Nominal_Value_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Total_Placement_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Count_Pla_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Begin_Deal_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Repayment_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Average_Price_Pla_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Income_ACQ_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_GOVSECURITIES_"].Value = Id_GOVSECURITIES;

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
                cmd.Parameters["Date_Proposal_"].Size = 4000;
                cmd.Parameters["Name_Jur_Person_"].Size = 4000;
                cmd.Parameters["Name_Knd_GCB_"].Size = 4000;
                cmd.Parameters["NIN_"].Size = 4000;
                cmd.Parameters["Date_NIN_"].Size = 4000;
                cmd.Parameters["Num_Serial_"].Size = 4000;
                cmd.Parameters["Name_Currency_"].Size = 4000;
                cmd.Parameters["Term_Circulation_"].Size = 4000;
                cmd.Parameters["Name_UD_"].Size = 4000;
                cmd.Parameters["Date_Placement_"].Size = 4000;
                cmd.Parameters["Comments_"].Size = 4000;
                cmd.Parameters["User_Name_"].Size = 4000;
                cmd.Parameters["Num_Cer_"].Size = 4000;
                cmd.Parameters["Date_GloCer_"].Size = 4000;
                cmd.Parameters["Nominal_Value_"].Size = 4000;
                cmd.Parameters["Total_Placement_"].Size = 4000;
                cmd.Parameters["Count_Pla_"].Size = 4000;
                cmd.Parameters["Date_Begin_Deal_"].Size = 4000;
                cmd.Parameters["Date_Repayment_"].Size = 4000;
                cmd.Parameters["Average_Price_Pla_"].Size = 4000;
                cmd.Parameters["Income_ACQ_"].Size = 4000;

                cmd.ExecuteNonQuery();
                Num = cmd.Parameters["Num_"].Value.ToString();
                if (Num == "null")
                {
                    Num = string.Empty;
                }

                Date_Proposal = cmd.Parameters["Date_Proposal_"].Value.ToString();
                if (Date_Proposal == "null")
                {
                    Date_Proposal = string.Empty;
                }
                Name_Jur_Person = cmd.Parameters["Name_Jur_Person_"].Value.ToString();
                if (Name_Jur_Person == "null")
                {
                    Name_Jur_Person = string.Empty;
                }

                Name_Knd_GCB = cmd.Parameters["Name_Knd_GCB_"].Value.ToString();
                if (Name_Knd_GCB == "null")
                {
                    Name_Knd_GCB = string.Empty;
                }

                NIN = cmd.Parameters["NIN_"].Value.ToString();
                if (NIN == "null")
                {
                    NIN = string.Empty;
                }

                Date_NIN = cmd.Parameters["Date_NIN_"].Value.ToString();
                if (Date_NIN == "null")
                {
                    Date_NIN = string.Empty;
                }

                Num_Serial = cmd.Parameters["Num_Serial_"].Value.ToString();
                if (Num_Serial == "null")
                {
                    Num_Serial = string.Empty;
                }

                Name_Currency = cmd.Parameters["Name_Currency_"].Value.ToString();
                if (Name_Currency == "null")
                {
                    Name_Currency = string.Empty;
                }

                Term_Circulation = cmd.Parameters["Term_Circulation_"].Value.ToString();
                if (Term_Circulation == "null")
                {
                    Term_Circulation = string.Empty;
                }

                Name_UD = cmd.Parameters["Name_UD_"].Value.ToString();
                if (Name_UD == "null")
                {
                    Name_UD = string.Empty;
                }

                Date_Placement = cmd.Parameters["Date_Placement_"].Value.ToString();
                if (Date_Placement == "null")
                {
                    Date_Placement = string.Empty;
                }

                Comments = cmd.Parameters["Comments_"].Value.ToString();
                if (Comments == "null")
                {
                    Comments = string.Empty;
                }

                User_Name = cmd.Parameters["User_Name_"].Value.ToString();
                if (User_Name == "null")
                {
                    User_Name = string.Empty;
                }

                Num_Cer = cmd.Parameters["Num_Cer_"].Value.ToString();
                if (Num_Cer == "null")
                {
                    Num_Cer = string.Empty;
                }

                Date_GloCer = cmd.Parameters["Date_GloCer_"].Value.ToString();
                if (Date_GloCer == "null")
                {
                    Date_GloCer = string.Empty;
                }

                Nominal_Value = cmd.Parameters["Nominal_Value_"].Value.ToString();
                if (Nominal_Value == "null")
                {
                    Nominal_Value = string.Empty;
                }

                Total_Placement = cmd.Parameters["Total_Placement_"].Value.ToString();
                if (Total_Placement == "null")
                {
                    Total_Placement = string.Empty;
                }

                Count_Pla = cmd.Parameters["Count_Pla_"].Value.ToString();
                if (Count_Pla == "null")
                {
                    Count_Pla = string.Empty;
                }

                Date_Begin_Deal = cmd.Parameters["Date_Begin_Deal_"].Value.ToString();
                if (Date_Begin_Deal == "null")
                {
                    Date_Begin_Deal = string.Empty;
                }

                Date_Repayment = cmd.Parameters["Date_Repayment_"].Value.ToString();
                if (Date_Repayment == "null")
                {
                    Date_Repayment = string.Empty;
                }

                Average_Price_Pla = cmd.Parameters["Average_Price_Pla_"].Value.ToString();
                if (Average_Price_Pla == "null")
                {
                    Average_Price_Pla = string.Empty;
                }

                Income_ACQ = cmd.Parameters["Income_ACQ_"].Value.ToString();
                if (Income_ACQ == "null")
                {
                    Income_ACQ = string.Empty;
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

        protected virtual void CreateReportFromXml()
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var ws = wb.Worksheets[1] as Worksheet;

                GetData();

                if (language == LanguageIds.Russian)
                {
                    ws.Range["A4"].Value = "Номер запроса: " + Num + " от " + Date_Proposal + "г.";
                    ws.Range["A5"].Value = "Наименование эмитента: " + Name_Jur_Person;
                    ws.Range["A6"].Value = "Вид ГЦБ: " + Name_Knd_GCB;
                    ws.Range["A7"].Value = "НИН: " + NIN + "  Дата присвоения: " + Date_NIN + "г.";
                    ws.Range["A8"].Value = "Порядковый номер эмиссии: " + Num_Serial;
                    ws.Range["A9"].Value = "Валюта эмиссии: " + Name_Currency;
                    ws.Range["A10"].Value = "Срок обращения: " + Term_Circulation + "  Единица измерения: " + Name_UD;
                    ws.Range["A11"].Value = "Предполагаемая дата размещения: " + Date_Placement + "г.";
                    ws.Range["A12"].Value = "Примечание: " + Comments;
                    ws.Range["A13"].Value = "Исполнитель: " + User_Name;
                    ws.Range["A15"].Value = "Глобальный сертификат № " + Num_Cer + " от " + Date_GloCer + "г.";
                    ws.Range["A16"].Value = "Номинальная стоимость: " + Nominal_Value + " KZT";
                    ws.Range["A17"].Value = "Объем выпуска: " + Total_Placement;
                    ws.Range["A18"].Value = "Количество: " + Count_Pla;
                    ws.Range["A19"].Value = "Дата начала обращения: " + Date_Begin_Deal + "г.  Дата погашения: " + Date_Repayment + "г.";
                    ws.Range["A20"].Value = "Средневзвешенная цена размещения: " + Average_Price_Pla + "  Доходность приобретения: " + Income_ACQ + "%";
                }
                else if (language == LanguageIds.Kazakh)
                {
                    ws.Range["A4"].Value = "Сұраным нөмірі: " + Num + "  " + Date_Proposal + "ж.";
                    ws.Range["A5"].Value = "Эмитент атауы: " + Name_Jur_Person;
                    ws.Range["A6"].Value = "МБҚ түрі: " + Name_Knd_GCB;
                    ws.Range["A7"].Value = "ҰБН: " + NIN + "  Берілген күні:  " + Date_NIN + "ж.";
                    ws.Range["A8"].Value = "Эмиссияның реттік нөмірі: " + Num_Serial;
                    ws.Range["A9"].Value = "Эмиссия валютасы: " + Name_Currency;
                    ws.Range["A10"].Value = "Айналыс мерзімі: " + Term_Circulation + "  Өлшем бірлігі: " + Name_UD;
                    ws.Range["A11"].Value = "Болжамды орналыстыруы күні: " + Date_Placement + "ж.";
                    ws.Range["A12"].Value = "Қосымша: " + Comments;
                    ws.Range["A13"].Value = "Орындаушы: " + User_Name;
                    ws.Range["A15"].Value = "Ғаламдық сертификат № " + Num_Cer + "  " + Date_GloCer + "ж.";
                    ws.Range["A16"].Value = "Номиналдық құны: " + Nominal_Value + " KZT";
                    ws.Range["A17"].Value = "Шығарылым көлемі: " + Total_Placement;
                    ws.Range["A18"].Value = "Саны: " + Count_Pla;
                    ws.Range["A19"].Value = "Айналыс бастау күні: " + Date_Begin_Deal + "ж.  Өтеу күні: " + Date_Repayment + "ж.";
                    ws.Range["A20"].Value = "Орташа өлшенген орналыстыру құны: " + Average_Price_Pla + "  Мүлiктенү табыстылық: " + Income_ACQ + "%";
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