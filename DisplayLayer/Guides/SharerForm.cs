using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Base;
using ARM_User.ServiceLayer.Service.Editor;
using System.Windows.Forms;
using ARM_User.DisplayLayer.Popup;
using DevExpress.XtraEditors;
using BSB.Common;

namespace ARM_User.DisplayLayer.Guides
{
    public partial class SharerForm : SimpleDBEditGBForm
    {
        protected Sharer sharer;

        public SharerForm()
        {
            InitializeComponent();
            if (!UnitOfWork.Instance.IsTransactionStarted)
            UnitOfWork.Instance.BeginTransaction();
            sharer = Sharer.CreateNew();
            State = EditorState.Insert;
        }

        public SharerForm(Sharer sharer, EditorState state)
        {
            InitializeComponent();
            this.state = state;
            if (State == EditorState.Edit)
            {
                if (!UnitOfWork.Instance.IsTransactionStarted)
                UnitOfWork.Instance.BeginTransaction();
            }
            this.sharer = sharer;
        }

        public Sharer Sharer
        {
            get { return sharer; }
        }

        private void SharerForm_Load(object sender, EventArgs e)
        {
            if (Site != null) return;

            MainBS.Add(sharer);
            edNameRu.DataBindings.Add("EditValue", MainBS, "NameRu", true);
            edNameKz.DataBindings.Add("EditValue", MainBS, "NameKz", true);
            edIINBINOKPONumber.DataBindings.Add("EditValue", MainBS, "IIN_BIN_OKPO_NUMBER", true);
            beDocknd.DataBindings.Add("EditValue", MainBS, "DocKnd.NameRu", true);
            edNumDoc.DataBindings.Add("EditValue", MainBS, "DocNumUdLich", true);
            edDocDate.DataBindings.Add("EditValue", MainBS, "DocDate", true);
            cbDel.DataBindings.Add("EditValue", MainBS, "IsDelete", true);
            wdDateLast.DataBindings.Add("EditValue", MainBS, "EditTime", true);
            wdUserName.DataBindings.Add("EditValue", MainBS, "EditUser", true);

            readOnlyControls.Add(wdDateLast);
            readOnlyControls.Add(wdUserName);

            SetEditorsStatus();

            foreach (Control control in readOnlyControls)
                EditorUtils.ReadOnlyControl(control, true);

            if (State == EditorState.Insert)
                Text = LangTranslate.UiGetText("Ввод новых реквизитов справочника \"Акционеры\"");
            else if (State == EditorState.Edit)
                Text = LangTranslate.UiGetText("Редактирование реквизитов справочника \"Акционеры\"");
        }

        protected override bool Validate()
        {
            if (string.IsNullOrEmpty(sharer.NameRu) || string.IsNullOrWhiteSpace(sharer.NameRu))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Наименование (рус) не заполнено"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edNameRu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(sharer.NameKz) || string.IsNullOrWhiteSpace(sharer.NameKz))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Наименование (каз) не заполнено"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edNameKz.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(sharer.IIN_BIN_OKPO_NUMBER) || string.IsNullOrWhiteSpace(sharer.IIN_BIN_OKPO_NUMBER))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("ИИН/БИН/ОКПО/Номер гос.рег. не заполнен"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edIINBINOKPONumber.Focus();
                return false;
            }
            if (beDocknd.Text == "")
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Вид документа не выбран"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                beDocknd.Focus();
                return false;
            }
            
            return true;
        }

        private void beDocknd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           

        }
        
    }
}