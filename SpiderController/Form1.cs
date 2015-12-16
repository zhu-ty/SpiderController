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
        bool Auto, Man, connected;
        int order;
        private CheckBox[] clb;
        Move spider = new Move();
        
        
        public Form1()
        {
            InitializeComponent();
            Auto = Man = connected = false;
            
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            Auto = true; Man = false; 
        }

        private void test(int order)
        {
            switch (order)
            {
                case 1:
                    label1.Text += "1";
                    break;
                case 2:
                    label1.Text += "2";
                    break;
                case 3:
                    label1.Text += "3";
                    break;
                case 4:
                    label1.Text += "4";
                    break;
                default:
                    break;
            }
        }

        private void button3_mouse_down(object sender, MouseEventArgs e)
        {
            order = 3;
            timer1.Start();
        }

        private void button3_Mouse_up(object sender, MouseEventArgs e)
        {
            order = 4;
            timer1.Stop();
        }

        private string get_com(string[] coms)
        {
            for (int i = 0; i < coms.Length; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    return coms[i];
            }
            return null;
        }

        private void Form1_load(object sender, EventArgs e)
        {

            string[] coms = spider.sk.get_com_list();
            clb = new CheckBox[coms.Length * coms.Length];
            for (int i = 0; i < coms.Length; i++)
            {
                checkedListBox1.Items.Add(coms[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tmp = get_com(spider.sk.get_com_list());
            if ( tmp != null)
            {
                spider.sk.set_com(tmp);
                textBox2.BackColor = Color.GreenYellow;
                
            }
            spider.sk.connect();
            connected = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            spider.sk.disconnect();
            connected = false;
            textBox2.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Auto = false; Man = true;
        }

        private void left_Mouse_Down(object sender, MouseEventArgs e)
        {
            order = 1;
            timer2.Start();
        }

        private void left_Mouse_Up(object sender, MouseEventArgs e)
        {
            order = 4;
            timer2.Stop();
        }

        private void right_Mouse_Down(object sender, MouseEventArgs e)
        {
            order = 2;
            timer2.Start();
        }

        private void right_Mouse_Up(object sender, MouseEventArgs e)
        {
            order = 4;
            timer2.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Auto && Man && connected)
                test(order);
                //spider.move(order);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!Auto && Man && connected) test(order);
                //spider.move(order);
        }
    }
}
