using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using BSB.Common.DB;

namespace ARM_User.MapperLayer.Guides.Simple
{
  public class SharedMapper
    : SimpleMapper<Shared, SharedList, SharedDS.REF_SHAREDDataTable, SharedDS.REF_SHAREDRow>,
      Shared.ISharedFinder
  {
    protected override Shared CreateByRow(SharedDS.REF_SHAREDRow row)
    {
      var obj = new Shared(
        row.ID,
        row.IsPARENT_IDNull() ? (decimal?)null : row.PARENT_ID,
        row.CODE,
        row.NAME_RU,
        row.NAME_KZ);
      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          Shared shared = (Shared)obj;
          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "main.pkg_ref.ins_shared";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_parent_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_code", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_name_ru", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_name_kz", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            if (shared.Parent != null)
              cmd.Parameters["p_parent_id"].Value = shared.Parent.Id;
            cmd.Parameters["p_code"].Value = shared.Code;
            cmd.Parameters["p_name_ru"].Value = shared.NameRu;
            cmd.Parameters["p_name_kz"].Value = shared.EditUser.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal)cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharedMapper)"); //throw new OraCustomException(errCode, errMsg);
              else
                  obj.SetId(((OracleDecimal)(cmd.Parameters["p_id"].Value)).Value);
            }

            

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharedMapper)");
      }
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          Shared shared = (Shared)obj;
          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "main.pkg_ref.upd_shared";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_parent_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_code", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_name_ru", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_name_kz", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["p_id"].Value = shared.Id;
            if (shared.Parent != null)
              cmd.Parameters["p_parent_id"].Value = shared.Parent.Id;            
            cmd.Parameters["p_code"].Value = shared.Code;
            cmd.Parameters["p_name_ru"].Value = shared.NameRu;
            cmd.Parameters["p_name_kz"].Value = shared.EditUser.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal)cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharedMapper)"); //throw new OraCustomException(errCode, errMsg);
            }            

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharedMapper)");
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
            cmd.CommandText = "main.pkg_ref.del_shared";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["p_id"].Value = obj.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal)cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal)cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharedMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharedMapper)");
      }
    }

    protected override string IdName()
    {
      return "ID";
    }

    #region ISharedListFinder Members

    public SharedList FindByParentId(decimal parentId)
    {
      return FindBy("PARENT_ID", parentId);
    }

    #endregion
  }
}