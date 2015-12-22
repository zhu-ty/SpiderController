using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SpiderController
{
    class AutoInfoCatcher
    {
        /// <summary>
        /// 新建AutoInfoCatcher类，提供目标Ip地址
        /// </summary>
        /// <param name="ip">ip地址，string，请确保输入格式正确</param>
        public AutoInfoCatcher(string ip)
        {
            try
            {
                target_ip = IPAddress.Parse(ip);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("IP转换失败！");
            }
            if (!connect())
            {
                System.Windows.Forms.MessageBox.Show("连接失败！");
            }
        }
        /// <summary>
        /// 新建AutoInfoCatcher类，提供目标Ip地址
        /// </summary>
        /// <param name="ip">ip地址</param>
        public AutoInfoCatcher(IPAddress ip)
        {
            try
            {
                target_ip = IPAddress.Parse(ip.ToString());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("IP转换失败！");
            }
            if (!connect())
            {
                System.Windows.Forms.MessageBox.Show("连接失败！");
            }
        }
        /// <summary>
        /// 获得当前的操作目标
        /// <para>若无法收到，则返回右转</para>
        /// </summary>
        /// <returns></returns>
        public Info get_info()
        {
            try
            {
                byte[] send_byte = new byte[1];
                send_byte[0] = 0x31;
                client.Send(send_byte);
                byte[] rev_buffer = new byte[10];
                int len = client.Receive(rev_buffer);
                if (len <= 0)
                    return Info.RIGHT;
                else
                {
                    switch (rev_buffer[0])
                    {
                        case (byte)'0':
                            return Info.STRAIGHT;
                        case (byte)'1':
                            return Info.LEFT;
                        case (byte)'2':
                            return Info.RIGHT;
                        default:
                            return Info.RIGHT;
                    }
                }
            }
            catch (Exception)
            {
                return Info.RIGHT;
            }
        }

        public enum Info { STRAIGHT, LEFT, RIGHT };
        /// <summary>
        /// 连接等待时间
        /// </summary>
        public int MAX_CONNECT_SECONDS = 10;


        private bool connect()
        {
            IAsyncResult connect_result = client.BeginConnect(target_ip, port, null, null);
            connect_result.AsyncWaitHandle.WaitOne(MAX_CONNECT_SECONDS * 1000);
            if (!connect_result.IsCompleted)
            {
                client.Close();
                return false;
            }
            return true;
        }
        private IPAddress target_ip;
        private int port = 8888;
        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
}
