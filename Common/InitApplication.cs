using System;
using System.Data;
using System.Globalization;
using System.Threading;
using ARM_User.BusinessLayer.Guides;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using Microsoft.Win32;
//using ARM_User.BusinessLayer.Guides;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for InitApplication.
  /// </summary>
  public class InitApplication
  {
      public const string ProductName = "Государственный реестр эмиссионных ценных бумаг: АРМ \"Пользователь\"";
      public const string AppName = "Государственный реестр эмиссионных ценных бумаг: АРМ \"Пользователь\"";
      public const string AppTitle = "Государственный реестр эмиссионных ценных бумаг: АРМ \"Пользователь\"";
    public const string BSB_APP_GUID = "0901197F-D627-4104-B25D-2E4750A30D52";
    public const int AppId = 2/*1004*/;
    public const string RegAppKey = "Software\\BSB\\Gercb\\ARM_User";
    public static DataView dvLocaleResource;
    public static RegistryKey RegSetupRoot = Registry.CurrentUser;
    public static CultureInfo AppCulture = new CultureInfo("ru-RU");
    public static LookAndFeelStyle style;
    public static bool useWindowsXPTheme;
    public static bool useDefaultLookAndFeel;
    public static string skinName;
    public static LanguageIds CurrentLangId = LanguageIds.Russian;
    public static User currentUser;

    /// <summary>
    ///   Инициализирует данные для приложения.
    /// </summary>
    public static void InitializeApp()
    {
      var dtfi = AppCulture.DateTimeFormat;
      dtfi.DateSeparator = ".";
      dtfi.TimeSeparator = ":";
      dtfi.ShortDatePattern = "dd.MM.yyyy";
      dtfi.LongDatePattern = "d MMMM yyyy г";
      dtfi.ShortTimePattern = "HH:mm:ss";
      dtfi.LongTimePattern = "HH:mm:ss";

      Thread.CurrentThread.CurrentCulture = AppCulture;

      DevExpResource.SetLanguage(LanguageIds.Russian);
      BonusSkins.Register();

      LoadLastValues();
    }

    public static void UnInitializeApp()
    {
      SaveLastValues();
    }

    /// <summary>
    ///   Загружаем сохраненные значения из реестра пользователя Windows
    /// </summary>
    private static void LoadLastValues()
    {
      var reg = RegSetupRoot.OpenSubKey(RegAppKey, true);
      if (reg == null)
        reg = RegSetupRoot.CreateSubKey(RegAppKey);

      if (reg != null)
      {
        if (reg.GetValue("LookAndFeelStyle") == null)
          reg.SetValue("LookAndFeelStyle", "Office2003");

        if (reg.GetValue("useWindowsXPTheme") == null)
          reg.SetValue("useWindowsXPTheme", true);

        if (reg.GetValue("useDefaultLookAndFeel") == null)
          reg.SetValue("useDefaultLookAndFeel", true);

        if (reg.GetValue("skinName") == null)
          reg.SetValue("skinName", "Caramel");

        if (reg.GetValue("LookAndFeelStyle") != null)
        {
          switch (reg.GetValue("LookAndFeelStyle").ToString())
          {
            case "Flat":
              style = LookAndFeelStyle.Flat;
              break;
            case "UltraFlat":
              style = LookAndFeelStyle.UltraFlat;
              break;
            case "Style3D":
              style = LookAndFeelStyle.Style3D;
              break;
            case "Office2003":
              style = LookAndFeelStyle.Office2003;
              break;
            default:
              style = LookAndFeelStyle.Skin;
              break;
          }
        }

        if (reg.GetValue("useWindowsXPTheme") != null)
          useWindowsXPTheme = Convert.ToBoolean(reg.GetValue("useWindowsXPTheme"));

        if (reg.GetValue("useDefaultLookAndFeel") != null)
          useDefaultLookAndFeel = Convert.ToBoolean(reg.GetValue("useDefaultLookAndFeel"));

        if (reg.GetValue("skinName") != null)
          skinName = reg.GetValue("skinName").ToString();
      }
    }

    /// <summary>
    ///   Сохраняем значения в реестре пользователя Windows
    /// </summary>
    private static void SaveLastValues()
    {
      var reg = RegSetupRoot.OpenSubKey(RegAppKey, true);
      if (reg == null)
        reg = RegSetupRoot.CreateSubKey(RegAppKey);

      if (reg != null)
      {
        switch (style)
        {
          case LookAndFeelStyle.Flat:
            reg.SetValue("LookAndFeelStyle", "Flat");
            break;
          case LookAndFeelStyle.Office2003:
            reg.SetValue("LookAndFeelStyle", "Office2003");
            break;
          case LookAndFeelStyle.Skin:
            reg.SetValue("LookAndFeelStyle", "Skin");
            break;
          case LookAndFeelStyle.Style3D:
            reg.SetValue("LookAndFeelStyle", "Style3D");
            break;
          case LookAndFeelStyle.UltraFlat:
            reg.SetValue("LookAndFeelStyle", "UltraFlat");
            break;
          default:
            break;
        }
        reg.SetValue("useWindowsXPTheme", useWindowsXPTheme);
        reg.SetValue("useDefaultLookAndFeel", useDefaultLookAndFeel);
        reg.SetValue("skinName", skinName);
      }
    }
  }
}