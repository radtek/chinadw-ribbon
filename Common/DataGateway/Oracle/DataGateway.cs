using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;

namespace BSB.Common.DataGateway.Oracle
{
  public abstract class DataGateway : IDataGateway
  {
    #region Fields

    //private OracleConnection connection;
    private readonly OracleDataAdapter adapter = new OracleDataAdapter();

    #endregion

    #region Constructors

    public DataGateway()
    {
    }

    public DataGateway(OracleConnection connection)
    {
      //Connection = connection;
    }

    #endregion

    //#region Methods

    //protected virtual void InitConnection()
    //{
    //  Connection = ConnectionHolder.Instance.Connection;
    //}

    //#endregion

    #region Properties

    public OracleConnection Connection
    {
      get
      {
        //if (this.connection == null)
        //{
        //  this.InitConnection();
        //}
        //return this.connection;
        return ConnectionHolder.Instance.Connection;
      }
      //set
      //{
      //  this.connection = value;
      //  if (this.Adapter.InsertCommand != null)
      //  {
      //    this.Adapter.InsertCommand.Connection = value;
      //  }
      //  if (this.Adapter.DeleteCommand != null)
      //  {
      //    this.Adapter.DeleteCommand.Connection = value;
      //  }
      //  if (this.Adapter.UpdateCommand != null)
      //  {
      //    this.Adapter.UpdateCommand.Connection = value;
      //  }
      //}
    }

    protected OracleDataAdapter Adapter
    {
      get { return adapter; }
    }

    #endregion

    #region IDataGateway Members

    public abstract void Load(DataTable dataTable);

    public virtual void Load(Decimal key, DataTable dataTable)
    {
      throw new NotSupportedException();
    }

    public virtual void Lock(DataRow dataRow)
    {
      throw new NotSupportedException();
    }

    public virtual void Update(DataTable dataTable)
    {
      throw new NotSupportedException();
    }

    #endregion
  }

  public abstract class ChildDataGateway : DataGateway, IChildDataGateway
  {
    public ChildDataGateway()
    {
    }

    public ChildDataGateway(OracleConnection connection)
      : base(connection)
    {
    }

    protected abstract string ProcedureLstName { get; }
    protected abstract string ParamIdParentName { get; }

    public override void Load(DataTable dataTable)
    {
      throw new NotSupportedException();
    }

    #region IChildDataGateway Members

    public virtual void LoadByParent(decimal idParent, DataTable dataTable)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = ProcedureLstName;
          cmd.Parameters.Add("cur", OracleDbType.RefCursor, ParameterDirection.Output);
          cmd.Parameters.Add(ParamIdParentName, idParent);

          Adapter.SelectCommand = cmd;
          Adapter.Fill(dataTable);
        }
      }
      catch (Exception ex)
      {
        var rethrow = ExceptionPolicy.HandleException(ex, "Data Policy");
        if (rethrow)
        {
          throw;
        }
      }
    }

    #endregion
  }
}