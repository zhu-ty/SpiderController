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
        SKSerial group = new SKSerial();
        //扭转角度全局变量，声明方法
        byte [] s1 = { 0, 0, 0 };

        private void delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        
        public void Straight()
        {
            
            //状态待改
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            /// <para>每次发送完成后，请至少等待(5*max_turn+10)毫秒后再次操作本舵机组</para>
            /// <para>其中max_turn为本次转动中转动角度最大的舵机</para>
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);

            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1); 
        }

        public void turnLeft() 
        {
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);

            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);

            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
        }
        public void turnRight() 
        {
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);

            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);
            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
            group.control(SpiderController.SKSerial.Type.UP_AND_DOWN, s1);

            group.control(SpiderController.SKSerial.Type.LEFT_AND_RIGHT, s1);
        }
    }
    enum Pos { LEFT, RIGHT, FRONT, UNKNOWN, ERROR};
    class AutoControl : Move
    {
        int data;
        //传回的视频数据
        public Pos location(int data)
        {
            switch (data) {
                case 1:
                    return Pos.LEFT;
                case 2:
                    return Pos.RIGHT;
                case 3:
                    return Pos.FRONT;
                case 4:
                    return Pos.UNKNOWN;
                default:
                    System.Windows.Forms.MessageBox.Show("视频数据错误！");
                    return Pos.ERROR;
            }
        }
        void move()
        {
            while (true)
            {
                switch (location(data))
                {
                    case Pos.LEFT | Pos.UNKNOWN:
                        turnLeft();
                        break;
                    case Pos.RIGHT:
                        turnRight();
                        break;
                    case Pos.FRONT:
                        Straight();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    class ManControl:Move 
    {
        int order;
        
        public void move()
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
                    break;
            }
        } 
    }
}
