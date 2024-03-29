using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ARM_User;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraVerticalGrid;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.DataLayer;
using BSB.Common.DB;
using BSB.Common.DB.Admin;
using System.Diagnostics;

namespace BSB.Common
{
  public class LangTranslate
  {
    // конструктор классса для инициализации переменных
    public static LanguageIds SelectLang(Boolean typelang)
    {
      LanguageIds languageId = LanguageIds.Russian;
      //ChooseLangForm frm = new ChooseLangForm();
      if (typelang) //(frm.ShowDialog() == DialogResult.OK)
      //languageId = frm.langId;
      {
          languageId = LanguageIds.Kazakh;
          var tab = new LocalTextDS.REF_LOCAL_TEXTDataTable();
          DataGatewayFactoryHolder.CacheFactory.GetLocalTextGateway().Load(tab);
          InitApplication.dvLocaleResource = new DataView(tab);
      }
      else
          languageId = LanguageIds.Russian;

      return languageId;
    }

    // формирую массив из таблицы REF_LOCAL_TEXT, чтобы после выбора языка строить меню, label и т.п
    // на соответствующем языке 
    public static string UiGetText(string trText)
    {
      return new LangTranslate().UiGetText2(InitApplication.CurrentLangId, trText);      
    }

    public static string UiGetText(LanguageIds langId, string trText)
    {      
      return new LangTranslate().UiGetText2(langId, trText);
    }

    public string UiGetText2(string trText)
    {
        return UiGetText2(InitApplication.CurrentLangId, trText);
    }
    public string UiGetText3(string trText)
    {
        if (InitApplication.CurrentLangId == LanguageIds.Russian)
        {
            InitApplication.dvLocaleResource.Sort = "LOCAL_TEXT";
            int findIndex = InitApplication.dvLocaleResource.Find(trText);
            if (findIndex == -1)
                return trText;
            string textRu = InitApplication.dvLocaleResource[findIndex]["KEY_TEXT"].ToString();
            return textRu;
        }
        return UiGetText2(trText);
    }
    public static string UiGetText4(string trText)
    {
        if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
        {
            InitApplication.dvLocaleResource.Sort = "KEY_TEXT";
            int findIndex = InitApplication.dvLocaleResource.Find(trText);
            if (findIndex == -1)
                return trText;
            string text = InitApplication.dvLocaleResource[findIndex]["LOCAL_TEXT"].ToString();
            return text;
        }
        return new LangTranslate().UiGetText2(trText);
    }
    public string UiGetText2(LanguageIds langId, string trText)
    {
      if (langId == LanguageIds.Russian || string.IsNullOrEmpty(trText))
        return trText;
      InitApplication.dvLocaleResource.Sort = "KEY_TEXT";
      int findIndex = InitApplication.dvLocaleResource.Find(trText);      
      var param = new TPkgParams();
      param.oc = dmControler.frmMain.oracleConnection;
      var dictionary = Convert.ToInt32(param.GetSystemSetupParam("INS_DATA_DICTIONARY"));
      if (findIndex == -1 && dictionary == 1)
      {
        using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "main.pkg_ref.ins_local_text";

          cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Output);
          cmd.Parameters.Add("p_key_text", OracleDbType.Varchar2, ParameterDirection.Input);
          cmd.Parameters.Add("p_local_text", OracleDbType.Varchar2, ParameterDirection.Input);
          cmd.Parameters.Add("p_edit_time", OracleDbType.Date, ParameterDirection.Input);
          cmd.Parameters.Add("p_edit_user_id", OracleDbType.Decimal, ParameterDirection.Input);
          cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
          cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
          cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

          cmd.Parameters["p_key_text"].Value = trText;
          cmd.Parameters["p_local_text"].Value = "нет перевода";
          cmd.Parameters["p_edit_time"].Value = DateTime.Now;
          cmd.Parameters["p_edit_user_id"].Value = 12;//InitApplication.currentUser.Id;
          cmd.Parameters["p_do_commit"].Value = 1;
          cmd.Parameters["p_err_msg"].Size = 4000;

          cmd.ExecuteNonQuery();

          if (!((OracleDecimal)cmd.Parameters["p_err_code"].Value).IsNull)
          {
            int errCode = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();
            string errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
            //if (errCode != 0)
            //  throw new OraCustomException(errCode, errMsg);
          }
        }
      }

      // Проверка результатов.
      if (findIndex == -1)
        return trText;
      string textKz = InitApplication.dvLocaleResource[findIndex]["LOCAL_TEXT"].ToString();
      return textKz;
    }

    public void UISetupTexts(Control control, List<Control> nonLocalizable = null)
    {
        if (control.Parent != null)
        
            control.Parent.Text = UiGetText2(control.Parent.Text);
            control.Text = UiGetText2(control.Text);

            if (control.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
            {
                TreeList tl = ((TreeList)control);
                for (var j = 0; j < tl.Columns.Count; j++)
                    tl.Columns[j].Caption = UiGetText2(tl.Columns[j].Caption);
            }
            //else if (control.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit")
            //{
            //  ComboBoxEdit cbe = ((ComboBoxEdit) control);
            //  for (var j = 0; j < cbe.Properties.Items.Count; j++)
            //    cbe.Properties.Items[j] = UiGetText2(cbe.Properties.Items[j].ToString());
            //}
            //else if (control.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit")
            //{
            //  var dl = ((LookUpEdit) control);
            //  dl.Properties.NullText = UiGetText2(dl.Properties.NullText);
            //  for (var j = 0; j < dl.Properties.Columns.Count; j++)
            //    dl.Properties.Columns[j].Caption = UiGetText2(dl.Properties.Columns[j].Caption);
            //}
            else if (control.GetType().ToString() == "DevExpress.XtraBars.BarDockControl")
            {
                var bdc = ((BarDockControl)control);
                for (var j = 0; j < bdc.Manager.Bars.Count; j++)
                    bdc.Manager.Bars[j].Text = UiGetText2(bdc.Manager.Bars[j].Text);
                for (var j = 0; j < bdc.Manager.Items.Count; j++)
                {
                    /*bdc.Manager.Items[j].Caption = UiGetText2(bdc.Manager.Items[j].Caption);
                    bdc.Manager.Items[j].Hint = UiGetText2(bdc.Manager.Items[j].Hint);*/
                    /*if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                    {*/
                    bdc.Manager.Items[j].Caption = UiGetText3(bdc.Manager.Items[j].Caption);
                    bdc.Manager.Items[j].Hint = UiGetText3(bdc.Manager.Items[j].Hint);
                    /* }
                     else
                     {
                       bdc.Manager.Items[j].Caption = UiGetText2(bdc.Manager.Items[j].Caption);
                       bdc.Manager.Items[j].Hint = UiGetText2(bdc.Manager.Items[j].Hint);
                     }*/

                }

            }
            else if (control.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
            {
                var lc = (LayoutControl)control;
                if (lc.Root != null)
                {
                    foreach (var item in GetLayoutItems(lc.Root.Items))
                        item.Text = UiGetText2(item.Text);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
            {
                var dg = ((GridControl)control);
                var gv = dg.DefaultView as GridView;
                gv.GroupPanelText = UiGetText2(gv.GroupPanelText);

                for (var j = 0; j < gv.Columns.Count; j++)
                {
                    gv.Columns[j].SummaryItem.DisplayFormat = UiGetText2(gv.Columns[j].SummaryItem.DisplayFormat);
                    gv.Columns[j].Caption = UiGetText2(gv.Columns[j].Caption);
                }

                for (var j = 0; j < dg.ViewCollection.Count; j++)
                {
                    var gv1 = dg.ViewCollection[j] as GridView;
                    gv1.GroupPanelText = UiGetText2(gv1.GroupPanelText);
                    for (var j1 = 0; j1 < gv1.Columns.Count; j1++)
                    {
                        gv1.Columns[j1].SummaryItem.DisplayFormat = UiGetText2(gv1.Columns[j1].SummaryItem.DisplayFormat);
                        gv1.Columns[j1].Caption = UiGetText2(gv1.Columns[j1].Caption);
                    }
                }

                if (dg.DefaultView.GetType() == typeof(BandedGridView))
                {
                    var bgv = (BandedGridView)dg.DefaultView;
                    foreach (var band in GetGridBands(bgv.Bands))
                        band.Caption = UiGetText2(band.Caption);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraVerticalGrid.VGridControl")
            {
                var dvg = ((VGridControl)control);
                for (var j = 0; j < dvg.Rows.Count; j++)
                {
                    dvg.Rows[j].Properties.Caption = UiGetText2(dvg.Rows[j].Properties.Caption);
                    for (var j1 = 0; j1 < dvg.Rows[j].ChildRows.Count; j1++)
                        dvg.Rows[j].ChildRows[j1].Properties.Caption = UiGetText2(dvg.Rows[j].ChildRows[j1].Properties.Caption);
                }
                for (var j = 0; j < dvg.RepositoryItems.Count; j++)
                {
                    if (dvg.RepositoryItems[j].GetType().ToString() ==
                        "DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup")
                    {
                        var rg = ((RepositoryItemRadioGroup)dvg.RepositoryItems[j]);
                        for (var j1 = 0; j1 < rg.Items.Count; j1++)
                            rg.Items[j1].Description = UiGetText2(rg.Items[j1].Description);
                    }
                    if (dvg.RepositoryItems[j].GetType().ToString() ==
                        "DevExpress.XtraEditors.Repository.RepositoryItemComboBox")
                    {
                        var cbx = ((RepositoryItemComboBox)dvg.RepositoryItems[j]);
                        for (var j1 = 0; j1 < cbx.Items.Count; j1++)
                            cbx.Items[j1] = UiGetText2(cbx.Items[j1].ToString());
                    }
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraBars.Controls.DockedBarControl")
            {
                var bdc = ((DockedBarControl)control);
                for (var j = 0; j < bdc.Bar.ItemLinks.Count; j++)
                {
                    if (bdc.Bar.ItemLinks[j].GetType().ToString() == "DevExpress.XtraBars.BarEditItemLink")
                    {
                        var el = ((BarEditItemLink)bdc.Bar.ItemLinks[j]);
                        if (el.Edit.GetType().ToString() == "DevExpress.XtraEditors.Repository.RepositoryItemComboBox")
                        {
                            var cbx = ((RepositoryItemComboBox)el.Edit);
                            for (var j1 = 0; j1 < cbx.Items.Count; j1++)
                                cbx.Items[j1] = UiGetText2(cbx.Items[j1].ToString());
                        }
                        if (el.Edit.GetType().ToString() == "DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit")
                        {
                            var cbx = ((RepositoryItemButtonEdit)el.Edit);
                            for (var j1 = 0; j1 < cbx.Buttons.Count; j1++)
                                cbx.Buttons[j1].ToolTip = UiGetText2(cbx.Buttons[j1].ToolTip);
                        }
                    }
                }
            }
            foreach (Control ctrl in control.Controls)
            {
                if (nonLocalizable != null && nonLocalizable.IndexOf(ctrl) != -1)
                    continue;
                UISetupTexts(ctrl, nonLocalizable);
            }
       
    }
    public void UISetupTextCon(Control control, List<Control> nonLocalizable = null)
    {
        if (control.Parent != null)
            control.Parent.Text = UiGetText2(control.Parent.Text);
        control.Text = UiGetText2(control.Text);

        if (control.GetType().ToString() == "DevExpress.XtraTreeList.TreeList")
        {
            TreeList tl = ((TreeList)control);
            for (var j = 0; j < tl.Columns.Count; j++)
                tl.Columns[j].Caption = UiGetText2(tl.Columns[j].Caption);
        }
        //else if (control.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit")
        //{
        //    ComboBoxEdit cbe = ((ComboBoxEdit)control);
        //    for (var j = 0; j < cbe.Properties.Items.Count; j++)
        //        cbe.Properties.Items[j] = UiGetText2(cbe.Properties.Items[j].ToString());
        //}
        //else if (control.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit")
        //{
        //    var dl = ((LookUpEdit)control);
        //    dl.Properties.NullText = UiGetText2(dl.Properties.NullText);
        //    for (var j = 0; j < dl.Properties.Columns.Count; j++)
        //        dl.Properties.Columns[j].Caption = UiGetText2(dl.Properties.Columns[j].Caption);
        //}
        else if (control.GetType().ToString() == "DevExpress.XtraBars.BarDockControl")
        {
            var bdc = ((BarDockControl)control);
            for (var j = 0; j < bdc.Manager.Bars.Count; j++)
                bdc.Manager.Bars[j].Text = UiGetText2(bdc.Manager.Bars[j].Text);
            for (var j = 0; j < bdc.Manager.Items.Count; j++)
            {
                /*bdc.Manager.Items[j].Caption = UiGetText2(bdc.Manager.Items[j].Caption);
                bdc.Manager.Items[j].Hint = UiGetText2(bdc.Manager.Items[j].Hint);*/
                /*if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
                {*/
                bdc.Manager.Items[j].Caption = UiGetText4(bdc.Manager.Items[j].Caption);
                bdc.Manager.Items[j].Hint = UiGetText4(bdc.Manager.Items[j].Hint);
                /* }
                 else
                 {
                   bdc.Manager.Items[j].Caption = UiGetText2(bdc.Manager.Items[j].Caption);
                   bdc.Manager.Items[j].Hint = UiGetText2(bdc.Manager.Items[j].Hint);
                 }*/

            }

        }
        else if (control.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
        {
            var lc = (LayoutControl)control;
            if (lc.Root != null)
            {
                foreach (var item in GetLayoutItems(lc.Root.Items))
                    item.Text = UiGetText2(item.Text);
            }
        }
        else if (control.GetType().ToString() == "DevExpress.XtraGrid.GridControl")
        {
            var dg = ((GridControl)control);
            var gv = dg.DefaultView as GridView;
            gv.GroupPanelText = UiGetText2(gv.GroupPanelText);

            for (var j = 0; j < gv.Columns.Count; j++)
            {
                gv.Columns[j].SummaryItem.DisplayFormat = UiGetText2(gv.Columns[j].SummaryItem.DisplayFormat);
                gv.Columns[j].Caption = UiGetText2(gv.Columns[j].Caption);
            }

            for (var j = 0; j < dg.ViewCollection.Count; j++)
            {
                var gv1 = dg.ViewCollection[j] as GridView;
                gv1.GroupPanelText = UiGetText2(gv1.GroupPanelText);
                for (var j1 = 0; j1 < gv1.Columns.Count; j1++)
                {
                    gv1.Columns[j1].SummaryItem.DisplayFormat = UiGetText2(gv1.Columns[j1].SummaryItem.DisplayFormat);
                    gv1.Columns[j1].Caption = UiGetText2(gv1.Columns[j1].Caption);
                }
            }

            if (dg.DefaultView.GetType() == typeof(BandedGridView))
            {
                var bgv = (BandedGridView)dg.DefaultView;
                foreach (var band in GetGridBands(bgv.Bands))
                    band.Caption = UiGetText2(band.Caption);
            }
        }
        else if (control.GetType().ToString() == "DevExpress.XtraVerticalGrid.VGridControl")
        {
            var dvg = ((VGridControl)control);
            for (var j = 0; j < dvg.Rows.Count; j++)
            {
                dvg.Rows[j].Properties.Caption = UiGetText2(dvg.Rows[j].Properties.Caption);
                for (var j1 = 0; j1 < dvg.Rows[j].ChildRows.Count; j1++)
                    dvg.Rows[j].ChildRows[j1].Properties.Caption = UiGetText2(dvg.Rows[j].ChildRows[j1].Properties.Caption);
            }
            for (var j = 0; j < dvg.RepositoryItems.Count; j++)
            {
                if (dvg.RepositoryItems[j].GetType().ToString() ==
                    "DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup")
                {
                    var rg = ((RepositoryItemRadioGroup)dvg.RepositoryItems[j]);
                    for (var j1 = 0; j1 < rg.Items.Count; j1++)
                        rg.Items[j1].Description = UiGetText2(rg.Items[j1].Description);
                }
                if (dvg.RepositoryItems[j].GetType().ToString() ==
                    "DevExpress.XtraEditors.Repository.RepositoryItemComboBox")
                {
                    var cbx = ((RepositoryItemComboBox)dvg.RepositoryItems[j]);
                    for (var j1 = 0; j1 < cbx.Items.Count; j1++)
                        cbx.Items[j1] = UiGetText2(cbx.Items[j1].ToString());
                }
            }
        }
        else if (control.GetType().ToString() == "DevExpress.XtraBars.Controls.DockedBarControl")
        {
            var bdc = ((DockedBarControl)control);
            for (var j = 0; j < bdc.Bar.ItemLinks.Count; j++)
            {
                if (bdc.Bar.ItemLinks[j].GetType().ToString() == "DevExpress.XtraBars.BarEditItemLink")
                {
                    var el = ((BarEditItemLink)bdc.Bar.ItemLinks[j]);
                    if (el.Edit.GetType().ToString() == "DevExpress.XtraEditors.Repository.RepositoryItemComboBox")
                    {
                        var cbx = ((RepositoryItemComboBox)el.Edit);
                        for (var j1 = 0; j1 < cbx.Items.Count; j1++)
                            cbx.Items[j1] = UiGetText2(cbx.Items[j1].ToString());
                    }
                    if (el.Edit.GetType().ToString() == "DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit")
                    {
                        var cbx = ((RepositoryItemButtonEdit)el.Edit);
                        for (var j1 = 0; j1 < cbx.Buttons.Count; j1++)
                            cbx.Buttons[j1].ToolTip = UiGetText2(cbx.Buttons[j1].ToolTip);
                    }
                }
            }
        }
        foreach (Control ctrl in control.Controls)
        {
            if (nonLocalizable != null && nonLocalizable.IndexOf(ctrl) != -1)
                continue;
            UISetupTextCon(ctrl, nonLocalizable);
        }
    }

    private List<GridBand> GetGridBands(GridBandCollection bands)
    {
      var list = new List<GridBand>();
      foreach (GridBand childBand in bands)
      {
        list.Add(childBand);
        list.AddRange(GetGridBands(childBand.Children));
      }
      return list;
    }

    private List<BaseLayoutItem> GetLayoutItems(LayoutGroupItemCollection items)
    {
      var list = new List<BaseLayoutItem>();
      foreach (BaseLayoutItem item in items)
      {
        list.Add(item);
        if (item.GetType() == typeof (LayoutControlGroup))
          list.AddRange(GetLayoutItems(((LayoutControlGroup) item).Items));
      }
      return list;
    }    
  }
}