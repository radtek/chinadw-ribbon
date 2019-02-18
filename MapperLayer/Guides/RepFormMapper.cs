using System;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.BusinessLayer.Guides;
using ARM_User.DataLayer.DataSet.GuidesDataSet;
using ARM_User.MapperLayer.Common;
using BSB.Common;
using BSB.Common.DB;
using Oracle.DataAccess.Client;
using System.Collections;
using ARM_User.DataLayer;

namespace ARM_User.MapperLayer.Guides
{
  public class RepFormMapper
    : SimpleMapper<RepForm, RepFormList, RepFormDS.G_FORMDataTable, RepFormDS.G_FORMRow>
  {
    protected override RepForm CreateByRow(RepFormDS.G_FORMRow row)
    {
      var obj = new RepForm(
        row.ID,
        row.NAME_RU,
        row.NAME_KZ,
        2,
        row.CODE,
        row.REPORT_KND
        //row.TEMPLATE_RU,
        //row.TEMPLATE_KZ
        );

      return obj;
    }

    public override void Insert(ICollection<DomainObject> objCollection)
    {
      //
    }

    public override void Update(ICollection<DomainObject> objCollection)
    {
      //
    }

    public override void Delete(ICollection<DomainObject> objCollection)
    {
      //
    }

    protected override string IdName()
    {
      return "ID";
    }

    public byte[] GetTemplate(decimal id, LanguageIds langId)
    {
      try
      {
        using (var cmd = Connection.CreateCommand())
        {
          cmd.BindByName = true;
          cmd.CommandText = "select " + (langId == LanguageIds.Russian ? "TEMPLATE_RU" : "TEMPLATE_KZ") + " TEMPLATE from prepared.G_FORM where ID = :p_id";
          cmd.Parameters.Add("p_id", OracleDbType.Int32, id, ParameterDirection.Input);

          var adapter = new OracleDataAdapter(cmd);
          var dataTable = new DataTable();
          adapter.Fill(dataTable);

          foreach (DataRow row in dataTable.Rows)
          {
            var blob = (Byte[])row["TEMPLATE"];
            return blob;
          }
        }
      }
      catch (Exception oe)
      {
          DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.ProcessMapper)");
      }
      /*catch (Exception ex)
      {
        AppErrSupport.ErrorHandler(ex);
      }*/

      return null;
    }

    public virtual RepFormList FindBylist(decimal id_kind)
    {
        var objList = new RepFormList();
        objList.Loader = new VLLoader(new ByConditionTableLoader(id_kind), this);
        return objList;
    }
    public class ByConditionTableLoader : TableLoader
    {
        private readonly decimal id_kind;

        public ByConditionTableLoader(decimal id_kind)
        {
            this.id_kind = id_kind;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetRepFormGateway();
            var tab = new RepFormDS.G_FORMDataTable();
            gw.Load(tab, id_kind);
            return tab.Rows;
        }
    }

    public virtual RepFormList FindIdlist(Int64 id_rep)
    {
        var objList = new RepFormList();
        objList.Loader = new VLLoader(new ByIdTableLoader(id_rep), this);
        return objList;
    }
    public class ByIdTableLoader : TableLoader
    {
        private readonly Int64 id_rep;

        public ByIdTableLoader(Int64 id_rep)
        {
            this.id_rep = id_rep;
        }

        public override ICollection CreateAndLoad()
        {
            var gw = DataGatewayFactoryHolder.CacheFactory.GetRepFormGateway();
            var tab = new RepFormDS.G_FORMDataTable();
            gw.Load(tab, id_rep);
            return tab.Rows;
        }
    }
  }
}