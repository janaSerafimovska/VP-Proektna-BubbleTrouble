﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    class GreenBall:Ball
    {
        public GreenBall(int Radius, Point Center, Color Color, int Width, int Height) : base(Radius, Center, Color, Width, Height) { }

        public override List<Ball> SplitBall(Point p)
        {
            List<Ball> NewBalls = new List<Ball>();
            Ball one = new BlueBall(20, new Point(p.X + 20, p.Y - 10), Color.LightBlue, this.Width, this.Height);
            one.InvertDirection();
            Ball two = new BlueBall(20, new Point(p.X + 20, p.Y - 10), Color.Blue,this.Width, this.Height);
            NewBalls.Add(one);
            NewBalls.Add(two);
            return NewBalls;
        }
    }
}
