using System;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using ARM_User.Reports;
using ARM_User.ServiceLayer.Reporting;
using BSB.Common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using ARM_User.ServiceLayer.Reporting.Excel;
using BSB.Common.DB;

/*
 Authors: Tolebi Baimenov, Nurlan Ryskeldi, Zhandos Iskakov
 */
namespace ARM_User.DisplayLayer.Service
{
  public partial class MakeReportsForm : MDIChildForm
  {
    
    public MakeReportsForm()
    {
        InitializeComponent();

    }
    private decimal id_kind;
  
    private void MakeReportsBaseForm_Load(object sender, EventArgs e)
    {
      if (Site != null) return;
      
      btnRefresh.PerformClick();
    }

    private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
    {
        var ReportKnd = id_kind;

        var oldCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        if (ReportKnd != 0)
        {
            try
            {
                formsBS.DataSource = MapperRegistry.Instance.GetRepFormMapper().FindBylist(ReportKnd);
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.MakeReportsForm)");
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }
        else
          formsBS.DataSource = MapperRegistry.Instance.GetRepFormMapper().FindAll();
    }

    private void btnMake_ItemClick(object sender, ItemClickEventArgs e)
    {
      var form = (RepForm) formsBS.Current;
      if (form.Code.Equals("testword2"))
      {
          new TestWordReport(form, LanguageIds.Russian, DateTime.Now, DateTime.Now).ShowReport();
      }
      else  if (form.Code.Equals("form1"))
      {
          new TestReport(form, LanguageIds.Russian, DateTime.Now, DateTime.Now).ShowReport();
      }
      #region Tolebi
      else if (form.Code.Equals("G_REP_SHARES"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepShares1(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_KDR"))
      {
          var frm2 = new ChooseRepRegionDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
             // var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepKDR(form, LanguageIds.Russian, reportDate1, /*reportDate2,*/ gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_ICB"))
      {
          var frm2 = new ChooseRepRegionDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              //var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepICB(form, LanguageIds.Russian, reportDate1, /*reportDate2,*/ gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_KDR_REPAYMENT"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepKDRRepayment(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_ICB_REPAYMENT"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepICBRepayment(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_PAI"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepPai(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_BOND"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepBond(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_SHARE_PRICE"))
      {
          var frm2 = new ChooseIsHaveTechForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var gHaveTech = frm2.HaveTech;
              new RepSharePrice(form, LanguageIds.Russian, gHaveTech).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_TIME_SUBMISSION"))
      {
          var frm2 = new ChooseRepRegionPeriodDenialForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gtypeSecurities = frm2.TypeSecurities;
              var gUsers = frm2.Users;
              new RepTimeSubmission(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion,gtypeSecurities, gUsers).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_CNT_STATE_SERVICES"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepCntStateServices(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_BOND_LIST_LEGAL_ENTITIES"))
      {
          var frm2 = new ChooseRepDateRegionForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              var gRegion = frm2.Region;
              new RepBondListLegalEntities(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_CORPORATIONS_REG_SHARES"))
      {
          var frm2 = new ChooseRepDateRegionForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              var gRegion = frm2.Region;
              new RepCorporationsRegShares(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_FUNDS_REG_PAI"))
      {
          var frm2 = new ChooseRepDateRegionForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              var gRegion = frm2.Region;
              new RepListFundsRegPai(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_FUNDS_REG_PAI_2"))
      {
          var frm2 = new ChooseRepRegPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              new RepListFundsRegPai2(form, InitApplication.CurrentLangId, reportDate1, reportDate2, gRegion).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_ISSUERS_SHARES"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListIssuersShares(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_CANCEL_SHARES"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListCancelShares(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_STATUS_ISSUE_SHARES"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepStatusIssueShares(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_JUR_REPAYMENT_BOND"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListJurRepaymentBond(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_JUR_ANNUL_BOND"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListJurAnnulBond(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_STATE_BOND_ISSUE"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepStatusBondIssue(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_FUNDS_PLACEMENT_PAI"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListFundsPalcementPai(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_INF_MUTUAL_FUNDS"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepInfMutualFunds(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_11_KDR_PLACEMENT"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepForm11KDRPlacement(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_13_KDR_ANNUL"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepForm13KDRAnnul(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_11_ICB_CONFIRM_REP"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepForm11ICBConfirmRep(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_13_ICB_SUBM_REP"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepForm13ICBSubmRep(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_15_ICB_REPAYMENT"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepForm15ICBRepayment(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_GCB_1_NIN"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormGCB1NIN(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_A19_LIST_ISSUERS"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormA19ListIssuers(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }

      else if (form.Code.Equals("G_REP_FORM_A20_LIST_ISSUERS_CO"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormA20ListIssuersCO(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_A23_LIST_ISSUERS"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormA23ListIssuers(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_ISSUERS_ANNUL_ISI"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListIssuersAnnulISI(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("g_rep_20_from_xml"))
      {
          var frm2 = new ChooseRepYearsQuarterMonthForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DBegin;
              var reportDate2 = frm2.DEnd;
             // new RepChangesCntIssuers(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              new Rep20FromXML(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_REESTR_PAI"))
      {
          new RepReestrPai(form, InitApplication.CurrentLangId, 60).ShowReport();
      }
      else if (form.Code.Equals("G_REP_CERTIFICATE_REG_SHARE"))
      {
          new RepCertificateRegShare(form, InitApplication.CurrentLangId, 626).ShowReport();
      }
      else if (form.Code.Equals("G_REP_INF_AO_SIZE_UK"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepInfAOSizeUK(form, LanguageIds.Russian, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_DR_02"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormDR02(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }

      else if (form.Code.Equals("G_REP_REESTR_SHARE"))
      {
          new RepReestrShare(form, InitApplication.CurrentLangId, 625).ShowReport();
      }
      else if (form.Code.Equals("G_REP_REESTR_BONDS"))
      {
          new RepReestrBonds(form, InitApplication.CurrentLangId, 256).ShowReport();
      }
      else if (form.Code.Equals("G_REP_REESTR_BONDS_PROGRAMM"))
      {
          new RepReestrBondsProgramm(form, InitApplication.CurrentLangId, 256).ShowReport();
      }
      else if (form.Code.Equals("G_REP_REESTR_BONDS_WITHIN_BP"))
      {
          new RepReestrBondsWithinBP(form, InitApplication.CurrentLangId, 256).ShowReport();
      }
      else if (form.Code.Equals("G_REP_REESTR_IS"))
      {
          new RepReestrIS(form, LanguageIds.Russian, 50).ShowReport();
      }
      else if (form.Code.Equals("G_REP_INF_ISSUE_DEFAULT"))
      {
          new RepInfIssueDefault(form, InitApplication.CurrentLangId, 262).ShowReport();
      }
      else if (form.Code.Equals("G_REP_12_INF_FACTS_BOND"))
      {
          var frm2 = new ChooseRepYearQuarterForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DBegin;
              var reportDate2 = frm2.DEnd;
              var reported = frm2.IsReported;
              new Rep12InfFactsBond(form, LanguageIds.Russian, reportDate1, reportDate2, reported).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_DEFAULT2"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListDefault(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("g_rep_75_from_xml"))
      {
          var frm2 = new ChooseRepYearsQuarterMonthForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DBegin;
              var reportDate2 = frm2.DEnd;
              // new RepChangesCntIssuers(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              new Rep75FromXML(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_DATES_OMV_EXEC"))
      {
          var frm2 = new ChooseRepOMVExecForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var rDt1 = frm2.Date1;
              var rDt2 = frm2.Date2;
              var rDt3 = frm2.Date3;
              var rDt4 = frm2.Date4;
              var rDt5 = frm2.Date5;
              var rDt6 = frm2.Date6;
              var idSts = frm2.TypeSecurities;
              var idUsr = frm2.Users;
              var idOMV = frm2.KndOMV;
              new RepDateOMVExec(form, LanguageIds.Russian, rDt1, rDt2, rDt3, rDt4, rDt5, rDt6,idOMV,idUsr,idSts).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_ADM_OFFENSE"))
      {
          var frm2 = new ChooseRepADMOffenseForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var rDt1 = frm2.Date1;
              var rDt2 = frm2.Date2;
             
              var idSts = frm2.TypeSecurities;
              var idUsr = frm2.Users;
              var idSanc = frm2.KndSanc;
              var idKoAP = frm2.KoAP;
              new RepADMOffense(form, LanguageIds.Russian, rDt1, rDt2, idSanc,idKoAP, idUsr, idSts).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_ENFORCE_MEASURE"))
      {
          var frm2 = new ChooseRepEnforceMeasureForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var rDt1 = frm2.Date1;
              var rDt2 = frm2.Date2;
              var idSts = frm2.TypeSecurities;
              var idUsr = frm2.Users;
              var idIssuer = frm2.Emitent;
              new RepEnforceMeasure(form, LanguageIds.Russian, rDt1, rDt2, idIssuer, idUsr, idSts).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_SANCTIONS"))
      {
          var frm2 = new ChooseRepSanctionsForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var rDt1 = frm2.Date1;
              var rDt2 = frm2.Date2;

              var idDecision = frm2.TypeSecurities;
              var idUsr = frm2.Users;
              var idIssuer = frm2.Emitent;
              new RepSanctions(form, LanguageIds.Russian, rDt1, rDt2, idIssuer, idUsr, idDecision).ShowReport();
              return;
          }
      }
    #endregion Tolebi  
    #region Nurlan
    else if (form.Code.Equals("SGREADOFSHARES"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepShares1(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_PAI"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepPai(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_BOND"))
      {
          var frm2 = new ChooseRepRegionPeriodForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRegion = frm2.Region;
              var gCancelConfirmRep = frm2.CancelConfirmRep;
              new RepBond(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_SHARE_PIECE"))
      {
          var frm2 = new ChooseRepDateProportionForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var gRepProportion = frm2.RepProportion;
              new RepShareProportion(form, LanguageIds.Russian, reportDate1, gRepProportion).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_PLACE_ACCOMMODATION"))
      {
          var frm2 = new ChooseRepDatePlaceAccomForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRepPlaceAccom = frm2.RepPlaceAccom;
              new RepPlaceAccom(form, LanguageIds.Russian, reportDate1, reportDate2, gRepPlaceAccom).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_BOND_INF_REPRESEN"))
      {
          var frm2 = new ChooseRepRegionBankCustForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
             
              var gRepBondInfRepresenReg = frm2.Region;
              var gRepBondInfRepresenUsr = frm2.IdUsr;
              var gRepBondInfRepresenBC = frm2.IdBankCust;
              new RepBondInfRepresen(form, LanguageIds.Russian, gRepBondInfRepresenReg, gRepBondInfRepresenUsr, gRepBondInfRepresenBC).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_INF_INTRODUCTION_AIP"))
      {
          var frm2 = new ChooseRepPeriodUsrForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              var gRepBondInfRepresenUsr = frm2.IdUsr;
              new RepInfIntraductionAIP(form, LanguageIds.Russian, gRepBondInfRepresenUsr, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_SUM_ISSUE_SECUR"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepSIS(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_INF_REG_ISS_SECUR_S"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepInfRegIssSecur(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_JS_COMP_REP_SHARE_P"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListJSCompRepShareP(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_JS_COMP_REP_SHARE_D"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListJSCompRepShareD(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_AUTHORIZED_SECUR"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListAuthorizedSecur(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_JUR_REP_BOND"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepListJurRepBond(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_LIST_CANCEL_BOND_ISSUE"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepListCancelBondIssue(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_O_18_LIST_BOND_PROG"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormO18ListBondProg(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_P12_LIST_FUND_PLACE"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormP12ListFundPlace(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
         else if (form.Code.Equals("G_REP_FORM_P14_LIST_FUND_CLOSE"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormP14ListFundClose(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_KRD10_LIST_REG_ISS"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormKDR10ListRegIss(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_KDR12"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormKDR12(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I12"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormI12(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I14"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormI14(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I18"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormI18(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_A25"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormA25(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_INF_INVESTMENT_FUNDS"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepInfInvestmentFunds(form, LanguageIds.Russian, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_REESTR_KDR"))
      {
         // var Id_KDR_ = 106;
          new RepReestrKDR(form, InitApplication.CurrentLangId, 0).ShowReport();

          //var frm2 = new ChooseDateForm();
          //if (frm2.ShowDialog() == DialogResult.OK)
          //{
          //    var reportDate1 = frm2.Date;
          //    new RepInfInvestmentFunds(form, LanguageIds.Russian, reportDate1).ShowReport();
          //    return;
          //}
      }
      else if (form.Code.Equals("G_REP_ANNUL_REG_SHARE"))
      {
         // var Id_Share = 619;
          new RepAnnulRegShare(form, InitApplication.CurrentLangId, 619).ShowReport();
      }
      else if (form.Code.Equals("G_REP_FORM_DR01"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormDR01(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_DR03"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormDR03(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_DR04"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormDR04(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I03"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormI03(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I16"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepFormI16(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_I10"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormI10(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_O10"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormO10(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_JOURNAL_OMV"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepJournalOMV(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_JOURNAL_VIOLATION"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepJournalViolation(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_CONSOLIDATED_VIOLATION"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepConsolidatedViolation(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_FORM_O11"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepFormO11(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_DEFAULT_INFO"))
      {
          var frm2 = new ChooseDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.Date;
              new RepDefaultInfo(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_CARD_NIN_GCB"))
      {
          new RepCardNINGCB(form, InitApplication.CurrentLangId, 161).ShowReport();
      }
      else if (form.Code.Equals("G_REP_BONDCHG_JOURNAL"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepBondChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_PAICHG_JOURNAL"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepPaiChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
      else if (form.Code.Equals("G_REP_SHARECHG_JOURNAL"))
      {
          var frm2 = new ChooseReportDateForm();
          if (frm2.ShowDialog() == DialogResult.OK)
          {
              var reportDate1 = frm2.DateBegin;
              var reportDate2 = frm2.DateEnd;
              new RepShareChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
              return;
          }
      }
    #endregion Nurlan

    }


    public object MainBS { get; set; }

    private void luTypeReport_EditValueChanged(object sender, EventArgs e)
    {
        btnRefresh.PerformClick();
        id_kind = cbTypeReport.SelectedIndex;
        if (id_kind == -1)
            id_kind = 0;
        btnRefresh.PerformClick();
    }

    private void gcForms_DoubleClick(object sender, EventArgs e)
    {
        var form = (RepForm)formsBS.Current;
        if (form.Code.Equals("testword2"))
        {
            new TestWordReport(form, LanguageIds.Russian, DateTime.Now, DateTime.Now).ShowReport();
        }
        else if (form.Code.Equals("form1"))
        {
            new TestReport(form, LanguageIds.Russian, DateTime.Now, DateTime.Now).ShowReport();
        }
        #region Tolebi
        else if (form.Code.Equals("G_REP_SHARES"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepShares1(form, LanguageIds.Russian, reportDate1, reportDate2,gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_KDR"))
        {
            var frm2 = new ChooseRepRegionDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
               // var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepKDR(form, LanguageIds.Russian, reportDate1, /*reportDate2, */gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_ICB"))
        {
            var frm2 = new ChooseRepRegionDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                //var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepICB(form, LanguageIds.Russian, reportDate1,/* reportDate2,*/ gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_KDR_REPAYMENT"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepKDRRepayment(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_ICB_REPAYMENT"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepICBRepayment(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_PAI"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepPai(form, LanguageIds.Russian, reportDate1, reportDate2,gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_BOND"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepBond(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_SHARE_PRICE"))
        {
            var frm2 = new ChooseIsHaveTechForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var gHaveTech = frm2.HaveTech;
                new RepSharePrice(form, LanguageIds.Russian, gHaveTech).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_TIME_SUBMISSION"))
        {
            var frm2 = new ChooseRepRegionPeriodDenialForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gtypeSecurities = frm2.TypeSecurities;
                var gUsers = frm2.Users;
                new RepTimeSubmission(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gtypeSecurities, gUsers).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_CNT_STATE_SERVICES"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepCntStateServices(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_BOND_LIST_LEGAL_ENTITIES"))
        {
            var frm2 = new ChooseRepDateRegionForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                var gRegion = frm2.Region;
                new RepBondListLegalEntities(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_CORPORATIONS_REG_SHARES"))
        {
            var frm2 = new ChooseRepDateRegionForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                var gRegion = frm2.Region;
                new RepCorporationsRegShares(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_CORPORATIONS_REG_SHARES2"))
        {
            var frm2 = new ChooseRepRegPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                new RepCorporationsRefShares2(form, InitApplication.CurrentLangId, reportDate1, reportDate2, gRegion).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_FUNDS_REG_PAI"))
        {
            var frm2 = new ChooseRepDateRegionForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                var gRegion = frm2.Region;
                new RepListFundsRegPai(form, InitApplication.CurrentLangId, reportDate1, gRegion).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_ISSUERS_SHARES"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListIssuersShares(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_CANCEL_SHARES"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListCancelShares(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_STATUS_ISSUE_SHARES"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepStatusIssueShares(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_JUR_REPAYMENT_BOND"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListJurRepaymentBond(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_JUR_ANNUL_BOND"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListJurAnnulBond(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_STATE_BOND_ISSUE"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepStatusBondIssue(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_FUNDS_PLACEMENT_PAI"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListFundsPalcementPai(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_INF_MUTUAL_FUNDS"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepInfMutualFunds(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_11_KDR_PLACEMENT"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepForm11KDRPlacement(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_13_KDR_ANNUL"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepForm13KDRAnnul(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_11_ICB_CONFIRM_REP"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepForm11ICBConfirmRep(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_13_ICB_SUBM_REP"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepForm13ICBSubmRep(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_15_ICB_REPAYMENT"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepForm15ICBRepayment(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_GCB_1_NIN"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormGCB1NIN(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_A19_LIST_ISSUERS"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormA19ListIssuers(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }

        else if (form.Code.Equals("G_REP_FORM_A20_LIST_ISSUERS_CO"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormA20ListIssuersCO(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_A23_LIST_ISSUERS"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormA23ListIssuers(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_ISSUERS_ANNUL_ISI"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListIssuersAnnulISI(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("g_rep_20_from_xml"))
        {
            var frm2 = new ChooseRepYearsQuarterMonthForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DBegin;
                var reportDate2 = frm2.DEnd;
                // new RepChangesCntIssuers(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                new Rep20FromXML(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_REESTR_PAI"))
        {
            new RepReestrPai(form, InitApplication.CurrentLangId, 60).ShowReport();
        }
        else if (form.Code.Equals("G_REP_CERTIFICATE_REG_SHARE"))
        {
            new RepCertificateRegShare(form, InitApplication.CurrentLangId, 626).ShowReport();
        }
        else if (form.Code.Equals("G_REP_INF_AO_SIZE_UK"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepInfAOSizeUK(form, LanguageIds.Russian, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_DR_02"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormDR02(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }

        else if (form.Code.Equals("G_REP_REESTR_SHARE"))
        {
            new RepReestrShare(form, InitApplication.CurrentLangId, 625).ShowReport();
        }
        else if (form.Code.Equals("G_REP_REESTR_BONDS"))
        {
            new RepReestrBonds(form, InitApplication.CurrentLangId, 256).ShowReport();
        }
        else if (form.Code.Equals("G_REP_REESTR_BONDS_PROGRAMM"))
        {
            new RepReestrBondsProgramm(form, InitApplication.CurrentLangId, 256).ShowReport();
        }
        else if (form.Code.Equals("G_REP_REESTR_BONDS_WITHIN_BP"))
        {
            new RepReestrBondsWithinBP(form, InitApplication.CurrentLangId, 256).ShowReport();
        }
        else if (form.Code.Equals("G_REP_REESTR_IS"))
        {
            new RepReestrIS(form, LanguageIds.Russian, 50).ShowReport();
        }
        else if (form.Code.Equals("G_REP_INF_ISSUE_DEFAULT"))
        {
            new RepInfIssueDefault(form, InitApplication.CurrentLangId, 262).ShowReport();
        }
        else if (form.Code.Equals("G_REP_12_INF_FACTS_BOND"))
        {
            var frm2 = new ChooseRepYearQuarterForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DBegin;
                var reportDate2 = frm2.DEnd;
                var reported = frm2.IsReported;
                new Rep12InfFactsBond(form, LanguageIds.Russian, reportDate1, reportDate2, reported).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_DEFAULT2"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListDefault(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("g_rep_75_from_xml"))
        {
            var frm2 = new ChooseRepYearsQuarterMonthForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DBegin;
                var reportDate2 = frm2.DEnd;
                // new RepChangesCntIssuers(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                new Rep75FromXML(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_DATES_OMV_EXEC"))
        {
            var frm2 = new ChooseRepOMVExecForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var rDt1 = frm2.Date1;
                var rDt2 = frm2.Date2;
                var rDt3 = frm2.Date3;
                var rDt4 = frm2.Date4;
                var rDt5 = frm2.Date5;
                var rDt6 = frm2.Date6;
                var idSts = frm2.TypeSecurities;
                var idUsr = frm2.Users;
                var idOMV = frm2.KndOMV;
                new RepDateOMVExec(form, LanguageIds.Russian, rDt1, rDt2, rDt3, rDt4, rDt5, rDt6, idOMV, idUsr, idSts).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_ADM_OFFENSE"))
        {
            var frm2 = new ChooseRepADMOffenseForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var rDt1 = frm2.Date1;
                var rDt2 = frm2.Date2;

                var idSts = frm2.TypeSecurities;
                var idUsr = frm2.Users;
                var idSanc = frm2.KndSanc;
                var idKoAP = frm2.KoAP;
                new RepADMOffense(form, LanguageIds.Russian, rDt1, rDt2, idSanc, idKoAP, idUsr, idSts).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_ENFORCE_MEASURE"))
        {
            var frm2 = new ChooseRepEnforceMeasureForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var rDt1 = frm2.Date1;
                var rDt2 = frm2.Date2;

                var idSts = frm2.TypeSecurities;
                var idUsr = frm2.Users;
                var idIssuer = frm2.Emitent;
                new RepEnforceMeasure(form, LanguageIds.Russian, rDt1, rDt2, idIssuer, idUsr, idSts).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_SANCTIONS"))
        {
            var frm2 = new ChooseRepSanctionsForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var rDt1 = frm2.Date1;
                var rDt2 = frm2.Date2;

                var idDecision = frm2.TypeSecurities;
                var idUsr = frm2.Users;
                var idIssuer = frm2.Emitent;
                new RepSanctions(form, LanguageIds.Russian, rDt1, rDt2, idIssuer, idUsr, idDecision).ShowReport();
                return;
            }
        }
        #endregion Tolebi
        #region Nurlan
        else if (form.Code.Equals("SGREADOFSHARES"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepShares1(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_PAI"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepPai(form, LanguageIds.Russian, reportDate1,reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_BOND"))
        {
            var frm2 = new ChooseRepRegionPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                var gCancelConfirmRep = frm2.CancelConfirmRep;
                new RepBond(form, LanguageIds.Russian, reportDate1, reportDate2, gRegion, gCancelConfirmRep).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_SHARE_PIECE"))
        {
            var frm2 = new ChooseRepDateProportionForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var gRepProportion = frm2.RepProportion;
                new RepShareProportion(form, LanguageIds.Russian, reportDate1, gRepProportion).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_PLACE_ACCOMMODATION"))
        {
            var frm2 = new ChooseRepDatePlaceAccomForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRepPlaceAccom = frm2.RepPlaceAccom;
                new RepPlaceAccom(form, LanguageIds.Russian, reportDate1, reportDate2, gRepPlaceAccom).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_BOND_INF_REPRESEN"))
        {
            var frm2 = new ChooseRepRegionBankCustForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {

                var gRepBondInfRepresenReg = frm2.Region;
                var gRepBondInfRepresenUsr = frm2.IdUsr;
                var gRepBondInfRepresenBC = frm2.IdBankCust;
                new RepBondInfRepresen(form, LanguageIds.Russian, gRepBondInfRepresenReg, gRepBondInfRepresenBC, gRepBondInfRepresenUsr).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_INF_INTRODUCTION_AIP"))
        {
            var frm2 = new ChooseRepPeriodUsrForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRepBondInfRepresenUsr = frm2.IdUsr;
                new RepInfIntraductionAIP(form, LanguageIds.Russian, gRepBondInfRepresenUsr, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_SUM_ISSUE_SECUR"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepSIS(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_INF_REG_ISS_SECUR_S"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepInfRegIssSecur(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_JS_COMP_REP_SHARE_P"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListJSCompRepShareP(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_JS_COMP_REP_SHARE_D"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListJSCompRepShareD(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_AUTHORIZED_SECUR"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListAuthorizedSecur(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_JUR_REP_BOND"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepListJurRepBond(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_CANCEL_BOND_ISSUE"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepListCancelBondIssue(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_O_18_LIST_BOND_PROG"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormO18ListBondProg(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_P12_LIST_FUND_PLACE"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormP12ListFundPlace(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_P14_LIST_FUND_CLOSE"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormP14ListFundClose(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_KRD10_LIST_REG_ISS"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormKDR10ListRegIss(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_KDR12"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormKDR12(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I12"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormI12(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I14"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormI14(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I18"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormI18(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_A25"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormA25(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_INF_INVESTMENT_FUNDS"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepInfInvestmentFunds(form, LanguageIds.Russian, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_REESTR_KDR"))
        {
            // var Id_KDR_ = 106;
            new RepReestrKDR(form, InitApplication.CurrentLangId, 106).ShowReport();

            //var frm2 = new ChooseDateForm();
            //if (frm2.ShowDialog() == DialogResult.OK)
            //{
            //    var reportDate1 = frm2.Date;
            //    new RepInfInvestmentFunds(form, LanguageIds.Russian, reportDate1).ShowReport();
            //    return;
            //}
        }
        else if (form.Code.Equals("G_REP_ANNUL_REG_SHARE"))
        {
            // var Id_Share = 619;
            new RepAnnulRegShare(form, InitApplication.CurrentLangId, 619).ShowReport();
        }
        else if (form.Code.Equals("G_REP_FORM_DR01"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormDR01(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_DR03"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormDR03(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_DR04"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormDR04(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I03"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormI03(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I16"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepFormI16(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_I10"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormI10(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_O10"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormO10(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_JOURNAL_OMV"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepJournalOMV(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_JOURNAL_VIOLATION"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepJournalViolation(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_CONSOLIDATED_VIOLATION"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepConsolidatedViolation(form, LanguageIds.Russian, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_FORM_O11"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepFormO11(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_DEFAULT_INFO"))
        {
            var frm2 = new ChooseDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.Date;
                new RepDefaultInfo(form, InitApplication.CurrentLangId, reportDate1).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_CARD_NIN_GCB"))
        {
            new RepCardNINGCB(form, InitApplication.CurrentLangId, 161).ShowReport();
        }
        #endregion Nurlan        
        else if (form.Code.Equals("G_REP_SHARECHG_JOURNAL"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepShareChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_BONDCHG_JOURNAL"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepBondChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_PAICHG_JOURNAL"))
        {
            var frm2 = new ChooseReportDateForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                new RepPaiChgJournal(form, InitApplication.CurrentLangId, reportDate1, reportDate2).ShowReport();
                return;
            }
        }
        else if (form.Code.Equals("G_REP_LIST_FUNDS_REG_PAI_2"))
        {
            var frm2 = new ChooseRepRegPeriodForm();
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                var reportDate1 = frm2.DateBegin;
                var reportDate2 = frm2.DateEnd;
                var gRegion = frm2.Region;
                new RepListFundsRegPai2(form, InitApplication.CurrentLangId, reportDate1, reportDate2, gRegion).ShowReport();
                return;
            }
        }
    }

    private void cbTypeReport_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}