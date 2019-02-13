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
using BSB.Common.DB;

namespace ARM_User.MapperLayer.Guides
{
    public class SharerMapper
      : SimpleMapper<Sharer, SharerList, SharerDS.S_G_SHARERDataTable, SharerDS.S_G_SHARERRow>
    {
        protected override Sharer CreateByRow(SharerDS.S_G_SHARERRow row)
        {
            var obj = new Sharer(
              row.ID,
              row.NAMERU,
              row.NAMEKZ,
              row.IIN_BIN_OKPO_NUMBER,
              null, //MapperRegistry.Instance.GetDocKndMapper().Find(row.S_G_DOCUMENT_KND),
              row.DOC_NUM_UD_LICH,
              row.IsDOC_DATENull() ? (DateTime?)null : row.DOC_DATE,
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
                    var Sharer = (Sharer)obj;

                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "G_INS_SHARER";
                        cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("NameRu_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameKz_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("IIN_BIN_OKPO_Number_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("S_G_Document_Knd_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Doc_Num_Ud_Lich_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Doc_Date_", OracleDbType.Date, ParameterDirection.Input);
                        cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                        cmd.Parameters["NameRu_"].Value = Sharer.NameRu;
                        cmd.Parameters["NameKz_"].Value = Sharer.NameKz;
                        cmd.Parameters["IIN_BIN_OKPO_Number_"].Value = Sharer.IIN_BIN_OKPO_NUMBER;
                        cmd.Parameters["S_G_Document_Knd_"].Value = Sharer.DocKnd.Id;
                        cmd.Parameters["Doc_Num_Ud_Lich_"].Value = Sharer.DocNumUdLich;
                        cmd.Parameters["Doc_Date_"].Value = Sharer.DocDate;
                        cmd.Parameters["Is_Delete_"].Value = Sharer.IsDelete?1:0;
                        cmd.Parameters["Err_Msg"].Size = 4000;

                        cmd.ExecuteNonQuery();

                        if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                        {
                            var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                            var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                            if (errCode != 0)
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharerMapper)");// throw new OraCustomException(errCode, errMsg);
                        }

                        obj.SetId(((OracleDecimal)(cmd.Parameters["Id_"].Value)).Value);

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharerMapper)");
            }
        }

        public override void Update(ICollection<DomainObject> objCollection)
        {
            try
            {
                foreach (var obj in objCollection)
                {
                    var Sharer = (Sharer)obj;

                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.BindByName = true;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "G_UPD_SHARER";
                        cmd.Parameters.Add("Id_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("NameRu_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("NameKz_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("IIN_BIN_OKPO_Number_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("S_G_Document_Knd_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Doc_Num_Ud_Lich_", OracleDbType.Varchar2, ParameterDirection.Input);
                        cmd.Parameters.Add("Doc_Date_", OracleDbType.Date, ParameterDirection.Input);
                        cmd.Parameters.Add("Is_Delete_", OracleDbType.Decimal, ParameterDirection.Input);
                        cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);

                        cmd.Parameters["Id_"].Value = Sharer.Id;
                        cmd.Parameters["NameRu_"].Value = Sharer.NameRu;
                        cmd.Parameters["NameKz_"].Value = Sharer.NameKz;
                        cmd.Parameters["IIN_BIN_OKPO_Number_"].Value = Sharer.IIN_BIN_OKPO_NUMBER;
                        cmd.Parameters["S_G_Document_Knd_"].Value = Sharer.DocKnd.Id;
                        cmd.Parameters["Doc_Num_Ud_Lich_"].Value = Sharer.DocNumUdLich;
                        cmd.Parameters["Doc_Date_"].Value = Sharer.DocDate;
                        cmd.Parameters["Is_Delete_"].Value = Sharer.IsDelete?1:0;
                        cmd.Parameters["Err_Msg"].Size = 4000;

                        cmd.ExecuteNonQuery();

                        if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                        {
                            var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                            var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                            if (errCode != 0)
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharerMapper)");// throw new OraCustomException(errCode, errMsg);
                        }

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharerMapper)");
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
                        cmd.CommandText = "G_DEL_BANKS_CUST_R_ECB";
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
                                DBSupport.DBErrorHandler(errCode, errMsg + Environment.NewLine + "(occured in DBSupport.SharerMapper)");// throw new OraCustomException(errCode, errMsg);
                        }

                        MarkAsNeedLoad();
                    }
                }
            }
            catch (Exception oe)
            {
                DBSupport.DBErrorHandler(942, oe.Message + Environment.NewLine + "(occured in DBSupport.SharerMapper)");
            }
        }

        protected override string IdName()
        {
            return "ID";
        }
    }
}