using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DisplayLayer.Base;
using ARM_User.ServiceLayer.Service.Editor;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BSB.Common;

namespace ARM_User.DisplayLayer.Guides
{
    public partial class CurrencyECBForm : SimpleDBEditGBForm
    {
        protected CurrencyECB currencyecb;

        public CurrencyECBForm()
        {
            InitializeComponent();
            if (!UnitOfWork.Instance.IsTransactionStarted)
              UnitOfWork.Instance.BeginTransaction();
            currencyecb = CurrencyECB.CreateNew();
            State = EditorState.Insert;
       }

        public CurrencyECBForm(CurrencyECB currencyecb, EditorState state)
        {
            InitializeComponent();
            this.state = state;
            if (State == EditorState.Edit)
            {
                if (!UnitOfWork.Instance.IsTransactionStarted)
                    UnitOfWork.Instance.BeginTransaction();
            }
                this.currencyecb = currencyecb;
        }

        public CurrencyECB CurrencyECB
        {
            get { return currencyecb; }
        }

        private void CurrencyECBForm_Load(object sender, EventArgs e)
        {
            if (Site != null) return;

            MainBS.Add(currencyecb);
            edCode.DataBindings.Add("EditValue", MainBS, "Code", true);
            edDesig.DataBindings.Add("EditValue", MainBS, "Desig", true);
            edNameRu.DataBindings.Add("EditValue", MainBS, "Nameru", true);
            edNameKz.DataBindings.Add("EditValue", MainBS, "Namekz", true);
            cbDel.DataBindings.Add("EditValue", MainBS, "Isdelete", true);
            wdDateLast.DataBindings.Add("EditValue", MainBS, "EditTime", true);
            wdUserName.DataBindings.Add("EditValue", MainBS, "EditUser", true);

            readOnlyControls.Add(wdDateLast);
            readOnlyControls.Add(wdUserName);

            SetEditorsStatus();

            foreach (Control control in readOnlyControls)
                EditorUtils.ReadOnlyControl(control, true);

            if (State == EditorState.Insert)
                Text = LangTranslate.UiGetText4("Ввод новых реквизитов справочника \"Коды для обозначения валют и фондов\"");                
            else if (State == EditorState.Edit)
                Text = LangTranslate.UiGetText4("Редактирование реквизитов справочника \"Коды для обозначения валют и фондов\"");                                
        }

        protected override bool Validate()
        {
            if (string.IsNullOrEmpty(currencyecb.Code) || string.IsNullOrWhiteSpace(currencyecb.Code))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Код не заполнен"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(currencyecb.Desig) || string.IsNullOrWhiteSpace(currencyecb.Desig))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Обозначение для НИН не заполнено"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edDesig.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(currencyecb.Nameru) || string.IsNullOrWhiteSpace(currencyecb.Nameru))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Наименование (рус) не заполнено"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edNameRu.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(currencyecb.Namekz) || string.IsNullOrWhiteSpace(currencyecb.Namekz))
            {
                XtraMessageBox.Show(
                    LangTranslate.UiGetText("Наименование (каз) не заполнено"),
                    LangTranslate.UiGetText("Внимание"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edNameKz.Focus();
                return false;
            }
            return true;
        }
      }
}