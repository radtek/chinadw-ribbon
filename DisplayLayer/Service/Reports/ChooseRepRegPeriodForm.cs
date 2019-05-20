using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ARM_User.DisplayLayer.Popup;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using ARM_User.BusinessLayer.Common;
using BSB.Common.DB;


namespace ARM_User.DisplayLayer.Service
{
    public partial class ChooseRepRegPeriodForm : ARM_User.DisplayLayer.Service.ParametersForOutputForm
    {
        protected bool isValid;
        protected Decimal idRegion;

        public ChooseRepRegPeriodForm()
        {
            InitializeComponent();
            BindingSource RegionBS = new BindingSource();
            luRegion.Properties.DataSource = RegionBS;
           // RegionBS.DataSource = MapperRegistry.Instance.GetRegionMapper().FindByCondition(3);
        }

        public DateTime DateBegin
        {
            get { return edDateBegin.DateTime; }
        }

        public DateTime DateEnd
        {
            get { return edDateEnd.DateTime; }
        }
#pragma warning disable CS0108 // 'ChooseRepRegPeriodForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
        public Decimal Region
#pragma warning restore CS0108 // 'ChooseRepRegPeriodForm.Region' hides inherited member 'Control.Region'. Use the new keyword if hiding was intended.
        {
            get { return idRegion; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            isValid = true;
            if (edDateBegin.EditValue == null)
            {
                isValid = false;
                XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату начало"), LangTranslate.UiGetText("Информация"),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (edDateEnd.EditValue == null)
            {
                isValid = false;
                XtraMessageBox.Show(LangTranslate.UiGetText("Укажите дату конец "), LangTranslate.UiGetText("Информация"),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void luRegion_EditValueChanged(object sender, EventArgs e)
        {
            idRegion = (decimal)luRegion.EditValue;
        }

        private void ChooseRepRegPeriodForm_Load(object sender, EventArgs e)
        {
            edDateBegin.DateTime = DateTime.Now;
            edDateEnd.DateTime = DateTime.Now;
        }
    }
}
