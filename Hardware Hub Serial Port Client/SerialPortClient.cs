using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using Microsoft.Win32;

namespace Hardware_Hub_Serial_Port_Client
{
    public partial class SerialPortClient : Form
    {
        private DynamicsHub.Hub hub = new DynamicsHub.Hub();

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        public SerialPortClient()
        {
            InitializeComponent();
           
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxPortName.Items.Add(port);
            }

            comboBoxPortBaudRate.Items.Add("9600");
            comboBoxPortBaudRate.Items.Add("19200");
            comboBoxPortBaudRate.Items.Add("38400");
            comboBoxPortBaudRate.Items.Add("57600");
            comboBoxPortBaudRate.Items.Add("115200");
            comboBoxPortParity.DataSource = Enum.GetValues(typeof(Parity));
            comboBoxDataBits.Items.Add("7");
            comboBoxDataBits.Items.Add("8");
            comboBoxStopBits.DataSource = Enum.GetValues(typeof(StopBits));

            LoadSettings();

            HardwareHubClient_Resize(null, null);
            hub.Url = CurrentHubURL.Text;
            hub.SendCommand(CurrentSerialPortGUID.Text , "Serial Port Hub Started", Environment.GetEnvironmentVariable("COMPUTERNAME"), System.DateTime.Now.ToString(), "", "");

        }

        #region Serial Port Handler

        private void checkBoxIsOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsOpen.Checked)
            {
                OpenPort(false);
            }
            else
            {
                ClosePort(false); 
            }
        }

        private void ClosePort(bool flipcheckbox)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            if (flipcheckbox)
            {
                checkBoxIsOpen.Checked = false;
            }
                
        }

        private void OpenPort(bool flipcheckbox)
        {
            ClosePort(flipcheckbox);
            if (CurrentSerialPortGUID.Text == "")
            {
                ShowBalloonTip("Serial Port GUID Missing", "Error");
                checkBoxIsOpen.Checked = false;
            }
            else
            {
                try
                {
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxPortBaudRate.Text);
                    serialPort1.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxPortParity.Text);
                    serialPort1.PortName = comboBoxPortName.Text;
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);
                    serialPort1.Open();
                    if (flipcheckbox)
                    {
                        checkBoxIsOpen.Checked = serialPort1.IsOpen;
                    }
                    ShowBalloonTip("Port " + comboBoxPortName.Text + " is listening", "Message");
                    WriteSettings();
                }
                catch (Exception ex)
                {
                    ShowBalloonTip(ex.Message, "Error");
                    checkBoxIsOpen.Checked = false;
                }
            }

        }

        private void SetBarcodeText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.BarcodeBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetBarcodeText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.BarcodeBox.Text = text;
            }
        }

        private void SetErrorText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ErrorTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetErrorText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ErrorTextBox.Text = text;
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1.BytesToRead > 0)
                {
                    string barcode = "";
                    while (serialPort1.BytesToRead > 0)
                    {
                        barcode = barcode + serialPort1.ReadExisting();
                        System.Threading.Thread.Sleep(50);
                    }
                    hub.SendBarcode(CurrentSerialPortGUID.Text, barcode);
                    this.SetBarcodeText(barcode);
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message, "Error");
            }


        }
        #endregion

        #region Form Functions

        private void ShowBalloonTip(string ballontip, string title)
        {
            if (ballontip != ErrorTextBox.Text)
            {
                SetErrorText(ballontip);
                if (notifyIcon1.Visible == true)
                {
                    notifyIcon1.BalloonTipText = ballontip;
                    notifyIcon1.BalloonTipTitle = title;
                    notifyIcon1.ShowBalloonTip(500);
                }
            }
        }

        private void HardwareHubClient_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {                
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Hardware Hub Serial Port Client is running in the background";
                notifyIcon1.BalloonTipTitle = "Message";
                notifyIcon1.ShowBalloonTip(500);
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
            CurrentHubURL.Text = Properties.Settings.Default.HubURL;
            CurrentSerialPortGUID.Text = Properties.Settings.Default.SerialPortGUID;
            comboBoxPortName.SelectedIndex = comboBoxPortName.FindString(Properties.Settings.Default.PortName);
            comboBoxPortBaudRate.SelectedIndex = comboBoxPortBaudRate.FindString(Properties.Settings.Default.BaudRate);
            comboBoxPortParity.SelectedIndex = comboBoxPortParity.FindString(Properties.Settings.Default.Parity);
            comboBoxDataBits.SelectedIndex = comboBoxDataBits.FindString(Properties.Settings.Default.DataBits);
            comboBoxStopBits.SelectedIndex = comboBoxStopBits.FindString(Properties.Settings.Default.StopBits);
            checkBoxIsOpen.Checked = Convert.ToBoolean(Properties.Settings.Default.AutoOpenPort);
                        
            if (CurrentHubURL.Text == "")
            {
                CurrentHubURL.Text = "http://hub.dynamics.is/HardwareHub.asmx";
            }
        }
        private void WriteSettings()
        {
            Properties.Settings.Default.HubURL = CurrentHubURL.Text;
            Properties.Settings.Default.SerialPortGUID = CurrentSerialPortGUID.Text;
            Properties.Settings.Default.PortName = comboBoxPortName.Text;
            Properties.Settings.Default.BaudRate = comboBoxPortBaudRate.Text;
            Properties.Settings.Default.Parity = comboBoxPortParity.Text;
            Properties.Settings.Default.DataBits = comboBoxDataBits.Text;
            Properties.Settings.Default.StopBits = comboBoxStopBits.Text;
            Properties.Settings.Default.AutoOpenPort = checkBoxIsOpen.Checked.ToString();
            Properties.Settings.Default.Save();
        }

        private void HardwareHubClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteSettings();
        }

        #endregion        
                      
    }
}
