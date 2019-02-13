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

        private string nameRu, nameKz;
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

        public string NameRu
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
