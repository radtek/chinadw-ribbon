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
using System.Data;
using ARM_User.BusinessLayer.Reports;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using BSB.Common.DataGateway.Oracle;
using Oracle.DataAccess.Client;

namespace ARM_User.DisplayLayer.Service
{
  public partial class ChooseRepYearQuarterForm : ParametersForOutputForm
  {
    protected bool isValid;
    protected Decimal yearsId;
    protected Decimal isReported;
    //protected String NameYears;
    public DateTime DBegin,DEnd,DateNow;
    protected YearsQuarterMonth years;
    protected Quarters quartesrs;
    protected Months months;

    public ChooseRepYearQuarterForm()
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
    public Decimal IsReported
    {
        get { return isReported; }
    }
   
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
       
        
      }
   
      DialogResult = DialogResult.OK;
      Close();
    }

   
    private void ChooseRepYearQuarterForm_Load(object sender, EventArgs e)
    {
        var oldCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        {
            try
            {

                BindingSource YearsBS = new BindingSource();

                luYears.Properties.DataSource = YearsBS;
                YearsBS.DataSource = MapperRegistry.Instance.GetYearsQuarterMonthMapper().FindByCondition(0);
              //  DateNow = DateTime.Now;

               // years = MapperRegistry.Instance.GetYearsQuarterMonthMapper().Find(4);
                //luYears.Text = years.NameRu;
               // DateTime dt7 = Convert.ToDateTime(DateNow);
               // NameYears = dt7.Year.ToString();
                //luYears.Text = NameYears;


                BindingSource QuartersBS = new BindingSource();

                luQuarter.Properties.DataSource = QuartersBS;
                QuartersBS.DataSource = MapperRegistry.Instance.GetQuartersMapper().FindByCondition(1);
               //  quartesrs = MapperRegistry.Instance.GetQuartersMapper().Find(4);
               //  luQuarter.Text = quartesrs.NameRu;

                BindingSource MonthsBS = new BindingSource();

               
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ChooseRepYearQuarterForm)");
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
        luQuarter.Enabled = false;
       
    }

    private void rbQuarter_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = true;
        luYears.Enabled = false;
        
    }

    private void rbMonth_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = false;
        luYears.Enabled = false;
        
    }

    private void rbPeriod_CheckedChanged(object sender, EventArgs e)
    {
        luQuarter.Enabled = false;
        luYears.Enabled = false;
       
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

    private void cbIsReported_EditValueChanged(object sender, EventArgs e)
    {
        isReported = cbIsReported.SelectedIndex;
    }

 
  

  
  
    
  }
}