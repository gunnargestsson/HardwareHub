using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace HardwareHubTwainClient
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
            Application.Run(new HardwareHubTwainClient());
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
                Window_Management.ShowWindow(runningProcess.MainWindowHandle, Window_Management.SW_SHOWMAXIMIZED);
                Window_Management.SetForegroundWindow(runningProcess.MainWindowHandle);

                return false;
            }

            return true;
        }
    }
}
