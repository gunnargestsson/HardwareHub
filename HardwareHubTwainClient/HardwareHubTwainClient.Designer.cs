namespace HardwareHubTwainClient
{
    partial class HardwareHubTwainClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HardwareHubTwainClient));
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentScannerGUID = new System.Windows.Forms.TextBox();
            this.CurrentHubURL = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.CheckHub_Timer = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.LogCheckBox = new System.Windows.Forms.CheckBox();
            this.ProcessName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "About Twain Control";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Messages";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(132, 95);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageTextBox.Size = new System.Drawing.Size(397, 207);
            this.MessageTextBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Twain Scanner GUID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hardware Hub URL";
            // 
            // CurrentScannerGUID
            // 
            this.CurrentScannerGUID.Location = new System.Drawing.Point(132, 38);
            this.CurrentScannerGUID.Name = "CurrentScannerGUID";
            this.CurrentScannerGUID.Size = new System.Drawing.Size(260, 20);
            this.CurrentScannerGUID.TabIndex = 2;
            // 
            // CurrentHubURL
            // 
            this.CurrentHubURL.Location = new System.Drawing.Point(132, 12);
            this.CurrentHubURL.Name = "CurrentHubURL";
            this.CurrentHubURL.Size = new System.Drawing.Size(260, 20);
            this.CurrentHubURL.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Hardware Hub Twain Client";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // CheckHub_Timer
            // 
            this.CheckHub_Timer.Interval = 200;
            this.CheckHub_Timer.Tick += new System.EventHandler(this.CheckHub_Timer_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "About Hardware Hub";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LogCheckBox
            // 
            this.LogCheckBox.AutoSize = true;
            this.LogCheckBox.Location = new System.Drawing.Point(21, 117);
            this.LogCheckBox.Name = "LogCheckBox";
            this.LogCheckBox.Size = new System.Drawing.Size(44, 17);
            this.LogCheckBox.TabIndex = 31;
            this.LogCheckBox.Text = "Log";
            this.LogCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProcessName
            // 
            this.ProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessName.Location = new System.Drawing.Point(132, 64);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(260, 20);
            this.ProcessName.TabIndex = 32;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(398, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "Select Process";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "PopUp Process Name";
            // 
            // HardwareHubTwainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(546, 331);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ProcessName);
            this.Controls.Add(this.LogCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentScannerGUID);
            this.Controls.Add(this.CurrentHubURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HardwareHubTwainClient";
            this.ShowInTaskbar = false;
            this.Text = "Hardware Hub Twain Client";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareHubClient_FormClosing);
            this.Resize += new System.EventHandler(this.HardwareHubTwainClient_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CurrentScannerGUID;
        private System.Windows.Forms.TextBox CurrentHubURL;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer CheckHub_Timer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox LogCheckBox;
        private System.Windows.Forms.TextBox ProcessName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
    }
}

