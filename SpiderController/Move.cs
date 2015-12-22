using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderController
{
    class Move
    {
        const int N = 6;
        public SKSerial sk = new SKSerial();

        byte[] v0 = { 50, 50, 50, 50, 50, 50 };
        byte[] v1 = { 50, 90, 50, 90, 50, 90 }; //1 3 5
        byte[] v2 = { 90, 50, 90, 50, 90, 50 }; //2 4 6

        byte[] v3 = { 50, 30, 50, 30, 50, 30 };
        byte[] v4 = { 30, 50, 30, 50, 30, 50 };

        //初始状态
        byte[] h0 = { 30, 50, 50, 40, 60, 50 };
        //逆时针
        byte[] h1 = { 0, 50, 5, 40, 90, 50 };
        byte[] h2 = { 0, 5, 5, 80, 90, 90 };
        //顺时针
        byte[] h3 = { 70, 50, 90, 40, 10, 50 };
        byte[] h4 = { 70, 90, 90, 0, 10, 0 };
        //直行
        byte[] h5 = { 60, 50, 90, 40, 85, 50 };
        byte[] h6 = { 30, 80, 50, 80, 60, 90 };

        private void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        
        public void Straight()
        {
            int a = 3;
            while (a-- > 0)
            {
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v1);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h5);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.UP_AND_DOWN, v3);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);

                sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
                System.Threading.Thread.Sleep(260);
                sk.control(SKSerial.Type.UP_AND_DOWN, v0);
                System.Threading.Thread.Sleep(260);
            }

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h6);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v4);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);
        }

        public void turnLeft() 
        {
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h1);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h2);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);
        }

        public void turnRight() 
        {
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h3);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h4);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);
        }

        public void stay()
        {
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, v0);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, h0);
            delay(260);
        }
        public void move(int order)
        {
            switch (order)
            {
                case 1:
                    turnLeft();
                    break;
                case 2:
                    turnRight();
                    break;
                case 3:
                    Straight();
                    break;
                default:
                    stay();
                    break;
            }
        } 
    }
}
