using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.MapperLayer.Common;
using BSB.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.BusinessLayer.Guides
{
    public class RepForm : LocalizedSimpleDO
    {
        #region Fileds

        private string nameRu, nameKz,code;
        private decimal typeId, repKnd;
        private byte[] templateRu, templateKz;
     
        #endregion Fileds
        //

        public interface IRepFormFinder : ISimpleFinder<RepForm, RepFormList>
        {
          RepFormList FindByList(decimal id_kind);
          RepFormList FindIdList(Int64 id_rep);
        }
      
        public RepForm()
        {
        }

        public RepForm(decimal id, string nameRu, string nameKz, decimal typeId, string code, decimal repKnd) : base(id, nameRu, nameKz)
           
        {
            this.typeId = typeId;
            this.code = code;
            this.repKnd = repKnd;
        }

        public static RepForm CreateNew()
        {
            return CreateNew<RepForm>();
        }

        #region propertis

        public string Code
        {
            get { return code; }
            set
            {
                NotifyBeforeObjectChange();
                nameKz = value;
                NotifyPropertyChanged("Code");
            }
        }

        public decimal RepKnd
        {
            get { return repKnd; }
            set
            {
                NotifyBeforeObjectChange();
                repKnd = value;
                NotifyPropertyChanged("RepKnd");
            }
        }
        public decimal TypeId
        {
          get { return typeId; }
          set
          {
            NotifyBeforeObjectChange();
            typeId = value;
            NotifyPropertyChanged("TypeId");
          }
        }

        public byte[] TemplateRu
        {
          get
          {
            if (templateRu == null && id > 0)
              templateRu = MapperRegistry.Instance.GetRepFormMapper().GetTemplate(id, LanguageIds.Russian);
            return templateRu;
          }
          set
          {
            if (templateRu != value)
            {
              NotifyBeforeObjectChange();
              templateRu = value;
              NotifyPropertyChanged("TemplateRu");
            }
          }
        }

        public byte[] TemplateKz
        {
          get
          {
            if (templateKz == null && id > 0)
              templateKz = MapperRegistry.Instance.GetRepFormMapper().GetTemplate(id, LanguageIds.Kazakh);
            return templateKz;
          }
          set
          {
            if (templateKz != value)
            {
              NotifyBeforeObjectChange();
              templateKz = value;
              NotifyPropertyChanged("TemplateKz");
            }
          }
        }

        public byte[] GetTemplate(LanguageIds lang)
        {
          return lang == LanguageIds.Russian ? TemplateRu : TemplateKz;
        }

        #endregion
    }

    public class RepFormList : DOList<RepForm>
    {
    }
}