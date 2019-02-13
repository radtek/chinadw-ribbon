using System;
using BSB.Actions;
using DevExpress.XtraEditors;

namespace BSB.Common
{
  /// <summary>
  ///   ������ ��� ������ � ������� ����
  /// </summary>
  public class TMenuData
  {
    public MyAction pAction = null;
    public Int32 pAppMenuItem;
    public string pCaption;
    public string pHint;
    public Int32 pImageIndex;
    public string pShortCut;
    public XtraForm pForm; //��� ������ ����
  }
}