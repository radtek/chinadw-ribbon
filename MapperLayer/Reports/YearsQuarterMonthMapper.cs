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
    public class YearsQuarterMonthMapper
      : SimpleMapper<YearsQuarterMonth, YearsQuarterMonthList, YearsQuarterMonthDS.G_REPORT_STRDataTable, YearsQuarterMonthDS.G_REPORT_STRRow>
    {
        protected override YearsQuarterMonth CreateByRow(YearsQuarterMonthDS.G_REPORT_STRRow row)
        {
            var obj = new YearsQuarterMonth(
              row.ID,
              row.NAME_RU,
              row.NAME_RU,
              row.IsYEARNull()?(DateTime?)null:row.YEAR,
              row.IsYEAR_ENDNull()?(DateTime?)null:row.YEAR_END
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

        public virtual YearsQuarterMonthList FindByCondition(decimal id_guides)
        {
            var objList = new YearsQuarterMonthList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetYearsQuarterMonthGateway();
                var tab = new YearsQuarterMonthDS.G_REPORT_STRDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }

        public virtual YearsQuarterMonth FindBy(decimal id_guides)
        {
            var objList = new YearsQuarterMonthList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetYearsQuarterMonthGateway();
                var tab = new YearsQuarterMonthDS.G_REPORT_STRDataTable();
                gw.Load(tab, id_guides);
                return tab.Rows;
            }
        }
    }
}