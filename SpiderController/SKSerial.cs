using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace SpiderController
{
    class SKSerial
    {
        /// <summary>
        /// 舵机组选项
        /// </summary>
        public enum Type{UP_AND_DOWN,LEFT_AND_RIGHT};
        /// <summary>
        /// 单舵机组最大舵机数量
        /// </summary>
        public const int MAX_SERVO = 6;
        /// <summary>
        /// 舵机转动最大角度
        /// </summary>
        public const int MAX_POS = 90;
        /// <summary>
        /// 舵机转动最小角度
        /// </summary>
        public const int MIN_POS = 10;
        /// <summary>
        /// 中间位置
        /// </summary>
        public const int MID_POS = 50;

        /// <summary>
        /// 默认构造函数，应当依次调用set_com和connect才能开始发送
        /// </summary>
        public SKSerial()
        {
            main_port.StopBits = StopBits.One;
            main_port.BaudRate = 115200;
            main_port.DataBits = 8;
            main_port.Parity = Parity.None;
        }
        /// <summary>
        /// 设置新的串口号，当前串口（若有）、被设置的串口均会被关闭
        /// </summary>
        /// <param name="your_com">被设置串口号，如"COM3"</param>
        public void set_com(string your_com)
        {
            try
            {
                main_port.Close();
            }
            catch (Exception) { }
            main_port.PortName = your_com;
            if (main_port.IsOpen)
                main_port.Close();
        }
        /// <summary>
        /// 获得当前计算机的串口列表
        /// </summary>
        /// <returns></returns>
        public string[] get_com_list()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            return ports;
        }
        /// <summary>
        /// 打开已经设置的串口，若串口号未被正常设置或串口被占用，则会弹出错误窗口
        /// </summary>
        public void connect()
        {
            try
            {
                main_port.Open();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("串口打开失败！");
            }
        }
        /// <summary>
        /// 断开串口连接，任何情况下都不会弹出错误
        /// </summary>
        public void disconnect()
        {
            try
            {
                main_port.Close();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 控制舵机的转动，若发送成功，则返回true
        /// <para>为保证接受成功，请（尽量）多次（2~3次）发送</para>
        /// <para>每次发送完成后，请至少等待(5*max_turn+10)毫秒后再次操作本舵机组</para>
        /// <para>其中max_turn为本次转动中转动角度最大的舵机</para>
        /// </summary>
        /// <param name="t">
        /// 舵机组选项
        /// <para>若为UP_AND_DOWN，则为上下舵机组</para>
        /// <para>若为LEFT_AND_RIGHT，则为左右舵机组</para>
        /// </param>
        /// <param name="pos">
        /// 舵机组的各个角度，数组长度为MAX_SERVO(6)
        /// <para>目前pos内各个值仅能为10~90</para>
        /// </param>
        /// <param name="speed">
        /// 舵机转速，默认为5，勿动
        /// </param>
        /// <param name="delay">
        /// 舵机转动延迟，默认为5，勿动
        /// </param>
        /// <returns></returns>
        public bool control(Type t, byte[] pos,int speed = 5,int delay = 5)
        {
            if (main_port.IsOpen == false || pos.Length != MAX_SERVO || speed < 1 || speed > 7 || delay < 1 || delay > 7)
                return false;
            for (int i = 0; i < MAX_SERVO; i++)
            {
                if (pos[i] < MIN_POS || pos[i] > MAX_POS)
                    return false;
                else if (i > 2)
                    pos[i] = (byte)(2 * MID_POS - pos[i]);
            }
            byte[] to_send = new byte[8];
            to_send[0] = 0xFE;
            to_send[1] = (byte)((((t == Type.LEFT_AND_RIGHT) ? 0 : 1) << 7) | (speed << 4) | (delay << 1) | 0x01);
            Array.Copy(pos, 0, to_send, 2, 6);
            try
            {
                main_port.Write(to_send, 0, 2 + MAX_SERVO);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private SerialPort main_port = new SerialPort();
    }
}
