using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public class Shared : LocalizedSimpleGuideDO
  {
    public static Shared CreateNew()
    {
      return CreateNew<Shared>();
    }

    public interface ISharedFinder : ISimpleFinder<Shared, SharedList>
    {
    }

    #region Fields

    protected string code;
    protected Shared parent;
    protected decimal? parentId;

    #endregion

    #region Constructors

    public Shared()
    {
    }

    public Shared(
      decimal id,
      decimal? parentId,
      string code,
      string nameRu,
      string nameKz)
      : base(id, nameRu, nameKz)
    {
      this.code = code;
      this.parentId = parentId;
    }    

    #endregion

    #region Properties

    public string Code
    {
      get { return code; }
      set
      {
        NotifyBeforeObjectChange();
        code = value;
        NotifyPropertyChanged("Code");
      }
    }

    public Shared Parent
    {
      get
      {
        if (parent == null && parentId != null)
          parent = (Shared)UnitOfWork.Instance.FindObject(typeof(Shared), (decimal)parentId, false);
        return parent;
      }
      set
      {
        NotifyBeforeObjectChange();
        parent = value;
        NotifyPropertyChanged("Parent");
      }
    }

    public decimal? ParentId
    {
      get
      {
        return Parent != null ? Parent.Id : (decimal?)null;
      }
    }

    #endregion

    #region Enums

    public enum ElimType
    {
      Org = 87,
      Nb = 88
    }

    public enum FormSizeType
    {
      ByIndex = 406,
      ByLine = 404,
      ByCol = 405,
      ByForm = 403
    }

    public enum FormLogTestSide
    {
      Left = 110,
      Right = 111
    }

    public enum FormLogTestType
    {
      Parent = 130,
      Inner = 132,
      Cross = 131
    }

    public enum FormLogTestSizeType
    {
      Parent = 157,
      ByLine = 158,
      ByCol = 159,
      ByIndex = 160
    }

    public enum FormLogTestPeriodType
    {
      Parent = 425,
      Current = 426,
      Previous = 427
    }

    public enum OrgType
    {
      Parent = 95,
      Nbrk = 96,
      Org = 97
    }

    public enum DataType
    {
      Parent = 35,
      String = 36,
      Date = 37,
      Integer = 38,
      Double = 39
    }

    public enum LoadStatus
    {
      Parent = 48,
      Loading = 49,
      Loaded = 50
    }

    public enum ProtocolStatus
    {
      Successful = 414,
      Failed = 413,
      Waiting = 416
    }

    public enum CompType
    {
      Parent = 150,
      Equal = 151,
      NotEqual = 152,
      LessThan = 153,
      GreaterThann = 154,
      LessThanOrEqual = 155,
      GreaterThanOrEqual = 156,
      GreaterThanOrEqualToZero = 161,
      LessThanOrEqualToZero = 162
    }

    public enum ApprovalStatus
    {
      Parent = 55,
      NotApproved = 56,
      Approved = 57,
      Rejected = 58
    }

    public enum ReceiverType
    {
      Parent = 59,
      WebPortal = 60,
      Arm = 61
    }

    public enum FormType
    {
      Parent = 69,
      Out = -1,
      Input = 70,
      Sum = 71,
      Eliminate = 81,
      WorkingTables = 129
    }

    public enum PlanAccType
    {
      Parent = 112,
      Org = 113,
      Nbrk = 114
    }

    public enum AccountType
    {
      Parent = 78,
      Active = 79,
      Passive = 80,
      ActivePassive = 92,
      CounterActive = 93,
      CounterPassive = 94
    }

    public enum AccountItemType
    {
      Parent = 41,
      Account = 42,
      Group = 43
    }

    public enum Sign
    {
      Parent = 89,
      Positive = 90,
      Negative = 91
    }

    public enum ReportingType
    {
      Financial = 127,
      Consolidated = 128
    }

    public enum PeriodType
    {
      Monthly = 74,
      Quaterly = 75,
      HalfYearly = 76,
      Yearly = 77
    }

    public enum ProtocolItemType
    {
      CriticalError = 115,
      Information = 116
    }

    #endregion

    public override string ToString()
    {
      return Name;
    }
  }

  public class SharedList : DOList<Shared>
  {
  }
}