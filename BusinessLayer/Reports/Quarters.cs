using System;
using System.Collections.Generic;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using BSB.Common;
using ARM_User.MapperLayer.Common;

namespace ARM_User.BusinessLayer.Reports
{
    public class Quarters : LocalizedSimpleDO
    {
        #region Fileds

        private string nameRu, nameKz;
        private DateTime? quarter, quarterEnd;


        #endregion Fileds
        public interface IQuarters : ISimpleFinder<Quarters, QuartersList>
        {
            Quarters FindByCondition(decimal id_guides);
            Quarters FindBy(decimal id_guides);         
        }
        public Quarters()
        {
        }

        public Quarters(decimal id, string nameRu, string nameKz, DateTime? quarter, DateTime? quarterEnd)
            : base(id, nameRu, nameKz)
        {
            this.nameRu = nameRu;
            this.quarter = quarter;
            this.quarterEnd = quarterEnd;


        }

        public static Quarters CreateNew()
        {
            return CreateNew<Quarters>();
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
        public DateTime? Quarter
        {
            get { return quarter; }
            set
            {
                NotifyBeforeObjectChange();
                quarter = value;
                NotifyPropertyChanged("Quarter");
            }
        }
        public DateTime? QuarterEnd
        {
            get { return quarterEnd; }
            set
            {
                NotifyBeforeObjectChange();
                quarterEnd = value;
                NotifyPropertyChanged("QuarterEnd");
            }
        }
        #endregion
    }

    public class QuartersList : DOList<Quarters>
    {
    }

}
