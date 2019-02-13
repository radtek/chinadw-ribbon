using System;
using ARM_User.BusinessLayer.Common;
using BSB.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public interface IHistoricalObject
  {
    IDOList History { get; }
    bool HasHistoryAt(DateTime dateTime);
    void AddHistory();
    void DeleteHistory();
  }

  public abstract class HistoricalObject<HistoryObject, HistoryList> : DomainObject, IHistoricalObject
    where HistoryObject : HistoryOfObject
    where HistoryList : DOList<HistoryObject>, new()
  {
    protected HistoryList history;
    protected HistoryObject lastHistory;

    public HistoricalObject()
    {
      history = new HistoryList();
      history.Add(CreateHistoryObject());
      SetListners(true);
    }

    public HistoricalObject(
      decimal id,
      HistoryList history)
      : base(id)
    {
      this.history = history;
      SetListners(true);
    }

    [ParentId("IdParent")]
    [SetParentDirty]
    [DeleteRule(DeleteRule.Cascade)]
    public HistoryList History
    {
      get { return history; }
    }

    public HistoryObject FirstHistory
    {
      get
      {
        var firstHistory = LastHistory;
        foreach (var historyObject in History)
        {
       //   if (historyObject.DateBeg < firstHistory.DateBeg)
            firstHistory = historyObject;
        }
        return firstHistory;
      }
    }

    public HistoryObject LastHistory
    {
      get
      {
        if (lastHistory == null)
          SetLastHistory();
        return lastHistory;
      }
    }

    protected HistoryObject PreviousHistory
    {
      get
      {
        if (LastHistory == null)
          return null;
        HistoryObject hisObjectPrevious = null;
        foreach (var o in History)
        {
       //   if (o.DateEnd == LastHistory.DateBeg)
            hisObjectPrevious = o;
        }
        return hisObjectPrevious;
      }
    }

 /*   public DateTime DateBeg
    {
      get { return LastHistory.DateBeg; }
      set
      {
        if (History.Count > 1)
          if (value <= PreviousHistory.DateBeg)
            throw new ApplicationException(LangTranslate.UiGetText(
              "Дата ввода в действие исторической записи должна быть больше даты ввода в действие предыдущей исторической записи"));
        var hisObjectPrevious = PreviousHistory;
        LastHistory.DateBeg = value;
        if (hisObjectPrevious != null)
          hisObjectPrevious.DateEnd = value;
        NotifyPropertyChanged("DateBeg");
      }
    }*/

   /* public DateTime? DateEnd
    {
      get { return LastHistory.DateEnd; }
      set
      {
        var dateEnd = LastHistory.DateEnd;
        if (dateEnd != value)
        {
          if (value != null)
          {
            var dt = value.Value;
            if (dt <= DateBeg)
              throw new ApplicationException(LangTranslate.UiGetText(
                "Дата окончания действия записи должна быть больше даты начала действия записи"));
          }

          NotifyBeforeObjectChange();
          LastHistory.DateEnd = value;
          NotifyPropertyChanged("DateEnd");
        }
      }
    }*/

    public new User EditUser
    {
      get { return LastHistory.EditUser; }
      set
      {
        LastHistory.EditUser = value;
        NotifyPropertyChanged("EditUser");
      }
    }

    public new DateTime? EditTime
    {
      get { return LastHistory.EditTime; }
      set
      {
        LastHistory.EditTime = value;
        NotifyPropertyChanged("EditTime");
      }
    }

    protected void SetLastHistory()
    {
      var index = History.Find("IsLast", true, 0);
      if (index >= 0)
        lastHistory = History[index];
      else
        lastHistory = null;
      NotifyPropertyChanged(null);
    }

    public
      HistoricalObjectWrapper<HistoricalObject<HistoryObject, HistoryList>, HistoryObject, HistoryList, TFieldResult>
      AsWrapper<TFieldResult>(Func<HistoryObject, TFieldResult> field, DateTime reportDate)
    {
      return
        new HistoricalObjectWrapper
          <HistoricalObject<HistoryObject, HistoryList>, HistoryObject, HistoryList, TFieldResult>(this, field,
            reportDate);
    }

    public HistoryObject GetHistoryByDate(DateTime dateTime)
    {
    /*  foreach (var historyObject in History)
      {
        if (historyObject.DateBeg <= dateTime &&
            (historyObject.DateEnd == null ||
             !historyObject.DateEnd.HasValue ||
             historyObject.DateEnd.Value > dateTime))
          return historyObject;
      }*/
      return null;
    }

    /*public HistoryObject GetHistoryByDateOrLast(DateTime dateTime)
    {
      return (GetHistoryByDate(dateTime) ?? LastHistory);
    }*/

    public void AddHistory()
    {
  /*    var hisObjectLast = LastHistory;
      if (hisObjectLast.DateEnd == null)
        hisObjectLast.DateEnd = SessionVariables.Instance.Today;
      hisObjectLast.IsLast = false;
      var hisObject = CreateHistoryObject();
      hisObject.DateBeg = hisObjectLast.DateEnd.Value;
      hisObjectLast.CopyAddedPropertiesTo(hisObject);
      history.Add(hisObject);*/
      SetLastHistory();
    }

    public void DeleteHistory()
    {
   /*   if (History.Count <= 1)
        throw new ApplicationException(LangTranslate.UiGetText("Нельзя удалить последнюю историю"));
      var hisObjectLast = LastHistory;

     var hisObjectPrevious = PreviousHistory;
      if (hisObjectPrevious == null)
        throw new ApplicationException(LangTranslate.UiGetText("Не найдена предпоследняя история"));

      hisObjectLast.Delete();
     // hisObjectPrevious.DateEnd = null;
      hisObjectPrevious.IsLast = true;
      SetLastHistory();*/
    }

    public TFieldResult GetPropertyValue<TFieldResult>(Func<HistoryObject, TFieldResult> func, DateTime reportDate)
    {
      HistoryObject historyOfObject = null;
      if (reportDate != null)
      {
        historyOfObject = GetHistoryByDate(reportDate);
      }
      else
      {
        historyOfObject = LastHistory;
      }

      if (historyOfObject != null)
      {
        var fieldResult = func(historyOfObject);
        return fieldResult;
      }
      return default(TFieldResult);
    }

    protected abstract HistoryObject CreateHistoryObject();

    public override void Validate()
    {
  /*    base.Validate();
      if (DateEnd is DateTime)
      {
        if (DateBeg >= (DateTime) DateEnd)
          throw new ApplicationException(
            LangTranslate.UiGetText("Дата окончания действия записи должна быть больше даты начала действия записи"));
      }*/
    }

    public class ByDatePredicate
    {
      public ByDatePredicate(DateTime date)
      {
        Date = date;
      }

      public DateTime Date { get; private set; }

      public bool Predicate(IHistoricalObject obj)
      {
        return obj.HasHistoryAt(Date);
      }
    }

    #region IHistoricalObject Members

    IDOList IHistoricalObject.History
    {
      get { return History; }
    }

    bool IHistoricalObject.HasHistoryAt(DateTime dateTime)
    {
      return GetHistoryByDate(dateTime) != null;
    }

    void IHistoricalObject.AddHistory()
    {
      AddHistory();
    }

    void IHistoricalObject.DeleteHistory()
    {
      DeleteHistory();
    }

    #endregion
  }
}