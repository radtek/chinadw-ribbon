using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Common;
using ARM_User.MapperLayer.Common;
using BSB.Common.DB.Admin;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using ARM_User;
using BSB.Common;
using ARM_User.Common;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
/*using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;*/

namespace BSB.Common.DB
{
  /// <summary>
  ///   Summary description for DBSupport.
  /// </summary>
  public class DBSupport
  {
        static public MainForm main;
    /// <summary>
    ///   Показывает окно ввода имени/пароля и пытается подключиться к Oracle
    /// </summary>
    ///     
    public static bool ConnectToOracle(OracleConnection oc)
    {
      // Проверка на подключение к БД
      if (oc.State == ConnectionState.Open)
        return false;

      // Подключаемся к БД
      const int PasswTryCount = 3;
            int PassBlock = 0;
      var PasswTry = 0;
      bool UserCancel;
           
            using (var LogonDlgForm = new XtraLogonDlgForm()) //new TfrmLogonDialog()
            {
                try
                {
                    do
                    {
                        // Спрашиваем у пользователя логин и пароль
                        // UserCancel = LogonDlgForm.ShowDialog() == DialogResult.Cancel;

                         CustomFlyoutDialog.ShowForm(main, null, LogonDlgForm);
                        UserCancel = !LogonDlgForm.isOK;
                        if (!UserCancel)
                        {
                            // Устанавливаем параметры подключения

                            /* oc.ConnectionString = String.Format(dmControler.frmMain.DBConnectString,
                               LogonDlgForm.LogonUsername,
                               LogonDlgForm.LogonPassword,
                               LogonDlgForm.LogonDatabase);*/
                            oc.ConnectionString = LogonDlgForm.connString;
                            var oldCursor = Cursor.Current;
                            Cursor.Current = Cursors.WaitCursor;
                            try
                            {
                                PassBlock = 0;
                                oc.Open();

                                dmControler.frmMain.DBDatabase = LogonDlgForm.LogonDatabase;
                                dmControler.frmMain.DBLogin = LogonDlgForm.LogonUsername;
                                dmControler.frmMain.DBPassword = LogonDlgForm.LogonPassword;
                            }
                            catch (OracleException oe)
                            {
                                switch (oe.Number)
                                {
                                    case 1004:
                                        XtraMessageBox.Show(
                                          LangTranslate.UiGetText("Не указано имя пользователя для подключения к базе данных"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 1005:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Не указан пароль для подключения к базе данных"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 1017:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя пользователя или пароль"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        PassBlock = 1;
                                        break;
                                    case 12154:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя сервера"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 12500:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Неверное имя сервера"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 12560:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Не задано (неверно задано) имя сервера"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 28000:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Пользователь ORACLE заблокирован"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    case 28001:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Пароль пользователя ORACLE заблокирован"),
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                    default:
                                        XtraMessageBox.Show(LangTranslate.UiGetText("Ошибка № ") + oe.Number + ": " + oe.Message,
                                          LangTranslate.UiGetText("В доступе отказано"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        break;
                                }
                            }
                            finally
                            {
                                Cursor.Current = oldCursor;
                            }

                            PasswTry++;
                        }
                    } while (!((oc.State == ConnectionState.Open) || (PasswTry >= PasswTryCount) || UserCancel));
                    if ((PasswTry == PasswTryCount) && (PassBlock == 1))
                    {
                        XtraMessageBox.Show(
                        LangTranslate.UiGetText("Превышен лимит неверных попыток. Пользователь заблокирован.") + Environment.NewLine +
                        LangTranslate.UiGetText("Обратитесь к администратору "),
                        LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        try
                        {
                            int ErrCode;
                            string ErrMsg;
                            var username = LogonDlgForm.LogonUsername;
                            new SetOfficialBlocked().SetCurrOfficialBlocked(5, username, out ErrCode, out ErrMsg);
                            if (ErrCode != 0)
                            {
                                DBErrorHandler(ErrCode, ErrMsg);
                            }
                        }
                        catch (OracleException oe)
                        {
                            DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.SetCurrOfficialBlocked).");
                        }
                        catch (Exception oe)
                        {
                            XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.SetCurrOfficialBlocked).",
                              LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                finally
                {
                    LogonDlgForm.Dispose();
                }
            }
                

      return (oc.State == ConnectionState.Open);
    }

    /// <summary>
    ///   Отключение от БД
    /// </summary>
    public static bool DisconnectFromOracle(OracleConnection oc)
    {
      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        return false;

      try
      {
        oc.Close();
        UnitOfWork.Instance.Clear();
      }
      catch (Exception e)
      {
        XtraMessageBox.Show(LangTranslate.UiGetText("Ошибка при отключении от базы данных:") + e.Message,
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    /// <summary>
    ///   Проверяет прописан ли пользователь Oracle в Official
    /// </summary>
    public static bool IsUserOfficial()
    {
      // Проверка на подключение к БД
      if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
        return false;

      try
      {
        string ErrMsg;
        int ErrCode;
        var off = new TPkgOfficial();
        off.oc = dmControler.frmMain.oracleConnection;
        var Ret = off.IsUserOfficial(out ErrCode, out ErrMsg);

        if (ErrCode != 0)
        {
          DBErrorHandler(ErrCode, ErrMsg);
        }
        else
          return (Ret == 1);
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.IsUserOfficial)");
      }
      catch (Exception e)
      {
        XtraMessageBox.Show(e.Message + Environment.NewLine + "(occured in DBSupport.IsUserOfficial)",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return false;
    }

    /// <summary>
    ///   Проверяет заблокировано ли должностное лицо администратором
    /// </summary>
    public static bool IsOfficialBlocked()
    {
      // Проверка на подключение к БД
      if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      try
      {
        var oCommand = new OracleCommand("begin" +
                                         " :result := adm.official_pack.is_official_blocked(:err_code, :err_msg);" +
                                         "end;", dmControler.frmMain.oracleConnection);
        try
        {
          oCommand.BindByName = true;
          oCommand.Parameters.Add("result", OracleDbType.Int32, ParameterDirection.ReturnValue);
          oCommand.Parameters.Add("err_code", OracleDbType.Int32, ParameterDirection.Output);
          oCommand.Parameters.Add("err_msg", OracleDbType.Varchar2, ParameterDirection.Output);
          oCommand.Parameters["err_msg"].Size = 2000;
          oCommand.ExecuteNonQuery();

          string ErrMsg;
          var ErrCode = ((OracleDecimal) oCommand.Parameters["err_code"].Value).ToInt32();
          if (ErrCode != 0)
          {
            ErrMsg = oCommand.Parameters["err_msg"].ToString();
            DBErrorHandler(ErrCode, ErrMsg);
          }
          else
            return (((OracleDecimal) oCommand.Parameters["result"].Value).ToInt32() == 1);
        }
        finally
        {
          oCommand.Dispose();
        }
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.IsOfficialBlocked)");
      }
      catch (Exception e)
      {
        XtraMessageBox.Show(e.Message + Environment.NewLine + "(occured in DBSupport.IsOfficialBlocked)",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return false;
    }

        internal static void ErrorHandler(OracleException oracleException)
        {
            throw new NotImplementedException();
        }

        public static void DBErrorHandler(int ErrCode, string ErrMsg)
    {
      // Выделяем из ErrMsg строку трассировки и сообщения на русском и английском языках
        int startIndex = 0;
        int length = 9;        
        string  substring = ErrMsg.Substring(startIndex, length);
        if (substring == "ORA-00028" || substring == "ORA-03114")
        {
            var main = new MainForm();                  
            XtraMessageBox.Show(
                   LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
                   LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            main.KillClose();           
        }
        else
        {
            if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
            {
                XtraMessageBox.Show(
                  LangTranslate.UiGetText("Нет соединения с БД. Требуется повторное подключение."),
                  LangTranslate.UiGetText("Внимание!"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var MsgPartArr = GetErrorSubStrings(ErrMsg);
                var ErrDlg = new TfrmAppErrorDlg();
                try
                {
                    if (ErrCode == -20500 || ErrCode == -20599 || ErrCode == 942 ||
                        ErrCode == 6550 || ErrCode == -6508) // Наше сообщение об ошибке
                    {
                        ErrDlg.ErrCode = ErrCode.ToString();
                        ErrDlg.ErrMsgEng = MsgPartArr[2];
                        ErrDlg.ErrTrace = MsgPartArr[0];

                        // {ORA-00942: Table or view does not exists}
                        // {ORA-06550: Identifier ... must be declared}
                        if ((ErrCode == 942 || ErrCode == 6550) && (MsgPartArr[3] == String.Empty))
                            MsgPartArr[3] = LangTranslate.UiGetText("Недостаточно прав для выполнения операции");

                        // {ORA-06508: Could not find program unit being called}  
                        if (ErrCode == -6508)
                            MsgPartArr[3] = LangTranslate.UiGetText("Администратором системы (или системой) были выполнены процессы,") + Environment.NewLine +
                                            LangTranslate.UiGetText("требующие выполнения отключения и повторного подключения к БД");
                        //else if (ErrCode == 942)
                        //{
                        //    MsgPartArr[3] = LangTranslate.UiGetText("Сеанс был убит!") + Environment.NewLine +
                        //                      LangTranslate.UiGetText("требующие выполнения отключения и повторного подключения к БД");
                        //}

                        ErrDlg.ErrMsgRus = MsgPartArr[3];
                    }
                    else // Сообщение ORACLE'а
                    {
                        ErrDlg.ErrCode = ErrCode.ToString();
                        ErrDlg.ErrMsgEng = MsgPartArr[2];
                        ErrDlg.ErrMsgRus = MsgPartArr[3];
                        ErrDlg.ErrTrace = MsgPartArr[2];
                    }

                    ErrDlg.ShowDialog();
                }

                finally
                {
                    ErrDlg.Dispose();
                }
            }
        }
    }

    public static void MyErrorHandler(OracleException OracleError)
    {
      var ErrDlg = new TfrmAppErrorDlg();
      try
      {
        if (OracleError.Number == 20998) // Если ошибка пользовательская
        {
          TPkgError.ERR_REC ErrorRec = null;
          var ErrorPack = new TPkgError(dmControler.frmMain.oracleConnection);
          ErrorPack.GetErr(out ErrorRec);
          var ErrorMsg = ErrorPack.GetErrors();

          ErrDlg.ErrCode = OracleError.Number.ToString();
          ErrDlg.ErrMsgRus = ErrorMsg;
          ErrDlg.ErrTrace = ErrorRec.loc;
          ErrDlg.ErrMsgEng = ErrorRec.loc + Environment.NewLine +
                             ":AppStackTrace:" + Environment.NewLine + OracleError.StackTrace;

          ErrDlg.ShowDialog();
        }
        else // Если ошибка системная
        {
          //{ORA-00942: Table or view does not exists}
          //{ORA-06550: Identifier ... must be declared}
          if (OracleError.Number == 942 || OracleError.Number == 6550) // Если недостаточно прав
          {
            ErrDlg.ErrCode = OracleError.Number.ToString();
            ErrDlg.ErrMsgRus = "Недостаточно прав для выполнения операции.";
            ErrDlg.ErrMsgEng = UnixToWindowsCRLF(OracleError.Message) + Environment.NewLine +
                               ":AppStackTrace:" + Environment.NewLine + OracleError.StackTrace;

            ErrDlg.ShowDialog();
          }
          else
          {
            ErrDlg.ErrCode = OracleError.Number.ToString();
            ErrDlg.ErrMsgRus = "Ошибка БД";
            ErrDlg.ErrTrace = UnixToWindowsCRLF(OracleError.Message);
            ErrDlg.ErrMsgEng = UnixToWindowsCRLF(OracleError.Message) + Environment.NewLine +
                               ":AppStackTrace:" + Environment.NewLine + OracleError.StackTrace;

            ErrDlg.ShowDialog();
          }
        }
      }
      finally
      {
        ErrDlg.Dispose();
      }
    }

    public static string[] GetErrorSubStrings(string ErrMsg)
    {
      // /T\ - строка трассировки (не обязательный тэг, может просто начинаться с начала строки)
      // /C\ - код ошибки;
      // /E\ - сообщение об ошибке на англ. языке;
      // /R\ - сообщение об ошибке на русском языке
      var arrReturn = new string[4] {"", "", "", ""};

      var r = new Regex(@"(/T\\|/C\\|/E\\|/R\\)");
      var strArr = r.Split(ErrMsg);

      if (strArr.Length > 1)
      {
        var CurDelimiter = "";
        foreach (var strTemp in strArr)
        {
          if (strTemp == @"/T\" || strTemp == @"/C\" || strTemp == @"/E\" || strTemp == @"/R\")
          {
            CurDelimiter = strTemp;
          }
          else
          {
            switch (CurDelimiter)
            {
              case @"/T\":
              case "":
                arrReturn[0] = strTemp;
                break;
              case @"/C\":
                arrReturn[1] = strTemp;
                break;
              case @"/E\":
                arrReturn[2] = strTemp;
                break;
              case @"/R\":
                arrReturn[3] = strTemp;
                break;
            }
          }
        }
      }
      else
        arrReturn[2] = strArr[0];

      for (var i = 0; i < arrReturn.Length; i++)
        arrReturn[i] = UnixToWindowsCRLF(arrReturn[i]);

      return arrReturn;
    }

    /// <summary>
    ///   Преобразует переносы строк в стиле Unix ($D (а также и $A))
    ///   в переносы строк в стиле Windows
    /// </summary>
    public static string UnixToWindowsCRLF(string UnixCRLFStr)
    {
      return Regex.Replace(UnixCRLFStr, "\r\n?|\r?\n", "\r\n");
    }

    /// <summary>
    ///   Возвращает дату последней смены пароля пользователя
    /// </summary>
    public static DateTime GetUserPasswordChangeDate(string UserName)
    {
      var oc = dmControler.frmMain.oracleConnection;
      var Result = new DateTime(1900, 1, 1);

      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      try
      {
        int ErrCode;
        string ErrMsg;
        var op = new TPkgOfficial();
        op.oc = oc;
        Result = op.GetUserPasswordChangeDate(UserName, out ErrCode, out ErrMsg);

        if (ErrCode != 0)
        {
          DBErrorHandler(ErrCode, ErrMsg);
        }
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.GetUserPasswordChangeDate).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.GetUserPasswordChangeDate).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return Result;
    }
    
    /// <summary>
    ///   Устанавливает флаг блокировки пользователя
    /// </summary>
    public static void SetCurrOfficialBlocked(int Blocked)
    {
      var oc = dmControler.frmMain.oracleConnection;

      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      try
      {
        int ErrCode;
        string ErrMsg;
        var op = new TPkgOfficial();
        op.oc = oc;
        op.SetCurrOfficialBlocked(Blocked, out ErrCode, out ErrMsg);

        if (ErrCode != 0)
        {
          DBErrorHandler(ErrCode, ErrMsg);
        }
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.SetCurrOfficialBlocked).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.SetCurrOfficialBlocked).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    ///   Возвращает текущее время на сервере (приведенное к локальному)
    /// </summary>
    public static DateTime GetServerTime()
    {
      var Result = new DateTime(1900, 1, 1);
      var oc = dmControler.frmMain.oracleConnection;

      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      try
      {
        var op = new TPkgOfficial();
        op.oc = oc;
        Result = op.GetServerTime();
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.GetServerTime).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.GetServerTime).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return Result;
    }
    public static Int32 GetIdUserChangePassword()
    {
        var Result = 0;
        var oc = dmControler.frmMain.oracleConnection;

        // Проверка на подключение к БД
        if (oc.State != ConnectionState.Open)
            throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

        try
        {
            var op = new TPkgOfficial();
            op.oc = oc;
            Result = op.GetIdUserChangePassword();
        }
        catch (OracleException oe)
        {
            DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.GetIdUserChangePassword).");
        }
        catch (Exception oe)
        {
            XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.GetIdUserChangePassword).",
              LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return Result;
    }

    /// <summary>
    ///   Возвращает True, если компьютер зарегистрирован в базе данных
    /// </summary>
    public static bool IsCompRegistered(out int Computer, out string ComputerName)
    {
      var Result = false;
      Computer = 0;
      ComputerName = String.Empty;

      var oc = dmControler.frmMain.oracleConnection;

      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      Int32 OSPlatformId;
      int OSMajorVer, OSMinorVer, OSBuildNumber, CPUAmount, CPUType;
      UInt32 DiskCSerNum;
      UInt32 FixedDrives;
      Utilities.GetPCData(out ComputerName, out OSPlatformId, out OSMajorVer,
        out OSMinorVer, out OSBuildNumber, out CPUAmount, out CPUType, out FixedDrives,
        out DiskCSerNum);

      try
      {
        Int32 ErrCode;
        string ErrMsg;
        var kp = new TPkgComputer();
        kp.oc = oc;
        var Res = kp.IsCompRegistered(ComputerName, OSPlatformId, OSMajorVer, OSMinorVer, OSBuildNumber,
          CPUAmount, CPUType, (Int32) FixedDrives, (Int32) DiskCSerNum, out Computer,
          out ErrCode, out ErrMsg);
        if (ErrCode != 0)
        {
          DBErrorHandler(ErrCode, ErrMsg);
        }
        else
          Result = (Res == 1);
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + Environment.NewLine + "(occured in DBSupport.IsCompRegistered).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + Environment.NewLine + "(occured in DBSupport.IsCompRegistered).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return Result;
    }

    /// <summary>
    ///   Возвращает True, если компьютер успешно зарегистрирован в базе данных
    /// </summary>
    public static bool RegisterComputer(out Int32 Computer, out string ComputerName)
    {
      Computer = 0;
      ComputerName = String.Empty;

      var fr = new TfrmRegComputer();
      try
      {
        if (fr.ShowDialog() != DialogResult.OK)
          return false;

        Computer = fr.pComputerID;
        ComputerName = fr.pComputerName;
      }
      finally
      {
        fr.Dispose();
      }

      return true;
    }

    /// <summary>
    ///   Возвращает True, если компьютер заблокирован
    /// </summary>
    public static bool IsCompBlocked(Int32 Computer)
    {
      var oc = dmControler.frmMain.oracleConnection;
      var bResult = false;

      // Проверка на подключение к БД
      if (oc.State != ConnectionState.Open)
        throw new Exception(LangTranslate.UiGetText("Нет соединения с БД"));

      try
      {
        Int32 ErrCode;
        string ErrMsg;

        var pk = new TPkgComputer();
        pk.oc = oc;
        var Res = pk.IsCompBlocked(Computer, out ErrCode, out ErrMsg);

        if (ErrCode != 0)
        {
          DBErrorHandler(ErrCode, ErrMsg);
        }
        else
          bResult = (Res == 1);
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in DBSupport.IsCompBlocked).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in DBSupport.IsCompBlocked).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return bResult;
    }

    /// <summary>
    ///   Заполняет таблицы прав и меню текущего должн. лица
    /// </summary>
    public static bool FillCurrOfficTables(OracleConnection oc)
    {
      if (oc.State != ConnectionState.Open)
        return false;

      Int32 ErrCode;
      string ErrMsg;

      var or = new TPkgOfficialRight();
      or.oc = oc;
      or.FillCurrOfficTables(out ErrCode, out ErrMsg);

      if (ErrCode != 0)
      {
        DBErrorHandler(ErrCode, ErrMsg);
        return false;
      }

      return true;
    }

    /// <summary>
    ///   Корректирует объектные привилегии текущего должностного лица
    /// </summary>
    public static void CorrectCurrOfficGrants(OracleConnection oc)
    {
      if (oc.State != ConnectionState.Open)
        return;

      Int32 ErrCode;
      string ErrMsg;

      var or = new TPkgOfficialRight();
      or.oc = oc;
      or.CorrectCurrOfficGrants(out ErrCode, out ErrMsg);

      if (ErrCode != 0)
        DBErrorHandler(ErrCode, ErrMsg);
    }

    /// <summary>
    ///   Устанавливает параметры БД
    /// </summary>
    public static void SetParams()
    {
      var oc = dmControler.frmMain.oracleConnection;

      if (oc.State != ConnectionState.Open)
        return;

      Int32 ErrCode;
      string ErrMsg;

      var cp = new TPkgConnectionParam();
      cp.oc = oc;
      cp.SetParams(out ErrCode, out ErrMsg);

      if (ErrCode != 0)
        DBErrorHandler(ErrCode, ErrMsg);
    }

    /// <summary>
    ///   Устанавливает параметры БД
    /// </summary>
    public static string GetOfficialName()
    {
      var strResult = String.Empty;
      var oc = dmControler.frmMain.oracleConnection;

      if (oc.State != ConnectionState.Open)
        return strResult;

      Int32 ErrCode;
      string ErrMsg;

      var pof = new TPkgOfficial();
      pof.oc = oc;

      InitApplication.currentUser =
        MapperRegistry.Instance.GetUserMapper().Find(pof.GetOfficial(out strResult, out ErrCode, out ErrMsg));

      if (ErrCode != 0)
        DBErrorHandler(ErrCode, ErrMsg);

      return strResult;
    }

    /// <summary>
    ///   Опредиляет идиентифицировано ли приложение (сессия, заданная audsid)
    /// </summary>
    public static bool IsAppIdentified(decimal Audsid)
    {
      var bResult = false;
      var oc = dmControler.frmMain.oracleConnection;

      if (oc.State != ConnectionState.Open)
        return bResult;

      try
      {
        var app = new TPkgAppIdentify();
        app.oc = oc;
        bResult = (app.IsAppIdentified(Audsid) == 1);
      }
      catch (OracleException oe)
      {
        DBErrorHandler(oe.Number, oe.Message + "\r\n(occured in DBSupport.IsAppIdentified).");
      }
      catch (Exception oe)
      {
        XtraMessageBox.Show(oe.Message + "\r\n(occured in DBSupport.IsAppIdentified).",
          LangTranslate.UiGetText("Ошибка"), MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return bResult;
    }
    
  }
}