using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderController
{
    class SKSerial
    {
        public SKSerial();

        public void set_com(string your_com);
        public string[] get_com_list();
        public void connect();
        public void disconnect();
        public void control_at(int servo_num, int pos);



        private string com;
    }
}
