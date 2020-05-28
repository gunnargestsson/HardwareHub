using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Timers;

namespace HardwareHubTwainClient
{
    public partial class HardwareHubTwainClient : Form
    {
        private DynamicsHub.Hub hub = new DynamicsHub.Hub();
        private TwainControlX.Twain twain = new TwainControlX.Twain();
        private System.Timers.Timer PopUpTimer = new System.Timers.Timer();
        private string TempFilePath = "";
        private string devicelist = "";
        private string lasterrortext = "";
        private string HubUrlKey = "Hub Url";
        private string HubScannerGuidKey = "Scanner Guid";
        private string ProcessNameKey = "Setting Dialog Process Name";
        private bool lastWindowFound = false;
        private bool writedebug = false;

        public HardwareHubTwainClient()
        {
            InitializeComponent();
            LoadSettings();
            HardwareHubTwainClient_Resize(null, null);
            TempFilePath = Environment.GetEnvironmentVariable("TEMP");
            GetTwainDeviceList();            
            Connect2HardwareHub();
            CheckHub_Timer.Enabled = true;
            CheckHub_Timer.Start();
            PopUpTimer.Enabled = false;
            PopUpTimer.Elapsed += new ElapsedEventHandler(HandleTimer);
            PopUpTimer.Interval = 1000;            
        }

        #region Hub Listener
        private void CheckHub_Timer_Tick(object sender, EventArgs e)
        {
            CheckHub_Timer.Stop();
            if (CurrentScannerGUID.Text != "")
            {
                Twain_Timer_Tick(sender, e);
            }
            CheckHub_Timer.Start();
        }
        #endregion

        #region Hub Response
        private void SendAnswer(string currentguid, string command, string answer, string parameter1, string parameter2, string parameter3, string parameter4)
        {
            try
            {
                if (answer != "")
                {
                    LogCommand(command);
                    LogAnswer(answer);
                    hub.SendCommand(currentguid, answer, parameter1, parameter2, parameter3, parameter4);
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message, true);
            }
        }
        #endregion

        #region Tickers
        private void Twain_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string answer = "";
                string parameter1 = "";
                string parameter2 = "";
                string parameter3 = "";
                string parameter4 = "";
                string lastCommand = hub.ReceiveCommand(CurrentScannerGUID.Text, ref parameter1, ref parameter2, ref parameter3, ref parameter4);
                switch (lastCommand)
                {
                    case "AboutBox":
                        TwainAboutBox();
                        answer = "AboutBoxSuccess";                        
                        break;
                    case "Ping":
                        answer = "PingSuccess";                        
                        break;
                    case "Connected":
                        parameter1 = TwainIsConnected();
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "ConnectedSuccess";
                        break;
                    case "Unload":
                        TwainUnload();
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "UnloadSuccess";
                        break;
                    case "get_DeviceList":
                        parameter1 = devicelist.Substring(0, Math.Min(1024, devicelist.Length));
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "set_DeviceList";
                        break;
                    case "SelectDeviceByName":
                        parameter1 = TwainSelectDeviceByName(parameter1);
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "SelectDeviceByNameSuccess";
                        break;
                    case "SelectDeviceByIndex":
                        int deviceIndex = int.Parse(parameter1);
                        parameter1 = TwainSelectDeviceByIndex(deviceIndex);
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "SelectDeviceByIndexSuccess";
                        break;
                    case "get_Properties":
                        TwainGetProperties(ref parameter1, ref parameter2, ref parameter3, ref parameter4);
                        answer = "got_Properties";
                        break;
                    case "Acquire":
                        SendAnswer(CurrentScannerGUID.Text, "Aquire", "WaitingForAcquire", "", "", "", "");
                        parameter1 = TwainAcquire(parameter1, parameter2, parameter3, parameter4);
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "AcquireSuccess";
                        break;
                    case "UploadImage":
                        parameter1 = UploadImageFile(parameter1);
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "UploadImageSuccess";
                        break;
                    default:
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "";
                        break;
                }
                SendAnswer(CurrentScannerGUID.Text, lastCommand, answer, parameter1, parameter2, parameter3, parameter4);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                message = message.Substring(0, Math.Min(1024, message.Length));
                SendAnswer(CurrentScannerGUID.Text, "", "Hub Error", message, "", "", "");
                ShowBalloonTip(message, true);
            }
        }
    
        #endregion

        #region Twain Handler

        private void button1_Click(object sender, EventArgs e)
        {
            TwainAboutBox();
        }

        private void TwainAboutBox()
        {
            try
            {
                twain.AboutBox();
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message, true);
            }
        }

        private string TwainIsConnected()
        {
            return twain.Connected.ToString();
        }

        private void TwainUnload()
        {
            twain.Unload();
        }

        private string TwainDeviceList()
        {
            string devlist = "";
            for (int i = 1; i <= twain.DeviceCount; i++)
            {
                if (i == 1)
                {
                    devlist = twain.get_DeviceName(i - 1);
                }
                else
                {
                    devlist = devlist + ',' + twain.get_DeviceName(i - 1);
                }
            }
            return devlist;
        }

        private string TwainSelectDeviceByName(string DeviceName)
        {
            for (int i = 1; i <= twain.DeviceCount; i++)
                if (DeviceName == twain.get_DeviceName(i - 1))
                {
                    twain.CurrentDevice = i - 1;
                    return "true";
                }
            return "false";
        }
        private string TwainSelectDeviceByIndex(int DeviceIndex)
        {
            twain.CurrentDevice = DeviceIndex;
            return twain.DeviceName[DeviceIndex];
        }
        private void TwainSelectDevice()
        {
            twain.SelectDevice();
        }


        private void TwainGetProperties(ref string properties1, ref string properties2, ref string properties3, ref string properties4)
        {
            properties1 = twain.HasADF.ToString();
            properties2 = twain.DuplexSupported.ToString() + "," + twain.DuplexEnabled.ToString();
            properties3 = twain.CanDisableInterface.ToString();
            properties4 = "";
        }

        private string TwainAcquire(string properties1, string properties2, string properties3, string properties4)
        {
            string[] properties = properties1.Split(',');
            twain.UseADF = Convert.ToBoolean(properties.GetValue(0));
            twain.MultiImage = Convert.ToBoolean(properties.GetValue(1));
            twain.KeepImages = Convert.ToBoolean(properties.GetValue(2));
            twain.ShowProgress = Convert.ToBoolean(properties.GetValue(3));
            twain.WaitForAcquire = Convert.ToBoolean(properties.GetValue(4));
            twain.DuplexEnabled = Convert.ToBoolean(properties.GetValue(5));
            twain.UseInterface = Convert.ToBoolean(properties.GetValue(6));
            twain.AppName = properties2;
            PopUpTimer.Enabled = (twain.UseInterface && ProcessName.Text != "");

            if (properties3 == "PDF")
            {
                twain.ClearPDF();
                twain.Acquire();
                twain.SaveMultiPagePDF(TempFilePath + "\\" + properties4);
            }
            if (properties3 == "TIF")
            {
                twain.ClearTIF();
                twain.Acquire();
                twain.SaveMultiPageTIF(TempFilePath + "\\" + properties4);
            }

            if (properties3 == "BMP")
            {
                twain.FileFormat = TwainControlX.TxFileFormat.ffBMP;
                twain.AcquireToFile(TempFilePath + "\\" + properties4);
            }
            if (properties3 == "JPG")
            {
                twain.FileFormat = TwainControlX.TxFileFormat.ffJPEG;
                twain.AcquireToFile(TempFilePath + "\\" + properties4);
            }
            PopUpTimer.Enabled = false;
            lastWindowFound = false;
            return TempFilePath + "\\" + properties4;
        }
     
        private string UploadImageFile(string ImageFileName)
        {
            if (File.Exists(ImageFileName))
            {
                hub.SendImage(CurrentScannerGUID.Text, File.ReadAllBytes(ImageFileName));
                File.Delete(ImageFileName);
                return "true";
            }
            else
            {
                return "false";
            }
        }

        #endregion

        #region Form Functions

        private void ShowBalloonTip(string ballontip, bool isError)
        {
            if (ballontip != lasterrortext)
            {
                AddToMessageText(ballontip, isError, false);
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.BalloonTipText = ballontip;
                    notifyIcon1.BalloonTipTitle = "Error";
                    notifyIcon1.ShowBalloonTip(500);
                }
                lasterrortext = ballontip;
            }
        }
        private void AddToMessageText(string NewErrorText, bool isError, bool threadSafe)
        {
            try
            {
                if (isError)
                    NewErrorText = "Error: " + NewErrorText;
                if (MessageTextBox.Text != "")
                    NewErrorText = NewErrorText + "\r\n" + MessageTextBox.Text;
                if (threadSafe)
                    MessageTextBox.Invoke(new UpdateMessageTextBoxCallback(this.UpdateMessageTextBox), new object[] { NewErrorText });
                else
                    MessageTextBox.Text = NewErrorText;
            }
            catch (Exception ex) { }
        }
        private void UpdateMessageTextBox(string NewMessage)
        {
            MessageTextBox.Text = NewMessage;
        }
        public delegate void UpdateMessageTextBoxCallback(string NewMessage);
        private void LogCommand(string Command)
        {
            LogAction("Got Command: " + Command);
        }
        private void LogAnswer(string Command)
        {
            LogAction("Sending Answer: " + Command);
        }
        private void LogAction(string LogText)
        {
            if (LogCheckBox.Checked)
                AddToMessageText(LogText,false,true);
            if (writedebug)
                LogDebug(LogText);
        }
        private void LogDebug(string DebugText)
        {
            try
            {
                System.IO.File.AppendAllText(@"c:\temp\process.log", DebugText + "\r\n");
            }
            catch (Exception ex) {}
        }
        private void Connect2HardwareHub()
        {
            try
            {
                if (CurrentHubURL.Text != "")
                {
                    hub.Url = CurrentHubURL.Text;
                    hub.SendCommand(CurrentScannerGUID.Text, "Twain Hub Started", Environment.GetEnvironmentVariable("COMPUTERNAME"), System.DateTime.Now.ToString(), "", "");
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip("Sending Hub Started: " + ex.Message, true);
            }

        }
        private void GetTwainDeviceList()
        {
            try
            {
                twain.Password = "ZRSUVCNFXK";
                devicelist = TwainDeviceList();
            }
            catch (Exception ex)
            {
                ShowBalloonTip("Opening Device List: " + ex.Message, true);
            }
        }

        private void HardwareHubTwainClient_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Hardware Hub Twain Client is running in the background";
                notifyIcon1.BalloonTipTitle = "Message";
                notifyIcon1.ShowBalloonTip(500);
                WriteSettings();
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
                this.Show();
            }
        }
        
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenWebsite("http://www.dynamics.is/?p=1275");
        }

        public static void OpenWebsite(string url)
        {
            Process.Start(GetDefaultBrowserPath(), url);
        }

        private static string GetDefaultBrowserPath()
        {
            string key = @"http\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }

        #endregion

        #region Application Setting
        private void LoadSettings()
        {
            try
            {
                CurrentHubURL.Text = Application.UserAppDataRegistry.GetValue(HubUrlKey).ToString();
                CurrentScannerGUID.Text = Application.UserAppDataRegistry.GetValue(HubScannerGuidKey).ToString();                
                AddToMessageText("Registry: " + CurrentHubURL.Text + ", " + CurrentScannerGUID.Text, false, false);
                if (CurrentHubURL.Text == "")
                {
                    CurrentHubURL.Text = Properties.Settings.Default.HubURL;
                    CurrentScannerGUID.Text = Properties.Settings.Default.ScannerGUID;
                    AddToMessageText("Settings: " + CurrentHubURL.Text + ", " + CurrentScannerGUID.Text, false, false);
                }
                if (CurrentHubURL.Text == "")
                {
                    CurrentHubURL.Text = "http://hub.dynamics.is/HardwareHub.asmx";
                }
                if (CurrentScannerGUID.Text == "")
                {
                    CurrentScannerGUID.Text = Guid.NewGuid().ToString();
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip("Load Settings: " + ex.Message, true);
            }
            try
            {
                ProcessName.Text = Application.UserAppDataRegistry.GetValue(ProcessNameKey).ToString();
                AddToMessageText("PopUp Process Name: " + ProcessName.Text, false, false);
            }
            catch (Exception ex)
            {
                ShowBalloonTip("PopUp Process Name not defined", false);
            }
        }
        private void WriteSettings()
        {
            try
            {
                Application.UserAppDataRegistry.SetValue(HubUrlKey, CurrentHubURL.Text);
                Application.UserAppDataRegistry.SetValue(HubScannerGuidKey, CurrentScannerGUID.Text);
                Application.UserAppDataRegistry.SetValue(ProcessNameKey, ProcessName.Text);                
            }
            catch (Exception ex)
            {
                ShowBalloonTip("Save Settings: " + ex.Message, true);
            }
            Connect2HardwareHub();
        }
        private void HardwareHubClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteSettings();
        }

        #endregion           

        #region PopUp2Front
        private void button3_Click(object sender, EventArgs e)
        {
            Select_Process popUpList = new Select_Process();
            popUpList.ShowDialog();
            if (popUpList.ProcessSelected())
                ProcessName.Text = popUpList.GetSelectedWindowTitle();                
        }


        private void HandleTimer(object source, ElapsedEventArgs e)
        {            
            IntPtr WindowHandle = new IntPtr();
            string procName = "";
            bool localWindowFound = false;
            LogAction("Searching for process: " + ProcessName.Text);
            
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                procName = "(" + process.ProcessName + ")" + process.MainWindowTitle;                
                if (procName == ProcessName.Text)
                {
                    WindowHandle = process.Handle;
                    localWindowFound = true;
                    break;
                }
            }

            if (localWindowFound)
                LogAction("Result: window found");
            else
                LogAction("Result: Window not found");
            if (localWindowFound && lastWindowFound)
                return;
            lastWindowFound = localWindowFound;
            if (!localWindowFound)
                return;
            LogAction("Action: Bringing Pop Up Process to front");
            Window_Management.SetForegroundWindow(WindowHandle);
        }

        #endregion

    }
}
