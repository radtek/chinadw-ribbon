using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.GuidesDataSet;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Collections;
using ARM_User.DataLayer;
using BSB.Common.DB;

namespace ARM_User.MapperLayer.Guides
{
  public class ExecutorMapper
    : SimpleMapper<Executor, ExecutorList, ExecutorDS.S_G_EXECUTORDataTable, ExecutorDS.S_G_EXECUTORRow>
  {
    protected override Executor CreateByRow(ExecutorDS.S_G_EXECUTORRow row)
    {
      var obj = new Executor(
        row.ID,
        row.ID_OFFICIAL,
        row.LOGIN,
        row.S_G_APPOINTMENT,
        row.APP_NAME,
        row.SIGNATURE_FNF,
        row.IS_DELETE == 1,
        MapperRegistry.Instance.GetUserMapper().Find(row.ID_USR),
        row.DATLAST);

      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var executor = (Executor) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "S_G_INS_EXECUTOR";
            cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Id_Official_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("S_G_Appointment_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Signature_FNF_", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["Id_Official_"].Value = executor.User.Id;
                        cmd.Parameters["S_G_Appointment_"].Value = null; //executor.Appointment.Id;
            cmd.Parameters["Signature_FNF_"].Value = executor.SignatureFNF;
            cmd.Parameters["Is_Delete_"].Value = executor.IsDelete ? 1 : 0;
            cmd.Parameters["Err_Msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["Err_Code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["Err_Code"].Value).ToInt32();
              var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)");//throw new OraCustomException(errCode, errMsg);
              else
                  obj.SetId(((OracleDecimal)(cmd.Parameters["Id_"].Value)).Value);
            }

            

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)");
      }
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var executor = (Executor) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "S_G_UPD_EXECUTOR";
            cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Id_Official_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("S_G_Appointment_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Signature_FNF_", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["Id_"].Value = executor.Id;
            cmd.Parameters["Id_Official_"].Value = executor.User.Id;
                        cmd.Parameters["S_G_Appointment_"].Value = null; //executor.Appointment.Id;
            cmd.Parameters["Signature_FNF_"].Value = executor.SignatureFNF;
            cmd.Parameters["Is_Delete_"].Value = executor.IsDelete ? 1 : 0;
            cmd.Parameters["Err_Msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["Err_Code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["Err_Code"].Value).ToInt32();
              var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)");
      }
    }

    public override void Delete(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "G_DELETE_REGISTRARS";
            cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters["Id_"].Value = obj.Id;
            cmd.Parameters["Err_Msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["Err_Code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["Err_Code"].Value).ToInt32();
              var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ExecutorMapper)");
      }
    }

    public virtual ExecutorList FindByCondition(decimal id_guides)
    {
        var objList = new ExecutorList();
        objList.Loader = new VLLoader(new ByConditionTableLoader(id_guides), this);
        return objList;
    }
    public class ByConditionTableLoader : TableLoader
    {
        private readonly decimal id_guides;

        public ByConditionTableLoader(decimal id_guides)
        {
            this.id_guides = id_guides;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetExecutorGateway();
            var tab = new ExecutorDS.S_G_EXECUTORDataTable();
            gw.Load(tab, id_guides,0);
            return tab.Rows;
        }
    }

    public virtual Executor FindByUser(decimal id_user)
    {
        var objList = new ExecutorList();
        objList.Loader = new VLLoader(new ByUserTableLoader(id_user), this);
        if (objList.Count > 0)
            return objList[0];
        else
            return null;
    }
    public class ByUserTableLoader : TableLoader
    {
        private readonly decimal id_user;

        public ByUserTableLoader(decimal id_user)
        {
            this.id_user = id_user;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetExecutorGateway();
            var tab = new ExecutorDS.S_G_EXECUTORDataTable();
            gw.Load(tab, id_user,1);
            return tab.Rows;
        }
    }

     public virtual Executor FindById(decimal id)
    {
        var objList = new ExecutorList();
        objList.Loader = new VLLoader(new ByIdTableLoader(id), this);
        if (objList.Count > 0)
            return objList[0];
        else
            return null;
    }
    public class ByIdTableLoader : TableLoader
    {
        private readonly decimal id;

        public ByIdTableLoader(decimal id)
        {
            this.id = id;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetExecutorGateway();
            var tab = new ExecutorDS.S_G_EXECUTORDataTable();
            gw.Load(tab, id);
            return tab.Rows;
        }
    }
   
    protected override string IdName()
    {
      return "ID";
    }
  }


}