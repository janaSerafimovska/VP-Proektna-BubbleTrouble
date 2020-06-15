using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    class BlueBall:Ball
    {
        public BlueBall(int Radius, Point Center, Color Color, int Width, int Height) : base(Radius, Center, Color, Width, Height) { }

        public override List<Ball> SplitBall(Point p)
        {
            List<Ball> NewBalls = new List<Ball>();
            Ball one = new RedBall(15, new Point(p.X + 10, p.Y - 10), Color.Red, this.Width, this.Height);
            one.InvertDirection();
            Ball two = new RedBall(15, new Point(p.X + 10, p.Y - 10), Color.Red, this.Width, this.Height);
            NewBalls.Add(one);
            NewBalls.Add(two);
            return NewBalls;
        }
    }
}
