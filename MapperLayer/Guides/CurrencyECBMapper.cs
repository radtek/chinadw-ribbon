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
using DevExpress.XtraEditors;
using System.Windows.Forms;
using BSB.Common;

namespace ARM_User.MapperLayer.Guides
{
    public class CurrencyECBMapper
      : SimpleMapper<CurrencyECB, CurrencyECBList, CurrencyECBDS.S_G_CURRENCY_ECBDataTable, CurrencyECBDS.S_G_CURRENCY_ECBRow>
    {
        protected override CurrencyECB CreateByRow(CurrencyECBDS.S_G_CURRENCY_ECBRow row)
        {
            var obj = new CurrencyECB(
              row.ID,
              row.CODE,
              row.DESIGNATION_NIN,
              row.NAMERU,
              row.NAMEKZ,
              row.IS_DELETE==1,
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
                    var CurrencyECB = (CurrencyECB)obj;

                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "g_insert_g_currency_ecb";
                        cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Code_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Designation_NIN_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameRu_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameKz_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                        cmd.Parameters["Code_"].Value = CurrencyECB.Code;
                        cmd.Parameters["Designation_NIN_"].Value = CurrencyECB.Desig;
                        cmd.Parameters["NameRu_"].Value = CurrencyECB.Nameru;
                        cmd.Parameters["NameKz_"].Value = CurrencyECB.Namekz;
                        cmd.Parameters["Is_Delete_"].Value = CurrencyECB.Isdelete?1:0;
                        cmd.Parameters["Err_Msg"].Size = 4000;

                        cmd.ExecuteNonQuery();

                        if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                        {
                            var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                            var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                            if (errCode != 0)
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper)."); //throw new OraCustomException(errCode, errMsg);
                            else
                                obj.SetId(((OracleDecimal)(cmd.Parameters["Id_"].Value)).Value);
                        }

                        

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper)");
            }
        }

        public override void Update(ICollection<DomainObject> objCollection)
        {
            try
            {
                foreach (var obj in objCollection)
                {
                    var CurrencyECB = (CurrencyECB)obj;

                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "g_update_g_currency_ecb";
                        cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Code_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Designation_NIN_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameRu_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameKz_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                        cmd.Parameters["Id_"].Value = CurrencyECB.Id;
                        cmd.Parameters["Code_"].Value = CurrencyECB.Code;
                        cmd.Parameters["Designation_NIN_"].Value = CurrencyECB.Desig;
                        cmd.Parameters["NameRu_"].Value = CurrencyECB.Nameru;
                        cmd.Parameters["NameKz_"].Value = CurrencyECB.Namekz;
                        cmd.Parameters["Is_Delete_"].Value = CurrencyECB.Isdelete?1:0;
                        cmd.Parameters["Err_Msg"].Size = 4000;

                        cmd.ExecuteNonQuery();

                        if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                        {
                            var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                            var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                            if (errCode != 0)
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper)."); //throw new OraCustomException(errCode, errMsg);
                        }

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper)");
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
                        cmd.CommandText = "g_delete_g_currency_ecb";
                        cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                        cmd.Parameters["Id_"].Value = obj.Id;
                        cmd.Parameters["Err_Msg"].Size = 4000;

                        cmd.ExecuteNonQuery();

                        if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                        {
                            var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                            var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                            if (errCode != 0)
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper).");// throw new OraCustomException(errCode, errMsg);
                        }

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.CurrencyECBMapper)");
            }
        }
        public virtual CurrencyECBList FindByCondition(decimal id_guides)
        {
            var objList = new CurrencyECBList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetCurrencyECBGateway();
                var tab = new CurrencyECBDS.S_G_CURRENCY_ECBDataTable();
                gw.Load(tab, id_guides,0);
                return tab.Rows;
            }
        }

        public virtual CurrencyECB FindById(decimal id)
        {
            var objList = new CurrencyECBList();
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
                var gw = DataGatewayFactoryHolder.CacheFactory.GetCurrencyECBGateway();
                var tab = new CurrencyECBDS.S_G_CURRENCY_ECBDataTable();
                gw.Load(tab, 0, id);
                return tab.Rows;
            }
        }
        protected override string IdName()
        {
            return "ID";
        }
    }
}