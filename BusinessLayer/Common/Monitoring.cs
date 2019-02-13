using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSB.Common.DataGateway.Oracle;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.BusinessLayer.Common
{
    public class Monitoring
    {
        public static string Check_CapSize()
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_READ_CAPSIZECHECK";                  

                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);                   

                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return("Проверка на несоответствие уставного капитала прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }         
        }
        public static string Check_IsssueReport(DateTime? DateMon)
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_Read_DateSubmReportCheck";
                    cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Date_"].Value = DateMon;
                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return ("Проверка предоставления отчетов о размещении ЭЦБ  прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }
        }

        public static string Check_RpmReport(DateTime? DateMon)
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_Read_DateSubmRpmReportCheck";
                    cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Date_"].Value = DateMon;
                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return ("Проверка предоставления отчетов о погашении ЭЦБ прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }
        }
        public static string Check_ViolEnforce(DateTime? DateMon)
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_Read_ViolEnforceCheck";
                    cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Date_"].Value = DateMon;
                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return ("Проверка наступления срока исполнения ОМВ прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }
        }
        public static string Check_ViolSnactions(DateTime? DateMon)
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_READ_VIOLSANCTIONSCHECK";
                    cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Date_"].Value = DateMon;
                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return ("Проверка наступления срока исполнения АП прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }
        }
        public static string Check_ViolRefuseDoc(DateTime? DateMon)
        {
            try
            {
                var cmd = ConnectionHolder.Instance.Connection.CreateCommand();
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "V_Read_RefuseDoc";
                    cmd.Parameters.Add("Date_", OracleDbType.Date, ParameterDirection.Input);
                    cmd.Parameters.Add("Err_Code", OracleDbType.Decimal, ParameterDirection.Output);
                    cmd.Parameters.Add("Err_Msg", OracleDbType.Varchar2, ParameterDirection.Output);
                    cmd.Parameters["Date_"].Value = DateMon;
                    cmd.ExecuteNonQuery();

                    if (!((OracleDecimal)cmd.Parameters["Err_Code"].Value).IsNull)
                    {
                        var errCode = ((OracleDecimal)cmd.Parameters["Err_Code"].Value).ToInt32();
                        var errMsg = cmd.Parameters["Err_Msg"].Value.ToString();
                        if (errCode != 0)
                            throw new OraCustomException(errCode, errMsg);
                    }
                    return ("Проверка наступления сроков представления документов после отказа прошла успешно");
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
                return null;
            }
        }
    }
}
