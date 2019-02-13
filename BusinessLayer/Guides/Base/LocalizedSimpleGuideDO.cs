using ARM_User.BusinessLayer.Common;
using BSB.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public abstract class LocalizedSimpleGuideDO : DomainObject
  {
    #region Fields

    protected string nameKz, nameRu;

    #endregion

    public override void Validate()
    {
      base.Validate();
      if (NameRu == null || NameRu == "")
        throw new PropertyNullException(LangTranslate.UiGetText("Наименование на русском языке"));
      if (NameKz == null || NameRu == "")
        throw new PropertyNullException(LangTranslate.UiGetText("Наименование на казахском языке"));
    }

    public virtual string GetName(LanguageIds langId)
    {
      return langId == LanguageIds.Kazakh ? nameKz : nameRu;
    }

    public override string ToString()
    {
      return Name;
    }

    #region IComparable Members

    public override int CompareTo(object obj)
    {
      if (obj is SimpleGuideDO)
      {
        var cmp = Name.CompareTo(((SimpleGuideDO) obj).Name);
        if (cmp != 0)
          return cmp;
      }
      return base.CompareTo(obj);
    }

    #endregion

    #region Constructors

    public LocalizedSimpleGuideDO()
    {
    }

    public LocalizedSimpleGuideDO(
      decimal id,
      string nameRu,
      string nameKz)
      : base(id)
    {
      this.nameRu = nameRu;
      this.nameKz = nameKz;
    }

    #endregion

    #region Properties

    public string Name
    {
      get
      {
        if (InitApplication.CurrentLangId == LanguageIds.Kazakh)
          return nameKz;
        return nameRu;
      }
    }

    public string NameRu
    {
      get { return nameRu; }
      set
      {
        NotifyBeforeObjectChange();
        nameRu = value;
        NotifyPropertyChanged("NameRu");
      }
    }

    public string NameKz
    {
      get { return nameKz; }
      set
      {
        NotifyBeforeObjectChange();
        nameKz = value;
        NotifyPropertyChanged("NameKz");
      }
    }

    #endregion
  }
}