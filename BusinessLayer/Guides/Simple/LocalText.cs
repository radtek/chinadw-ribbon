using System;
using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides.Simple
{
  public class LocalText : DomainObject
  {
    #region Fields

    protected string keyText, transText;

    #endregion

    public static LocalText CreateNew()
    {
      return CreateNew<LocalText>();
    }

    public interface ILocalTextFinder : ISimpleFinder<LocalText, LocalTextList>
    {
    }

    #region Constructors

    public LocalText()
    {
    }

    public LocalText(
      decimal id,
      User editUser,
      DateTime? editTime,
      string keyText,
      string transText)
      : base(id, editUser, editTime)
    {
      this.keyText = keyText;
      this.transText = transText;
    }

    #endregion

    #region Properties

    public string KeyText
    {
      get { return keyText; }
      set
      {
        NotifyBeforeObjectChange();
        keyText = value;
        NotifyPropertyChanged("KeyText");
      }
    }

    public string TransText
    {
      get { return transText; }
      set
      {
        NotifyBeforeObjectChange();
        transText = value;
        NotifyPropertyChanged("TransText");
      }
    }

    #endregion
  }

  public class LocalTextList : DOList<LocalText>
  {
  }
}