using System;
using System.Collections.Generic;
using ARM_User.DataLayer.DataSet;
using ARM_User.DataLayer.DB.Gateway;
using BSB.Common.DataGateway;

namespace ARM_User.DataLayer.DB
{
  public class DBDataGatewayFactory : IDataGatewayFactory
  {
    #region Fields

    private readonly Dictionary<Type, IDataGateway> store = new Dictionary<Type, IDataGateway>();

    #endregion

    #region Constructors

    public DBDataGatewayFactory()
    {
      #region Simple Guides

      store.Add(typeof(SharedDS.REF_SHAREDDataTable), new SharedGateway());
      store.Add(typeof(LocalTextDS.REF_LOCAL_TEXTDataTable), new LocalTextGateway());
      store.Add(typeof(FundkndDS.S_G_FUNDKNDDataTable), new FundkndGateway());
      store.Add(typeof(IssueECBDS.S_G_FORM_ISSUE_ECBDataTable), new IssueECBGateway());
      store.Add(typeof(CurrencyECBDS.S_G_CURRENCY_ECBDataTable), new CurrencyECBGateway());
      store.Add(typeof(IssuersGuidesDS.G_JUR_PERSONDataTable), new IssuersGuidesGateway());
      store.Add(typeof(RegionDS.G_REGIONDataTable), new RegionGateway());
      store.Add(typeof(BankCustDS.S_G_BANKS_CUST_REPR_ECBDataTable), new BankCustGateway());
      store.Add(typeof(ClassifierOKEDDS.S_G_CLASSIFIER_OKEDDataTable), new ClassifierOKEDGateway());
      store.Add(typeof(SpecBusDS.S_G_SPEC_BUS_SECTORDataTable), new SpecBusGateway());
      store.Add(typeof(SignPartNoresDS.S_G_SIGN_PART_NORES_RK_UKDataTable), new SignPartNoresGateway());
      store.Add(typeof(CategoryControlsDS.S_G_CATEGORY_CONTROLSDataTable), new CategoryControlsGateway());
      store.Add(typeof(AddCategoryShareDS.S_G_ADD_CATEGORY_SHARESDataTable), new AddCategoryShareGateway());
      store.Add(typeof(CategoryECBDS.S_G_CATEGORY_ECBDataTable), new CategoryECBGateway());
      store.Add(typeof(IndexRewardsDS.S_G_INDEX_REWARDSDataTable), new IndexRewardsGateway());
      store.Add(typeof(SpecIssuerDS.S_G_SPEC_ISSUERDataTable), new SpecIssuerGateway());
      store.Add(typeof(AbilityConvertDS.S_G_ABILITY_CONVERTDataTable), new AbilityConvertGateway());
      store.Add(typeof(KindECBDS.S_G_KIND_ECBDataTable), new KindECBGateway());
      store.Add(typeof(IssOrganControlDS.S_G_ISSUER_ORGAN_CONTROLDataTable), new IssOrganControlGateway());
      store.Add(typeof(DateTypeLocalDS.S_G_DATE_TYPE_LOCATIONDataTable), new DateTypeLocalGateway());
      store.Add(typeof(DocKndDS.S_G_DOCUMENT_KINDDataTable), new DocKndGateway());
      store.Add(typeof(ProcesskndDS.G_PROCESSKNDDataTable), new ProcesskndGateway());
      store.Add(typeof(ProcessDS.PROCESSDataTable), new ProcessGateway());
      store.Add(typeof(OLFDS.S_G_OLFDataTable), new OLFGateway());
      store.Add(typeof(ListingDS.S_G_LISTINGDataTable), new ListingGateway());
      store.Add(typeof(RatingDS.S_G_RATINGDataTable), new RatingGateway());
      store.Add(typeof(RegDS.S_G_REGISTRARSDataTable), new RegGateway());
      store.Add(typeof(AuditDS.S_G_AUDITORSDataTable), new AuditGateway());
      store.Add(typeof(JurPersCreateMethodDS.S_G_JUR_PERSON_CREATE_METHODDataTable), new JurPersCreateMethodGateway());
      store.Add(typeof(RegOrganMUDS.S_G_REG_ORGAN_MUDataTable), new RegOrganMUGateway());
      store.Add(typeof(BondDS.BONDDataTable), new BondGateway());
      store.Add(typeof(BondFoundersDS.BONDFOUNDERSDataTable), new BondFoundersGateway());
      store.Add(typeof(AppointmentDS.S_G_APPOINTMENTDataTable), new AppointmentGateway());
      store.Add(typeof(BondAppointmentDS.BondAppDataTable), new BondAppointmentGateway());
      store.Add(typeof(StateShareUKDS.S_G_STATE_SHARE_UKDataTable), new StateShareUKGateway());
      store.Add(typeof(RepKndDS.S_G_REPORT_KNDDataTable), new RepKndGateway());
      store.Add(typeof(SignatoryDS.S_G_SIGNATORYDataTable), new SignatoryGateway());
      store.Add(typeof(ExecutorDS.S_G_EXECUTORDataTable), new ExecutorGateway());
      store.Add(typeof(CatHolderEcbDS.S_G_CATEGORY_HOLDER_ECBDataTable), new CatHolderEcbGateway());
      store.Add(typeof(IssueStsECBDS.S_G_ISSUE_STS_ECBDataTable), new IssueStsECBGateway());
      store.Add(typeof(IssuersGCBDS.S_G_ISSUERS_GCBDataTable), new IssuersGCBGateway());
      store.Add(typeof(KindGCBDS.S_G_KIND_GCBDataTable), new KindGCBGateway());
      store.Add(typeof(DebtRepaymentDS.S_G_DEBT_REPAYMENTDataTable), new DebtRepaymentGateway());
      store.Add(typeof(StsReportDS.S_G_STATUS_REPORTDataTable), new StsReportGateway());
      store.Add(typeof(KindRegBondsDS.S_G_KIND_REGISTRY_BONDSDataTable), new KindRegBondsGateway());
      store.Add(typeof(ArticlesKOAPDS.S_G_ARTICLES_KOAPDataTable), new ArticlesKOAPGateway());
      store.Add(typeof(CauseChangesRepDS.S_G_CAUSE_CHANGES_REPORTDataTable), new CauseChangesRepGateway());
      store.Add(typeof(SuspensionDS.S_G_SUSPENSIONDataTable), new SuspensionGateway());
      store.Add(typeof(CountryDS.G_COUNTRYDataTable), new CountryGateway());
      store.Add(typeof(DecisionAdmOffencesDS.S_G_DECISION_ADM_OFFENCESDataTable), new DecisionAdmOffencesGateway());
      store.Add(typeof(CollectionFormDS.S_G_FORM_COLLECTIONDataTable), new CollectionFormGateway());
      store.Add(typeof(JurPersStsDS.S_G_JUR_PERSON_STATUSDataTable), new JurPersStsGateway());
      store.Add(typeof(ReasonAnnulECBDS.S_G_REASON_ANNUL_ECBDataTable), new ReasonAnnulECBGateway());
      store.Add(typeof(UnitDimPerECBDS.S_G_UNIT_DIMENSION_PERIOD_ECBDataTable), new UnitDimPerECBGateway());
      store.Add(typeof(MethodLocalECBDS.S_G_METHOD_LOCATION_ECBDataTable), new MethodLocalECBGateway());
      store.Add(typeof(PlaceAccommECBDS.S_G_PLACE_ACCOMMODATION_ECBDataTable), new PlaceAccommECBGateway());
      store.Add(typeof(ReasonChangeShareIssueDS.S_G_REASON_CHANGE_SHARE_ISSUEDataTable), new ReasonChangeShareIssueGateway());
      store.Add(typeof(StsStAccommECBDS.S_G_STATUS_STATE_ACCOMM_ECBDataTable), new StsStAccommECBGateway());
      store.Add(typeof(DecVerifInfDS.S_G_DECISION_VERIF_INF_RESPERDataTable), new DecVerifInfGateway());
      store.Add(typeof(BasePrescriptionDS.S_G_BASE_PRESCRIPTIONDataTable), new BasePrescriptionGateway());
      store.Add(typeof(ViolationKndDS.S_G_VIOLATION_KNDDataTable), new ViolationKndGateway());
      store.Add(typeof(OrganRegIssueECBDS.S_G_ORGAN_REGISTR_ISSUE_ECBDataTable), new OrganRegIssueECBGateway());
      store.Add(typeof(MRPDS.S_G_MRPDataTable), new MRPGateway());
      store.Add(typeof(ResolutionDRDS.S_G_RESOLUTION_DRDataTable), new ResolutionDRGateway());
      store.Add(typeof(StatusECBDS.S_G_STATUS_ECBDataTable), new StatusECBGateway());
      store.Add(typeof(StatusLicenseDS.S_G_LICENSE_STATUSDataTable), new StatusLicenseGateway());
      store.Add(typeof(CondMonitorValidDS.S_G_COND_MONITOR_VIOLATIONDataTable), new CondMonitorValidGateway());
      store.Add(typeof(SharerDS.S_G_SHARERDataTable), new SharerGateway());
      store.Add(typeof(ReasonSuspensionECBDS.S_G_REAS_SUSP_PLACE_APPEAL_ECBDataTable), new ReasonSuspensionECBGateway());
      store.Add(typeof(DecTreadCardDS.S_G_DECISION_TREADMENT_CARDDataTable), new DecTreadCardGateway());
      store.Add(typeof(ConfirmObjectDS.CONFIRM_OBJECTDataTable), new ConfirmObjectGateway());
      store.Add(typeof(BondRegistryDS.BOND_REGISTRYDataTable), new BondRegistryGateway());
      store.Add(typeof(BondFilterDS.BondFilterDataTable), new BondFilterGateway());
      

      #endregion

      #region Services

      store.Add(typeof (UserDS.UserDSDataTable), new UserGateway());
      store.Add(typeof (RightsItemDS._CURRENT_OFFICIAL_RIGHTS_DataTable), new RightsItemGateway());
      //store.Add(typeof(ShareidDS.ShareidDataTable), new ShareidGateway());
      #endregion

      /*#region Modules

      store.Add(typeof(ShareDS.S_SHAREDataTable), new ShareGateway());
      store.Add(typeof(ShareStructRelDS.S_SHARE_STRUCT_RELDataTable), new ShareStructRelGateway());
      store.Add(typeof(ShareFounderDS.S_SHARE_FOUNDERDataTable), new ShareFounderGateway());
      store.Add(typeof(ShareInfoOfficialDS.S_SHARE_INFO_OFFICIALSDataTable), new ShareInfoOfficialGateway());
      store.Add(typeof(ShareBureauInfoDS.S_SHARE_BUREAU_INFODataTable), new ShareBureauInfoGateway());      
      store.Add(typeof(ShareRegDS.S_SHARE_REGDataTable), new ShareRegIssueGateway());
      store.Add(typeof(ShareIssuersDS.S_SHAR_ISSUERSDataTable), new ShareIssuersGateway());
      store.Add(typeof(ShareChangesDS.S_SHARE_CHANGESDataTable), new ShareChangesGateway());      

      #endregion*/

      #region Filter

      store.Add(typeof(ShareFilterDS.S_SHARE_FILTERDataTable), new ShareFilterGateway());

      #endregion

      #region Confirm

      store.Add(typeof(ConfirmObjectDS.CONFIRM_OBJECTDataTable), new ConfirmObjectGateway());
      store.Add(typeof(ConfirmObjectStepDS.CONFIRM_OBJECT_STEPDataTable), new ConfirmObjectStepGateway());
      #endregion
    }

    #endregion

    #region Public methods

    public virtual IDataGateway GetGateway(Type type)
    {
      return store[type];
    }

    #endregion

    #region Guides
    public IDataGateway GetIssueECBGateway()
    {
        return GetGateway(typeof(IssueECBDS.S_G_FORM_ISSUE_ECBDataTable));
    }
    public IDataGateway GetCurrencyECBGateway()
    {
        return GetGateway(typeof(CurrencyECBDS.S_G_CURRENCY_ECBDataTable));
    }
    public IIssuerHstGateway GetIssuersGuidesGateway()
    {
        return (IIssuerHstGateway)GetGateway(typeof(IssuersGuidesDS.G_JUR_PERSONDataTable));
    }
    public IDataGateway GetFundkndGateway()
    {
        return GetGateway(typeof(FundkndDS.S_G_FUNDKNDDataTable));
    }
    public IDataGateway GetBankCustGateway()
    {
        return GetGateway(typeof(BankCustDS.S_G_BANKS_CUST_REPR_ECBDataTable));
    }
    public IDataGateway GetClassifierOKEDGateway()
    {
        return GetGateway(typeof(ClassifierOKEDDS.S_G_CLASSIFIER_OKEDDataTable));
    }
    public IDataGateway GetSpecBusGateway()
    {
        return GetGateway(typeof(SpecBusDS.S_G_SPEC_BUS_SECTORDataTable));
    }
    public IDataGateway GetSignPartNoresGateway()
    {
        return GetGateway(typeof(SignPartNoresDS.S_G_SIGN_PART_NORES_RK_UKDataTable));
    }
    public IDataGateway GetCategoryControlsGateway()
    {
        return GetGateway(typeof(CategoryControlsDS.S_G_CATEGORY_CONTROLSDataTable));
    }
    public IDataGateway GetSharedGateway()
    {
      return GetGateway(typeof (SharedDS.REF_SHAREDDataTable));
    }
    public IDataGateway GetRegionGateway()
    {
        return GetGateway(typeof(RegionDS.G_REGIONDataTable));
    }
    public IDataGateway GetLocalTextGateway()
    {
      return GetGateway(typeof (LocalTextDS.REF_LOCAL_TEXTDataTable));
    }
    public IDataGateway GetAddCategoryShareGateway()
    {
        return GetGateway(typeof(AddCategoryShareDS.S_G_ADD_CATEGORY_SHARESDataTable));
    }
    public IDataGateway GetCategoryECBGateway()
    {
        return GetGateway(typeof(CategoryECBDS.S_G_CATEGORY_ECBDataTable));
    }
    public IDataGateway GetIndexRewardsGateway()
    {
        return GetGateway(typeof(IndexRewardsDS.S_G_INDEX_REWARDSDataTable));
    }
    public IDataGateway GetSpecIssuerGateway()
    {
        return GetGateway(typeof(SpecIssuerDS.S_G_SPEC_ISSUERDataTable));
    }
    public IDataGateway GetAbilityConvertGateway()
    {
        return GetGateway(typeof(AbilityConvertDS.S_G_ABILITY_CONVERTDataTable));
    }
    public IDataGateway GetKindECBGateway()
    {
        return GetGateway(typeof(KindECBDS.S_G_KIND_ECBDataTable));
    }
    public IDataGateway GetIssOrganControlGateway()
    {
        return GetGateway(typeof(IssOrganControlDS.S_G_ISSUER_ORGAN_CONTROLDataTable));
    }
    public IDataGateway GetDateTypeLocalGateway()
    {
        return GetGateway(typeof(DateTypeLocalDS.S_G_DATE_TYPE_LOCATIONDataTable));
    }
    public IDataGateway GetDocKndGateway()
    {
        return GetGateway(typeof(DocKndDS.S_G_DOCUMENT_KINDDataTable));
    }
    public IDataGateway GetProcesskndGateway()
    {
        return GetGateway(typeof(ProcesskndDS.G_PROCESSKNDDataTable));
    }
    public IDataGateway GetProcessGateway()
    {
        return GetGateway(typeof(ProcessDS.PROCESSDataTable));
    }
    public IDataGateway GetOLFGateway()
    {
        return GetGateway(typeof(OLFDS.S_G_OLFDataTable));
    }
    public IDataGateway GetListingGateway()
    {
        return GetGateway(typeof(ListingDS.S_G_LISTINGDataTable));
    }
    public IDataGateway GetRatingGateway()
    {
        return GetGateway(typeof(RatingDS.S_G_RATINGDataTable));
    }
    public IDataGateway GetRegGateway()
    {
        return GetGateway(typeof(RegDS.S_G_REGISTRARSDataTable));
    }
    public IDataGateway GetAuditGateway()
    {
        return GetGateway(typeof(AuditDS.S_G_AUDITORSDataTable));
    }
    public IDataGateway GetJurPersCreateMethodGateway()
    {
        return GetGateway(typeof(JurPersCreateMethodDS.S_G_JUR_PERSON_CREATE_METHODDataTable));
    }
    public IDataGateway GetRegOrganMUGateway()
    {
        return GetGateway(typeof(RegOrganMUDS.S_G_REG_ORGAN_MUDataTable));
    }
   
    public IDataGateway GetAppointmentGateway()
    {
        return GetGateway(typeof(AppointmentDS.S_G_APPOINTMENTDataTable));
    }
    
    public IDataGateway GetStateShareUKGateway()
    {
      return GetGateway(typeof (StateShareUKDS.S_G_STATE_SHARE_UKDataTable));
    }
    public IDataGateway GetRepKndGateway()
    {
      return GetGateway(typeof (RepKndDS.S_G_REPORT_KNDDataTable));
    }
    public IDataGateway GetSignatoryGateway()
    {
      return GetGateway(typeof (SignatoryDS.S_G_SIGNATORYDataTable));
    }
    public IDataGateway GetExecutorGateway()
    {
      return GetGateway(typeof (ExecutorDS.S_G_EXECUTORDataTable));
    }
    public IDataGateway GetCatHolderEcbGateway()
    {
      return GetGateway(typeof (CatHolderEcbDS.S_G_CATEGORY_HOLDER_ECBDataTable));
    }
    public IDataGateway GetIssueStsECBGateway()
    {
      return GetGateway(typeof (IssueStsECBDS.S_G_ISSUE_STS_ECBDataTable));
    }
    public IDataGateway GetIssuersGCBGateway()
    {
      return GetGateway(typeof (IssuersGCBDS.S_G_ISSUERS_GCBDataTable));
    }
    public IDataGateway GetKindGCBGateway()
    {
      return GetGateway(typeof (KindGCBDS.S_G_KIND_GCBDataTable));
    }
    public IDataGateway GetDebtRepaymentGateway()
    {
      return GetGateway(typeof (DebtRepaymentDS.S_G_DEBT_REPAYMENTDataTable));
    }
    public IDataGateway GetStsReportGateway()
    {
      return GetGateway(typeof (StsReportDS.S_G_STATUS_REPORTDataTable));
    }
    public IDataGateway GetKindRegBondsGateway()
    {
      return GetGateway(typeof (KindRegBondsDS.S_G_KIND_REGISTRY_BONDSDataTable));
    }
    public IDataGateway GetArticlesKOAPGateway()
    {
      return GetGateway(typeof (ArticlesKOAPDS.S_G_ARTICLES_KOAPDataTable));
    }
    public IDataGateway GetCauseChangesRepGateway()
    {
      return GetGateway(typeof (CauseChangesRepDS.S_G_CAUSE_CHANGES_REPORTDataTable));
    }
    public IDataGateway GetSuspensionGateway()
    {
      return GetGateway(typeof (SuspensionDS.S_G_SUSPENSIONDataTable));
    }
    public IDataGateway GetCountryGateway()
    {
      return GetGateway(typeof (CountryDS.G_COUNTRYDataTable));
    }
    public IDataGateway GetDecisionAdmOffencesGateway()
    {
      return GetGateway(typeof (DecisionAdmOffencesDS.S_G_DECISION_ADM_OFFENCESDataTable));
    }
    public IDataGateway GetCollectionFormGateway()
    {
      return GetGateway(typeof (CollectionFormDS.S_G_FORM_COLLECTIONDataTable));
    }
    public IDataGateway GetJurPersStsGateway()
    {
        return GetGateway(typeof(JurPersStsDS.S_G_JUR_PERSON_STATUSDataTable));
    }
    public IDataGateway GetBasePrescriptionGateway()
    {
        return GetGateway(typeof(BasePrescriptionDS.S_G_BASE_PRESCRIPTIONDataTable));
    }
    public IDataGateway GetCondMonitorValidGateway()
    {
        return GetGateway(typeof(CondMonitorValidDS.S_G_COND_MONITOR_VIOLATIONDataTable));
    }
    public IDataGateway GetDecTreadCardGateway()
    {
        return GetGateway(typeof(DecTreadCardDS.S_G_DECISION_TREADMENT_CARDDataTable));
    }
    public IDataGateway GetDecVerifInfGateway()
    {
        return GetGateway(typeof(DecVerifInfDS.S_G_DECISION_VERIF_INF_RESPERDataTable));
    }
    public IDataGateway GetMethodLocalECBGateway()
    {
        return GetGateway(typeof(MethodLocalECBDS.S_G_METHOD_LOCATION_ECBDataTable));
    }
    public IDataGateway GetMRPGateway()
    {
        return GetGateway(typeof(MRPDS.S_G_MRPDataTable));
    }
    public IDataGateway GetOrganRegIssueECBGateway()
    {
        return GetGateway(typeof(OrganRegIssueECBDS.S_G_ORGAN_REGISTR_ISSUE_ECBDataTable));
    }
    public IDataGateway GetPlaceAccommECBGateway()
    {
        return GetGateway(typeof(PlaceAccommECBDS.S_G_PLACE_ACCOMMODATION_ECBDataTable));
    }
    public IDataGateway GetReasonAnnulECBGateway()
    {
        return GetGateway(typeof(ReasonAnnulECBDS.S_G_REASON_ANNUL_ECBDataTable));
    }
    public IDataGateway GetReasonChangeShareIssueGateway()
    {
        return GetGateway(typeof(ReasonChangeShareIssueDS.S_G_REASON_CHANGE_SHARE_ISSUEDataTable));
    }
    public IDataGateway GetReasonSuspensionECBGateway()
    {
        return GetGateway(typeof(ReasonSuspensionECBDS.S_G_REAS_SUSP_PLACE_APPEAL_ECBDataTable));
    }
    public IDataGateway GetResolutionDRGateway()
    {
        return GetGateway(typeof(ResolutionDRDS.S_G_RESOLUTION_DRDataTable));
    }
    public IDataGateway GetSharerGateway()
    {
        return GetGateway(typeof(SharerDS.S_G_SHARERDataTable));
    }
    public IDataGateway GetStatusECBGateway()
    {
        return GetGateway(typeof(StatusECBDS.S_G_STATUS_ECBDataTable));
    }
    public IDataGateway GetStatusLicenseGateway()
    {
        return GetGateway(typeof(StatusLicenseDS.S_G_LICENSE_STATUSDataTable));
    }
    public IDataGateway GetStsStAccommECBGateway()
    {
        return GetGateway(typeof(StsStAccommECBDS.S_G_STATUS_STATE_ACCOMM_ECBDataTable));
    }
    public IDataGateway GetUnitDimPerECBGateway()
    {
        return GetGateway(typeof(UnitDimPerECBDS.S_G_UNIT_DIMENSION_PERIOD_ECBDataTable));
    }
    public IDataGateway GetViolationKndGateway()
    {
        return GetGateway(typeof(ViolationKndDS.S_G_VIOLATION_KNDDataTable));
    }
   #endregion

    

    #region Share

    public IDataGateway GetShareGateway()
    {
        return GetGateway(typeof(ShareDS.S_SHAREDataTable));
    }

    public IShareStructRelGateway GetShareStructRelGateway()
    {
        return (IShareStructRelGateway)GetGateway(typeof(ShareStructRelDS.S_SHARE_STRUCT_RELDataTable));
    }
    public IShareFounderGateway GetShareFounderGateway()
    {
        return (IShareFounderGateway)GetGateway(typeof(ShareFounderDS.S_SHARE_FOUNDERDataTable));
    }
    public IShareInfoOfficialGateway GetShareInfoOfficialGateway()
    {
        return (IShareInfoOfficialGateway)GetGateway(typeof(ShareInfoOfficialDS.S_SHARE_INFO_OFFICIALSDataTable));
    }
    public IShareBureauInfoGateway GetShareBureauInfoGateway()
    {
        return (IShareBureauInfoGateway)GetGateway(typeof(ShareBureauInfoDS.S_SHARE_BUREAU_INFODataTable));
    }
    public IShareRegIssueGateway GetShareRegIssueGateway()
    {
        return (IShareRegIssueGateway)GetGateway(typeof(ShareRegDS.S_SHARE_REGDataTable));
    }
    public IShareIssuersGateway GetShareIssuersGateway()
    {
        return (IShareIssuersGateway)GetGateway(typeof(ShareIssuersDS.S_SHAR_ISSUERSDataTable));
    }
    public IShareChangesGateway GetShareChangesGateway()
    {
        return (IShareChangesGateway)GetGateway(typeof(ShareChangesDS.S_SHARE_CHANGESDataTable));
    }
    public IShareFilterGateway GetShareFilterGateway()
    {
        return (IShareFilterGateway)GetGateway(typeof(ShareFilterDS.S_SHARE_FILTERDataTable));
    }
    #endregion

    #region Bond

    public IDataGateway GetBondRegistryGateway()
    {
        return GetGateway(typeof(BondRegistryDS.BOND_REGISTRYDataTable));
    }
    public IBondFilterGateway GetBondFilterGateway()
    {
        return (IBondFilterGateway)GetGateway(typeof(BondFilterDS.BondFilterDataTable));
    }
    public IBondAppointmentGateway GetBondAppointmentGateway()
    {
        return (IBondAppointmentGateway)GetGateway(typeof(BondAppointmentDS.BondAppDataTable));
    }
    public IBondHstGateway GetBondGateway()
    {
        return (IBondHstGateway)GetGateway(typeof(BondDS.BONDDataTable));
    }
    public IBondFoundersGateway GetBondFoundersGateway()
    {
        return (IBondFoundersGateway)GetGateway(typeof(BondFoundersDS.BONDFOUNDERSDataTable));
    }

    #endregion

    #region Confirm

    public IConfirmObjectGateway GetConfirmObjectGateway()
    {
        return (IConfirmObjectGateway)GetGateway(typeof(ConfirmObjectDS.CONFIRM_OBJECTDataTable));
    }
    public IConfirmObjectStepGateway GetConfirmObjectStepGateway()
    {
        return (IConfirmObjectStepGateway)GetGateway(typeof(ConfirmObjectStepDS.CONFIRM_OBJECT_STEPDataTable));
    }

    #endregion

    #region Services

    public IDataGateway RightsItemDataGateway()
    {
      return GetGateway(typeof (RightsItemDS._CURRENT_OFFICIAL_RIGHTS_DataTable));
    }
    
    public IDataGateway GetUserGateway()
    {
      return GetGateway(typeof(UserDS.UserDSDataTable));
    }
    public IDataGateway GetShareidGateway()
    {
        return GetGateway(typeof(ShareidDS.ShareidDataTable));
    }    
    #endregion
  }
}