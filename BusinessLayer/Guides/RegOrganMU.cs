using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.MapperLayer.Common;

//Справочник "Регистрирующий орган МЮ"

namespace ARM_User.BusinessLayer.Guides
{
  public class RegOrganMU : DomainObject
  {
    public RegOrganMU()
    {
    }

    public interface IRegOrganMUFinder : ISimpleFinder<RegOrganMU, RegOrganMUList>
    {
        RegOrganMUList FindByCondition(decimal id_guides);
        RegOrganMU FindById(decimal id_ref);
    }
    public RegOrganMU(decimal id, decimal? parentId, string name, int typeElement, decimal numLevel,
      decimal lastElementHierarchy, bool isDelete)
      : base(id)
    {
      this.ParentId = parentId;
      this.name = name;
      this.typeElement = typeElement;
      this.numLevel = numLevel;
      this.lastElementHierarchy = lastElementHierarchy;
      this.isDelete = isDelete;
    }

    public static RegOrganMU CreateNew()
    {
      return CreateNew<RegOrganMU>();
    }

    #region Fileds

    private String name;
    private int typeElement;
    private decimal numLevel, lastElementHierarchy;
    private RegOrganMU regorganMUParent;
    private bool isDelete;
    #endregion Fileds

    #region propertis

    public decimal? ParentId { get; private set; }

    public string Name
    {
      get { return name; }
      set
      {
        NotifyBeforeObjectChange();
        name = value;
        NotifyPropertyChanged("Name");
      }
    }

    public int TypeElement
    {
      get { return typeElement; }
      set
      {
        NotifyBeforeObjectChange();
        typeElement = value;
        NotifyPropertyChanged("TypeElement");
      }
    }

    public decimal NumLevel
    {
      get { return numLevel; }
      set
      {
        NotifyBeforeObjectChange();
        numLevel = value;
        NotifyPropertyChanged("NumLevel");
      }
    }

    public decimal LastElementHierarchy
    {
      get { return lastElementHierarchy; }
      set
      {
        NotifyBeforeObjectChange();
        lastElementHierarchy = value;
        NotifyPropertyChanged("LastElementHierarchy");
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
    public RegOrganMU RegOrganMUParent
    {
      get
      {
       // if (ParentId != null && regorganMUParent == null)
        //  regorganMUParent = MapperRegistry.Instance.GetRegOrganMUMapper().Find((decimal) ParentId);
        return regorganMUParent;
      }
      set
      {
           //NotifyBeforeObjectChange();
          //regorganMUParent = value;
         //NotifyPropertyChanged("RegOrganMUParent");
        regorganMUParent = value;
        ParentId = regorganMUParent.Id;
      }
    }

    #endregion
  }

  public class RegOrganMUList : DOList<RegOrganMU>
  {
  }
}