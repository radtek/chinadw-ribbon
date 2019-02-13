using System;
using System.Collections.Specialized;
using BSB.Common;
using BSB.Common.DataGateway.Oracle;
using BSB.Common.DB.Admin;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Oracle.DataAccess.Client;

namespace ARM_User.ExceptionHandling
{
  [ConfigurationElementType(typeof (CustomHandlerData))]
  public class OracleExceptionHandler : IExceptionHandler
  {
    public OracleExceptionHandler(NameValueCollection ignore)
    {
    }

    public Exception HandleException(Exception exception, Guid handlingInstanceId)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");
      if (!(exception is OracleException))
        throw new ArgumentException("exception");

      var oraException = (OracleException) exception;
      Exception resultException;

      if (oraException.Number == 20998)
      {
        TPkgError.ERR_REC ErrorRec = null;
        var ErrorPack = new TPkgError(ConnectionHolder.Instance.Connection);
        ErrorPack.GetErr(out ErrorRec);
        //string ErrorMsg = ErrorPack.GetErrors();

        if (ErrorRec.msg_id == 101 || ErrorRec.msg_id == 102 || ErrorRec.msg_id == 103 || ErrorRec.msg_id == 104)
        {
          // Если err_upd_no_data_found, err_del_no_data_found, err_read_no_data_found, err_lock_no_data_found
          resultException = new ConcurrencyException(ErrorRec.msg, oraException, oraException.Message, ErrorRec.error,
            ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
        else if (ErrorRec.msg_id == -1400 || ErrorRec.msg_id == -1407)
        {
          // Если err_mandatory_missing, err_upd_mandatory_null
          resultException = new MandatoryMissingException(ErrorRec.msg, oraException, oraException.Message,
            ErrorRec.error, ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
        else if (ErrorRec.msg_id == -1)
        {
          // Если err_uk_violation
          resultException = new UKViolationException(ErrorRec.msg, oraException, oraException.Message, ErrorRec.error,
            ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
        else if (ErrorRec.msg_id == -1)
        {
          // Если err_delete_restrict
          resultException = new DeleteRestrictException(ErrorRec.msg, oraException, oraException.Message, ErrorRec.error,
            ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
        else if (ErrorRec.msg_id < 0)
        {
          // Если обернутая ошибка Oracle
          resultException = new OraSystemException(ErrorRec.msg, oraException, oraException.Message, ErrorRec.error,
            ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
        else
        {
          // Остальные "пользовательские" ошибки
          resultException = new OraApplicationException(ErrorRec.msg, oraException, oraException.Message, ErrorRec.error,
            ErrorRec.msg_type, ErrorRec.msg_id, ErrorRec.loc);
          //throw resultException;
        }
      }
      else if (oraException.Number == 942 || oraException.Number == 6550)
      {
        // Если недостаточно прав
        //{ORA-00942: Table or view does not exists}
        //{ORA-06550: Identifier ... must be declared}
        resultException = new AccessViolationException(LangTranslate.UiGetText("Недостаточно привилегий"), oraException);
        //throw resultException;
      }
      else if (oraException.Number == 3114 || oraException.Number == 3135 || oraException.Number == 12571)
      {
        // Если  
        // ORA-03134: not connected to ORACLE
        // ORA-03135: connection lost contact
        // ORA-12571: TNS:packet writer failure
        resultException = oraException;
        try
        {
          ConnectionHolder.Instance.TryRestoreConnection();
        }
        catch
        {
        }
      }
      else
      {
        resultException = oraException;
      }
      return resultException;
    }
  }
}