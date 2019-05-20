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

#pragma warning disable CS0108 // 'Quarters.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
#pragma warning disable CS0169 // The field 'Quarters.nameKz' is never used
#pragma warning disable CS0108 // 'Quarters.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
        private string nameRu, nameKz;
#pragma warning restore CS0108 // 'Quarters.nameRu' hides inherited member 'LocalizedSimpleDO.nameRu'. Use the new keyword if hiding was intended.
#pragma warning restore CS0169 // The field 'Quarters.nameKz' is never used
#pragma warning restore CS0108 // 'Quarters.nameKz' hides inherited member 'LocalizedSimpleDO.nameKz'. Use the new keyword if hiding was intended.
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

#pragma warning disable CS0108 // 'Quarters.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
        public string NameRu
#pragma warning restore CS0108 // 'Quarters.NameRu' hides inherited member 'LocalizedSimpleDO.NameRu'. Use the new keyword if hiding was intended.
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
