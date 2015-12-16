using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderController
{
    public partial class DebugForm : Form
    {
        SKSerial sk = new SKSerial();

        public DebugForm()
        {
            InitializeComponent();
        }
        
        private void DebugForm_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < sk.get_com_list().Length; i++)
                //textBox1.AppendText(sk.get_com_list()[i] + "\r\n");
            sk.set_com("COM4");
            sk.connect(); 
        
            byte[] v0 = { 50, 50, 50, 50, 50, 50 };
            byte[] v1 = { 90, 50, 90, 50, 90, 50 };
            byte[] v3 = { 40, 50, 40, 50, 40, 50 };
            byte[] v2 = { 50, 90, 50, 90, 50, 90 };
            byte[] v4 = { 50, 40, 50, 40, 50, 40 };


            byte[] h0 = { 30, 50, 50, 40, 60, 50 };
            byte[] h1 = { 30, 70, 50, 50, 70, 70 };
            byte[] h2 = { 30, 40, 50, 30, 60, 40 };
            byte[] h3 = { 50, 50, 70, 40, 80, 50 };
            

            //sk.control(SKSerial.Type.LEFT_AND_RIGHT, test);
            //System.Threading.Thread.Sleep(260);
            //每次发送完成后，请至少等待(5*max_turn+10)毫秒后再次操作本舵机组</para>
            for (int i = 0; i < 0; i++)
            {
            //三只
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v1);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h1);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v3);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h2);
            //另三只
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v2);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h3);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v4);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);

           }
            byte[] test = { 80, 90, 80, 10, 10, 10 };
            //byte[] h0 = { 30, 50, 50, 40, 60, 50 };
            byte[] t1 = { 30, 80, 50, 10, 60, 10 };
            byte[] t2 = { 80, 90, 90, 10, 10, 10 };
            byte[] t3 = { 30, 50, 50, 40, 60, 50 };

            for (int i = 0; i < 1; i++)
            {
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v1);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, t1);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v2);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, t2);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.LEFT_AND_RIGHT, t3);
                System.Threading.Thread.Sleep(260);
            }
            sk.disconnect();
        }
    }
}
