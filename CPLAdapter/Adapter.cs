using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace CPL_Adapter
{
    class Adapter
    {
        private GroundBox gBox = null;
        private SerialPort curPort = null;
        UdpServer udpServer = null;
        TcpServer tcpServer = null;
        TcpClient tcpClient = null;

        private byte[] buffer { get; set; }
        private long mark = 0;
        public bool IsAcq { get; set; }
        public Adapter()
        {
            //gBox = new GroundBox(DataRecvCallback, Config.CfgInfo.ComPortNum,Config.CfgInfo.BaudRate, Config.CfgInfo.DeviceSN, Config.CfgInfo.NetKey);
            curPort = new SerialPort(Config.CfgInfo.ComPortNum, Config.CfgInfo.BaudRate);
            udpServer = new UdpServer(Config.CfgInfo.LocalDeptPort);
            tcpServer = new TcpServer(Config.CfgInfo.LocalCmdRecvPort);
            tcpClient = new TcpClient(Config.CfgInfo.CPLWitsIP, Config.CfgInfo.CPLWitsPort, Config.CfgInfo.CMSWitsRecvIP, Config.CfgInfo.CMSWitsRecvPort,gBox);
            this.curPort.DataReceived += curPort_DataReceived;
        }

        private void curPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try {
                int length = curPort.BytesToRead;//接收数据长度
                buffer = new byte[length];
                curPort.Read(buffer, 0, length);
                mark += buffer.Length;
                Trace.WriteLine(converter._converter.ByteArrayToHexString(buffer) + "\r\n");
                if (IsAcq)
                    Start();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        private void DataRecvCallback(byte[] datalist)
        {
            CommonData.SaveQueueItem(datalist);
            Debug.WriteLine(DateTime.Now.ToString());
            for (int i = 0; i < datalist.Length; i++)
            {

                Debug.Write(string.Format("{0:X} ", datalist[i]));
                if (i % 16 == 0)
                {
                    System.Diagnostics.Debug.Write("\n");
                }
            }
            Debug.Write("\n\n\n\n");
            return;
        }
        public string Start()
        {
            if (!gBox.Start())
            {
                return "打开串口出错!";
            }
            if (!udpServer.Start())
            {
                gBox.Stop();
                return "打开从CMS接收数据监听端口出错!";
            }
            if (!tcpServer.Start())
            {
                gBox.Stop();
                udpServer.Stop();
                return "打开命令接收数据出错!";
            }
            if (!tcpClient.Start())
            {
                gBox.Stop();
                udpServer.Stop();
                tcpServer.Stop();
                return "打开从CPL接收数据的wits线程出错!";
            }
            return null;
        }
        public void Stop()
        {
            gBox.Stop();
            udpServer.Stop();
            tcpServer.Stop();
            tcpClient.Stop();
        }
    }
}