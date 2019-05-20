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
    public class RepWordReestrKdr : GeneralWordReport
    {
        #region Fields
        protected Microsoft.Office.Interop.Excel.Range range2;
        protected Decimal languageId;
#pragma warning disable CS0108 // 'RepWordReestrKdr.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'RepWordReestrKdr.wordparagraph' is never used
        private Microsoft.Office.Interop.Word.Paragraph wordparagraph;
#pragma warning restore CS0169 // The field 'RepWordReestrKdr.wordparagraph' is never used
#pragma warning restore CS0108 // 'RepWordReestrKdr.wordparagraph' hides inherited member 'WordReport.wordparagraph'. Use the new keyword if hiding was intended.
        public Document wordDoc;
        #endregion
        protected string firstName, lastName;
        protected string SNameKdr, SNameIssue, SCode, SName1, SRegion, SAddress, SOKPO, SRegistr_Jur, SReg_Num, vNameSts, SRegName, SNum, SNumSerial, SFormType, STerm_Circulation, SPrice_Placement, SPlacementSts, SDate_Placement,
                         SAmount_Placement, SAmount_PlacementTg, SUserName, STPayAgent, SPayAgent1, STUnderrider, SUnderrider, SRepName, SInfoIssue, SEmitent, SCountry, SPayAgent2, SKndCategoryBase, SSrokObr, SPrice, SNameSts;
        protected string Name_Emit1_, Code1_, Oblast1_, Address1_, OKPO1_, Registr_Jur1_, Reg_Num1_, Name_Sts1_, Date_Reg1_, Num1_, Num_Serial1_, Form_Vyp1_, Term_Circulation1_,
                          Price_Placement1_, Placement_Sts1_, User_Name1_, Pay_Agent1_, Underrider1_, Emitent1_, Country1_, Pay_Agent2_, KNDANDCATEGORYBASEACTIV1_, namereg, regdate;
        protected string Date_Placement_E1_, Srok_Obr1_, Amount_Placement1_, Amount_Placement_TG1_, Price_R1_, STableName1, STextTable, TextTable;
        protected decimal? Id_KDR;
        protected int coloumn;
        protected string[] template = new string[10];
        public RepWordReestrKdr(RepForm form, LanguageIds language, decimal? Id_KDR)
            : base(form, language)
        {
            this.form = form;
            this.Id_KDR = Id_KDR;
        }
        protected virtual string GetData()
        {
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REESTR_KDR";
                cmd.Parameters.Add("Id_KDR_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Decimal, ParameterDirection.Input);
                cmd.Parameters.Add("Name_Emit_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Code_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Oblast_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Address_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("OKPO_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Registr_Jur_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Sts_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Num_Serial_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Form_Vyp_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Term_Circulation_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_Placement_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Placement_Sts_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Date_Placement_E_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Amount_Placement_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Amount_Placement_TG_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("User_Name_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Pay_Agent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Underrider_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Emitent_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Country_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Pay_Agent1_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("KNDANDCATEGORYBASEACTIV_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Srok_Obr_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Price_R_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Name_Reg_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Reg_Date_", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_KDR_"].Value = Id_KDR;

                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;

                cmd.Parameters["Name_Emit_"].Size = 4000;
                cmd.Parameters["Code_"].Size = 4000;
                cmd.Parameters["Oblast_"].Size = 4000;
                cmd.Parameters["Address_"].Size = 4000;
                cmd.Parameters["OKPO_"].Size = 4000;
                cmd.Parameters["Registr_Jur_"].Size = 4000;
                cmd.Parameters["Reg_Num_"].Size = 4000;
                cmd.Parameters["Name_Sts_"].Size = 4000;
                cmd.Parameters["Date_Reg_"].Size = 4000;
                cmd.Parameters["Num_"].Size = 4000;
                cmd.Parameters["Num_Serial_"].Size = 4000;
                cmd.Parameters["Form_Vyp_"].Size = 4000;
                cmd.Parameters["Term_Circulation_"].Size = 4000;
                cmd.Parameters["Price_Placement_"].Size = 4000;
                cmd.Parameters["Placement_Sts_"].Size = 4000;
                cmd.Parameters["Date_Placement_E_"].Size = 4000;
                cmd.Parameters["Amount_Placement_"].Size = 4000;
                cmd.Parameters["Amount_Placement_TG_"].Size = 4000;
                cmd.Parameters["User_Name_"].Size = 4000;
                cmd.Parameters["Pay_Agent_"].Size = 4000;
                cmd.Parameters["Underrider_"].Size = 4000;
                cmd.Parameters["Emitent_"].Size = 4000;
                cmd.Parameters["Country_"].Size = 4000;
                cmd.Parameters["Pay_Agent1_"].Size = 4000;
                cmd.Parameters["KNDANDCATEGORYBASEACTIV_"].Size = 4000;
                cmd.Parameters["Srok_Obr_"].Size = 4000;
                cmd.Parameters["Price_R_"].Size = 4000;
                cmd.Parameters["Name_Reg_"].Size = 4000;
                cmd.Parameters["Reg_Date_"].Size = 4000;

                cmd.ExecuteNonQuery();

                Name_Emit1_ = cmd.Parameters["Name_Emit_"].Value.ToString();
                if (Name_Emit1_ == "null")
                {
                    Name_Emit1_ = string.Empty;
                }

                Code1_ = cmd.Parameters["Code_"].Value.ToString();
                if (Code1_ == "null")
                {
                    Code1_ = string.Empty;
                }

                Oblast1_ = cmd.Parameters["Oblast_"].Value.ToString();
                if (Oblast1_ == "null")
                {
                    Oblast1_ = string.Empty;
                }

                Address1_ = cmd.Parameters["Address_"].Value.ToString();
                if (Address1_ == "null")
                {
                    Address1_ = string.Empty;
                }

                OKPO1_ = cmd.Parameters["OKPO_"].Value.ToString();
                if (OKPO1_ == "null")
                {
                    OKPO1_ = string.Empty;
                }

                Registr_Jur1_ = cmd.Parameters["Registr_Jur_"].Value.ToString();
                if (Registr_Jur1_ == "null")
                {
                    Registr_Jur1_ = string.Empty;
                }

                Reg_Num1_ = cmd.Parameters["Reg_Num_"].Value.ToString();
                if (Reg_Num1_ == "null")
                {
                    Reg_Num1_ = string.Empty;
                }

                Name_Sts1_ = cmd.Parameters["Name_Sts_"].Value.ToString();
                if (Name_Sts1_ == "null")
                {
                    Name_Sts1_ = string.Empty;
                }

                Date_Reg1_ = cmd.Parameters["Date_Reg_"].Value.ToString();
                if (Date_Reg1_ == "null")
                {
                    Date_Reg1_ = string.Empty;
                }

                Num1_ = cmd.Parameters["Num_"].Value.ToString();
                if (Num1_ == "null")
                {
                    Num1_ = string.Empty;
                }

                Num_Serial1_ = cmd.Parameters["Num_Serial_"].Value.ToString();
                if (Num_Serial1_ == "null")
                {
                    Num_Serial1_ = string.Empty;
                }

                Form_Vyp1_ = cmd.Parameters["Form_Vyp_"].Value.ToString();
                if (Form_Vyp1_ == "null")
                {
                    Form_Vyp1_ = string.Empty;
                }

                Term_Circulation1_ = cmd.Parameters["Term_Circulation_"].Value.ToString();
                if (Term_Circulation1_ == "null")
                {
                    Term_Circulation1_ = string.Empty;
                }

                Price_Placement1_ = cmd.Parameters["Price_Placement_"].Value.ToString();
                if (Price_Placement1_ == "null")
                {
                    Price_Placement1_ = string.Empty;
                }

                Placement_Sts1_ = cmd.Parameters["Placement_Sts_"].Value.ToString();
                if (Placement_Sts1_ == "null")
                {
                    Placement_Sts1_ = string.Empty;
                }

                Date_Placement_E1_ = cmd.Parameters["Date_Placement_E_"].Value.ToString();
                if (Date_Placement_E1_ == "null")
                {
                    Date_Placement_E1_ = string.Empty;
                }

                Amount_Placement1_ = cmd.Parameters["Amount_Placement_"].Value.ToString();
                if (Amount_Placement1_ == "null")
                {
                    Amount_Placement1_ = string.Empty;
                }

                Amount_Placement_TG1_ = cmd.Parameters["Amount_Placement_TG_"].Value.ToString();
                if (Amount_Placement_TG1_ == "null")
                {
                    Amount_Placement_TG1_ = string.Empty;
                }

                User_Name1_ = cmd.Parameters["User_Name_"].Value.ToString();
                if (User_Name1_ == "null")
                {
                    User_Name1_ = string.Empty;
                }

                Pay_Agent1_ = cmd.Parameters["Pay_Agent_"].Value.ToString();
                if (Pay_Agent1_ == "null")
                {
                    Pay_Agent1_ = string.Empty;
                }

                Underrider1_ = cmd.Parameters["Underrider_"].Value.ToString();
                if (Underrider1_ == "null")
                {
                    Underrider1_ = string.Empty;
                }

                Emitent1_ = cmd.Parameters["Emitent_"].Value.ToString();
                if (Emitent1_ == "null")
                {
                    Emitent1_ = string.Empty;
                }

                Country1_ = cmd.Parameters["Country_"].Value.ToString();
                if (Country1_ == "null")
                {
                    Country1_ = string.Empty;
                }

                Pay_Agent2_ = cmd.Parameters["Pay_Agent1_"].Value.ToString();
                if (Pay_Agent2_ == "null")
                {
                    Pay_Agent2_ = string.Empty;
                }

                KNDANDCATEGORYBASEACTIV1_ = cmd.Parameters["KNDANDCATEGORYBASEACTIV_"].Value.ToString();
                if (KNDANDCATEGORYBASEACTIV1_ == "null")
                {
                    KNDANDCATEGORYBASEACTIV1_ = string.Empty;
                }

                Srok_Obr1_ = cmd.Parameters["Srok_Obr_"].Value.ToString();
                if (Srok_Obr1_ == "null")
                {
                    Srok_Obr1_ = string.Empty;
                }

                Price_R1_ = cmd.Parameters["Price_R_"].Value.ToString();
                if (Price_R1_ == "null")
                {
                    Price_R1_ = string.Empty;
                }
                namereg = cmd.Parameters["Name_Reg_"].Value.ToString();
                if (namereg == "null")
                {
                    namereg = string.Empty;
                }
                regdate = cmd.Parameters["Reg_Date_"].Value.ToString();
                if (regdate == "null")
                {
                    regdate = string.Empty;
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

        public System.Data.DataTable GetCursor()
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            using (var cmd = ConnectionHolder.Instance.Connection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "G_REP_REESTR_KDR1";
                cmd.Parameters.Add("Id_KDR_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Lang_id_", OracleDbType.Int32, ParameterDirection.Input);
                cmd.Parameters.Add("Cur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Code", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                cmd.Parameters["Id_KDR_"].Value = Id_KDR;
                if (language == LanguageIds.Russian)
                {
                    languageId = 1;
                }
                if (language == LanguageIds.Kazakh)
                {
                    languageId = 2;
                }
                cmd.Parameters["Lang_id_"].Value = languageId;
                cmd.Parameters["Err_Msg"].Size = 4000;


                using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                {
                    oda.Fill(dt1);
                }

                return dt1;
            }
        }
        public override void ShowReport()
        {

            CreateWord();
            BeginFillReport();
            GetData();
            if (language == LanguageIds.Russian)
            {
                SNameKdr = " Реестр казахстанских депозитарных расписок";
                SName1 = "наименование эмитента";
                SNameIssue = Name_Emit1_;
                SCode = "Код ";// +Code1_;
                SRegion = "Область  ";// + Oblast1_;
                SAddress = "Адрес  ";// + Address1_;
                SOKPO = "ОКПО ";//+ OKPO1_;
                SRegistr_Jur = "Регистрацию ЮЛ  ";//+ Registr_Jur1_;
                SReg_Num = "за № ";//+ Reg_Num1_;
                SNameSts = "Статус эмитента:  ";//+ Name_Sts1_;
                SRegName = "Выпуск зарегистрирован  ";//+ Date_Reg1_;
                SNum = "за № ";//+ Num1_;
                SNumSerial = "Порядковый номер выпуска  ";// + Num_Serial1_;
                SFormType = "Форма выпуска";//+ Form_Vyp1_;
                STerm_Circulation = "Срок обращения  ";//+ Term_Circulation1_;
                SPrice_Placement = "Цена размещения: ";// + Price_Placement1_;
                SPlacementSts = "Состояние размещения на";//+ Placement_Sts1_;
                SDate_Placement = "на ";// + Date_Placement_E1_;
                SAmount_Placement = "Объем размещения КДР по утвержденным  ";//+ Amount_Placement1_;
                SAmount_PlacementTg = "отчетам, тг ";// + Amount_Placement_TG1_;
                SUserName = "Выпуск регистрировал  ";//+ User_Name1_;
                STPayAgent = "Платежный агент:";
                SPayAgent1 = Pay_Agent1_;
                STUnderrider = "Андеррайтер:";
                SUnderrider = Underrider1_;
                SRepName = "Отчеты о движении эмиссии:";
                SInfoIssue = "Информация о эмитенте базового актива:";
                SEmitent = "Эмитент  ";// + Emitent1_;
                SCountry = "Страна  ";//+ Country1_;
                SPayAgent2 = "Платежный агент  ";// + Pay_Agent2_;
                SKndCategoryBase = "Вид  и категория базового актива  ";//+ KNDANDCATEGORYBASEACTIV1_;
                SSrokObr = "Срок обращения  ";//+ Srok_Obr1_;
                SPrice = "Рыночная цена";//+ Price_R1_;
                STableName1 = "Структура эмиссии:";
                template[0] = "Вид производныхценных бумаг";
                template[1] = "Количество";
                template[2] = "НИН";
                template[3] = "Примечание";
                template[4] = "По данным на дд.мм.гггг";
            }
            else
            {
                SNameKdr = "ҚАЗАҚСТАНДЫҚ ДЕПОЗИТАРЛЫҚ ҚОЛХАТТАРДЫҢ РЕЕСТРІ";
                SName1 = "Атауы";
                SNameIssue = Name_Emit1_;
                SCode = "Коды";//+ Code1_;
                SRegion = "Обласы  ";//+ Oblast1_;
                SAddress = "Мекен-жайы  ";//+ Address1_;
                SOKPO = "БСН КҰЖС ";//+ OKPO1_;
                SRegistr_Jur = "ЗТ тіркеу  ";//+ Registr_Jur1_;
                SReg_Num = "за № ";//+ Reg_Num1_;
                SNameSts = "Эмитента жағдайы:  ";//+ Name_Sts1_;
                SRegName = "Шығарылым тіркелінді  ";//+ Date_Reg1_;
                SNum = "за № ";//+ Num1_;
                SNumSerial = "Шығарылымның реттік нөмірі  ";//+ Num_Serial1_;
                SFormType = " ";//+ Form_Vyp1_;
                STerm_Circulation = "Айналыс мерзімі  ";// + Term_Circulation1_;
                SPrice_Placement = "Орналастыру бағасы: ";//+ Price_Placement1_;
                SPlacementSts = "Орналастырудың жай-күйі  ";//+ Placement_Sts1_;
                SDate_Placement = "на ";//+ Date_Placement_E1_;
                SAmount_Placement = "ҚДҚ орналастыру көлемі бекітілген  ";//+ Amount_Placement1_;
                SAmount_PlacementTg = "есептер бойынша, тг ";// + Amount_Placement_TG1_;
                SUserName = "Шығарылымды тіркеген  ";// + User_Name1_;
                STPayAgent = "Төлемді агенттің атауы:";
                SPayAgent1 = Pay_Agent1_;
                STUnderrider = "Андеррайтер:";
                SUnderrider = Underrider1_;
                SPrice = "Нарықтық бағасы";
                SRepName = "Шығарындылары қозғалыс туралы есептер:";
                SInfoIssue = "Эмиссия қозғалысы туралы есептер:";
                SEmitent = "Эмитент  ";//+ Emitent1_;
                SCountry = "Елі  ";//+ Country1_;
                SPayAgent2 = "Төлемді агенттің атауы  ";// + Pay_Agent2_;
                SKndCategoryBase = "Вид  и категория базового актива  ";// + KNDANDCATEGORYBASEACTIV1_;
                SSrokObr = "Айналыс мерзімі  ";//+ Srok_Obr1_;
                SPrice = " " + Price_R1_;
                STableName1 = "  Эмиссияның құрылымы:";                
                template[0] = "Туынды бағалы қағаздар түрі";
                template[1] = "Саны";
                template[2] = "ҰСН";
                template[3] = "Қосымша";
                template[4] = "Деректер бойынша кк.аа.жжжж";
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

                FindAndReplace(wordApp, "${NameKdr}", SNameKdr);
                FindAndReplace(wordApp, "${NameIssue}", SNameIssue);
                FindAndReplace(wordApp, "${Name1}", SName1);
                FindAndReplace(wordApp, "${Code}", Code1_);
                FindAndReplace(wordApp, "${Region}", Oblast1_);
                FindAndReplace(wordApp, "${Address}", Address1_);
                FindAndReplace(wordApp, "${OKPO}", OKPO1_);
                FindAndReplace(wordApp, "${Registr_Jur}", namereg);
                FindAndReplace(wordApp, "${Reg_Num}", Reg_Num1_);
                FindAndReplace(wordApp, "${NameSts}", Name_Sts1_);
                FindAndReplace(wordApp, "${RegName}", User_Name1_);
                FindAndReplace(wordApp, "${NumSerial}", Num_Serial1_);
                FindAndReplace(wordApp, "${FormType}", Form_Vyp1_);
                FindAndReplace(wordApp, "${Num}", Num1_);
                FindAndReplace(wordApp, "${Term_Circulation}", Term_Circulation1_);
                FindAndReplace(wordApp, "${Price_Placement}", Price_Placement1_);
                FindAndReplace(wordApp, "${PlacementSts}", Placement_Sts1_);
                FindAndReplace(wordApp, "${Amount_Placement}", Amount_Placement1_);
                FindAndReplace(wordApp, "${Amount_PlacementTg}", Amount_Placement_TG1_);
                FindAndReplace(wordApp, "${Date_Placement}", Date_Placement_E1_);
                FindAndReplace(wordApp, "${UserName}", User_Name1_);
                FindAndReplace(wordApp, "${PayAgent}", Pay_Agent1_);
                FindAndReplace(wordApp, "${PayAgent1}", Pay_Agent2_);
                FindAndReplace(wordApp, "${Underrider}", Underrider1_);
                FindAndReplace(wordApp, "${RepName}", SRepName);
                FindAndReplace(wordApp, "${InfoIssue}", SInfoIssue);
                FindAndReplace(wordApp, "${Emitent}", Emitent1_);
                FindAndReplace(wordApp, "${Country}", Country1_);
                FindAndReplace(wordApp, "${PayAgent2}", Pay_Agent1_);
                FindAndReplace(wordApp, "${KndCategoryBase}", KNDANDCATEGORYBASEACTIV1_);
                FindAndReplace(wordApp, "${SrokObr}", Srok_Obr1_);
                FindAndReplace(wordApp, "${Price}", Price_R1_);
                FindAndReplace(wordApp, "${RegDate}", regdate);
                FindAndReplace(wordApp, "${DateReg}", Date_Reg1_);

                FindAndReplace(wordApp, "${TNameKdr}", SNameKdr);
                FindAndReplace(wordApp, "${TNameIssue}", SNameIssue);
                FindAndReplace(wordApp, "${TCode}", SCode);
                FindAndReplace(wordApp, "${TName1}", SName1);
                FindAndReplace(wordApp, "${TRegion}", SRegion);
                FindAndReplace(wordApp, "${TAddress}", SAddress);
                FindAndReplace(wordApp, "${TOKPO}", SOKPO);
                FindAndReplace(wordApp, "${TRegistr_Jur}", SRegistr_Jur);
                FindAndReplace(wordApp, "${TReg_Num}", SReg_Num);
                FindAndReplace(wordApp, "${TNameSts}", SNameSts);
                FindAndReplace(wordApp, "${TRegName}", SRegName);
                FindAndReplace(wordApp, "${TNumSerial}", SNumSerial);
                FindAndReplace(wordApp, "${TFormType}", SFormType);
                FindAndReplace(wordApp, "${TNum}", SNum);
                FindAndReplace(wordApp, "${TTerm_Circulation}", STerm_Circulation);
                FindAndReplace(wordApp, "${TPrice_Placement}", SPrice_Placement);
                FindAndReplace(wordApp, "${TPlacementSts}", SPlacementSts);
                FindAndReplace(wordApp, "${TAmount_Placement}", SAmount_Placement);
                FindAndReplace(wordApp, "${TAmount_PlacementTg}", SAmount_PlacementTg);
                FindAndReplace(wordApp, "${TDate_Placement}", SDate_Placement);
                FindAndReplace(wordApp, "${TUserName}", SUserName);
                FindAndReplace(wordApp, "${TPayAgent}", STPayAgent);
                FindAndReplace(wordApp, "${TTUnderrider}", STUnderrider);
                FindAndReplace(wordApp, "${TUnderrider}", SUnderrider);
                // FindAndReplace(wordApp, "${InfoIssue}", infois);
                FindAndReplace(wordApp, "${TEmitent}", SEmitent);
                FindAndReplace(wordApp, "${TCountry}", SCountry);
                FindAndReplace(wordApp, "${TPayAgent2}", SPayAgent2);
                FindAndReplace(wordApp, "${TKndCategoryBase}", SKndCategoryBase);
                FindAndReplace(wordApp, "${TSrokObr}", SSrokObr);
                FindAndReplace(wordApp, "${TPrice}", SPrice);
                #region table1
                System.Data.DataTable dt1 = GetCursor();

                CreateTableWord(wordDoc, dt1.Rows.Count + 2, 5, 2, STableName1, true, true);

                wordcellrange = wordtable.Cell(2, 1).Range;
                wordcellrange.Text = template[0];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 2).Range;
                wordcellrange.Text = template[1];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 3).Range;
                wordcellrange.Text = template[2];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 4).Range;
                wordcellrange.Text = template[3];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordcellrange = wordtable.Cell(2, 5).Range;
                wordcellrange.Text = template[4];
                wordcellrange.Font.Bold = 1;
                wordcellrange.Borders.Enable = 1;
                wordcellrange.Font.Size = 11;
                wordtable.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                coloumn = 2;
                for (var i = 0; i < dt1.Rows.Count; i++)
                {
                    coloumn = coloumn + 1;
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = dt1.Rows[i]["KND_CB"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = dt1.Rows[i]["CNT"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordcellrange = wordtable.Cell(coloumn, 3).Range;
                    wordcellrange.Text = dt1.Rows[i]["NIN"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordcellrange = wordtable.Cell(coloumn, 4).Range;
                    wordcellrange.Text = dt1.Rows[i]["COMMENTS"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 4).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    wordcellrange = wordtable.Cell(coloumn, 5).Range;
                    wordcellrange.Text = dt1.Rows[i]["DATE_REG"].ToString();
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 1;
                    wordcellrange.Font.Size = 11;
                }
                #endregion
                #region TextTable1
                CreateTableWord(wordDoc, 7, 2, 3, SInfoIssue, true,false);
                coloumn = 1;
                for (var i = 0; i < 7; i++)
                {
                    coloumn = coloumn + 1;
                    if (coloumn == 2)
                    {
                        STextTable = SEmitent;
                        TextTable = Emitent1_;
                    }
                    else if (coloumn == 3)
                    {
                        STextTable = SCountry;
                        TextTable = Country1_;
                    }
                    else if (coloumn == 4)
                    {
                        STextTable = SPayAgent2;
                        TextTable = Pay_Agent1_;
                    }
                    else if (coloumn == 5)
                    {
                        STextTable = SKndCategoryBase;
                        TextTable = KNDANDCATEGORYBASEACTIV1_;
                    }
                    else if (coloumn == 6)
                    {
                        STextTable = SSrokObr;
                        TextTable = Srok_Obr1_;
                    }
                    else if (coloumn == 7)
                    {
                        STextTable = SPrice;
                        TextTable = Price_R1_;
                    }
                    wordcellrange = wordtable.Cell(coloumn, 1).Range;
                    wordcellrange.Text = STextTable;
                    wordcellrange.Font.Bold = 0;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                    wordcellrange = wordtable.Cell(coloumn, 2).Range;
                    wordcellrange.Text = TextTable;
                    wordcellrange.Font.Bold = 1;
                    wordcellrange.Borders.Enable = 0;
                    wordcellrange.Font.Size = 11;
                    wordtable.Cell(coloumn, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }

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