using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSB.Common.DataGateway.Oracle;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using ARM_User.MapperLayer.Common;
using DevExpress.XtraEditors;
using BSB.Common;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace ARM_User.BusinessLayer.Common
{
  public class RightsItemChecking
    {
     public static bool GetRightsItem(decimal rightsitem = 0)
      {
          var mapper = MapperRegistry.Instance.GetRightsItemMapper();
          if (mapper.Find(rightsitem) != null)
            return true;
          else
            return false;
     }
      public static void Message()
      {
          XtraMessageBox.Show(LangTranslate.UiGetText("Недостаточно прав для выполнения операции"),
                              LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }      
    }
}
