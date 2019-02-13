// Win32API: wrapper for selected Win32 API functions
// To compile:
//    csc /t:library /out:Win32API.dll Win32API.cs
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

//////////////////
// namespace to wrap Win32 API functions. Add them here as you need...
//

namespace BSB.Win32API
{
  [StructLayout(LayoutKind.Sequential)]
  public struct POINT
  {
    public POINT(int xx, int yy)
    {
      x = xx;
      y = yy;
    }

    public int x;
    public int y;

    public override string ToString()
    {
      var s = String.Format("({0},{1})", x, y);
      return s;
    }
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct SIZE
  {
    public SIZE(int cxx, int cyy)
    {
      cx = cxx;
      cy = cyy;
    }

    public int cx;
    public int cy;

    public override string ToString()
    {
      var s = String.Format("({0},{1})", cx, cy);
      return s;
    }
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;

    public int Width()
    {
      return right - left;
    }

    public int Height()
    {
      return bottom - top;
    }

    public POINT TopLeft()
    {
      return new POINT(left, top);
    }

    public SIZE Size()
    {
      return new SIZE(Width(), Height());
    }

    public override string ToString()
    {
      var s = String.Format("{0}x{1}", TopLeft(), Size());
      return s;
    }
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct SYSTEM_INFO
  {
    public UInt32 dwOemId;
    public UInt32 dwPageSize;
    public IntPtr lpMinimumApplicationAddress;
    public IntPtr lpMaximumApplicationAddress;
    public UInt32 dwActiveProcessorMask;
    public UInt32 dwNumberOfProcessors;
    public UInt32 dwProcessorType;
    public UInt32 dwAllocationGranularity;
    public UInt16 dwProcessorLevel;
    public UInt16 dwProcessorRevision;
  }

  /// <summary>
  ///   ShowWindow() Commands
  /// </summary>
  public enum CmdShow
  {
    SW_HIDE = 0,
    SW_MAXIMIZE = 3,
    SW_MINIMIZE = 6,
    SW_RESTORE = 9,
    SW_SHOW = 5,
    SW_SHOWDEFAULT = 10,
    SW_SHOWMAXIMIZED = 3,
    SW_SHOWMINIMIZED = 2,
    SW_SHOWMINNOACTIVE = 7,
    SW_SHOWNOACTIVATE = 4,
    SW_SHOWNORMAL = 1
  }

  /// <summary>
  ///   Windows Messages
  /// </summary>
  public enum WinMessage
  {
    WM_ACTIVATEAPP = 28,
    WM_SHOWWINDOW = 24,
    WM_QUERYOPEN = 19,
    WM_MOUSEMOVE = 0x0200,
    WM_KEYDOWN = 0x0100,
    WM_NCMOUSEMOVE = 0x00A0,
    WM_SYSKEYDOWN = 0x0104,
    WM_USER = 0x0400
  }

  public class Win32
  {
    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern int GetWindowText(IntPtr hwnd,
      StringBuilder buf, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern int GetClassName(IntPtr hwnd,
      [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf,
      int nMaxCount);

    [DllImport("user32.dll")]
    public static extern int GetWindowRect(IntPtr hwnd, ref RECT rc);

    [DllImport("user32.dll")]
    public static extern bool GetClientRect(IntPtr hwnd, ref RECT rc);

    [DllImport("user32.dll")]
    // note the runtime knows how to marshal a Rectangle
    public static extern int GetWindowRect(IntPtr hwnd, ref Rectangle rc);

    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hWnd, int wMsg,
      int wParam, ref int lParam);

    [DllImport("user32.dll")]
    public static extern bool PostMessage(IntPtr hWnd, Int32 wMsg,
      IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, CmdShow nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("kernel32")]
    public static extern void GetSystemInfo(ref SYSTEM_INFO pSI);

    [DllImport("kernel32")]
    public static extern UInt32 GetLogicalDrives();

    [DllImport("kernel32")]
    public static extern bool GetVolumeInformation(string strPathName,
      StringBuilder strVolumeNameBuffer,
      int lngVolumeNameSize,
      out UInt32 lngVolumeSerialNumber,
      out int lngMaximumComponentLength,
      out int lngFileSystemFlags,
      StringBuilder strFileSystemNameBuffer,
      int lngFileSystemNameSize);

    [DllImport("kernel32")]
    public static extern uint GetDriveType(string lpRootPathName);

    [DllImport("user32.dll")]
    public static extern bool MoveWindow(IntPtr hWnd, Int32 X, Int32 Y,
      Int32 nWidth, Int32 nHeight, bool bRepaint);
  }
}