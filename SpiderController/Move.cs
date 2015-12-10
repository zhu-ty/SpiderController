using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderController
{
    
    //全局变量N的声明忘记格式了
    class Motor 
    {
        int num;
        int angle;

        public Motor (int n, int a = 50) {
            this.num = n;
            this.angle = a;
        }
        public void setNum (int n) {
            this.num = n;
        }
        public int getAngle () 
        {
            return this.angle;
        }
    }

    class Group
    {
        const int N = 6;
        Motor[] group = new Motor[N];
        int[] Status = new int[N];

        public Group()
        {
            for (int i = 0; i < N; i++)
            {
                group[i].setNum(i);
                Status[i] = group[i].getAngle();
            }
        }

        public void renewStatus(int[] newState)
        {
            for (int i = 0; i < N; i++)
            {
                Status[i] = newState[i];
            }
        }
        public int[] getStatus()
        {
            return Status;
        }
    }

    class Move
    {
        const int N = 6;
        Group vertical = new Group();
        Group horizon  = new Group();
        //扭转角度全局变量，声明方法
        const int[] s1 = { 0, 0, 0 };//,{0},{0},{0},{0},{0}};


        public void Straight()
        {
            //状态待改
            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);
            horizon.renewStatus(s1);

            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
        }

        public void turnLeft() 
        {
            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);

            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);

            horizon.renewStatus(s1);
        }
        public void turnRight() 
        {
            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);

            vertical.renewStatus(s1);
            horizon.renewStatus(s1);
            vertical.renewStatus(s1);

            horizon.renewStatus(s1);
        }
    }
    enum Pos { LEFT, RIGHT, FRONT, UNKNOWN, EEROR};
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
                    //warning
                    return Pos.EEROR;
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
