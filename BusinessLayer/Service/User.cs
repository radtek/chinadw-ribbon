using ARM_User.BusinessLayer.Common;

namespace ARM_User.BusinessLayer.Guides
{
  public class User : SimpleGuideDO
  {
    #region Fields

    protected string email, username;
    protected decimal? dept;

    #endregion

    #region Constructors

    public User(decimal id, string name, string username, decimal? dept)
      : base(id, name)
    {
      this.username = username;
      this.dept = dept;
    }
    #endregion

    #region Properties

    public string Username
    {
      get { return username; }
      set
      {
        if (username != value)
        {
          NotifyBeforeObjectChange();
          username = value;
          NotifyPropertyChanged("Username");
        }
      }
    }
    public decimal? Dept
    {
        get { return dept; }
        set
        {
            if (dept != value)
            {
                NotifyBeforeObjectChange();
                dept = value;
                NotifyPropertyChanged("Dept");
            }
        }
    }

    #endregion

    public interface IUserFinder : ISimpleFinder<User, UserList>
    {
        UserList FindByCondition(decimal id_popup);
        User FindById(decimal id);
    }
  }

  public class UserList : DOList<User>
  {
  }
}