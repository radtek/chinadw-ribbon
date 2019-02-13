using System;
using ARM_User.BusinessLayer.Common;
using BSB.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.BusinessLayer.Guides
{
    public class DocKnd : LocalizedSimpleDO
    {
        #region Fileds

        private string nameRu, nameKz;
        private bool isDelete;

        #endregion Fileds
        public interface IDocKndFinder : ISimpleFinder<DocKnd, DocKndList>
        {
            DocKndList FindByCondition(decimal id_guides);
            DocKnd FindById(decimal id, int type);         
        }
        public DocKnd()
        {
        }

        public DocKnd(decimal id, string nameRu, string nameKz, bool isDelete, User editUser, DateTime? editTime)
            : base(id, nameRu, nameKz, editUser, editTime)
        {
            this.nameRu = nameRu;
            this.nameKz = nameKz;
            this.isDelete = isDelete;
        }

        public static DocKnd CreateNew()
        {
            return CreateNew<DocKnd>();
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

    public class DocKndList : DOList<DocKnd>
    {
    }
}