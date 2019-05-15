using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.GuidesDataSet;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections;
using ARM_User.DataLayer;
using BSB.Common.DB;
//using ARM_User.DataLayer.DataSet.GuidesDataSet;

namespace ARM_User.MapperLayer.Guides
{
  public class RegOrganMUMapper
    : SimpleMapper<RegOrganMU, RegOrganMUList, RegOrganMUDS.S_G_REG_ORGAN_MUDataTable, RegOrganMUDS.S_G_REG_ORGAN_MURow>
  {
    protected override RegOrganMU CreateByRow(RegOrganMUDS.S_G_REG_ORGAN_MURow row)
    {
      var obj = new RegOrganMU(
        row.ID,
        row.PARENT_ID,
        row.NAME,
        row.TYPE_ELEMENT,
        row.NUM_LEVEL,
        row.LAST_ELEMENT_HIERARCHY,
        row.IS_DELETE == 1);

      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var RegOrganMU = (RegOrganMU) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "S_G_INS_REG_ORGAN_MU";
            cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Parent_ID_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Name_", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("Type_Element_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Last_Element_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
            if (RegOrganMU.RegOrganMUParent != null)
              cmd.Parameters["Parent_ID_"].Value = RegOrganMU.ParentId;
            cmd.Parameters["Name_"].Value = RegOrganMU.Name;
            cmd.Parameters["Type_Element_"].Value = RegOrganMU.TypeElement;
            cmd.Parameters["Last_Element_"].Value = RegOrganMU.LastElementHierarchy;
            cmd.Parameters["Is_Delete_"].Value = RegOrganMU.IsDelete ? 1 : 0;
            
            cmd.Parameters["Err_Msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["Err_Code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["Err_Code"].Value).ToInt32();
              var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)"); //throw new OraCustomException(errCode, errMsg);
              else
                  obj.SetId(((OracleDecimal)(cmd.Parameters["Id_"].Value)).Value);
            }

            

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)");
      }
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      try
      {
        foreach (var obj in objCollection)
        {
          var RegOrganMU = (RegOrganMU) obj;

          using (var cmd = Connection.CreateCommand())
          {
            cmd.BindByName = true;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "S_G_UPD_REG_ORGAN_MU";
            cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Parent_ID_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Name_", OracleDbType.Varchar2, ParameterDirection.Input);
            cmd.Parameters.Add("Type_Element_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
            cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

            cmd.Parameters["Id_"].Value = RegOrganMU.Id;
            if (RegOrganMU.RegOrganMUParent != null)
                cmd.Parameters["Parent_ID_"].Value = RegOrganMU.ParentId;
            cmd.Parameters["Name_"].Value = RegOrganMU.Name;
            cmd.Parameters["Type_Element_"].Value = RegOrganMU.TypeElement;
            cmd.Parameters["Is_Delete_"].Value = RegOrganMU.IsDelete ? 1 : 0;
            cmd.Parameters["Err_Msg"].Size = 4000;

            cmd.ExecuteNonQuery();

            if (!((OracleDecimal) cmd.Parameters["Err_Code"].Value).IsNull)
            {
              var errCode = ((OracleDecimal) cmd.Parameters["Err_Code"].Value).ToInt32();
              var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
              if (errCode != 0)
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)");
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
            cmd.CommandText = "S_G_DEL_REG_ORGAN_MU";
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
                  DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)"); //throw new OraCustomException(errCode, errMsg);
            }

            MarkAsNeedLoad();
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.RegOrganMUMapper)");
      }
    }

    public virtual RegOrganMUList FindByCondition(decimal id_guides)
    {
        var objList = new RegOrganMUList();
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
            var gw = DataGatewayFactoryHolder.CacheFactory.GetRegOrganMUGateway();
            var tab = new RegOrganMUDS.S_G_REG_ORGAN_MUDataTable();
            gw.Load(tab, id_guides,0);
            return tab.Rows;
        }
    }
    public virtual RegOrganMU FindById(decimal id_ref)
    {
        var objList = new RegOrganMUList();
        objList.Loader = new VLLoader(new ByIdTableLoader(id_ref), this);
        if (objList.Count > 0)
            return objList[0];
        else
            return null;
    }
    public class ByIdTableLoader : TableLoader
    {
        private readonly decimal id_ref;

        public ByIdTableLoader(decimal id_ref)
        {
            this.id_ref = id_ref;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetRegOrganMUGateway();
            var tab = new RegOrganMUDS.S_G_REG_ORGAN_MUDataTable();
            gw.Load(tab, 0, id_ref);
            return tab.Rows;
        }
    }
    protected override string IdName()
    {
      return "ID";
    }
  }
}