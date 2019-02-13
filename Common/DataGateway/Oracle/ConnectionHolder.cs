using System.Data;
using Oracle.DataAccess.Client;

namespace BSB.Common.DataGateway.Oracle
{
  public class ConnectionHolder
  {
    protected static ConnectionHolder _Instance;

    protected ConnectionHolder()
    {
    }

    static ConnectionHolder()
    {
      _Instance = new ConnectionHolder();
    }

    public static ConnectionHolder Instance
    {
      get { return _Instance; }
    }

    public virtual OracleConnection Connection
    {
      get { return dmControler.frmMain.oracleConnection; }
    }

    public virtual void TryRestoreConnection()
    {
      if (dmControler.frmMain.oracleConnection.State == ConnectionState.Open)
      {
        var oldOC = dmControler.frmMain.oracleConnection;
        var newOC = (OracleConnection) dmControler.frmMain.oracleConnection.Clone();
        try
        {
          newOC.Open();
          dmControler.frmMain.oracleConnection = newOC;
          oldOC.Dispose();
        }
        catch
        {
          newOC.Dispose();
        }
      }
    }
  }
}