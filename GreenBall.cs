using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    class GreenBall:Ball
    {
        public GreenBall( Point Center, int Width, int Height) : base(30, Center, Color.MediumSpringGreen, Width, Height) { }

        public override List<Ball> SplitBall(Point p)
        {
            List<Ball> NewBalls = new List<Ball>();
            Ball one = new BlueBall( new Point(p.X + 20, p.Y - 10), this.Width, this.Height);
            one.InvertDirection();
            Ball two = new BlueBall( new Point(p.X + 20, p.Y - 10), this.Width, this.Height);
            NewBalls.Add(one);
            NewBalls.Add(two);
            return NewBalls;
        }
    }
}
