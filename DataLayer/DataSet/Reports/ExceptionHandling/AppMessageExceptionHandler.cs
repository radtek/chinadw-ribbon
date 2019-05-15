using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using BSB.Common;
using BSB.Common.DB;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;

namespace ARM_User.ExceptionHandling
{
  [ConfigurationElementType(typeof (CustomHandlerData))]
  public class AppMessageExceptionHandler : IExceptionHandler
  {
    public AppMessageExceptionHandler(NameValueCollection ignore)
    {
    }

    public Exception HandleException(Exception exception, Guid handlingInstanceId)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");

      var ErrDlg = new TfrmAppErrorDlg();

      if (exception is OraCustomException)
      {
        var ex = (OraCustomException) exception;

        // �������� �� ErrMsg ������ ����������� � ��������� �� ������� � ���������� ������
        var MsgPartArr = DBSupport.GetErrorSubStrings(ex.FullErrorMsg);

        if (ex.MsgId == -20500 || ex.MsgId == -20599 || ex.MsgId == 942 ||
            ex.MsgId == 6550 || ex.MsgId == -6508) // ���� ��������� �� ������
        {
          ErrDlg.ErrCode = ex.MsgId.ToString();
          ErrDlg.ErrMsgEng = MsgPartArr[2];
          ErrDlg.ErrTrace = MsgPartArr[0];

          // {ORA-00942: Table or view does not exists}
          // {ORA-06550: Identifier ... must be declared}
          if ((ex.MsgId == 942 || ex.MsgId == 6550) && (MsgPartArr[3] == String.Empty))
            MsgPartArr[3] = LangTranslate.UiGetText("������������ ���� ��� ���������� ��������");

          // {ORA-06508: Could not find program unit being called}  
          if (ex.MsgId == -6508)
            MsgPartArr[3] = LangTranslate.UiGetText("��������������� ������� (��� ��������) ���� ��������� ��������,") + Environment.NewLine +
                            LangTranslate.UiGetText("��������� ���������� ���������� � ���������� ����������� � ��");

          ErrDlg.ErrMsgRus = MsgPartArr[3];
        }
        else // ��������� ORACLE'�
        {
          ErrDlg.ErrCode = ex.MsgId.ToString();
          ErrDlg.ErrMsgEng = MsgPartArr[2];
          ErrDlg.ErrMsgRus = MsgPartArr[3];
          ErrDlg.ErrTrace = MsgPartArr[2];
        }
      }
      else if (exception is OraApplicationException)
      {
        var ex = (OraApplicationException) exception;
        ErrDlg.ErrCode = ex.MsgId.ToString();
        ErrDlg.ErrMsgRus = ex.Message;
        ErrDlg.ErrTrace = ex.Loc + Environment.NewLine + ex.StackTrace;

        var sb = new StringBuilder();
        var writer = new StringWriter(sb);

        var formatter = new TextExceptionFormatter(writer, ex);
        formatter.Format();

        ErrDlg.ErrMsgEng = sb.ToString();
      }
      else if (exception is ApplicationException)
      {
        var ex = (ApplicationException) exception;
        ErrDlg.ErrCode = "";
        ErrDlg.ErrMsgRus = ex.Message;
        ErrDlg.ErrTrace = ex.StackTrace;

        var sb = new StringBuilder();
        var writer = new StringWriter(sb);

        var formatter = new TextExceptionFormatter(writer, ex);
        formatter.Format();

        ErrDlg.ErrMsgEng = sb.ToString();
      }
      else if (exception is OracleException)
      {
        var ex = (OracleException) exception;
        ErrDlg.ErrCode = ex.Number.ToString();
        ErrDlg.ErrMsgRus = ex.Message;
        ErrDlg.ErrTrace = ex.StackTrace;

        var sb = new StringBuilder();
        var writer = new StringWriter(sb);

        var formatter = new TextExceptionFormatter(writer, ex);
        formatter.Format();

        ErrDlg.ErrMsgEng = sb.ToString();
      }
      else
      {
        var ex = exception;
        ErrDlg.ErrCode = "";
        ErrDlg.ErrMsgRus = ex.Message;
        ErrDlg.ErrTrace = ex.StackTrace;

        var sb = new StringBuilder();
        var writer = new StringWriter(sb);

        var formatter = new TextExceptionFormatter(writer, ex);
        formatter.Format();

        ErrDlg.ErrMsgEng = sb.ToString();
      }

      ErrDlg.ShowDialog();

      return exception;
    }
  }
}