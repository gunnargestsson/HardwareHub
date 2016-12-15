using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hardware_Hub_Setup_and_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            URLBox.Text = "http://hub.dynamics.is/HardwareHub.asmx";
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            try
            {
                HardwareHub.Hub hub = new HardwareHub.Hub();
                hub.Url = URLBox.Text;
                DataSourceBox.Text = hub.DataSourceGet(Convert.ToInt32(PinBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            try
            {
                HardwareHub.Hub hub = new HardwareHub.Hub();
                hub.Url = URLBox.Text;
                MessageBox.Show(hub.DataSourceSet(DataSourceBox.Text, Convert.ToInt32(PinBox.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            try
            {
                HardwareHub.Hub hub = new HardwareHub.Hub();
                hub.Url = URLBox.Text;
                string g = Guid.NewGuid().ToString();
                string sendcommand = "Hub Test";
                string receivecommand = "";
                string parm1 = "";
                string parm2 = "";
                string parm3 = "";
                string parm4 = "";
                if (hub.SendCommand(g, sendcommand, "", "", "", ""))
                {
                    receivecommand = hub.ReceiveCommand(g, ref parm1, ref parm2, ref parm3, ref parm4);
                }
                if (receivecommand == sendcommand)
                {
                    MessageBox.Show("Hub Successfully Tested");
                }
                else
                {
                    MessageBox.Show("Hub Test Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

    }
}
