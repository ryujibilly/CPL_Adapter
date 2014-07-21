using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace CPL_Adapter
{
    public partial class Form1 : Form
    {
        private SerialPort curPort=null;
        Adapter adp = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            txtPort.Items.AddRange(SerialPort.GetPortNames());
            txtPort.SelectedIndex = 0;
            LoadConfig();
        }
        private void LoadConfig()
        {
            Config.GetConfig();
            txtPort.Text = Config.CfgInfo.ComPortNum;
            txtBaud.Text = Config.CfgInfo.BaudRate.ToString();
            txtGlasIP.Text = Config.CfgInfo.GlasIP;
            txtGlasPort.Text = Config.CfgInfo.GlasPort.ToString();
            txtDaqIP.Text = Config.CfgInfo.DaqIP;
            txtDaqPort.Text = Config.CfgInfo.DaqPort.ToString();
        }

        private void txtSave_Click(object sender, EventArgs e)
        {
            try
            {
                Config.CfgInfo.ComPortNum = txtPort.Text.Trim();
                Config.CfgInfo.BaudRate = int.Parse(txtBaud.Text.Trim());
                Config.CfgInfo.GlasIP = txtGlasIP.Text.Trim();
                Config.CfgInfo.GlasPort = int.Parse(txtGlasPort.Text.Trim());
                Config.CfgInfo.DaqIP = txtDaqIP.Text.Trim();
                Config.CfgInfo.DaqPort = int.Parse(txtDaqPort.Text.Trim());
                Config.SaveConfig();
            }
            catch
            {
                MessageBox.Show("保存出错，请检查数据格式是否正确!");
            }
           
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            adp = new Adapter();
            string str=adp.Start();
            if (str != null)
            {
                MessageBox.Show(str);
            }
            else
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (adp != null)
            {
                adp.Stop();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adp != null)
            {
                adp.Stop();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            curPort.Write(Command.RESEND,0,5);
        }

        private void btn_TEST_Click(object sender, EventArgs e)
        {
            curPort.Write(Command.TEST, 0, 5);
            Thread.Sleep(2000);
            curPort.Write(Command.VERSIONS, 0, 5);
        }

        private void btn_GOON_Click(object sender, EventArgs e)
        {
            curPort.Write(Command.GO_ON, 0, 5);
        }

        private void btn_SEND_Click(object sender, EventArgs e)
        {
            curPort.Write(Command.SEND, 0, 5);
        }

        private void txtPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPort.PortName = txtPort.SelectedText.Trim();
        }

    }
}
