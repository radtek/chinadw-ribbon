using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace BSB.Common.DB.Admin
{
  /// <summary>
  ///   Пакет в схеме ADM: OFFICIAL_PACK.
  /// </summary>
  public class TPkgOfficial
  {
    public OracleConnection oc;

    public TPkgOfficial()
    {
      oc = dmControler.frmMain.oracleConnection;
    }

    public DateTime GetUserPasswordChangeDate(string user_name, out int ErrCode, out string ErrMsg)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin" +
                           " :result := adm.official_pack.get_user_password_change_date(:user_name_, :err_code, :err_msg);" +
                           "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("user_name_", OracleDbType.Varchar2, user_name, ParameterDirection.Input);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("result", OracleDbType.Date, ParameterDirection.ReturnValue);
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        ErrCode = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        ErrMsg = ocmd.Parameters["err_msg"].Value.ToString();

        return ((OracleDate) ocmd.Parameters["result"].Value).Value;
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public void SetCurrOfficialBlocked(int Blocked, out int ErrCode, out string ErrMsg)
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin"
                           + " adm.official_pack.set_curr_official_blocked(:blocked_, :err_code, :err_msg);"
                           + "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("blocked_", OracleDbType.Int32, Blocked, ParameterDirection.Input);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        ErrCode = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        ErrMsg = ocmd.Parameters["err_msg"].Value.ToString();
      }
      finally
      {
        ocmd.Dispose();
      }
    }

    public DateTime GetServerTime()
    {
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin"
                           + " :result := adm.official_pack.get_server_time;"
                           + "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("result", OracleDbType.Date, ParameterDirection.ReturnValue);
        ocmd.ExecuteNonQuery();

        return ((OracleDate) ocmd.Parameters["result"].Value).Value;
      }
      finally
      {
        ocmd.Dispose();
      }
    }
    public Int32 GetIdUserChangePassword()
    {
        var ocmd = oc.CreateCommand();
        try
        {
            ocmd.CommandText = "begin"
                               + " :result := adm.official_pack.Get_Id_User_Change_Password;"
                               + "end;";
            ocmd.BindByName = true;            
            ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
            ocmd.ExecuteNonQuery();

            return ((OracleDecimal)ocmd.Parameters["result"].Value).ToInt32();
        }
        finally
        {
            ocmd.Dispose();
        }
    }

    public Int32 GetOfficial(out string Name, out Int32 err_code, out string err_msg)
    {
      var iResult = 0;
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin"
                           + " :result := adm.official_pack.get_official(:name_, :err_code, :err_msg);"
                           + "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("name_", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
        ocmd.Parameters["name_"].Size = 1000;
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        Name = ocmd.Parameters["name_"].Value.ToString();
        err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        iResult = ((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32();
      }
      finally
      {
        ocmd.Dispose();
      }

      return iResult;
    }

    public Int32 IsUserOfficial(out Int32 err_code, out string err_msg)
    {
      var iResult = 0;
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin"
                           + " :result := adm.official_pack.is_user_official(:err_code, :err_msg);"
                           + "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        iResult = ((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32();
      }
      finally
      {
        ocmd.Dispose();
      }

      return iResult;
    }
  }

  /// <summary>
  ///   Пакет в схеме ADM: PARAMS.
  /// </summary>
  public class TPkgParams
  {
    public OracleConnection oc = null;

    /// <summary>
    ///   Возвращает значение параметра из таблицы SYSTEM_SETUP по коду
    /// </summary>
    public string GetSystemSetupParam(string setup_code)
    {
      var strResult = "";
      var ocmd = oc.CreateCommand();
      try
      {
        try
        {
          ocmd.CommandText = "begin"
                             + " :result := adm.params.get_system_setup_param(:setup_code_);"
                             + "end;";
          ocmd.BindByName = true;
          ocmd.Parameters.Add("setup_code_", OracleDbType.Varchar2, setup_code, ParameterDirection.Input);
          ocmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
          ocmd.Parameters["result"].Size = 1000;
          ocmd.ExecuteNonQuery();

          strResult = ocmd.Parameters["result"].Value.ToString();
        }
        finally
        {
          ocmd.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in TPkgParams.GetSystemSetupParam).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in TPkgParams.GetSystemSetupParam).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return strResult;
    }
    //--- Перевод панель сообщений
    public void Set_Panel_Local_Text(Int32 is_lang, out Int32 err_code, out string err_msg)
    {
        err_code = 0;
        err_msg = String.Empty;
        var ocmd = oc.CreateCommand();
        try
        {
            ocmd.CommandText = "G_Set_Panel_Local_Text";
            ocmd.CommandType = CommandType.StoredProcedure;
            ocmd.BindByName = true;
            ocmd.Parameters.Add("Is_Lang_", OracleDbType.Int32, is_lang, ParameterDirection.Input);
            ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
            ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
            ocmd.Parameters["err_msg"].Size = 4000;
            ocmd.ExecuteNonQuery();

            err_code = ((OracleDecimal)ocmd.Parameters["err_code"].Value).ToInt32();
            err_msg = ocmd.Parameters["err_msg"].Value.ToString();
            if (err_code != 0)
                return;
        }
        finally
        {
            ocmd.Dispose();
        }
    }
    public void GetLoadSetTimesParametrs(Int32 is_current, out string minut, out string hours, out string day, out DateTime dateset, Int32 idkind, out decimal err_code, out string err_msg)
    {
        err_code = 0;
        minut = null;
        hours = null;
        day = null;        
        dateset = new DateTime(1900, 1, 1); ;
        err_msg = String.Empty;        
        var ocmd = oc.CreateCommand();
        try
        {
            ocmd.CommandText = "G_Get_Set_Times";
            ocmd.CommandType = CommandType.StoredProcedure;
            ocmd.BindByName = true;
            ocmd.Parameters.Add("Id_Kind_", OracleDbType.Int32, idkind, ParameterDirection.Input);
            ocmd.Parameters.Add("Is_Current_", OracleDbType.Int32, is_current, ParameterDirection.Input);
            ocmd.Parameters.Add("Minut_", OracleDbType.Varchar2, ParameterDirection.Output);
            ocmd.Parameters.Add("Hours_", OracleDbType.Varchar2, ParameterDirection.Output);
            ocmd.Parameters.Add("Day_", OracleDbType.Varchar2, ParameterDirection.Output);
            ocmd.Parameters.Add("DateSet_", OracleDbType.Date, ParameterDirection.Output);           
            ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
            ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
            ocmd.Parameters["err_msg"].Size = 4000;
            ocmd.Parameters["Minut_"].Size = 4000;
            ocmd.Parameters["Hours_"].Size = 4000;
            ocmd.Parameters["Day_"].Size = 4000;
            ocmd.ExecuteNonQuery();

            err_code = ((OracleDecimal)ocmd.Parameters["err_code"].Value).ToInt32();
            err_msg = ocmd.Parameters["err_msg"].Value.ToString();
            if (err_code != 0)
                return;
            minut = ((OracleString)ocmd.Parameters["Minut_"].Value).ToString();
            hours = ((OracleString)ocmd.Parameters["Hours_"].Value).ToString();
            day = ((OracleString)ocmd.Parameters["Day_"].Value).ToString();
            dateset = ((OracleDate)ocmd.Parameters["DateSet_"].Value).Value;
           // idkind = ((OracleDecimal)ocmd.Parameters["Id_Kind_"].Value).ToInt32();

        }
        finally
        {
            ocmd.Dispose();
        }
    }
      //------------
  }

  /// <summary>
  ///   Пакет в схеме ADM: COMPUTER_PACK.
  /// </summary>
  public class TPkgComputer
  {
    public OracleConnection oc = null;
   
    /// <summary>
    ///   Проверяет регистрацию компьютера в БД
    /// </summary>
    public Int32 IsCompRegistered(string computer_name,
      Int32 os_platform_id,
      Int32 os_major_ver,
      Int32 os_minor_ver,
      Int32 os_build_number,
      Int32 cpu_amount,
      Int32 cpu_type,
      Int32 fixed_drives,
      Int32 disk_c_ser_num,
      out Int32 computer,
      out Int32 err_code,
      out string err_msg)
    {
      var Result = 0;
      computer = 0;
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText =
          "begin" +
          "  :result := adm.computer_pack.is_comp_registered(:computer_name_," +
          "	:os_platform_id_," +
          "	:os_major_ver_," +
          "	:os_minor_ver_," +
          "	:os_build_number_," +
          "	:cpu_amount_," +
          "	:cpu_type_," +
          "	:fixed_drives_," +
          "	:disk_c_ser_num_," +
          "	:computer_," +
          "	:err_code," +
          "	:err_msg);" +
          "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("computer_name_", OracleDbType.Varchar2, computer_name, ParameterDirection.Input);
        ocmd.Parameters.Add("os_platform_id_", OracleDbType.Int32, os_platform_id, ParameterDirection.Input);
        ocmd.Parameters.Add("os_major_ver_", OracleDbType.Int32, os_major_ver, ParameterDirection.Input);
        ocmd.Parameters.Add("os_minor_ver_", OracleDbType.Int32, os_minor_ver, ParameterDirection.Input);
        ocmd.Parameters.Add("os_build_number_", OracleDbType.Int32, os_build_number, ParameterDirection.Input);
        ocmd.Parameters.Add("cpu_amount_", OracleDbType.Int32, cpu_amount, ParameterDirection.Input);
        ocmd.Parameters.Add("cpu_type_", OracleDbType.Int32, cpu_type, ParameterDirection.Input);
        ocmd.Parameters.Add("fixed_drives_", OracleDbType.Int32, fixed_drives, ParameterDirection.Input);
        ocmd.Parameters.Add("disk_c_ser_num_", OracleDbType.Int32, disk_c_ser_num, ParameterDirection.Input);
        ocmd.Parameters.Add("computer_", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        if (((OracleDecimal) ocmd.Parameters["computer_"].Value) != OracleDecimal.Null)
          computer = ((OracleDecimal) ocmd.Parameters["computer_"].Value).ToInt32();

        err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        Result = ((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32();
      }
      finally
      {
        ocmd.Dispose();
      }

      return Result;
    }

    /// <summary>
    ///   Сохраняет информацию о компьютере в БД.
    /// </summary>
    public void InsertComputer(string computer_name,
      string description,
      Int32 os_platform_id,
      Int32 os_major_ver,
      Int32 os_minor_ver,
      Int32 os_build_number,
      Int32 cpu_amount,
      Int32 cpu_type,
      UInt32 fixed_drives,
      Int32 disk_c_ser_num,
      Int32 blocked,
      out Int32 computer,
      out Int32 err_code,
      out string err_msg)
    {
      computer = 0;
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "adm.computer_pack.insert_computer";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("computer_name_", OracleDbType.Varchar2, computer_name, ParameterDirection.Input);
        ocmd.Parameters.Add("os_platform_id_", OracleDbType.Int32, os_platform_id, ParameterDirection.Input);
        ocmd.Parameters.Add("os_major_ver_", OracleDbType.Int32, os_major_ver, ParameterDirection.Input);
        ocmd.Parameters.Add("os_minor_ver_", OracleDbType.Int32, os_minor_ver, ParameterDirection.Input);
        ocmd.Parameters.Add("os_build_number_", OracleDbType.Int32, os_build_number, ParameterDirection.Input);
        ocmd.Parameters.Add("cpu_amount_", OracleDbType.Int32, cpu_amount, ParameterDirection.Input);
        ocmd.Parameters.Add("cpu_type_", OracleDbType.Int32, cpu_type, ParameterDirection.Input);
        ocmd.Parameters.Add("fixed_drives_", OracleDbType.Int64, fixed_drives, ParameterDirection.Input);
        ocmd.Parameters.Add("disk_c_ser_num_", OracleDbType.Int32, disk_c_ser_num, ParameterDirection.Input);
        ocmd.Parameters.Add("description_", OracleDbType.Varchar2, description, ParameterDirection.Input);
        ocmd.Parameters.Add("blocked_", OracleDbType.Int32, blocked, ParameterDirection.Input);
        ocmd.Parameters.Add("computer_", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters["err_msg"].Size = 4000;
        ocmd.ExecuteNonQuery();

        err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        if (err_code != 0)
          return;
        computer = ((OracleDecimal) ocmd.Parameters["computer_"].Value).ToInt32();
      }
      finally
      {
        ocmd.Dispose();
      }
    }
    /// <summary>
    ///   Проверяет заблокирован ли компьютер
    /// </summary>
    public Int32 IsCompBlocked(Int32 computer,
      out Int32 err_code,
      out string err_msg)
    {
      var Result = 0;
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        try
        {
          ocmd.CommandText = "begin\n" +
                             "  :result := adm.computer_pack.is_comp_blocked(computer_ => :computer_,\n" +
                             "                                           err_code => :err_code,\n" +
                             "                                           err_msg => :err_msg);\n" +
                             "end;";
          ocmd.BindByName = true;
          ocmd.Parameters.Add("computer_", OracleDbType.Int32, computer, ParameterDirection.Input);
          ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
          ocmd.Parameters["err_msg"].Size = 4000;
          ocmd.ExecuteNonQuery();

          err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
          err_msg = ocmd.Parameters["err_msg"].Value.ToString();
          Result = ((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32();
        }
        finally
        {
          ocmd.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in TPkgComputer.IsCompBlocked).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in TPkgComputer.IsCompBlocked).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return Result;
    }
  }


  /// <summary>
  ///   Пакет в схеме ADM: OFFICIAL_RIGHT_PACK.
  /// </summary>
  public class TPkgOfficialRight
  {
    public OracleConnection oc = null;

    /// <summary>
    ///   Заполняет таблицы прав и меню текущего должн. лица
    /// </summary>
    public void FillCurrOfficTables(out Int32 err_code, out string err_msg)
    {
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        try
        {
          ocmd.CommandText = "adm.official_right_pack.fill_curr_offic_tables";
          ocmd.CommandType = CommandType.StoredProcedure;
          ocmd.BindByName = true;
          ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          ocmd.Parameters["err_msg"].Size = 4000;
          ocmd.ExecuteNonQuery();

          err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
          err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        }
        finally
        {
          ocmd.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in TPkgOfficialRight.FillCurrOfficTables).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in TPkgOfficialRight.FillCurrOfficTables).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    ///   Корректирует объектные привилегии текущего должностного лица
    /// </summary>
    public void CorrectCurrOfficGrants(out Int32 err_code, out string err_msg)
    {
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        try
        {
          ocmd.CommandText = "adm.official_right_pack.correct_curr_offic_grants";
          ocmd.CommandType = CommandType.StoredProcedure;
          ocmd.BindByName = true;
          ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          ocmd.Parameters["err_msg"].Size = 4000;
          ocmd.ExecuteNonQuery();

          err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
          err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        }
        finally
        {
          ocmd.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in TPkgOfficialRight.CorrectCurrOfficGrants).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in TPkgOfficialRight.CorrectCurrOfficGrants).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void ReadCurrOfficMenusAList(Int32 Application, out DataTable dt, out Int32 err_code, out string err_msg)
    {
      dt = null;
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "adm.official_right_pack.read_curr_offic_menus_a_list";
        ocmd.CommandType = CommandType.StoredProcedure;
        ocmd.BindByName = true;
        ocmd.Parameters.Add("application_", OracleDbType.Int32, Application, ParameterDirection.Input);
        ocmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
        ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters["err_msg"].Size = 4000;

        var da = new OracleDataAdapter(ocmd);
        var Cur = new DataSet();
        da.Fill(Cur, "CUR");
        dt = Cur.Tables["CUR"];

        err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
        err_msg = ocmd.Parameters["err_msg"].Value.ToString();
      }
      finally
      {
        ocmd.Dispose();
      }
    }
  }


  /// <summary>
  ///   Пакет в схеме ADM: CONNECTION_PARAM.
  /// </summary>
  public class TPkgConnectionParam
  {
    public OracleConnection oc = null;

    /// <summary>
    ///   Заполняет таблицы прав и меню текущего должн. лица
    /// </summary>
    public void SetParams(out Int32 err_code, out string err_msg)
    {
      err_code = 0;
      err_msg = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        try
        {
          ocmd.CommandText = "adm.connection_param.set_params";
          ocmd.CommandType = CommandType.StoredProcedure;
          ocmd.BindByName = true;
          ocmd.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          ocmd.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          ocmd.Parameters["err_msg"].Size = 4000;
          ocmd.ExecuteNonQuery();

          err_code = ((OracleDecimal) ocmd.Parameters["err_code"].Value).ToInt32();
          err_msg = ocmd.Parameters["err_msg"].Value.ToString();
        }
        finally
        {
          ocmd.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBSupport.DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in TPkgConnectionParam.SetParams).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in TPkgConnectionParam.SetParams).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }


  /// <summary>
  ///   Пакет в схеме ADM: APP_IDENTIFY_PACK.
  /// </summary>
  public class TPkgAppIdentify
  {
    public OracleConnection oc = null;

    public Int32 IsAppIdentified(decimal audsid)
    {
      var iResult = 0;
      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin"
                           + " :result := adm.app_identify_pack.is_app_identified(:audsid_);"
                           + "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("audsid_", OracleDbType.Decimal, audsid, ParameterDirection.Input);
        ocmd.Parameters.Add("result", OracleDbType.Decimal, ParameterDirection.ReturnValue);
        ocmd.ExecuteNonQuery();

        iResult = ((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32();
      }
      finally
      {
        ocmd.Dispose();
      }

      return iResult;
    }
  }


  /// <summary>
  ///   Пакет в схеме ADM: ERROR_PACK.
  /// </summary>
  public class TPkgError
  {
    public OracleConnection oc;

    public TPkgError()
    {
      oc = null;
    }

    public TPkgError(OracleConnection oConnection)
    {
      oc = oConnection;
    }

    /// <summary>
    ///   Читает сообщение из стека с полной информацией (не удаляя)
    /// </summary>
    /// <param name="ErrRec">Запись с информацией об ошибке</param>
    /// <returns>TRUE - Сообщение возвращено успешно, FALSE - Стек пуст</returns>
    public bool GetErr(out ERR_REC ErrRec)
    {
      var Result = false;
      ErrRec = new ERR_REC();

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "declare\n" +
                           "  result boolean;\n" +
                           "  p_err_rec prepared.pkg_err.err_rec_t;\n" +
                           "begin\n" +
                           "  result := prepared.pkg_err.get_err(p_err_rec => p_err_rec);\n" +
                           "\n" +
                           "  :msg := p_err_rec.msg;\n" +
                           "  :error := p_err_rec.error;\n" +
                           "  :msg_type := p_err_rec.msg_type;\n" +
                           "  :msg_id := p_err_rec.msg_id;\n" +
                           "  :loc := p_err_rec.loc;\n" +
                           "\n" +
                           "  :result := sys.diutil.bool_to_int(result);\n" +
                           "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("msg", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("error", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("msg_type", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("msg_id", OracleDbType.Int32, ParameterDirection.Output);
        ocmd.Parameters.Add("loc", OracleDbType.Varchar2, ParameterDirection.Output);
        ocmd.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
        ocmd.Parameters["msg"].Size = 512;
        ocmd.Parameters["error"].Size = 1;
        ocmd.Parameters["msg_type"].Size = 3;
        ocmd.Parameters["loc"].Size = 1000;
        ocmd.ExecuteNonQuery();

        if (ocmd.Parameters["msg"].Value != DBNull.Value)
          ErrRec.msg = ocmd.Parameters["msg"].Value.ToString();

        if (ocmd.Parameters["error"].Value != DBNull.Value)
          ErrRec.error = ocmd.Parameters["error"].Value.ToString();
        ;

        if (ocmd.Parameters["msg_type"].Value != DBNull.Value)
          ErrRec.msg_type = ocmd.Parameters["msg_type"].Value.ToString();

        if (ocmd.Parameters["msg_id"].Value != DBNull.Value)
          ErrRec.msg_id = ((OracleDecimal) ocmd.Parameters["msg_id"].Value).ToInt32();

        if (ocmd.Parameters["loc"].Value != DBNull.Value)
          ErrRec.loc = ocmd.Parameters["loc"].Value.ToString();

        Result = (((OracleDecimal) ocmd.Parameters["result"].Value).ToInt32() == 1 ? true : false);
      }
      finally
      {
        ocmd.Dispose();
      }

      return Result;
    }

    /// <summary>
    ///   Возвращает все сообщения об ошибках в порядке их появления и удаляет из стека
    /// </summary>
    /// <returns>Сообщения об ошибках</returns>
    public string GetErrors()
    {
      var Result = String.Empty;

      var ocmd = oc.CreateCommand();
      try
      {
        ocmd.CommandText = "begin\n" +
                           "  :result := prepared.pkg_err.geterrors;\n" +
                           "end;";
        ocmd.BindByName = true;
        ocmd.Parameters.Add("result", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
        ocmd.Parameters["result"].Size = 4000;
        ocmd.ExecuteNonQuery();

        if (ocmd.Parameters["result"].Value != DBNull.Value)
          Result = ocmd.Parameters["result"].Value.ToString();
      }
      finally
      {
        ocmd.Dispose();
      }

      return Result;
    }

    public class ERR_REC
    {
      public string error;
      public string loc;
      public string msg;
      public Int32 msg_id;
      public string msg_type;
    }
  }
}