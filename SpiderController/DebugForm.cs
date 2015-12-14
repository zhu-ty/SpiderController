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
            sk.set_com("COM3");
            sk.connect();
            byte[] s6 = new byte[6];
            for (int i = 0; i < 6; i++) s6[i] = 20;
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, s6);
            sk.disconnect();
        }
    }
}
