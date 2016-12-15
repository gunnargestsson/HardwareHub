using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardwareHubTwainClient
{
    public static class Window_Management
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        public const int SW_SHOWMAXIMIZED = 3;
    }
}
