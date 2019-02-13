using System.Collections.Generic;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using Microsoft.Win32;

namespace ARM_User.DisplayLayer.Common
{
  public class GridUtilities
  {
    public static string GetLayoutRegistryPath(Form form, GridView view)
    {
      return InitApplication.RegAppKey + "\\GridLayouts\\" + form.Name + "\\" + view.GridControl.Name + "." + view.Name;
    }

    public static string GetLayoutRegistryPath(Form form, TreeList treeList)
    {
      return InitApplication.RegAppKey + "\\GridLayouts\\" + form.Name + "\\" + treeList.Name;
    }

    // Сохраняет в реестре настройки по всем гридам формы
    public static void SaveGridLayouts(Form form)
    {
      var grids = GetGridControls(form, form.Controls);
      
      foreach (var ctrl in grids)
      {
        if (ctrl.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
        {
          var dg = ((GridControl) ctrl);
          var gv = dg.DefaultView as GridView;
          gv.SaveLayoutToRegistry(GetLayoutRegistryPath(form, gv));
          ClearLayoutRegistry(GetLayoutRegistryPath(form, gv) + "\\ViewData\\Columns");
        }
        else if (ctrl.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
        {
          var tl = ((TreeList) ctrl);
          tl.SaveLayoutToRegistry(GetLayoutRegistryPath(form, tl));
          ClearLayoutRegistry(GetLayoutRegistryPath(form, tl) + "\\TreeListData\\Columns");
        }
      }
    }

    // Загружает из реестра настройки по всем гридам формы
    public static void RestoreGridLayouts(Form form)
    {
      var grids = GetGridControls(form, form.Controls);
      foreach (var ctrl in grids)
      {
        if (ctrl.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
        {
          var dg = ((GridControl) ctrl);
          var gv = dg.DefaultView as GridView;
          gv.RestoreLayoutFromRegistry(GetLayoutRegistryPath(form, gv));
        }
        else if (ctrl.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
        {
          var tl = ((TreeList) ctrl);
          tl.RestoreLayoutFromRegistry(GetLayoutRegistryPath(form, tl));
        }
      }
    }

    // Сохраняет в реестре настройки по всем гридам формы
    public static void SaveGridLayouts(Form form, Control[] controls)
    {
      foreach (var ctrl in controls)
      {
        if (ctrl.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
        {
          var dg = ((GridControl) ctrl);
          var gv = dg.DefaultView as GridView;
          gv.SaveLayoutToRegistry(GetLayoutRegistryPath(form, gv));
          ClearLayoutRegistry(GetLayoutRegistryPath(form, gv) + "\\ViewData\\Columns");
        }
        else if (ctrl.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
        {
          var tl = ((TreeList) ctrl);
          tl.SaveLayoutToRegistry(GetLayoutRegistryPath(form, tl));
          ClearLayoutRegistry(GetLayoutRegistryPath(form, tl) + "\\TreeListData\\Columns");
        }
      }
    }

    // Загружает из реестра настройки по всем гридам формы
    public static void RestoreGridLayouts(Form form, Control[] controls)
    {
      foreach (var ctrl in controls)
      {
        if (ctrl.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
        {
          var dg = ((GridControl) ctrl);
          var gv = dg.DefaultView as GridView;
          gv.RestoreLayoutFromRegistry(GetLayoutRegistryPath(form, gv));
        }
        else if (ctrl.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
        {
          var tl = ((TreeList) ctrl);
          tl.RestoreLayoutFromRegistry(GetLayoutRegistryPath(form, tl));
        }
      }
    }

    // Возвращает массив гридов формы
    public static List<Control> GetGridControls(Form form, Control.ControlCollection controls)
    {
      var grids = new List<Control>();
      foreach (Control ctrl in controls)
      {
        if (ctrl.GetType().ToString() == "DevExpress.XtraGrid.GridControl" ||
            ctrl.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
          grids.Add(ctrl);

        if (ctrl.Controls.Count > 0)
          grids.AddRange(GetGridControls(form, ctrl.Controls));
      }

      return grids;
    }

    // Удаляет из реестра не нужные свойства
    public static void ClearLayoutRegistry(string regPath)
    {
      var reg = InitApplication.RegSetupRoot.OpenSubKey(regPath, true);
      foreach (var key in reg.GetSubKeyNames())
      {
        if (!key.StartsWith("Item")) continue;

        RegistryKey item = reg.OpenSubKey(key, true);

        if (item.GetValue("FieldName") != null)
          item.DeleteValue("FieldName");
        if (item.GetValue("Caption") != null)
          item.DeleteValue("Caption");
        if (item.GetValue("CustomizationCaption") != null)
          item.DeleteValue("CustomizationCaption");
        if (item.GetValue("Tooltip") != null)
          item.DeleteValue("Tooltip");
      }
    }
  }
}