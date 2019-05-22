using ARM_User.New.DB;
using BSB.Common;
using BSB.Common.DB;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using Ionic.Zip;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ARM_User.New.Guide
{
    public partial class NewCreditsListForm : BSB.Common.MDIChildForm
    {
        private DB_Pledges db = null;

        public NewCreditsListForm()
        {
            InitializeComponent();
            db = new DB_Pledges();

            beData.EditValue = (DateTime)System.DateTime.Today;
            
            try
            {
                splashScreenManager.ShowWaitForm();
                refreshListCredits();
            }
            finally
            {
                splashScreenManager.CloseWaitForm();
            }

            
            bgvCredits.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            bgvSheduler.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            
            bgvCredits.OptionsView.ShowGroupPanel = false;
            bgvSheduler.OptionsView.ShowGroupPanel = false;

            

            //colh_loan_sid.Fixed = FixedStyle.Left;
        }
        private void bgvList2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            splashScreenManager.ShowWaitForm();            
            refreshListPaymentPlan();
            refreshListPledges();
            refreshListPokaz();
            refreshListExtraPokaz();
            splashScreenManager.CloseWaitForm();
        }
        public void refreshListPaymentPlan()
        {
            gridBand2.Caption = String.Format("График оплаты - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));
            
            db.getReadPaymentPlan(ref dsMain, (DateTime)beData.EditValue, getCurrentID("tsCredits", "LOAN_SID"));
        }
        public virtual void refreshListCredits()
        {
            
            bgvCredits.BeginUpdate();
            
            db.getReadListCredits(ref dsMain, Convert.ToDateTime(beData.EditValue.ToString()).Date);
            Int32 xCount = dsMain.Tables["tsCredits"].Rows.Count;
            bCount.Caption = xCount.ToString();
            if (xCount == 0)
            {
                pBottomContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                pLeftContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            }
            else
            {
                pBottomContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                pLeftContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            }
           

            bgvCredits.EndUpdate();

        }
        public virtual void refreshListPledges()
        {
           
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListPledges(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsPledges"].Rows.Count;
                dpPledges.TabText = String.Format("({0} Залоги)", xCount);
                gdbPledges.Caption = String.Format("Залоги - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));

                Boolean xPermission = xCount == 0;
                for (int i = 0; i < dpPledges.CustomHeaderButtons.Count; i++)
                    if (i != (int)PanelButton.btInsert)
                        dpPledges.CustomHeaderButtons[i].Properties.Enabled = !xPermission;
               
            }
            else
                if (dsMain.Tables.Contains("tsPledges")) dsMain.Tables["tsPledges"].Clear();
           
        }
        public virtual void refreshListPokaz()
        {
            //splashScreenManager.ShowWaitForm();;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsPokaz"].Rows.Count;
                dpPokaz.TabText = String.Format("({0}) Показатели",xCount);
                gbPokaz.Caption = String.Format("Показатели - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));

                Boolean xPermission = xCount == 0;
                for (int i=0; i<dpPokaz.CustomHeaderButtons.Count; i++)                
                    if (i != (int)PanelButton.btInsert)
                        dpPokaz.CustomHeaderButtons[i].Properties.Enabled = !xPermission;
                
               
            }
            else
                if (dsMain.Tables.Contains("tsPokaz")) dsMain.Tables["tsPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        public virtual void refreshListExtraPokaz()
        {
            //splashScreenManager.ShowWaitForm();;
            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);

            Int32 loan_sid = getCurrentID("tsCredits", "LOAN_SID");

            if (loan_sid > 0)
            {
                db.getReadListExtraPokaz(ref dsMain, FilterDateTime.Date, loan_sid);
                Int32 xCount = dsMain.Tables["tsExtraPokaz"].Rows.Count;
                dpExtraPokaz.TabText = String.Format("({0}) Доп.показатель", xCount);
                gbExtraPokaz.Caption = String.Format("Доп.показатели - {0}", getCurrentName("tsCredits", "CUSTOMER_NAME"));

                Boolean xPermission = xCount == 0;
                for (int i = 0; i < dpExtraPokaz.CustomHeaderButtons.Count; i++)
                    if (i != (int)PanelButton.btInsert)
                        dpExtraPokaz.CustomHeaderButtons[i].Properties.Enabled = !xPermission;               
            }
            else
                if (dsMain.Tables.Contains("tsExtraPokaz")) dsMain.Tables["tsExtraPokaz"].Clear();

            //splashScreenManager.CloseWaitForm();
        }
        #region [GET urrent Data]
        private Int32 getCurrentID(String sTable, String sField)
        {
            Int32 result = -1;
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToInt32(row[sField]);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = -1;
            }
            return result;
        }
        private String getCurrentName(String sTable, String sField)
        {
            String result = "";
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToString(row[sField]);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = "";
            }
            return result;
        }
        private String getCurrentShortDate(String sTable, String sField)
        {
            String result = "";
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToDateTime(row[sField]).ToShortDateString();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                result = "";
            }
            return result;
        }
        private DateTime getCurrentReportDate(String sTable, String sField)
        {
            DateTime result = new DateTime();
            DataRow row = null;
            CurrencyManager ManagerTable = null;

            // Создаем менеджера таблицы
            try
            {
                ManagerTable = (CurrencyManager)this.BindingContext[dsMain, sTable];
                row = (ManagerTable.Current as DataRowView).Row;
                result = Convert.ToDateTime(row[sField]);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //result = -1;
            }
            return result;
        }

        #endregion

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*dpSheduler.Text = String.Format("[{0}-{1}]", getCurrentShortDate("tsPaymentPlan", "RP_BEGIN_DATE"),
                getCurrentShortDate("tsPaymentPlan", "RP_END_DATE"));*/
        }

        private void pBottomContainer_Click(object sender, EventArgs e)
        {

        }
        private enum PanelButton
        {
            btDelete = 0,
            btEdit = 1,
            btInsert = 2,
            btView = 3
        }
       
        private void dpPokaz_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            
            NewCreditImpPokaz nciPokaz = new NewCreditImpPokaz(
                Convert.ToDateTime(Convert.ToDateTime(beData.EditValue.ToString()).Date),
                getCurrentName("tsCredits", "ref_no"),
                getCurrentID("tsCredits", "loan_sid"),
                getCurrentName("tsCredits", "contract_no"),

                getCurrentID("tsPokaz", "pokaz_id"),
                getCurrentName("tsPokaz", "dim_name"),
                getCurrentName("tsPokaz", "dim_part"),
                getCurrentID("tsPokaz", "abs_dimension_id"),            
                getCurrentName("tsPokaz", "code_pokaz"),
                getCurrentName("tsPokaz", "name_pokaz")
                );
                /*int choice(DevExpress.XtraBars.Docking2010.ButtonEventArgs ee)
                {
                    int i = -1;
                    for (i = 0; i < dpPokaz.CustomHeaderButtons.Count; i++)
                        if (ee.Button == dpPokaz.CustomHeaderButtons[i])
                            break;

                    //MessageBox.Show(i.ToString());
                    return i;
                }*/
            switch (choice(dpPokaz, e))
            {
                case (int)PanelButton.btDelete:
                    {
                       if (
                          XtraMessageBox.Show(
                            LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                            LangTranslate.UiGetText("Удаление показателя"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            nciPokaz.Delete();
                        };
                        break;
                    }
                case (int)PanelButton.btEdit:
                    {
                        nciPokaz.State = ServiceLayer.Service.Editor.EditorState.Edit;
                        nciPokaz.Text = "Изменить показатель";
                        nciPokaz.Update();
                        
                        break;
                    }
                case (int)PanelButton.btInsert:
                    {
                        nciPokaz.State = ServiceLayer.Service.Editor.EditorState.Insert;
                        nciPokaz.Text = "Добавить показатель";
                        nciPokaz.Insert();
                        break;
                    }
                case (int)PanelButton.btView:
                    {
                        nciPokaz.State = ServiceLayer.Service.Editor.EditorState.View;
                        nciPokaz.Text = "Просмотр показателя";
                        nciPokaz.View();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("default");
                        break;
                    }
            }
            refreshListPokaz();
        }

        private void dpExtraPokaz_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            NewCreditImpExtraPokaz nciExtraPokaz = new NewCreditImpExtraPokaz(
             getCurrentID("tsCredits", "loan_sid"),
             getCurrentName("tsCredits", "contract_no"),
             getCurrentName("tsCredits", "ref_no"),

            Convert.ToDateTime(Convert.ToDateTime(beData.EditValue.ToString()).Date),
            getCurrentName("tsPokaz", "dim_name"),
            getCurrentName("tsPokaz", "dim_part"),
            getCurrentID("tsPokaz", "abs_dimension_id"),
            getCurrentID("tsExtraPokaz", "abs_constant_dimension_id"),
            getCurrentID("tsExtraPokaz", "abs_constant_loans_map_id"),
            getCurrentID("tsPokaz", "pokaz_id"),
            getCurrentName("tsExtraPokaz", "map_value"),
            getCurrentName("tsPokaz", "code_pokaz"),
            getCurrentName("tsPokaz", "name_pokaz")
            );
            switch (choice(dpExtraPokaz, e))
            {
                case (int)PanelButton.btDelete:
                    {
                        if (
                           XtraMessageBox.Show(
                             LangTranslate.UiGetText("Вы действительно хотите удалить запись?"),
                             LangTranslate.UiGetText("Удаление показателя"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            nciExtraPokaz.Delete();
                        };
                        break;
                    }
                case (int)PanelButton.btEdit:
                    {
                        nciExtraPokaz.State = ServiceLayer.Service.Editor.EditorState.Edit;
                        nciExtraPokaz.Text = "Изменить дополнительный показатель";
                        nciExtraPokaz.Update();
                        break;
                    }
                case (int)PanelButton.btInsert:
                    {
                        nciExtraPokaz.State = ServiceLayer.Service.Editor.EditorState.Insert;
                        nciExtraPokaz.Text = "Добавить дополнительного показателя";
                        nciExtraPokaz.Insert();
                        break;
                    }
                case (int)PanelButton.btView:
                    {
                        nciExtraPokaz.State = ServiceLayer.Service.Editor.EditorState.View;
                        nciExtraPokaz.Text = "Просмотр дополнительного показателя";
                        nciExtraPokaz.View();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("default");
                        break;
                    }
            }
            refreshListExtraPokaz();
        }
        private int choice(DevExpress.XtraBars.Docking.DockPanel dp, DevExpress.XtraBars.Docking2010.ButtonEventArgs ee)
        {
            int i = -1;
            for (i = 0; i < dp.CustomHeaderButtons.Count; i++)
                if (ee.Button == dp.CustomHeaderButtons[i])
                    break;

            //MessageBox.Show(i.ToString());
            return i;
        }
        private void dpPledges_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (choice(dpPledges, e))
            {
                case (int)PanelButton.btDelete:
                    {
                        MessageBox.Show("Delete");
                        break;
                    }
                case (int)PanelButton.btEdit:
                    {
                        MessageBox.Show("Edit");
                        break;
                    }
                case (int)PanelButton.btInsert:
                    {
                        MessageBox.Show("Insert");
                        break;
                    }
                case (int)PanelButton.btView:
                    {
                        MessageBox.Show("View");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("default");
                        break;
                    }
            }
            refreshListPledges();
        }

        private void bbFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Boolean filtered = bgvCredits.OptionsView.ShowAutoFilterRow;
            if (filtered)
            {
                bgvCredits.ClearColumnsFilter();
                bbFilter.Glyph = Properties.Resources.filter;
            }
            else
                bbFilter.Glyph = Properties.Resources.filter_disable;
            bgvCredits.OptionsView.ShowAutoFilterRow = !filtered;
        }

        private void bbSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean finded = bgvCredits.OptionsFind.AlwaysVisible;
            if (finded) bgvCredits.ApplyFindFilter("");
            bgvCredits.OptionsFind.AlwaysVisible = !finded;
        }

        private void bbExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportXML(1);
        }
        void ExportXML(int type)
        {
            String getXML( DateTime p_date_)
            {
                String result;
                using (OracleCommand cmd = dmControler.frmMain.oracleConnection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "prepared.proc_xml_create_list";
                        cmd.BindByName = true;

                        cmd.Parameters.Add("xml", OracleDbType.Clob, ParameterDirection.Output);
                        cmd.Parameters.Add("type_xml", OracleDbType.Decimal, type, ParameterDirection.Input);
                        cmd.Parameters.Add("report_date_", OracleDbType.Date, p_date_, ParameterDirection.Input);
                        //cmd.Parameters.Add("err_code", OracleDbType.Int16, ParameterDirection.Output);
                        //cmd.Parameters.Add("err_msg", OracleDbType.Clob, ParameterDirection.Output);
                        cmd.ExecuteNonQuery();
                        //result = ((OracleString)cmd.Parameters["xml"].Value).ToString(); //(String)xml.Value; 
                        result = ((Oracle.ManagedDataAccess.Types.OracleClob)cmd.Parameters["xml"].Value).Value;
                        return result;
                    }
                    catch (Exception oe)
                    {                       
                        //MessageBox.Show(oe.Message);
                        DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "prepared.pkg_xml_generation.p_01_test_generate_xml\n " + p_date_.ToString());
                        return "error get XML";
                    }
                }
            }
            void createDataXML(String path)
            {
                String XML = String.Empty;
                XML = getXML(Convert.ToDateTime(beData.EditValue.ToString()).Date);

                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
                writer.Write(XML);
                writer.Close();
            }
            void createManifestXML(String mfile)
            {

                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
                writerSettings.CloseOutput = false;
                MemoryStream localMemoryStream = new MemoryStream();

                using (XmlWriter writer = XmlWriter.Create(mfile, writerSettings))
                {                    
                    writer.WriteStartElement("manifest");
                    writer.WriteElementString("product", "CREDIT");
                    writer.WriteElementString("report_date", Convert.ToDateTime(beData.EditValue.ToString()).ToString("dd.MM.yyyy"));
                    writer.WriteElementString("respondent", "913");
                    writer.WriteEndElement();
                    writer.Flush();

                }
            }
            void AddZip(String sfileName, String mFileName)
            {
                FileInfo fi1 = new FileInfo(sfileName);
                FileInfo fi2 = new FileInfo(mFileName);               
               
                String stype = String.Empty;
                switch (type)
                {
                    case 1: stype = "ChinaBankCredits"; break;
                    case 2: stype = "ChinaBankPayments"; break;
                }

                String zipFileName = String.Format("{0}-[{1}]-{2}.zip", stype, Convert.ToDateTime(beData.EditValue.ToString()).Date.ToString("dd-MM-yyyy"), DateTime.Now.ToString("HHmmss"));
                String zippath = String.Format("{0}\\{1}", fi1.DirectoryName, zipFileName);

                using (ZipFile zip = new ZipFile())
                {
                    zip.Comment = "China Bank of Kazakhstan ";
                    zip.AddFile(sfileName, "");
                    zip.AddFile(mFileName, "");

                    try
                    {
                        zip.Save(zippath);
                        File.Delete(sfileName);
                        File.Delete(mFileName);
                        if (XtraMessageBox.Show(
                                LangTranslate.UiGetText("Вы хотите посмотреть XML в архиве?"),
                                LangTranslate.UiGetText("Открытие"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            openInExplorer(zippath);
                        }

                    }
                    catch (Exception oe)
                    {
                        MessageBox.Show("Error: create zip \n" + oe.Message);
                    }

                }

            }
            void openInExplorer(string path)
            {
                string cmd = "explorer.exe";
                string arg = "/select, " + path;
                Process.Start(cmd, arg);
            }

            String s = beData.EditValue.ToString();
            DateTime FilterDateTime = Convert.ToDateTime(s);
           
            using (XtraSaveFileDialog saveFileDialog1 = new XtraSaveFileDialog())
            {
                saveFileDialog1.Filter = "XML FILE|*.xml";
                saveFileDialog1.Title = "Save an XML File";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        splashScreenManager.ShowWaitForm();
                        String sfileName = saveFileDialog1.FileName;
                        FileInfo fi = new FileInfo(sfileName);
                        String mFileName = String.Format("{0}\\{1}", fi.DirectoryName, "usci_manifest.xml");

                        createDataXML(sfileName);
                        createManifestXML(mFileName);
                        AddZip(sfileName, mFileName);
                    }
                    catch (Exception oe)
                    {
                        MessageBox.Show("Error: " + oe.Message);
                    }
                    finally
                    {
                        splashScreenManager.CloseWaitForm();
                    }
                }
            }
            
        }

        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshListCredits();
        }

        private void beData_EditValueChanged(object sender, EventArgs e)
        {
            refreshListCredits();
        }

        private void dpSheduler_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (choice(dpSheduler, e))
            {
                case 0:
                    {
                        ExportXML(2);
                        break;
                    }
            }
        }

        private void bbExpXMLMenu_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(bbExpXMLMenu.Caption);
        }

        private void bbCredits_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbExpXMLMenu.Caption = "Кредит XML";
            ExportXML(1);
        }

        private void bbSheduler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbExpXMLMenu.Caption = "График XML";
            ExportXML(2);
        }
    }
}
