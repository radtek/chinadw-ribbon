using System;
using ARM_User.BusinessLayer.Common;
using BSB.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.BusinessLayer.Guides
{
    public class Sharer : DomainObject
    {
        #region Fileds

        private string nameRu, nameKz, iIN_BIN_OKPO_NUMBER, docNumUdLich;
        private DateTime? docDate;
        private bool isDelete;
        private DocKnd docKnd;

        #endregion Fileds

        public Sharer()
        {
        }

        public Sharer(decimal id, string nameRu, string nameKz, string iIN_BIN_OKPO_NUMBER, DocKnd docKnd, string docNumUdLich, DateTime? docDate, bool isDelete, User editUser, DateTime? editTime)
            : base(id, editUser, editTime)
        {
            this.nameRu = nameRu;
            this.nameKz = nameKz;
            this.iIN_BIN_OKPO_NUMBER = iIN_BIN_OKPO_NUMBER;
            this.docKnd = docKnd;
            this.docNumUdLich = docNumUdLich;
            this.docDate = docDate;
            this.isDelete = isDelete;
        }

        public static Sharer CreateNew()
        {
            return CreateNew<Sharer>();
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

        public string NameKz
        {
            get { return nameKz; }
            set
            {
                NotifyBeforeObjectChange();
                nameKz = value;
                NotifyPropertyChanged("NameKz");
            }
        }

        public string IIN_BIN_OKPO_NUMBER
        {
            get { return iIN_BIN_OKPO_NUMBER; }
            set
            {
                NotifyBeforeObjectChange();
                iIN_BIN_OKPO_NUMBER = value;
                NotifyPropertyChanged("IIN_BIN_OKPO_NUMBER");
            }
        }

        public DocKnd DocKnd
        {
            get { return docKnd; }
            set
            {
                NotifyBeforeObjectChange();
                docKnd = value;
                NotifyPropertyChanged("DocKnd");
            }
        }

        public string DocNumUdLich
        {
            get { return docNumUdLich; }
            set
            {
                NotifyBeforeObjectChange();
                docNumUdLich = value;
                NotifyPropertyChanged("DocNumUdLich");
            }
        }

        public DateTime? DocDate
        {
            get { return docDate; }
            set
            {
                NotifyBeforeObjectChange();
                docDate = value;
                NotifyPropertyChanged("DocDate");
            }
        }

        public bool IsDelete
        {
            get { return isDelete; }
            set
            {
                NotifyBeforeObjectChange();
                isDelete = value;
                NotifyPropertyChanged("IsDelete");
            }
        }

        public override void Delete()
        {
            try
            {
                if (!UnitOfWork.Instance.IsTransactionStarted)
                    UnitOfWork.Instance.BeginTransaction();
                IsDelete = true;
                UnitOfWork.Instance.Commit();
            }
            catch (Exception ex)
            {
                if (UnitOfWork.Instance.IsTransactionStarted)
                {
                    UnitOfWork.Instance.Rollback();
                }
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                {
                    throw;
                }
            }
        }

        #endregion
    }

    public class SharerList : DOList<Sharer>
    {
    }
}