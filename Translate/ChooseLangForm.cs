using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ARM_User.DataLayer;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.MapperLayer.Common;
using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User
{
  public partial class ChooseLangForm : BaseDialogForm
  {
    public LanguageIds langId;

    public ChooseLangForm()
    {
      InitializeComponent();
    }

    private void TfrmSelLang_Load(object sender, EventArgs e)
    {
      // Заполняем список языков          
      edLang.EditValue = LanguageIds.Russian;
      edLang.Properties.DataSource =
        MapperRegistry.Instance.GetSharedMapper().FindByParentId((decimal) LanguageIds.Root);
    }

    private void TfrmSelLang_Closing(object sender, CancelEventArgs e)
    {
      if (DialogResult == DialogResult.OK)
      {
        if (edLang.EditValue == null)
        {
          XtraMessageBox.Show(LangTranslate.UiGetText("Вы не выбрали язык интерфейса"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK,
            MessageBoxIcon.Information);
          e.Cancel = true;
          return;
        }

        langId = (LanguageIds)Convert.ToInt32(edLang.EditValue);
      }
      else
        langId = LanguageIds.Russian;

      var tab = new LocalTextDS.REF_LOCAL_TEXTDataTable();
      DataGatewayFactoryHolder.CacheFactory.GetLocalTextGateway().Load(tab);
      InitApplication.dvLocaleResource = new DataView(tab);

      e.Cancel = false;
    }

    private void BtnOK_Click(object sender, EventArgs e)
    {
      var ErrCode = 0;
      var ErrMsg = String.Empty;

      try
      {
        var dbSetup = new DBSetup();
        if (dmControler.frmMain.oracleConnection.State != ConnectionState.Open)
          return;
        dbSetup.oc = dmControler.frmMain.oracleConnection;
        var list = dbSetup.ReadSetupList(ErrCode, ErrMsg);

        if (list.Count > 0)
        {
          if (XtraMessageBox.Show(LangTranslate.UiGetText("Обнаружена новая версия АРМа ") + list[list.Count - 1].Version + Environment.NewLine +
                                  LangTranslate.UiGetText("Обновить АРМ?"), LangTranslate.UiGetText("Внимание"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
              DialogResult.Yes)
          {
            var tempPath = Path.GetTempPath();
            // Копируем утилиту UppateApp во временный каталог
            File.Copy(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + "UpdateApp.exe",
              tempPath + @"\" + "UpdateApp.exe", true);

            var args = "\"" + Application.ExecutablePath + "\" ";
            // Сохраняем установочные файлы во временный каталог
            foreach (var setup in list)
            {
              var setupFileName = tempPath + @"\" + "monitor_reports_update_" + setup.Version + ".exe";
              using (var fs = File.Create(setupFileName))
              {
                fs.Write(setup.FileBody, 0, setup.FileBody.Length);
                fs.Close();
                args = args + "\"" + setupFileName + "\" ";
              }
            }

            // Запускаем UppateApp
            Process.Start(tempPath + @"\" + "UpdateApp.exe", args);

            // Закрываем приложение
            Close();
          }
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
        if (rethrow)        
          throw;        
      }
    }
  }
}