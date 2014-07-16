using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CPL_Adapter
{
    class ConfigInfo
    {
        /// <summary>
        /// DAQ端wits接收IP
        /// </summary>
        public string DaqIP="127.0.0.1";
        /// <summary>
        /// DAQ端wits接收端口号
        /// </summary>
        public int DaqPort=3000;
        /// <summary>
        /// Glas端WITS服务端口号
        /// </summary>
        public int GlasPort=3001;
        /// <summary>
        /// Glas端WITS服务IP
        /// </summary>
        public string GlasIP="10.242.100.83";
        /// <summary>
        /// DAQ箱串口号
        /// </summary>
        public string ComPortNum = "COM1";
        /// <summary>
        /// 串口通讯波特率
        /// </summary>
        public int BaudRate = 115200;
        /// <summary>
        /// 配置信息是否有效
        /// </summary>
        public bool IsValue = false;

    }
    class Config
    {
        /// <summary>
        /// 全局配置信息
        /// </summary>
        public static ConfigInfo CfgInfo = new ConfigInfo();

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig()
        {
            bool bIsSave = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                //LocalDeptPort
                //XmlElement eleLocalDeptPort = doc.CreateElement("LocalDeptPort");
                //XmlText txtLocalDeptPort = doc.CreateTextNode(CfgInfo.LocalDeptPort.ToString());
                ////LocalCmdRecvPort
                //XmlElement eleLocalCmdRecvPort = doc.CreateElement("LocalCmdRecvPort");
                //XmlText txtLocalCmdRecvPort = doc.CreateTextNode(CfgInfo.LocalCmdRecvPort.ToString());
                //CMSWitsRecvIP
                XmlElement eleDaqIP = doc.CreateElement("DaqIP");
                XmlText txtDaqIP = doc.CreateTextNode(CfgInfo.DaqIP);
                //CMSWitsRecvPort
                XmlElement eleDaqPort = doc.CreateElement("DaqPort");
                XmlText txtDaqPort = doc.CreateTextNode(CfgInfo.DaqPort.ToString());
                //CPLWitsPort
                XmlElement eleGlasPort = doc.CreateElement("GlasPort");
                XmlText txtGlasPort = doc.CreateTextNode(CfgInfo.GlasPort.ToString());
                //CPLWitsIP
                XmlElement eleGlasIP = doc.CreateElement("GlasIP");
                XmlText txtGlasIP = doc.CreateTextNode(CfgInfo.GlasIP.ToString());
                //ComPortNum
                XmlElement eleComPortNum = doc.CreateElement("ComPortNum");
                XmlText txtComPortNum = doc.CreateTextNode(CfgInfo.ComPortNum);
                //BaudRate
                XmlElement eleBaudRate = doc.CreateElement("BaudRate");
                XmlText txtBaudRate = doc.CreateTextNode(CfgInfo.BaudRate.ToString());
                //DisplayMode
                //XmlElement eleDisplayMode = doc.CreateElement("DisplayMode");
                //XmlText txtDisplayMode = doc.CreateTextNode(CfgInfo.DisplayMode.ToString());

                XmlNode newElem = doc.CreateNode("element", "config", "");
                //newElem.AppendChild(eleLocalDeptPort);
                //newElem.LastChild.AppendChild(txtLocalDeptPort);

                //newElem.AppendChild(eleLocalCmdRecvPort);
                //newElem.LastChild.AppendChild(txtLocalCmdRecvPort);

                newElem.AppendChild(eleDaqIP);
                newElem.LastChild.AppendChild(txtDaqIP);

                //newElem.AppendChild(eleLocalDeptPort);
                //newElem.LastChild.AppendChild(txtLocalDeptPort);

                newElem.AppendChild(eleDaqPort);
                newElem.LastChild.AppendChild(txtDaqPort);

                newElem.AppendChild(eleGlasPort);
                newElem.LastChild.AppendChild(txtGlasPort);

                newElem.AppendChild(eleGlasIP);
                newElem.LastChild.AppendChild(txtGlasIP);

                newElem.AppendChild(eleComPortNum);
                newElem.LastChild.AppendChild(txtComPortNum);

                newElem.AppendChild(eleBaudRate);
                newElem.LastChild.AppendChild(txtBaudRate);

                //newElem.AppendChild(eleDisplayMode);
                //newElem.LastChild.AppendChild(txtDisplayMode);

                XmlElement root = doc.CreateElement("config");
                root.AppendChild(newElem);
                doc.AppendChild(root);
                doc.Save("config.xml");
                
                bIsSave = true;
            }
            catch 
            {
                bIsSave = false;
            }
            return bIsSave;
        }
        
        /// <summary>
        /// 获取配置信息 
        /// </summary>
        /// <returns></returns>
        public static bool GetConfig()
        {
            bool bIsGet = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");

                //CfgInfo.LocalDeptPort=int.Parse(doc.SelectSingleNode("//LocalDeptPort").InnerText);
                //CfgInfo.LocalCmdRecvPort = int.Parse(doc.SelectSingleNode("//LocalCmdRecvPort").InnerText);
                CfgInfo.DaqIP = doc.SelectSingleNode("//DaqIP").InnerText;
                CfgInfo.DaqPort = int.Parse(doc.SelectSingleNode("//DaqPort").InnerText);
                CfgInfo.GlasPort = int.Parse(doc.SelectSingleNode("//GlasPort").InnerText);
                CfgInfo.GlasIP = doc.SelectSingleNode("//GlasIP").InnerText;
                CfgInfo.ComPortNum = doc.SelectSingleNode("//ComPortNum").InnerText;
                CfgInfo.BaudRate = int.Parse(doc.SelectSingleNode("//BaudRate").InnerText);
                //CfgInfo.DisplayMode = int.Parse(doc.SelectSingleNode("//DisplayMode").InnerText);


                XmlDocument xmldoc = new XmlDocument();
                //if (File.Exists("NodeSettings.xml"))
                //{
                //    xmldoc.Load("NodeSettings.xml");
                //    XmlNodeList xmlnode = xmldoc.SelectSingleNode("Settings").ChildNodes;
                //    foreach (XmlElement element in xmlnode)
                //    {
                //        if (element.Attributes["purpose"].Value == "driller")
                //        {
                //            //司显属性值取得
                //            CfgInfo.DeviceSN = element.Attributes["deviceSN"].Value;
                //            CfgInfo.NetKey = element.Attributes["netKey"].Value;
                //            break;
                //        }
                //    }
                //}

                bIsGet = true;
            }
            catch
            {
                bIsGet = false;
            }
            return bIsGet;   
        }
        
    }
}