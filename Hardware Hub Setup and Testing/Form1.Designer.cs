namespace Hardware_Hub_Setup_and_Testing
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.PinBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.URLBox = new System.Windows.Forms.TextBox();
            this.DataSourceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GetButton = new System.Windows.Forms.Button();
            this.SetButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pin";
            // 
            // PinBox
            // 
            this.PinBox.Location = new System.Drawing.Point(101, 9);
            this.PinBox.Name = "PinBox";
            this.PinBox.Size = new System.Drawing.Size(100, 20);
            this.PinBox.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "URL";
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(101, 37);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(352, 20);
            this.URLBox.TabIndex = 3;
            // 
            // DataSourceBox
            // 
            this.DataSourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceBox.Location = new System.Drawing.Point(101, 67);
            this.DataSourceBox.Name = "DataSourceBox";
            this.DataSourceBox.Size = new System.Drawing.Size(550, 20);
            this.DataSourceBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Source";
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(101, 93);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(176, 23);
            this.GetButton.TabIndex = 6;
            this.GetButton.Text = "Get Data Source";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(101, 122);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(176, 23);
            this.SetButton.TabIndex = 7;
            this.SetButton.Text = "Set Data Source";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(101, 151);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(176, 23);
            this.TestButton.TabIndex = 8;
            this.TestButton.Text = "Test Command";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 212);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.GetButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataSourceBox);
            this.Controls.Add(this.URLBox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PinBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hardware Hub Setup and Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PinBox;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.TextBox DataSourceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GetButton;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Button TestButton;
    }
}

