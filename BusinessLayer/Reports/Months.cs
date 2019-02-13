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

        private string nameRu, nameKz;
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
