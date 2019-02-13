using System;
using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public class HistoricalObjectWrapper<THistoricalObject, THistoryOfObject, THistoryOfObjectList, TFieldResult>
    where THistoryOfObject : HistoryOfObject
    where THistoryOfObjectList : DOList<THistoryOfObject>, new()
    where THistoricalObject : HistoricalObject<THistoryOfObject, THistoryOfObjectList>
  {
    protected Func<THistoryOfObject, TFieldResult> func;
    protected THistoricalObject historicalObject;
    protected DateTime reportDate;

    public HistoricalObjectWrapper(THistoricalObject historicalObject, Func<THistoryOfObject, TFieldResult> func,
      DateTime reportDate)
    {
      this.historicalObject = historicalObject;
      this.func = func;
      this.reportDate = reportDate;
    }

    public HistoricalObjectWrapper(THistoricalObject historicalObject, Func<THistoryOfObject, TFieldResult> func)
    {
      this.historicalObject = historicalObject;
      this.func = func;
    }

    public TFieldResult FieldResult
    {
      get { return historicalObject.GetPropertyValue(func, reportDate); }
    }

    public THistoricalObject HistoricalObject
    {
      get { return historicalObject; }
      set { historicalObject = value; }
    }

    public DateTime ReportDate
    {
      get { return reportDate; }
      set { reportDate = value; }
    }

    public override string ToString()
    {
      var fieldResult = FieldResult;
      return fieldResult == null ? null : fieldResult.ToString();
    }
  }
}