using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.GuidesDataSet;
using ARM_User.MapperLayer.Common;
using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System.Collections;
using ARM_User.DataLayer;
using ARM_User.BusinessLayer.Reports;
using ARM_User.DataLayer.DataSet.Reports;

namespace ARM_User.MapperLayer.Reports
{
    public class MonthsMapper
      : SimpleMapper<Months, MonthsList, MonthsDS.G_MONTHSDataTable, MonthsDS.G_MONTHSRow>
    {
        protected override Months CreateByRow(MonthsDS.G_MONTHSRow row)
        {
            var obj = new Months(
              row.ID,
              row.NAME_RU,
              row.NAME_RU,
              row.IsMONTHNull()?(DateTime?)null:row.MONTH,
              row.IsMONTH_ENDNull()?(DateTime?)null:row.MONTH_END
             );

            return obj;
        }

        public override void Insert(ICollection<DomainObject> objCollection)
        {
            //
        }

        public override void Update(ICollection<DomainObject> objCollection)
        {
            //
        }

        public override void Delete(ICollection<DomainObject> objCollection)
        {
            //
        }

        protected override string IdName()
        {
            return "ID";
        }

        public virtual MonthsList FindByCondition(decimal id_guides)
        {
            var objList = new MonthsList();
            objList.Loader = new VLLoader(new ByConditionTableLoader(id_guides), this);
            return objList;
        }
        public class ByConditionTableLoader : TableLoader
        {
            private readonly decimal id_guides;

            public ByConditionTableLoader(decimal id_guides)
            {
                this.id_guides = id_guides;
            }

            public override ICollection CreateAndLoad()
            {
                var gw = DataGatewayFactoryHolder.CacheFactory.GetMonthsGateway();
                var tab = new MonthsDS.G_MONTHSDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }
        public virtual Months FindBy(decimal id_guides)
        {
            var objList = new MonthsList();
            objList.Loader = new VLLoader(new ByCondTableLoader(id_guides), this);
            return objList[0];
        }
        public class ByCondTableLoader : TableLoader
        {
            private readonly decimal id_guides;

            public ByCondTableLoader(decimal id_guides)
            {
                this.id_guides = id_guides;
            }

            public override ICollection CreateAndLoad()
            {
                var gw = DataGatewayFactoryHolder.CacheFactory.GetMonthsGateway();
                var tab = new MonthsDS.G_MONTHSDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }
    }
}