using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hardware_Hub_Topaz_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!EnsureSingleInstance())
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TopazClient());
        }

        static bool EnsureSingleInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();

            var runningProcess = (from process in Process.GetProcesses()
                                  where
                                    process.Id != currentProcess.Id &&
                                    process.ProcessName.Equals(
                                      currentProcess.ProcessName,
                                      StringComparison.Ordinal)
                                  select process).FirstOrDefault();

            if (runningProcess != null)
            {
                ShowWindow(runningProcess.MainWindowHandle, SW_SHOWMAXIMIZED);
                SetForegroundWindow(runningProcess.MainWindowHandle);

                return false;
            }

            return true;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        private const int SW_SHOWMAXIMIZED = 3;

    }
}
