using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BSB.Common.DB
{
  public class AppSetup
  {
    public Byte[] FileBody;
    public string FileName;
    public string Version;
  }

  /// <summary>
  ///   Автоматическая установка
  /// </summary>
  public class DBSetup
  {
    public OracleConnection oc = null;

    public List<AppSetup> ReadSetupList(int errCode, string errMsg)
    {
      var list = new List<AppSetup>();
      using (var ocmd = oc.CreateCommand())
      {
        try
        {
          ocmd.CommandText = "main.pkg_app.get_app_version";
          ocmd.CommandType = CommandType.StoredProcedure;
          ocmd.BindByName = true;
          ocmd.Parameters.Add("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
          ocmd.Parameters.Add("p_version", Application.ProductVersion);
          ocmd.Parameters.Add("p_arm_id", OracleDbType.Int32, 2, ParameterDirection.Input);
          ocmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
          ocmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

          var da = new OracleDataAdapter(ocmd);
          var cur = new DataSet();
          da.Fill(cur, "cur");
          var dt = cur.Tables["cur"];

          errCode = ((OracleDecimal) ocmd.Parameters["p_err_code"].Value).ToInt32();
          errMsg = ocmd.Parameters["p_err_msg"].Value.ToString();
          if (errCode != 0)
            return null;

          foreach (DataRow dr in dt.Rows)
            list.Add(new AppSetup {Version = dr["VER"].ToString(), FileBody = (Byte[]) dr["SETUP_FILE"]});
        }
        catch (Exception ex)
        {
          var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
          if (rethrow)
            throw;
        }
        return list;
      }
    }
  }
}