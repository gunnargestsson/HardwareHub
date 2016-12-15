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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml;
using System.Threading;

namespace Hardware_Hub_Serial_Port_Scale_Client
{
    public partial class SerialPortScaleClient : Form
    {
        private DynamicsHub.Hub hub = new DynamicsHub.Hub();
        private enum ScaleProtocol { TScale, TScaleAsk, Mettler};
        
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void SetWeightCallback(double weight, string uom);

        public SerialPortScaleClient()
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
            comboBoxProtocol.DataSource = Enum.GetValues(typeof(ScaleProtocol));

            LoadSettings();

            HardwareHubClient_Resize(null, null);
            hub.Url = CurrentHubURL.Text;
            hub.SendCommand(CurrentSerialPortGUID.Text , "Serial Port Scale Hub Started", Environment.GetEnvironmentVariable("COMPUTERNAME"), System.DateTime.Now.ToString(), "", "");
            CheckHub_Timer.Enabled = true;

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

        private void SetDataText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.DataBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetDataText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.DataBox.Text = text;
            }
        }
        private void SetData(double weight, string uom)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBoxWeight.InvokeRequired)
            {
                SetWeightCallback d = new SetWeightCallback(SetData);
                this.Invoke(d, new object[] { weight, uom });
            }
            else
            {
                this.textBoxWeight.Text = weight.ToString();
                this.textBoxUoM.Text = uom;
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
                    //hub.SendBarcode(CurrentSerialPortGUID.Text, barcode);
                    this.SetDataText(barcode);
                }
            }
            catch (Exception ex)
            {
                ShowBalloonTip(ex.Message, "Error");
            }


        }
        #endregion
        #region Hub Listener
        private void CheckHub_Timer_Tick(object sender, EventArgs e)
        {
            CheckHub_Timer.Stop();
            try
            {
                if (CurrentSerialPortGUID.Text != "")
                {
                    Printer_Timer_Tick(sender, e);
                }
            }
            finally
            {
                CheckHub_Timer.Interval = 100;
                CheckHub_Timer.Start();
            }
        }
        #endregion

        #region Tickers
        private void Printer_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string answer = "";
                string parameter1 = "";
                string parameter2 = "";
                string parameter3 = "";
                string parameter4 = "";
                string lastCommand = hub.ReceiveCommand(CurrentSerialPortGUID.Text, ref parameter1, ref parameter2, ref parameter3, ref parameter4);
                switch (lastCommand)
                {
                    case "Ping":
                        answer = "PingSuccess";
                        break;
                    case "GetWeight":
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "Weight";
                        GetWeight(ref parameter1,ref parameter2);
                        break;
                    case "Tare":
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "TareDone";
                        Tara();
                        break;

                    default:
                        parameter1 = "";
                        parameter2 = "";
                        parameter3 = "";
                        parameter4 = "";
                        answer = "";
                        return;
                }
                SendAnswer(CurrentSerialPortGUID.Text, lastCommand, answer, parameter1, parameter2, parameter3, parameter4);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                message = message.Substring(0, Math.Min(1024, message.Length));
                SendAnswer(CurrentSerialPortGUID.Text, "", "Hub Error", message, "", "", "");
                ShowBalloonTip(message,"Error");
            }
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
                ShowBalloonTip(ex.Message,"Error");
            }
        }
        #endregion


        #region Form Functions
        private void AddToErrorText(string NewErrorText)
        {
            if (ErrorTextBox.Text == "")
            {
                SetText(NewErrorText);
            }
            else
            {
                SetText(ErrorTextBox.Text + "\r\n" + NewErrorText);
            }
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ErrorTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ErrorTextBox.Text = text;
            }
        }
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
            AddToErrorText(LogText);
        }

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
                notifyIcon1.BalloonTipText = "Hardware Hub Serial Port Scale Client is running in the background";
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

        private void GetWeight(ref string param1, ref string param2)
        {
            if (this.checkBoxTestData.Checked)
            {
                param1 = textBoxWeight.Text;
                param2 = textBoxUoM.Text;
                return;
            }
            var protocol = (ScaleProtocol)Enum.Parse(typeof(ScaleProtocol),comboBoxProtocol.Text);
            double weight = 0;
            string uom = "";
            switch (protocol)
            {
                case ScaleProtocol.Mettler: GetWeightMettler(ref weight, ref uom); break;
                case ScaleProtocol.TScale: GetWeightTScale(ref weight, ref uom); break;
                case ScaleProtocol.TScaleAsk: GetWeightTScaleAsk(ref weight, ref uom); break;
            }
            //SendWeight(weight, uom);
            param1 = weight.ToString();
            param2 = uom;
        }

        private void SendWeight(double weight, string uom)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode rootNode = doc.CreateElement("scale");
            doc.AppendChild(rootNode);

            XmlNode valueNode = doc.CreateElement("value");
            XmlAttribute weightAttribute = doc.CreateAttribute("weight");
            weightAttribute.Value = weight.ToString();
            XmlAttribute uomAttribute = doc.CreateAttribute("UoM");
            uomAttribute.Value = uom;
            valueNode.Attributes.Append(weightAttribute);
            valueNode.Attributes.Append(uomAttribute);
            rootNode.AppendChild(valueNode);
            if (!hub.SendXml(CurrentSerialPortGUID.Text, doc))
                throw new Exception("Failed to upload XML");
        }

        private void GetWeightTScaleAsk(ref double weight, ref string uom)
        {
            ReadAllExistingFromSerialPort();
            SendDataToSerialPort("R\r\n");
            Thread.Sleep(1000);
            var data=ReadDataFromSerialPort();
            if (data=="")
            {
                throw new Exception("No data returned");
            }

            data = data.Substring(6);
            var gross = Regex.Replace(data,@"[^0123456789-,.]","");
            weight = double.Parse(gross);
            uom = Regex.Replace(data.Substring(7, 3), @"[^ABCDEFGHIJKLMNOPQRSTUVWXYZ]", "");
        }

        private string ReadDataFromSerialPort()
        {
            string data = "";
            if (serialPort1.BytesToRead > 0)
            {
                while (serialPort1.BytesToRead > 0)
                {
                    data = data + serialPort1.ReadExisting();
                    System.Threading.Thread.Sleep(50);
                }
            }
            return data;
        }

        private void SendDataToSerialPort(string data)
        {
            serialPort1.Write(data);
        }

        private void ReadAllExistingFromSerialPort()
        {
            if (serialPort1.BytesToRead > 0)
            {
                string data = "";
                while (serialPort1.BytesToRead > 0)
                {
                    data = data + serialPort1.ReadExisting();
                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        private void GetWeightTScale(ref double weight, ref string uom)
        {
            var data = ReadDataFromSerialPort();
            int loop = 0;
            int maxLoop = 50;
            while ((data.IndexOf("ST,",0)!=0) && (loop<maxLoop))
            {
                data = ReadDataFromSerialPort();
                loop++;
            }
            if (loop==maxLoop)
            {
                throw new TimeoutException("Scale does not return answer beginning with 'ST,'. Last Data='" + data + "'");
            }

            data = data.Substring(6);
            var gross = Regex.Replace(data, @"[^0123456789-,.]", "");
            weight = double.Parse(Regex.Replace(gross,@"[,.]", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            uom = Regex.Replace(data.Substring(7, 3), @"[^ABCDEFGHIJKLMNOPQRSTUVWXYZ]", "");
        }

        private void GetWeightMettler(ref double weight, ref string uom)
        {
            ReadAllExistingFromSerialPort();
            SendDataToSerialPort("S\r\n");
            var data = ReadDataFromSerialPort();
            if (data == "")
            {
                throw new Exception("No data returned");
            }

            if (data[0]!='S')
            {
                throw new ArgumentException("Unknown answer from scale '" + data + "'! Expected something beginning with 'S'.");
            }

            switch (data[2])
            {
                case 'S':break;
                case 'I':throw new ArgumentException("Scale is not stable!");
                case '+':throw new ArgumentOutOfRangeException("Scale is out of range!");
                case '-':throw new ArgumentOutOfRangeException("Scale is out of range!");
            }
            //data = data.Substring(6);
            var gross = Regex.Replace(data.Substring(4,10), @"[^0123456789-,.]", "");
            weight = double.Parse(gross);
            uom = Regex.Replace(data.Substring(15, 2), @"[^ABCDEFGHIJKLMNOPQRSTUVWXYZ]", "");
        }

        private void Tara()
        {
            try
            {
                var protocol = (ScaleProtocol)Enum.Parse(typeof(ScaleProtocol), comboBoxProtocol.Text);

                switch (protocol)
                {
                    case ScaleProtocol.Mettler: TaraMettler(); break;
                    case ScaleProtocol.TScale: TaraTScale(); break;
                    case ScaleProtocol.TScaleAsk: TaraTScaleAsk(); break;
                }
            }
            catch (Exception ex)
            {
                AddToErrorText(ex.Message);
            }

        }

        private void TaraTScale()
        {
            serialPort1.Write("T\r\n");
        }

        private void TaraTScaleAsk()
        {
            serialPort1.Write("T\r\n");
        }

        private void TaraMettler()
        {
            serialPort1.Write("T\r\n");
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
