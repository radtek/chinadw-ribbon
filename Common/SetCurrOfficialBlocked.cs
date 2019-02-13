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
using System.IO;
using System.Windows.Forms;

namespace BSB.Common
{
    public class SetOfficialBlocked
    {
        #region Constructors
        public SetOfficialBlocked()
        {
        }
        #endregion

        public void SetCurrOfficialBlocked(int Blocked, string user_name, out int ErrCode, out string ErrMsg)
        {
            OracleConnection oc = new OracleConnection("Data Source= GRECB; User Id= adm;Password=ADM");            
            try
            {
                
                oc.Open();
                OracleCommand ocmd = new OracleCommand();
                ocmd.Connection = oc;
                ocmd.BindByName = true;
                ocmd.CommandText = "begin"
                                   + " adm.official_pack.set_user_official_blocked(:blocked_, :user_name_, :err_code, :err_msg);"
                                   + "end;";                
                ocmd.Parameters.Add("blocked_", OracleDbType.Int32, Blocked, ParameterDirection.Input);
                ocmd.Parameters.Add("user_name_", OracleDbType.Varchar2, user_name, ParameterDirection.Input);
                ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
                ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
                ocmd.Parameters["err_msg"].Size = 4000;                
                ocmd.ExecuteNonQuery();

                ErrCode = ((OracleDecimal)ocmd.Parameters["err_code"].Value).ToInt32();
                ErrMsg = ocmd.Parameters["err_msg"].Value.ToString();
            }
            finally
            {
                oc.Dispose();
            }
        }
    }
}
