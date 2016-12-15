namespace Hardware_Hub_Topaz_Client
{
    partial class TopazClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopazClient));
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentTopazGUID = new System.Windows.Forms.TextBox();
            this.CurrentHubURL = new System.Windows.Forms.TextBox();
            this.CheckHub_Timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.HotSpotTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "About Topaz Table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AboutTopaz_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Error message";
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Enabled = false;
            this.ErrorTextBox.Location = new System.Drawing.Point(132, 64);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(397, 181);
            this.ErrorTextBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Topaz Table GUID";
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
            // CurrentTopazGUID
            // 
            this.CurrentTopazGUID.Location = new System.Drawing.Point(132, 38);
            this.CurrentTopazGUID.Name = "CurrentTopazGUID";
            this.CurrentTopazGUID.Size = new System.Drawing.Size(260, 20);
            this.CurrentTopazGUID.TabIndex = 13;
            // 
            // CurrentHubURL
            // 
            this.CurrentHubURL.Location = new System.Drawing.Point(132, 12);
            this.CurrentHubURL.Name = "CurrentHubURL";
            this.CurrentHubURL.Size = new System.Drawing.Size(260, 20);
            this.CurrentHubURL.TabIndex = 11;
            // 
            // CheckHub_Timer
            // 
            this.CheckHub_Timer.Interval = 200;
            this.CheckHub_Timer.Tick += new System.EventHandler(this.CheckHub_Timer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Hardware Hub Topaz Client";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "About Hardware Hub";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AboutHub_Click);
            // 
            // HotSpotTimer
            // 
            this.HotSpotTimer.Tick += new System.EventHandler(this.HotSpotTimer_Tick);
            // 
            // TopazClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(546, 257);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentTopazGUID);
            this.Controls.Add(this.CurrentHubURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TopazClient";
            this.ShowInTaskbar = false;
            this.Text = "Hardware Hub Topaz Client";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareHubClient_FormClosing);
            this.Resize += new System.EventHandler(this.HardwareHubTopazClient_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CurrentTopazGUID;
        private System.Windows.Forms.TextBox CurrentHubURL;
        private System.Windows.Forms.Timer CheckHub_Timer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer HotSpotTimer;
    }
}

