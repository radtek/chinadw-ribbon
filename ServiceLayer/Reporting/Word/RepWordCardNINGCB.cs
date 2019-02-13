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
    public class RepWordCardNINGCB : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;        
        protected Decimal languageId;
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
        public Document wordDoc;
        #endregion
        protected string Num, Date_Proposal, Name_Jur_Person, Name_Knd_GCB, NIN, Date_NIN, Num_Serial, Name_Currency, Term_Circulation, Name_UD, Date_Placement, Comments, User_Name,
                         Num_Cer, Date_GloCer, Nominal_Value, Total_Placement, Count_Pla, Date_Begin_Deal, Date_Repayment, Average_Price_Pla, Income_ACQ;
        protected decimal Id_GOVSECURITIES;
        protected string SNum, SName_Jur_Person, SName_Knd_GCB, SDate_NIN, SNum_Serial, SName_Currency, STerm_Circulation, SDate_Placement, SComments, SUser_Name, SName_UD ,SPer,
                   SGlobalCer, SNominal_Value, STotal_Placement, SCount_Pla, SDate_Repayment, SIncome_ACQ, SText, Sfrom, SYear, SKzt, SDate_Begin_Deal, SNIN, SDate_GloCer, SAverage_Price_Pla;
        public RepWordCardNINGCB(RepForm form, LanguageIds language, decimal Id_GOVSECURITIES)
            : base(form, language)
        {
            this.form = form;
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
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
            if (language == LanguageIds.Russian)
            {
                SText = "КАРТОЧКА ЗАПРОСА НА ПРИСВОЕНИЕ НИН ГЦБ";
                SNum = "Номер запроса: ";// +Num + " от " + Date_Proposal + "г.";                
                SYear = "г.";
                Sfrom = "от";
                SName_Jur_Person = "Наименование эмитента: ";// + Name_Jur_Person;
                SName_Knd_GCB = "Вид ГЦБ: ";//+ Name_Knd_GCB;А
                SNIN = "НИН: ";//+ NIN;
                SDate_NIN = "Дата присвоения: ";// + Date_NIN + "г.";
                SNum_Serial = "Порядковый номер эмиссии: ";//+ Num_Serial;
                SName_Currency = "Валюта эмиссии: ";//+ Name_Currency;
                STerm_Circulation = "Срок обращения: ";// + Term_Circulation;
                SName_UD = "  Единица измерения: ";//+ Name_UD;
                SDate_Placement = "Предполагаемая дата размещения: ";// + Date_Placement + "г.";
                SComments = "Примечание: ";// + Comments;
                SUser_Name = "Исполнитель: ";//+ User_Name;
                SGlobalCer = "Глобальный сертификат № ";//+ Num_Cer + " от ";
                //SDate_GloCer = Date_GloCer + "г.";
                SNominal_Value = "Номинальная стоимость: ";//+ Nominal_Value + " KZT";
                SKzt = "KZT";
                STotal_Placement = "Объем выпуска: ";// + Total_Placement;
                SCount_Pla = "Количество: ";//+ Count_Pla;
                SDate_Repayment = "Дата погашения: ";//+ Date_Repayment + "г.";
                SDate_Begin_Deal = "Дата начала обращения: ";//+ Date_Begin_Deal ;
                SAverage_Price_Pla = "Средневзвешенная цена размещения: ";// + Average_Price_Pla;
                SIncome_ACQ = "  Доходность приобретения: ";//+ Income_ACQ + "%";
                SPer = "%";
            }
            else
            {
                SText = "МБҚ-ға ҰБН БЕРУ СҰРАНЫМ КАРТОЧКАСЫ";
                SNum = "Сұраным нөмірі: "; //+ Num + " от " + Date_Proposal + "г.";
                SYear = "ж.";
                Sfrom = "  ";
                SName_Jur_Person = "Эмитент атауы: "; // + Name_Jur_Person;
                SName_Knd_GCB = "МБҚ түрі: "; // + Name_Knd_GCB;
                SDate_NIN = "Берілген күні: "; //+ NIN + "  Берілген күні: " + Date_NIN + "г.";
                SNIN = "ҰБН: ";
                SNum_Serial = "Эмиссияның реттік нөмірі: ";// +Num_Serial;
                SName_Currency = "Эмиссия валютасы: ";// + Name_Currency;
                STerm_Circulation = "Айналыс мерзімі: ";// + Term_Circulation + "  Өлшем бірлігі: " + Name_UD;
                SName_UD = "Өлшем бірлігі: ";
                SDate_Placement = "Болжамды орналыстыруы күні: ";// + Date_Placement + "г.";
                SComments = "Қосымша: ";// + Comments;
                SUser_Name = "Орындаушы: ";// + User_Name;
                SGlobalCer = "Ғаламдық сертификат № ";// + Num_Cer + "  " + Date_GloCer + "ж.";
                SNominal_Value = "Номиналдық құны: ";// + Nominal_Value + " KZT";
                SKzt = "KZT";
                STotal_Placement = "Шығарылым көлемі: ";// +Total_Placement;
                SCount_Pla = "Саны: ";// +Count_Pla;
                //SDate_Repayment = "Айналыс бастау күні: " + Date_Begin_Deal + "ж.  Өтеу күні: " + Date_Repayment + "ж.";
                //SIncome_ACQ = "Орташа өлшенген орналыстыру құны: " + Average_Price_Pla + "  Мүлiктенү табыстылық: " + Income_ACQ + "%";

                SDate_Repayment = "Өтеу күні: ";//+ Date_Repayment + "г.";
                SDate_Begin_Deal = "Айналыс бастау күні: ";//+ Date_Begin_Deal ;
                SAverage_Price_Pla = "Орташа өлшенген орналыстыру құны: ";// + Average_Price_Pla;
                SIncome_ACQ = "  Мүлiктенү табыстылық: ";//+ Income_ACQ + "%";
                SPer = "%";
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

                FindAndReplace(wordApp, "${Text}", SText);
                FindAndReplace(wordApp, "${TNum}", SNum);
                FindAndReplace(wordApp, "${Num}", Num);
                FindAndReplace(wordApp, "${Tfrom}", Sfrom);
                FindAndReplace(wordApp, "${TYear}", SYear);
                FindAndReplace(wordApp, "${TName_Jur_Person}", SName_Jur_Person);
                FindAndReplace(wordApp, "${Name_Jur_Person}", Name_Jur_Person);
                FindAndReplace(wordApp, "${TName_Knd_GCB}", SName_Knd_GCB);
                FindAndReplace(wordApp, "${Name_Knd_GCB}", Name_Knd_GCB);
                FindAndReplace(wordApp, "${TNIN}", SNIN);
                FindAndReplace(wordApp, "${NIN}", NIN);
                FindAndReplace(wordApp, "${TDate_NIN}", SDate_NIN);
                FindAndReplace(wordApp, "${Date_NIN}", Date_NIN);                
                FindAndReplace(wordApp, "${TNum_Serial}", SNum_Serial);
                FindAndReplace(wordApp, "${Num_Serial}", Num_Serial);
                FindAndReplace(wordApp, "${TName_Currency}", SName_Currency);
                FindAndReplace(wordApp, "${Name_Currency}", Name_Currency);
                FindAndReplace(wordApp, "${TTerm_Circulation}", STerm_Circulation);
                FindAndReplace(wordApp, "${Term_Circulation}", Term_Circulation);
                FindAndReplace(wordApp, "${TName_UD}", SName_UD);
                FindAndReplace(wordApp, "${Name_UD}", Name_UD);
                FindAndReplace(wordApp, "${TDate_Placement}", SDate_Placement);
                FindAndReplace(wordApp, "${Date_Placement}", Date_Placement);
                FindAndReplace(wordApp, "${TComments}", SComments);
                FindAndReplace(wordApp, "${Comments}", Comments);
                FindAndReplace(wordApp, "${TUser_Name}", SUser_Name);
                FindAndReplace(wordApp, "${User_Name}", User_Name);
                FindAndReplace(wordApp, "${TGlobalCer}", SGlobalCer);
                FindAndReplace(wordApp, "${GlobalCer}", Num_Cer);
                FindAndReplace(wordApp, "${TDate_GloCer}", SDate_GloCer);
                FindAndReplace(wordApp, "${Date_GloCer}", Date_GloCer);
                FindAndReplace(wordApp, "${TNominal_Value}", SNominal_Value);
                FindAndReplace(wordApp, "${Nominal_Value}", Nominal_Value);
                FindAndReplace(wordApp, "${SKzt}", SKzt);
                FindAndReplace(wordApp, "${TTotal_Placement}", STotal_Placement);
                FindAndReplace(wordApp, "${Total_Placement}", Total_Placement);
                FindAndReplace(wordApp, "${TCount_Pla}", SCount_Pla);
                FindAndReplace(wordApp, "${Count_Pla}", Count_Pla);
                FindAndReplace(wordApp, "${TDate_Repayment}", SDate_Repayment);
                FindAndReplace(wordApp, "${Date_Repayment}", Date_Repayment);
                FindAndReplace(wordApp, "${TDate_Begin_Deal}", SDate_Begin_Deal);
                FindAndReplace(wordApp, "${SDate_Begin_Deal}", Date_Begin_Deal);
                FindAndReplace(wordApp, "${TAverage_Price_Pla}", SAverage_Price_Pla);
                FindAndReplace(wordApp, "${Average_Price_Pla}", Average_Price_Pla);
                FindAndReplace(wordApp, "${TIncome_ACQ}", SIncome_ACQ);
                FindAndReplace(wordApp, "${Income_ACQ}", Income_ACQ);
                FindAndReplace(wordApp, "${SPer}", SPer);
                FindAndReplace(wordApp, "${TDateProposal}", Date_Proposal);
                

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