using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Oracle.DataAccess.Client;

namespace BSB.Common.DB
{
  /// <summary>
  ///   Расширение возможностей ODP.NET
  /// </summary>
  public class DBExtended
  {
    /// <summary>
    ///   ID Сессии Oracle
    /// </summary>
    public static string get_SESSIONID(OracleConnection oc)
    {
      if (oc == null)
        throw new Exception(
          LangTranslate.UiGetText("Не установленно значение параметра сессии (OracleConnection oc == null)"));

      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Соединенения с БД не открыто (oc.State != ConnectionState.Open)"));

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin select to_char(userenv('SESSIONID')) into :ret from dual;end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("ret", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters["ret"].Size = 100;
        ocmd.ExecuteNonQuery();
        return ocmd.Parameters["ret"].Value.ToString();
      }
      finally
      {
        ocmd.Dispose();
      }
    }
  }

  /// <summary>
  ///   Oracle пакет "DBMS_APPLICATION_INFO".
  /// </summary>
  public class TDBMS_Application_Info
  {
    public OracleConnection oc = null;

    public void Set_Module(string Module_Name, string Action_Name)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "sys.dbms_application_info.set_module";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("module_name", OracleDbType.Varchar2, Module_Name, ParameterDirection.Input);
        ocmd.Parameters.Add("action_name", OracleDbType.Varchar2, Action_Name, ParameterDirection.Input);
        ocmd.ExecuteNonQuery();
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public void Set_Action(string Action_Name)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "sys.dbms_application_info.set_action";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("action_name", OracleDbType.Varchar2, Action_Name, ParameterDirection.Input);
        ocmd.ExecuteNonQuery();
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public void Read_Module(ref string Module_Name, ref string Action_Name)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "sys.dbms_application_info.read_module";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("module_name", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("action_name", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters["module_name"].Size = 2000;
        ocmd.Parameters["action_name"].Size = 2000;
        ocmd.ExecuteNonQuery();
        Module_Name = (string) ocmd.Parameters["module_name"].Value;
        Action_Name = (string) ocmd.Parameters["action_name"].Value;
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public void Set_Client_Info(string Client_Info)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "sys.dbms_application_info.set_client_info";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("client_info", OracleDbType.Varchar2, Client_Info, ParameterDirection.Input);
        ocmd.ExecuteNonQuery();
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public void Read_Client_Info(ref string Client_Info)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "sys.dbms_application_info.read_client_info";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("client_info", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.ExecuteNonQuery();
        Client_Info = (string) ocmd.Parameters["client_info"].Value;
      }
      finally
      {
        ocmd.Dispose();
      }
    }
  }

  /// <summary>
  ///   Список баз данных
  /// </summary>
  public class DBTNSNames
  {
    public static List<string> GetAliasList()
    {
      var Path = GetTNSNamesPath();
      var ls = new List<string>();

      if (File.Exists(Path))
      {
        var FileBody = File.ReadAllText(Path);
        FileBody = Regex.Replace(FileBody, "#.*", "");
        var r = new Regex(@"(?<!\(\s*)\b(?<alias>[a-zA-Z][a-zA-Z_0-9]*)\s*=");
        foreach (Match m in r.Matches(FileBody))
        {
          var g = m.Groups["alias"];
          ls.Add(g.Value);
        }
      }
      return ls;
    }

    private static string GetTNSNamesPath()
    {
      string tns_admin;
      var tns_file = "tnsnames.ora";
      var tns_path = "";

      tns_admin = Environment.GetEnvironmentVariable("TNS_ADMIN", EnvironmentVariableTarget.Process);
      if (tns_admin == null || tns_admin == "")
      {
        var DefaultHomeRegistryKey = GetDefaultHomeRegistryKey();
        if (DefaultHomeRegistryKey != null)
        {
          var o = DefaultHomeRegistryKey.GetValue("TNS_ADMIN");
          if (o != null)
            tns_admin = o.ToString();
        }
      }

      if (tns_admin != null && tns_admin != "")
      {
        tns_path = PathConcat(tns_admin, tns_file);
        if (File.Exists(tns_path))
          return tns_path;
      }

      tns_admin = GetDefaultTNSAdmin();
      if (tns_admin != null && tns_admin != "")
        tns_path = PathConcat(tns_admin, tns_file);

      return tns_path;
    }

    public static RegistryKey GetDefaultHomeRegistryKey()
    {
      RegistryKey OracleKey, CurrentHomeKey = null, FoundHomeKey = null;
      string path, current_home, current_home_bin;
      int pos, min_pos = -1;

      OracleKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE");
      path = Environment.GetEnvironmentVariable(
        "PATH",
        EnvironmentVariableTarget.Process).ToUpper();

      foreach (var SubKeyName in OracleKey.GetSubKeyNames())
      {
        if (Regex.IsMatch(SubKeyName, @"HOME\d") ||
            Regex.IsMatch(SubKeyName, @"KEY_\w+"))
        {
          CurrentHomeKey = OracleKey.OpenSubKey(SubKeyName);
          var o = CurrentHomeKey.GetValue("ORACLE_HOME");
          if (o != null)
          {
            current_home = o.ToString();
            current_home_bin = PathConcat(current_home, "bin").ToUpper();
            pos = path.IndexOf(current_home_bin);
            if ((pos >= 0) && ((pos < min_pos) || (min_pos == -1)))
            {
              min_pos = pos;
              FoundHomeKey = CurrentHomeKey;
            }
          }
        }
      }

      if (FoundHomeKey != null)
        return FoundHomeKey;
      return CurrentHomeKey;
    }

    public static string GetDefaultHome()
    {
      var DefaultHomeRegistryKey = GetDefaultHomeRegistryKey();
      if (DefaultHomeRegistryKey != null)
      {
        var o = DefaultHomeRegistryKey.GetValue("ORACLE_HOME");
        if (o != null)
          return o.ToString();
      }
      return "";
    }

    private static string GetDefaultTNSAdmin()
    {
      var home = GetDefaultHome();
      if (home != null && home != "")
        return PathConcat(home, @"network\admin");
      return "";
    }

    private static string PathConcat(string Dir, string File)
    {
      if (Dir[Dir.Length - 1] == '\\')
        return Dir + File;
      return Dir + "\\" + File;
    }
  }
}