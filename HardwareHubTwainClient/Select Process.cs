using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HardwareHubTwainClient
{
    public partial class Select_Process : Form
    {
        public string selectedWindowTitle = "";
        public bool cancelAction;

        public Select_Process()
        {
            InitializeComponent();
            CopyProcessesToListBox();
        }
        public bool ProcessSelected()
        {
            return !cancelAction;
        }
        public string GetSelectedWindowTitle()
        {
            return selectedWindowTitle;
        }
        private void CopyProcessesToListBox()
        {
            string procName;
            try
            {
                listBox1.Items.Clear();
                Process[] processlist = Process.GetProcesses();
                foreach (Process process in processlist)
                {
                    procName = "(" + process.ProcessName + ")" + process.MainWindowTitle;
                    listBox1.Items.Add(procName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancelAction = false;
            if (listBox1.SelectedItem != null)
                selectedWindowTitle = listBox1.SelectedItem.ToString();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelAction = true;
            selectedWindowTitle = "";
            this.Close();
        }


    }
}
