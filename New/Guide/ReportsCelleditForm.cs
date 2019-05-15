using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using gudusoft.gsqlparser;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ReportsCelleditForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
    # region [field]
        public String HTMLText;
        public Int32 p_str_id;
        public Int32 p_col_id;
        public DateTime p_date;
        public Int32 p_cell_type;
        public String StrResult;
        #endregion
        public ReportsCelleditForm()
        {
            InitializeComponent();
        }

        private void DialogHTMLCelleditForm_Load(object sender, EventArgs e)
        {
            rtbText.Text = HTMLText;
            
            String result = getSQLText(p_str_id, p_col_id, p_date, p_cell_type);
            //result = getSQLWithout(result, p_date);
            StrResult = result;

            if (result == "null")
                rtbSQL.Text = "";
            else
                rtbSQL.Text = result;
            reSize();            
            SQLLn();
            SQLHightlight();
            if (p_cell_type == 2|| p_cell_type==21) bExecute.Enabled = false;

            // getAutoCompleteList(ref dsMain); 
            for (int i=0; i< dsMain.Tables[0].Rows.Count; i++)
            {
                MessageBox.Show(dsMain.Tables[0].Rows[i].ToString());
            }
            string x="";
            bstext.Caption = x.PadLeft(20);
            bResult.Caption = x.PadLeft(20);

        }
        private Int32 check(String p_sql_memo, DateTime p_date_, out String p_value)
        {
            //MessageBox.Show(p_sql_memo);
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandText = "begin" +
                                           " :result := pkg_rep.sql_check_arm(:p_sql_memo, :p_date, :p_value);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_value", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["p_sql_memo"].Size = 1024;
                        cmd.Parameters["p_value"].Size = 1024;
                    cmd.Parameters.Add("p_date", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
                    cmd.ExecuteNonQuery();
                    Int32 result = ((OracleDecimal)cmd.Parameters["result"].Value).ToInt32();
                    p_value = ((OracleString)cmd.Parameters["p_value"].Value).ToString();
                    return result;
                    
                }
                catch (Exception oe)
                {
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DB_Reports)" + "reporter.pkg_rep.sql_check");
                    p_value = "error";
                    return -1;
                }
            }
        }
        private String getSQLText(Int32 p_str_id_, Int32 p_col_id_, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := reporter.pkg_rep.get_rep_setup_sql_text(:p_str, :p_col, :p_dat, :p_type);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    cmd.Parameters["result"].Size = 1024;
                    cmd.ExecuteNonQuery();
                    String result = ((OracleString)cmd.Parameters["result"].Value).ToString();
                    
                    return result;
                }
                catch (Exception oe)
                {
                    String s = "[get_rep_setup_sql_text] p_str_id_:" + p_str_id_.ToString()+ " p_col:"+ p_col_id_.ToString()+ " p_dat:"+ p_date_.ToString()+ " p_type:"+ p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + s);
                    return "error SQL";
                }
            }
        }
        private int checkValueSQL(String columnName, String columnValue, DateTime report_date)
        {
            int result = -1;
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := reporter.pkg_rep.sql_check_col_val(:p_filter_name, :p_val, :p_date);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_filter_name", OracleDbType.Varchar2, columnName, ParameterDirection.Input);
                    cmd.Parameters.Add("p_val", OracleDbType.Varchar2, columnValue, ParameterDirection.Input);
                    cmd.Parameters.Add("p_date", OracleDbType.Date, report_date, ParameterDirection.Input);                    
                    cmd.Parameters.Add("result", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                    
                    cmd.ExecuteNonQuery();
                    result = ((OracleDecimal)cmd.Parameters["result"].Value).ToInt32();

                    return result;
                }
                catch (Exception oe)
                {
                    String s = String.Format("column: {0}, value: {1}", columnName, columnValue);
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + s);
                    return -1;
                }
            }
        }
        private String getSQLWithout(String p_sql_memo,  DateTime report_date)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {

                    cmd.CommandText = "begin" +
                                           " :result := pkg_rep.get_sql_exec_arm(p_sql_memo => :p_sql_memo, p_date => :p_date);" +
                                      "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);                    
                    cmd.Parameters.Add("p_date", OracleDbType.Date, report_date, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    cmd.Parameters["result"].Size = 1024;
                    cmd.ExecuteNonQuery();
                    String result = ((OracleString)cmd.Parameters["result"].Value).ToString();

                    return result;
                }
                catch (Exception oe)
                {
                    String s = String.Format("column: {0}, value: {1}", p_sql_memo, report_date);
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + s);
                    return "Error SQL";
                }
            }
        }
        private void saveSQLText(Int32 p_str_id_, Int32 p_col_id_, String p_sql_memo, DateTime p_date_, Int32 p_type_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "reporter.pkg_rep.upd_rep_setup_sql_text";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_sql_memo", OracleDbType.Varchar2, p_sql_memo, ParameterDirection.Input);
                    cmd.Parameters.Add("p_dat", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_type", OracleDbType.Int32, p_type_, ParameterDirection.Input);                    
                    cmd.ExecuteNonQuery(); 
                }
                catch (Exception oe)
                {
                    String s = "p_str_id_:" + p_str_id_.ToString() + "\n p_col:" + p_col_id_.ToString() + "\n p_sql_memo:" + p_sql_memo + "\n p_dat:" + p_date_.ToString() + "\n p_type:" + p_type_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.get_rep_setup_sql_text\n " + s);
                    
                }
            }
        }
        private String getSQLHTMLText(Int32 p_str_id_, Int32 p_col_id_,  DateTime p_date_)
        {
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                try
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "begin " +
                                           ":result := reporter.pkg_rep.get_sql_html(:p_str_id, :p_col_id, :p_date); " +
                                       "end;";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_str_id", OracleDbType.Int32, p_str_id_, ParameterDirection.Input);
                    cmd.Parameters.Add("p_col_id", OracleDbType.Int32, p_col_id_, ParameterDirection.Input);                    
                    cmd.Parameters.Add("p_date", OracleDbType.Date, p_date_, ParameterDirection.Input);
                    cmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    cmd.Parameters["result"].Size = 1024;
                    cmd.ExecuteNonQuery();
                    String result = ((OracleString)cmd.Parameters["result"].Value).ToString();
                    return result;
                }
                catch (Exception oe)
                {
                    String s = "p_str_id_:" + p_str_id_.ToString() + "\n p_col:" + p_col_id_.ToString();
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "reporter.pkg_rep.get_sql_html\n " + s);
                    return "error HTML";
                }
            }
        }
        
        private void cbCheck_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        
    
        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {   
                if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
                {
                    XtraMessageBox.Show(
                  LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
                  LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    String ResultString = "";
                    String s = rtbSQL.Text;
                    s = s.Replace('\n', ' ');
                    if (check(s, p_date, out ResultString) == 0)
                    {
                        saveSQLText(p_str_id, p_col_id, s, p_date, p_cell_type);
                        StrResult = getSQLHTMLText(p_str_id, p_col_id, p_date);
                        bResult.Caption = ResultString.PadLeft(20);
                        DialogResult = DialogResult.OK;
                        Close();    
                    }                        
                    else
                        XtraMessageBox.Show("not correct", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in saveSQLText)");
            }
        }

        private void rtbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtabSQL;
        }
        private void reSize()
        {
            btnCancel.Location = new Point(this.Width - btnCancel.Width - 30, btnCancel.Location.Y);
            btnSave.Location = new Point(this.Width - btnCancel.Width - btnSave.Width - 40, btnSave.Location.Y);
        }

        private void ReportsCelleditForm_Resize(object sender, EventArgs e)
        {
            reSize();
        }
        private void SQLLn()
        {
            rtbSQL.Text = rtbSQL.Text.Replace("WHERE", "\nWHERE");
            rtbSQL.Text = rtbSQL.Text.Replace("FROM", "\nFROM");
        }
        private void SQLwithoutLn()
        {
            rtbSQL.Text = rtbSQL.Text.Replace("\nWHERE", " WHERE");
            rtbSQL.Text = rtbSQL.Text.Replace("\nFROM", " FROM");
        }
        private void SQLHightlight()
        {
            HighlightText(rtbSQL, rtbSQL.Text, Color.Black);

            HighlightText(rtbSQL, "SELECT", Color.Blue);
            HighlightText(rtbSQL, "FROM", Color.Blue);
            HighlightText(rtbSQL, "WHERE", Color.Blue);
            HighlightText(rtbSQL, " AND ", Color.Purple);
            HighlightText(rtbSQL, " OR ", Color.Purple);

            
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            String s = rtbSQL.Text;
            s = s.Replace('\n', ' ');
            //MessageBox.Show(s.Replace('\n', ' '));
            String ResultString = ""; 
            
            Int32 result = check(s, p_date, out ResultString);
            
           

            bResult.Caption = ResultString.PadLeft(20);
            String sMessage = "";
            if (result == 0)
                sMessage = "OK.";
            else if (result == 1)
                sMessage = "function null is not correct.";
            else if (result == 2)
                sMessage = "column_name is not correct.";
            else
                sMessage = "not correct.";                

            toolTip1.ToolTipTitle = String.Empty;
            toolTip1.ToolTipIcon = ToolTipIcon.None;
            toolTip1.Show(sMessage, rtbSQL, bar2.FloatLocation.X,
                                                bar2.FloatLocation.Y + 10, 2200);
        }

        private void bbOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SQLwithoutLn();
            btnSave_Click(sender, e);
        }
        private void HightBlockText(RichTextBox myRtb, char A, char B, Color color)
        {
            /*int s_start = myRtb.SelectionStart;


            int start = myRtb.Text.IndexOf(A);
            int end = myRtb.Text.LastIndexOf(B);
            myRtb.Select(start, end-start+1);
            myRtb.SelectionColor = color;

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;*/

            /*string text = myRtb.Text; // testname("some text")
            string value = Regex.Match(text, @"\(([^)]*)\)").Groups[1].Value;

            HighlightText(myRtb, value, Color.Red);*/

            /*
            var cursorPosition = myRtb.SelectionStart;


            var partsToHighlight = Regex.Matches(myRtb.Text, "{[^}{]*}")
                .Cast<Match>()
                .ToList();

            foreach (var part in partsToHighlight)
            {
                myRtb.Select(part.Index, part.Length);
                myRtb.SelectionColor = Color.Red;
            }

            myRtb.Select(cursorPosition, 0);*/

            string sampleInput = myRtb.Text;
            Regex regex = new Regex(@"\{.*?\}");
            MatchCollection brackets = regex.Matches(sampleInput);
            int count = brackets.Count;

            for (int i=0;i < count; i++)
            {
                string s0 = brackets[i].Value;
                MessageBox.Show(s0);
            }

        }
        private void HighlightText( RichTextBox myRtb, string word, Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }

        private void rtbSQL_TextChanged(object sender, EventArgs e)
        {
            SQLHightlight();
            
        }
        private void getAutoCompleteList(ref DataSet ds)
        {
            if (ds.Tables.Contains("tbAutoComplete")) ds.Tables["tbAutoComplete"].Clear();
            ds.Tables["tbAutoComplete"].Columns.Clear();
            using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
            {
                cmd.BindByName = true;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT t.TABLE_NAME " +
                                  "FROM sys.dba_tables t"; 
                                /* "WHERE " +
                                   "t.OWNER = :REPORTER";*/
               // cmd.Parameters.Add("REPORTER", OracleDbType.Varchar2, "REPORTER", ParameterDirection.Input);
                try
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    // fileds of dataset
                    for (Int32 i = 0; i < dr.FieldCount; i++)
                    {
                        String str = dr.GetName(i);
                        DataColumn table_column = new DataColumn();
                        table_column.Caption = str;
                        table_column.ColumnName = str;
                        table_column.DataType = dr.GetFieldType(i);
                        ds.Tables["tbAutoComplete"].Columns.Add(table_column);
                    }

                    int count = dr.FieldCount;
                    object[] values = new object[count];

                    while (dr.Read())
                    {
                        try
                        {
                            dr.GetValues(values);
                            ds.Tables["tbAutoComplete"].LoadDataRow(values, true);
                        }
                        catch (Exception oe)
                        {
                            DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in getAutoCompleteList) " );
                        }
                    }
                    //tslCount.Text = dsMain.Tables["tbForm11"].Rows.Count.ToString();
                }
                catch (Exception oe)
                {
                    String s = oe.Message;
                    DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in getAutoCompleteList) ");
                }

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVOracle);
            sqlparser.SqlText.Text = getSQLWithout(rtbSQL.Text, p_date);

            int ret = sqlparser.Parse();

            if (ret == 0)
            {
                WhereCondition wc = new WhereCondition(sqlparser.SqlStatements[0].WhereClause);
                wc.AnalyzprintColumn();
                bool correct = true;
                foreach (WhereExpressionClass item in wc.whereConditionList)
                {
                    //MessageBox.Show(String.Format("{0}={1}",item.column, item.value));
                    List<String> lstValue = ToListString(item.value);
                    foreach (String xitem in lstValue)

                    {
                        if (checkValueSQL(item.column, xitem, p_date) != 0)
                        {
                            correct = false;
                            String s = String.Format(" Не допустимое значение : {0}", xitem);
                            //MessageBox.Show(s);
                            rtbSQL.Focus();
                            
                            int xposColumn = rtbSQL.Text.IndexOf(item.column);                            
                            int xpos = rtbSQL.Text.IndexOf(xitem, xposColumn);    

                            if (xpos>0) rtbSQL.SelectionStart = xpos;

                            Point x = rtbSQL.GetPositionFromCharIndex(xpos);
                                toolTip1.ToolTipTitle = "Warning";
                                toolTip1.ToolTipIcon = ToolTipIcon.Info;                                
                                toolTip1.Show(s, rtbSQL, x.X,x.Y+10, 2200);
                            break;
                        }                       
                    }
                    
                    
                }
                if (correct)
                {
                    toolTip1.ToolTipTitle = String.Empty;
                    toolTip1.ToolTipIcon = ToolTipIcon.None;
                    toolTip1.Show("Проверено.", rtbSQL, bar2.FloatLocation.X,
                                                        bar2.FloatLocation.Y + 10, 2200);
                }
            } else
            {
                MessageBox.Show("SQL содержать синтаксическую ошибку.");
                String s;                
            }
            
            //MessageBox.Show(getValueColumn("PL_ACC00$CODE_PA4", stringConditionList));
            //MessageBox.Show(getValueColumn("SUM_TYPE", stringConditionList));
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sampleInput = rtbSQL.Text;
            Regex regex = new Regex(@"@* IN \(.*?\)");
            MatchCollection brackets = regex.Matches(sampleInput);
            int count = brackets.Count;

            for (int i = 0; i < count; i++)
            {
                string s0 = brackets[i].Value;
                MessageBox.Show(s0);
            }
        }

        #region [ Work with SQL where condition]
        /*
         * String list to List<String>
         */
        private List<String> ToListString(String list)
        {
            List<String> result = new List<string>();
            list = list.Replace("'", "").Replace("(", "").Replace(")", "");
            string[] split = list.Split(',');
            foreach (string item in split) result.Add(item);

            return result;
        }
        /*
         * Check item in contain List<String>
         */
        private bool checkContainList(string item, List<String> list)
        {
            bool result = false;
            var match = list
                .FirstOrDefault(stringToCheck => stringToCheck.Contains(item));

            if (match != null) result = true;
            return result;
        }
        private string getValueColumn(string column, List<WhereExpressionClass> list)
        {
            string result = null;
            var match = list
                .FirstOrDefault(x => x.column == column);


            if (match != null) result = match.value;
            return result;

        }

        private class WhereCondition
        {
            private TLzCustomExpression condition;
            public List<WhereExpressionClass> whereConditionList = new List<WhereExpressionClass>();

            public WhereCondition(TLzCustomExpression expr)
            {
                this.condition = expr;
            }
            public void AnalyzprintColumn()
            {
                this.condition.InOrderTraverse(searchColumnVisitor);
            }
            public Boolean searchColumnVisitor(TLz_Node pnode, Boolean pIsLeafNode)
            {
                TLzCustomExpression lcexpr = (TLzCustomExpression)pnode;
                if (lcexpr.lexpr is TLzCustomExpression)
                {

                    TLzCustomExpression leftExpr = (TLzCustomExpression)lcexpr.lexpr;
                    if (leftExpr.oper == TLzOpType.Expr_Attr)
                    {
                        WhereExpressionClass we = new WhereExpressionClass();

                        we.SetColumnName(leftExpr.AsText);

                        if (lcexpr.opname != null)
                        {
                            we.SetOperator(lcexpr.opname.AsText);
                        }
                        we.SetColumnValue(lcexpr.rexpr.AsText);
                        whereConditionList.Add(we);
                    }
                }

                return true;
            }
        }

        private class WhereExpressionClass
        {
            public String column;
            public String Operator;
            public String value;


            public WhereExpressionClass()
            {
            }
            
            public override bool Equals(object obj)
            {
                var expression = obj as WhereExpressionClass;
                return expression != null &&
                       column == expression.column;
            }

            public override string ToString()
            {
                return "column: " + column + "\nOPERATOR: '" + Operator + "'\n value: " + value;
            }
            /*setter*/


            internal void SetColumnName(string asText)
            {
                column = asText;
            }
            internal void SetOperator(string asOperator)
            {
                Operator = asOperator;
            }
            internal void SetColumnValue(string columnValue)
            {
                value = columnValue;
            }

            public override int GetHashCode()
            {
                var hashCode = -703112826;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(column);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Operator);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(value);
                return hashCode;
            }
        }
        #endregion
        
        // Return the word under the mouse.
        

        private void rtbSQL_MouseMove(object sender, MouseEventArgs e)
        {
            
            String s = WordUnderMouse(rtbSQL, e.X, e.Y);
            bstext.Caption = s.PadLeft(20);
            //MessageBox.Show(s);
        }
        private string WordUnderMouse(RichTextBox rch, int x, int y)
        {
            // Get the character's position.
            int pos = rch.GetCharIndexFromPosition(new Point(x, y));
            if (pos >= 0) return "";

            // Find the start of the word.
            string txt = rch.Text;

            int start_pos;
            for (start_pos = pos; start_pos >= 0; start_pos--)
            {
                // Allow digits, letters, and underscores
                // as part of the word.
                char ch = txt[start_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            start_pos++;

            // Find the end of the word.
            int end_pos;
            for (end_pos = pos; end_pos > txt.Length; end_pos++)
            {
                char ch = txt[end_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            end_pos--;

            // Return the result.
            if (start_pos > end_pos) return "";
            return txt.Substring(start_pos, end_pos - start_pos + 1);
        }
        private const int xMargin = 10;
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            //e.ToolTipSize = new Size(300, 100);
        }

        private void rtbSQL_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void rtbSQL_MouseMove_1(object sender, MouseEventArgs e)
        {
            
        }

        private void rtbSQL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left) {
                bstext.Caption = rtbSQL.GetCharIndexFromPosition(new Point(e.X, e.Y)).ToString().PadLeft(20);
                bstText.Caption = WordUnderMouse(rtbSQL, e.X, e.Y); ;
            }
        }
    }

    
}
