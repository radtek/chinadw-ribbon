using System;
using ARM_User.BusinessLayer.Common;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

//Справочник "Исполнители"

namespace ARM_User.BusinessLayer.Guides
{
  public class Executor : DomainObject
  {
    public static Executor CreateNew()
    {
      return CreateNew<Executor>();
    }

    #region Fileds
    private decimal id_official;
    private String signatureFNF, login, appName;
    private bool isDelete;
    //private Appointment appointment;
    private User user;

    #endregion Fileds

    #region Constructors
    public interface IExecutorFinder : ISimpleFinder<Executor, ExecutorList>
    {
        ExecutorList FindByCondition(decimal id_guides);
        Executor FindByUser(decimal id_user);
        Executor FindById(decimal id);
    }
    public Executor()
    {
    }

    public Executor(decimal id, decimal id_official, string login, decimal s_g_appointment, string appName,
      string signatureFNF, bool isDelete, User editUser, DateTime? editTime)
      : base(id, editUser, editTime)
    {
      user = MapperRegistry.Instance.GetUserMapper().Find(id_official);
      this.id_official = id_official;
      this.login = login;
      //appointment = MapperRegistry.Instance.GetAppointmentMapper().Find(s_g_appointment);
      this.appName = appName;
      this.signatureFNF = signatureFNF;
      this.isDelete = isDelete;
    }

    #endregion

    #region propertis
    public decimal IDOfficial
    {
        get { return id_official; }
        set
        {
            NotifyBeforeObjectChange();
            id_official = value;
            NotifyPropertyChanged("IDOfficial");
        }
    }


    public string Login
    {
      get { return login; }
      set
      {
        NotifyBeforeObjectChange();
        login = value;
        NotifyPropertyChanged("Login");
      }
    }

    public string AppName
    {
      get { return appName; }
      set
      {
        NotifyBeforeObjectChange();
        appName = value;
        NotifyPropertyChanged("AppName");
      }
    }

    public string SignatureFNF
    {
      get { return signatureFNF; }
      set
      {
        NotifyBeforeObjectChange();
        signatureFNF = value;
        NotifyPropertyChanged("SignatureFNF");
      }
    }

    /*public Appointment Appointment
    {
      get { return appointment; }
      set
      {
        NotifyBeforeObjectChange();
        appointment = value;
        NotifyPropertyChanged("Appointment");
      }
    }*/

    public User User
    {
      get { return user; }
      set
      {
        NotifyBeforeObjectChange();
        user = value;
        NotifyPropertyChanged("User");
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

  public class ExecutorList : DOList<Executor>
  {
  }
}