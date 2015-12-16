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
        //扭转角度全局变量，声明方法
        byte[] v0 = { 50, 50, 50, 50, 50, 50 };
        byte[] v1 = { 90, 50, 90, 50, 90, 50 };
        byte[] v3 = { 40, 50, 40, 50, 40, 50 };
        byte[] v2 = { 50, 90, 50, 90, 50, 90 };
        byte[] v4 = { 50, 40, 50, 40, 50, 40 };


        byte[] h0 = { 50, 50, 50, 50, 50, 50 };
        byte[] h1 = { 50, 70, 50, 70, 50, 70 };
        byte[] h2 = { 50, 40, 50, 40, 50, 40 };
        byte[] h3 = { 70, 50, 70, 50, 70, 50 };

        private void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        
        public void Straight()
        {
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
            delay(1260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            delay(1260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h1);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v3);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h2);
            //另三只
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, v0);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, h0);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h3);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v4);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, h0);
        }

        byte[] t1 = { 50, 80, 50, 10, 50, 10 };
        byte[] t2 = { 80, 80, 80, 10, 10, 10 };
        byte[] t3 = { 50, 50, 50, 50, 50, 50 };
        //turnleft
        byte[] t4 = { 80, 50, 80, 50, 10, 50 };
        byte[] t5 = { 10, 10, 10, 80, 80, 80 };
        byte[] t6 = { 50, 50, 50, 50, 50, 50 };

        public void turnRight() 
        {
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, v0);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, h0);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t1);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t2);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t3);
            delay(260);
        }

        public void turnLeft() 
        {
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, v0);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, h0);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v1);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t4);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            delay(260);

            sk.control(SKSerial.Type.UP_AND_DOWN, v2);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t5);
            delay(260);
            sk.control(SKSerial.Type.UP_AND_DOWN, v0);
            delay(260);
            sk.control(SKSerial.Type.LEFT_AND_RIGHT, t6);
            delay(260);
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
