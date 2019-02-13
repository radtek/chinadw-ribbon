using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.MapperLayer.Common;
using System.Collections;
using ARM_User.DataLayer;

namespace ARM_User.MapperLayer.Guides
{
  public class UserMapper : SimpleMapper<User, UserList, UserDS.UserDSDataTable, UserDS.UserDSRow>, User.IUserFinder
  {
    protected override User CreateByRow(UserDS.UserDSRow row)
    {
      var obj = new User(row.OFFICIAL, row.NAME, row.USER_NAME, row.IsDEPTNull() ? null : (decimal?)row.DEPT);
      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    public override void Delete(ICollection<DomainObject> objCollection)
    {
      throw new NotSupportedException();
    }

    protected override string IdName()
    {
      return "OFFICIAL";
    }
    public virtual UserList FindByCondition(decimal id_popup)
    {
        var objList = new UserList();
        objList.Loader = new VLLoader(new ByConditionTableLoader(id_popup), this);
        return objList;
    }
    public class ByConditionTableLoader : TableLoader
    {
        private readonly decimal id_popup;

        public ByConditionTableLoader(decimal id_popup)
        {
            this.id_popup = id_popup;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetUserGateway();
            var tab = new UserDS.UserDSDataTable();
            gw.Load(tab, id_popup);
            return tab.Rows;
        }
    }

    public virtual User FindById(decimal id)
    {
        var objList = new UserList();
        objList.Loader = new VLLoader(new ByIdTableLoader(id), this);
        if (objList.Count > 0)
            return objList[0];
        else
            return null;
    }
    public class ByIdTableLoader : TableLoader
    {
        private readonly decimal id;

        public ByIdTableLoader(decimal id)
        {
            this.id = id;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetUserGateway();
            var tab = new UserDS.UserDSDataTable();
            gw.Load2(tab, id);
            return tab.Rows;
        }
    }
  }
}