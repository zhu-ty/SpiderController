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
        byte[] v1 = { 90, 50, 90, 50, 90, 50 };
        byte[] v3 = { 40, 50, 40, 50, 40, 50 };
        byte[] v2 = { 50, 90, 50, 90, 50, 90 };
        byte[] v4 = { 50, 40, 50, 40, 50, 40 };


        byte[] h0 = { 30, 50, 50, 40, 60, 50 };
        byte[] h1 = { 30, 70, 50, 50, 70, 70 };
        byte[] h2 = { 30, 40, 50, 30, 60, 40 };
        byte[] h3 = { 50, 50, 70, 40, 80, 50 };

        private void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        
        public void Straight()
        {
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

        byte[] t1 = { 30, 80, 50, 10, 60, 10 };
        byte[] t2 = { 80, 90, 90, 10, 10, 10 };
        byte[] t3 = { 30, 50, 50, 40, 60, 50 };
        //turnleft
        byte[] t4 = { 90, 50, 90, 40, 10, 50 };
        byte[] t5 = { 90, 90, 90, 10, 10, 10 };
        byte[] t6 = { 30, 50, 50, 40, 60, 50 };

        public void turnRight() 
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

        public void turnLeft() 
        {
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t4);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t5);
            System.Threading.Thread.Sleep(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            System.Threading.Thread.Sleep(260);

            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t6);
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
    enum Pos { LEFT, RIGHT, FRONT, UNKNOWN, ERROR};
}
