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

namespace Hardware_Hub_Topaz_Client
{
    public partial class TopazClient : Form
    {
        private DynamicsHub.Hub hub = new DynamicsHub.Hub();
        private Topaz.SigPlusNET sigplus = new Topaz.SigPlusNET();
        private string TempFilePath = "";
        private bool hasSignature = false;
        private string signatureUploaded = "false";


        public TopazClient()
        {           
            InitializeComponent();
            LoadSettings();
            hub.Timeout = 10000;
            HardwareHubTopazClient_Resize(null, null);
            hub.Url = CurrentHubURL.Text;
            hub.SendCommand(CurrentTopazGUID.Text, "Topaz Hub Started", Environment.GetEnvironmentVariable("COMPUTERNAME"), System.DateTime.Now.ToString(), "", "");
            TempFilePath = Environment.GetEnvironmentVariable("TEMP");
            CheckHub_Timer.Enabled = true;
            CheckHub_Timer.Start();
            HotSpotTimer.Enabled = false;           
        }

        #region Hub Listener
        private void CheckHub_Timer_Tick(object sender, EventArgs e)
        {
            CheckHub_Timer.Stop();
            if (CurrentTopazGUID.Text != "")
            {
                Topaz_Timer_Tick(sender, e);
            }
            CheckHub_Timer.Start();
        }
        #endregion

        #region Hub Response
        private void SendAnswer(string answer, string parameter1, string parameter2, string parameter3, string parameter4)
        {
            try
            {
                if (answer != "")
                {
                    hub.SendCommand(CurrentTopazGUID.Text, answer, parameter1, parameter2, parameter3, parameter4);
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message);
            }
        }
        private void SendStatus(string status)
        {
            try
            {
                if (status != "")
                {
                    hub.SendStatus(CurrentTopazGUID.Text, status);
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message);
            }
        }
        #endregion

        #region Tickers

        private void Topaz_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string answer = "";
                string parameter1 = "";
                string parameter2 = "";
                string parameter3 = "";
                string parameter4 = "";
                string lastCommand = hub.ReceiveCommand(CurrentTopazGUID.Text, ref parameter1, ref parameter2, ref parameter3, ref parameter4);
                switch (lastCommand)
                {
                    case "InitTable":
                        InitTable();
                        answer = "InitTableSuccess";
                        break;
                    case "StartTable":
                        StartTable();                        
                        answer = "StartTableSuccess";
                        break;
                    case "SetupTableSignature":
                        InitTable();
                        StartTable();
                        SetupTableSignature(parameter1, parameter2, parameter3, parameter4);
                        ClearSignature();                        
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "SetupTableSignatureSuccess";
                        HotSpotTimer.Enabled = true;
                        SendStatus(answer);
                        break;
                    case "GetSalesSignature":
                        parameter1 = GetSalesSignature(parameter1);
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "GetSalesSignatureSuccess";
                        break;
                    case "ClearSignature":
                        ClearSignature();
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "ClearSignatureSuccess";
                        break;
                    case "ClearTable":
                        HotSpotTimer.Enabled = false;
                        ClearTable();
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "ClearTableSuccess";
                        break;
                    case "CloseTable":
                        HotSpotTimer.Enabled = false;
                        CloseTable();
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "CloseTableSuccess";
                        break;
                    case "RefreshHotSpotList":
                        RefreshHotSpotList();
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "RefreshHotSpotListSuccess";                        
                        break;
                    case "CheckTableStatus":
                        parameter1 = CheckTableStatus();
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "CheckTableStatusSuccess";
                        break;
                    default:
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "";
                        break;
                }
                SendAnswer(answer, parameter1, parameter2, parameter3, parameter4);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                message = message.Substring(0, Math.Min(1024, message.Length));
                SendAnswer("Hub Error", message, "", "", "");
                ShowBalloonTip(message);
            }
        }
        #endregion

        #region Topaz Handler

        private void AboutTopaz_Click(object sender, EventArgs e)
        {
            AboutTable();
        }

        private void AboutTable()
        {
            StartTable();
            Font regularfont = new Font("Helvetica", 8, FontStyle.Regular);
            Font boldfont = new Font("Helvetica", 8, FontStyle.Bold);
            sigplus.LCDWriteString(0, 2, 4, 1, regularfont, "Hardware Hub Topaz Test");
            sigplus.LCDWriteString(0, 2, 4, 96, boldfont, "Gunnar Þór Gestsson");
            System.Threading.Thread.Sleep(5000);
            ClearTable();

        }
        private void InitTable()
        {

            sigplus.LCDSetTabletMap(0, 240, 128, 200, 250, 2000, 1300); //Sets up SigPlus for LCD 4X3 tablet
            sigplus.SetTabletXStart(500);
            sigplus.SetTabletXStop(2650);
            sigplus.SetTabletYStart(400);
            sigplus.SetTabletYStop(2100);
            sigplus.SetTabletLogicalXSize(2150);
            sigplus.SetTabletLogicalYSize(1700);
            sigplus.SetTabletFilterPoints(4);
            sigplus.SetTabletTimingAdvance(4);
            sigplus.SetTabletComPort(1);
            sigplus.SetTabletBaudRate(19200);
            sigplus.SetTabletRotation(0);
            sigplus.SetDisplayPenWidth(1);
            sigplus.SetDisplayAnnotate(false);
            sigplus.SetDisplayAnnotatePosX(0);
            sigplus.SetDisplayAnnotatePosY(0);
            sigplus.SetDisplayAnnotateSize(0);
            sigplus.SetDisplayTimeStamp(false);
            sigplus.SetDisplayTimeStampPosX(0);
            sigplus.SetDisplayTimeStampPosY(0);
            sigplus.SetDisplayTimeStampSize(0);
            sigplus.SetSigCompressionMode(2);
            sigplus.SetEncryptionMode(0);
            sigplus.SetSaveSigInfo(true);
            sigplus.SetImagePenWidth(1);
            sigplus.SetImageTimeStamp(false);
            sigplus.SetImageAnnotate(false);
            sigplus.SetImageTimeStampPosX(0);
            sigplus.SetImageTimeStampPosY(0);
            sigplus.SetImageTimeStampSize(0);
            sigplus.SetImageAnnotatePosX(0);
            sigplus.SetImageAnnotatePosY(0);
            sigplus.SetImageAnnotateSize(0);
            sigplus.SetJustifyX(0);
            sigplus.SetJustifyY(0);
            sigplus.SetJustifyMode(0);
            sigplus.ClearTablet();
        }

        private void StartTable()
        {
            sigplus.SetLCDCaptureMode(2);
            sigplus.SetTabletState(1);
        }

        private void SetupTableSignature(string properties1, string properties2, string properties3, string properties4)
        {

            sigplus.LCDRefresh(0, 0, 0, 240, 128);
            string[] properties = properties1.Split(',');
            string cardname = Convert.ToString(properties.GetValue(0));
            string transactiontype = Convert.ToString(properties.GetValue(1));
            properties = properties2.Split(',');
            string cardholdersignature = Convert.ToString(properties.GetValue(0));
            string customersignature = Convert.ToString(properties.GetValue(1));
            string xclear = Convert.ToString(properties.GetValue(2));
            string xconfirm = Convert.ToString(properties.GetValue(3));
            Font regularfont = new Font("Helvetica", 8, FontStyle.Regular);
            Font boldfont = new Font("Helvetica", 8, FontStyle.Bold);

            if (cardname != "")
            {
                sigplus.LCDWriteString(0, 2, 4, 1, regularfont, cardname);
                sigplus.LCDWriteString(0, 2, Convert.ToInt16(240 - transactiontype.Length * 8), 10, regularfont, transactiontype);
                sigplus.LCDWriteString(0, 2, 4, 96, boldfont, cardholdersignature);
            }
            else
            {
                sigplus.LCDWriteString(0, 2, 4, 1, regularfont, properties3);
                sigplus.LCDWriteString(0, 2, 4, 96, boldfont, customersignature);
            }

            sigplus.LCDWriteString(0, 2, 4, 15, regularfont, properties4);
            sigplus.LCDWriteString(0, 2, 4, 80, boldfont, "_________________________________");
            sigplus.LCDWriteString(0, 2, 100, 110, regularfont, xclear);
            sigplus.LCDWriteString(0, 2, 4, 110, regularfont, xconfirm);

            sigplus.SetSigWindow(1, 4, 30, 232, 60);
            sigplus.LCDSetWindow(4, 30, 232, 60);

            sigplus.KeyPadClearHotSpotList();
            sigplus.KeyPadAddHotSpot(3, 1, 4, 30, 232, 60);
            sigplus.KeyPadAddHotSpot(2, 1, 100, 100, 10, 28);
            signatureUploaded = "false";
        }

        private string GetSalesSignature(string properties1)
        {
            string ImageFileName = TempFilePath + "\\" + properties1;
            sigplus.SetTabletState(0);
            sigplus.SetImageFileFormat(0);
            sigplus.SetTranslateBitmapEnable(true);
            sigplus.SetImageXSize(600);
            sigplus.SetImageYSize(300);
            Image signature = sigplus.GetSigImage();
            if (File.Exists(ImageFileName))
            {
                File.Delete(ImageFileName);
            }
            signature.Save(ImageFileName, System.Drawing.Imaging.ImageFormat.Bmp);
            hub.SendImage(CurrentTopazGUID.Text, File.ReadAllBytes(ImageFileName));
            File.Delete(ImageFileName);
            return "true";
        }

        private void ClearSignature()
        {
            sigplus.SetTabletState(0);
            sigplus.ClearTablet();
            sigplus.SetTabletState(1);
            sigplus.LCDRefresh(0, 4, 30, 232, 60);
            sigplus.KeyPadClearHotSpotList();
            sigplus.KeyPadAddHotSpot(3, 1, 4, 30, 232, 60);
            sigplus.KeyPadAddHotSpot(2, 1, 10, 100, 10, 28);
            hasSignature = false;
        }

        private void ClearTable()
        {
            sigplus.SetTabletState(1);
            sigplus.LCDRefresh(0, 0, 0, 240, 128);
            sigplus.SetLCDCaptureMode(1);
            sigplus.SetTabletState(0);
        }

        private void CloseTable()
        {
            sigplus.SetTabletState(1);
            sigplus.LCDRefresh(0, 0, 0, 240, 128);
            sigplus.SetLCDCaptureMode(1);
            sigplus.SetTabletState(0);
        }

        private void RefreshHotSpotList()
        {
            sigplus.KeyPadClearHotSpotList();
            sigplus.KeyPadAddHotSpot(0, 1, 1, 100, 10, 28);
            sigplus.KeyPadAddHotSpot(2, 1, 100, 100, 10, 28);
        }

        private void HotSpotTimer_Tick(object sender, EventArgs e)
        {
            HotSpotTimer.Stop();
            if (sigplus.KeyPadQueryHotSpot(0) > 0)
            {                
                if (hasSignature == true & signatureUploaded == "false")
                {
                    Console.Beep();
                    Guid guid = Guid.NewGuid();
                    signatureUploaded = GetSalesSignature(guid.ToString());
                    HotSpotTimer.Stop();
                }
                SendStatus("HotSpotUpdate,1," + signatureUploaded);
            }
            else if (sigplus.KeyPadQueryHotSpot(1) > 0)
            {
                Console.Beep();
                SendStatus("HotSpotUpdate,2,");
                ClearTable();
            }
            else if (sigplus.KeyPadQueryHotSpot(2) > 0)
            {
                Console.Beep();
                SendStatus("HotSpotUpdate,3,");
                ClearSignature();
            }
            else if (sigplus.KeyPadQueryHotSpot(3) > 0)
            {
                SendStatus("HotSpotUpdate,4,");
                if (hasSignature == false)
                {
                    RefreshHotSpotList();
                    hasSignature = true;
                }
            }
            HotSpotTimer.Start();
        }
        
        private string CheckTableStatus()
        {
            if (sigplus.KeyPadQueryHotSpot(0) > 0)
            {
                return "1";
            }
            else if (sigplus.KeyPadQueryHotSpot(1) > 0)
            {
                return "2";
            }
            else if (sigplus.KeyPadQueryHotSpot(2) > 0)
            {
                return "3";
            }
            else if (sigplus.KeyPadQueryHotSpot(3) > 0)
            {
                return "4";
            }
            else
            {
                return "0";
            }
        }

        #endregion

        #region Form Functions
        
        private void ShowBalloonTip(string ballontip)
        {
            if (ballontip != ErrorTextBox.Text)
            {
                ErrorTextBox.Text = ballontip;
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.BalloonTipText = ballontip;
                    notifyIcon1.BalloonTipTitle = "Error";
                    notifyIcon1.ShowBalloonTip(500);
                }
            }
        }

        private void HardwareHubTopazClient_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Hardware Hub Topaz Client is running in the background";
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

        private void AboutHub_Click(object sender, EventArgs e)
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
            CurrentHubURL.Text = Properties.Settings.Default.HubURL;
            CurrentTopazGUID.Text = Properties.Settings.Default.TopazGUID;
            if (CurrentHubURL.Text == "")
            {
                CurrentHubURL.Text = "http://hub.dynamics.is/HardwareHub.asmx";
            }
        }
        private void WriteSettings()
        {
            Properties.Settings.Default.HubURL = CurrentHubURL.Text;
            Properties.Settings.Default.TopazGUID = CurrentTopazGUID.Text;
            Properties.Settings.Default.Save();
        }

        private void HardwareHubClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteSettings();
        }

        #endregion        

       
    }
}
