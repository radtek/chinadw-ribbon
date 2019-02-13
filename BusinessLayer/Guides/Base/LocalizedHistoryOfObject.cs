using System;
using BSB.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public abstract class LocalizedHistoryOfObject : HistoryOfObject
  {
    #region Fields

    #endregion

    public override void CopyAddedPropertiesTo(HistoryOfObject obj)
    {
      if (!(obj is LocalizedHistoryOfObject))
        throw new ArgumentException();
      var o = (LocalizedHistoryOfObject) obj;
   
    }

    #region Constructors

    public LocalizedHistoryOfObject(decimal rootId)
      : base(rootId)
    {
    }

    

    public LocalizedHistoryOfObject(
      decimal rootId,
      bool isLast)
      : base(rootId, isLast)
    {
      
    }

    public LocalizedHistoryOfObject(
      decimal id,
      decimal rootId,
      bool isLast)
      : base(id, rootId, isLast)
    {
    
    }

    public LocalizedHistoryOfObject(
      decimal id,
      User editUser,
      DateTime? editTime,
      decimal rootId,      
      bool isLast)
      : base(id, editUser, editTime, rootId, isLast)
    {
      
    }

    #endregion

    #region Properties

  
   

    #endregion
  }
}