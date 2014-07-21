﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CPL_Adapter
{
    /// <summary>
    /// TCP服务器,接收CPL连接
    /// </summary>
    class TcpServer
    {
        private int TcpPort = 3001;
        private Socket ServerSocket = null;
        private Thread RecvThread = null;
        private Socket CurClientSocket = null;
        private object ClientSocketAsynObj = new object();

        /// <summary>
        /// 接收定时器
        /// </summary>
        private MMTimer RecvTimer = null;
        private UInt16 RecvCount = 0;
        /// <summary>
        /// 是否开始测井
        /// </summary>
        private bool IsStartWell = false;
        /// <summary>
        /// 是否开始深度跟踪
        /// </summary>
        private bool IsStartDepth = false;
        /// <summary>
        /// 存放井深的字节数组
        /// </summary>
        private byte[] WellDeptBytes = null;
        /// <summary>
        /// 是否继续线程循环
        /// </summary>
        private bool IsContinue = true;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tcpPort">端口号</param>
        public TcpServer(int tcpPort)
        {
            this.TcpPort = tcpPort;
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RecvThread = new Thread(new ThreadStart(this.RecvThreadFunc));
            RecvTimer = new MMTimer(this.SendTimerFunc);
            WellDeptBytes = new byte[6];
            WellDeptBytes[0] = WellDeptBytes[1] = (byte)'E';
        }

        /// <summary>
        /// tcp服务开始启动
        /// </summary>
        public bool Start()
        {
            bool bRet = false;
            try
            {
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, TcpPort);
                ServerSocket.Bind(ipEnd);
                ServerSocket.Listen(10);
                RecvThread.Start();
                RecvTimer.Start(1000, true);
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("TcpServer::Start->" + ex.Message);
                bRet = false;
            }
            return bRet;
        }
        /// <summary>
        /// tcp服务开始关闭
        /// </summary>
        public void Stop()
        {
            IsContinue = false;

            try
            {
                if (ServerSocket != null)
                {
                    ServerSocket.Close();
                }
            }
            catch { }
            try
            {

                if (RecvThread != null)
                {
                    RecvThread.Abort();
                }
            }
            catch { }
            try
            {
                if (RecvTimer != null)
                {
                    RecvTimer.Stop();
                }
            }
            catch { }
        }
        /// <summary>
        /// 在此线程函数中接收命令数据
        /// </summary>
        void RecvThreadFunc()
        {
            System.Diagnostics.Trace.WriteLine("TcpServer 线程启动！");
            byte[] bytesRecv = new byte[64];
            while (IsContinue)
            {
                try
                {
                    CurClientSocket = ServerSocket.Accept();
                    System.Diagnostics.Trace.WriteLine(string.Format("客户端{0}已经连接！",((IPEndPoint)CurClientSocket.RemoteEndPoint).Address.ToString()));
                    CurClientSocket.Send(ASCIIEncoding.ASCII.GetBytes("Server OK,YOU CAN SEND COMMAND"));
                  
                    while (IsContinue)//一个新的连接
                    {
                        int rcvLen = CurClientSocket.Receive(bytesRecv);
                        if (rcvLen <= 0)
                        {
                            lock (ClientSocketAsynObj)
                            {
                                CurClientSocket.Close();
                                CurClientSocket = null;
                                IsStartWell = IsStartDepth = false;
                            }
                            break;
                        }
                        //对比 如果是开始发送指令
                        if (rcvLen == 32 && bytesRecv[0] == 'C' && bytesRecv[1] == 'O' && bytesRecv[2] == 'M' && bytesRecv[3] == 'D'
                            && bytesRecv[4] == 0x20 && bytesRecv[5] == 0x20 && bytesRecv[7] == 0x30)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("收到指令{0}", bytesRecv[6]));
                            lock (ClientSocketAsynObj)
                            {
                                //开始测井0x3000
                                if (bytesRecv[6] == 0x00)
                                {
                                    IsStartWell = true;
                                }//停止测井
                                else if (bytesRecv[6] == 0x01)
                                {
                                    IsStartWell = false;
                                }//开始深度跟踪
                                else if (bytesRecv[6] == 0x02)
                                {
                                    IsStartDepth = true;
                                }
                                //停止深度跟踪
                                else if (bytesRecv[6] == 0x03)
                                {
                                    IsStartDepth = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine("TCPServer::RecvThreadFunc->" + e.Message);
                }
            }
        }

        private void print(byte[] receive)
        {
            //System.Diagnostics.Debug.WriteLine(receive.Length + "->" + DateTime.Now.ToString());
            //return;
            int c = 0;
            for (int i = 0; i < receive.Length; i++)
            {
                System.Diagnostics.Debug.Write(string.Format("{0:X2} ", receive[i]));
                c++;
                if (c == 16)
                {
                    System.Diagnostics.Debug.Write("\n");
                    c = 0;
                }
            }
            System.Diagnostics.Debug.Write("\n\n");
        }
        /// <summary>
        /// 定时发送函数
        /// </summary>
        /// <param name="uTimerID"></param>
        /// <param name="uMsg"></param>
        /// <param name="dwUser"></param>
        /// <param name="dw1"></param>
        /// <param name="dw2"></param>
        private void SendTimerFunc(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2)
        {
            try
            {
                RecvCount++;
                //发送深度数据//c3 f5 48 40
                CommonData.WellDepth++;//????????
                byte[] curWellDeptBytes = BitConverter.GetBytes(CommonData.WellDepth);
                WellDeptBytes[2] = curWellDeptBytes[0];
                WellDeptBytes[3] = curWellDeptBytes[1];
                WellDeptBytes[4] = curWellDeptBytes[2];
                WellDeptBytes[5] = curWellDeptBytes[3];

                lock (ClientSocketAsynObj)
                {
                    if (IsStartDepth && CurClientSocket != null && CurClientSocket.Connected)
                    {
                        if (CurClientSocket.Send(WellDeptBytes) <= 0)
                        {
                            System.Diagnostics.Trace.WriteLine("下发深度数据失败！");
                        }
                    }
                }


                lock (ClientSocketAsynObj)
                {
                    if (IsStartWell && CurClientSocket != null && CurClientSocket.Connected)
                    {
                        byte[] curSppBytes = CommonData.GetQueueItem();
                        if (curSppBytes != null)
                        {
                            if (CurClientSocket.Send(curSppBytes) <= 0)
                            {

                                System.Diagnostics.Trace.WriteLine("下发压力数据失败！");
                            }   
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine("TCPServer::SendTimerFunc->" + e.Message);
            }
        }
    }        
}
