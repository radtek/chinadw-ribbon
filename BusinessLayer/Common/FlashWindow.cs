using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ARM_User.BusinessLayer.Common
{
    public static class FlashWindow
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
            public IntPtr hwnd;
            /// The Flash Status.
            public uint dwFlags;
            /// The number of times to Flash the window.
            public uint uCount;
            /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
            public uint dwTimeout;
        }

        /// Stop flashing. The system restores the window to its original stae.
        public const uint FLASHW_STOP = 0;
        /// Flash the window caption.
        public const uint FLASHW_CAPTION = 1;
        /// Flash the taskbar button.
        public const uint FLASHW_TRAY = 2;
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        public const uint FLASHW_ALL = 3;
        /// Flash continuously, until the FLASHW_STOP flag is set.
        public const uint FLASHW_TIMER = 4;
        /// Flash continuously until the window comes to the foreground.
        public const uint FLASHW_TIMERNOFG = 12;
        /// Flash the spacified Window (Form) until it recieves focus.
        /// <param name="form">The Form (Window) to Flash.</param>
        public static bool Flash(System.Windows.Forms.Form form)
        {
            // Make sure we're running under Windows 2000 or later
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        /// Flash the specified Window (form) for the specified number of times
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <param name="count">The number of times to Flash.</param>
        public static bool Flash(System.Windows.Forms.Form form, uint count)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// Start Flashing the specified Window (form)
        /// <param name="form">The Form (Window) to Flash.</param>        
        public static bool Start(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// Stop Flashing the specified Window (form)
        /// <param name="form"></param>
        public static bool Stop(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// A boolean value indicating whether the application is running on Windows 2000 or later.
        private static bool Win2000OrLater
        {
            get { return System.Environment.OSVersion.Version.Major >= 5; }
        }
    }
}
