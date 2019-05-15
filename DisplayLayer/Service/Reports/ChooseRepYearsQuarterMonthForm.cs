using System;
using System.Windows.Forms;
using BSB.Common;
using DevExpress.XtraEditors;
using ARM_User.MapperLayer.Common;
using BSB.Common.DB;
using ARM_User.BusinessLayer.Reports;

namespace ARM_User.DisplayLayer.Service
{
    public partial class ChooseRepYearsQuarterMonthForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal yearsId;
  //  protected String nameYears, nameQuartesrs;
    public DateTime DBegin, DEnd;//, DateNow;
    protected YearsQuarterMonth years;
    protected Quarters quartesrs;
    protected Months months;
/*
    int m = DateTime.Today.Month; //месяц
    int d = DateTime.Today.Day; //день
    int y = DateTime.Today.Year; //год
    int quarter;            
*/
    public ChooseRepYearsQuarterMonthForm()
    {
      InitializeComponent();



      //BindingSource YearsBS = new BindingSource();
     
      //luYears.Properties.DataSource = YearsBS;
      //YearsBS.DataSource = MapperRegistry.Instance.GetYearsQuarterMonthMapper().FindByCondition(0);


      //BindingSource QuartersBS = new BindingSource();

      //luQuarter.Properties.DataSource = QuartersBS;
      //QuartersBS.DataSource = MapperRegistry.Instance.GetQuartersMapper().FindByCondition(1);

      //BindingSource MonthsBS = new BindingSource();

      //luMonth.Properties.DataSource = MonthsBS;
      //MonthsBS.DataSource = MapperRegistry.Instance.GetMonthsMapper().FindByCondition(2);
    
    }
    //string yearNow = DateTime.Now.ToString("yyyy");
    private void btnOk_Click(object sender, EventArgs e)
    {
      isValid = true;
      {
        if (rbYears.Checked == true)
          {
              if (luYears.Text == null)
              {
                  isValid = false;
                  XtraMessageBox.Show(LangTranslate.UiGetText("Выберите год"), LangTranslate.UiGetText("Информация"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
              }
          }
        if (rbQuarter.Checked == true)
          {
              if (luQuarter.Text == null)
              {
                  isValid = false;
                  XtraMessageBox.Show(LangTranslate.UiGetText("Выберите квартал"), LangTranslate.UiGetText("Информация"),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
              }
          }
        if (rbMonth.Checked == true)
        {
            if (luQuarter.Text == null)
            {
                isValid = false;
                XtraMessageBox.Show(LangTranslate.UiGetText("Выберите месяц"), LangTranslate.UiGetText("Информация"),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        if (rbPeriod.Checked == true)
        {
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
        }
      }
   
      DialogResult = DialogResult.OK;
      Close();
    }

   
    private void ChooseRepYearsQuarterMonthForm_Load(object sender, EventArgs e)
    {
        var oldCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        {
            try
            {
                #region YEAR
                BindingSource YearsBS = new BindingSource();
              //  nameYears = y.ToString();
                
                luYears.Properties.DataSource = YearsBS;
                YearsBS.DataSource = MapperRegistry.Instance.GetYearsQuarterMonthMapper().FindByCondition(0);
                //luYears.Text = nameYears;
                #endregion YEAR

                #region QUARTER
                /*
                quarter = 0;

                if (m >= 1 && m <= 3) quarter = 1;
                if (m >= 4 && m <= 6) quarter = 2;
                if (m >= 7 && m <= 9) quarter = 3;
                if (m >= 10 && m <= 12) quarter = 4;

                string quarter2 = null;
                if (quarter == 1) quarter2 = "I";
                if (quarter == 2) quarter2 = "II";
                if (quarter == 3) quarter2 = "III";
                if (quarter == 4) quarter2 = "IV";

                nameQuartesrs = quarter2.ToString() + " - " + nameYears;
                */
                BindingSource QuartersBS = new BindingSource();
                luQuarter.Properties.DataSource = QuartersBS;
                QuartersBS.DataSource = MapperRegistry.Instance.GetQuartersMapper().FindByCondition(1);
                //luQuarter.Text = nameQuartesrs;
                #endregion QUARTER

                #region MONTH
                BindingSource MonthsBS = new BindingSource();

                luMonth.Properties.DataSource = MonthsBS;
                MonthsBS.DataSource = MapperRegistry.Instance.GetMonthsMapper().FindByCondition(2);
                #endregion MONTH

                //  months = MapperRegistry.Instance.GetMonthsMapper().Find(4);
                //luMonth.Text = months.NameRu;   

                #region PERIODS
                 edDateBegin.DateTime = DateTime.Now;
                 edDateEnd.DateTime = DateTime.Now;
                #endregion PERIODS

            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ChooseRepYearsQuarterMonthForm)");
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

      
    }

    private void luYears_EditValueChanged(object sender, EventArgs e)
    {
        if (rbYears.Checked == true)
        {

            years = MapperRegistry.Instance.GetYearsQuarterMonthMapper().Find((decimal)luYears.EditValue);
            DBegin = (DateTime)years.Year;  
            DEnd = (DateTime)years.YearEnd; 
        }
    }

    private void rbYears_CheckedChanged(object sender, EventArgs e)
    {
        luYears.Enabled = true;
        luMonth.Enabled = false;
        luQuarter.Enabled = false;
        edDateBegin.Enabled = false;
        edDateEnd.Enabled = false;
    }

    private void rbQuarter_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = true;
        luMonth.Enabled = false;
        luYears.Enabled = false;
        edDateBegin.Enabled = false;
        edDateEnd.Enabled = false;
        /*if (quarter == 1)
        {
            DBegin = Convert.ToDateTime("01.01." + y);
            DEnd = Convert.ToDateTime("31.03." + y);
        }
        if (quarter == 2)
        {
            DBegin = Convert.ToDateTime("01.04." + y);
            DEnd = Convert.ToDateTime("30.06." + y);
        }
        if (quarter == 3)
        {
            DBegin = Convert.ToDateTime("01.07." + y);
            DEnd = Convert.ToDateTime("30.09." + y);
        }
        if (quarter == 4)
        {
            DBegin = Convert.ToDateTime("01.10." + y);
            DEnd = Convert.ToDateTime("31.12." + y);
        }*/
    }

    private void rbMonth_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = false;
        luMonth.Enabled = true;
        luYears.Enabled = false;
        edDateBegin.Enabled = false;
        edDateEnd.Enabled = false;
    }

    private void rbPeriod_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = false;
        luMonth.Enabled = false;
        luYears.Enabled = false;
        edDateBegin.Enabled = true;
        edDateEnd.Enabled = true;
    }

    private void luQuarter_EditValueChanged(object sender, EventArgs e)
    {
        if (rbQuarter.Checked == true)
        {
            
            quartesrs = MapperRegistry.Instance.GetQuartersMapper().Find((decimal)luQuarter.EditValue);
            DBegin = (DateTime)quartesrs.Quarter;
            DEnd = (DateTime)quartesrs.QuarterEnd;
        }
    }

    private void luMonth_EditValueChanged(object sender, EventArgs e)
    {
        if (rbMonth.Checked == true)
        {

            months = MapperRegistry.Instance.GetMonthsMapper().Find((decimal)luMonth.EditValue);
            DBegin = (DateTime)months.Month;
            DEnd = (DateTime)months.MonthEnd;
        }
    }

    private void edDateBegin_EditValueChanged(object sender, EventArgs e)
    {
        if (rbPeriod.Checked == true)
        {
            DBegin = edDateBegin.DateTime;
        }
    }

    private void edDateEnd_EditValueChanged(object sender, EventArgs e)
    {
        if (rbPeriod.Checked == true)
        {
            DEnd = edDateEnd.DateTime;
        }
    }

  
  
    
  }
}