using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides.Simple;
using ARM_User.DataLayer.DataSet.CommonDataSet;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using BSB.Common.DB;

namespace ARM_User.MapperLayer.Guides.Simple
{
  public class LocalTextMapper
    : SimpleMapper<LocalText, LocalTextList, LocalTextDS.REF_LOCAL_TEXTDataTable, LocalTextDS.REF_LOCAL_TEXTRow>,
      LocalText.ILocalTextFinder
  {
    protected override LocalText CreateByRow(LocalTextDS.REF_LOCAL_TEXTRow row)
    {
      var obj = new LocalText(
        row.ID,
        row.IsEDIT_USER_IDNull() ? null : MapperRegistry.Instance.GetUserMapper().Find(row.EDIT_USER_ID),
        row.IsEDIT_TIMENull() ? null : (DateTime?) row.EDIT_TIME,
        row.KEY_TEXT,
        row.LOCAL_TEXT);
      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var localText = (LocalText) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "main.pkg_ref.ins_local_text";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_key_text", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_local_text", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_edit_time", OracleDbType.Date, ParameterDirection.Input);
            cmd.Parameters.Add("p_edit_user_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["p_key_text"].Value = localText.KeyText;
            cmd.Parameters["p_local_text"].Value = localText.TransText;
            cmd.Parameters["p_edit_time"].Value = localText.EditTime;
            cmd.Parameters["p_edit_user_id"].Value = localText.EditUser.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            obj.SetId(((OracleDecimal) (cmd.Parameters["p_id"].Value)).Value);

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)");
      }
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var localText = (LocalText) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "main.pkg_ref.upd_local_text";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_key_text", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_local_text", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("p_edit_time", OracleDbType.Date, ParameterDirection.Input);
            cmd.Parameters.Add("p_edit_user_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["p_id"].Value = localText.Id;
            cmd.Parameters["p_key_text"].Value = localText.KeyText;
            cmd.Parameters["p_local_text"].Value = localText.TransText;
            cmd.Parameters["p_edit_time"].Value = localText.EditTime;
            cmd.Parameters["p_edit_user_id"].Value = localText.EditUser.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)");
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
            cmd.CommandText = "main.pkg_ref.del_local_text";
            cmd.Parameters.Add("p_id", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_do_commit", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("p_err_code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["p_id"].Value = obj.Id;
            cmd.Parameters["p_do_commit"].Value = 0;
            cmd.Parameters["p_err_msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["p_err_code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["p_err_code"].Value).ToInt32();
              var errMsg = cmd.Parameters["p_err_msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.LocalTextMapper)");
      }
    }

    protected override string IdName()
    {
      return "ID";
    }
  }
}