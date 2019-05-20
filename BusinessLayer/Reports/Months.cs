using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using ARM_User.MapperLayer.Common;

namespace ARM_User.BusinessLayer.Reports
{
    public class Months : LocalizedSimpleDO
    {
        #region Fileds

#pragma warning disable CS0108 // 'Months.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
#pragma warning disable CS0108 // 'Months.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'Months.nameKz' is never used
        private string nameRu, nameKz;
#pragma warning restore CS0169 // The field 'Months.nameKz' is never used
#pragma warning restore CS0108 // 'Months.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
#pragma warning restore CS0108 // 'Months.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
        private DateTime? month, monthEnd;


        #endregion Fileds
        public interface IMonths : ISimpleFinder<Months, MonthsList>
        {
            Months FindByCondition(decimal id_guides);
            Months FindBy(decimal id_guides);
        }
        public Months()
        {
        }

        public Months(decimal id, string nameRu, string nameKz, DateTime? month, DateTime? monthEnd)
            : base(id, nameRu, nameKz)
        {
            this.nameRu = nameRu;
            this.month = month;
            this.monthEnd = monthEnd;


        }

        public static Months CreateNew()
        {
            return CreateNew<Months>();
        }
        #region propertis

#pragma warning disable CS0108 // 'Months.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
        public string NameRu
#pragma warning restore CS0108 // 'Months.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
        {
            get { return nameRu; }
            set
            {
                NotifyBeforeObjectChange();
                nameRu = value;
                NotifyPropertyChanged("NameRu");
            }
        }
        public DateTime? Month
        {
            get { return month; }
            set
            {
                NotifyBeforeObjectChange();
                month = value;
                NotifyPropertyChanged("Month");
            }
        }
        public DateTime? MonthEnd
        {
            get { return monthEnd; }
            set
            {
                NotifyBeforeObjectChange();
                monthEnd = value;
                NotifyPropertyChanged("MonthEnd");
            }
        }
        #endregion
    }

    public class MonthsList : DOList<Months>
    {
    }

}
