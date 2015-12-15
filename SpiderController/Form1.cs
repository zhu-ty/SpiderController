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
    public partial class Form1 : Form
    {
        bool Auto = false, Man = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AutoControl spider = new AutoControl();
            if (!Auto && Man) spider.Straight();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Auto = true;
        }
    }
}
