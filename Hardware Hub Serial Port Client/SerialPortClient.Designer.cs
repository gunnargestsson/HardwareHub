namespace Hardware_Hub_Serial_Port_Client
{
    partial class SerialPortClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialPortClient));
            this.comboBoxPortParity = new System.Windows.Forms.ComboBox();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.comboBoxPortBaudRate = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentSerialPortGUID = new System.Windows.Forms.TextBox();
            this.CurrentHubURL = new System.Windows.Forms.TextBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.checkBoxIsOpen = new System.Windows.Forms.CheckBox();
            this.BarcodeBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxPortParity
            // 
            this.comboBoxPortParity.FormattingEnabled = true;
            this.comboBoxPortParity.Location = new System.Drawing.Point(129, 118);
            this.comboBoxPortParity.Name = "comboBoxPortParity";
            this.comboBoxPortParity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPortParity.TabIndex = 5;
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(129, 64);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPortName.TabIndex = 3;
            // 
            // comboBoxPortBaudRate
            // 
            this.comboBoxPortBaudRate.FormattingEnabled = true;
            this.comboBoxPortBaudRate.Location = new System.Drawing.Point(129, 91);
            this.comboBoxPortBaudRate.Name = "comboBoxPortBaudRate";
            this.comboBoxPortBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPortBaudRate.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Hardware Hub Serial Port Client";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "About Hardware Hub";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Serial Port GUID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Hardware Hub URL";
            // 
            // CurrentSerialPortGUID
            // 
            this.CurrentSerialPortGUID.Location = new System.Drawing.Point(129, 38);
            this.CurrentSerialPortGUID.Name = "CurrentSerialPortGUID";
            this.CurrentSerialPortGUID.Size = new System.Drawing.Size(260, 20);
            this.CurrentSerialPortGUID.TabIndex = 2;
            // 
            // CurrentHubURL
            // 
            this.CurrentHubURL.Location = new System.Drawing.Point(129, 12);
            this.CurrentHubURL.Name = "CurrentHubURL";
            this.CurrentHubURL.Size = new System.Drawing.Size(260, 20);
            this.CurrentHubURL.TabIndex = 1;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(129, 145);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataBits.TabIndex = 6;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(129, 172);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStopBits.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Serial Port Stop Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Serial Port Data Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Serial Port Parity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Serial Port Baud Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Serial Port Name";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // checkBoxIsOpen
            // 
            this.checkBoxIsOpen.AutoSize = true;
            this.checkBoxIsOpen.Location = new System.Drawing.Point(395, 41);
            this.checkBoxIsOpen.Name = "checkBoxIsOpen";
            this.checkBoxIsOpen.Size = new System.Drawing.Size(82, 17);
            this.checkBoxIsOpen.TabIndex = 8;
            this.checkBoxIsOpen.Text = "Port is open";
            this.checkBoxIsOpen.UseVisualStyleBackColor = false;
            this.checkBoxIsOpen.CheckedChanged += new System.EventHandler(this.checkBoxIsOpen_CheckedChanged);
            // 
            // BarcodeBox
            // 
            this.BarcodeBox.Location = new System.Drawing.Point(129, 202);
            this.BarcodeBox.Name = "BarcodeBox";
            this.BarcodeBox.ReadOnly = true;
            this.BarcodeBox.Size = new System.Drawing.Size(121, 20);
            this.BarcodeBox.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Last Data";
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Enabled = false;
            this.ErrorTextBox.Location = new System.Drawing.Point(129, 228);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.Size = new System.Drawing.Size(397, 44);
            this.ErrorTextBox.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Message";
            // 
            // SerialPortClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(546, 287);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BarcodeBox);
            this.Controls.Add(this.checkBoxIsOpen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentSerialPortGUID);
            this.Controls.Add(this.CurrentHubURL);
            this.Controls.Add(this.comboBoxPortBaudRate);
            this.Controls.Add(this.comboBoxPortName);
            this.Controls.Add(this.comboBoxPortParity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SerialPortClient";
            this.ShowInTaskbar = false;
            this.Text = "Hardware Hub Serial Port Client";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareHubClient_FormClosing);
            this.Resize += new System.EventHandler(this.HardwareHubClient_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPortParity;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.ComboBox comboBoxPortBaudRate;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CurrentSerialPortGUID;
        private System.Windows.Forms.TextBox CurrentHubURL;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox checkBoxIsOpen;
        private System.Windows.Forms.TextBox BarcodeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Label label8;
    }
}

