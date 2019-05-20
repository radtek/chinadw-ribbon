using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using ARM_User.MapperLayer.Common;

namespace ARM_User.BusinessLayer.Reports
{
    public class YearsQuarterMonth : LocalizedSimpleDO
    {
        #region Fileds

#pragma warning disable CS0169 // The field 'YearsQuarterMonth.nameKz' is never used
#pragma warning disable CS0108 // 'YearsQuarterMonth.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
#pragma warning disable CS0108 // 'YearsQuarterMonth.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
        private string nameRu, nameKz;
#pragma warning restore CS0108 // 'YearsQuarterMonth.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
#pragma warning restore CS0108 // 'YearsQuarterMonth.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
#pragma warning restore CS0169 // The field 'YearsQuarterMonth.nameKz' is never used
        private DateTime? year, yearEnd;
       

        #endregion Fileds
        public interface IYearsQuarterMonth : ISimpleFinder<YearsQuarterMonth, YearsQuarterMonthList>
        {
            YearsQuarterMonth FindByCondition(decimal id_guides);
            YearsQuarterMonth FindBy(decimal id_guides);            
        }
        public YearsQuarterMonth()
        {
        }

        public YearsQuarterMonth(decimal id, string nameRu, string nameKz,DateTime? year, DateTime? yearEnd)
            : base(id, nameRu, nameKz)
        {
            this.nameRu = nameRu;
            this.year = year;
            this.yearEnd = yearEnd;

          
        }

        public static YearsQuarterMonth CreateNew()
        {
            return CreateNew<YearsQuarterMonth>();
        }
        #region propertis

#pragma warning disable CS0108 // 'YearsQuarterMonth.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
        public string NameRu
#pragma warning restore CS0108 // 'YearsQuarterMonth.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
        {
            get { return nameRu; }
            set
            {
                NotifyBeforeObjectChange();
                nameRu = value;
                NotifyPropertyChanged("NameRu");
            }
        }
        public DateTime? Year
        {
            get { return year; }
            set
            {
                NotifyBeforeObjectChange();
                year = value;
                NotifyPropertyChanged("Year");
            }
        }
        public DateTime? YearEnd
        {
            get { return yearEnd; }
            set
            {
                NotifyBeforeObjectChange();
                yearEnd = value;
                NotifyPropertyChanged("YearEnd");
            }
        }
        #endregion
    }

    public class YearsQuarterMonthList : DOList<YearsQuarterMonth>
    {
    }

}
