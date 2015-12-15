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
        bool Auto, Man;
        int order;
        private CheckBox[] clb;
        Move spider = new Move();
        
        public Form1()
        {
            InitializeComponent();
            Auto = Man = false;
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
                    label1.BackColor = Color.White;
                    break;
                case 2:
                    label1.BackColor = Color.Yellow;
                    break;
                case 3:
                    label1.BackColor = Color.Green;
                    break;
                case 4:
                    label1.BackColor = Color.Blue;
                    break;
                default:
                    break;
            }
        }

        private void button3_mouse_down(object sender, MouseEventArgs e)
        {
            order = 3;
  
        }

        private void button3_Mouse_up(object sender, MouseEventArgs e)
        {
            order = 4;
            if (!Auto && Man) //test(order);
             spider.move(order);
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            spider.sk.disconnect();
            textBox2.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Auto = false; Man = true;
        }

        private void left_Mouse_Down(object sender, MouseEventArgs e)
        {
            order = 1;
            if (!Auto && Man) //test(order);
                 spider.move(order);
        }

        private void left_Mouse_Up(object sender, MouseEventArgs e)
        {
            order = 4;
            if (!Auto && Man) //test(order);
                 spider.move(order);
        }

        private void right_Mouse_Down(object sender, MouseEventArgs e)
        {
            order = 2;
            if (!Auto && Man) //test(order);
                 spider.move(order);
        }

        private void right_Mouse_Up(object sender, MouseEventArgs e)
        {
            order = 4;
            if (!Auto && Man) //test(order);
                 spider.move(order);
        }
    }
}
