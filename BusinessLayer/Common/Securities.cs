using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using BSB.Common;


namespace ARM_User.BusinessLayer.Common
{
    public class Securities : DomainObject
    {
        private int idstsknd;
     //   private int 
 
        public int Idstsknd
        {
            get { return idstsknd; }
            set
            {
                NotifyBeforeObjectChange();
                idstsknd = value;
                NotifyPropertyChanged("Idstsknd");
            }
        }

        public Securities()
        {
        }

        public Securities(int id, int idstsknd, User editUser, DateTime? editTime) 
        {
            
            this.idstsknd = idstsknd;
        }

        /*public Securities(int id, BondList hislist) : base(id, hislist)
        {
                    
        }*/

        public static Securities CreateNew()
        {
            return CreateNew<Securities>();
        }

        /*protected override Bond CreateHistoryObject()
        {
            return Bond.CreateNew(this);
        }*/
    }

    public class SecuritiesList : DOList<Securities>
    {
    }
}
