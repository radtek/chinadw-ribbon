using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using System.Collections.Generic;
using BSB.Common.DataGateway.Oracle;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.ServiceLayer.Service.Editor
{
  public enum EditorState
  {
    View,
    Insert,
    Edit,
    Final
  }

  public class EditorUtils
  {
    #region Public static methods

    public static void ReadOnlyControls(Control.ControlCollection controls, List<Control> readOnlyControls, bool readOnly)
    {
      foreach (Control control in controls)
      {
        if (readOnlyControls != null && readOnlyControls.IndexOf(control) >= 0) 
          continue;
        ReadOnlyControl(control, readOnly);
        if (control.Controls.Count > 0)
        {
          foreach (Control control2 in control.Controls)
          {
            if (readOnlyControls != null && readOnlyControls.IndexOf(control2) >= 0) 
              continue;
            ReadOnlyControl(control2, readOnly);
            // рекурсия , чтобы получить все дочерние компоненты
            ReadOnlyControls(control2.Controls, readOnlyControls, readOnly);
          }
        }
      }
    }

    public static void ReadOnlyControl(Control control, bool readOnly)
    {
      if (control.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
      {
        TextEdit te = (TextEdit)control;
        te.Properties.ReadOnly = readOnly;
        te.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        te.BackColor = Color.White;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.MemoEdit")
      {
        MemoEdit me = (MemoEdit)control;
        me.Properties.ReadOnly = readOnly;
        me.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        me.BackColor = Color.White;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.DateEdit")
      {
        DateEdit de = (DateEdit)control;
        de.Properties.ReadOnly = readOnly;
        de.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        de.BackColor = Color.White;
        foreach (EditorButton btn in de.Properties.Buttons)
          btn.Enabled = !readOnly;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.CheckEdit")
      {
        CheckEdit ce = (CheckEdit)control;
        ce.Properties.ReadOnly = readOnly;
        ce.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        ce.BackColor = Color.White;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit")
      {
        LookUpEdit le = (LookUpEdit)control;
        le.Properties.ReadOnly = readOnly;
        le.Properties.TextEditStyle = readOnly ? TextEditStyles.Standard : TextEditStyles.DisableTextEditor;
        le.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        le.BackColor = Color.White;
        foreach (EditorButton btn in le.Properties.Buttons)
          btn.Enabled = !readOnly;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.ButtonEdit")
      {
        ButtonEdit be = (ButtonEdit)control;
        be.Properties.ReadOnly = true;
        be.Properties.TextEditStyle = readOnly ? TextEditStyles.Standard : TextEditStyles.DisableTextEditor;
        be.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
        be.BackColor = Color.White;
        foreach (EditorButton btn in be.Properties.Buttons)
          btn.Enabled = !readOnly;
      }
      else if (control.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit")
      {
          ComboBoxEdit co = (ComboBoxEdit)control;
          co.Properties.ReadOnly = true;
          co.Properties.TextEditStyle = readOnly ? TextEditStyles.Standard : TextEditStyles.DisableTextEditor;
          co.ForeColor = readOnly ? SystemColors.GrayText : SystemColors.WindowText;
          co.BackColor = Color.White;
          foreach (EditorButton btn in co.Properties.Buttons)
              btn.Enabled = !readOnly;
      }      
    }    
    #endregion    
  }
}