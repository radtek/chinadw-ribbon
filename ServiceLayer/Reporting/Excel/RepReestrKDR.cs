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

/*
 Author: Nurlan Ryskeldi (36)
 */
namespace ARM_User.ServiceLayer.Reporting
{
    public class RepReestrKDR : ReportToExcel
    {
        protected RepForm form;
        protected LanguageIds language;
        protected string firstName, lastName;
        protected string  Name_Emit1_, Code1_, Oblast1_, Address1_, OKPO1_, Registr_Jur1_, Reg_Num1_, Name_Sts1_, Date_Reg1_, Num1_, Num_Serial1_, Form_Vyp1_, Term_Circulation1_,
                          Price_Placement1_, Placement_Sts1_, User_Name1_, Pay_Agent1_, Underrider1_, Emitent1_, Country1_, Pay_Agent2_, KNDANDCATEGORYBASEACTIV1_;
        protected string Date_Placement_E1_, Srok_Obr1_, Amount_Placement1_, Amount_Placement_TG1_, Price_R1_;
        protected decimal Id_KDR;
        protected Decimal languageId;

        public RepReestrKDR(RepForm form, LanguageIds language, decimal Id_KDR)
           // : base(form, language)
        {
            this.form = form;
            this.language = language;
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
             
                if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                {
                    var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                    var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                    if (errCode != 0)
                        throw new OraCustomException(errCode, errMsg);
                }
                return "";/*((OracleString)cmd.Parameters["Name_Emit_"].Value).Value;
                return ((OracleString)cmd.Parameters["Code_"].Value).Value;
                return ((OracleString)cmd.Parameters["Oblast_"].Value).Value;
                return ((OracleString)cmd.Parameters["Address_"].Value).Value;
                return ((OracleString)cmd.Parameters["OKPO_"].Value).Value;
                return ((OracleString)cmd.Parameters["Registr_Jur_"].Value).Value;
                return ((OracleString)cmd.Parameters["Reg_Num_"].Value).Value;

                return ((OracleString)cmd.Parameters["Name_Sts_"].Value).Value;
                return ((OracleString)cmd.Parameters["Date_Reg_"].Value).Value;
                return ((OracleString)cmd.Parameters["Num_"].Value).Value;
                return ((OracleString)cmd.Parameters["Num_Serial_"].Value).Value;
                return ((OracleString)cmd.Parameters["Form_Vyp_"].Value).Value;
                return ((OracleString)cmd.Parameters["Term_Circulation_"].Value).Value;
                return ((OracleString)cmd.Parameters["Price_Placement_"].Value).Value;

                return ((OracleString)cmd.Parameters["Placement_Sts_"].Value).Value;
                return ((OracleString)cmd.Parameters["Date_Placement_E_"].Value).Value;
                return ((OracleString)cmd.Parameters["Amount_Placement_"].Value).Value;
                return ((OracleString)cmd.Parameters["Amount_Placement_TG_"].Value).Value;
                return ((OracleString)cmd.Parameters["User_Name_"].Value).Value;
                return ((OracleString)cmd.Parameters["Pay_Agent_"].Value).Value;
                return ((OracleString)cmd.Parameters["Underrider_"].Value).Value;

                return ((OracleString)cmd.Parameters["Emitent_"].Value).Value;
                return ((OracleString)cmd.Parameters["Country_"].Value).Value;
                return ((OracleString)cmd.Parameters["Pay_Agent1_"].Value).Value;
                return ((OracleString)cmd.Parameters["KNDANDCATEGORYBASEACTIV_"].Value).Value;
                return ((OracleString)cmd.Parameters["Srok_Obr_"].Value).Value;
                return ((OracleString)cmd.Parameters["Price_R_"].Value).Value;*/
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
        
        protected virtual void CreateReportFromXml()
        {
            BeginFillReport();

            try
            {
                var path = SaveTemplateFile(form.GetTemplate(language));

                var wb = appExcel.Workbooks.Add(path);

                var ws = wb.Worksheets[1] as Worksheet;

                Range rngData = ws.get_Range("DATA", Type.Missing) as Range;
                Range rngDataRow = rngData.Rows[rngData.Rows.Count, Type.Missing] as Range;

                var rngBelowDataRow = ws.Rows[rngDataRow.Row, Type.Missing] as Range;

                GetData();
                //ws.Range["A2"].Font.Bold = true;

                //"Форма А-17. Сведения об акционерных инвестиционных фондах по состоянию на " + Name_Emit1_ + " года.";

                /*  ws.Range["A5"].Value = Name_Emit1_;
                    ws.Range["F5"].Value = Code1_;
                    ws.Range["B7"].Value = Oblast1_;
                    ws.Range["D7"].Value = Address1_;
                    ws.Range["F7"].Value = OKPO1_;
                    ws.Range["B8"].Value = Registr_Jur1_;
                    ws.Range["F8"].Value = Reg_Num1_;
                    ws.Range["B9"].Value = Name_Sts1_;
                    ws.Range["B10"].Value = Date_Reg1_;
                    ws.Range["F10"].Value = Num1_;
                    ws.Range["B11"].Value = Num_Serial1_;
                    ws.Range["D11"].Value = Form_Vyp1_;
                    ws.Range["B12"].Value = Term_Circulation1_;
                    ws.Range["D12"].Value = Price_Placement1_;
                    ws.Range["B13"].Value = Placement_Sts1_;
                    ws.Range["E13"].Value = Date_Placement_E1_;
                    ws.Range["C14"].Value = Amount_Placement1_;
                    ws.Range["E14"].Value = Amount_Placement_TG1_;
                    ws.Range["B15"].Value = User_Name1_;
                    ws.Range["B17"].Value = Pay_Agent1_;
                    ws.Range["B18"].Value = Underrider1_;
                    ws.Range["B29"].Value = Emitent1_;
                    ws.Range["B30"].Value = Country1_;
                    ws.Range["B31"].Value = Pay_Agent2_;
                    ws.Range["C32"].Value = KNDANDCATEGORYBASEACTIV1_;
                    ws.Range["B33"].Value = Srok_Obr1_;
                    ws.Range["D33"].Value = Price_R1_;*/
                if (language == LanguageIds.Russian)
                {
                    ws.Range["A4"].Value = Name_Emit1_;
                    ws.Range["F4"].Value = " " + Code1_;
                    ws.Range["A6"].Value = "Область  " + Oblast1_;
                    ws.Range["C6"].Value = "Адрес  " + Address1_;
                    ws.Range["F6"].Value = " " + OKPO1_;
                    ws.Range["A7"].Value = "Регистрацию ЮЛ  " + Registr_Jur1_;
                    ws.Range["F7"].Value = " " + Reg_Num1_;
                    ws.Range["A8"].Value = "Статус эмитента:  " + Name_Sts1_;
                    ws.Range["A9"].Value = "Выпуск зарегистрирован  " + Date_Reg1_;
                    ws.Range["F9"].Value = " " + Num1_;
                    ws.Range["A10"].Value = "Порядковый номер выпуска  " + Num_Serial1_;
                    ws.Range["D10"].Value = " " + Form_Vyp1_;
                    ws.Range["A11"].Value = "Срок обращения  " + Term_Circulation1_;
                    ws.Range["D11"].Value = " " + Price_Placement1_;
                    ws.Range["A12"].Value = "Состояние размещения  " + Placement_Sts1_;
                    ws.Range["E12"].Value = " " + Date_Placement_E1_;
                    ws.Range["A13"].Value = "Объем размещения КДР по утвержденным  " + Amount_Placement1_;
                    ws.Range["E13"].Value = " " + Amount_Placement_TG1_;
                    ws.Range["A14"].Value = "Выпуск регистрировал  " + User_Name1_;
                    ws.Range["B16"].Value = Pay_Agent1_;
                    ws.Range["B17"].Value = Underrider1_;
                    ws.Range["A28"].Value = "Эмитент  " + Emitent1_;
                    ws.Range["A29"].Value = "Страна  " + Country1_;
                    ws.Range["A30"].Value = "Платежный агент  " + Pay_Agent2_;
                    ws.Range["A31"].Value = "Вид  и категория базового актива  " + KNDANDCATEGORYBASEACTIV1_;
                    ws.Range["A32"].Value = "Срок обращения  " + Srok_Obr1_;
                    ws.Range["D32"].Value = " " + Price_R1_;
                }
                else if (language == LanguageIds.Kazakh)
                {
                    ws.Range["A4"].Value = "Атауы  " + Name_Emit1_;
                    ws.Range["F4"].Value = "  " + Code1_;
                    ws.Range["A5"].Value = "Обласы  " + Oblast1_;
                    ws.Range["C5"].Value = "Мекен-жайы  " + Address1_;
                    ws.Range["F5"].Value = "  " + OKPO1_;
                    ws.Range["A6"].Value = "ЗТ тіркеу  " + Registr_Jur1_;
                    ws.Range["F6"].Value = "  " + Reg_Num1_;
                    ws.Range["A7"].Value = "Эмитента жағдайы:  " + Name_Sts1_;
                    ws.Range["A8"].Value = "Шығарылым тіркелінді  " + Date_Reg1_;
                    ws.Range["F8"].Value = "  " + Num1_;
                    ws.Range["A9"].Value = "Шығарылымның реттік нөмірі  " + Num_Serial1_;
                    ws.Range["D9"].Value = "  " + Form_Vyp1_;
                    ws.Range["A10"].Value = "Айналыс мерзімі  " + Term_Circulation1_;
                    ws.Range["D10"].Value = "  " + Price_Placement1_;
                    ws.Range["A11"].Value = "Орналастырудың жай-күйі  " + Placement_Sts1_;
                    ws.Range["E11"].Value = "  " + Date_Placement_E1_;
                    ws.Range["A12"].Value = "ҚДҚ орналастыру көлемі бекітілген  " + Amount_Placement1_;
                    ws.Range["E12"].Value = "  " + Amount_Placement_TG1_;
                    ws.Range["A13"].Value = "Шығарылымды тіркеген  " + User_Name1_;
                    ws.Range["B15"].Value = Pay_Agent1_;
                    ws.Range["B16"].Value = Underrider1_;
                    ws.Range["A27"].Value = "Эмитент  " + Emitent1_;
                    ws.Range["A28"].Value = "Елі " + Country1_;
                    ws.Range["A29"].Value = "Төлемді агенттің атауы  " + Pay_Agent2_;
                    ws.Range["A30"].Value = "Вид  и категория базового актива  " + KNDANDCATEGORYBASEACTIV1_;
                    ws.Range["A31"].Value = "Айналыс мерзімі  " + Srok_Obr1_;
                    ws.Range["D31"].Value = "  " + Price_R1_;
                }


                System.Data.DataTable dt = GetCursor();


                int rowIndex = 1;

                Console.WriteLine(dt.Rows.GetType());

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    rngBelowDataRow.Copy();
                    (rngDataRow.Rows[rowIndex, Type.Missing] as Range).PasteSpecial(XlPasteType.xlPasteFormats,
                      XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    (rngDataRow.Cells[rowIndex, 1] as Range).Value2 = dt.Rows[i]["KND_CB"].ToString();
                    (rngDataRow.Cells[rowIndex, 2] as Range).Value2 = dt.Rows[i]["CNT"].ToString();
                    (rngDataRow.Cells[rowIndex, 3] as Range).Value2 = dt.Rows[i]["NIN"].ToString();
                    (rngDataRow.Cells[rowIndex, 4] as Range).Value2 = dt.Rows[i]["COMMENTS"].ToString();
                    (rngDataRow.Cells[rowIndex, 5] as Range).Value2 = dt.Rows[i]["DATE_REG"].ToString();

                    rowIndex++;
                }

            }
            finally
            {
                EndFillReport();
            }
        }

        private System.Data.DataTable Getcursor()
        {
            throw new NotImplementedException();
        }


        public override void ShowReport()
        {
            CreateReportFromXml();
        }
    }
}