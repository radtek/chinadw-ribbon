using System;
using System.Text;
using BSB.Win32API;

namespace BSB.Common
{
  /// <summary>
  ///   Summary description for Utilities.
  /// </summary>
  public class Utilities
  {
    /// <summary>
    ///   ���������� ����� ���������� � ���������� ������������
    /// </summary>
    public static void GetPCData(out string ComputerName,
      out Int32 OSPlatformId,
      out Int32 OSMajorVer,
      out Int32 OSMinorVer,
      out Int32 OSBuildNumber,
      out Int32 CPUAmount,
      out Int32 CPUType,
      out UInt32 FixedDrives,
      out UInt32 DiskCSerNum)
    {
      // ���������� ��� ����������
      ComputerName = Environment.MachineName;

      // ���������� ��� � ������ ��
      switch (Environment.OSVersion.Platform)
      {
        case PlatformID.Win32NT:
          OSPlatformId = 2;
          break;
        case PlatformID.Win32S:
          OSPlatformId = 0;
          break;
        case PlatformID.Win32Windows:
          OSPlatformId = 1;
          break;
        case PlatformID.WinCE:
          OSPlatformId = 3;
          break;
        default:
          OSPlatformId = 4;
          break;
      }

      OSMajorVer = Environment.OSVersion.Version.Major;
      OSMinorVer = Environment.OSVersion.Version.Minor;
      OSBuildNumber = Environment.OSVersion.Version.Build;

      // ���������� ��� CPU
      var si = new SYSTEM_INFO();
      Win32.GetSystemInfo(ref si);
      CPUAmount = (int) si.dwNumberOfProcessors;

      if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        CPUType = si.dwProcessorLevel;
      else
        CPUType = (int) si.dwProcessorType;

      // �������� ������ ���������� ������ (������� �������������)
      var LogDrives = Win32.GetLogicalDrives();

      // ��������� ������ ���������� ������ (������, ������� ������ - ���� A)
      var LogDrivesStr = DWord2Bin(LogDrives);

      // ���������� ���� ������ ��� ����� ��������� ������
      // � ��������� ������ ������� ������.
      var LogDrivesStrLen = LogDrivesStr.Length;
      var FixedDrivesStr = String.Empty;
      string DrvLetter;
      uint DrvType;
      for (var i = 0; i < LogDrivesStrLen; i++)
      {
        if (LogDrivesStr[i] == '0')
        {
          FixedDrivesStr += "0";
          continue;
        }
        DrvLetter = Chr((uint) (65 + (LogDrivesStrLen - i - 1))).ToString();
        DrvType = Win32.GetDriveType(DrvLetter + @":\");
        if (DrvType == 3) // Hard Drive
          FixedDrivesStr += "1";
        else
          FixedDrivesStr += "0";
      }

      // ������ ������� ������������� ��������� ������� ������ (������, ������� ������ - ���� A)}
      FixedDrives = Bin2DWord(FixedDrivesStr);

      // ���������� �������� ����� ����� C
      DiskCSerNum = GetDiskSerNum(@"C:\");
    }

    /// <summary>
    ///   ���������� ����� ���������� � ���������� ������������ � ��������� ����
    /// </summary>
    public static void GetPCDataStr(Int32 OSPlatformId,
      int CPUType,
      UInt32 FixedDrives,
      UInt32 DiskCSerNum,
      out string OSPlatformIdStr,
      out string CPUTypeStr,
      out string FixedDrivesStr,
      out string DiskCSerNumStr)
    {
      switch (OSPlatformId)
      {
        case 2:
          OSPlatformIdStr = "Windows NT/2000/XP/2003";
          break;
        case 0:
          OSPlatformIdStr = "Win32s �� Windows 3.1";
          break;
        case 1:
          OSPlatformIdStr = "Windows 95/98/Me";
          break;
        case 3:
          OSPlatformIdStr = "Windows CE";
          break;
        default:
          OSPlatformIdStr = "Other";
          break;
      }

      switch (CPUType)
      {
        case 386:
          CPUTypeStr = "Intel 386";
          break;
        case 486:
          CPUTypeStr = "Intel 486";
          break;
        case 586:
          CPUTypeStr = "Intel Pentium";
          break;
        case 8664:
          CPUTypeStr = "AMD X8664";
          break;
        case 4000:
          CPUTypeStr = "MIPS R4000";
          break;
        case 21064:
          CPUTypeStr = "ALPHA 21064";
          break;
        default:
          CPUTypeStr = "Other";
          break;
      }

      FixedDrivesStr = GetFixedDrivesStr(FixedDrives);
      DiskCSerNumStr = Word2Hex(HiWord(DiskCSerNum)) + "-" + Word2Hex(LoWord(DiskCSerNum));
    }

    /// <summary>
    ///   ������������ ����� (��� �����) � ����������������� ������.
    /// </summary>
    public static string Word2Hex(UInt32 D)
    {
      if (D == 0)
        return "0000";

      return Byte2Hex(Hi(D)) + Byte2Hex(Lo(D)); // ����� ���� + ������ ���� �����
    }

    /// <summary>
    ///   Returns the high-order byte of X as an unsigned value.
    /// </summary>
    public static byte Hi(UInt32 D)
    {
      var b = BitConverter.GetBytes(D);
      return b[1];
    }

    /// <summary>
    ///   Returns the low order Byte of argument X.
    /// </summary>
    public static byte Lo(UInt32 D)
    {
      var b = BitConverter.GetBytes(D);
      return b[0];
    }

    /// <summary>
    ///   ������������ ���� � ����������������� ������
    /// </summary>
    public static string Byte2Hex(byte D)
    {
      if (D == 0)
        return "00";

      var HiHex = '0';
      var LoHex = '0';

      var HiPart = (byte) (D/16);
      if (HiPart >= 0 && HiPart <= 9)
        HiHex = (char) (HiPart + 48);
      else if (HiPart >= 10 && HiPart <= 15)
        HiHex = (char) (HiPart + 55);

      var LoPart = (byte) (D%16);
      if (LoPart >= 0 && LoPart <= 9)
        LoHex = (char) (LoPart + 48);
      else if (LoPart >= 10 && LoPart <= 15)
        LoHex = (char) (LoPart + 55);

      return HiHex + LoHex.ToString();
    }

    /// <summary>
    ///   �������� ������� (�����) ����� � ������� ����� (���������� Hi)
    /// </summary>
    public static UInt16 HiWord(UInt32 D)
    {
      return (UInt16) (D >> 16);
    }

    /// <summary>
    ///   �������� ������� (������) ����� � ������� ����� (���������� Lo)
    /// </summary>
    public static UInt16 LoWord(UInt32 D)
    {
      return (UInt16) (D & 0xFFFF);
    }

    /// <summary>
    ///   ���������� ������ ������� ������
    /// </summary>
    public static string GetFixedDrivesStr(UInt32 FixedDrives)
    {
      if (FixedDrives == 0)
        return LangTranslate.UiGetText("������� ������ ���");

      // �������� ������� ������������� ������ ������� ������
      var FixedDrivesStr = DWord2Bin(FixedDrives);

      // ��������� ������ ���� ������� ������
      var FixedDrivesStrLen = FixedDrivesStr.Length;
      var DrvLetter = String.Empty;
      var strTmp = String.Empty;
      for (var i = (FixedDrivesStrLen - 1); i >= 0; i--)
        if (FixedDrivesStr[i] == '1')
        {
          DrvLetter = Chr((uint) (65 + (FixedDrivesStrLen - i - 1))).ToString();
          strTmp += DrvLetter + ": ";
        }

      return strTmp;
    }

    /// <summary>
    ///   ���������� �������� ����� �����
    /// </summary>
    public static UInt32 GetDiskSerNum(string Disk)
    {
      var volname = new StringBuilder(256);
      UInt32 sn;
      int maxcomplen;
      int sysflags;
      var sysname = new StringBuilder(256);

      var retval = Win32.GetVolumeInformation(Disk, volname, 256, out sn, out maxcomplen,
        out sysflags, sysname, 256);
      if (retval)
        return sn;
      return 0;
    }

    /// <summary>
    ///   ������������ ������� ����� � �������� ������
    /// </summary>
    public static string DWord2Bin(UInt32 D)
    {
      if (D == 0)
      {
        return "00000000000000000000000000000000";
      }

      return Dig2Bin(D);
    }

    /// <summary>
    ///   ������������ �������� ������ ������ �� 32 "��������" � ������� �����.
    ///   ���������������, ��� ��������� "���" � ������ - �������
    /// </summary>
    public static UInt32 Bin2DWord(string B)
    {
      if (!CheckBinStr(B)) // � ������ ���� �������, �������� �� 0 � 1 ��� ������ ������
        throw new Exception(B + " is not valid binary string");

      if (B.Length > 32) // ������ ������� ������
        throw new Exception(B + " is to long binary string");

      UInt32 DigWeight = 1;
      UInt32 TmpDWord = 0;

      for (var i = (B.Length - 1); i >= 0; i--)
      {
        TmpDWord += UInt32.Parse(B[i].ToString())*DigWeight;
        DigWeight *= 2;
      }

      return TmpDWord;
    }

    /// <summary>
    ///   ������������ ����� � �������� ������. ��������� "���" � ������ ����� �������
    /// </summary>
    public static string Dig2Bin(UInt32 D)
    {
      var Dividend = D;
      byte Remainder;
      var Result = String.Empty;
      do
      {
        Remainder = (byte) (Dividend%2);
        Dividend = Dividend/2;
        Result = Remainder + Result;
      } while (Dividend != 0);

      return Result;
    }

    /// <summary>
    ///   True, ���� B - ���������� �������� ������
    /// </summary>
    public static bool CheckBinStr(string B)
    {
      if (B == "")
        return false;

      for (var i = 0; i < B.Length; i++)
        if (B[i] == '0' && B[i] == '1')
          return false;

      return true;
    }

    public static char Chr(uint number)
    {
      return BitConverter.ToChar(BitConverter.GetBytes(number), 0);
    }
  }
}