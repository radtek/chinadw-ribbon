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
    public class QuartersMapper
      : SimpleMapper<Quarters, QuartersList, QuartersDS.G_QUARTERSDataTable, QuartersDS.G_QUARTERSRow>
    {
        protected override Quarters CreateByRow(QuartersDS.G_QUARTERSRow row)
        {
            var obj = new Quarters(
              row.ID,
              row.NAME_RU,
              row.NAME_RU,
              row.IsQUARTERNull()?(DateTime?)null:row.QUARTER,
              row.IsQUARTER_ENDNull()? (DateTime?)null :row.QUARTER_END
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

        public virtual QuartersList FindByCondition(decimal id_guides)
        {
            var objList = new QuartersList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetQuartersGateway();
                var tab = new QuartersDS.G_QUARTERSDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }
        public virtual Quarters FindBy(decimal id_guides)
        {
            var objList = new QuartersList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetQuartersGateway();
                var tab = new QuartersDS.G_QUARTERSDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }
    }
}