using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using BSB.Common;

namespace ARM_User.Common
{
    public partial class XtraLogonDlgForm : DevExpress.XtraEditors.XtraUserControl
    {
        public String LogonUsername;
        public String LogonPassword;
        public String LogonDatabase;
        public String LogonHost;
        public String connString;
        public bool isOK = false;

        private IDictionary<String, String> dbhosts = new Dictionary<String, String>();
        private String file = String.Format("{0}\\host.bin", Directory.GetCurrentDirectory());
        private int hform;

        public XtraLogonDlgForm()
        {
            InitializeComponent();
            FileSaveOrLoad();
            hform = Height;
            lchost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            LoadLastValues();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        private void FileSaveOrLoad()
        {
            
            if (File.Exists(file))
                dbhosts = Read(file);
            else
            {
                //IDictionary<String, String> db = new Dictionary<String, String>();
                dbhosts.Add(new KeyValuePair<String, String>("DWH", "21.233.128.158"));
                dbhosts.Add(new KeyValuePair<String, String>("ORCLXE", "localhost"));
                Write(dbhosts, file);                
            }
            loadDBList();
            teSid.SelectedIndex = 0;
        }

        private void loadDBList()
        {
            teSid.Properties.Items.Clear();
            foreach (KeyValuePair<String, String> x in dbhosts)
                teSid.Properties.Items.Add(x.Key);

        }
        #region SelectedValueChanged for teSid

        #endregion
        #region EditValueChanged for teHost
        private void teHost_EditValueChanged(object sender, EventArgs e)
        {
            string skey = teSid.Text;
            dbhosts[skey] = teHost.Text;
        }
        #endregion
        #region Button Click for teSid
        private void teSid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            String skey = teSid.Text.Trim();
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                if (e.Button.Caption == "host")
                {
                    //XtraMessageBox.Show("Button click" + e.Button);
                    DevExpress.XtraLayout.Utils.LayoutVisibility statehost = lchost.Visibility;
                    if (statehost == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
                    {
                        lchost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                    else
                    {
                        //Height = hform - lchost.Height;
                        lchost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }

                    teHost.Text = dbhosts[skey];

                }
                else if (e.Button.Caption == "add")
                {

                    if (!dbhosts.ContainsKey(skey) && skey.Length > 0)
                    {
                        dbhosts.Add(skey, "");
                        //teSid.Text = String.Empty;
                        teSid.SelectedItem = skey;
                        teHost.Text = string.Empty;
                        VisibilyButton(skey);
                    }

                }
                loadDBList();
            }

        }
        #endregion
        #region SelectedIndexChanged for teSid
        private void teSid_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cBox = sender as ComboBoxEdit;

            string skey = teSid.Text;
            string sValue = teHost.Text;

            if (cBox.SelectedIndex != -1)
                teHost.Text = dbhosts[skey];
            else loadDBList();

        }
        #endregion 
        #region ContextButtonClick for teSid
        private void teSid_Properties_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {

            String scaption = e.DataItem.ToString();
            String smsg = String.Format("Вы хотите удалить  {0}?", scaption);
            if (XtraMessageBox.Show(smsg, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbhosts.Remove(scaption);
                string skey = teSid.Text;
                teSid.Text = dbhosts.ContainsKey(skey) ? skey : String.Empty;
            }
            loadDBList();
        }
        #endregion
        #region KeyUp for teSid
        private void teSid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XtraMessageBox.Show("Click enter");
            }
        }
        #endregion
        #region Work file
        static void Write(IDictionary<String, String> dictionary, string file)
        {
            using (FileStream fs = File.OpenWrite(file))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                //Put count
                writer.Write(dictionary.Count);
                // Write pairs.
                foreach (var pair in dictionary)
                {
                    writer.Write(pair.Key);
                    writer.Write(pair.Value);
                }
            }
        }

        private void teSid_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            String s = teSid.SelectedText;
            VisibilyButton(s);
        }
        private void VisibilyButton(String sdbkey)
        {
            bool xExistKey = dbhosts.ContainsKey(sdbkey);
            teSid.Properties.Buttons[2].Visible = xExistKey;
            teSid.Properties.Buttons[1].Visible = !xExistKey;
            // lchost.Visibility = xExistKey ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        static IDictionary<String, String> Read(string file)
        {
            var result = new Dictionary<String, String>();
            using (FileStream fs = File.OpenRead(file))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                // Get count
                int count = reader.ReadInt32();
                // Read in all pairs.
                for (int i = 0; i < count; i++)
                {
                    string key = reader.ReadString();
                    string value = reader.ReadString();
                    result[key] = value;
                }
            }
            return result;
        }

        #endregion

        private void sbCancel_Click(object sender, EventArgs e)
        {
            isOK = false;
            this.Parent.Hide();
        }

        private void sbSignIn_Click(object sender, EventArgs e)
        {
            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                LogonDatabase = teSid.Text.Trim();
                LogonPassword = tePassword.Text;
                LogonUsername = teUser.Text.ToUpper().Trim();
                LogonHost = dbhosts[LogonDatabase];

                int port = 1521;
                String formatConnString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = {0} )(PORT = {1}))" +
                    "(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = {2}))); Password={3};User ID={4}";
                connString = String.Format(formatConnString, LogonHost, port, LogonDatabase.ToUpper(), LogonPassword, LogonUsername);

                // Save to Window regisrty
                if (isSaveToRegistry.Checked)
                {
                    SaveLastValues();
                }
                isOK = true;
                Write(dbhosts, file);
                this.Parent.Hide();
            }


        }



        private void sbSignIn_DoubleClick(object sender, EventArgs e)
        {
            // MessageBox.Show("dfgfsgfg");
        }


        /// <summary>
        ///   Загружаем значения БД и Login из реестра пользователя Windows
        /// </summary>
        private void LoadLastValues()
        {
            var reg = InitApplication.RegSetupRoot.OpenSubKey(InitApplication.RegAppKey, true);
            if (reg == null)
                reg = InitApplication.RegSetupRoot.CreateSubKey(InitApplication.RegAppKey);

            if (reg != null)
            {
                if (reg.GetValue("ProductName") == null)
                    reg.SetValue("ProductName", InitApplication.ProductName);

                if (reg.GetValue("AppName") == null)
                    reg.SetValue("AppName", InitApplication.AppName);

                if (reg.GetValue("LogonDatabase") != null)
                    LogonDatabase = reg.GetValue("LogonDatabase").ToString();

                if (reg.GetValue("LogonUsername") != null)
                    LogonUsername = reg.GetValue("LogonUsername").ToString();

                teSid.Text = LogonDatabase;
                teUser.Text = LogonUsername;

                /*if (edLogin.Text == "SUPERUSER")
                    edPassword.Text = "Qwerty_12345";*/
            }
        }

        /// <summary>
        ///   Сохраняем значения БД и Login в реестре пользователя Windows
        /// </summary>
        private void SaveLastValues()
        {
            var reg = InitApplication.RegSetupRoot.OpenSubKey(InitApplication.RegAppKey, true);
            if (reg == null)
                reg = InitApplication.RegSetupRoot.CreateSubKey(InitApplication.RegAppKey);

            if (reg != null)
            {
                reg.SetValue("LogonDatabase", LogonDatabase);
                reg.SetValue("LogonUsername", LogonUsername);
            }
        }

        private void XtraLogonDlgForm_Validating(object sender, CancelEventArgs e)
        {
            //e.Cancel = verify();
        }


        bool Validation(Control control, String msg, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                e.Cancel = true;
                control.Focus();
                dxErrorProvider1.SetError(control, msg);
                return true;
            }
            else
            {
                e.Cancel = false;
                dxErrorProvider1.SetError(control, null);
                return false;
            }
        }
        private void teUser_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validation(teUser, "Пожалуйста, введите имя пользователя", e);
        }
        private void teSid_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validation(teSid, "Пожалуйста, выберите базу", e);
        }

        private void tePassword_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validation(tePassword, "Пожалуйста, введите пароль", e);
        }

        private void teHost_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validation(teHost, "Пожалуйста, введите IP адрес базы", e);
        }

        private void XtraLogonDlgForm_Validated(object sender, EventArgs e)
        {
            MessageBox.Show("All success!");
        }

        private void teSid_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void teUser_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) || e.KeyChar != '\b')
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                }
                else if (e.KeyChar == '_') {
                    e.KeyChar = '_';
                } else
            e.KeyChar = '\0';
           
        }

        private void XtraLogonDlgForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter )
            {
                sbSignIn_Click(sender, e);
            }
        }

        private void teSid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbSignIn_Click(sender, e);
            }
        }

        private void teUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbSignIn_Click(sender, e);
            }
        }

        private void tePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (Console.CapsLock)
                lcText.Text = "Caps Look is on.";            
            else lcText.Text = String.Empty;
            if (e.KeyCode == Keys.Enter)
            {
                sbSignIn_Click(sender, e);
            }
        }

        private void teHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbSignIn_Click(sender, e);
            }
        }
    }
}