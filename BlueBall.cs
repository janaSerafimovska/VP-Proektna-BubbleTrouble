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
        public BlueBall( Point Center, int Width, int Height) : base(25, Center, Color.Blue, Width, Height) { }

        public override List<Ball> SplitBall(Point p)
        {
            List<Ball> NewBalls = new List<Ball>();
            Ball one = new RedBall(new Point(p.X + 10, p.Y - 10), this.Width, this.Height);
            one.InvertDirection();
            Ball two = new RedBall(new Point(p.X + 10, p.Y - 10),  this.Width, this.Height);
            NewBalls.Add(one);
            NewBalls.Add(two);
            return NewBalls;
        }
    }
}
