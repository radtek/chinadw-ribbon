using System;
using System.Runtime.Serialization;
using BSB.Common;
using Oracle.DataAccess.Client;

namespace ARM_User
{

  #region Global Exceptions

  #endregion

  #region Data Layer Exceptions

  public class OraApplicationException : ApplicationException
  {
    public OraApplicationException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException)
    {
      FullErrorMsg = fullErrorMsg;
      Error = error;
      MsgType = msgType;
      MsgId = msgId;
      Loc = loc;
    }

    public OraApplicationException(int msgId, string fullErrorMsg)
    {
      MsgId = msgId;
      FullErrorMsg = fullErrorMsg;
    }

    protected OraApplicationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public string FullErrorMsg { get; private set; }
    public string Error { get; private set; }
    public string MsgType { get; private set; }
    public int MsgId { get; private set; }
    public string Loc { get; private set; }
  }

  public class OraCustomException : OraApplicationException
  {
    public OraCustomException(
      int msgId,
      string message)
      : base(msgId, message)
    {
    }
  }

  public class OraSystemException : OraApplicationException
  {
    public OraSystemException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException, fullErrorMsg, error, msgType, msgId, loc)
    {
    }

    protected OraSystemException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }

  public class ConcurrencyException : OraApplicationException
  {
    public ConcurrencyException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException, fullErrorMsg, error, msgType, msgId, loc)
    {
    }

    protected ConcurrencyException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }

  public class MandatoryMissingException : OraApplicationException
  {
    public MandatoryMissingException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException, fullErrorMsg, error, msgType, msgId, loc)
    {
    }

    protected MandatoryMissingException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }

  public class UKViolationException : OraApplicationException
  {
    public UKViolationException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException, fullErrorMsg, error, msgType, msgId, loc)
    {
    }

    protected UKViolationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }

  public class DeleteRestrictException : OraApplicationException
  {
    public DeleteRestrictException(
      string message,
      OracleException innerException,
      string fullErrorMsg,
      string error,
      string msgType,
      int msgId,
      string loc)
      : base(message, innerException, fullErrorMsg, error, msgType, msgId, loc)
    {
    }

    protected DeleteRestrictException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }

  public class AccessViolationException : ApplicationException
  {
    protected AccessViolationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public AccessViolationException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public AccessViolationException()
      : base(LangTranslate.UiGetText("ACCESS_VIOLATION_EXCEPTION"))
    {
    }
  }

  #endregion

  #region Mapper Layer Exceptions

  #endregion

  #region Business Layer Exceptions

  public class ReadOnlyException : ApplicationException
  {
    public ReadOnlyException()
      : base(LangTranslate.UiGetText("Попытка отредактировать не редактируемый объект"))
    {
    }

    public ReadOnlyException(string message)
      : base(LangTranslate.UiGetText("Попытка отредактировать не редактируемый объект \"" + message + "\""))
    {
    }

    protected ReadOnlyException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public ReadOnlyException(string message, Exception innerException)
      : base(LangTranslate.UiGetText("Попытка отредактировать не редактируемый объект \""+ message + "\""), innerException)
    {
    }
  }

  public class OneTransactionException : ApplicationException
  {
    public OneTransactionException()
    {
    }

    public OneTransactionException(string message)
      : base(message)
    {
    }

    protected OneTransactionException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public OneTransactionException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }

  public class FieldTooSmallException : ApplicationException
  {
    public FieldTooSmallException()
    {
    }

    public FieldTooSmallException(string propertyName)
      : base(String.Format(LangTranslate.UiGetText("FIELD_TOO_SMALL_EXCEPTION"), propertyName))
    {
    }

    protected FieldTooSmallException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public FieldTooSmallException(string propertyName, Exception innerException)
      : base(String.Format(LangTranslate.UiGetText("FIELD_TOO_SMALL_EXCEPTION"), propertyName), innerException)
    {
    }
  }

  public class PropertyNullException : ApplicationException
  {
    public PropertyNullException()
    {
    }

    public PropertyNullException(string propertyName)
      : base(String.Format(LangTranslate.UiGetText("Обязательное поле \"{0}\" не заполнено"), propertyName))
    {
    }

    protected PropertyNullException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public PropertyNullException(string propertyName, Exception innerException)
      : base(
        String.Format(LangTranslate.UiGetText("Обязательное поле \"{0}\" не заполнено"), propertyName), innerException)
    {
    }
  }

  public class PropertyInvalidException : ApplicationException
  {
    public PropertyInvalidException()
    {
    }

    public PropertyInvalidException(string message)
      : base(message)
    {
    }

    protected PropertyInvalidException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public PropertyInvalidException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }

  #endregion

  #region Service Layer Exceptions

  #endregion

  #region Display Layer Exceptions

  #endregion
}