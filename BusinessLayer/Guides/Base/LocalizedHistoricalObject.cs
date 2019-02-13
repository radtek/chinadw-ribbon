using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public abstract class LocalizedHistoricalObject<HistoryObject, HistoryList> :
    HistoricalObject<HistoryObject, HistoryList>
    where HistoryObject : LocalizedHistoryOfObject
    where HistoryList : DOList<HistoryObject>, new()
  {
  
    #region Constructors

    public LocalizedHistoricalObject()
    {
    }

    public LocalizedHistoricalObject(
      decimal id,
      HistoryList history)
      : base(id, history)
    {
    }

    #endregion

    #region Properties
  
    #endregion
  }
}