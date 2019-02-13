using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARM_User.BusinessLayer.Guides;
using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Service
{
    public class Shareid : SimpleGuideDO
    {

    #region Constructors
    public Shareid(decimal id, string name)
      : base(id, name)
    {
            
    }
    #endregion
    public interface IShareidFinder : ISimpleFinder<Shareid, ShareidList>
    {
    }
  }

    public class ShareidList : DOList<Shareid>
  {
  }
}
